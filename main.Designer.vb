<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class memoireForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(memoireForm))
        Me.CloseBox = New System.Windows.Forms.PictureBox()
        Me.MinBox = New System.Windows.Forms.PictureBox()
        Me.LogoBox = New System.Windows.Forms.PictureBox()
        Me.TitleTextLabel = New System.Windows.Forms.Label()
        Me.SubtitleTextLabel = New System.Windows.Forms.Label()
        Me.AuthorTextLabel = New System.Windows.Forms.Label()
        Me.ChkFileGrpBox = New System.Windows.Forms.GroupBox()
        Me.CheckFileButton = New System.Windows.Forms.Button()
        Me.FileCheckStatus = New System.Windows.Forms.Label()
        Me.LinkSnapAccount = New System.Windows.Forms.LinkLabel()
        Me.ChkFileDescLabel = New System.Windows.Forms.Label()
        Me.FileStatsGrpBox = New System.Windows.Forms.GroupBox()
        Me.totalMemoriesVideos = New System.Windows.Forms.Label()
        Me.totalMemoriesImages = New System.Windows.Forms.Label()
        Me.totalMemories = New System.Windows.Forms.Label()
        Me.DownloadGrpBox = New System.Windows.Forms.GroupBox()
        Me.DLProgBar = New System.Windows.Forms.ProgressBar()
        Me.BeginDLButton = New System.Windows.Forms.Button()
        Me.DownloadStatus = New System.Windows.Forms.Label()
        Me.DownloadDescLabel = New System.Windows.Forms.Label()
        Me.LSDLink = New System.Windows.Forms.LinkLabel()
        Me.OpenFolderCWD = New System.Windows.Forms.Button()
        Me.SizeChanger = New System.Windows.Forms.Timer(Me.components)
        Me.SecChecker = New System.Windows.Forms.Timer(Me.components)
        Me.DebugLabel = New System.Windows.Forms.Label()
        Me.ConsoleLog = New System.Windows.Forms.TextBox()
        Me.ConsoleOutputLabel = New System.Windows.Forms.Label()
        Me.TopMostCheck = New System.Windows.Forms.CheckBox()
        Me.BGDownloader = New System.ComponentModel.BackgroundWorker()
        CType(Me.CloseBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MinBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LogoBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ChkFileGrpBox.SuspendLayout()
        Me.FileStatsGrpBox.SuspendLayout()
        Me.DownloadGrpBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'CloseBox
        '
        Me.CloseBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.CloseBox.Image = CType(resources.GetObject("CloseBox.Image"), System.Drawing.Image)
        Me.CloseBox.Location = New System.Drawing.Point(363, 7)
        Me.CloseBox.Name = "CloseBox"
        Me.CloseBox.Size = New System.Drawing.Size(10, 10)
        Me.CloseBox.TabIndex = 0
        Me.CloseBox.TabStop = False
        '
        'MinBox
        '
        Me.MinBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.MinBox.Image = CType(resources.GetObject("MinBox.Image"), System.Drawing.Image)
        Me.MinBox.Location = New System.Drawing.Point(347, 7)
        Me.MinBox.Name = "MinBox"
        Me.MinBox.Size = New System.Drawing.Size(10, 10)
        Me.MinBox.TabIndex = 1
        Me.MinBox.TabStop = False
        '
        'LogoBox
        '
        Me.LogoBox.BackgroundImage = CType(resources.GetObject("LogoBox.BackgroundImage"), System.Drawing.Image)
        Me.LogoBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.LogoBox.InitialImage = Nothing
        Me.LogoBox.Location = New System.Drawing.Point(4, -3)
        Me.LogoBox.Name = "LogoBox"
        Me.LogoBox.Size = New System.Drawing.Size(66, 66)
        Me.LogoBox.TabIndex = 2
        Me.LogoBox.TabStop = False
        '
        'TitleTextLabel
        '
        Me.TitleTextLabel.AutoSize = True
        Me.TitleTextLabel.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitleTextLabel.Location = New System.Drawing.Point(67, 1)
        Me.TitleTextLabel.Name = "TitleTextLabel"
        Me.TitleTextLabel.Size = New System.Drawing.Size(111, 32)
        Me.TitleTextLabel.TabIndex = 0
        Me.TitleTextLabel.Text = "Memoire"
        '
        'SubtitleTextLabel
        '
        Me.SubtitleTextLabel.AutoSize = True
        Me.SubtitleTextLabel.Font = New System.Drawing.Font("Consolas", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SubtitleTextLabel.Location = New System.Drawing.Point(71, 27)
        Me.SubtitleTextLabel.Name = "SubtitleTextLabel"
        Me.SubtitleTextLabel.Size = New System.Drawing.Size(133, 13)
        Me.SubtitleTextLabel.TabIndex = 4
        Me.SubtitleTextLabel.Text = "For Snapchat Memories"
        '
        'AuthorTextLabel
        '
        Me.AuthorTextLabel.AutoSize = True
        Me.AuthorTextLabel.Font = New System.Drawing.Font("Consolas", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AuthorTextLabel.Location = New System.Drawing.Point(149, 38)
        Me.AuthorTextLabel.Name = "AuthorTextLabel"
        Me.AuthorTextLabel.Size = New System.Drawing.Size(53, 9)
        Me.AuthorTextLabel.TabIndex = 5
        Me.AuthorTextLabel.Text = "By LazySmurf"
        '
        'ChkFileGrpBox
        '
        Me.ChkFileGrpBox.Controls.Add(Me.CheckFileButton)
        Me.ChkFileGrpBox.Controls.Add(Me.FileCheckStatus)
        Me.ChkFileGrpBox.Controls.Add(Me.LinkSnapAccount)
        Me.ChkFileGrpBox.Controls.Add(Me.ChkFileDescLabel)
        Me.ChkFileGrpBox.ForeColor = System.Drawing.Color.White
        Me.ChkFileGrpBox.Location = New System.Drawing.Point(12, 64)
        Me.ChkFileGrpBox.Name = "ChkFileGrpBox"
        Me.ChkFileGrpBox.Size = New System.Drawing.Size(356, 165)
        Me.ChkFileGrpBox.TabIndex = 6
        Me.ChkFileGrpBox.TabStop = False
        Me.ChkFileGrpBox.Text = "Check File"
        '
        'CheckFileButton
        '
        Me.CheckFileButton.BackColor = System.Drawing.Color.Gray
        Me.CheckFileButton.ForeColor = System.Drawing.Color.White
        Me.CheckFileButton.Location = New System.Drawing.Point(115, 126)
        Me.CheckFileButton.Name = "CheckFileButton"
        Me.CheckFileButton.Size = New System.Drawing.Size(127, 22)
        Me.CheckFileButton.TabIndex = 1
        Me.CheckFileButton.Text = "Check For File"
        Me.CheckFileButton.UseVisualStyleBackColor = False
        '
        'FileCheckStatus
        '
        Me.FileCheckStatus.Location = New System.Drawing.Point(6, 147)
        Me.FileCheckStatus.Name = "FileCheckStatus"
        Me.FileCheckStatus.Size = New System.Drawing.Size(344, 15)
        Me.FileCheckStatus.TabIndex = 3
        Me.FileCheckStatus.Text = "Waiting to check file..."
        Me.FileCheckStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LinkSnapAccount
        '
        Me.LinkSnapAccount.ActiveLinkColor = System.Drawing.Color.Blue
        Me.LinkSnapAccount.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LinkSnapAccount.Location = New System.Drawing.Point(6, 30)
        Me.LinkSnapAccount.Name = "LinkSnapAccount"
        Me.LinkSnapAccount.Size = New System.Drawing.Size(344, 13)
        Me.LinkSnapAccount.TabIndex = 1
        Me.LinkSnapAccount.TabStop = True
        Me.LinkSnapAccount.Text = "https://accounts.snapchat.com"
        Me.LinkSnapAccount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ChkFileDescLabel
        '
        Me.ChkFileDescLabel.Location = New System.Drawing.Point(6, 17)
        Me.ChkFileDescLabel.Name = "ChkFileDescLabel"
        Me.ChkFileDescLabel.Size = New System.Drawing.Size(344, 108)
        Me.ChkFileDescLabel.TabIndex = 0
        Me.ChkFileDescLabel.Text = resources.GetString("ChkFileDescLabel.Text")
        Me.ChkFileDescLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FileStatsGrpBox
        '
        Me.FileStatsGrpBox.Controls.Add(Me.totalMemoriesVideos)
        Me.FileStatsGrpBox.Controls.Add(Me.totalMemoriesImages)
        Me.FileStatsGrpBox.Controls.Add(Me.totalMemories)
        Me.FileStatsGrpBox.ForeColor = System.Drawing.Color.White
        Me.FileStatsGrpBox.Location = New System.Drawing.Point(12, 235)
        Me.FileStatsGrpBox.Name = "FileStatsGrpBox"
        Me.FileStatsGrpBox.Size = New System.Drawing.Size(356, 65)
        Me.FileStatsGrpBox.TabIndex = 7
        Me.FileStatsGrpBox.TabStop = False
        Me.FileStatsGrpBox.Text = "File Stats"
        Me.FileStatsGrpBox.Visible = False
        '
        'totalMemoriesVideos
        '
        Me.totalMemoriesVideos.Location = New System.Drawing.Point(6, 29)
        Me.totalMemoriesVideos.Name = "totalMemoriesVideos"
        Me.totalMemoriesVideos.Size = New System.Drawing.Size(344, 13)
        Me.totalMemoriesVideos.TabIndex = 2
        Me.totalMemoriesVideos.Text = "Videos:"
        Me.totalMemoriesVideos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'totalMemoriesImages
        '
        Me.totalMemoriesImages.Location = New System.Drawing.Point(6, 14)
        Me.totalMemoriesImages.Name = "totalMemoriesImages"
        Me.totalMemoriesImages.Size = New System.Drawing.Size(344, 13)
        Me.totalMemoriesImages.TabIndex = 1
        Me.totalMemoriesImages.Text = "Images:"
        Me.totalMemoriesImages.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'totalMemories
        '
        Me.totalMemories.Location = New System.Drawing.Point(6, 44)
        Me.totalMemories.Name = "totalMemories"
        Me.totalMemories.Size = New System.Drawing.Size(344, 13)
        Me.totalMemories.TabIndex = 0
        Me.totalMemories.Text = "Total Memories:"
        Me.totalMemories.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'DownloadGrpBox
        '
        Me.DownloadGrpBox.Controls.Add(Me.DLProgBar)
        Me.DownloadGrpBox.Controls.Add(Me.BeginDLButton)
        Me.DownloadGrpBox.Controls.Add(Me.DownloadStatus)
        Me.DownloadGrpBox.Controls.Add(Me.DownloadDescLabel)
        Me.DownloadGrpBox.ForeColor = System.Drawing.Color.White
        Me.DownloadGrpBox.Location = New System.Drawing.Point(12, 306)
        Me.DownloadGrpBox.Name = "DownloadGrpBox"
        Me.DownloadGrpBox.Size = New System.Drawing.Size(356, 165)
        Me.DownloadGrpBox.TabIndex = 8
        Me.DownloadGrpBox.TabStop = False
        Me.DownloadGrpBox.Text = "Download"
        Me.DownloadGrpBox.Visible = False
        '
        'DLProgBar
        '
        Me.DLProgBar.Location = New System.Drawing.Point(9, 124)
        Me.DLProgBar.Name = "DLProgBar"
        Me.DLProgBar.Size = New System.Drawing.Size(341, 10)
        Me.DLProgBar.TabIndex = 4
        Me.DLProgBar.Visible = False
        '
        'BeginDLButton
        '
        Me.BeginDLButton.BackColor = System.Drawing.Color.Gray
        Me.BeginDLButton.Enabled = False
        Me.BeginDLButton.ForeColor = System.Drawing.Color.White
        Me.BeginDLButton.Location = New System.Drawing.Point(115, 79)
        Me.BeginDLButton.Name = "BeginDLButton"
        Me.BeginDLButton.Size = New System.Drawing.Size(127, 34)
        Me.BeginDLButton.TabIndex = 2
        Me.BeginDLButton.Text = "Begin Downloading"
        Me.BeginDLButton.UseVisualStyleBackColor = False
        '
        'DownloadStatus
        '
        Me.DownloadStatus.Location = New System.Drawing.Point(6, 135)
        Me.DownloadStatus.Name = "DownloadStatus"
        Me.DownloadStatus.Size = New System.Drawing.Size(344, 27)
        Me.DownloadStatus.TabIndex = 3
        Me.DownloadStatus.Text = "Waiting to download..."
        Me.DownloadStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DownloadDescLabel
        '
        Me.DownloadDescLabel.Location = New System.Drawing.Point(6, 17)
        Me.DownloadDescLabel.Name = "DownloadDescLabel"
        Me.DownloadDescLabel.Size = New System.Drawing.Size(344, 55)
        Me.DownloadDescLabel.TabIndex = 0
        Me.DownloadDescLabel.Text = resources.GetString("DownloadDescLabel.Text")
        Me.DownloadDescLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LSDLink
        '
        Me.LSDLink.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LSDLink.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LSDLink.AutoSize = True
        Me.LSDLink.BackColor = System.Drawing.Color.Transparent
        Me.LSDLink.LinkColor = System.Drawing.Color.Silver
        Me.LSDLink.Location = New System.Drawing.Point(126, 476)
        Me.LSDLink.Name = "LSDLink"
        Me.LSDLink.Size = New System.Drawing.Size(129, 13)
        Me.LSDLink.TabIndex = 9
        Me.LSDLink.TabStop = True
        Me.LSDLink.Text = "LazySmurf Development"
        Me.LSDLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'OpenFolderCWD
        '
        Me.OpenFolderCWD.BackColor = System.Drawing.Color.Gray
        Me.OpenFolderCWD.ForeColor = System.Drawing.Color.White
        Me.OpenFolderCWD.Location = New System.Drawing.Point(291, 47)
        Me.OpenFolderCWD.Name = "OpenFolderCWD"
        Me.OpenFolderCWD.Size = New System.Drawing.Size(79, 22)
        Me.OpenFolderCWD.TabIndex = 3
        Me.OpenFolderCWD.Text = "View Folder"
        Me.OpenFolderCWD.UseVisualStyleBackColor = False
        '
        'SizeChanger
        '
        Me.SizeChanger.Interval = 1
        '
        'SecChecker
        '
        Me.SecChecker.Enabled = True
        Me.SecChecker.Interval = 1
        '
        'DebugLabel
        '
        Me.DebugLabel.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DebugLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(22, Byte), Integer))
        Me.DebugLabel.Location = New System.Drawing.Point(475, 7)
        Me.DebugLabel.Name = "DebugLabel"
        Me.DebugLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DebugLabel.Size = New System.Drawing.Size(350, 13)
        Me.DebugLabel.TabIndex = 12
        Me.DebugLabel.Text = "Debugging Mode Enabled"
        '
        'ConsoleLog
        '
        Me.ConsoleLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.ConsoleLog.BackColor = System.Drawing.Color.Black
        Me.ConsoleLog.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ConsoleLog.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConsoleLog.ForeColor = System.Drawing.Color.Lime
        Me.ConsoleLog.Location = New System.Drawing.Point(379, 27)
        Me.ConsoleLog.Multiline = True
        Me.ConsoleLog.Name = "ConsoleLog"
        Me.ConsoleLog.ReadOnly = True
        Me.ConsoleLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ConsoleLog.Size = New System.Drawing.Size(446, 444)
        Me.ConsoleLog.TabIndex = 9999
        '
        'ConsoleOutputLabel
        '
        Me.ConsoleOutputLabel.AutoSize = True
        Me.ConsoleOutputLabel.Location = New System.Drawing.Point(379, 7)
        Me.ConsoleOutputLabel.Name = "ConsoleOutputLabel"
        Me.ConsoleOutputLabel.Size = New System.Drawing.Size(90, 13)
        Me.ConsoleOutputLabel.TabIndex = 14
        Me.ConsoleOutputLabel.Text = "Console Output"
        '
        'TopMostCheck
        '
        Me.TopMostCheck.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.TopMostCheck.AutoSize = True
        Me.TopMostCheck.Location = New System.Drawing.Point(555, 477)
        Me.TopMostCheck.Name = "TopMostCheck"
        Me.TopMostCheck.Size = New System.Drawing.Size(102, 17)
        Me.TopMostCheck.TabIndex = 15
        Me.TopMostCheck.Text = "Always On Top"
        Me.TopMostCheck.UseVisualStyleBackColor = True
        '
        'BGDownloader
        '
        Me.BGDownloader.WorkerReportsProgress = True
        '
        'memoireForm
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(837, 498)
        Me.Controls.Add(Me.TopMostCheck)
        Me.Controls.Add(Me.ConsoleOutputLabel)
        Me.Controls.Add(Me.ConsoleLog)
        Me.Controls.Add(Me.DebugLabel)
        Me.Controls.Add(Me.OpenFolderCWD)
        Me.Controls.Add(Me.LSDLink)
        Me.Controls.Add(Me.DownloadGrpBox)
        Me.Controls.Add(Me.FileStatsGrpBox)
        Me.Controls.Add(Me.ChkFileGrpBox)
        Me.Controls.Add(Me.AuthorTextLabel)
        Me.Controls.Add(Me.SubtitleTextLabel)
        Me.Controls.Add(Me.TitleTextLabel)
        Me.Controls.Add(Me.LogoBox)
        Me.Controls.Add(Me.MinBox)
        Me.Controls.Add(Me.CloseBox)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "memoireForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Memoire for Snapchat Memories"
        CType(Me.CloseBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MinBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LogoBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ChkFileGrpBox.ResumeLayout(False)
        Me.FileStatsGrpBox.ResumeLayout(False)
        Me.DownloadGrpBox.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CloseBox As PictureBox
    Friend WithEvents MinBox As PictureBox
    Friend WithEvents LogoBox As PictureBox
    Friend WithEvents TitleTextLabel As Label
    Friend WithEvents SubtitleTextLabel As Label
    Friend WithEvents AuthorTextLabel As Label
    Friend WithEvents ChkFileGrpBox As GroupBox
    Friend WithEvents LinkSnapAccount As LinkLabel
    Friend WithEvents ChkFileDescLabel As Label
    Friend WithEvents FileCheckStatus As Label
    Friend WithEvents CheckFileButton As Button
    Friend WithEvents FileStatsGrpBox As GroupBox
    Friend WithEvents totalMemoriesVideos As Label
    Friend WithEvents totalMemoriesImages As Label
    Friend WithEvents totalMemories As Label
    Friend WithEvents DownloadGrpBox As GroupBox
    Friend WithEvents DownloadStatus As Label
    Friend WithEvents BeginDLButton As Button
    Friend WithEvents DownloadDescLabel As Label
    Friend WithEvents LSDLink As LinkLabel
    Friend WithEvents OpenFolderCWD As Button
    Friend WithEvents SizeChanger As Timer
    Friend WithEvents SecChecker As Timer
    Friend WithEvents DebugLabel As Label
    Friend WithEvents DLProgBar As ProgressBar
    Friend WithEvents ConsoleLog As TextBox
    Friend WithEvents ConsoleOutputLabel As Label
    Friend WithEvents TopMostCheck As CheckBox
    Friend WithEvents BGDownloader As System.ComponentModel.BackgroundWorker
End Class
