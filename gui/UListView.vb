Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Public Class UListView
    Inherits System.Windows.Forms.ListView

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.WatermarkAlpha = 200
        MyBase.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        CoInitialize(IntPtr.Zero)
        SetBkImage()
    End Sub

    'UserControl1 overrides dispose to clean up the component list.
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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

#End Region

    Private Const WM_HSCROLL As Integer = &H114
    Private Const WM_VSCROLL As Integer = &H115

    '------------------------------------------------------------------------------
    'Structure needed to set the listviews background watermark image
    Public Structure LVBKIMAGE
        Public ulFlags As Int32
        Public hbm As IntPtr
        Public pszImage As String
        Public cchImageMax As Int32
        Public xOffsetPercent As Int32
        Public yOffsetPercent As Int32
    End Structure


    'Constant Declarations
    Private Const LVM_FIRST As Int32 = &H1000
    Private Const LVM_SETBKIMAGEW As Int32 = (LVM_FIRST + 138)
    Private Const LVBKIF_TYPE_WATERMARK As Int32 = &H10000000

    'API Declarations
    Private Declare Sub CoInitialize Lib "ole32.dll" (ByVal pvReserved As Int32)
    Private Declare Sub CoUninitialize Lib "ole32.dll" ()
    Private Declare Function SendMessage Lib "user32.dll" Alias "SendMessageA" (ByVal hwnd As Int32, ByVal wMsg As Int32, ByVal wParam As Int32, ByVal lParam As Int32) As Int32


    Dim vWatermarkImage As Bitmap
    Dim vWatermarkAlpha As Integer

    <Configuration.DefaultSettingValue("200")> _
    Public Property WatermarkAlpha() As Integer
        Get
            Return vWatermarkAlpha
        End Get
        Set(ByVal value As Integer)
            vWatermarkAlpha = value
            SetBkImage()
        End Set
    End Property

    Public Property WatermarkImage() As Bitmap
        Get
            Return vWatermarkImage
        End Get
        Set(ByVal value As Bitmap)
            vWatermarkImage = value
            SetBkImage()
        End Set
    End Property

    Private Sub SetBkImage()
        If Not WatermarkImage Is Nothing Then
            Dim hBMP As IntPtr = GetBMP(WatermarkImage)
            If Not hBMP = IntPtr.Zero Then
                Dim lv As New LVBKIMAGE
                lv.hbm = hBMP
                lv.ulFlags = LVBKIF_TYPE_WATERMARK
                Dim lvPTR As IntPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(System.Runtime.InteropServices.Marshal.SizeOf(lv))
                System.Runtime.InteropServices.Marshal.StructureToPtr(lv, lvPTR, False)
                SendMessage(Me.Handle, LVM_SETBKIMAGEW, 0, lvPTR)
                System.Runtime.InteropServices.Marshal.FreeCoTaskMem(lvPTR)
            End If
        Else
            Dim lv As New LVBKIMAGE
            lv.hbm = IntPtr.Zero
            lv.ulFlags = LVBKIF_TYPE_WATERMARK
            Dim lvPTR As IntPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(System.Runtime.InteropServices.Marshal.SizeOf(lv))
            System.Runtime.InteropServices.Marshal.StructureToPtr(lv, lvPTR, False)
            SendMessage(Me.Handle, LVM_SETBKIMAGEW, 0, lvPTR)
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(lvPTR)
        End If
    End Sub


    Private Function GetBMP(ByVal FromImage As Image) As IntPtr
        Dim bmp As Bitmap = New Bitmap(FromImage.Width, FromImage.Height)
        Dim g As Graphics = Graphics.FromImage(bmp)
        g.Clear(Me.BackColor)
        g.DrawImage(FromImage, 310, 130, CInt(bmp.Width * 1 / 3), CInt(bmp.Height * 1 / 3))
        g.FillRectangle(New SolidBrush(Color.FromArgb(WatermarkAlpha, Me.BackColor.R, Me.BackColor.G, Me.BackColor.B)), New RectangleF(0, 0, bmp.Width, bmp.Height))
        g.Dispose()
        Return bmp.GetHbitmap
        'bmp.Dispose()
    End Function

    'Public Sub New()
    '    Me.WatermarkAlpha = 200
    '    MyBase.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
    '    CoInitialize(IntPtr.Zero)
    '    SetBkImage()
    'End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        CoUninitialize()
    End Sub

    Private Sub UListView_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.HandleCreated
        SetBkImage()
    End Sub


    '-------------------------------------------------------------------------------
    Protected Overrides Sub WndProc(ByRef msg As Message)
        ' Look for the WM_VSCROLL or the WM_HSCROLL messages.
        If ((msg.Msg = WM_VSCROLL) Or (msg.Msg = WM_HSCROLL)) Then
            ' Move focus to the ListView to cause ComboBox to lose focus.
            Me.Focus()
        End If

        ' Pass message to default handler.
        MyBase.WndProc(msg)
    End Sub
End Class
