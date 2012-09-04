<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.lblUrl = New System.Windows.Forms.Label()
        Me.textboxUrl = New System.Windows.Forms.TextBox()
        Me.bttnOk = New System.Windows.Forms.Button()
        Me.bttnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblUrl
        '
        Me.lblUrl.AutoSize = True
        Me.lblUrl.Location = New System.Drawing.Point(28, 60)
        Me.lblUrl.Name = "lblUrl"
        Me.lblUrl.Size = New System.Drawing.Size(29, 13)
        Me.lblUrl.TabIndex = 0
        Me.lblUrl.Text = "URL"
        '
        'textboxUrl
        '
        Me.textboxUrl.Location = New System.Drawing.Point(63, 57)
        Me.textboxUrl.Name = "textboxUrl"
        Me.textboxUrl.Size = New System.Drawing.Size(316, 20)
        Me.textboxUrl.TabIndex = 1
        '
        'bttnOk
        '
        Me.bttnOk.Location = New System.Drawing.Point(175, 147)
        Me.bttnOk.Name = "bttnOk"
        Me.bttnOk.Size = New System.Drawing.Size(75, 23)
        Me.bttnOk.TabIndex = 2
        Me.bttnOk.Text = "OK"
        Me.bttnOk.UseVisualStyleBackColor = True
        '
        'bttnCancel
        '
        Me.bttnCancel.Location = New System.Drawing.Point(272, 147)
        Me.bttnCancel.Name = "bttnCancel"
        Me.bttnCancel.Size = New System.Drawing.Size(75, 23)
        Me.bttnCancel.TabIndex = 3
        Me.bttnCancel.Text = "Cancel"
        Me.bttnCancel.UseVisualStyleBackColor = True
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(409, 197)
        Me.Controls.Add(Me.bttnCancel)
        Me.Controls.Add(Me.bttnOk)
        Me.Controls.Add(Me.textboxUrl)
        Me.Controls.Add(Me.lblUrl)
        Me.Name = "Form2"
        Me.Text = "Enter URL"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblUrl As System.Windows.Forms.Label
    Friend WithEvents textboxUrl As System.Windows.Forms.TextBox
    Friend WithEvents bttnOk As System.Windows.Forms.Button
    Friend WithEvents bttnCancel As System.Windows.Forms.Button
End Class
