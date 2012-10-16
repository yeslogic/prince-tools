Imports System.IO

Public Class Form3

    Private Sub bttnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnOk.Click
        Me.Close()
    End Sub

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.textBoxAbout.Text = Chr(13) + Chr(10) + _
                                GetPrinceVersion() + _
                                Chr(13) + Chr(10) + _
                                "All rights reserved" + _
                                Chr(13) + Chr(10) + Chr(13) + Chr(10) + _
                                "Prince is a batch formatter for converting" + _
                                Chr(13) + Chr(10) + _
                                "XML and HTML into PDF  by applying CSS." + _
                                Chr(13) + Chr(10) + Chr(13) + Chr(10) + _
                                "Use Prince for creating dynamic," + _
                                Chr(13) + Chr(10) + _
                                "data-driven documents and printing" + _
                                Chr(13) + Chr(10) + _
                                "reports, articles and manuals."
        
    End Sub

    Private Function GetPrinceVersion() As String
        Dim args As String
        Dim prs As Process
        Dim stdOutputFromPrince As StreamReader
        Dim line1 As String = ""
        Dim line2 As String = ""


        args = "--version"

        Try
            prs = StartPrince(Form1.princePath, args)

            If prs IsNot Nothing Then

                stdOutputFromPrince = prs.StandardOutput

                line1 = stdOutputFromPrince.ReadLine

                line2 = stdOutputFromPrince.ReadLine

                stdOutputFromPrince.Close()
            End If

            If line1.Length > 6 AndAlso line1.Substring(0, 6) = "Prince" Then
                Return line1 + Chr(13) + Chr(10) + line2
            Else
                MsgBox("Could not get Prince version.")
                Return "Unknown Prince version" + Chr(13) + Chr(10) + "Copyright © 2002-2012 Yes Logic Pty Ltd"
            End If

        Catch ex As ApplicationException
            MsgBox(ex.Message + ": " + System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location) + "\engine\bin\prince.exe")
            Return "Unknown Prince version" + Chr(13) + Chr(10) + "Copyright © 2002-2012 Yes Logic Pty Ltd"
        End Try

        
    End Function

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

    Private Sub linkLbl1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles linkLbl1.LinkClicked
        linkLbl1.LinkVisited = True
        System.Diagnostics.Process.Start("http://www.princexml.com")
    End Sub
End Class