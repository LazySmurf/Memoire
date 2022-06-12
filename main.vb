'                  _             _     
'                 (_)           | |    
'  _ __ ___   __ _ _ _ __ __   _| |__  
' | '_ ` _ \ / _` | | '_ \\ \ / / '_ \ 
' | | | | | | (_| | | | | |\ V /| |_) |
' |_| |_| |_|\__,_|_|_| |_(_)_/ |_.__/ 
'                                                                            
'
'This file contains the main logic to check for, verify, and process the Snapchat JSON data.
'
'main.vb contains the functional application code as well as the
'design. Do not open init.vb file in the designer or risk breaking
'main.vb! Please edit main.vb in the designer to make changes to
'the UI elements. init.vb file only contains code to handle the window itself.
'It is merely an extension of this file.
'
'-LazySmurf

Imports System
Imports System.Text
Imports System.Globalization
Imports System.ComponentModel
Imports System.Threading
Imports System.Net 'Used by Newtonsoft.Json
Imports System.Collections
'Imports System.Text.Json
Imports System.IO 'We use System/System.IO to read the file from disk and get our CWD.
Imports System.Web.Script.Serialization 'Uses the in-built JSON serialization class included with the .NET Framework.
Imports System.Runtime.Serialization 'I had planned to use the Runtime Serialization to process JSON data. I left the include here so you could try it if you'd like.
Imports Newtonsoft.Json 'After reading the file via System.IO, you can use Newtonsoft.Json to parse the data.
Imports Newtonsoft.Json.Linq
'You can use System.Runtime.Serialization out of the box, I've included the System.Web.Extensions for System.Web.Script.Serialization, and I've also included the NuGet Package for Newtonsoft.Json.
'This means that you should be able to use any method out of the box in this project. To start, see the CheckFile function and go from there, as it's the first logic to interact with the JSON data itself.
'The CheckFileButton only checks that the file exists, and then waits for CheckFile to finish before proceeding.
'If you're not going to use Newtonsoft.Json, I suggest you comment it's Imports statements out. It might also be wise to do the same for System.Web. System.Runtime.Serialization doesn't matter, but it's good practice to disable if not in use.
Public Class memoireForm
    Dim DebuggingMode As Boolean = False 'Set Debugging Mode. Set to False normally. 'Set to True to see the DebugLabel. Assign Your Own Debug Text in SecChecker timer. There's an example in there.
    'Debugging mode can be enabled externally by passing Memoire.exe the arguemnt -debug

    Dim jsonData As String
    Dim imgCount As Integer = 0
    Dim vidCount As Integer = 0
    Dim unknwnCount As Integer = 0
    Dim itmCount As Integer = 0

    Dim Lrg As Int16 = 498 'Define Lrg and Sml form size values.
    Dim Sml As Int16 = 250 'These will be the height values we toggle between.
    Dim GrowDirection As String = "grow" 'Set the direction of the form's height change. We want to default to "grow" as we start off small, but we could programmatically change this to "shrink" to go the other way.
    Dim CWD = Directory.GetCurrentDirectory()
    Private Sub CheckFileButton_Click(sender As Object, e As EventArgs) Handles CheckFileButton.Click
        Dim JSONFile As String = CWD & "\memories_history.json" 'Define what the location of the file we're checking for is, in this case, inside the current directory of the .exe file, we're looking for a particular .json file.
        If My.Computer.FileSystem.FileExists(JSONFile) Then 'If the file we want exists,
            LogText("File found!")
            CheckFileButton.Enabled = False 'Disable the button, as we don't need to check for the file anymore. Yes, they could remove the file from the folder at this point, but we're going to assume to some degree that the user actually wants this to work.
            CheckFileButton.Text = "File Found! :)" 'Add some friendly text to the button to let the user know we found their file.
            FileCheckStatus.ForeColor = ColorTranslator.FromHtml("#ffbd44") 'Set the status label colour to a yellow,
            FileCheckStatus.Text = "Verifying File..." 'Indicate via status text that we're verifying the file. It should be quick enough that we don't see this, but it's here for larger files that may take some time for the next function to run.
            If CheckFile(JSONFile) = True Then 'Now, we run the CheckFile() function and if it returns true,
                FileCheckStatus.ForeColor = Color.Lime 'Set status label to lime green 
                FileCheckStatus.Text = "File Validated! :)" 'Let the user know we've validated their file successfully,
                SizeChanger.Start() 'Start the SizeChanger to reveal the rest of the application.
                BeginDLButton.Enabled = True
            Else 'Otherwise, if CheckFile does not return true,
                LogText("File not valid!")
                FileCheckStatus.ForeColor = Color.Red 'Set the status label to red,
                FileCheckStatus.Text = "Invalid File! :(" 'Let them know their file isn't valid
                CheckFileButton.Enabled = True 'Re-enable the button.
                CheckFileButton.Text = "Try Again" 'And set the button's text to Try Again, so we can check again.
            End If
        Else 'If the file can't be found at all,
            LogText("File not found!")
            FileCheckStatus.ForeColor = ColorTranslator.FromHtml("#FF605C") 'Set the status label text to red,
            FileCheckStatus.Text = "No File Found! :(" 'Let the user know we couldn't find their file.
        End If
    End Sub


    Function CheckFile(ByVal FileLoc As String)
        'Check the file has the correct JSON structure that we're looking for.
        'Since this could just be any random JSON file that's been renamed to what the app wants,
        'we really should check that it contains the data we expect in the way we expect it.
        jsonData = File.ReadAllText(FileLoc)
        Dim json1stObjData As String = Nothing
        ConsoleLog.MaxLength = Int32.MaxValue
        jsonData = jsonData.Replace("Date", "jsDate") 'Date is a .NET Supervariable/Function so we cannot use that as a name.
        jsonData = jsonData.Replace("Media Type", "jsMediaType") 'The other names contain spaces, which we also can't have.
        jsonData = jsonData.Replace("Download Link", "jsDlLink") 'So, we replace each element of the JSON data's name
        jsonData = jsonData.Replace("Saved Media", "jsSavedMedia") 'and use our own custom names once we've read the file.
        LogText("File Length: " & jsonData.Length.ToString("N").Substring(0, jsonData.Length.ToString("N").Length - 3))
        LogText("Int32 Max: " & Int32.MaxValue.ToString("N").Substring(0, Int32.MaxValue.ToString("N").Length - 3))

        If jsonData.Length > Int32.MaxValue Then 'If the JSON file is larger than the int32 max value, throw an error.
            MessageBox.Show("JSON file is longer than max int32 value!", "Overflow Error")
            LogText("Overflow: JSON File contains more characters than int32 value can store.")
            LogText("You can split the file into smaller JSON files that fit within the limit, or you can add some logic where this error throws to do that automatically. Additionally, you could use a File Stream rather than a File Read to circumvent this limit.")
            Return False
        Else 'If file is within int32 max value, we're good.
            LogText("File length is within int32 limits.")
        End If

        Try 'Attempt to validate file
            json1stObjData = CheckFirstObj(jsonData) 'Set the jsonData to the output of the CheckFirstObj function, which checks for the first object we should expect from the Snapchat file.
            LogText("Attempting to grab first object:   " & vbNewLine & json1stObjData & vbNewLine & vbNewLine)
            Dim jss As Object = New JavaScriptSerializer()
            jss.MaxJsonLength = Int32.MaxValue
            Dim j = jss.Deserialize(Of Object)(json1stObjData)

            Dim i = 0
            For Each entry As KeyValuePair(Of String, Object) In j
                Dim thisDate As DateTime
                If i = 0 Then
                    If Not entry.Key.ToString = "jsDate" Then
                        LogText("First key invalid!")
                        LogText("Key = " & entry.Key)
                        LogText("Expected: jsDate (Date in JSON file)")
                        Return False
                    End If
                    'Date format: 2022-04-25 12:57:24 UTC
                    thisDate = DateTime.Parse(entry.Value.ToString.Replace("UTC", "+0")) '.NET DateTime objects don't like 3-letter timezone codes, but don't mind hourly offsets. Since Snapchat uses UTC, we can simply set this offset to +0.
                    LogText("Date (Localized): " & thisDate.ToString)
                ElseIf i = 1 Then
                    If Not entry.Key.ToString = "jsMediaType" Then
                        LogText("Second key invalid!")
                        LogText("Key = " & entry.Key)
                        LogText("Expected: jsMediaType (Media Type in JSON file)")
                        Return False
                    End If
                    If Not entry.Value = "Image" And Not entry.Value = "Video" Then
                        LogText("Unexpected value for jsMediaType!")
                        LogText("Value = " & entry.Value)
                        LogText("Expected 'Image' or 'Video' as media type")
                        Return False
                    End If
                ElseIf i = 2 Then
                    If Not entry.Key.ToString = "jsDlLink" Then
                        LogText("Third key invalid!")
                        LogText("Key = " & entry.Key)
                        LogText("Expected: jsDlLink (Download Link in JSON file)")
                        Return False
                    End If
                    If Not entry.Value.ToString.Contains("https://app.snapchat.com/") Then
                        LogText("Unexpected value for jsDlLink!")
                        LogText("Value = " & entry.Value)
                        LogText("Expected to contain link to Snapchat App's CDN")
                        Return False
                    End If
                End If
                LogText("Key " & i.ToString & " = " & entry.Key)
                LogText(" ╚═ Value " & i.ToString & " = " & entry.Value & vbNewLine)
                i += 1
            Next
            LogText("File validation complete! Structure in expected format.")
        Catch ex As Exception
            ' in case the structure of the object is not what we expected.
            LogText("Object Error: " & vbNewLine & ex.ToString)
            Return False
        End Try


        'Enumerate JSON objects by type
        Dim jMatrix() = Nothing
        Try
            LogText("Begin counting objects...")
            FileCheckStatus.Text = "Counting Memories..."

            Dim serObj As JObject = JObject.Parse(jsonData)
            Dim list As JArray = CType(serObj.SelectToken("jsSavedMedia"), JArray)

            For Each item As JObject In list
                itmCount += 1
                Dim thisDate As String = CType(item("jsDate"), String)
                Dim thisMediaType As String = CType(item("jsMediaType"), String)
                Dim thisDlLink As String = CType(item("jsDlLink"), String)
                If thisMediaType = "Image" Then
                    imgCount += 1
                ElseIf thisMediaType = "Video" Then
                    vidCount += 1
                Else
                    unknwnCount += 1
                End If
            Next
            LogText("Images: " & imgCount.ToString & vbNewLine & "Videos: " & vidCount.ToString & vbNewLine & "Unknown: " & unknwnCount & vbNewLine & "Total: " & imgCount + vidCount + unknwnCount)
            totalMemoriesImages.Text = "Images: " & imgCount.ToString("N0")
            totalMemoriesVideos.Text = "Videos: " & vidCount.ToString("N0")
            If unknwnCount > 0 Then
                totalMemories.Text = "Total Memories: " & (imgCount + vidCount + unknwnCount).ToString("N0") & " (" & unknwnCount.ToString("N0") & " Unknown)"
            Else
                totalMemories.Text = "Total Memories: " & (imgCount + vidCount).ToString("N0")
            End If

        Catch ex As Exception
            LogText("Enumeration Error: " & vbNewLine & ex.ToString)
            Return False
        End Try
        Return True
    End Function

    Function CheckFirstObj(ByVal json As String)
        Dim frstOpnBrkt As Int16 = json.IndexOf("{", 0) 'Get the index of the first occurance of an opening bracket, which is likely 0, starting from the beginning of the file
        Dim ScndOpnBrkt As Int16 = json.IndexOf("{", frstOpnBrkt + 1) 'Get the first occurance of an opening bracket, starting from the index of the first one, plus one.
        'This will allow us to get the second index of an opening bracket. The reason this is useful is
        'because the JSON file contains several objects inside of one large object. So, by doing this,
        'we can set all those objects free and read each one individually without accessing their larger object.

        LogText("First Open Bracket Index: " & frstOpnBrkt) 'Log the index of the first open bracket
        LogText("Second Open Bracket Index: " & ScndOpnBrkt) 'Log the index of the second open bracket
        json = json.Substring(ScndOpnBrkt, json.Length - ScndOpnBrkt) 'Remove the larger object from the beginning of the file.
        Dim FrstClsBrkt As Int16 = json.IndexOf("},", 0) 'Get the first occurance of a closing bracket, starting from the NEW beginning of the JSON data.
        LogText("First Close Bracket Index: " & FrstClsBrkt) 'Log the index of the first close bracket
        json = json.Substring(0, FrstClsBrkt + 1) 'Remove everything after the first close bracket
        Return json 'Return the first object of the JSON data.
        'If we return garbage, CheckFile will fail and the file will be considered invalid.
        'Otherwise, we will return valid data from JSON.
    End Function

    Private context As SynchronizationContext = SynchronizationContext.Current
    Private Sub BeginDLButton_Click(sender As Object, e As EventArgs) Handles BeginDLButton.Click
        BeginDLButton.Enabled = False
        DLProgBar.Visible = True
        BeginDLButton.Text = "Downloading..."
        DownloadStatus.Text = "Downloading ..."
        BGDownloader.RunWorkerAsync()
        DLProgBar.Minimum = 0
        DLProgBar.Maximum = itmCount
        CloseBox.Visible = False
        MinBox.Visible = False
    End Sub

    Private Sub BGDownloader_DoWork(sender As Object, e As DoWorkEventArgs) Handles BGDownloader.DoWork
        Dim serObj As JObject = JObject.Parse(jsonData)
        Dim list As JArray = CType(serObj.SelectToken("jsSavedMedia"), JArray)
        Dim DlItmCount = 0
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US")
        For Each item As JObject In list
            DlItmCount += 1
            Dim PercentComplete = ((DlItmCount / itmCount) * 100)
            BGDownloader.ReportProgress(PercentComplete, DlItmCount)

            Dim thisDate As String = CType(item("jsDate"), String)
            Dim thisMediaType As String = CType(item("jsMediaType"), String)
            Dim thisDlLink As String = CType(item("jsDlLink"), String)

            Dim remoteUri As Uri = New Uri(thisDlLink)

            setLabelTxt("Downloading " & DlItmCount.ToString("N0") & " of " & itmCount.ToString("N0") & " (" & PercentComplete.ToString("N0") & "%)", DownloadStatus)

            'Check if Snap Memories folder exists, if not, create it
            If Not System.IO.Directory.Exists(CWD & "\Snap Memories") Then
                System.IO.Directory.CreateDirectory(CWD & "\Snap Memories")
            End If
            Dim ParsedDate As DateTime = DateTime.Parse(thisDate.Replace("UTC", "+0"))
            'Set folder locations:
            Dim YearDir As String = ParsedDate.Year
            Dim MonthDir As String = ParsedDate.ToString("MM - MMMM", CultureInfo.CreateSpecificCulture("en-US"))
            Dim DayDir As String = ParsedDate.ToString("dd-MM-yyyy - dddd", CultureInfo.CreateSpecificCulture("en-US"))

            'Check if a folder exists with this item's year, if not, create it
            If Not System.IO.Directory.Exists(CWD & "\Snap Memories\" & ParsedDate.Year) Then
                System.IO.Directory.CreateDirectory(CWD & "\Snap Memories\" & ParsedDate.Year)
            End If
            'Check if a folder exists with this item's month, if not, create it
            If Not System.IO.Directory.Exists(CWD & "\Snap Memories\" & ParsedDate.Year & "\" & MonthDir) Then
                System.IO.Directory.CreateDirectory(CWD & "\Snap Memories\" & ParsedDate.Year & "\" & MonthDir)
            End If
            'Check if a folder exists with this item's day, if not, create it
            If Not System.IO.Directory.Exists(CWD & "\Snap Memories\" & ParsedDate.Year & "\" & MonthDir & "\" & DayDir) Then
                System.IO.Directory.CreateDirectory(CWD & "\Snap Memories\" & ParsedDate.Year & "\" & MonthDir & "\" & DayDir)
            End If
            'Check this item's media type
            Dim fileExt As String = ".unknown" 'By default, we'll make it unknown, just in case we encounter an error.
            'If for some reason the media type isn't what we expect, we will still download the file, just with the unknown file ext.
            If thisMediaType = "Video" Then
                fileExt = ".mp4"
            ElseIf thisMediaType = "Image" Then
                fileExt = ".jpg"
            Else
                fileExt = ".unknown"
            End If
            'Set the download directory within the CWD. If your OS requires you to have permissions in this folder,
            'you may need to run the application as administrator. Otherwise, it should be fine without that.
            Dim DlDir As String = CWD & "\Snap Memories\" & ParsedDate.Year & "\" & MonthDir & "\" & DayDir & "\"
            Dim fileName As String = ParsedDate.Hour & "-" & ParsedDate.Minute & "-" & ParsedDate.Second & fileExt

            'Start Download process

            Try
                LogText("Sending POST request to: " & vbNewLine & thisDlLink)
                Dim s As HttpWebRequest
                Dim enc As UTF8Encoding = New System.Text.UTF8Encoding()
                s = HttpWebRequest.Create(thisDlLink)
                s.Method = "POST"
                Dim postdata As String = thisDlLink
                Dim postdatabytes As Byte() = enc.GetBytes(postdata)

                Using stream = s.GetRequestStream()
                    stream.Write(postdatabytes, 0, postdatabytes.Length)
                End Using
                Dim PostResult = s.GetResponse()
                Dim reader As StreamReader = New System.IO.StreamReader(PostResult.GetResponseStream(), enc)
                Dim responseText As String = reader.ReadToEnd()
                LogText("POST Response: " & vbNewLine & responseText & vbNewLine)
                Dim GetURL As Uri = New Uri(responseText)

                Using client As New WebClient()
                    client.DownloadFileAsync(GetURL, DlDir & fileName)
                End Using

            Catch ex As Exception
                setTextBoxTxt("Download Error on Item " & DlItmCount & ": " & ex.ToString & vbNewLine, ConsoleLog)
            End Try
        Next
    End Sub

    Private Sub setLabelTxt(ByVal text As String, ByVal lbl As Label)
        If lbl.InvokeRequired Then
            lbl.Invoke(New setLabelTxtInvoker(AddressOf setLabelTxt), text, lbl)
        Else
            lbl.Text = text
        End If
    End Sub
    Private Delegate Sub setLabelTxtInvoker(ByVal text As String, ByVal lbl As Label)

    Private Sub setTextBoxTxt(ByVal text As String, ByVal txtbox As TextBox)
        If txtbox.InvokeRequired Then
            txtbox.Invoke(New setTextBoxTxtInvoker(AddressOf setTextBoxTxt), txtbox.Text & vbNewLine & text, txtbox)
        Else
            txtbox.Text = text
        End If
    End Sub
    Private Delegate Sub setTextBoxTxtInvoker(ByVal text As String, ByVal txtbox As TextBox)

    Private Sub BGDownloader_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BGDownloader.ProgressChanged
        Dim PercentCompleted As Integer = e.ProgressPercentage
        Dim CurrentItem As Integer = e.UserState
        Dim FormattedCurrItm = CurrentItem.ToString("N0")
        Dim FormattedTotlItm = itmCount.ToString("N0")
        DLProgBar.Value = CurrentItem
        LogText("Downloading " & FormattedCurrItm & "/" & FormattedTotlItm & " (" & PercentCompleted & "%)")
    End Sub

    Private Sub BGDownloader_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BGDownloader.RunWorkerCompleted
        BeginDLButton.Text = "Done!"
        DownloadStatus.Text = "Download Complete!"
        LogText("Background Worker completed running.")
        CloseBox.Visible = True
        MinBox.Visible = True
    End Sub
End Class

Public Class PostWrapper
    Public posts() As Post
End Class

Public Class Post
    Public Property jsDate As String
    Public Property jsMediaType As String
    Public Property jsDlLink As String
End Class