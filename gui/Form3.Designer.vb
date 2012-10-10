<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form3))
        Me.pictureBoxAbout = New System.Windows.Forms.PictureBox()
        Me.textBoxAbout = New System.Windows.Forms.TextBox()
        Me.bttnOk = New System.Windows.Forms.Button()
        Me.linkLbl1 = New System.Windows.Forms.LinkLabel()
        CType(Me.pictureBoxAbout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pictureBoxAbout
        '
        Me.pictureBoxAbout.BackColor = System.Drawing.SystemColors.Control
        Me.pictureBoxAbout.BackgroundImage = CType(resources.GetObject("pictureBoxAbout.BackgroundImage"), System.Drawing.Image)
        Me.pictureBoxAbout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pictureBoxAbout.ImageLocation = ""
        Me.pictureBoxAbout.Location = New System.Drawing.Point(24, 22)
        Me.pictureBoxAbout.Name = "pictureBoxAbout"
        Me.pictureBoxAbout.Size = New System.Drawing.Size(166, 158)
        Me.pictureBoxAbout.TabIndex = 0
        Me.pictureBoxAbout.TabStop = False
        '
        'textBoxAbout
        '
        Me.textBoxAbout.BackColor = System.Drawing.SystemColors.Control
        Me.textBoxAbout.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.textBoxAbout.Location = New System.Drawing.Point(234, 0)
        Me.textBoxAbout.Multiline = True
        Me.textBoxAbout.Name = "textBoxAbout"
        Me.textBoxAbout.ReadOnly = True
        Me.textBoxAbout.Size = New System.Drawing.Size(222, 154)
        Me.textBoxAbout.TabIndex = 1
        '
        'bttnOk
        '
        Me.bttnOk.Location = New System.Drawing.Point(191, 200)
        Me.bttnOk.Name = "bttnOk"
        Me.bttnOk.Size = New System.Drawing.Size(75, 23)
        Me.bttnOk.TabIndex = 1
        Me.bttnOk.Text = "OK"
        Me.bttnOk.UseVisualStyleBackColor = True
        '
        'linkLbl1
        '
        Me.linkLbl1.AutoSize = True
        Me.linkLbl1.Location = New System.Drawing.Point(230, 160)
        Me.linkLbl1.Name = "linkLbl1"
        Me.linkLbl1.Size = New System.Drawing.Size(132, 13)
        Me.linkLbl1.TabIndex = 2
        Me.linkLbl1.TabStop = True
        Me.linkLbl1.Text = "http://www.princexml.com"
        '
        'Form3
        '
        Me.AcceptButton = Me.bttnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(452, 256)
        Me.Controls.Add(Me.linkLbl1)
        Me.Controls.Add(Me.bttnOk)
        Me.Controls.Add(Me.textBoxAbout)
        Me.Controls.Add(Me.pictureBoxAbout)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(468, 294)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(468, 294)
        Me.Name = "Form3"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "About Prince"
        CType(Me.pictureBoxAbout, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pictureBoxAbout As System.Windows.Forms.PictureBox
    Friend WithEvents textBoxAbout As System.Windows.Forms.TextBox
    Friend WithEvents bttnOk As System.Windows.Forms.Button
    Friend WithEvents linkLbl1 As System.Windows.Forms.LinkLabel
End Class
