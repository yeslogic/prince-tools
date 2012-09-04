Public Class Form2

    Private Sub bttnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnOk.Click
        Dim itm As ListViewItem

        If textboxUrl.Text <> "" Then
            itm = New ListViewItem

            itm.Text = textboxUrl.Text

            itm.SubItems.Add("")
            itm.SubItems.Add("AUTO")
            itm.SubItems.Add("Unconverted")

            Form1.lvwDoc.Items.Add(itm)

        End If

        Me.Close()
    End Sub

    Private Sub bttnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnCancel.Click
        Me.Close()
    End Sub
End Class