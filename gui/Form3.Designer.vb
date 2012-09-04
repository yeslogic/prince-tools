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
        CType(Me.pictureBoxAbout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pictureBoxAbout
        '
        Me.pictureBoxAbout.BackColor = System.Drawing.SystemColors.Control
        Me.pictureBoxAbout.BackgroundImage = CType(resources.GetObject("pictureBoxAbout.BackgroundImage"), System.Drawing.Image)
        Me.pictureBoxAbout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pictureBoxAbout.ImageLocation = ""
        Me.pictureBoxAbout.Location = New System.Drawing.Point(0, 0)
        Me.pictureBoxAbout.Name = "pictureBoxAbout"
        Me.pictureBoxAbout.Size = New System.Drawing.Size(224, 213)
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
        Me.textBoxAbout.Size = New System.Drawing.Size(222, 213)
        Me.textBoxAbout.TabIndex = 1
        Me.textBoxAbout.Text = resources.GetString("textBoxAbout.Text")
        '
        'bttnOk
        '
        Me.bttnOk.Location = New System.Drawing.Point(198, 240)
        Me.bttnOk.Name = "bttnOk"
        Me.bttnOk.Size = New System.Drawing.Size(75, 23)
        Me.bttnOk.TabIndex = 1
        Me.bttnOk.Text = "OK"
        Me.bttnOk.UseVisualStyleBackColor = True
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(452, 285)
        Me.Controls.Add(Me.bttnOk)
        Me.Controls.Add(Me.textBoxAbout)
        Me.Controls.Add(Me.pictureBoxAbout)
        Me.Name = "Form3"
        Me.Text = "About Prince"
        CType(Me.pictureBoxAbout, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pictureBoxAbout As System.Windows.Forms.PictureBox
    Friend WithEvents textBoxAbout As System.Windows.Forms.TextBox
    Friend WithEvents bttnOk As System.Windows.Forms.Button
End Class
