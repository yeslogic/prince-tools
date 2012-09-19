Imports System.Diagnostics
Imports System.IO
Imports System.Text
Imports System
Public Class Form4
    Dim licType As String = ""
    Dim vendor As String = ""
    Dim endUser As String = ""
    Dim supportBegin As String = ""
    Dim supportEnd As String = ""
    Dim demo As String = ""
    Dim err As String = ""
    Dim newLicFile As String = ""

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim showCurrLic As Boolean = True
        Dim newLicPath As String = ""

        ShowLicense(showCurrLic, newLicPath)

    End Sub
    Private Sub ShowLicense(ByVal showCurrLic As Boolean, ByVal newLicensePath As String)
        Dim princePath As String
        Dim licensePath As String
        Dim args As String
        Dim prs As Process

        licType = ""
        vendor = ""
        endUser = ""
        supportBegin = ""
        supportEnd = ""
        demo = ""
        err = ""
        newLicFile = ""

        princePath = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location)) + _
                      "\engine\bin\prince.exe"

        If showCurrLic Then
            licensePath = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location)) + _
                          "\engine\license\license.dat"
        Else
            licensePath = newLicensePath
        End If
       

        args = "--check-license " + Chr(34) + licensePath + Chr(34) + " --server"

        Try
            prs = StartPrince(princePath, args)

            If Not (prs Is Nothing) Then
                If ReadMessages(prs) = "success" Then
                    If showCurrLic Then
                        ShowCurrLicDetails()
                    Else
                        ShowNewLicDetails()
                        newLicFile = newLicensePath
                        If err = "inapplicable license" Then
                            bttnAcceptLic.Enabled = False
                        Else
                            bttnAcceptLic.Enabled = True
                            bttnAcceptLic.Focus()
                        End If
                    End If
                Else
                    If showCurrLic Then
                        lblCurrLicType.Text = "Invalid license file"
                        textBoxCurrLic.Text = ""
                    Else
                        lblNewLicType.Text = "Invalid license file"
                        textBoxNewLic.Text = ""
                        newLicFile = ""
                        bttnAcceptLic.Enabled = False
                    End If
                End If
            End If

        Catch ex As ApplicationException
            MsgBox(ex.Message + ": " + System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location)) + "\engine\bin\prince.exe")
        End Try
       
    End Sub

    Private Function StartPrince(ByVal princePath As String, ByVal args As String) As Process
        Dim ERROR_FILE_NOT_FOUND As Integer = 2
        Dim ERROR_PATH_NOT_FOUND As Integer = 3
        Dim ERROR_ACCESS_DENIED As Integer = 5

        Dim pr As Process = New Process

        pr.StartInfo.FileName = princePath
        pr.StartInfo.Arguments = args
        pr.StartInfo.UseShellExecute = False
        pr.StartInfo.CreateNoWindow = True
        pr.StartInfo.RedirectStandardInput = True
        pr.StartInfo.RedirectStandardOutput = True
        pr.StartInfo.RedirectStandardError = True

        Try
            pr.Start()

            If Not pr.HasExited Then
                Return pr
            Else
                Throw New ApplicationException("Error starting Prince: " + princePath)
            End If

        Catch ex As System.ComponentModel.Win32Exception
            Dim msg As String
            msg = ex.Message
            If ex.NativeErrorCode = ERROR_FILE_NOT_FOUND Then
                msg = msg + " -- Please verify that Prince.exe is in the directory"
            ElseIf ex.NativeErrorCode = ERROR_ACCESS_DENIED Then
                msg = msg + " -- Please check system permission to run Prince."
            ElseIf ex.NativeErrorCode = ERROR_PATH_NOT_FOUND Then
                msg = msg + " -- Please check Prince path."
            Else
                ' just use ex.Message
            End If

            Throw New ApplicationException(msg)
        End Try
    End Function
    Private Function ReadMessages(ByVal prs As Process) As String
        Dim stdErrFromPr As StreamReader = prs.StandardError
        Dim line As String
        Dim result As String

        line = ""
        result = ""


        Do While True
            If stdErrFromPr.Peek() > -1 Then

                line = stdErrFromPr.ReadLine

                If line.Substring(0, 4) = "fin|" Then
                    result = line.Substring(4, (line.Length - 4))
                    Return result
                End If

                ProcessLine(line)
                Application.DoEvents()

            Else
                If stdErrFromPr.EndOfStream Then
                    Exit Do
                Else
                    Application.DoEvents()
                End If
            End If
        Loop

        stdErrFromPr.Close()

        Return result

    End Function
    Private Sub ProcessLine(ByVal Line As String)
        Dim msgType As String
        Dim Content As String

        msgType = Line.Substring(0, 4)
        Content = Line.Substring(4)

        If msgType = "lic|" Then
            If Content.Length > 7 Then
                If Content.Substring(0, 7) = "vendor|" Then
                    vendor = Content.Substring(7)
                End If
            End If

            If Content.Length > 5 Then
                If Content.Substring(0, 5) = "name|" Then
                    licType = Content.Substring(5)
                End If
            End If

            If Content.Length > 9 Then
                If Content.Substring(0, 9) = "end-user|" Then
                    endUser = Content.Substring(9)
                End If
            End If

            If Content.Length > 5 Then
                If Content.Substring(0, 5) = "date|" Then
                    supportBegin = Content.Substring(5)
                End If
            End If

            If Content.Length > 9 Then
                If Content.Substring(0, 9) = "upgrades|" Then
                    supportEnd = Content.Substring(9)
                End If
            End If

            If Content.Length > 5 Then
                If Content.Substring(0, 5) = "demo|" Then
                    demo = Content.Substring(5)
                End If
            End If

            If Content.Length > 4 Then
                If Content.Substring(0, 4) = "err|" Then
                    err = Content.Substring(4)
                End If
            End If

        End If
    End Sub

    Private Sub ShowCurrLicDetails()
        Dim licDetails As String

        If demo = "yes" Then
            lblCurrLicType.Text = licType
        Else
            If err = "inapplicable license" Then
                lblCurrLicType.Text = "Inapplicable license"
            Else
                lblCurrLicType.Text = licType
            End If

            licDetails = endUser + _
                         Chr(13) + Chr(10) + Chr(13) + Chr(10) + "Support period begins:   " + supportBegin

            If supportEnd.Length = 8 Then
                licDetails = licDetails + _
                             Chr(13) + Chr(10) + "Support period ends:      " + supportEnd.Substring(0, 4) + "-" + _
                                  supportEnd.Substring(4, 2) + "-" + supportEnd.Substring(6, 2)
            End If

            textBoxCurrLic.Text = licDetails
        End If
    End Sub
    Private Sub ShowNewLicDetails()
        Dim licDetails As String

        If demo = "yes" Then
            lblNewLicType.Text = licType
        Else
            If err = "inapplicable license" Then
                lblNewLicType.Text = "Inapplicable license"
            Else
                lblNewLicType.Text = licType
            End If

            licDetails = endUser + _
                         Chr(13) + Chr(10) + Chr(13) + Chr(10) + "Support period begins:   " + supportBegin

            If supportEnd.Length = 8 Then
                licDetails = licDetails + _
                             Chr(13) + Chr(10) + "Support period ends:      " + supportEnd.Substring(0, 4) + "-" + _
                                  supportEnd.Substring(4, 2) + "-" + supportEnd.Substring(6, 2)
            End If

            textBoxNewLic.Text = licDetails
        End If
    End Sub
    Private Sub bttnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnOk.Click
        Me.Close()
    End Sub

    Private Sub bttnOpenLic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnOpenLic.Click
        Dim licFile As String

        'open file dialog settings
        Form1.openFD.InitialDirectory() = Application.StartupPath
        Form1.openFD.FileName = String.Empty
        Form1.openFD.Filter() = "All Files (*.*)|*.*"
        Form1.openFD.Title = "Select License File"
        Form1.openFD.Multiselect() = False

        If Form1.openFD.ShowDialog() = DialogResult.OK Then
            licFile = Form1.openFD.FileName
            ShowLicense(False, licFile)
        End If
    End Sub

    Private Sub bttnAcceptLic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnAcceptLic.Click
        Dim toFile As String

        toFile = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location)) + _
                          "\engine\license\license.dat"

        If newLicFile <> "" Then
            Try
                File.Copy(newLicFile, toFile, True)

                ShowLicense(True, "")

                WelcomeMessage()

                bttnAcceptLic.Enabled = False


            Catch ex As Exception
                MsgBox(ex.Message + ": " + "Could not copy license file to the license directory.")
            End Try
        End If
    End Sub
    Private Sub WelcomeMessage()
        lblNewLicType.Text = ""
        textBoxNewLic.Text = Chr(13) + Chr(10) + "Thank You For Using Prince!" _
                            + Chr(13) + Chr(10) + Chr(13) + Chr(10) _
                            + "                           YesLogic Prince Development Team"

    End Sub
End Class