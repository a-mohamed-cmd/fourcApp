Imports System.Drawing.Imaging

Public Class frm_TransReceipt
    Private _cur As CurrencyManager
    Private _dt As New DataTable
    Private _Transfar As New Transfer
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

    Public Property Transfar As Transfer
        Get
            Return _Transfar
        End Get
        Set(value As Transfer)
            _Transfar = value
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

        UC_cur1.Visibility(Cls_Users.LoginVaidateType("اضافه سندات تحويلات"),
                           Cls_Users.LoginVaidateType("اضافه سندات تحويلات"),
                           Cls_Users.LoginVaidateType("تعديل سندات تحويلات"),
                           Cls_Users.LoginVaidateType("حذف سندات تحويلات"))

        _New_Invoice = False
        load_Cmd()
        Refresh_Database()
        Btn_First()


    End Sub
    Private Sub Load_Cmd()
        Transfar.Items.Com_unit(Cmd_Unit)
        Transfar.Store_IN.Com_store(cmd_stores_in)
        Transfar.Store_Out.Com_store(Cmd_Stores_out)
    End Sub
    Private Sub Refresh_Database()



        'Cmd_Stores.SelectedIndex = 1

        'Purchase.Department.Com_Department(Cmd_DepartmentOrder, Cmd_Stores.SelectedValue)
        _dt = Transfar.View_SalesInvoice()
        If _dt.Rows.Count <> Nothing Then
            UC_cur1.Refresh_Data(_dt)
            Refresh_invoice_code()
        End If
    End Sub
    Private Sub Refresh_invoice_code()
        Btn_Clear()
        Transfar.Load_data_invoice_Code(UC_cur1.Cur1, Me)
        If Transfar.Dv.Count <> Nothing Then

            Cur_Invoice = Transfar.Cur
            dgv_ItemsMove.DataSource = Transfar.Dv
            Transfar.Dgv_Design(dgv_ItemsMove)
        End If
    End Sub
    Private Sub Btn_New_Invoice()
        Btn_Clear()
        dgv_ItemsMove.DataSource = Nothing
        Cls_DataAccessLayer.ClearTextBoxes(Panal_Total)
        Transfar.AccFunction_Code = Transfar.New_Acc_Code()
        Txt_TransCode.Text = Transfar.AccFunction_Code
        _New_Invoice = True
    End Sub


    Private Sub Btn_Addstore()
        If txt_ItemAvailable.Text = 0 Or txt_ItemAvailable.Text - txt_ItemQty.Text < 0 Then
            MsgBox("الكميه لا تكفي ", vbOKOnly)
            Exit Sub
        End If
        Transfar.import_Data(
            accFunctionCode:=Txt_TransCode.Text,
            transfarInvoiceDate:=Dt_InvoiceDate.Value.ToShortDateString,
            transfarInvoiceNo:=txt_InvoiceNumber.Text,
            Department_In:=Cmd_DepartmentIN.SelectedValue,
            Department_Out:=Cmd_Departmentout.SelectedValue,
            itemsID:=txt_ItemCode.Text,
            unitID:=Cmd_Unit.SelectedValue,
            transfarNote:=Txt_PurchaseNote.Text,
            transfarQty:=txt_ItemQty.Text,
            transfarCost:=txt_ItemPrice.Text
        )
        Transfar.SaveNewTransfer()
        If _New_Invoice = True Then
            Refresh_Database()
            UC_cur1.Btn_last.PerformClick()
            Transfar.Cur.Position = 1

            _New_Invoice = False
        Else
            Refresh_invoice_code()
            Cur_Invoice.Position = Cur_Invoice.Count - 1

        End If
        Explore_Data()
    End Sub


    Private Sub Btn_Clear()
        Cls_DataAccessLayer.ClearTextBoxes(Panal_Info)
        Txt_TransCode.Text = Transfar.AccFunction_Code

    End Sub
    Private Sub Btn_DeleteInvoice()
        Dim index_cur As Integer = UC_cur1.Cur1.Position
        Dim index_invoice As Integer = Cur_Invoice.Position
        Transfar.DeleteSale()
        Refresh_invoice_code()
        UC_cur1.Cur1.Position = index_cur
        Cur_Invoice.Position = index_invoice - 1
        Explore_Data()
    End Sub
    Private Sub Btn_UpdateStore()
        If txt_ItemAvailable.Text + Cur_Invoice.Current("Transfar_Qty") - txt_ItemQty.Text < 0 Then
            MsgBox("الكميه غير كافيه", vbOKOnly)
            Exit Sub
        End If
        Dim index_cur As Integer = UC_cur1.Cur1.Position
        Dim index_invoice As Integer = Cur_Invoice.Position
        Transfar.import_Data(
            accFunctionCode:=Txt_TransCode.Text,
            transfarInvoiceDate:=Dt_InvoiceDate.Value.ToShortDateString,
            transfarInvoiceNo:=txt_InvoiceNumber.Text,
            Department_In:=Cmd_DepartmentIN.SelectedValue,
            Department_Out:=Cmd_Departmentout.SelectedValue,
            itemsID:=txt_ItemCode.Text,
            unitID:=Cmd_Unit.SelectedValue,
            transfarNote:=Txt_PurchaseNote.Text,
            transfarQty:=txt_ItemQty.Text,
            transfarCost:=txt_ItemPrice.Text
        )
        Transfar.UpdateTransfer()
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

        Transfar.Load_Data(Cur_Invoice)
        Transfar.Send_Data({Txt_TransCode,
                           txt_InvoiceNumber,
                           txt_ItemCode,
                           Txt_ItemName,
                           Txt_PurchaseNote,
                           txt_ItemQty,
                           txt_ItemPrice,
                           txt_ItemPriceTotal,
                           txt_InvoiceItemsNumber,
                           txt_InvoiceQtyTotal,
                           txt_InvoicePriceTotal,
                           txt_ItemAvailable}, Dt_InvoiceDate,
                           {Cmd_Departmentout, Cmd_Stores_out,
                             Cmd_DepartmentIN, cmd_stores_in,
                                               Cmd_Unit})
    End Sub

    Private Sub Cmd_StoresOut_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmd_Stores_out.SelectedIndexChanged
        If Cmd_Stores_out.DataSource Is Nothing Then Exit Sub
        If Cmd_Stores_out.SelectedItem Is Nothing Then Exit Sub
        Cmd_Departmentout.DataSource = Nothing
        Try
            Dim selectedStoreID As Integer = CInt(Cmd_Stores_out.SelectedItem("Store_ID"))
            Department.Com_Department(Cmd_Departmentout, selectedStoreID)
            Cmd_Departmentout.SelectedValue = Transfar.Department_out.Department_ID
        Catch ex As Exception

        End Try

    End Sub
    Private Sub Cmd_StoresIn_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmd_stores_in.SelectedIndexChanged
        If cmd_stores_in.DataSource Is Nothing Then Exit Sub
        If cmd_stores_in.SelectedItem Is Nothing Then Exit Sub
        Cmd_DepartmentIN.DataSource = Nothing
        Try
            Dim selectedStoreID As Integer = CInt(cmd_stores_in.SelectedItem("Store_ID"))
            Department.Com_Department(Cmd_DepartmentIN, selectedStoreID)
            Cmd_DepartmentIN.SelectedValue = Transfar.Department_In.Department_ID
        Catch ex As Exception

        End Try

    End Sub
    Private Sub Dgv_ItemsMove_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_ItemsMove.CellClick
        If e.RowIndex = -1 Then Exit Sub
        Cur_Invoice.Position = dgv_ItemsMove.CurrentRow.Index
        Explore_Data()
    End Sub

    Private Sub Btn_SearchItems_Click(sender As Object, e As EventArgs) Handles btn_SearchItems.Click

        Dim Frm_searchItem As New frm_Items_search(Me.Transfar)
        Frm_searchItem.ShowDialog()
        'If frm_Items_search.DialogResult = "" Then
        txt_ItemCode.Text = Transfar.Items.Items_Code
        Txt_ItemName.Text = Transfar.Items.Items_NameAR
        Cmd_Unit.SelectedValue = Transfar.Items.Unit.Unit_ID
        txt_ItemPrice.Text = Transfar.Items.AvgCostAndBalance()
        txt_ItemAvailable.Text = Transfar.Items.BalanceOfItemInDeprartment(item_ID:=Transfar.Items.Items_ID,
Deprartment:=Cmd_Departmentout.SelectedValue)
        'End If
    End Sub

End Class