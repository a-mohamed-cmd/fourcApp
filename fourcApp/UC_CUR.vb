Imports System.Drawing.Imaging

Public Class UC_CUR
    Private dv As New DataView
    Private cur As CurrencyManager
    Private dt As New DataTable

#Region "Property"

    Public Property Dv1 As DataView
        Get
            Return dv
        End Get
        Set(value As DataView)
            dv = value
        End Set
    End Property

    Public Property Cur1 As CurrencyManager
        Get
            Return cur
        End Get
        Set(value As CurrencyManager)
            cur = value
        End Set
    End Property

    Public Property Dt1 As DataTable
        Get
            Return dt
        End Get
        Set(value As DataTable)
            dt = value
            Dv1 = dt.DefaultView
            Cur1 = CType(Me.BindingContext(dv), CurrencyManager)
        End Set
    End Property

    Public Property colorToolstrip As Color
        Get
            Return Me.ToolStrip2.BackColor
        End Get
        Set(value As Color)
            ToolStrip2.BackColor = value
        End Set
    End Property

    Public Property ColorCur As Color
        Get
            Return Me.BackColor
        End Get
        Set(value As Color)
            Me.BackColor = value
        End Set
    End Property


#End Region

#Region "Methods"
    ''' <summary>
    ''' السجل الاول
    ''' </summary>
    Public Sub cur_first()
        Cur1.Position = 0
        Txt_FileNo.Text = File_No()
        Txt_FileNo.TextAlign = ContentAlignment.BottomCenter
    End Sub
    ''' <summary>
    ''' السجل الاخير
    ''' </summary>
    Public Sub Cur_Last()
        Cur1.Position = Cur1.Count - 1
        Txt_FileNo.Text = File_No()
    End Sub
    ''' <summary>
    ''' السجل التالي
    ''' </summary>
    Public Sub cur_next()
        Cur1.Position += 1
        Txt_FileNo.Text = File_No()
    End Sub
    ''' <summary>
    ''' السجل السابق
    ''' </summary>
    Public Sub Cur_previous()
        Cur1.Position -= 1
        Txt_FileNo.Text = File_No()
    End Sub
    ''' <summary>
    ''' عرض رقم السجل
    ''' </summary>
    ''' <returns></returns>
    Function File_No() As String
        If Dv1.Count = Nothing Then Return ""
        Return "          سجل رقم   " & Cur1.Position + 1 & "    من عدد   " & Cur1.Count & "         "
    End Function
    Function File_No(M_string As String) As String
        If Dv1.Count = Nothing Then Return ""
        Return "                       " & M_string & "                              "
    End Function

#End Region
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        'Refresh_Data(dt)

        'cur_first()
    End Sub
    ''' <summary>
    ''' اعادة تحميل البيانات في الفورم
    ''' </summary>
    Sub Refresh_Data(dt As DataTable)
        Dt1 = dt
        dv = dt.DefaultView
        Cur1 = CType(Me.BindingContext(dv), CurrencyManager)

    End Sub
    ''' <summary>
    ''' الذهاب للسجل الاول
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Public Sub Btn_First_Click(sender As Object, e As EventArgs) Handles Btn_First.Click
        cur_first()

    End Sub

#Region "مفاتيح الانتقال"
    ''' <summary>
    ''' الذهاب للسجل السابق
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Btn_After_Click(sender As Object, e As EventArgs) Handles Btn_After.Click
        Cur_previous()

    End Sub
    ''' <summary>
    ''' الذهاب للسجل التالي
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Btn_Next_Click(sender As Object, e As EventArgs) Handles Btn_Next.Click
        cur_next()

    End Sub
    ''' <summary>
    ''' الذهاب للسجل الاخير 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Btn_last_Click(sender As Object, e As EventArgs) Handles Btn_last.Click
        Cur_Last()

    End Sub
#End Region

    ''' <summary>
    ''' اظهار المفاتيح واخفها
    ''' </summary>
    ''' <param name="btn_newE"></param>
    ''' <param name="btn_AddE"></param>
    ''' <param name="btn_EditeE"></param>
    ''' <param name="btn_DeleteE"></param>
    Sub Visibility(btn_newE As Boolean, btn_AddE As Boolean,
                           btn_EditeE As Boolean, btn_DeleteE As Boolean)
        btn_newItem.Enabled = btn_newE
        Btn_AddItem.Enabled = btn_AddE
        btn_updateItem.Enabled = btn_EditeE
        btn_DeleteItem.Enabled = btn_DeleteE
    End Sub


End Class
