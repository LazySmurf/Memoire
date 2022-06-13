'This file is not the main logic of the application!
'
'This file only contains code to set up the window environment.
'This code makes certain window functions work, such as handling
'the Minimize/Exit buttons, dragging the borderless form, and
'curving the border of the form. It also handles the developer
'link at the bottom, and the button to open the CWD.
'
'If you want to look into the code that actually handles the
'Snapchat JSON data, please see main.vb
'
'main.vb contains the functional application code as well as the
'design. Do not open this file in the designer or risk breaking
'main.vb! Please edit main.vb in the designer to make changes to
'the UI elements.
'
'I made this a fairly pretty program to both explore some design
'concepts myself, as well as to show others how it can be done
'easily to improve the look of applications. You can use this
'code, modify it, and improve it in your own applications.
'The main focus of this program is to handle Snapchat JSON data,
'but that doesn't mean we can't learn other concepts along the way!
'
'I've done my best to comment as much as I could to explain myself
'throughout the code. Please feel free to add additional info
'or ask about stuff!
'
'-LazySmurf

Imports System.ComponentModel

Partial Class memoireForm 'Extends main form's logic
    Dim X1 As Integer 'These 3 variables are defined here for use with the following functions
    Dim Y1 As Integer 'to allow dragging of the borderless form!
    Dim WR As Rectangle
    Dim FirstLaunch As Boolean = True
    Dim VerMode As Boolean = False

    'Handle the elements that you can use to click and drag the window, and also handles snapping to the edges of the screen.
    Function MouseDownEvents(ByVal e As MouseEventArgs) As MouseEventArgs 'When the mouse is down...
        X1 = e.X 'Set X1 to mouse event's X coord
        Y1 = e.Y 'Set Y1 to mouse event's Y coord
        WR = Screen.GetWorkingArea(Me) 'Set WR as the working area of the current screen that the window is on.
        Return e 'Return e (discarded)
    End Function

    Function MouseMoveEvents(ByVal e As MouseEventArgs) As MouseEventArgs 'When the mouse moves...
        If Not e.Button = Windows.Forms.MouseButtons.Left Then Return e 'If the mouse button isn't the left mouse button, return e, exit function.
        Dim NewX As Integer = Left + (e.X - X1) 'NewX is window's left plus mouse's X subtract X1 (lock X coords together)
        Dim NewY As Integer = Top + (e.Y - Y1) 'Same but for Y coord (lock Y coords together)
        Dim W As Integer = Width 'W is window's width
        Dim H As Integer = Height 'H is window's height
        If NewY >= WR.Top - 15 And NewY <= WR.Top + 15 Then 'If we approach an edge, do some logic to see when we're getting close, then set our position to that edge.
            Top = WR.Top
        ElseIf NewY + H > WR.Bottom - 15 And NewY + H < WR.Bottom + 15 Then
            Top = WR.Bottom - H
        Else
            Top = NewY
        End If
        If NewX >= WR.Left - 15 And NewX <= WR.Left + 15 Then
            Left = WR.Left
        ElseIf NewX + W > WR.Right - 15 And NewX + W < WR.Right + 15 Then
            Left = WR.Right - W
        Else
            Left = NewX
        End If
        Return e 'Return e (discarded again)
    End Function

    'Give the borders a curve by a set amount, passed when calling the function
    Function CurveBorder(ByVal curve As Integer) As Integer 'We set the variable 'curve' to define how much of a curve we want. 10-30 is usually a decent range.
        Dim p As New Drawing2D.GraphicsPath 'Create a 2D path
        p.StartFigure() 'Start defining the figure. Rectangle Constructor uses (int32) format Rectangle(int x, int y, int width, int height)
        p.AddArc(New Rectangle(0, 0, curve, curve), 180, 90) 'Add Arc, then line, for each corner. 
        p.AddLine(curve, 0, Width - curve, 0)
        p.AddArc(New Rectangle(Width - curve, 0, curve, curve), -90, 90)
        p.AddLine(Width, curve, Width, Height - curve)
        p.AddArc(New Rectangle(Width - curve, Height - curve, curve, curve), 0, 90)
        p.AddLine(Width - curve, Height, curve, Height)
        p.AddArc(New Rectangle(0, Height - curve, curve, curve), 90, 90)
        p.CloseFigure() 'Close figure
        Region = New Region(p) 'Set new region as our 2D path
        Return True 'Return true (discarded, but could be used for error handling of some kind. not really necessary.)
    End Function
    Private Sub memoireForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If VerMode = False Then
            If Not BGDownloader.IsBusy Then
                If Not MessageBox.Show("Are you sure you want to close Memoire?", "Memoire - Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, 0) = DialogResult.Yes Then
                    e.Cancel = True
                End If
            End If
            If BGDownloader.IsBusy Then
                If Not MessageBox.Show("Memoire is still running!" & vbNewLine & "Closing Memoire while it is downloading may lead to corruption of your image/video file(s). It's recommended that you leave Memoire open until it is finished downloading." & vbNewLine & vbNewLine & "Are you absolutely sure you want to close Memoire?", "Memoire - Still Running!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0) = DialogResult.Yes Then
                    e.Cancel = True
                End If
            End If
        End If
    End Sub
    Private Sub memoireForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load 'ON PROGRAM LOAD!
        For Each arg As String In Environment.GetCommandLineArgs()
            If arg = "-ver" Then
                VerMode = True
                MessageBox.Show(Application.ProductName & vbNewLine & vbNewLine & My.Application.Info.Description & vbNewLine & vbNewLine & "Assembly Version" & vbNewLine & " ⮚" & My.Application.Info.Version.ToString & vbNewLine & "Build Version" & vbNewLine & " ⮚" & Application.ProductVersion.ToString & vbNewLine & vbNewLine & "Created By" & vbNewLine & Application.CompanyName & vbNewLine & vbNewLine & My.Application.Info.Copyright & "-" & Date.Today.Year & vbNewLine & My.Application.Info.Trademark, "Memoire - Version Info", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, 0)
                Close()
            End If
            If arg = "-debug" Then 'If debugging argument is passed at launch,
                DebuggingMode = True 'Enable debugging mode.
            End If
            If arg = "-smurf" Then
                LogText("Thank you for using my software! -LazySmurf")
            End If
        Next arg
        Holiday()
        'Handle Debugging Mode
        'main.vb contains the variable to enable or disable debugging mode.
        'When you pass the executable with argument "-debug", debug mode will be enabled without recompiling the program.
        If DebuggingMode = True Then
            DebugLabel.Visible = True
            DebugLabel.Text = "Debugging Mode Enabled"
            SecChecker.Enabled = True
            ConsoleLog.Visible = True
            TopMostCheck.Visible = True
            Width = 840
            LogText("Memoire version " & Application.ProductVersion.ToString & " build " & My.Application.Info.Version.ToString & " loaded!")
        ElseIf DebuggingMode = False Then
            DebugLabel.Visible = False
            DebugLabel.Text = Nothing
            SecChecker.Enabled = False
            ConsoleLog.Visible = False
            TopMostCheck.Visible = False
            Width = 380
        Else
            DebuggingModeError()
        End If

        CurveBorder(20) 'We will call our curve function at launch to set our curved borders. I like 20 as a good curve setting.
    End Sub

    Function DetermineSize(ByVal First As Boolean)
        If First = True Then 'On Launch, we pass the Global variable First to this function. If it's true, we resize and set it false.
            Size = New Size(Width, Sml) 'We also set the size to the initial size before setting it false.
            FirstLaunch = False 'This way, hopefully, it only sets the form size on FIRST launch and not if we refresh/reload the form.
        End If

        'Re-align the form to the center of the screen, assuming it's the large size.
        'This is done so that when the window is expanded, it will be center screen,
        'instead of when it starts up small, so that the expanded window doesn't get
        'lost under the task bar or anything like that. This ensures our final window
        'size will be center screen. Also supports both regular and debug modes.
        Top = (My.Computer.Screen.WorkingArea.Height \ 2) - (Lrg \ 2)
        Left = (My.Computer.Screen.WorkingArea.Width \ 2) - (Width \ 2)
        Return FirstLaunch
    End Function

    Private Sub memoireForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        WindowState = FormWindowState.Normal 'Ensure the window is in a normal state, not minimized or maximized.
        If Not DetermineSize(FirstLaunch) = False Then
            MessageBox.Show("Error displaying main window. Size mismatch.", "Window Size Error")
        End If 'As this application has two sizes, we will set the first size at launch and define new one later in main.vb
    End Sub

    Function ToggleSize() 'ToggleSize function to go between the two sizes, pass it Lrg or Sml (UNUSED, SEE SizeChanger TIMER INSTEAD!)
        Dim Lrg As Int16 = 498 'Define Lrg and Sml size values.
        Dim Sml As Int16 = 244 'These will be the values we toggle between.
        Dim CurrHeight As Int16 = Size.Height 'We'll also grab the current width of the window before we've operated on it.

        If CurrHeight = Lrg Then
            Do Until Size.Height = Sml
                Me.Bounds = New Rectangle(Left, Top, Width, Height - 1)
            Loop
            Refresh()
            Return True
        ElseIf CurrHeight = Sml Then
            Do Until Size.Height = Lrg
                Me.Bounds = New Rectangle(Left, Top, Width, Height + 1)
            Loop
            Refresh()
            Return True
        Else
            Return False
        End If

        'You could also change this around to modify the width instead, or both.
        'I just want to change the height to show more info once we've verified our file.
    End Function

    Private Sub SizeChanger_Tick(sender As Object, e As EventArgs) Handles SizeChanger.Tick
        'This timer is used to animate the size change of the form. I had tried doing this entirely with a function,
        'but it only worked in one direction for some reason, freezing the window in the other. This method has seemed
        'to work fairly reliably for me over the years, so we're using it here for that sweet, sweet UX.
        '
        'I've also included a modified function that you can try to get working if you're interested, I can't get it to work the way I'd like.
        'It's based on the principle I used in my Ghost Anti-Process repo, also on my GitHub.
        'This timer works similarly but uses the timer's tick to increment the size rather than a loop.
        '
        'To avoid a lot of ugly code enabling and disabling form elements depending on the current state of the application,
        'I've instead gone with the method of simply hiding the rest of the application until we need to see it. So, once the
        'JSON file has been found and verified as having the correct data structure, we will grow the form to reveal the rest
        'of the controls, and display some information about the contents of the file.
        'We do also hide the group boxes that contain the other controls, though, just in case. We'll reveal them when the form grows.
        'Form size when full = 380, 498
        'Form size when small = 380, 244

        If GrowDirection = "grow" Then
            FileStatsGrpBox.Visible = True
            DownloadGrpBox.Visible = True
            If Size.Height < Lrg Then
                Bounds = New Rectangle(Left, Top, Width, Height + 4)
                'Size = New Size(380, Lrg)
            ElseIf Size.Height = Lrg Then
                'Refresh()
                SizeChanger.Stop()
                GrowDirection = "shrink" 'Set the direction to opposite so if we run timer again later it will toggle.
            End If
        ElseIf GrowDirection = "shrink" Then
            If Size.Height > Sml Then
                Bounds = New Rectangle(Left, Top, Width, Height - 4)
                'Size = New Size(380, Sml)
            ElseIf Size.Height = Sml Then
                FileStatsGrpBox.Visible = False
                DownloadGrpBox.Visible = False
                'Refresh()
                SizeChanger.Stop()
                GrowDirection = "grow" 'Set the direction to opposite so if we run timer again later it will toggle.
            End If
        End If
    End Sub

    Private Sub MinimizeBox_MouseEnter(sender As Object, e As EventArgs) Handles MinBox.MouseEnter 'When mouse enters Minimize Box...
        MinBox.BackColor = ColorTranslator.FromHtml("#ffce75") 'Set the back colour to a lighter colour
    End Sub

    Private Sub MinimizeBox_MouseLeave(sender As Object, e As EventArgs) Handles MinBox.MouseLeave 'When mouse leaves Minimize Box...
        MinBox.BackColor = ColorTranslator.FromHtml("#ffbd44") 'Set the back colour back to the default
    End Sub

    Private Sub MinimizeBox_MouseClick(sender As Object, e As MouseEventArgs) Handles MinBox.MouseClick 'When mouse clicks Minimize Box...
        WindowState = FormWindowState.Minimized 'Set Window State to minimized
    End Sub

    Private Sub CloseBox_MouseEnter(sender As Object, e As EventArgs) Handles CloseBox.MouseEnter 'When mouse enters Close Box...
        CloseBox.BackColor = ColorTranslator.FromHtml("#ff7975") 'Set the back colour to lighter colour
    End Sub

    Private Sub CloseBox_MouseLeave(sender As Object, e As EventArgs) Handles CloseBox.MouseLeave 'When mouse leaves Close Box...
        CloseBox.BackColor = ColorTranslator.FromHtml("#FF605C") 'Set the back colour back to the default
    End Sub

    Private Sub CloseBox_MouseClick(sender As Object, e As MouseEventArgs) Handles CloseBox.MouseClick 'When mouse clicks Close Box...
        Close() 'Close the main form. As per our project settings, this will close the entire application and all of it's children.
    End Sub

    Private Sub LinkSnapAccount_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkSnapAccount.LinkClicked
        'When you click the link to download your data, open the Snapchat website for you to log into and do that in your default browser.
        Process.Start("https://accounts.snapchat.com")
    End Sub

    Private Sub LSDLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LSDLink.LinkClicked
        'When you click my link, open my website in your default browser.
        Process.Start("https://lazysmurf.net")
    End Sub

    Private Sub OpenFolderCWD_Click(sender As Object, e As EventArgs) Handles OpenFolderCWD.Click
        'When you click the button to open the folder, open the folder.
        Process.Start(CWD)
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles TopMostCheck.CheckedChanged
        If TopMostCheck.Checked = True Then
            MyBase.TopMost = True
        ElseIf TopMostCheck.Checked = False Then
            MyBase.TopMost = False
        Else
            DebuggingModeError()
        End If
    End Sub

    '=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~'
    '                                                       Debugging                                                        '
    '=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~'
    Function LogText(ByVal logentry As String) 'Console is shown when debugging mode is enabled.
        'Pass text to this function to log it to the console and go to the next line automatically.
        If DebuggingMode = True Then
            ConsoleLog.AppendText(logentry & vbNewLine) 'Append text to the console and go to the next line.
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub SecChecker_Tick(sender As Object, e As EventArgs) Handles SecChecker.Tick
        'SecChecker Timer is used for debugging. It's disabled when debugging is disabled.
        'It allows you to update the DebugLabel.Text with a value to see how it changes during runtime.

        'Example: Shows the current application height in the debug label every tick.
        'DebugLabel.Text = "Size.Height: " & Size.Height.ToString
    End Sub

    '=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~'
    '                                                 Mouse Event Handling                                                   '
    '=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~'
    '
    'Adding MouseDownEvents(e) to a control's MouseDown handler, and MouseMoveEvents(e) to the same control's MouseMove handler
    'will allow that control to drag the entire form around. Using this, we're able to assign these events to the form itself
    'as well as a few other elements like static labels, a picture box, and group boxes. This way, the form can be dragged
    'around the screen from just about anywhere on the form. Since the form is borderless, this gives the program a sort of
    'natural and intuitive feel to the user. It makes sense that you can drag it from anywhere since it doesn't follow the
    'traditional window schema. It also vastly improves the look and feel of the application, I think due to it's small size.
    '
    'You can add an element's MouseDown and MouseMove events to this list, adding the proper event handlers as well, and see
    'what it does. For the record, while you can do this with Buttons and LinkLabels, I wouldn't recommend it since their click
    'event is usually already handled and it can cause issues with the MouseDown event.
    Private Sub memoireForm_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        MouseDownEvents(e)
    End Sub

    Private Sub memoireForm_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        MouseMoveEvents(e)
    End Sub
    Private Sub Label3_MouseDown(sender As Object, e As MouseEventArgs) Handles AuthorTextLabel.MouseDown
        MouseDownEvents(e)
    End Sub

    Private Sub Label3_MouseMove(sender As Object, e As MouseEventArgs) Handles AuthorTextLabel.MouseMove
        MouseMoveEvents(e)
    End Sub

    Private Sub Label2_MouseDown(sender As Object, e As MouseEventArgs) Handles SubtitleTextLabel.MouseDown
        MouseDownEvents(e)
    End Sub

    Private Sub Label2_MouseMove(sender As Object, e As MouseEventArgs) Handles SubtitleTextLabel.MouseMove
        MouseMoveEvents(e)
    End Sub

    Private Sub Label1_MouseDown(sender As Object, e As MouseEventArgs) Handles TitleTextLabel.MouseDown
        MouseDownEvents(e)
    End Sub

    Private Sub Label1_MouseMove(sender As Object, e As MouseEventArgs) Handles TitleTextLabel.MouseMove
        MouseMoveEvents(e)
    End Sub

    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles LogoBox.MouseDown
        MouseDownEvents(e)
    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles LogoBox.MouseMove
        MouseMoveEvents(e)
    End Sub

    Private Sub ChkFileGrpBox_MouseDown(sender As Object, e As MouseEventArgs) Handles ChkFileGrpBox.MouseDown
        MouseDownEvents(e)
    End Sub

    Private Sub ChkFileGrpBox_MouseMove(sender As Object, e As MouseEventArgs) Handles ChkFileGrpBox.MouseMove
        MouseMoveEvents(e)
    End Sub

    Private Sub Label4_MouseDown(sender As Object, e As MouseEventArgs) Handles ChkFileDescLabel.MouseDown
        MouseDownEvents(e)
    End Sub

    Private Sub Label4_MouseMove(sender As Object, e As MouseEventArgs) Handles ChkFileDescLabel.MouseMove
        MouseMoveEvents(e)
    End Sub

    Private Sub FileCheckStatus_MouseDown(sender As Object, e As MouseEventArgs) Handles FileCheckStatus.MouseDown
        MouseDownEvents(e)
    End Sub

    Private Sub FileCheckStatus_MouseMove(sender As Object, e As MouseEventArgs) Handles FileCheckStatus.MouseMove
        MouseMoveEvents(e)
    End Sub

    Private Sub totalMemoriesImages_MouseDown(sender As Object, e As MouseEventArgs) Handles totalMemoriesImages.MouseDown
        MouseDownEvents(e)
    End Sub

    Private Sub totalMemoriesImages_MouseMove(sender As Object, e As MouseEventArgs) Handles totalMemoriesImages.MouseMove
        MouseMoveEvents(e)
    End Sub

    Private Sub totalMemoriesVideos_MouseDown(sender As Object, e As MouseEventArgs) Handles totalMemoriesVideos.MouseDown
        MouseDownEvents(e)
    End Sub

    Private Sub totalMemoriesVideos_MouseMove(sender As Object, e As MouseEventArgs) Handles totalMemoriesVideos.MouseMove
        MouseMoveEvents(e)
    End Sub

    Private Sub totalMemories_MouseDown(sender As Object, e As MouseEventArgs) Handles totalMemories.MouseDown
        MouseDownEvents(e)
    End Sub

    Private Sub totalMemories_MouseMove(sender As Object, e As MouseEventArgs) Handles totalMemories.MouseMove
        MouseMoveEvents(e)
    End Sub

    Private Sub DownloadGrpBox_MouseDown(sender As Object, e As MouseEventArgs) Handles DownloadGrpBox.MouseDown
        MouseDownEvents(e)
    End Sub

    Private Sub DownloadGrpBox_MouseMove(sender As Object, e As MouseEventArgs) Handles DownloadGrpBox.MouseMove
        MouseMoveEvents(e)
    End Sub

    Private Sub Label6_MouseDown(sender As Object, e As MouseEventArgs) Handles DownloadDescLabel.MouseDown
        MouseDownEvents(e)
    End Sub

    Private Sub Label6_MouseMove(sender As Object, e As MouseEventArgs) Handles DownloadDescLabel.MouseMove
        MouseMoveEvents(e)
    End Sub

    Private Sub ProgressBar1_MouseDown(sender As Object, e As MouseEventArgs) Handles DLProgBar.MouseDown
        MouseDownEvents(e)
    End Sub

    Private Sub ProgressBar1_MouseMove(sender As Object, e As MouseEventArgs) Handles DLProgBar.MouseMove
        MouseMoveEvents(e)
    End Sub

    Private Sub DownloadStatus_MouseDown(sender As Object, e As MouseEventArgs) Handles DownloadStatus.MouseDown
        MouseDownEvents(e)
    End Sub

    Private Sub DownloadStatus_MouseMove(sender As Object, e As MouseEventArgs) Handles DownloadStatus.MouseMove
        MouseMoveEvents(e)
    End Sub

    Private Sub DebugLabel_MouseDown(sender As Object, e As MouseEventArgs) Handles DebugLabel.MouseDown
        MouseDownEvents(e)
    End Sub

    Private Sub DebugLabel_MouseMove(sender As Object, e As MouseEventArgs) Handles DebugLabel.MouseMove
        MouseMoveEvents(e)
    End Sub
End Class