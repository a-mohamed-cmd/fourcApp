Imports System.Drawing.Imaging
Imports System.Security.Cryptography.Xml

Public Class frm_DepreciationReceipt
    Private _cur As CurrencyManager
    Private _dt As New DataTable
    Private _Deprecation As New Depreciation
    Private _Cur_Invoice As CurrencyManager
    Private _New_Invoice As Boolean = False

    Public Property Cur_Invoice As CurrencyManager
        Get
            Return _Cur_Invoice
        End Get
        Set(value As CurrencyManager)
            _Cur_Invoice = value
        End Set
    End Property


    Public Property Deprecation As Depreciation
        Get
            Return _Deprecation
        End Get
        Set(value As Depreciation)
            _Deprecation = value
        End Set
    End Property

    Private Sub Frm_Items_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UC_cur1.ColorCur = Color.FromArgb(196, 207, 137)
        Load_btn_Event_of_Cur()
    End Sub
#Region "Buttons Cur"
    Private Sub Load_btn_Event_of_Cur()
        AddHandler Me.UC_cur1.Btn_AddItem.Click, AddressOf Btn_Addstore
        AddHandler Me.UC_cur1.btn_newItem.Click, AddressOf Btn_Clear
        AddHandler Me.UC_cur1.btn_newItem.DoubleClick, AddressOf btn_New_Invoice
        AddHandler Me.UC_cur1.btn_updateItem.Click, AddressOf Btn_UpdateStore
        AddHandler Me.UC_cur1.btn_DeleteItem.Click, AddressOf btn_DeleteInvoice
        AddHandler Me.UC_cur1.Btn_After.Click, AddressOf Btn_After
        AddHandler Me.UC_cur1.Btn_First.Click, AddressOf Btn_First
        AddHandler Me.UC_cur1.Btn_last.Click, AddressOf Btn_Last
        AddHandler Me.UC_cur1.Btn_Next.Click, AddressOf Btn_Next

        UC_cur1.Visibility(Cls_Users.LoginVaidateType("اضافه سندات اهلاك"),
                           Cls_Users.LoginVaidateType("اضافه سندات اهلاك"),
                           Cls_Users.LoginVaidateType("تعديل سندات اهلاك"),
                           Cls_Users.LoginVaidateType("حذف سندات اهلاك"))

        _New_Invoice = False
        load_Cmd()
        Refresh_Database()
        Btn_First()


    End Sub
    Private Sub Load_Cmd()
        Deprecation.Items.Com_unit(Cmd_Unit)
        Deprecation.Store.Com_store(Cmd_Stores)
    End Sub
    Private Sub Refresh_Database()



        'Cmd_Stores.SelectedIndex = 1

        'Purchase.Department.Com_Department(Cmd_DepartmentOrder, Cmd_Stores.SelectedValue)
        _dt = Deprecation.View_SalesInvoice()
        If _dt.Rows.Count <> Nothing Then
            UC_cur1.Refresh_Data(_dt)
            Refresh_invoice_code()
        End If
    End Sub
    Private Sub Refresh_invoice_code()
        Btn_Clear()
        Deprecation.Load_data_invoice_Code(UC_cur1.Cur1, Me)
        If Deprecation.Dv.Count <> Nothing Then

            Cur_Invoice = Deprecation.Cur
            dgv_ItemsMove.DataSource = Deprecation.Dv
            Deprecation.Dgv_Design(dgv_ItemsMove)
        End If
    End Sub
    Private Sub Btn_New_Invoice()
        Btn_Clear()
        dgv_ItemsMove.DataSource = Nothing
        Cls_DataAccessLayer.ClearTextBoxes(panal_Total)
        Deprecation.AccFunction_Code = Deprecation.New_Acc_Code()
        Txt_DepreciationCode.Text = Deprecation.AccFunction_Code
        _New_Invoice = True
    End Sub


    Private Sub Btn_Addstore()
        If txt_ItemAvailable.Text = 0 Or txt_ItemAvailable.Text - txt_ItemQty.Text < 0 Then
            MsgBox("الكميه لا تكفي ", vbOKOnly)
            Exit Sub
        End If
        Deprecation.import_Data(
            accFunctionCode:=Txt_DepreciationCode.Text,
            depreciationDate:=Dt_DepreciationDate.Value.ToShortDateString,
            departmentID:=Cmd_DepartmentDepreciation.SelectedValue,
            itemsID:=txt_ItemCode.Text,
            unitID:=Cmd_Unit.SelectedValue,
            depreciationCase:=Txt_DepreciationCause.Text,
            depreciationQty:=txt_ItemQty.Text,
            depreciationCost:=txt_ItemPrice.Text
        )
        Deprecation.SaveNewDepreciation()
        If _New_Invoice = True Then
            Refresh_Database()
            UC_cur1.Btn_last.PerformClick()
            Deprecation.Cur.Position = 1

            _New_Invoice = False
        Else
            Refresh_invoice_code()
            Cur_Invoice.Position = Cur_Invoice.Count - 1

        End If
        Explore_Data()
    End Sub


    Private Sub Btn_Clear()
        Cls_DataAccessLayer.ClearTextBoxes(panal_Info)
        Txt_DepreciationCode.Text = Deprecation.AccFunction_Code

    End Sub
    Private Sub Btn_DeleteInvoice()
        Dim index_cur As Integer = UC_cur1.Cur1.Position
        Dim index_invoice As Integer = Cur_Invoice.Position
        Deprecation.DeleteSale()
        Refresh_invoice_code()
        UC_cur1.Cur1.Position = index_cur
        Cur_Invoice.Position = index_invoice - 1
        Explore_Data()
    End Sub
    Private Sub Btn_UpdateStore()
        If txt_ItemAvailable.Text + Cur_Invoice.Current("Depreciation_Qty") - txt_ItemQty.Text < 0 Then
            MsgBox("الكميه غير كافيه", vbOKOnly)
            Exit Sub
        End If
        Dim index_cur As Integer = UC_cur1.Cur1.Position
        Dim index_invoice As Integer = Cur_Invoice.Position
        Deprecation.import_Data(
            accFunctionCode:=Txt_DepreciationCode.Text,
            depreciationDate:=Dt_DepreciationDate.Value.ToShortDateString,
            departmentID:=Cmd_DepartmentDepreciation.SelectedValue,
            itemsID:=txt_ItemCode.Text,
            unitID:=Cmd_Unit.SelectedValue,
            depreciationCase:=Txt_DepreciationCause.Text,
            depreciationQty:=txt_ItemQty.Text,
            depreciationCost:=txt_ItemPrice.Text
        )
        Deprecation.UpdateDepreciation()
        'Refresh_Database()
        Refresh_invoice_code()
        UC_cur1.Cur1.Position = index_cur
        Cur_Invoice.Position = index_invoice
        Explore_Data()
    End Sub

    Private Sub Btn_After()
        Refresh_invoice_code()
        Explore_Data()

    End Sub
    Private Sub Btn_First()
        UC_cur1.cur_first()
        Explore_Data()

    End Sub
    Private Sub Btn_Last()
        Refresh_invoice_code()
        Explore_Data()
    End Sub
    Private Sub Btn_Next()
        Refresh_invoice_code()
        Explore_Data()
    End Sub
