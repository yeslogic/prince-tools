Imports System.Threading

Delegate Sub SetItemToConvDelegate(ByVal indx As Integer)
Delegate Sub SaveOutputPathDelegate(ByVal indx As Integer, ByVal outputPath As String)

Public Class Form1
    Private pr As Prince
    Private docItem As ListViewItem
    Private docSubitem As ListViewItem.ListViewSubItem
    Private saveFdInitDir As String
    Private openFdInitDocDir As String
    Private openFdInitCssDir As String
    Private openFdInitJsDir As String
    Private openfdInitAttachDir As String
    Private folderBdInitDir As String
    Private lastConvBttnState As buttonStates

    Private Enum buttonStates
        normal = 0
        hover = 1
        pressed = 2
    End Enum

    Private Sub addFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addFile.Click
        Dim pathAndFile As String
        Dim path As String
        Dim fileName As String
        Dim itm As ListViewItem

        'Open file dialog settings:
        openFD.InitialDirectory() = openFdInitDocDir
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

                'remember path
                openFdInitDocDir = path

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

        saveFdInitDir = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        openFdInitDocDir = Application.StartupPath
        openFdInitCssDir = Application.StartupPath
        openFdInitJsDir = Application.StartupPath
        openfdInitAttachDir = Application.StartupPath
        folderBdInitDir = Environment.SpecialFolder.MyComputer

        lastConvBttnState = buttonStates.normal

    End Sub

    Private Sub conv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles conv.Click
        Dim docItem As ListViewItem
        Dim cssItem As ListViewItem
        Dim jsItem As ListViewItem
        Dim outputPath As String
        Dim princePath As String

        princePath = Chr(34) + System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location)) + _
                      "\engine\bin\prince.exe" + Chr(34)

        pr = New Prince(princePath)

        'add CSS to args
        For Each cssItem In lvwCSS.Items
            pr.AddStyleSheet(cssItem.SubItems(1).Text + "\" + cssItem.Text)
        Next

        'add JavaScripts to args
        For Each jsItem In lvwJS.Items
            pr.AddJavaScript(jsItem.SubItems(1).Text + "\" + jsItem.Text)
        Next

        'add file attachements
        For Each attachItem In lvwAttachment.Items
            pr.AddFileAttachment(attachItem.Subitems(1).text + "\" + attachItem.text)
        Next

        'set javaScript to TRUE
        pr.SetJavaScript(True)

        'set PDF encrypt info
        setPDFEncryptInfo()

        'embed fonts or embed subset fonts
        If ChEmbedFontFile.Checked Then
            pr.SetEmbedFonts(True)
        Else
            pr.SetEmbedFonts(False)
        End If

        If ChEmbedSubsetFontFile.Checked Then
            pr.SetEmbedSubsetFonts(True)
        Else
            pr.SetEmbedSubsetFonts(False)
        End If

        'set mMainForm to Form1
        pr.SetMainForm(Me)

        lvwLog.Items.Clear()
        If ChBoxMerge.Checked Then

            If lvwDoc.Items.Count > 0 Then
                outputPath = textBoxSave.Text

                Dim multipleDocs(lvwDoc.Items.Count - 1) As String

                For i As Integer = 0 To (lvwDoc.Items.Count - 1) Step 1
                    docItem = lvwDoc.Items(i)
                    If docItem.SubItems(1).Text <> "" Then
                        multipleDocs(i) = docItem.SubItems(1).Text + "\" + docItem.Text + " "
                    Else
                        multipleDocs(i) = docItem.Text + " "
                    End If
                Next

                pr.SetConvertMultiple(True)
                pr.ConvertMultiple(multipleDocs, outputPath)

            End If
        Else
            If lvwDoc.Items.Count > 0 Then
                Dim docArray(lvwDoc.Items.Count - 1) As LvwDocItem
                Dim doc As String
                Dim saveTo As String
                Dim docType As String
                Dim thrdConv As Thread

                For i As Integer = 0 To (lvwDoc.Items.Count - 1) Step 1
                    docItem = lvwDoc.Items(i)
                    docType = docItem.SubItems(2).Text

                    If docItem.SubItems(1).Text <> "" Then
                        doc = docItem.SubItems(1).Text + "\" + docItem.Text
                        saveTo = ""
                    Else
                        doc = docItem.Text
                        If docItem.Tag IsNot Nothing Then
                            saveTo = docItem.Tag
                        Else
                            saveTo = "URL"
                        End If
                    End If

                    docArray(i) = New LvwDocItem(doc, saveTo, docType)
                Next


                thrdConv = New Thread(AddressOf ConvertDocs)
                thrdConv.SetApartmentState(ApartmentState.STA)
                thrdConv.IsBackground = True
                thrdConv.Start(docArray)

            End If

        End If
    End Sub
    Private Sub ConvertDocs(ByVal docArray() As LvwDocItem)
        Dim arrayItem As LvwDocItem
        Dim outputPath As String

        For i As Integer = 0 To (docArray.Count - 1) Step 1
            arrayItem = docArray(i)
            SetItemToConv(i)
            pr.SetInputType(arrayItem.docType)

            If arrayItem.outputPath = "" Then   'document is a file
                pr.Convert(arrayItem.doc)
            ElseIf arrayItem.outputPath = "URL" Then    'document is a URL, need to get output path
                outputPath = GetOutputPath()
                If outputPath <> "" Then
                    pr.Convert(arrayItem.doc, outputPath)
                    SaveOutputPath(i, outputPath)
                End If
            Else                                        'document is a URL with output path already provided
                pr.Convert(arrayItem.doc, arrayItem.outputPath)
            End If

        Next
    End Sub

    Private Sub SetItemToConv(ByVal indx As Integer)
        If Me.InvokeRequired Then
            Dim setItemToConvDel As New SetItemToConvDelegate(AddressOf SetItemToConv)
            Me.Invoke(setItemToConvDel, New Object() {indx})
        Else
            pr.SetItemToConvert(Me.lvwDoc.Items(indx))
        End If
    End Sub

    'ensure indx is within range before calling this function
    Private Sub SaveOutputPath(ByVal indx As Integer, ByVal outputPath As String)
        If Me.InvokeRequired Then
            Dim saveOutputPathDel As New SaveOutputPathDelegate(AddressOf SaveOutputPath)
            Me.Invoke(saveOutputPathDel, New Object() {indx, outputPath})
        Else
            Me.lvwDoc.Items(indx).Tag = outputPath
        End If
    End Sub

    Private Function GetOutputPath() As String
        'SaveFileDialog setting
        SaveFD.InitialDirectory = saveFdInitDir
        SaveFD.FileName = "output"
        SaveFD.Filter = "PDF Files (*.pdf)|*.pdf|" + "All Files (*.*)|*.*"

        If SaveFD.ShowDialog() = DialogResult.OK Then
            saveFdInitDir = System.IO.Path.GetDirectoryName(SaveFD.FileName)
            Return SaveFD.FileName
        Else
            Return ""
        End If

    End Function

    Private Sub addCss_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addCss.Click
        Dim pathAndFile As String
        Dim path As String
        Dim fileName As String
        Dim itm As ListViewItem

        'open file dialog settings:
        openFD.InitialDirectory() = openFdInitCssDir
        openFD.FileName = String.Empty
        openFD.Filter() = "Stylesheet Files (*.css)|*.css|" + "All Files (*.*)|*.*"
        openFD.Title = "Select Stylesheet File(s)"
        openFD.Multiselect() = True

        If openFD.ShowDialog() = DialogResult.OK Then
            For Each pathAndFile In openFD.FileNames
                fileName = System.IO.Path.GetFileName(pathAndFile)
                path = System.IO.Path.GetDirectoryName(pathAndFile)

                'remember path
                openFdInitCssDir = path

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
        openFD.InitialDirectory() = openFdInitJsDir
        openFD.FileName = String.Empty
        openFD.Filter() = "JavaScript Files (*.js)|*.js|" + "All Files (*.*)|*.*"
        openFD.Title = "Select JavaScript File(s)"
        openFD.Multiselect() = True

        If openFD.ShowDialog() = DialogResult.OK Then
            For Each pathAndFile In openFD.FileNames
                fileName = System.IO.Path.GetFileName(pathAndFile)
                path = System.IO.Path.GetDirectoryName(pathAndFile)

                'remember path
                openFdInitJsDir = path

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

        If lvwDoc.Items.Count < 2 Then
            ChBoxMerge.Checked = False
            ChBoxMerge.Enabled = False
        End If

    End Sub

    Private Sub clearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clearAll.Click
        If lvwDoc.Items.Count > 0 Then
            lvwDoc.Items.Clear()
        End If

        If (lvwLog.Items.Count > 0) Then
            lvwLog.Items.Clear()
        End If

        ChBoxMerge.Checked = False
        ChBoxMerge.Enabled = False
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
        folderBD.RootFolder = folderBdInitDir
        folderBD.Description = "Select Output Folder"

        If folderBD.ShowDialog = Windows.Forms.DialogResult.OK Then
            If textBoxSave.Text = (folderBD.SelectedPath + "\output.pdf") Then

            Else
                textBoxSave.Text = folderBD.SelectedPath + "\output.pdf"
            End If

            'remember output folder for folder browser
            folderBdInitDir = folderBD.SelectedPath
        End If
    End Sub

    Private Sub ChBoxMerge_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChBoxMerge.CheckedChanged
        If ChBoxMerge.Checked Then
            lblSaveOutput.Enabled = True
            bttnOpenFolder.Enabled = True
            textBoxSave.Enabled = True
            textBoxSave.BackColor = Color.White
            If lvwDoc.Items.Count > 0 Then
                If lvwDoc.Items(0).SubItems(1).Text <> "" Then
                    textBoxSave.Text = lvwDoc.Items(0).SubItems(1).Text + "\output.pdf"
                Else
                    textBoxSave.Text = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\output.pdf"
                End If
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
        Form2.Show()
    End Sub

    Private Function GetUserPass() As String
        Dim userPass As String = ""

        userPass = textBoxUserPass.Text
        userPass = cmdline_arg_escape_2(cmdline_arg_escape_1(userPass))

        Return userPass
    End Function

    Private Function getOwnerPass() As String
        Dim ownerPass As String = ""

        ownerPass = textBoxOwnerPass.Text
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

    Private Sub Form1_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Dim yStretch As Integer = 0
        Dim xStretch As Integer = 0

        If Me.Height > 680 Then
            yStretch = Me.Height - 680
        End If
        If Me.Width > 1256 Then
            xStretch = Me.Width - 1256
        End If

        GBMain.Width = 680 + xStretch
        GBMain.Height = 571 + yStretch

        lvwDoc.Width = 584 + xStretch
        lvwDoc.Height = 198 + yStretch / 2

        lvwLog.Location = New Point(16, (376 + yStretch / 2))
        lvwLog.Width = 640 + xStretch
        lvwLog.Height = 176 + yStretch / 2

        ChBoxMerge.Location = New Point(24, (304 + yStretch / 2))
        lblSaveOutput.Location = New Point(21, (334 + yStretch / 2))
        textBoxSave.Location = New Point(110, (332 + yStretch / 2))
        bttnOpenFolder.Location = New Point(396, (330 + yStretch / 2))

        bttnDocUp.Location = New Point((615 + xStretch), (149 + yStretch / 4))
        bttnDocDown.Location = New Point((615 + xStretch), (198 + yStretch / 4))

        conv.Location = New Point(498, (311 + yStretch / 2))
        ConvPrgrsBar.Location = New Point(24, (608 + yStretch))
        ConvPrgrsBar.Width = 680 + xStretch

        lblStatus.Location = New Point(24, (590 + yStretch))
        optionTabs.Location = New Point((720 + xStretch), 16)

    End Sub

    Private Sub removeCss_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles removeCss.Click
        If lvwCSS.Items.Count > 0 Then
            For Each cssItem As ListViewItem In lvwCSS.SelectedItems
                lvwCSS.Items.Remove(cssItem)
            Next
        End If
    End Sub

    Private Sub removeJS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles removeJS.Click
        If lvwJS.Items.Count > 0 Then
            For Each jsItem As ListViewItem In lvwJS.SelectedItems
                lvwJS.Items.Remove(jsItem)
            Next
        End If
    End Sub

    Private Sub editCss_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles editCss.Click
        Dim cssPath As String

        If lvwCSS.Items.Count > 0 Then
            If lvwCSS.SelectedItems.Count > 0 Then
                cssPath = Chr(34) + lvwCSS.SelectedItems(0).SubItems(1).Text + "\" + lvwCSS.SelectedItems(0).Text + Chr(34)

                Try
                    System.Diagnostics.Process.Start("notepad.exe", cssPath)
                Catch ex As System.ComponentModel.Win32Exception
                    MsgBox("Could not run Notepad.")
                    lvwCSS.Focus()
                End Try

            End If
        End If

    End Sub

    Private Sub editJS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles editJS.Click
        Dim jsPath As String

        If lvwJS.Items.Count > 0 Then
            If lvwJS.SelectedItems.Count > 0 Then
                jsPath = Chr(34) + lvwJS.SelectedItems(0).SubItems(1).Text + "\" + lvwJS.SelectedItems(0).Text + Chr(34)

                Try
                    System.Diagnostics.Process.Start("notepad.exe", jsPath)
                Catch ex As System.ComponentModel.Win32Exception
                    MsgBox("Could not run Notepad.")
                    lvwJS.Focus()
                End Try

            End If
        End If
    End Sub

    Private Sub bttnAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnAbout.Click
        Form3.Show()
    End Sub

    Private Sub BttnAddAttach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BttnAddAttach.Click
        Dim pathAndFile As String
        Dim path As String
        Dim fileName As String
        Dim itm As ListViewItem

        'open file dialog settings:
        openFD.InitialDirectory() = openfdInitAttachDir
        openFD.FileName = String.Empty
        openFD.Filter() = "All Files (*.*)|*.*"
        openFD.Title = "Select File(s)"
        openFD.Multiselect() = True

        If openFD.ShowDialog() = DialogResult.OK Then
            For Each pathAndFile In openFD.FileNames
                fileName = System.IO.Path.GetFileName(pathAndFile)
                path = System.IO.Path.GetDirectoryName(pathAndFile)

                'remember path
                openfdInitAttachDir = path

                itm = New ListViewItem

                itm.Text = fileName
                itm.SubItems.Add(path)
                lvwAttachment.Items.Add(itm)
            Next

        End If
    End Sub

    Private Sub BttnRemoveAttach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BttnRemoveAttach.Click
        If lvwAttachment.Items.Count > 0 Then
            For Each attItem As ListViewItem In lvwAttachment.SelectedItems
                lvwAttachment.Items.Remove(attItem)
            Next
        End If
    End Sub

    Private Sub ChEmbedFontFile_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChEmbedFontFile.CheckedChanged
        If ChEmbedFontFile.Checked Then
            ChEmbedSubsetFontFile.Enabled = True
        Else
            ChEmbedSubsetFontFile.Enabled = False
        End If
    End Sub

    Private Sub bttnLicense_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnLicense.Click
        Form4.Show()
    End Sub

    Private Sub lvwDoc_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lvwDoc.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        End If
    End Sub

    Private Sub lvwDoc_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lvwDoc.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim fileArray() As String
            Dim i As Integer
            Dim path As String
            Dim fileName As String
            Dim itm As ListViewItem

            ' Assign the files to an array.
            fileArray = e.Data.GetData(DataFormats.FileDrop)
            ' Loop through the array and add the files to the listview
            For i = 0 To fileArray.Length - 1
                fileName = System.IO.Path.GetFileName(fileArray(i))
                path = System.IO.Path.GetDirectoryName(fileArray(i))

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

    Private Sub bttnDocUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnDocUp.Click
        If lvwDoc.Items.Count > 0 Then
            If lvwDoc.SelectedItems.Count > 0 Then
                If lvwDoc.SelectedIndices(0) > 0 Then
                    'Dim itm As ListViewItem = lvwDoc.SelectedItems(0)
                    'Dim newIndex As Integer = lvwDoc.SelectedIndices(0) - 1

                    'lvwDoc.Items.Remove(itm)
                    'lvwDoc.Items.Insert(newIndex, itm)
                    'lvwDoc.Focus()
                    For i As Integer = 0 To (lvwDoc.SelectedItems.Count - 1) Step 1
                        Dim itm As ListViewItem
                        Dim newIndex As Integer

                        itm = lvwDoc.SelectedItems(i)
                        newIndex = lvwDoc.SelectedIndices(i) - 1

                        lvwDoc.Items.Remove(itm)
                        lvwDoc.Items.Insert(newIndex, itm)
                    Next
                End If
                lvwDoc.Focus()
            End If
        End If
    End Sub

    Private Sub lvwCSS_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lvwCSS.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        End If
    End Sub

    Private Sub lvwCSS_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lvwCSS.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim fileArray() As String
            Dim i As Integer
            Dim path As String
            Dim fileName As String
            Dim itm As ListViewItem

            ' Assign the files to an array.
            fileArray = e.Data.GetData(DataFormats.FileDrop)
            ' Loop through the array and add the files to the listview
            For i = 0 To fileArray.Length - 1
                fileName = System.IO.Path.GetFileName(fileArray(i))
                path = System.IO.Path.GetDirectoryName(fileArray(i))

                itm = New ListViewItem

                itm.Text = fileName
                itm.SubItems.Add(path)

                lvwCSS.Items.Add(itm)
            Next
        End If
    End Sub

    Private Sub lvwJS_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lvwJS.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        End If
    End Sub

    Private Sub lvwJS_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lvwJS.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim fileArray() As String
            Dim i As Integer
            Dim path As String
            Dim fileName As String
            Dim itm As ListViewItem

            ' Assign the files to an array.
            fileArray = e.Data.GetData(DataFormats.FileDrop)
            ' Loop through the array and add the files to the listview
            For i = 0 To fileArray.Length - 1
                fileName = System.IO.Path.GetFileName(fileArray(i))
                path = System.IO.Path.GetDirectoryName(fileArray(i))

                itm = New ListViewItem

                itm.Text = fileName
                itm.SubItems.Add(path)

                lvwJS.Items.Add(itm)
            Next
        End If
    End Sub

    Private Sub lvwAttachment_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lvwAttachment.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        End If
    End Sub

    Private Sub lvwAttachment_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lvwAttachment.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim fileArray() As String
            Dim i As Integer
            Dim path As String
            Dim fileName As String
            Dim itm As ListViewItem

            ' Assign the files to an array.
            fileArray = e.Data.GetData(DataFormats.FileDrop)
            ' Loop through the array and add the files to the listview
            For i = 0 To fileArray.Length - 1
                fileName = System.IO.Path.GetFileName(fileArray(i))
                path = System.IO.Path.GetDirectoryName(fileArray(i))

                itm = New ListViewItem

                itm.Text = fileName
                itm.SubItems.Add(path)

                lvwAttachment.Items.Add(itm)
            Next
        End If
    End Sub

    Private Sub conv_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles conv.MouseEnter
        If lastConvBttnState = buttonStates.normal Then
            lastConvBttnState = buttonStates.hover
            conv.ImageIndex = buttonStates.hover
            'Else
            '    lastConvBttnState = buttonStates.pressed
            '    conv.ImageIndex = buttonStates.pressed
        End If
    End Sub

    Private Sub conv_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles conv.MouseLeave
        If lastConvBttnState = buttonStates.hover Then
            lastConvBttnState = buttonStates.normal
            conv.ImageIndex = buttonStates.normal
            'ElseIf lastConvBttnState = buttonStates.pressed Then
            '    lastConvBttnState = buttonStates.hover
            '    conv.ImageIndex = buttonStates.hover
            'Else
            '    conv.ImageIndex = buttonStates.normal
        End If
    End Sub

    Private Sub conv_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles conv.MouseDown
        If lastConvBttnState = buttonStates.hover Then
            lastConvBttnState = buttonStates.pressed
            conv.ImageIndex = buttonStates.pressed
        End If
    End Sub
    Private Sub conv_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles conv.MouseUp
        If lastConvBttnState = buttonStates.pressed Then
            lastConvBttnState = buttonStates.hover
            conv.ImageIndex = buttonStates.hover
        End If
    End Sub

    Private Sub conv_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles conv.MouseMove
        If lastConvBttnState = buttonStates.pressed Then
            If (e.X < 0) Or (e.X > conv.Width) Or (e.Y < 0) Or (e.Y > conv.Height) Then
                lastConvBttnState = buttonStates.pressed
                conv.ImageIndex = buttonStates.hover
            End If
        End If
        If lastConvBttnState = buttonStates.pressed Then
            If (e.X >= 0) And (e.X <= conv.Width) And (e.Y >= 0) And (e.Y <= conv.Height) Then
                lastConvBttnState = buttonStates.pressed
                conv.ImageIndex = buttonStates.pressed
            End If
        End If
    End Sub

    Private Sub addFile_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addFile.MouseEnter
        addFile.FlatStyle = System.Windows.Forms.FlatStyle.Standard
    End Sub

    Private Sub addFile_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addFile.MouseLeave
        addFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    End Sub

    Private Sub addURL_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addURL.MouseEnter
        addURL.FlatStyle = System.Windows.Forms.FlatStyle.Standard
    End Sub

    Private Sub addURL_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addURL.MouseLeave
        addURL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    End Sub

    Private Sub removeFile_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles removeFile.MouseEnter
        removeFile.FlatStyle = System.Windows.Forms.FlatStyle.Standard
    End Sub

    Private Sub removeFile_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles removeFile.MouseLeave
        removeFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    End Sub

    Private Sub clearAll_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clearAll.MouseEnter
        clearAll.FlatStyle = System.Windows.Forms.FlatStyle.Standard
    End Sub

    Private Sub clearAll_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clearAll.MouseLeave
        clearAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    End Sub

    Private Sub bttnAbout_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnAbout.MouseEnter
        bttnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Standard
    End Sub

    Private Sub bttnAbout_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnAbout.MouseLeave
        bttnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    End Sub

    Private Sub bttnLicense_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnLicense.MouseEnter
        bttnLicense.FlatStyle = System.Windows.Forms.FlatStyle.Standard
    End Sub

    Private Sub bttnLicense_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnLicense.MouseLeave
        bttnLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    End Sub

    Private Sub addCss_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addCss.MouseEnter
        addCss.FlatStyle = System.Windows.Forms.FlatStyle.Standard
    End Sub

    Private Sub addCss_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addCss.MouseLeave
        addCss.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    End Sub

    Private Sub removeCss_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles removeCss.MouseEnter
        removeCss.FlatStyle = System.Windows.Forms.FlatStyle.Standard
    End Sub

    Private Sub removeCss_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles removeCss.MouseLeave
        removeCss.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    End Sub

    Private Sub editCss_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles editCss.MouseEnter
        editCss.FlatStyle = System.Windows.Forms.FlatStyle.Standard
    End Sub

    Private Sub editCss_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles editCss.MouseLeave
        editCss.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    End Sub

    Private Sub addJS_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addJS.MouseEnter
        addJS.FlatStyle = System.Windows.Forms.FlatStyle.Standard
    End Sub

    Private Sub addJS_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addJS.MouseLeave
        addJS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    End Sub

    Private Sub removeJS_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles removeJS.MouseEnter
        removeJS.FlatStyle = System.Windows.Forms.FlatStyle.Standard
    End Sub

    Private Sub removeJS_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles removeJS.MouseLeave
        removeJS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    End Sub

    Private Sub editJS_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles editJS.MouseEnter
        editJS.FlatStyle = System.Windows.Forms.FlatStyle.Standard
    End Sub

    Private Sub editJS_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles editJS.MouseLeave
        editJS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    End Sub

    Private Sub bttnDocUp_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnDocUp.MouseEnter
        bttnDocUp.FlatStyle = System.Windows.Forms.FlatStyle.Standard
    End Sub

    Private Sub bttnDocUp_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnDocUp.MouseLeave
        bttnDocUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    End Sub

    Private Sub bttnDocDown_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnDocDown.MouseEnter
        bttnDocDown.FlatStyle = System.Windows.Forms.FlatStyle.Standard
    End Sub

    Private Sub bttnDocDown_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnDocDown.MouseLeave
        bttnDocDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    End Sub

    Private Sub bttnCssUp_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnCssUp.MouseEnter
        bttnCssUp.FlatStyle = System.Windows.Forms.FlatStyle.Standard
    End Sub

    Private Sub bttnCssUp_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnCssUp.MouseLeave
        bttnCssUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    End Sub

    Private Sub bttnCssDown_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnCssDown.MouseEnter
        bttnCssDown.FlatStyle = System.Windows.Forms.FlatStyle.Standard
    End Sub

    Private Sub bttnCssDown_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnCssDown.MouseLeave
        bttnCssDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    End Sub

    Private Sub bttnJsUp_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnJsUp.MouseEnter
        bttnJsUp.FlatStyle = System.Windows.Forms.FlatStyle.Standard
    End Sub

    Private Sub bttnJsUp_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnJsUp.MouseLeave
        bttnJsUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    End Sub

    Private Sub bttnJsDown_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnJsDown.MouseEnter
        bttnJsDown.FlatStyle = System.Windows.Forms.FlatStyle.Standard
    End Sub

    Private Sub bttnJsDown_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnJsDown.MouseLeave
        bttnJsDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    End Sub

    Private Sub BttnAddAttach_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BttnAddAttach.MouseEnter
        BttnAddAttach.FlatStyle = System.Windows.Forms.FlatStyle.Standard
    End Sub

    Private Sub BttnAddAttach_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BttnAddAttach.MouseLeave
        BttnAddAttach.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    End Sub

    Private Sub BttnRemoveAttach_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BttnRemoveAttach.MouseEnter
        BttnRemoveAttach.FlatStyle = System.Windows.Forms.FlatStyle.Standard
    End Sub

    Private Sub BttnRemoveAttach_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BttnRemoveAttach.MouseLeave
        BttnRemoveAttach.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    End Sub
End Class

Public Class LvwDocItem
    Public doc As String
    Public outputPath As String
    Public docType As String
    Public Sub New(ByVal doc As String, ByVal outputPath As String, ByVal docType As String)
        Me.doc = doc
        Me.outputPath = outputPath
        Me.docType = docType
    End Sub
End Class