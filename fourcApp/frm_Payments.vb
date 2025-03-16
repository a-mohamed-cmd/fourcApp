Imports System.Drawing.Imaging

Public Class frm_Payments
    Private _cur As CurrencyManager
    Private _dt As New DataTable
    Private _Payment As New Payment
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

    Public Property Payment As Payment
        Get
            Return _Payment
        End Get
        Set(value As Payment)
            _Payment = value
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

        UC_cur1.Visibility(Cls_Users.LoginVaidateType("اضافه سندات مصروفات"),
                           Cls_Users.LoginVaidateType("اضافه سندات مصروفات"),
                           Cls_Users.LoginVaidateType("تعديل سندات مصروفات"),
                           Cls_Users.LoginVaidateType("حذف سندات مصروفات"))

        _New_Invoice = False
        load_Cmd()
        Refresh_Database()
        Btn_First()


    End Sub
    Private Sub Load_Cmd()

        Payment.Store.Com_store(cmd_Stores)
        Payment.Com_Payment(Com_PaymentType)
    End Sub
    Private Sub Refresh_Database()



        'Cmd_Stores.SelectedIndex = 1

        'Purchase.Department.Com_Department(Cmd_DepartmentOrder, Cmd_Stores.SelectedValue)
        _dt = Payment.View_SalesInvoice()
        If _dt.Rows.Count <> Nothing Then
            UC_cur1.Refresh_Data(_dt)
            Refresh_invoice_code()
        End If
    End Sub
    Private Sub Refresh_invoice_code()
        Btn_Clear()
        Payment.Load_data_invoice_Code(UC_cur1.Cur1, Me)
        If Payment.Dv.Count <> Nothing Then

            Cur_Invoice = Payment.Cur
            dgv_ItemsMove.DataSource = Payment.Dv
            Payment.Dgv_Design(dgv_ItemsMove)
        End If
    End Sub
    Private Sub Btn_New_Invoice()
        Btn_Clear()
        dgv_ItemsMove.DataSource = Nothing
        Cls_DataAccessLayer.ClearTextBoxes(Panal_Total)
        Payment.AccFunction_Code = Payment.New_Acc_Code()
        Txt_PaymentCode.Text = Payment.AccFunction_Code
        _New_Invoice = True
    End Sub


    Private Sub Btn_Addstore()

        If cmd_Department.SelectedValue Is DBNull.Value Then
            Payment.import_Data(
           AccFunction_Code:=Txt_PaymentCode.Text,
           payment_Date:=Dt_InvoiceDate.Value.ToShortDateString,
           payment_invoiceNo:=txt_InvoiceNumber.Text,
           AccountSub_Code:=Com_PaymentType.SelectedValue,
           Department_ID:=Nothing,
           Store_IDs:=cmd_Stores.SelectedValue,
           payment_Amount:=txt_Amount.Text,
           payment_Note:=Txt_PaymentNote.Text
       )
        Else
            Payment.import_Data(
          AccFunction_Code:=Txt_PaymentCode.Text,
          payment_Date:=Dt_InvoiceDate.Value.ToShortDateString,
          payment_invoiceNo:=txt_InvoiceNumber.Text,
          AccountSub_Code:=Com_PaymentType.SelectedValue,
          Department_ID:=cmd_Department.SelectedValue,
          Store_IDs:=Nothing,
          payment_Amount:=txt_Amount.Text,
          payment_Note:=Txt_PaymentNote.Text)
        End If

        Payment.SaveNewPayment()
        If _New_Invoice = True Then
            Refresh_Database()
            UC_cur1.Btn_last.PerformClick()
            Payment.Cur.Position = 1

            _New_Invoice = False
        Else
            Refresh_invoice_code()
            Cur_Invoice.Position = Cur_Invoice.Count - 1

        End If
        Explore_Data()
    End Sub


    Private Sub Btn_Clear()
        Cls_DataAccessLayer.ClearTextBoxes(panal_Info)
        Txt_PaymentCode.Text = Payment.AccFunction_Code

    End Sub
    Private Sub Btn_DeleteInvoice()
        Dim index_cur As Integer = UC_cur1.Cur1.Position
        Dim index_invoice As Integer = Cur_Invoice.Position
        Payment.DeleteSale()
        Refresh_invoice_code()
        UC_cur1.Cur1.Position = index_cur
        Cur_Invoice.Position = index_invoice - 1
        Explore_Data()
    End Sub
    Private Sub Btn_UpdateStore()

        Dim index_cur As Integer = UC_cur1.Cur1.Position
        Dim index_invoice As Integer = Cur_Invoice.Position
        If cmd_Department.SelectedValue Is DBNull.Value Then
            Payment.import_Data(
           AccFunction_Code:=Txt_PaymentCode.Text,
           payment_Date:=Dt_InvoiceDate.Value.ToShortDateString,
           payment_invoiceNo:=txt_InvoiceNumber.Text,
           AccountSub_Code:=Com_PaymentType.SelectedValue,
           Department_ID:=Nothing,
           Store_IDs:=cmd_Stores.SelectedValue,
           payment_Amount:=txt_Amount.Text,
           payment_Note:=Txt_PaymentNote.Text
       )
        Else
            Payment.import_Data(
          AccFunction_Code:=Txt_PaymentCode.Text,
          payment_Date:=Dt_InvoiceDate.Value.ToShortDateString,
          payment_invoiceNo:=txt_InvoiceNumber.Text,
          AccountSub_Code:=Com_PaymentType.SelectedValue,
          Department_ID:=cmd_Department.SelectedValue,
          Store_IDs:=Nothing,
          payment_Amount:=txt_Amount.Text,
          payment_Note:=Txt_PaymentNote.Text)
        End If

        Payment.UpdatePayment()
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

        Payment.Load_Data(Cur_Invoice)
        Payment.Send_Data({Txt_PaymentCode,
                           txt_InvoiceNumber,
                           txt_Amount,
                           Txt_PaymentNote,
                           txt_Invoice_Count,
                           txt_Invoicetotal
                           }, Dt_InvoiceDate, {Com_PaymentType, cmd_Department, cmd_Stores})
    End Sub

    Private Sub Cmd_Stores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmd_Stores.SelectedIndexChanged
        If cmd_Stores.DataSource Is Nothing Then Exit Sub
        If cmd_Stores.SelectedItem Is Nothing Then Exit Sub
        cmd_Department.DataSource = Nothing
        Try
            Dim selectedStoreID As Integer = CInt(cmd_Stores.SelectedItem("Store_ID"))
            Department.Com_DepartmentwithNull(cmd_Department, selectedStoreID)
            cmd_Department.SelectedValue = Payment.Department_ID
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Dgv_ItemsMove_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_ItemsMove.CellClick
        If e.RowIndex = -1 Then Exit Sub
        Cur_Invoice.Position = dgv_ItemsMove.CurrentRow.Index
        Explore_Data()
    End Sub



    'Private Sub Guna2ToggleSwitch1_CheckedChanged(sender As Object, e As EventArgs)
    '    If swt_Department.Checked Then
    '        cmd_Department.Visible = True
    '        swt_store.Checked = False
    '        cmd_Stores.Visible = False
    '    Else
    '        swt_store.Checked = True
    '        cmd_Department.Visible = False
    '        cmd_Stores.Visible = True
    '    End If
    'End Sub
End Class