#End Region
    Private Sub Explore_Data()

        Deprecation.Load_Data(Cur_Invoice)
        Deprecation.Send_Data({Txt_DepreciationCode,
                           txt_ItemCode,
                           Txt_ItemName,
                           Txt_DepreciationCause,
                           txt_ItemQty,
                           txt_ItemPrice,
                           txt_ItemPriceTotal,
                           txt_InvoiceItemsNumber,
                           txt_InvoiceQtyTotal,
                           txt_InvoicePriceTotal,
                           txt_ItemAvailable}, Dt_DepreciationDate, {Cmd_DepartmentDepreciation, Cmd_Stores, Cmd_Unit})
    End Sub

    Private Sub Cmd_Stores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmd_Stores.SelectedIndexChanged
        If Cmd_Stores.DataSource Is Nothing Then Exit Sub
        If Cmd_Stores.SelectedItem Is Nothing Then Exit Sub
        Cmd_DepartmentDepreciation.DataSource = Nothing
        Try
            Dim selectedStoreID As Integer = CInt(Cmd_Stores.SelectedItem("Store_ID"))
            Department.Com_Department(Cmd_DepartmentDepreciation, selectedStoreID)
            Cmd_DepartmentDepreciation.SelectedValue = Deprecation.Department.Department_ID
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Dgv_ItemsMove_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_ItemsMove.CellClick
        If e.RowIndex = -1 Then Exit Sub
        Cur_Invoice.Position = dgv_ItemsMove.CurrentRow.Index
        Explore_Data()
    End Sub

    Private Sub Btn_SearchItems_Click(sender As Object, e As EventArgs) Handles btn_SearchItems.Click

        Dim Frm_searchItem As New frm_Items_search(Me.Deprecation)
        Frm_searchItem.ShowDialog()
        'If frm_Items_search.DialogResult = "" Then
        txt_ItemCode.Text = Deprecation.Items.Items_Code
        Txt_ItemName.Text = Deprecation.Items.Items_NameAR
        Cmd_Unit.SelectedValue = Deprecation.Items.Unit.Unit_ID
        txt_ItemPrice.Text = Deprecation.Items.AvgCostAndBalance
        txt_ItemAvailable.Text = Deprecation.Items.BalanceOfItemInDeprartment(item_ID:=Deprecation.Items.Items_ID,
            Deprartment:=Cmd_DepartmentDepreciation.SelectedValue)
        'End If
    End Sub

End Class