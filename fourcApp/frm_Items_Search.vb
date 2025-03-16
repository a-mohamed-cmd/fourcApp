Imports System.Drawing.Imaging

Public Class frm_Items_search

    Private _dt As New DataTable
    Private _frm As Object
    Sub New(frm As Object)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _frm = frm

    End Sub

    Private Sub frm_Items_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clear()
        load_Items_list()
    End Sub

    Private Sub load_Items_list()
        _dt = _frm.Items.View_ItemsInfo()

        dgv_ItemsMove.DataSource = _dt
        If _dt.Rows.Count = Nothing Then Exit Sub
        _frm.Items.Dgv_Design_view_items(dgv_ItemsMove)
    End Sub
    Private Sub clear()
        txt_SearchInfo.Clear()
        Com_searchMode.SelectedIndex = 0
    End Sub
    Private Sub Search_Mode_items()
        Select Case Com_searchMode.SelectedIndex
            Case 0
                _dt = _frm.Items.Search_by_code(txt_SearchInfo.Text)
            Case 1
                _dt = _frm.Items.Search_by_NameAr(txt_SearchInfo.Text)
            Case 2
                _dt = _frm.Items.Search_by_NameEn(txt_SearchInfo.Text)
        End Select
    End Sub

    Private Sub txt_SearchInfo_TextChanged(sender As Object, e As EventArgs) Handles txt_SearchInfo.TextChanged
        If txt_SearchInfo.Text.Length = 0 Then Exit Sub
        Search_Mode_items()
        dgv_ItemsMove.DataSource = ""

        dgv_ItemsMove.DataSource = _dt

        _frm.Items.Dgv_Design_view_items(dgv_ItemsMove)
    End Sub

    Private Sub dgv_ItemsMove_Click(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_ItemsMove.CellClick
        If e.RowIndex = -1 Then Exit Sub


        Dim cur As CurrencyManager = CType(Me.BindingContext(dgv_ItemsMove.DataSource), CurrencyManager)

        _frm.Items.Load_Data(cur)
        Me.Close()
    End Sub

    Private Sub Com_searchMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Com_searchMode.SelectedIndexChanged
        txt_SearchInfo.Clear()
    End Sub
End Class