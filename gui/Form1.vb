Public Class Form1

    Private pr As Prince
    Private docItem As ListViewItem
    Private docSubitem As ListViewItem.ListViewSubItem

    Private Sub addFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addFile.Click
        Dim pathAndFile As String
        Dim path As String
        Dim fileName As String
        Dim itm As ListViewItem

        'Open file dialog settings:
        openFD.InitialDirectory() = Application.StartupPath
        openFD.FileName = String.Empty
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

            If lvwDoc.Items.Count > 1 Then
                ChBoxMerge.Enabled = True
            End If

        End If

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'lvwDoc.BackgroundImage.FromFile("C:\mywork\gui\prince-gui-1\background-1.bmp")
        'SetListViewBackgroundImage(lvwDoc, "C:\mywork\gui\prince-gui-1\background-1.bmp")
        'Dim lvwDocBkImg As Bitmap = New Bitmap("C:\mywork\gui\prince-gui-2-bk-img\PrinceLogoGUI-tranparent.png")

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

        'lvwDoc.WatermarkAlpha = 200
        'lvwDoc.WatermarkImage = lvwDocBkImg

    End Sub

    Private Sub conv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles conv.Click
        Dim docItem As ListViewItem
        Dim cssItem As ListViewItem
        Dim jsItem As ListViewItem
        Dim pathAndFileName As String
        Dim outputPath As String
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
        If ChBoxMerge.Checked Then

            If lvwDoc.Items.Count > 0 Then
                outputPath = textBoxSave.Text

                Dim multipleDocs(lvwDoc.Items.Count - 1) As String

                For i As Integer = 0 To (lvwDoc.Items.Count - 1) Step 1
                    docItem = lvwDoc.Items(i)
                    multipleDocs(i) = docItem.SubItems(1).Text + "\" + docItem.Text + " "
                Next

                If pr.ConvertMultiple(multipleDocs, outputPath) Then
                    For Each docItem In lvwDoc.Items
                        docItem.SubItems(3).Text = "Converted"
                    Next
                Else
                    For Each docItem In lvwDoc.Items
                        docItem.SubItems(3).Text = "Unsuccessful"
                    Next
                End If
            End If
        Else
            For Each docItem In lvwDoc.Items
                pathAndFileName = docItem.SubItems(1).Text + "\" + docItem.Text
                If pr.Convert(pathAndFileName) Then
                    docItem.SubItems(3).Text = "Converted"
                Else
                    docItem.SubItems(3).Text = "Unsuccessful"
                End If
            Next
        End If
        ConvPrgrsBar.Visible = False


    End Sub

    Private Sub addCss_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addCss.Click
        Dim pathAndFile As String
        Dim path As String
        Dim fileName As String
        Dim itm As ListViewItem

        'open file dialog settings:
        openFD.InitialDirectory() = Application.StartupPath
        openFD.FileName = String.Empty
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
        openFD.FileName = String.Empty
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


    Private Sub RemoveFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles removeFile.Click
        If lvwDoc.Items.Count > 0 Then
            For Each docItem As ListViewItem In lvwDoc.SelectedItems
                lvwDoc.Items.Remove(docItem)
            Next
        End If

        lvwDoc.Refresh()
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

    Private Sub bttnOpenFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnOpenFolder.Click

        'Folder browser dialog settings:
        folderBD.RootFolder = Environment.SpecialFolder.MyComputer
        folderBD.Description = "Select Output Folder"

        If folderBD.ShowDialog = Windows.Forms.DialogResult.OK Then
            If textBoxSave.Text = (folderBD.SelectedPath + "\output.pdf") Then

            Else
                textBoxSave.Text = folderBD.SelectedPath + "\output.pdf"
            End If
        End If
    End Sub

    Private Sub ChBoxMerge_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChBoxMerge.CheckedChanged
        If ChBoxMerge.Checked Then
            lblSaveOutput.Enabled = True
            bttnOpenFolder.Enabled = True
            textBoxSave.Enabled = True
            textBoxSave.BackColor = Color.White
            If lvwDoc.Items.Count > 0 Then
                textBoxSave.Text = lvwDoc.Items(0).SubItems(1).Text + "\output.pdf"
            Else
                textBoxSave.Text = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\output.pdf"
            End If

        Else
            lblSaveOutput.Enabled = False
            bttnOpenFolder.Enabled = False
            textBoxSave.Text = ""
            textBoxSave.Enabled = False
            textBoxSave.BackColor = System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.Control)
        End If
    End Sub
    Private Sub addURL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addURL.Click
        'Form2.Show()
    End Sub

    Private Function GetUserPass() As String
        Dim userPass As String = ""

        userPass = textBoxUserPass.Text
        'userPass = cmdline_arg_escape_1(userPass)
        userPass = cmdline_arg_escape_2(cmdline_arg_escape_1(userPass))

        Return userPass
    End Function

    Private Function getOwnerPass() As String
        Dim ownerPass As String = ""

        ownerPass = textBoxOwnerPass.Text
        'ownerPass = cmdline_arg_escape_1(ownerPass)
        ownerPass = cmdline_arg_escape_2(cmdline_arg_escape_1(ownerPass))

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
    Private Function cmdline_arg_escape_1(ByVal arg As String) As String
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

                If arg.Chars(pos) = Chr(34) Then
                    'if there is a double quote in the arg string
                    'find number of backslashes preceding the double quote ( " )
                    numSlashes = 0
                    Do While ((pos - 1 - numSlashes) >= 0)
                        If arg.Chars(pos - 1 - numSlashes) = Chr(92) Then
                            numSlashes += 1
                        Else
                            Exit Do
                        End If
                    Loop

                    rightSubstring = arg.Substring(pos + 1)
                    leftSubstring = arg.Substring(0, (pos - numSlashes))

                    middleSubstring = Chr(92)
                    For i As Integer = 1 To numSlashes Step 1
                        middleSubstring = middleSubstring + Chr(92) + Chr(92)
                    Next

                    middleSubstring = middleSubstring + Chr(34)

                    Return cmdline_arg_escape_1(leftSubstring) + middleSubstring + rightSubstring

                End If
            Next

            'no double quote found, return string itself
            Return arg

        End If
    End Function
    Private Function cmdline_arg_escape_2(ByVal arg As String) As String
        Dim pos As Integer
        Dim numEndingSlashes As Integer

        numEndingSlashes = 0
        For pos = (arg.Length - 1) To 0 Step -1
            If arg.Chars(pos) = Chr(92) Then
                numEndingSlashes += 1
            Else
                Exit For
            End If
        Next

        For i As Integer = 1 To numEndingSlashes Step 1
            arg = arg + Chr(92)
        Next

        Return arg

    End Function

End Class
