<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form4))
        Me.pictureBoxLicense = New System.Windows.Forms.PictureBox()
        Me.GBCurLic = New System.Windows.Forms.GroupBox()
        Me.lblCurrLicType = New System.Windows.Forms.Label()
        Me.textBoxCurrLic = New System.Windows.Forms.TextBox()
        Me.lblCurrLic = New System.Windows.Forms.Label()
        Me.GBNewLic = New System.Windows.Forms.GroupBox()
        Me.lblNewLicType = New System.Windows.Forms.Label()
        Me.bttnAcceptLic = New System.Windows.Forms.Button()
        Me.bttnOpenLic = New System.Windows.Forms.Button()
        Me.textBoxNewLic = New System.Windows.Forms.TextBox()
        Me.lblNewLic = New System.Windows.Forms.Label()
        Me.bttnOk = New System.Windows.Forms.Button()
        CType(Me.pictureBoxLicense, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBCurLic.SuspendLayout()
        Me.GBNewLic.SuspendLayout()
        Me.SuspendLayout()
        '
        'pictureBoxLicense
        '
        Me.pictureBoxLicense.BackgroundImage = CType(resources.GetObject("pictureBoxLicense.BackgroundImage"), System.Drawing.Image)
        Me.pictureBoxLicense.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pictureBoxLicense.Location = New System.Drawing.Point(90, 2)
        Me.pictureBoxLicense.Name = "pictureBoxLicense"
        Me.pictureBoxLicense.Size = New System.Drawing.Size(242, 120)
        Me.pictureBoxLicense.TabIndex = 0
        Me.pictureBoxLicense.TabStop = False
        '
        'GBCurLic
        '
        Me.GBCurLic.Controls.Add(Me.lblCurrLicType)
        Me.GBCurLic.Controls.Add(Me.textBoxCurrLic)
        Me.GBCurLic.Controls.Add(Me.lblCurrLic)
        Me.GBCurLic.Location = New System.Drawing.Point(22, 132)
        Me.GBCurLic.Name = "GBCurLic"
        Me.GBCurLic.Size = New System.Drawing.Size(391, 144)
        Me.GBCurLic.TabIndex = 1
        Me.GBCurLic.TabStop = False
        '
        'lblCurrLicType
        '
        Me.lblCurrLicType.AutoSize = True
        Me.lblCurrLicType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrLicType.Location = New System.Drawing.Point(50, 38)
        Me.lblCurrLicType.Name = "lblCurrLicType"
        Me.lblCurrLicType.Size = New System.Drawing.Size(0, 16)
        Me.lblCurrLicType.TabIndex = 2
        '
        'textBoxCurrLic
        '
        Me.textBoxCurrLic.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.textBoxCurrLic.Location = New System.Drawing.Point(53, 60)
        Me.textBoxCurrLic.Multiline = True
        Me.textBoxCurrLic.Name = "textBoxCurrLic"
        Me.textBoxCurrLic.ReadOnly = True
        Me.textBoxCurrLic.Size = New System.Drawing.Size(307, 78)
        Me.textBoxCurrLic.TabIndex = 1
        '
        'lblCurrLic
        '
        Me.lblCurrLic.AutoSize = True
        Me.lblCurrLic.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrLic.Location = New System.Drawing.Point(30, 16)
        Me.lblCurrLic.Name = "lblCurrLic"
        Me.lblCurrLic.Size = New System.Drawing.Size(100, 16)
        Me.lblCurrLic.TabIndex = 0
        Me.lblCurrLic.Text = "Current License"
        '
        'GBNewLic
        '
        Me.GBNewLic.Controls.Add(Me.lblNewLicType)
        Me.GBNewLic.Controls.Add(Me.bttnAcceptLic)
        Me.GBNewLic.Controls.Add(Me.bttnOpenLic)
        Me.GBNewLic.Controls.Add(Me.textBoxNewLic)
        Me.GBNewLic.Controls.Add(Me.lblNewLic)
        Me.GBNewLic.Location = New System.Drawing.Point(22, 276)
        Me.GBNewLic.Name = "GBNewLic"
        Me.GBNewLic.Size = New System.Drawing.Size(391, 190)
        Me.GBNewLic.TabIndex = 2
        Me.GBNewLic.TabStop = False
        '
        'lblNewLicType
        '
        Me.lblNewLicType.AutoSize = True
        Me.lblNewLicType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewLicType.Location = New System.Drawing.Point(50, 38)
        Me.lblNewLicType.Name = "lblNewLicType"
        Me.lblNewLicType.Size = New System.Drawing.Size(0, 16)
        Me.lblNewLicType.TabIndex = 4
        '
        'bttnAcceptLic
        '
        Me.bttnAcceptLic.Enabled = False
        Me.bttnAcceptLic.Location = New System.Drawing.Point(216, 148)
        Me.bttnAcceptLic.Name = "bttnAcceptLic"
        Me.bttnAcceptLic.Size = New System.Drawing.Size(75, 32)
        Me.bttnAcceptLic.TabIndex = 3
        Me.bttnAcceptLic.Text = "Accept"
        Me.bttnAcceptLic.UseVisualStyleBackColor = True
        '
        'bttnOpenLic
        '
        Me.bttnOpenLic.Location = New System.Drawing.Point(101, 148)
        Me.bttnOpenLic.Name = "bttnOpenLic"
        Me.bttnOpenLic.Size = New System.Drawing.Size(75, 32)
        Me.bttnOpenLic.TabIndex = 2
        Me.bttnOpenLic.Text = "Open"
        Me.bttnOpenLic.UseVisualStyleBackColor = True
        '
        'textBoxNewLic
        '
        Me.textBoxNewLic.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.textBoxNewLic.Location = New System.Drawing.Point(53, 60)
        Me.textBoxNewLic.Multiline = True
        Me.textBoxNewLic.Name = "textBoxNewLic"
        Me.textBoxNewLic.ReadOnly = True
        Me.textBoxNewLic.Size = New System.Drawing.Size(307, 78)
        Me.textBoxNewLic.TabIndex = 1
        '
        'lblNewLic
        '
        Me.lblNewLic.AutoSize = True
        Me.lblNewLic.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewLic.Location = New System.Drawing.Point(30, 16)
        Me.lblNewLic.Name = "lblNewLic"
        Me.lblNewLic.Size = New System.Drawing.Size(85, 16)
        Me.lblNewLic.TabIndex = 0
        Me.lblNewLic.Text = "New License"
        '
        'bttnOk
        '
        Me.bttnOk.Location = New System.Drawing.Point(165, 485)
        Me.bttnOk.Name = "bttnOk"
        Me.bttnOk.Size = New System.Drawing.Size(103, 31)
        Me.bttnOk.TabIndex = 1
        Me.bttnOk.Text = "OK"
        Me.bttnOk.UseVisualStyleBackColor = True
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(435, 528)
        Me.Controls.Add(Me.bttnOk)
        Me.Controls.Add(Me.GBNewLic)
        Me.Controls.Add(Me.GBCurLic)
        Me.Controls.Add(Me.pictureBoxLicense)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form4"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Prince License"
        CType(Me.pictureBoxLicense, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBCurLic.ResumeLayout(False)
        Me.GBCurLic.PerformLayout()
        Me.GBNewLic.ResumeLayout(False)
        Me.GBNewLic.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pictureBoxLicense As System.Windows.Forms.PictureBox
    Friend WithEvents GBCurLic As System.Windows.Forms.GroupBox
    Friend WithEvents textBoxCurrLic As System.Windows.Forms.TextBox
    Friend WithEvents lblCurrLic As System.Windows.Forms.Label
    Friend WithEvents GBNewLic As System.Windows.Forms.GroupBox
    Friend WithEvents bttnAcceptLic As System.Windows.Forms.Button
    Friend WithEvents bttnOpenLic As System.Windows.Forms.Button
    Friend WithEvents textBoxNewLic As System.Windows.Forms.TextBox
    Friend WithEvents lblNewLic As System.Windows.Forms.Label
    Friend WithEvents bttnOk As System.Windows.Forms.Button
    Friend WithEvents lblCurrLicType As System.Windows.Forms.Label
    Friend WithEvents lblNewLicType As System.Windows.Forms.Label
End Class
