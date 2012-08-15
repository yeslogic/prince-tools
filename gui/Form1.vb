Public Class Form1
    Inherits System.Windows.Forms.Form

    Private pr As Prince
    Private docItem As ListViewItem
    Friend WithEvents lvwDoc As prince_gui_2.UListView
    Private docSubitem As ListViewItem.ListViewSubItem

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents openFD As System.Windows.Forms.OpenFileDialog
    Friend WithEvents addFile As System.Windows.Forms.Button
    Friend WithEvents conv As System.Windows.Forms.Button
    Friend WithEvents optionTabs As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GBCss As System.Windows.Forms.GroupBox
    Friend WithEvents GBMain As System.Windows.Forms.GroupBox
    Friend WithEvents lvwLog As System.Windows.Forms.ListView
    Friend WithEvents ChBoxMerge As System.Windows.Forms.CheckBox
    Friend WithEvents lvwCSS As System.Windows.Forms.ListView
    Friend WithEvents addCss As System.Windows.Forms.Button
    Friend WithEvents GBJavaScript As System.Windows.Forms.GroupBox
    Friend WithEvents addJS As System.Windows.Forms.Button
    Friend WithEvents ConvPrgrsBar As System.Windows.Forms.ProgressBar
    Friend WithEvents comboDoctype As System.Windows.Forms.ComboBox
    Friend WithEvents GBAttachment As System.Windows.Forms.GroupBox
    Friend WithEvents GBEmbedFonts As System.Windows.Forms.GroupBox
    Friend WithEvents GBEncrypt As System.Windows.Forms.GroupBox
    Friend WithEvents ChDisallowAnnotation As System.Windows.Forms.CheckBox
    Friend WithEvents ChDisallowCopyText As System.Windows.Forms.CheckBox
    Friend WithEvents ChDisallowModify As System.Windows.Forms.CheckBox
    Friend WithEvents ChDisallowPrint As System.Windows.Forms.CheckBox
    Friend WithEvents LblUserPass As System.Windows.Forms.Label
    Friend WithEvents RButton128 As System.Windows.Forms.RadioButton
    Friend WithEvents RButton40 As System.Windows.Forms.RadioButton
    Friend WithEvents lblKeyBits As System.Windows.Forms.Label
    Friend WithEvents textBoxOwnerPass As System.Windows.Forms.TextBox
    Friend WithEvents textBoxUserPass As System.Windows.Forms.TextBox
    Friend WithEvents LblOwnerPass As System.Windows.Forms.Label
    Friend WithEvents BttnRemoveAttach As System.Windows.Forms.Button
    Friend WithEvents BttnAddAttach As System.Windows.Forms.Button
    Friend WithEvents lvwAttachment As System.Windows.Forms.ListView
    Friend WithEvents ChEmbedSubsetFontFile As System.Windows.Forms.CheckBox
    Friend WithEvents ChEmbedFontFile As System.Windows.Forms.CheckBox
    Friend WithEvents ChEncrypt As System.Windows.Forms.CheckBox
    Friend WithEvents clearAll As System.Windows.Forms.Button
    Friend WithEvents RemoveFile As System.Windows.Forms.Button
    Friend WithEvents lvwJS As System.Windows.Forms.ListView
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.addFile = New System.Windows.Forms.Button()
        Me.conv = New System.Windows.Forms.Button()
        Me.openFD = New System.Windows.Forms.OpenFileDialog()
        Me.optionTabs = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GBJavaScript = New System.Windows.Forms.GroupBox()
        Me.addJS = New System.Windows.Forms.Button()
        Me.lvwJS = New System.Windows.Forms.ListView()
        Me.GBCss = New System.Windows.Forms.GroupBox()
        Me.addCss = New System.Windows.Forms.Button()
        Me.lvwCSS = New System.Windows.Forms.ListView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GBAttachment = New System.Windows.Forms.GroupBox()
        Me.BttnRemoveAttach = New System.Windows.Forms.Button()
        Me.BttnAddAttach = New System.Windows.Forms.Button()
        Me.lvwAttachment = New System.Windows.Forms.ListView()
        Me.GBEmbedFonts = New System.Windows.Forms.GroupBox()
        Me.ChEmbedSubsetFontFile = New System.Windows.Forms.CheckBox()
        Me.ChEmbedFontFile = New System.Windows.Forms.CheckBox()
        Me.GBEncrypt = New System.Windows.Forms.GroupBox()
        Me.ChEncrypt = New System.Windows.Forms.CheckBox()
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
        Me.GBMain = New System.Windows.Forms.GroupBox()
        Me.lvwDoc = New prince_gui_2.UListView()
        Me.clearAll = New System.Windows.Forms.Button()
        Me.RemoveFile = New System.Windows.Forms.Button()
        Me.ChBoxMerge = New System.Windows.Forms.CheckBox()
        Me.lvwLog = New System.Windows.Forms.ListView()
        Me.ConvPrgrsBar = New System.Windows.Forms.ProgressBar()
        Me.comboDoctype = New System.Windows.Forms.ComboBox()
        Me.optionTabs.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GBJavaScript.SuspendLayout()
        Me.GBCss.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GBAttachment.SuspendLayout()
        Me.GBEmbedFonts.SuspendLayout()
        Me.GBEncrypt.SuspendLayout()
        Me.GBMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'addFile
        '
        Me.addFile.Location = New System.Drawing.Point(56, 16)
        Me.addFile.Name = "addFile"
        Me.addFile.Size = New System.Drawing.Size(80, 32)
        Me.addFile.TabIndex = 0
        Me.addFile.Text = "Add File"
        '
        'conv
        '
        Me.conv.Location = New System.Drawing.Point(520, 312)
        Me.conv.Name = "conv"
        Me.conv.Size = New System.Drawing.Size(120, 40)
        Me.conv.TabIndex = 2
        Me.conv.Text = "Convert"
        '
        'optionTabs
        '
        Me.optionTabs.Controls.Add(Me.TabPage1)
        Me.optionTabs.Controls.Add(Me.TabPage2)
        Me.optionTabs.Location = New System.Drawing.Point(720, 16)
        Me.optionTabs.Name = "optionTabs"
        Me.optionTabs.SelectedIndex = 0
        Me.optionTabs.Size = New System.Drawing.Size(480, 592)
        Me.optionTabs.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GBJavaScript)
        Me.TabPage1.Controls.Add(Me.GBCss)
        Me.TabPage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(472, 566)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "CSS & JavaScript"
        '
        'GBJavaScript
        '
        Me.GBJavaScript.Controls.Add(Me.addJS)
        Me.GBJavaScript.Controls.Add(Me.lvwJS)
        Me.GBJavaScript.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBJavaScript.Location = New System.Drawing.Point(24, 304)
        Me.GBJavaScript.Name = "GBJavaScript"
        Me.GBJavaScript.Size = New System.Drawing.Size(424, 248)
        Me.GBJavaScript.TabIndex = 3
        Me.GBJavaScript.TabStop = False
        Me.GBJavaScript.Text = "JavaScript (JS)"
        '
        'addJS
        '
        Me.addJS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addJS.Location = New System.Drawing.Point(24, 24)
        Me.addJS.Name = "addJS"
        Me.addJS.Size = New System.Drawing.Size(88, 23)
        Me.addJS.TabIndex = 1
        Me.addJS.Text = "Add JS"
        '
        'lvwJS
        '
        Me.lvwJS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvwJS.FullRowSelect = True
        Me.lvwJS.Location = New System.Drawing.Point(8, 56)
        Me.lvwJS.Name = "lvwJS"
        Me.lvwJS.Size = New System.Drawing.Size(360, 184)
        Me.lvwJS.TabIndex = 0
        Me.lvwJS.UseCompatibleStateImageBehavior = False
        Me.lvwJS.View = System.Windows.Forms.View.Details
        '
        'GBCss
        '
        Me.GBCss.Controls.Add(Me.addCss)
        Me.GBCss.Controls.Add(Me.lvwCSS)
        Me.GBCss.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBCss.Location = New System.Drawing.Point(24, 8)
        Me.GBCss.Name = "GBCss"
        Me.GBCss.Size = New System.Drawing.Size(424, 264)
        Me.GBCss.TabIndex = 2
        Me.GBCss.TabStop = False
        Me.GBCss.Text = "Cascading Style Sheet (CSS)"
        '
        'addCss
        '
        Me.addCss.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addCss.Location = New System.Drawing.Point(24, 24)
        Me.addCss.Name = "addCss"
        Me.addCss.Size = New System.Drawing.Size(88, 23)
        Me.addCss.TabIndex = 1
        Me.addCss.Text = "Add CSS"
        '
        'lvwCSS
        '
        Me.lvwCSS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvwCSS.FullRowSelect = True
        Me.lvwCSS.Location = New System.Drawing.Point(8, 56)
        Me.lvwCSS.Name = "lvwCSS"
        Me.lvwCSS.Size = New System.Drawing.Size(360, 200)
        Me.lvwCSS.TabIndex = 0
        Me.lvwCSS.UseCompatibleStateImageBehavior = False
        Me.lvwCSS.View = System.Windows.Forms.View.Details
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GBAttachment)
        Me.TabPage2.Controls.Add(Me.GBEmbedFonts)
        Me.TabPage2.Controls.Add(Me.GBEncrypt)
        Me.TabPage2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(472, 566)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "PDF Settings"
        '
        'GBAttachment
        '
        Me.GBAttachment.Controls.Add(Me.BttnRemoveAttach)
        Me.GBAttachment.Controls.Add(Me.BttnAddAttach)
        Me.GBAttachment.Controls.Add(Me.lvwAttachment)
        Me.GBAttachment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBAttachment.Location = New System.Drawing.Point(12, 388)
        Me.GBAttachment.Name = "GBAttachment"
        Me.GBAttachment.Size = New System.Drawing.Size(445, 165)
        Me.GBAttachment.TabIndex = 2
        Me.GBAttachment.TabStop = False
        Me.GBAttachment.Text = "Attachment"
        '
        'BttnRemoveAttach
        '
        Me.BttnRemoveAttach.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BttnRemoveAttach.Location = New System.Drawing.Point(376, 99)
        Me.BttnRemoveAttach.Name = "BttnRemoveAttach"
        Me.BttnRemoveAttach.Size = New System.Drawing.Size(63, 28)
        Me.BttnRemoveAttach.TabIndex = 2
        Me.BttnRemoveAttach.Text = "Remove"
        Me.BttnRemoveAttach.UseVisualStyleBackColor = True
        '
        'BttnAddAttach
        '
        Me.BttnAddAttach.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BttnAddAttach.Location = New System.Drawing.Point(376, 46)
        Me.BttnAddAttach.Name = "BttnAddAttach"
        Me.BttnAddAttach.Size = New System.Drawing.Size(63, 30)
        Me.BttnAddAttach.TabIndex = 1
        Me.BttnAddAttach.Text = "Add"
        Me.BttnAddAttach.UseVisualStyleBackColor = True
        '
        'lvwAttachment
        '
        Me.lvwAttachment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvwAttachment.FullRowSelect = True
        Me.lvwAttachment.Location = New System.Drawing.Point(18, 19)
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
        Me.GBEmbedFonts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBEmbedFonts.Location = New System.Drawing.Point(12, 308)
        Me.GBEmbedFonts.Name = "GBEmbedFonts"
        Me.GBEmbedFonts.Size = New System.Drawing.Size(445, 74)
        Me.GBEmbedFonts.TabIndex = 1
        Me.GBEmbedFonts.TabStop = False
        Me.GBEmbedFonts.Text = "Embed Fonts"
        '
        'ChEmbedSubsetFontFile
        '
        Me.ChEmbedSubsetFontFile.AutoSize = True
        Me.ChEmbedSubsetFontFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChEmbedSubsetFontFile.Location = New System.Drawing.Point(51, 47)
        Me.ChEmbedSubsetFontFile.Name = "ChEmbedSubsetFontFile"
        Me.ChEmbedSubsetFontFile.Size = New System.Drawing.Size(157, 19)
        Me.ChEmbedSubsetFontFile.TabIndex = 1
        Me.ChEmbedSubsetFontFile.Text = "Embed Subset Font File"
        Me.ChEmbedSubsetFontFile.UseVisualStyleBackColor = True
        '
        'ChEmbedFontFile
        '
        Me.ChEmbedFontFile.AutoSize = True
        Me.ChEmbedFontFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChEmbedFontFile.Location = New System.Drawing.Point(51, 22)
        Me.ChEmbedFontFile.Name = "ChEmbedFontFile"
        Me.ChEmbedFontFile.Size = New System.Drawing.Size(116, 19)
        Me.ChEmbedFontFile.TabIndex = 0
        Me.ChEmbedFontFile.Text = "Embed Font File"
        Me.ChEmbedFontFile.UseVisualStyleBackColor = True
        '
        'GBEncrypt
        '
        Me.GBEncrypt.Controls.Add(Me.ChEncrypt)
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
        Me.GBEncrypt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBEncrypt.Location = New System.Drawing.Point(12, 13)
        Me.GBEncrypt.Name = "GBEncrypt"
        Me.GBEncrypt.Size = New System.Drawing.Size(445, 289)
        Me.GBEncrypt.TabIndex = 0
        Me.GBEncrypt.TabStop = False
        Me.GBEncrypt.Text = "   "
        '
        'ChEncrypt
        '
        Me.ChEncrypt.AutoSize = True
        Me.ChEncrypt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChEncrypt.Location = New System.Drawing.Point(12, -2)
        Me.ChEncrypt.Name = "ChEncrypt"
        Me.ChEncrypt.Size = New System.Drawing.Size(116, 19)
        Me.ChEncrypt.TabIndex = 11
        Me.ChEncrypt.Text = "Encrypt PDF File"
        Me.ChEncrypt.UseVisualStyleBackColor = True
        '
        'textBoxOwnerPass
        '
        Me.textBoxOwnerPass.Enabled = False
        Me.textBoxOwnerPass.Location = New System.Drawing.Point(32, 241)
        Me.textBoxOwnerPass.Name = "textBoxOwnerPass"
        Me.textBoxOwnerPass.Size = New System.Drawing.Size(387, 20)
        Me.textBoxOwnerPass.TabIndex = 10
        '
        'textBoxUserPass
        '
        Me.textBoxUserPass.Enabled = False
        Me.textBoxUserPass.Location = New System.Drawing.Point(32, 190)
        Me.textBoxUserPass.Name = "textBoxUserPass"
        Me.textBoxUserPass.Size = New System.Drawing.Size(387, 20)
        Me.textBoxUserPass.TabIndex = 9
        '
        'LblOwnerPass
        '
        Me.LblOwnerPass.AutoSize = True
        Me.LblOwnerPass.Enabled = False
        Me.LblOwnerPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOwnerPass.Location = New System.Drawing.Point(29, 223)
        Me.LblOwnerPass.Name = "LblOwnerPass"
        Me.LblOwnerPass.Size = New System.Drawing.Size(100, 15)
        Me.LblOwnerPass.TabIndex = 8
        Me.LblOwnerPass.Text = "Owner Password"
        '
        'LblUserPass
        '
        Me.LblUserPass.AutoSize = True
        Me.LblUserPass.Enabled = False
        Me.LblUserPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUserPass.Location = New System.Drawing.Point(29, 171)
        Me.LblUserPass.Name = "LblUserPass"
        Me.LblUserPass.Size = New System.Drawing.Size(90, 15)
        Me.LblUserPass.TabIndex = 7
        Me.LblUserPass.Text = "User Password"
        '
        'RButton128
        '
        Me.RButton128.AutoSize = True
        Me.RButton128.Enabled = False
        Me.RButton128.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RButton128.Location = New System.Drawing.Point(255, 106)
        Me.RButton128.Name = "RButton128"
        Me.RButton128.Size = New System.Drawing.Size(69, 19)
        Me.RButton128.TabIndex = 6
        Me.RButton128.TabStop = True
        Me.RButton128.Text = "128 Bits"
        Me.RButton128.UseVisualStyleBackColor = True
        '
        'RButton40
        '
        Me.RButton40.AutoSize = True
        Me.RButton40.Enabled = False
        Me.RButton40.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RButton40.Location = New System.Drawing.Point(255, 81)
        Me.RButton40.Name = "RButton40"
        Me.RButton40.Size = New System.Drawing.Size(62, 19)
        Me.RButton40.TabIndex = 5
        Me.RButton40.TabStop = True
        Me.RButton40.Text = "40 Bits"
        Me.RButton40.UseVisualStyleBackColor = True
        '
        'lblKeyBits
        '
        Me.lblKeyBits.AutoSize = True
        Me.lblKeyBits.Enabled = False
        Me.lblKeyBits.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKeyBits.Location = New System.Drawing.Point(252, 55)
        Me.lblKeyBits.Name = "lblKeyBits"
        Me.lblKeyBits.Size = New System.Drawing.Size(50, 15)
        Me.lblKeyBits.TabIndex = 4
        Me.lblKeyBits.Text = "Key Bits"
        '
        'ChDisallowAnnotation
        '
        Me.ChDisallowAnnotation.AutoSize = True
        Me.ChDisallowAnnotation.Enabled = False
        Me.ChDisallowAnnotation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChDisallowAnnotation.Location = New System.Drawing.Point(51, 123)
        Me.ChDisallowAnnotation.Name = "ChDisallowAnnotation"
        Me.ChDisallowAnnotation.Size = New System.Drawing.Size(134, 19)
        Me.ChDisallowAnnotation.TabIndex = 3
        Me.ChDisallowAnnotation.Text = "Disallow Annotation"
        Me.ChDisallowAnnotation.UseVisualStyleBackColor = True
        '
        'ChDisallowCopyText
        '
        Me.ChDisallowCopyText.AutoSize = True
        Me.ChDisallowCopyText.Enabled = False
        Me.ChDisallowCopyText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChDisallowCopyText.Location = New System.Drawing.Point(51, 98)
        Me.ChDisallowCopyText.Name = "ChDisallowCopyText"
        Me.ChDisallowCopyText.Size = New System.Drawing.Size(146, 19)
        Me.ChDisallowCopyText.TabIndex = 2
        Me.ChDisallowCopyText.Text = "Disallow Copying Text"
        Me.ChDisallowCopyText.UseVisualStyleBackColor = True
        '
        'ChDisallowModify
        '
        Me.ChDisallowModify.AutoSize = True
        Me.ChDisallowModify.Enabled = False
        Me.ChDisallowModify.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChDisallowModify.Location = New System.Drawing.Point(51, 72)
        Me.ChDisallowModify.Name = "ChDisallowModify"
        Me.ChDisallowModify.Size = New System.Drawing.Size(143, 19)
        Me.ChDisallowModify.TabIndex = 1
        Me.ChDisallowModify.Text = "Disallow Modification"
        Me.ChDisallowModify.UseVisualStyleBackColor = True
        '
        'ChDisallowPrint
        '
        Me.ChDisallowPrint.AutoSize = True
        Me.ChDisallowPrint.Enabled = False
        Me.ChDisallowPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChDisallowPrint.Location = New System.Drawing.Point(51, 46)
        Me.ChDisallowPrint.Name = "ChDisallowPrint"
        Me.ChDisallowPrint.Size = New System.Drawing.Size(118, 19)
        Me.ChDisallowPrint.TabIndex = 0
        Me.ChDisallowPrint.Text = "Disallow Printing"
        Me.ChDisallowPrint.UseVisualStyleBackColor = True
        '
        'GBMain
        '
        Me.GBMain.Controls.Add(Me.lvwDoc)
        Me.GBMain.Controls.Add(Me.clearAll)
        Me.GBMain.Controls.Add(Me.RemoveFile)
        Me.GBMain.Controls.Add(Me.ChBoxMerge)
        Me.GBMain.Controls.Add(Me.lvwLog)
        Me.GBMain.Controls.Add(Me.addFile)
        Me.GBMain.Controls.Add(Me.conv)
        Me.GBMain.Location = New System.Drawing.Point(24, 12)
        Me.GBMain.Name = "GBMain"
        Me.GBMain.Size = New System.Drawing.Size(680, 570)
        Me.GBMain.TabIndex = 4
        Me.GBMain.TabStop = False
        '
        'lvwDoc
        '
        Me.lvwDoc.FullRowSelect = True
        Me.lvwDoc.Location = New System.Drawing.Point(16, 58)
        Me.lvwDoc.MultiSelect = False
        Me.lvwDoc.Name = "lvwDoc"
        Me.lvwDoc.Size = New System.Drawing.Size(584, 240)
        Me.lvwDoc.TabIndex = 8
        Me.lvwDoc.UseCompatibleStateImageBehavior = False
        Me.lvwDoc.View = System.Windows.Forms.View.Details
        '
        'clearAll
        '
        Me.clearAll.Location = New System.Drawing.Point(460, 16)
        Me.clearAll.Name = "clearAll"
        Me.clearAll.Size = New System.Drawing.Size(80, 32)
        Me.clearAll.TabIndex = 7
        Me.clearAll.Text = "Clear All"
        Me.clearAll.UseVisualStyleBackColor = True
        '
        'RemoveFile
        '
        Me.RemoveFile.Location = New System.Drawing.Point(269, 16)
        Me.RemoveFile.Name = "RemoveFile"
        Me.RemoveFile.Size = New System.Drawing.Size(80, 32)
        Me.RemoveFile.TabIndex = 6
        Me.RemoveFile.Text = "Remove"
        Me.RemoveFile.UseVisualStyleBackColor = True
        '
        'ChBoxMerge
        '
        Me.ChBoxMerge.Location = New System.Drawing.Point(24, 304)
        Me.ChBoxMerge.Name = "ChBoxMerge"
        Me.ChBoxMerge.Size = New System.Drawing.Size(240, 16)
        Me.ChBoxMerge.TabIndex = 4
        Me.ChBoxMerge.Text = "Merge all documents into a single PDF file"
        Me.ChBoxMerge.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lvwLog
        '
        Me.lvwLog.FullRowSelect = True
        Me.lvwLog.Location = New System.Drawing.Point(16, 376)
        Me.lvwLog.Name = "lvwLog"
        Me.lvwLog.Size = New System.Drawing.Size(640, 176)
        Me.lvwLog.TabIndex = 3
        Me.lvwLog.UseCompatibleStateImageBehavior = False
        Me.lvwLog.View = System.Windows.Forms.View.Details
        '
        'ConvPrgrsBar
        '
        Me.ConvPrgrsBar.Location = New System.Drawing.Point(24, 588)
        Me.ConvPrgrsBar.Name = "ConvPrgrsBar"
        Me.ConvPrgrsBar.Size = New System.Drawing.Size(680, 20)
        Me.ConvPrgrsBar.TabIndex = 5
        Me.ConvPrgrsBar.Visible = False
        '
        'comboDoctype
        '
        Me.comboDoctype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboDoctype.FormattingEnabled = True
        Me.comboDoctype.Location = New System.Drawing.Point(105, 614)
        Me.comboDoctype.Name = "comboDoctype"
        Me.comboDoctype.Size = New System.Drawing.Size(41, 21)
        Me.comboDoctype.TabIndex = 6
        Me.comboDoctype.Visible = False
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1240, 642)
        Me.Controls.Add(Me.comboDoctype)
        Me.Controls.Add(Me.ConvPrgrsBar)
        Me.Controls.Add(Me.GBMain)
        Me.Controls.Add(Me.optionTabs)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.optionTabs.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GBJavaScript.ResumeLayout(False)
        Me.GBCss.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.GBAttachment.ResumeLayout(False)
        Me.GBEmbedFonts.ResumeLayout(False)
        Me.GBEmbedFonts.PerformLayout()
        Me.GBEncrypt.ResumeLayout(False)
        Me.GBEncrypt.PerformLayout()
        Me.GBMain.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub addFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addFile.Click
        Dim pathAndFile As String
        Dim path As String
        Dim fileName As String
        Dim itm As ListViewItem

        'Open file dialog settings:
        openFD.InitialDirectory() = Application.StartupPath
        openFD.Filter() = "XML Files (*.xml, *.xhtml, *.xht, *.html, *.htm)|*.xml;*.xhtml;*.xht;*.html;*.htm|" + _
                        "XHTML files (*.xhtml, *.xht)|*.xhtml;*.xht|" + _
                        "HTML Files (*.html, *.htm)|*.html;*.htm|" + "All Files (*.*)|*.*"
        openFD.Title = "Select Document File(s)"
        openFD.Multiselect() = True

        If openFD.ShowDialog() = DialogResult.OK Then
            For Each pathAndFile In openFD.FileNames
                fileName = System.IO.Path.GetFileName(pathAndFile)
                path = System.IO.Path.GetDirectoryName(pathAndFile)

                itm = New ListViewItem

                itm.Text = fileName
                itm.SubItems.Add(path)
                itm.SubItems.Add("AUTO")
                itm.SubItems.Add("Unconverted")

                lvwDoc.Items.Add(itm)
            Next

        End If

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'lvwDoc.BackgroundImage.FromFile("C:\mywork\gui\prince-gui-1\background-1.bmp")
        'SetListViewBackgroundImage(lvwDoc, "C:\mywork\gui\prince-gui-1\background-1.bmp")


        lvwDoc.Columns.Add("Documents", 220, HorizontalAlignment.Left)
        lvwDoc.Columns.Add("Location", 220, HorizontalAlignment.Left)
        lvwDoc.Columns.Add("Type", 65, HorizontalAlignment.Left)
        lvwDoc.Columns.Add("Status", 75, HorizontalAlignment.Left)

        lvwCSS.Columns.Add("Stylesheets", 178, HorizontalAlignment.Left)
        lvwCSS.Columns.Add("Location", 178, HorizontalAlignment.Left)

        lvwJS.Columns.Add("JavaScripts", 178, HorizontalAlignment.Left)
        lvwJS.Columns.Add("Location", 178, HorizontalAlignment.Left)

        lvwLog.Columns.Add("Status", 70, HorizontalAlignment.Left)
        lvwLog.Columns.Add("Location", 260, HorizontalAlignment.Left)
        lvwLog.Columns.Add("Message", 306, HorizontalAlignment.Left)

        comboDoctype.Items.Add("AUTO")
        comboDoctype.Items.Add("XML")
        comboDoctype.Items.Add("HTML")


        lvwAttachment.Columns.Add("Documents", 174, HorizontalAlignment.Left)
        lvwAttachment.Columns.Add("Location", 174, HorizontalAlignment.Left)


    End Sub

    Private Sub conv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles conv.Click
        Dim docItem As ListViewItem
        Dim cssItem As ListViewItem
        Dim jsItem As ListViewItem
        Dim pathAndFileName As String
        Dim princePath As String

        princePath = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location)) + _
                      "\engine\bin\prince.exe"
        pr = New Prince(princePath)

        'add CSS to args
        For Each cssItem In lvwCSS.Items
            pr.AddStyleSheet(cssItem.SubItems(1).Text + "\" + cssItem.Text)
        Next

        'add JavaScripts to args
        For Each jsItem In lvwJS.Items
            pr.AddJavaScript(jsItem.SubItems(1).Text + "\" + jsItem.Text)
        Next

        'set javaScript to TRUE
        pr.SetJavaScript(True)

        'set PDF encrypt info
        setPDFEncryptInfo()

        ConvPrgrsBar.Visible = True
        For Each docItem In lvwDoc.Items
            pathAndFileName = docItem.SubItems(1).Text + "\" + docItem.Text
            If pr.Convert(pathAndFileName) Then
                docItem.SubItems(3).Text = "Converted"
            Else
                docItem.SubItems(3).Text = "Unsuccessful"
            End If
        Next
        ConvPrgrsBar.Visible = False


    End Sub

    Private Sub addCss_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addCss.Click
        Dim pathAndFile As String
        Dim path As String
        Dim fileName As String
        Dim itm As ListViewItem

        'open file dialog settings:
        openFD.InitialDirectory() = Application.StartupPath
        openFD.Filter() = "Stylesheet Files (*.css)|*.css|" + "All Files (*.*)|*.*"
        openFD.Title = "Select Stylesheet File(s)"
        openFD.Multiselect() = True

        If openFD.ShowDialog() = DialogResult.OK Then
            For Each pathAndFile In openFD.FileNames
                fileName = System.IO.Path.GetFileName(pathAndFile)
                path = System.IO.Path.GetDirectoryName(pathAndFile)

                itm = New ListViewItem

                itm.Text = fileName
                itm.SubItems.Add(path)
                lvwCSS.Items.Add(itm)
            Next

        End If

    End Sub

    Private Sub addJS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addJS.Click
        Dim pathAndFile As String
        Dim path As String
        Dim fileName As String
        Dim itm As ListViewItem

        'open file dialog settings:
        openFD.InitialDirectory() = Application.StartupPath
        openFD.Filter() = "JavaScript Files (*.js)|*.js|" + "All Files (*.*)|*.*"
        openFD.Title = "Select JavaScript File(s)"
        openFD.Multiselect() = True

        If openFD.ShowDialog() = DialogResult.OK Then
            For Each pathAndFile In openFD.FileNames
                fileName = System.IO.Path.GetFileName(pathAndFile)
                path = System.IO.Path.GetDirectoryName(pathAndFile)

                itm = New ListViewItem

                itm.Text = fileName
                itm.SubItems.Add(path)
                lvwJS.Items.Add(itm)
            Next

        End If
    End Sub

    'Private Sub comboDoctype_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comboDoctype.SelectedValueChanged
    '    docItem.SubItems(2).Text = comboDoctype.Text
    '    comboDoctype.Visible = False
    'End Sub

    Private Sub comboDoctype_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comboDoctype.Leave
        docItem.SubItems(2).Text = comboDoctype.Text
        comboDoctype.Visible = False
    End Sub

    Private Sub comboDoctype_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles comboDoctype.KeyPress
        'user presses ESC.
        Select Case (e.KeyChar)
            Case ChrW(CType(Keys.Escape, Integer))
                ' Reset the original text value, and then hide the ComboBox.
                comboDoctype.Text = docItem.SubItems(2).Text
                comboDoctype.Visible = False

            Case ChrW(CType(Keys.Enter, Integer))
                ' Hide the ComboBox.
                comboDoctype.Visible = False
        End Select
    End Sub

    Private Sub lvwDoc_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvwDoc.MouseUp
        ' Get the item on the row that is clicked.

        docItem = lvwDoc.GetItemAt(e.X, e.Y)

        If Not (docItem Is Nothing) Then
            docSubitem = docItem.GetSubItemAt(e.X, e.Y)
        End If

        ' Make sure that an item is clicked.
        If (Not (docItem Is Nothing)) And Not (docSubitem Is Nothing) Then
            If (docSubitem Is docItem.SubItems(2)) Then
                ' Get the bounds of the item that is clicked.
                Dim clickedItem As Rectangle = docItem.SubItems(2).Bounds

                ' Verify that the column is completely scrolled off to the left.
                If ((clickedItem.Left + lvwDoc.Columns(0).Width + lvwDoc.Columns(1).Width + lvwDoc.Columns(2).Width) < 0) Then
                    ' If the cell is out of view to the left, do nothing.
                    Return

                    ' Verify that the column is partially scrolled off to the left.
                ElseIf (clickedItem.Left < 0) Then
                    ' Determine if column extends beyond right side of ListView.
                    If ((clickedItem.Left + lvwDoc.Columns(0).Width + lvwDoc.Columns(1).Width + lvwDoc.Columns(2).Width) > lvwDoc.Width) Then
                        ' Set width of column to match width of ListView.
                        'clickedItem.Width = Me.MyListView1.Width
                        'changed: set width of column to match (width of ListView - width of column(0))
                        clickedItem.Width = lvwDoc.Width - lvwDoc.Columns(0).Width - lvwDoc.Columns(1).Width
                        'clickedItem.X = 0
                        'changed:
                    Else
                        ' Right side of cell is in view.
                        'clickedItem.Width = Me.MyListView1.Columns(1).Width + clickedItem.Left
                        clickedItem.Width = lvwDoc.Columns(2).Width
                    End If

                ElseIf (lvwDoc.Columns(2).Width > lvwDoc.Width) Then
                    clickedItem.Width = lvwDoc.Width

                Else
                    clickedItem.Width = lvwDoc.Columns(2).Width
                End If

                ' Adjust the top to account for the location of the lvwDoc and GBMain
                clickedItem.Y = clickedItem.Y + lvwDoc.Top + GBMain.Top
                clickedItem.X = clickedItem.X + lvwDoc.Left + GBMain.Left


                ' Assign calculated bounds to the ComboBox.
                comboDoctype.Bounds = clickedItem

                ' Set default text for ComboBox to match the item that is clicked.

                comboDoctype.Text = docItem.SubItems(2).Text

                ' Display the ComboBox, and make sure that it is on top with focus.
                comboDoctype.Visible = True
                comboDoctype.BringToFront()
                comboDoctype.Focus()
            End If
        End If
    End Sub


    Private Sub RemoveFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveFile.Click
        If lvwDoc.Items.Count > 0 Then
            For Each docItem As ListViewItem In lvwDoc.SelectedItems
                lvwDoc.Items.Remove(docItem)
            Next
        End If
        comboDoctype.Visible = False
    End Sub

    Private Sub clearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clearAll.Click
        If lvwDoc.Items.Count > 0 Then
            lvwDoc.Items.Clear()
        End If
    End Sub

    Private Sub comboDoctype_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comboDoctype.DropDownClosed
        docItem.SubItems(2).Text = comboDoctype.Text
        comboDoctype.Visible = False
        docItem.Selected = False
    End Sub

    Private Sub ChEncrypt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChEncrypt.Click
        If ChEncrypt.Checked Then
            ChDisallowPrint.Enabled = True
            ChDisallowModify.Enabled = True
            ChDisallowCopyText.Enabled = True
            ChDisallowAnnotation.Enabled = True
            lblKeyBits.Enabled = True
            RButton40.Enabled = True
            RButton128.Enabled = True
            LblUserPass.Enabled = True
            textBoxUserPass.Enabled = True
            LblOwnerPass.Enabled = True
            textBoxOwnerPass.Enabled = True
        Else
            ChDisallowPrint.Enabled = False
            ChDisallowModify.Enabled = False
            ChDisallowCopyText.Enabled = False
            ChDisallowAnnotation.Enabled = False
            lblKeyBits.Enabled = False
            RButton40.Enabled = False
            RButton128.Enabled = False
            LblUserPass.Enabled = False
            textBoxUserPass.Enabled = False
            LblOwnerPass.Enabled = False
            textBoxOwnerPass.Enabled = False
        End If
    End Sub

    Private Function GetUserPass() As String
        Dim userPass As String = ""

        userPass = textBoxUserPass.Text
        userPass = userPass.Replace(Chr(92) + Chr(92) + Chr(34), Chr(92) + Chr(92) + Chr(92) + Chr(34)).Replace(Chr(92) + Chr(34), Chr(92) + Chr(92) + Chr(34)).Replace(Chr(34), Chr(92) + Chr(34))

        Return userPass
    End Function

    Private Function getOwnerPass() As String
        Dim ownerPass As String = ""

        ownerPass = textBoxOwnerPass.Text
        ownerPass = ownerPass.Replace(Chr(92) + Chr(92) + Chr(34), Chr(92) + Chr(92) + Chr(92) + Chr(34)).Replace(Chr(92) + Chr(34), Chr(92) + Chr(92) + Chr(34)).Replace(Chr(34), Chr(92) + Chr(34))

        Return ownerPass
    End Function

    Private Sub setPDFEncryptInfo()
        Dim keyBits As Integer
        Dim userPassword As String
        Dim ownerPassword As String
        Dim disallowPrint As Boolean
        Dim disallowModify As Boolean
        Dim disallowCopy As Boolean
        Dim disallowAnnotate As Boolean

        If ChEncrypt.Checked Then
            If RButton40.Checked Then
                keyBits = 40
            ElseIf RButton128.Checked Then
                keyBits = 128
            Else
                keyBits = 40
            End If

            If ChDisallowPrint.Checked Then
                disallowPrint = True
            Else
                disallowPrint = False
            End If

            If ChDisallowModify.Checked Then
                disallowModify = True
            Else
                disallowModify = False
            End If

            If ChDisallowCopyText.Checked Then
                disallowCopy = True
            Else
                disallowCopy = False
            End If

            If ChDisallowAnnotation.Checked Then
                disallowAnnotate = True
            Else
                disallowAnnotate = False
            End If

            userPassword = GetUserPass()
            ownerPassword = getOwnerPass()

            pr.SetEncryptInfo(keyBits, userPassword, ownerPassword, disallowPrint, disallowModify, disallowCopy, disallowAnnotate)

        End If
    End Sub

    Private Function cmdline_arg_escape(ByVal arg As String) As String
        Dim pos As Integer
        Dim numSlashes As Integer
        Dim rightSubstring As String
        Dim leftSubstring As String
        Dim middleSubstring As String


        If arg.Length = 0 Then
            'return empty string
            Return arg
        Else

            'chr(34) is character double quote ( " ), chr(92) is character backslash ( \ )
            For pos = (arg.Length - 1) To 0 Step -1

                If arg(pos) = Chr(34) Then

                    'find number of backslashes preceding the character "
                    numSlashes = 0
                    Do While ((pos - 1 - numSlashes) >= 0)
                        If arg(pos - 1 - numSlashes) = Chr(92) Then
                            numSlashes += 1
                        Else
                            Exit Do
                        End If
                    Loop

                    rightSubstring = arg.Substring(pos + 1)
                    leftSubstring = arg.Substring(0, (pos - numSlashes))

                    middleSubstring = Chr(92)
                    For i As Integer = 0 To numSlashes Step 1
                        middleSubstring = middleSubstring + Chr(92) + Chr(92)
                    Next

                    Return
                End If
            Next

            'no double quote found, return string itself
            Return arg

        End If
    End Function
End Class
