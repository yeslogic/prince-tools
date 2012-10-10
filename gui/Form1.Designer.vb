<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.GBMain = New System.Windows.Forms.GroupBox()
        Me.bttnDocDown = New System.Windows.Forms.Button()
        Me.bttnDocUp = New System.Windows.Forms.Button()
        Me.bttnLicense = New System.Windows.Forms.Button()
        Me.bttnAbout = New System.Windows.Forms.Button()
        Me.GBLine2 = New System.Windows.Forms.GroupBox()
        Me.GBLine1 = New System.Windows.Forms.GroupBox()
        Me.lvwDoc = New prince_gui.UListView()
        Me.conv = New System.Windows.Forms.Button()
        Me.convImages = New System.Windows.Forms.ImageList(Me.components)
        Me.bttnOpenFolder = New System.Windows.Forms.Button()
        Me.textBoxSave = New System.Windows.Forms.TextBox()
        Me.lblSaveOutput = New System.Windows.Forms.Label()
        Me.ChBoxMerge = New System.Windows.Forms.CheckBox()
        Me.clearAll = New System.Windows.Forms.Button()
        Me.removeFile = New System.Windows.Forms.Button()
        Me.addURL = New System.Windows.Forms.Button()
        Me.addFile = New System.Windows.Forms.Button()
        Me.lvwLog = New System.Windows.Forms.ListView()
        Me.optionTabs = New System.Windows.Forms.TabControl()
        Me.CssJavaTab = New System.Windows.Forms.TabPage()
        Me.GBJavaScript = New System.Windows.Forms.GroupBox()
        Me.lblGbJsTitle = New System.Windows.Forms.Label()
        Me.bttnJsDown = New System.Windows.Forms.Button()
        Me.bttnJsUp = New System.Windows.Forms.Button()
        Me.editJS = New System.Windows.Forms.Button()
        Me.removeJS = New System.Windows.Forms.Button()
        Me.addJS = New System.Windows.Forms.Button()
        Me.lvwJS = New System.Windows.Forms.ListView()
        Me.GBCss = New System.Windows.Forms.GroupBox()
        Me.lblGbCssTitle = New System.Windows.Forms.Label()
        Me.bttnCssDown = New System.Windows.Forms.Button()
        Me.bttnCssUp = New System.Windows.Forms.Button()
        Me.editCss = New System.Windows.Forms.Button()
        Me.removeCss = New System.Windows.Forms.Button()
        Me.addCss = New System.Windows.Forms.Button()
        Me.lvwCSS = New System.Windows.Forms.ListView()
        Me.PdfTab = New System.Windows.Forms.TabPage()
        Me.GBAttachment = New System.Windows.Forms.GroupBox()
        Me.BttnRemoveAttach = New System.Windows.Forms.Button()
        Me.BttnAddAttach = New System.Windows.Forms.Button()
        Me.lvwAttachment = New System.Windows.Forms.ListView()
        Me.GBEmbedFonts = New System.Windows.Forms.GroupBox()
        Me.ChEmbedSubsetFontFile = New System.Windows.Forms.CheckBox()
        Me.ChEmbedFontFile = New System.Windows.Forms.CheckBox()
        Me.GBEncrypt = New System.Windows.Forms.GroupBox()
        Me.textBoxOwnerPass = New System.Windows.Forms.TextBox()
        Me.textBoxUserPass = New System.Windows.Forms.TextBox()
        Me.LblOwnerPass = New System.Windows.Forms.Label()
        Me.LblUserPass = New System.Windows.Forms.Label()
        Me.RButton128 = New System.Windows.Forms.RadioButton()
        Me.RButton40 = New System.Windows.Forms.RadioButton()
        Me.lblKeyBits = New System.Windows.Forms.Label()
        Me.ChDisallowAnnotation = New System.Windows.Forms.CheckBox()
        Me.ChDisallowCopyText = New System.Windows.Forms.CheckBox()
        Me.ChDisallowModify = New System.Windows.Forms.CheckBox()
        Me.ChDisallowPrint = New System.Windows.Forms.CheckBox()
        Me.ChEncrypt = New System.Windows.Forms.CheckBox()
        Me.openFD = New System.Windows.Forms.OpenFileDialog()
        Me.folderBD = New System.Windows.Forms.FolderBrowserDialog()
        Me.ConvPrgrsBar = New System.Windows.Forms.ProgressBar()
        Me.comboDoctype = New System.Windows.Forms.ComboBox()
        Me.SaveFD = New System.Windows.Forms.SaveFileDialog()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.GBMain.SuspendLayout()
        Me.optionTabs.SuspendLayout()
        Me.CssJavaTab.SuspendLayout()
        Me.GBJavaScript.SuspendLayout()
        Me.GBCss.SuspendLayout()
        Me.PdfTab.SuspendLayout()
        Me.GBAttachment.SuspendLayout()
        Me.GBEmbedFonts.SuspendLayout()
        Me.GBEncrypt.SuspendLayout()
        Me.SuspendLayout()
        '
        'GBMain
        '
        Me.GBMain.AutoSize = True
        Me.GBMain.Controls.Add(Me.bttnDocDown)
        Me.GBMain.Controls.Add(Me.bttnDocUp)
        Me.GBMain.Controls.Add(Me.bttnLicense)
        Me.GBMain.Controls.Add(Me.bttnAbout)
        Me.GBMain.Controls.Add(Me.GBLine2)
        Me.GBMain.Controls.Add(Me.GBLine1)
        Me.GBMain.Controls.Add(Me.lvwDoc)
        Me.GBMain.Controls.Add(Me.conv)
        Me.GBMain.Controls.Add(Me.bttnOpenFolder)
        Me.GBMain.Controls.Add(Me.textBoxSave)
        Me.GBMain.Controls.Add(Me.lblSaveOutput)
        Me.GBMain.Controls.Add(Me.ChBoxMerge)
        Me.GBMain.Controls.Add(Me.clearAll)
        Me.GBMain.Controls.Add(Me.removeFile)
        Me.GBMain.Controls.Add(Me.addURL)
        Me.GBMain.Controls.Add(Me.addFile)
        Me.GBMain.Controls.Add(Me.lvwLog)
        Me.GBMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GBMain.Location = New System.Drawing.Point(24, 12)
        Me.GBMain.Name = "GBMain"
        Me.GBMain.Size = New System.Drawing.Size(680, 571)
        Me.GBMain.TabIndex = 0
        Me.GBMain.TabStop = False
        '
        'bttnDocDown
        '
        Me.bttnDocDown.FlatAppearance.BorderSize = 0
        Me.bttnDocDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttnDocDown.Image = CType(resources.GetObject("bttnDocDown.Image"), System.Drawing.Image)
        Me.bttnDocDown.Location = New System.Drawing.Point(615, 198)
        Me.bttnDocDown.Name = "bttnDocDown"
        Me.bttnDocDown.Size = New System.Drawing.Size(40, 40)
        Me.bttnDocDown.TabIndex = 17
        Me.bttnDocDown.UseVisualStyleBackColor = True
        '
        'bttnDocUp
        '
        Me.bttnDocUp.FlatAppearance.BorderSize = 0
        Me.bttnDocUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttnDocUp.Image = CType(resources.GetObject("bttnDocUp.Image"), System.Drawing.Image)
        Me.bttnDocUp.Location = New System.Drawing.Point(615, 149)
        Me.bttnDocUp.Name = "bttnDocUp"
        Me.bttnDocUp.Size = New System.Drawing.Size(40, 42)
        Me.bttnDocUp.TabIndex = 16
        Me.bttnDocUp.UseVisualStyleBackColor = True
        '
        'bttnLicense
        '
        Me.bttnLicense.FlatAppearance.BorderSize = 0
        Me.bttnLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttnLicense.Image = CType(resources.GetObject("bttnLicense.Image"), System.Drawing.Image)
        Me.bttnLicense.Location = New System.Drawing.Point(519, 16)
        Me.bttnLicense.Name = "bttnLicense"
        Me.bttnLicense.Size = New System.Drawing.Size(76, 70)
        Me.bttnLicense.TabIndex = 15
        Me.bttnLicense.Text = "License"
        Me.bttnLicense.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.bttnLicense.UseVisualStyleBackColor = True
        '
        'bttnAbout
        '
        Me.bttnAbout.FlatAppearance.BorderSize = 0
        Me.bttnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttnAbout.Image = CType(resources.GetObject("bttnAbout.Image"), System.Drawing.Image)
        Me.bttnAbout.Location = New System.Drawing.Point(428, 16)
        Me.bttnAbout.Name = "bttnAbout"
        Me.bttnAbout.Size = New System.Drawing.Size(76, 70)
        Me.bttnAbout.TabIndex = 14
        Me.bttnAbout.Text = "About"
        Me.bttnAbout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.bttnAbout.UseVisualStyleBackColor = True
        '
        'GBLine2
        '
        Me.GBLine2.Location = New System.Drawing.Point(610, 10)
        Me.GBLine2.Name = "GBLine2"
        Me.GBLine2.Size = New System.Drawing.Size(2, 80)
        Me.GBLine2.TabIndex = 13
        Me.GBLine2.TabStop = False
        '
        'GBLine1
        '
        Me.GBLine1.Location = New System.Drawing.Point(420, 10)
        Me.GBLine1.Name = "GBLine1"
        Me.GBLine1.Size = New System.Drawing.Size(2, 80)
        Me.GBLine1.TabIndex = 12
        Me.GBLine1.TabStop = False
        '
        'lvwDoc
        '
        Me.lvwDoc.AllowDrop = True
        Me.lvwDoc.FullRowSelect = True
        Me.lvwDoc.Location = New System.Drawing.Point(16, 100)
        Me.lvwDoc.Name = "lvwDoc"
        Me.lvwDoc.Size = New System.Drawing.Size(584, 198)
        Me.lvwDoc.TabIndex = 11
        Me.lvwDoc.UseCompatibleStateImageBehavior = False
        Me.lvwDoc.View = System.Windows.Forms.View.Details
        Me.lvwDoc.WatermarkAlpha = 140
        Me.lvwDoc.WatermarkImage = CType(resources.GetObject("lvwDoc.WatermarkImage"), System.Drawing.Bitmap)
        '
        'conv
        '
        Me.conv.FlatAppearance.BorderSize = 0
        Me.conv.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.conv.ImageIndex = 0
        Me.conv.ImageList = Me.convImages
        Me.conv.Location = New System.Drawing.Point(498, 311)
        Me.conv.Name = "conv"
        Me.conv.Size = New System.Drawing.Size(156, 55)
        Me.conv.TabIndex = 10
        Me.conv.UseVisualStyleBackColor = True
        '
        'convImages
        '
        Me.convImages.ImageStream = CType(resources.GetObject("convImages.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.convImages.TransparentColor = System.Drawing.Color.Transparent
        Me.convImages.Images.SetKeyName(0, "convert.png")
        Me.convImages.Images.SetKeyName(1, "converthover.png")
        Me.convImages.Images.SetKeyName(2, "convertactive.png")
        '
        'bttnOpenFolder
        '
        Me.bttnOpenFolder.Enabled = False
        Me.bttnOpenFolder.Location = New System.Drawing.Point(396, 330)
        Me.bttnOpenFolder.Name = "bttnOpenFolder"
        Me.bttnOpenFolder.Size = New System.Drawing.Size(75, 23)
        Me.bttnOpenFolder.TabIndex = 9
        Me.bttnOpenFolder.Text = "Open Folder"
        Me.bttnOpenFolder.UseVisualStyleBackColor = True
        '
        'textBoxSave
        '
        Me.textBoxSave.Enabled = False
        Me.textBoxSave.Location = New System.Drawing.Point(110, 332)
        Me.textBoxSave.Name = "textBoxSave"
        Me.textBoxSave.Size = New System.Drawing.Size(270, 20)
        Me.textBoxSave.TabIndex = 8
        '
        'lblSaveOutput
        '
        Me.lblSaveOutput.AutoSize = True
        Me.lblSaveOutput.Enabled = False
        Me.lblSaveOutput.Location = New System.Drawing.Point(21, 334)
        Me.lblSaveOutput.Name = "lblSaveOutput"
        Me.lblSaveOutput.Size = New System.Drawing.Size(87, 13)
        Me.lblSaveOutput.TabIndex = 7
        Me.lblSaveOutput.Text = "Save PDF file to:"
        '
        'ChBoxMerge
        '
        Me.ChBoxMerge.AutoSize = True
        Me.ChBoxMerge.Enabled = False
        Me.ChBoxMerge.Location = New System.Drawing.Point(24, 304)
        Me.ChBoxMerge.Name = "ChBoxMerge"
        Me.ChBoxMerge.Size = New System.Drawing.Size(223, 17)
        Me.ChBoxMerge.TabIndex = 6
        Me.ChBoxMerge.Text = "Merge all documents into a single PDF file"
        Me.ChBoxMerge.UseVisualStyleBackColor = True
        '
        'clearAll
        '
        Me.clearAll.FlatAppearance.BorderSize = 0
        Me.clearAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.clearAll.Image = CType(resources.GetObject("clearAll.Image"), System.Drawing.Image)
        Me.clearAll.Location = New System.Drawing.Point(330, 16)
        Me.clearAll.Name = "clearAll"
        Me.clearAll.Size = New System.Drawing.Size(76, 70)
        Me.clearAll.TabIndex = 5
        Me.clearAll.Text = "Clear All"
        Me.clearAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.clearAll.UseVisualStyleBackColor = True
        '
        'removeFile
        '
        Me.removeFile.FlatAppearance.BorderSize = 0
        Me.removeFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.removeFile.Image = CType(resources.GetObject("removeFile.Image"), System.Drawing.Image)
        Me.removeFile.Location = New System.Drawing.Point(234, 16)
        Me.removeFile.Name = "removeFile"
        Me.removeFile.Size = New System.Drawing.Size(76, 70)
        Me.removeFile.TabIndex = 4
        Me.removeFile.Text = "Remove"
        Me.removeFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.removeFile.UseVisualStyleBackColor = True
        '
        'addURL
        '
        Me.addURL.FlatAppearance.BorderSize = 0
        Me.addURL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.addURL.Image = CType(resources.GetObject("addURL.Image"), System.Drawing.Image)
        Me.addURL.Location = New System.Drawing.Point(138, 16)
        Me.addURL.Name = "addURL"
        Me.addURL.Size = New System.Drawing.Size(76, 70)
        Me.addURL.TabIndex = 3
        Me.addURL.Text = "Add URL"
        Me.addURL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.addURL.UseVisualStyleBackColor = True
        '
        'addFile
        '
        Me.addFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.addFile.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.addFile.FlatAppearance.BorderSize = 0
        Me.addFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.addFile.Image = CType(resources.GetObject("addFile.Image"), System.Drawing.Image)
        Me.addFile.Location = New System.Drawing.Point(42, 16)
        Me.addFile.Name = "addFile"
        Me.addFile.Size = New System.Drawing.Size(76, 70)
        Me.addFile.TabIndex = 2
        Me.addFile.Text = "Add file(s)"
        Me.addFile.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.addFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.addFile.UseVisualStyleBackColor = True
        '
        'lvwLog
        '
        Me.lvwLog.FullRowSelect = True
        Me.lvwLog.Location = New System.Drawing.Point(16, 376)
        Me.lvwLog.Name = "lvwLog"
        Me.lvwLog.Size = New System.Drawing.Size(640, 176)
        Me.lvwLog.TabIndex = 1
        Me.lvwLog.UseCompatibleStateImageBehavior = False
        Me.lvwLog.View = System.Windows.Forms.View.Details
        '
        'optionTabs
        '
        Me.optionTabs.Controls.Add(Me.CssJavaTab)
        Me.optionTabs.Controls.Add(Me.PdfTab)
        Me.optionTabs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optionTabs.Location = New System.Drawing.Point(720, 16)
        Me.optionTabs.Multiline = True
        Me.optionTabs.Name = "optionTabs"
        Me.optionTabs.Padding = New System.Drawing.Point(6, 8)
        Me.optionTabs.SelectedIndex = 0
        Me.optionTabs.Size = New System.Drawing.Size(480, 592)
        Me.optionTabs.TabIndex = 1
        '
        'CssJavaTab
        '
        Me.CssJavaTab.BackColor = System.Drawing.SystemColors.Control
        Me.CssJavaTab.Controls.Add(Me.GBJavaScript)
        Me.CssJavaTab.Controls.Add(Me.GBCss)
        Me.CssJavaTab.Location = New System.Drawing.Point(4, 34)
        Me.CssJavaTab.Name = "CssJavaTab"
        Me.CssJavaTab.Padding = New System.Windows.Forms.Padding(3)
        Me.CssJavaTab.Size = New System.Drawing.Size(472, 554)
        Me.CssJavaTab.TabIndex = 0
        Me.CssJavaTab.Text = "                       CSS & JavaScript                        "
        '
        'GBJavaScript
        '
        Me.GBJavaScript.Controls.Add(Me.lblGbJsTitle)
        Me.GBJavaScript.Controls.Add(Me.bttnJsDown)
        Me.GBJavaScript.Controls.Add(Me.bttnJsUp)
        Me.GBJavaScript.Controls.Add(Me.editJS)
        Me.GBJavaScript.Controls.Add(Me.removeJS)
        Me.GBJavaScript.Controls.Add(Me.addJS)
        Me.GBJavaScript.Controls.Add(Me.lvwJS)
        Me.GBJavaScript.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBJavaScript.Location = New System.Drawing.Point(24, 284)
        Me.GBJavaScript.Name = "GBJavaScript"
        Me.GBJavaScript.Size = New System.Drawing.Size(424, 268)
        Me.GBJavaScript.TabIndex = 1
        Me.GBJavaScript.TabStop = False
        '
        'lblGbJsTitle
        '
        Me.lblGbJsTitle.AutoSize = True
        Me.lblGbJsTitle.Location = New System.Drawing.Point(155, 1)
        Me.lblGbJsTitle.Name = "lblGbJsTitle"
        Me.lblGbJsTitle.Size = New System.Drawing.Size(90, 13)
        Me.lblGbJsTitle.TabIndex = 6
        Me.lblGbJsTitle.Text = "  JavaScript (JS)  "
        '
        'bttnJsDown
        '
        Me.bttnJsDown.FlatAppearance.BorderSize = 0
        Me.bttnJsDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttnJsDown.Image = CType(resources.GetObject("bttnJsDown.Image"), System.Drawing.Image)
        Me.bttnJsDown.Location = New System.Drawing.Point(374, 176)
        Me.bttnJsDown.Name = "bttnJsDown"
        Me.bttnJsDown.Size = New System.Drawing.Size(40, 40)
        Me.bttnJsDown.TabIndex = 5
        Me.bttnJsDown.UseVisualStyleBackColor = True
        '
        'bttnJsUp
        '
        Me.bttnJsUp.FlatAppearance.BorderSize = 0
        Me.bttnJsUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttnJsUp.Image = CType(resources.GetObject("bttnJsUp.Image"), System.Drawing.Image)
        Me.bttnJsUp.Location = New System.Drawing.Point(374, 128)
        Me.bttnJsUp.Name = "bttnJsUp"
        Me.bttnJsUp.Size = New System.Drawing.Size(40, 42)
        Me.bttnJsUp.TabIndex = 4
        Me.bttnJsUp.UseVisualStyleBackColor = True
        '
        'editJS
        '
        Me.editJS.FlatAppearance.BorderSize = 0
        Me.editJS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.editJS.Image = CType(resources.GetObject("editJS.Image"), System.Drawing.Image)
        Me.editJS.Location = New System.Drawing.Point(265, 19)
        Me.editJS.Name = "editJS"
        Me.editJS.Size = New System.Drawing.Size(60, 60)
        Me.editJS.TabIndex = 3
        Me.editJS.Text = "Edit JS"
        Me.editJS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.editJS.UseVisualStyleBackColor = True
        '
        'removeJS
        '
        Me.removeJS.FlatAppearance.BorderSize = 0
        Me.removeJS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.removeJS.Image = CType(resources.GetObject("removeJS.Image"), System.Drawing.Image)
        Me.removeJS.Location = New System.Drawing.Point(168, 19)
        Me.removeJS.Name = "removeJS"
        Me.removeJS.Size = New System.Drawing.Size(60, 60)
        Me.removeJS.TabIndex = 2
        Me.removeJS.Text = "Remove"
        Me.removeJS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.removeJS.UseVisualStyleBackColor = True
        '
        'addJS
        '
        Me.addJS.FlatAppearance.BorderSize = 0
        Me.addJS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.addJS.Image = CType(resources.GetObject("addJS.Image"), System.Drawing.Image)
        Me.addJS.Location = New System.Drawing.Point(71, 19)
        Me.addJS.Name = "addJS"
        Me.addJS.Size = New System.Drawing.Size(60, 60)
        Me.addJS.TabIndex = 1
        Me.addJS.Text = "Add JS"
        Me.addJS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.addJS.UseVisualStyleBackColor = True
        '
        'lvwJS
        '
        Me.lvwJS.AllowDrop = True
        Me.lvwJS.FullRowSelect = True
        Me.lvwJS.Location = New System.Drawing.Point(8, 89)
        Me.lvwJS.Name = "lvwJS"
        Me.lvwJS.Size = New System.Drawing.Size(360, 171)
        Me.lvwJS.TabIndex = 0
        Me.lvwJS.UseCompatibleStateImageBehavior = False
        Me.lvwJS.View = System.Windows.Forms.View.Details
        '
        'GBCss
        '
        Me.GBCss.Controls.Add(Me.lblGbCssTitle)
        Me.GBCss.Controls.Add(Me.bttnCssDown)
        Me.GBCss.Controls.Add(Me.bttnCssUp)
        Me.GBCss.Controls.Add(Me.editCss)
        Me.GBCss.Controls.Add(Me.removeCss)
        Me.GBCss.Controls.Add(Me.addCss)
        Me.GBCss.Controls.Add(Me.lvwCSS)
        Me.GBCss.Location = New System.Drawing.Point(24, 14)
        Me.GBCss.Name = "GBCss"
        Me.GBCss.Size = New System.Drawing.Size(424, 264)
        Me.GBCss.TabIndex = 0
        Me.GBCss.TabStop = False
        '
        'lblGbCssTitle
        '
        Me.lblGbCssTitle.AutoSize = True
        Me.lblGbCssTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGbCssTitle.Location = New System.Drawing.Point(125, 1)
        Me.lblGbCssTitle.Name = "lblGbCssTitle"
        Me.lblGbCssTitle.Size = New System.Drawing.Size(156, 13)
        Me.lblGbCssTitle.TabIndex = 6
        Me.lblGbCssTitle.Text = "  Cascading Style Sheet (CSS)  "
        '
        'bttnCssDown
        '
        Me.bttnCssDown.FlatAppearance.BorderSize = 0
        Me.bttnCssDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttnCssDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnCssDown.Image = CType(resources.GetObject("bttnCssDown.Image"), System.Drawing.Image)
        Me.bttnCssDown.Location = New System.Drawing.Point(374, 171)
        Me.bttnCssDown.Name = "bttnCssDown"
        Me.bttnCssDown.Size = New System.Drawing.Size(40, 40)
        Me.bttnCssDown.TabIndex = 5
        Me.bttnCssDown.UseVisualStyleBackColor = True
        '
        'bttnCssUp
        '
        Me.bttnCssUp.FlatAppearance.BorderSize = 0
        Me.bttnCssUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttnCssUp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnCssUp.Image = CType(resources.GetObject("bttnCssUp.Image"), System.Drawing.Image)
        Me.bttnCssUp.Location = New System.Drawing.Point(374, 123)
        Me.bttnCssUp.Name = "bttnCssUp"
        Me.bttnCssUp.Size = New System.Drawing.Size(40, 42)
        Me.bttnCssUp.TabIndex = 4
        Me.bttnCssUp.UseVisualStyleBackColor = True
        '
        'editCss
        '
        Me.editCss.FlatAppearance.BorderSize = 0
        Me.editCss.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.editCss.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.editCss.Image = CType(resources.GetObject("editCss.Image"), System.Drawing.Image)
        Me.editCss.Location = New System.Drawing.Point(265, 19)
        Me.editCss.Name = "editCss"
        Me.editCss.Size = New System.Drawing.Size(60, 60)
        Me.editCss.TabIndex = 3
        Me.editCss.Text = "Edit CSS"
        Me.editCss.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.editCss.UseVisualStyleBackColor = True
        '
        'removeCss
        '
        Me.removeCss.FlatAppearance.BorderSize = 0
        Me.removeCss.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.removeCss.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.removeCss.Image = CType(resources.GetObject("removeCss.Image"), System.Drawing.Image)
        Me.removeCss.Location = New System.Drawing.Point(168, 19)
        Me.removeCss.Name = "removeCss"
        Me.removeCss.Size = New System.Drawing.Size(60, 60)
        Me.removeCss.TabIndex = 2
        Me.removeCss.Text = "Remove"
        Me.removeCss.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.removeCss.UseVisualStyleBackColor = True
        '
        'addCss
        '
        Me.addCss.FlatAppearance.BorderSize = 0
        Me.addCss.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.addCss.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addCss.Image = CType(resources.GetObject("addCss.Image"), System.Drawing.Image)
        Me.addCss.Location = New System.Drawing.Point(71, 19)
        Me.addCss.Name = "addCss"
        Me.addCss.Size = New System.Drawing.Size(60, 60)
        Me.addCss.TabIndex = 1
        Me.addCss.Text = "Add CSS"
        Me.addCss.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.addCss.UseVisualStyleBackColor = True
        '
        'lvwCSS
        '
        Me.lvwCSS.AllowDrop = True
        Me.lvwCSS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvwCSS.FullRowSelect = True
        Me.lvwCSS.Location = New System.Drawing.Point(8, 85)
        Me.lvwCSS.Name = "lvwCSS"
        Me.lvwCSS.Size = New System.Drawing.Size(360, 171)
        Me.lvwCSS.TabIndex = 0
        Me.lvwCSS.UseCompatibleStateImageBehavior = False
        Me.lvwCSS.View = System.Windows.Forms.View.Details
        '
        'PdfTab
        '
        Me.PdfTab.BackColor = System.Drawing.SystemColors.Control
        Me.PdfTab.Controls.Add(Me.GBAttachment)
        Me.PdfTab.Controls.Add(Me.GBEmbedFonts)
        Me.PdfTab.Controls.Add(Me.GBEncrypt)
        Me.PdfTab.Location = New System.Drawing.Point(4, 34)
        Me.PdfTab.Name = "PdfTab"
        Me.PdfTab.Padding = New System.Windows.Forms.Padding(3)
        Me.PdfTab.Size = New System.Drawing.Size(472, 554)
        Me.PdfTab.TabIndex = 1
        Me.PdfTab.Text = "                       PDF Settings                        "
        '
        'GBAttachment
        '
        Me.GBAttachment.Controls.Add(Me.BttnRemoveAttach)
        Me.GBAttachment.Controls.Add(Me.BttnAddAttach)
        Me.GBAttachment.Controls.Add(Me.lvwAttachment)
        Me.GBAttachment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBAttachment.Location = New System.Drawing.Point(12, 388)
        Me.GBAttachment.Name = "GBAttachment"
        Me.GBAttachment.Size = New System.Drawing.Size(445, 165)
        Me.GBAttachment.TabIndex = 2
        Me.GBAttachment.TabStop = False
        Me.GBAttachment.Text = " Attachment"
        '
        'BttnRemoveAttach
        '
        Me.BttnRemoveAttach.FlatAppearance.BorderSize = 0
        Me.BttnRemoveAttach.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttnRemoveAttach.Image = CType(resources.GetObject("BttnRemoveAttach.Image"), System.Drawing.Image)
        Me.BttnRemoveAttach.Location = New System.Drawing.Point(372, 90)
        Me.BttnRemoveAttach.Name = "BttnRemoveAttach"
        Me.BttnRemoveAttach.Size = New System.Drawing.Size(60, 60)
        Me.BttnRemoveAttach.TabIndex = 2
        Me.BttnRemoveAttach.Text = "Remove"
        Me.BttnRemoveAttach.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BttnRemoveAttach.UseVisualStyleBackColor = True
        '
        'BttnAddAttach
        '
        Me.BttnAddAttach.FlatAppearance.BorderSize = 0
        Me.BttnAddAttach.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttnAddAttach.Image = CType(resources.GetObject("BttnAddAttach.Image"), System.Drawing.Image)
        Me.BttnAddAttach.Location = New System.Drawing.Point(372, 25)
        Me.BttnAddAttach.Name = "BttnAddAttach"
        Me.BttnAddAttach.Size = New System.Drawing.Size(60, 60)
        Me.BttnAddAttach.TabIndex = 1
        Me.BttnAddAttach.Text = "Add"
        Me.BttnAddAttach.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BttnAddAttach.UseVisualStyleBackColor = True
        '
        'lvwAttachment
        '
        Me.lvwAttachment.AllowDrop = True
        Me.lvwAttachment.FullRowSelect = True
        Me.lvwAttachment.Location = New System.Drawing.Point(8, 19)
        Me.lvwAttachment.Name = "lvwAttachment"
        Me.lvwAttachment.Size = New System.Drawing.Size(352, 137)
        Me.lvwAttachment.TabIndex = 0
        Me.lvwAttachment.UseCompatibleStateImageBehavior = False
        Me.lvwAttachment.View = System.Windows.Forms.View.Details
        '
        'GBEmbedFonts
        '
        Me.GBEmbedFonts.Controls.Add(Me.ChEmbedSubsetFontFile)
        Me.GBEmbedFonts.Controls.Add(Me.ChEmbedFontFile)
        Me.GBEmbedFonts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBEmbedFonts.Location = New System.Drawing.Point(12, 308)
        Me.GBEmbedFonts.Name = "GBEmbedFonts"
        Me.GBEmbedFonts.Size = New System.Drawing.Size(445, 74)
        Me.GBEmbedFonts.TabIndex = 1
        Me.GBEmbedFonts.TabStop = False
        Me.GBEmbedFonts.Text = " Embed Fonts "
        '
        'ChEmbedSubsetFontFile
        '
        Me.ChEmbedSubsetFontFile.AutoSize = True
        Me.ChEmbedSubsetFontFile.Checked = True
        Me.ChEmbedSubsetFontFile.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChEmbedSubsetFontFile.Location = New System.Drawing.Point(51, 47)
        Me.ChEmbedSubsetFontFile.Name = "ChEmbedSubsetFontFile"
        Me.ChEmbedSubsetFontFile.Size = New System.Drawing.Size(142, 17)
        Me.ChEmbedSubsetFontFile.TabIndex = 1
        Me.ChEmbedSubsetFontFile.Text = "Subset Embedded Fonts"
        Me.ChEmbedSubsetFontFile.UseVisualStyleBackColor = True
        '
        'ChEmbedFontFile
        '
        Me.ChEmbedFontFile.AutoSize = True
        Me.ChEmbedFontFile.Checked = True
        Me.ChEmbedFontFile.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChEmbedFontFile.Location = New System.Drawing.Point(51, 22)
        Me.ChEmbedFontFile.Name = "ChEmbedFontFile"
        Me.ChEmbedFontFile.Size = New System.Drawing.Size(102, 17)
        Me.ChEmbedFontFile.TabIndex = 0
        Me.ChEmbedFontFile.Text = "Embed Font File"
        Me.ChEmbedFontFile.UseVisualStyleBackColor = True
        '
        'GBEncrypt
        '
        Me.GBEncrypt.Controls.Add(Me.textBoxOwnerPass)
        Me.GBEncrypt.Controls.Add(Me.textBoxUserPass)
        Me.GBEncrypt.Controls.Add(Me.LblOwnerPass)
        Me.GBEncrypt.Controls.Add(Me.LblUserPass)
        Me.GBEncrypt.Controls.Add(Me.RButton128)
        Me.GBEncrypt.Controls.Add(Me.RButton40)
        Me.GBEncrypt.Controls.Add(Me.lblKeyBits)
        Me.GBEncrypt.Controls.Add(Me.ChDisallowAnnotation)
        Me.GBEncrypt.Controls.Add(Me.ChDisallowCopyText)
        Me.GBEncrypt.Controls.Add(Me.ChDisallowModify)
        Me.GBEncrypt.Controls.Add(Me.ChDisallowPrint)
        Me.GBEncrypt.Controls.Add(Me.ChEncrypt)
        Me.GBEncrypt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBEncrypt.Location = New System.Drawing.Point(12, 13)
        Me.GBEncrypt.Name = "GBEncrypt"
        Me.GBEncrypt.Size = New System.Drawing.Size(445, 289)
        Me.GBEncrypt.TabIndex = 0
        Me.GBEncrypt.TabStop = False
        Me.GBEncrypt.Text = "   "
        '
        'textBoxOwnerPass
        '
        Me.textBoxOwnerPass.Location = New System.Drawing.Point(32, 241)
        Me.textBoxOwnerPass.Name = "textBoxOwnerPass"
        Me.textBoxOwnerPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.textBoxOwnerPass.Size = New System.Drawing.Size(387, 20)
        Me.textBoxOwnerPass.TabIndex = 11
        '
        'textBoxUserPass
        '
        Me.textBoxUserPass.Location = New System.Drawing.Point(32, 190)
        Me.textBoxUserPass.Name = "textBoxUserPass"
        Me.textBoxUserPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.textBoxUserPass.Size = New System.Drawing.Size(387, 20)
        Me.textBoxUserPass.TabIndex = 10
        '
        'LblOwnerPass
        '
        Me.LblOwnerPass.AutoSize = True
        Me.LblOwnerPass.Location = New System.Drawing.Point(29, 223)
        Me.LblOwnerPass.Name = "LblOwnerPass"
        Me.LblOwnerPass.Size = New System.Drawing.Size(87, 13)
        Me.LblOwnerPass.TabIndex = 9
        Me.LblOwnerPass.Text = "Owner Password"
        '
        'LblUserPass
        '
        Me.LblUserPass.AutoSize = True
        Me.LblUserPass.Location = New System.Drawing.Point(29, 171)
        Me.LblUserPass.Name = "LblUserPass"
        Me.LblUserPass.Size = New System.Drawing.Size(78, 13)
        Me.LblUserPass.TabIndex = 8
        Me.LblUserPass.Text = "User Password"
        '
        'RButton128
        '
        Me.RButton128.AutoSize = True
        Me.RButton128.Location = New System.Drawing.Point(255, 106)
        Me.RButton128.Name = "RButton128"
        Me.RButton128.Size = New System.Drawing.Size(63, 17)
        Me.RButton128.TabIndex = 7
        Me.RButton128.TabStop = True
        Me.RButton128.Text = "128 Bits"
        Me.RButton128.UseVisualStyleBackColor = True
        '
        'RButton40
        '
        Me.RButton40.AutoSize = True
        Me.RButton40.Location = New System.Drawing.Point(255, 81)
        Me.RButton40.Name = "RButton40"
        Me.RButton40.Size = New System.Drawing.Size(57, 17)
        Me.RButton40.TabIndex = 6
        Me.RButton40.TabStop = True
        Me.RButton40.Text = "40 Bits"
        Me.RButton40.UseVisualStyleBackColor = True
        '
        'lblKeyBits
        '
        Me.lblKeyBits.AutoSize = True
        Me.lblKeyBits.Location = New System.Drawing.Point(252, 55)
        Me.lblKeyBits.Name = "lblKeyBits"
        Me.lblKeyBits.Size = New System.Drawing.Size(45, 13)
        Me.lblKeyBits.TabIndex = 5
        Me.lblKeyBits.Text = "Key Bits"
        '
        'ChDisallowAnnotation
        '
        Me.ChDisallowAnnotation.AutoSize = True
        Me.ChDisallowAnnotation.Location = New System.Drawing.Point(51, 123)
        Me.ChDisallowAnnotation.Name = "ChDisallowAnnotation"
        Me.ChDisallowAnnotation.Size = New System.Drawing.Size(119, 17)
        Me.ChDisallowAnnotation.TabIndex = 4
        Me.ChDisallowAnnotation.Text = "Disallow Annotation"
        Me.ChDisallowAnnotation.UseVisualStyleBackColor = True
        '
        'ChDisallowCopyText
        '
        Me.ChDisallowCopyText.AutoSize = True
        Me.ChDisallowCopyText.Location = New System.Drawing.Point(51, 98)
        Me.ChDisallowCopyText.Name = "ChDisallowCopyText"
        Me.ChDisallowCopyText.Size = New System.Drawing.Size(130, 17)
        Me.ChDisallowCopyText.TabIndex = 3
        Me.ChDisallowCopyText.Text = "Disallow Copying Text"
        Me.ChDisallowCopyText.UseVisualStyleBackColor = True
        '
        'ChDisallowModify
        '
        Me.ChDisallowModify.AutoSize = True
        Me.ChDisallowModify.Location = New System.Drawing.Point(51, 72)
        Me.ChDisallowModify.Name = "ChDisallowModify"
        Me.ChDisallowModify.Size = New System.Drawing.Size(125, 17)
        Me.ChDisallowModify.TabIndex = 2
        Me.ChDisallowModify.Text = "Disallow Modification"
        Me.ChDisallowModify.UseVisualStyleBackColor = True
        '
        'ChDisallowPrint
        '
        Me.ChDisallowPrint.AutoSize = True
        Me.ChDisallowPrint.Location = New System.Drawing.Point(51, 46)
        Me.ChDisallowPrint.Name = "ChDisallowPrint"
        Me.ChDisallowPrint.Size = New System.Drawing.Size(103, 17)
        Me.ChDisallowPrint.TabIndex = 1
        Me.ChDisallowPrint.Text = "Disallow Printing"
        Me.ChDisallowPrint.UseVisualStyleBackColor = True
        '
        'ChEncrypt
        '
        Me.ChEncrypt.AutoSize = True
        Me.ChEncrypt.Location = New System.Drawing.Point(12, -1)
        Me.ChEncrypt.Name = "ChEncrypt"
        Me.ChEncrypt.Size = New System.Drawing.Size(105, 17)
        Me.ChEncrypt.TabIndex = 0
        Me.ChEncrypt.Text = "Encrypt PDF File"
        Me.ChEncrypt.UseVisualStyleBackColor = True
        '
        'openFD
        '
        Me.openFD.FileName = "OpenFileDialog1"
        '
        'ConvPrgrsBar
        '
        Me.ConvPrgrsBar.Location = New System.Drawing.Point(24, 608)
        Me.ConvPrgrsBar.Name = "ConvPrgrsBar"
        Me.ConvPrgrsBar.Size = New System.Drawing.Size(680, 20)
        Me.ConvPrgrsBar.TabIndex = 11
        Me.ConvPrgrsBar.Visible = False
        '
        'comboDoctype
        '
        Me.comboDoctype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboDoctype.FormattingEnabled = True
        Me.comboDoctype.Location = New System.Drawing.Point(724, 614)
        Me.comboDoctype.Name = "comboDoctype"
        Me.comboDoctype.Size = New System.Drawing.Size(41, 21)
        Me.comboDoctype.TabIndex = 12
        Me.comboDoctype.Visible = False
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(24, 590)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(0, 13)
        Me.lblStatus.TabIndex = 13
        Me.lblStatus.Visible = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1240, 642)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.comboDoctype)
        Me.Controls.Add(Me.ConvPrgrsBar)
        Me.Controls.Add(Me.optionTabs)
        Me.Controls.Add(Me.GBMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Prince"
        Me.GBMain.ResumeLayout(False)
        Me.GBMain.PerformLayout()
        Me.optionTabs.ResumeLayout(False)
        Me.CssJavaTab.ResumeLayout(False)
        Me.GBJavaScript.ResumeLayout(False)
        Me.GBJavaScript.PerformLayout()
        Me.GBCss.ResumeLayout(False)
        Me.GBCss.PerformLayout()
        Me.PdfTab.ResumeLayout(False)
        Me.GBAttachment.ResumeLayout(False)
        Me.GBEmbedFonts.ResumeLayout(False)
        Me.GBEmbedFonts.PerformLayout()
        Me.GBEncrypt.ResumeLayout(False)
        Me.GBEncrypt.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GBMain As System.Windows.Forms.GroupBox
    Friend WithEvents lvwLog As System.Windows.Forms.ListView
    Friend WithEvents optionTabs As System.Windows.Forms.TabControl
    Friend WithEvents CssJavaTab As System.Windows.Forms.TabPage
    Friend WithEvents PdfTab As System.Windows.Forms.TabPage
    Friend WithEvents clearAll As System.Windows.Forms.Button
    Friend WithEvents removeFile As System.Windows.Forms.Button
    Friend WithEvents addURL As System.Windows.Forms.Button
    Friend WithEvents addFile As System.Windows.Forms.Button
    Friend WithEvents GBJavaScript As System.Windows.Forms.GroupBox
    Friend WithEvents GBCss As System.Windows.Forms.GroupBox
    Friend WithEvents lvwJS As System.Windows.Forms.ListView
    Friend WithEvents lvwCSS As System.Windows.Forms.ListView
    Friend WithEvents addJS As System.Windows.Forms.Button
    Friend WithEvents addCss As System.Windows.Forms.Button
    Friend WithEvents conv As System.Windows.Forms.Button
    Friend WithEvents bttnOpenFolder As System.Windows.Forms.Button
    Friend WithEvents textBoxSave As System.Windows.Forms.TextBox
    Friend WithEvents lblSaveOutput As System.Windows.Forms.Label
    Friend WithEvents ChBoxMerge As System.Windows.Forms.CheckBox
    Friend WithEvents openFD As System.Windows.Forms.OpenFileDialog
    Friend WithEvents folderBD As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents ConvPrgrsBar As System.Windows.Forms.ProgressBar
    Friend WithEvents GBAttachment As System.Windows.Forms.GroupBox
    Friend WithEvents GBEmbedFonts As System.Windows.Forms.GroupBox
    Friend WithEvents GBEncrypt As System.Windows.Forms.GroupBox
    Friend WithEvents ChEncrypt As System.Windows.Forms.CheckBox
    Friend WithEvents comboDoctype As System.Windows.Forms.ComboBox
    Friend WithEvents ChDisallowAnnotation As System.Windows.Forms.CheckBox
    Friend WithEvents ChDisallowCopyText As System.Windows.Forms.CheckBox
    Friend WithEvents ChDisallowModify As System.Windows.Forms.CheckBox
    Friend WithEvents ChDisallowPrint As System.Windows.Forms.CheckBox
    Friend WithEvents RButton128 As System.Windows.Forms.RadioButton
    Friend WithEvents RButton40 As System.Windows.Forms.RadioButton
    Friend WithEvents lblKeyBits As System.Windows.Forms.Label
    Friend WithEvents textBoxOwnerPass As System.Windows.Forms.TextBox
    Friend WithEvents textBoxUserPass As System.Windows.Forms.TextBox
    Friend WithEvents LblOwnerPass As System.Windows.Forms.Label
    Friend WithEvents LblUserPass As System.Windows.Forms.Label
    Friend WithEvents ChEmbedSubsetFontFile As System.Windows.Forms.CheckBox
    Friend WithEvents ChEmbedFontFile As System.Windows.Forms.CheckBox
    Friend WithEvents BttnRemoveAttach As System.Windows.Forms.Button
    Friend WithEvents BttnAddAttach As System.Windows.Forms.Button
    Friend WithEvents lvwAttachment As System.Windows.Forms.ListView
    Friend WithEvents editJS As System.Windows.Forms.Button
    Friend WithEvents removeJS As System.Windows.Forms.Button
    Friend WithEvents editCss As System.Windows.Forms.Button
    Friend WithEvents removeCss As System.Windows.Forms.Button
    Friend WithEvents lvwDoc As prince_gui.UListView
    Friend WithEvents GBLine2 As System.Windows.Forms.GroupBox
    Friend WithEvents GBLine1 As System.Windows.Forms.GroupBox
    Friend WithEvents bttnLicense As System.Windows.Forms.Button
    Friend WithEvents bttnAbout As System.Windows.Forms.Button
    Friend WithEvents SaveFD As System.Windows.Forms.SaveFileDialog
    Friend WithEvents bttnDocDown As System.Windows.Forms.Button
    Friend WithEvents bttnDocUp As System.Windows.Forms.Button
    Friend WithEvents bttnJsDown As System.Windows.Forms.Button
    Friend WithEvents bttnJsUp As System.Windows.Forms.Button
    Friend WithEvents bttnCssDown As System.Windows.Forms.Button
    Friend WithEvents bttnCssUp As System.Windows.Forms.Button
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents convImages As System.Windows.Forms.ImageList
    Friend WithEvents lblGbCssTitle As System.Windows.Forms.Label
    Friend WithEvents lblGbJsTitle As System.Windows.Forms.Label

End Class
