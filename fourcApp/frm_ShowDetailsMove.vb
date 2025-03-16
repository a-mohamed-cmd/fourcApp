Imports System.Drawing.Imaging

Public Class frm_ShowDetailsMove

    Private _dt As New DataTable
    Private _frm As Object
    Private _info As String = ""
    Private _department As Integer = 1
    Sub New(frm As Object, info As String, department As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _frm = frm
        _info = info
        _department = department
    End Sub
#Region "property"
    Public Property Info As String
        Get
            Return _info
        End Get
        Set(value As String)
            _info = value
        End Set
    End Property

    Public Property Department As Integer
        Get
            Return _department
        End Get
        Set(value As Integer)
            _department = value
        End Set
    End Property
#End Region
    Private Sub frm_Items_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clear()
        load_Items_list()
    End Sub

    Private Sub load_Items_list()
        _dt = _frm.Show_DetailsMove(Info, Department)

        dgv_ItemsMove.DataSource = _dt
        If _dt.Rows.Count = Nothing Then Exit Sub
        _frm.Dgv_Design_DetailsMove(dgv_ItemsMove)
    End Sub
    Private Sub clear()
        dgv_ItemsMove.DataSource = ""
    End Sub



    'Private Sub dgv_ItemsMove_Click(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_ItemsMove.CellClick
    '    If e.RowIndex = -1 Then Exit Sub


    '    Dim cur As CurrencyManager = CType(Me.BindingContext(dgv_ItemsMove.DataSource), CurrencyManager)

    '    _frm.Items.Load_Data(cur)
    '    Me.Close()
    'End Sub

End Class