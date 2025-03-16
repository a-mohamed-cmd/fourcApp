Imports System.Drawing.Imaging
Imports Guna.UI2.WinForms

Public Class frm_PurchaseReceipt
    Private _cur As CurrencyManager
    Private _dt As New DataTable
    Private _Purchase As New Purchase
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

    Public Property Purchase As Purchase
        Get
            Return _Purchase
        End Get
        Set(value As Purchase)
            _Purchase = value
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

        UC_cur1.Visibility(Cls_Users.LoginVaidateType("اضافه فواتير مشتريات"),
                           Cls_Users.LoginVaidateType("اضافه فواتير مشتريات"),
                           Cls_Users.LoginVaidateType("تعديل فواتير المشتريات"),
                           Cls_Users.LoginVaidateType("حذف فواتير المشتريات")
                           )


        _New_Invoice = False
        load_Cmd()
        Refresh_Database()
        Btn_First()


    End Sub
    Private Sub Load_Cmd()
        Purchase.Items.Com_unit(Cmd_Unit)
        Purchase.Store.Com_store(Cmd_Stores)
    End Sub
    Private Sub Refresh_Database()



        'Cmd_Stores.SelectedIndex = 1

        'Purchase.Department.Com_Department(Cmd_DepartmentOrder, Cmd_Stores.SelectedValue)
        _dt = Purchase.View_PurchaseInvoice()
        If _dt.Rows.Count <> Nothing Then
            UC_cur1.Refresh_Data(_dt)
            Refresh_invoice_code()
        End If
    End Sub
    Private Sub Refresh_invoice_code()
        Btn_Clear()
        Purchase.Load_data_invoice_Code(UC_cur1.Cur1, Me)
        If Purchase.Dv.Count <> Nothing Then

            Cur_Invoice = Purchase.Cur
            dgv_ItemsMove.DataSource = Purchase.Dv
            Purchase.Dgv_Design(dgv_ItemsMove)
        End If
    End Sub
    Private Sub Btn_New_Invoice()
        Btn_Clear()
        dgv_ItemsMove.DataSource = Nothing
        Cls_DataAccessLayer.ClearTextBoxes(Panal_Total)
        Purchase.AccFunction_Code = Purchase.New_Acc_Code()
        Txt_PurchaseCode.Text = Purchase.AccFunction_Code
        _New_Invoice = True
    End Sub


    Private Sub Btn_Addstore()

        Purchase.import_Data(
            accFunction_Code:=Txt_PurchaseCode.Text,
            supplier_ID:=txt_SupplierCode.Text,
            invoiceDate:=Dt_InvoiceDate.Value.ToShortDateString,
            invoiceNo:=txt_InvoiceNumber.Text,
            department_ID:=Cmd_DepartmentOrder.SelectedValue,
            items_ID:=txt_ItemCode.Text,
            unit_ID:=Cmd_Unit.SelectedValue,
            note:=Txt_PurchaseNote.Text,
            qty:=txt_ItemQty.Text,
            price:=txt_ItemPrice.Text
        )
        Purchase.SaveNewPurchase()

        If _New_Invoice = True Then
            Refresh_Database()
            UC_cur1.Btn_last.PerformClick()
            Purchase.Cur.Position = 1

            _New_Invoice = False
        Else
            Refresh_invoice_code()
            Cur_Invoice.Position = Cur_Invoice.Count - 1

        End If
        Explore_Data()
    End Sub

    Private Sub Btn_Clear()
        Cls_DataAccessLayer.ClearTextBoxes(Panal_purchase)
        Txt_PurchaseCode.Text = Purchase.AccFunction_Code

    End Sub
    Private Sub Btn_DeleteInvoice()
        Dim index_cur As Integer = UC_cur1.Cur1.Position
        Dim index_invoice As Integer = Cur_Invoice.Position
        Purchase.Deletepurchase()
        Refresh_invoice_code()
        UC_cur1.Cur1.Position = index_cur
        Cur_Invoice.Position = index_invoice - 1
        Explore_Data()
    End Sub
    Private Sub Btn_UpdateStore()
        Dim index_cur As Integer = UC_cur1.Cur1.Position
        Dim index_invoice As Integer = Cur_Invoice.Position
        Purchase.import_Data(
            accFunction_Code:=Txt_PurchaseCode.Text,
            supplier_ID:=txt_SupplierCode.Text,
            invoiceDate:=Dt_InvoiceDate.Value.ToShortDateString,
            invoiceNo:=txt_InvoiceNumber.Text,
            department_ID:=Cmd_DepartmentOrder.SelectedValue,
            items_ID:=txt_ItemCode.Text,
            unit_ID:=Cmd_Unit.SelectedValue,
            note:=Txt_PurchaseNote.Text,
            qty:=txt_ItemQty.Text,
            price:=txt_ItemPrice.Text
        )
        Purchase.UpdatePurchase()
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

        Purchase.Load_Data(Cur_Invoice)
        Purchase.Send_Data({Txt_PurchaseCode,
                           txt_SupplierCode,
                           txt_SupplierNameAr,
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
                           txt_ItemAvailable}, Dt_InvoiceDate, {Cmd_DepartmentOrder, Cmd_Stores, Cmd_Unit})
    End Sub

    Private Sub Cmd_Stores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmd_Stores.SelectedIndexChanged
        If Cmd_Stores.DataSource Is Nothing Then Exit Sub
        If Cmd_Stores.SelectedItem Is Nothing Then Exit Sub
        Cmd_DepartmentOrder.DataSource = Nothing
        Try
            Dim selectedStoreID As Integer = CInt(Cmd_Stores.SelectedItem("Store_ID"))
            Department.Com_Department(Cmd_DepartmentOrder, selectedStoreID)
            Cmd_DepartmentOrder.SelectedValue = Purchase.Department.Department_ID
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Dgv_ItemsMove_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_ItemsMove.CellClick
        If e.RowIndex = -1 Then Exit Sub
        Cur_Invoice.Position = dgv_ItemsMove.CurrentRow.Index
        Explore_Data()
    End Sub

    Private Sub Btn_SearchItems_Click(sender As Object, e As EventArgs) Handles btn_SearchItems.Click

        Dim Frm_searchItem As New frm_Items_search(Me.Purchase)
        Frm_searchItem.ShowDialog()
        'If frm_Items_search.DialogResult = "" Then
        txt_ItemCode.Text = Purchase.Items.Items_Code
        Txt_ItemName.Text = Purchase.Items.Items_NameAR
        Cmd_Unit.SelectedValue = Purchase.Items.Unit.Unit_ID
        txt_ItemPrice.Text = Purchase.Items.AvgCostAndBalance()
        txt_ItemAvailable.Text = Purchase.Items.BalanceOfItem(item_ID:=Purchase.Items.Items_ID)
        'End If
    End Sub
    Private Sub Btn_SearchSupplier_Click(sender As Object, e As EventArgs) Handles btn_SearchSupplier.Click

        Dim Frm_searchSupplier As New frm_Personal_search(Me.Purchase.Supplier)
        Frm_searchSupplier.ShowDialog()
        'If frm_Items_search.DialogResult = "" Then
        txt_SupplierCode.Text = Purchase.Supplier.Supplier_ID
        txt_SupplierNameAr.Text = Purchase.Supplier.Supplier_Name

    End Sub
End Class