
Imports Guna.UI2.WinForms
Imports Microsoft.Data.SqlClient

Public Class Payment
    ' المتغيرات الخاصة
    Private _payment_ID As Integer
    Private _payment_Date As Date
    Private _payment_invoiceNo As String
    Private _AccountSub_Code As Integer
    Private _store As New Store
    Private _Department As New Department
    Private _Department_ID As Integer?
    Private _Store_IDs As Integer?
    Private _payment_Amount As Decimal
    Private _payment_Note As String
    Private _AccFunction_Code As Integer
    Private _TotalInvoice As Decimal = 0
    Private _dv As New DataView
    Private _Cur As CurrencyManager
#Region "الخصائص"
    Public Property Payment_ID As Integer
        Get
            Return _payment_ID
        End Get
        Set(value As Integer)
            _payment_ID = value
        End Set
    End Property

    Public Property Payment_Date As Date
        Get
            Return _payment_Date
        End Get
        Set(value As Date)
            _payment_Date = value
        End Set
    End Property

    Public Property Payment_invoiceNo As String
        Get
            Return _payment_invoiceNo
        End Get
        Set(value As String)
            _payment_invoiceNo = value
        End Set
    End Property

    Public Property AccountSub_Code As Integer
        Get
            Return _AccountSub_Code
        End Get
        Set(value As Integer)
            _AccountSub_Code = value
        End Set
    End Property

    Public Property Department_ID As Integer?
        Get
            Return _Department_ID
        End Get
        Set(value As Integer?)
            _Department_ID = value
        End Set
    End Property

    Public Property Store_IDs As Integer?
        Get
            Return _Store_IDs
        End Get
        Set(value As Integer?)
            _Store_IDs = value
        End Set
    End Property

    Public Property Payment_Amount As Decimal
        Get
            Return _payment_Amount
        End Get
        Set(value As Decimal)
            _payment_Amount = value
        End Set
    End Property

    Public Property Payment_Note As String
        Get
            Return _payment_Note
        End Get
        Set(value As String)
            _payment_Note = value
        End Set
    End Property

    Public Property AccFunction_Code As Integer
        Get
            Return _AccFunction_Code
        End Get
        Set(value As Integer)
            _AccFunction_Code = value
        End Set
    End Property

    Public Property TotalInvoice As Decimal
        Get
            Return _TotalInvoice
        End Get
        Set(value As Decimal)
            _TotalInvoice = value
        End Set
    End Property

    Public Property Dv As DataView
        Get
            Return _dv
        End Get
        Set(value As DataView)
            _dv = value
        End Set
    End Property

    Public Property Cur As CurrencyManager
        Get
            Return _Cur
        End Get
        Set(value As CurrencyManager)
            _Cur = value
        End Set
    End Property

    Public Property Store As Store
        Get
            Return _store
        End Get
        Set(value As Store)
            _store = value
        End Set
    End Property

    Public Property Department As Department
        Get
            Return _Department
        End Get
        Set(value As Department)
            _Department = value
        End Set
    End Property
#End Region

#Region "Constructor"
    Public Sub New(Optional payment_ID As Integer = 0,
                   Optional payment_Date As Date = Nothing,
                   Optional payment_invoiceNo As String = "",
                   Optional AccountSub_Code As Integer = 0,
                   Optional Department_ID As Integer? = Nothing,
                   Optional Store_IDs As Integer? = Nothing,
                   Optional payment_Amount As Decimal = 0,
                   Optional payment_Note As String = "",
                   Optional AccFunction_Code As Integer = 0)

        Me.payment_ID = payment_ID
        Me.payment_Date = payment_Date
        Me.payment_invoiceNo = payment_invoiceNo
        Me.AccountSub_Code = AccountSub_Code
        Me.Department_ID = Department_ID
        Me.Store_IDs = Store_IDs
        Me.payment_Amount = payment_Amount
        Me.payment_Note = payment_Note
        Me.AccFunction_Code = AccFunction_Code
    End Sub
#End Region

    Public Sub Import_Data(
                   Optional payment_Date As Date = Nothing,
                   Optional payment_invoiceNo As String = "",
                   Optional AccountSub_Code As Integer = 0,
                   Optional Department_ID As Integer? = Nothing,
                   Optional Store_IDs As Integer? = Nothing,
                   Optional payment_Amount As Decimal = 0,
                   Optional payment_Note As String = "",
                   Optional AccFunction_Code As Integer = 0)



        Me.payment_Date = payment_Date
        Me.payment_invoiceNo = payment_invoiceNo
        Me.AccountSub_Code = AccountSub_Code
        Me.Department_ID = Department_ID
        Me.Store_IDs = Store_IDs
        Me.payment_Amount = payment_Amount
        Me.payment_Note = payment_Note
        Me.AccFunction_Code = AccFunction_Code

    End Sub
    ''' <summary>
    ''' استقبال البيانات من row في هيئه current manager
    ''' </summary>
    ''' <param name="cur1"></param>
    Sub Load_data_invoice_Code(cur1 As CurrencyManager, frm As Control)
        Dv = View_SalesInvoice_Code(cur1).DefaultView()
        Cur = CType(frm.BindingContext(Dv), CurrencyManager)
    End Sub

    ''' <summary>
    ''' عرض بيانات row
    ''' </summary>
    ''' <param name="cur"></param>
    Sub Load_Data(cur As CurrencyManager)

        payment_ID = cur.Current("payment_ID")
        _AccFunction_Code = cur.Current("AccFunction_Code")

        payment_Date = If(IsDBNull(cur.Current("payment_Date")), Nothing, cur.Current("payment_Date"))
        payment_invoiceNo = If(IsDBNull(cur.Current("payment_invoiceNo")), Nothing, cur.Current("payment_invoiceNo"))
        AccountSub_Code = If(IsDBNull(cur.Current("AccountSub_Code")), Nothing, cur.Current("AccountSub_Code"))
        Department_ID = If(IsDBNull(cur.Current("Department_ID")), Nothing, cur.Current("Department_ID"))
        Store_IDs = If(IsDBNull(cur.Current("Store_IDs")), cur.Current("Store_ID"), cur.Current("Store_IDs"))

        payment_Note = If(IsDBNull(cur.Current("payment_Note")), Nothing, cur.Current("payment_Note"))

        payment_Amount = If(IsDBNull(cur.Current("payment_Amount")), 0D, cur.Current("payment_Amount"))

        '_TotalInvoice = 
    End Sub

    ''' <summary>
    ''' عرض البيانات علي interface
    ''' </summary>
    ''' <param name="txt"></param>
    ''' <param name="dateinvoice"></param>
    ''' <param name="com"></param>
    Sub Send_Data(txt() As Guna2TextBox,
                  dateinvoice As Guna2DateTimePicker,
                  com() As Guna2ComboBox)

        txt(0).Text = AccFunction_Code
        txt(1).Text = payment_invoiceNo
        txt(2).Text = payment_Amount
        dateinvoice.Value = payment_Date
        txt(3).Text = payment_Note
        com(0).SelectedValue = AccountSub_Code
        If Department_ID.HasValue Then
            com(1).SelectedValue = Department_ID
        Else
            com(1).SelectedValue = DBNull.Value
        End If
        If Store_IDs.HasValue Then
            com(2).SelectedValue = Store_IDs
        Else
            com(2).SelectedIndex = 0
        End If


        txt(4).Text = Dv.Count
        txt(5).Text = Convert.ToDecimal(Dv.Table.Compute("sum(payment_Amount)", Nothing)).ToString("N2")


    End Sub
    ''' <summary>
    ''' الحصول علي مجموع الفاتوره
    ''' </summary>
    ''' <returns></returns>
    'Private Function Total_Price() As Decimal



    '    For Each row As DataRowView In Dv
    '        If Not IsDBNull(row("Customer_Qty")) AndAlso Not IsDBNull(row("Customer_Price")) Then
    '            Total_Price += Convert.ToDecimal(row("Customer_Qty")) * Convert.ToDecimal(row("Customer_Price"))
    '        End If
    '    Next
    '    TotalInvoice = Total_Price
    '    Return Total_Price


    'End Function


#Region "Methods"
    Public Function SaveNewPayment() As Integer
        Dim parameters As New List(Of SqlParameter)
        With parameters
            .Add(New SqlParameter("@payment_Date", SqlDbType.Date) With {.Value = payment_Date})
            .Add(New SqlParameter("@payment_invoiceNo", SqlDbType.NVarChar, 10) With {.Value = payment_invoiceNo})
            .Add(New SqlParameter("@AccountSub_Code", SqlDbType.Int) With {.Value = AccountSub_Code})
            .Add(New SqlParameter("@Department_ID", SqlDbType.Int) With {.Value = If(Department_ID.HasValue, Department_ID, DBNull.Value)})
            .Add(New SqlParameter("@Store_IDs", SqlDbType.Int) With {.Value = If(Store_IDs.HasValue, Store_IDs, DBNull.Value)})
            .Add(New SqlParameter("@payment_Amount", SqlDbType.Decimal) With {.Value = payment_Amount})
            .Add(New SqlParameter("@payment_Note", SqlDbType.NVarChar, 500) With {.Value = If(payment_Note, DBNull.Value)})
            .Add(New SqlParameter("@AccFunction_Code", SqlDbType.Int) With {.Value = AccFunction_Code})

        End With

        ' استدعاء الإجراء المخزن لإضافة الدفع
        Dim result As Integer = sqlMethod.ExecuteStoredProcedure("Accounts.AddNew_Payment_Invoice", parameters.ToArray())
        If result > 0 Then
            MsgBox("تم حفظ المصروف بنجاح.")
        Else
            MsgBox("حدث خطأ في حفظ المصروف.")
        End If
        Return result

    End Function

    Public Function UpdatePayment() As Integer
        Dim parameters As New List(Of SqlParameter)
        With parameters
            .Add(New SqlParameter("@payment_Date", SqlDbType.Date) With {.Value = payment_Date})
            .Add(New SqlParameter("@payment_invoiceNo", SqlDbType.NVarChar, 10) With {.Value = payment_invoiceNo})
            .Add(New SqlParameter("@AccountSub_Code", SqlDbType.Int) With {.Value = AccountSub_Code})
            .Add(New SqlParameter("@Department_ID", SqlDbType.Int) With {.Value = If(Department_ID.HasValue, Department_ID, DBNull.Value)})
            .Add(New SqlParameter("@Store_IDs", SqlDbType.Int) With {.Value = If(Store_IDs.HasValue, Store_IDs, DBNull.Value)})
            .Add(New SqlParameter("@payment_Amount", SqlDbType.Decimal) With {.Value = payment_Amount})
            .Add(New SqlParameter("@payment_Note", SqlDbType.NVarChar, 500) With {.Value = If(payment_Note, DBNull.Value)})
            .Add(New SqlParameter("@AccFunction_Code", SqlDbType.Int) With {.Value = AccFunction_Code})
            .Add(New SqlParameter("@payment_ID", SqlDbType.Int) With {.Value = payment_ID})

        End With

        ' استدعاء الإجراء المخزن لإضافة الدفع
        Dim result As Integer = sqlMethod.ExecuteStoredProcedure("Accounts.Update_Payment_Invoice", parameters.ToArray())
        If result > 0 Then
            MsgBox("تم التعديل المصروف بنجاح.")
        Else
            MsgBox("حدث خطأ في التعديل المصروف.")
        End If
        Return result

    End Function
    Public Function DeletePayment() As Integer
        Dim parameters As New List(Of SqlParameter)
        With parameters

            .Add(New SqlParameter("@payment_ID", SqlDbType.Int) With {.Value = payment_ID})

        End With

        ' استدعاء الإجراء المخزن لإضافة الدفع
        Dim result As Integer = sqlMethod.ExecuteStoredProcedure("Accounts.Delete_Payment_Invoice", parameters.ToArray())
        If result > 0 Then
            MsgBox("تم حذف المصروف بنجاح.")
        Else
            MsgBox("حدث خطأ في حذف المصروف.")
        End If
        Return result

    End Function
    ''' <summary>
    ''' تنفيذ الإجراء  لعرض جميع ارقام قيود الفواتير
    ''' </summary>

    Public Shared Function View_SalesInvoice() As DataTable

        ' إعداد الإجراء المخزن
        View_SalesInvoice = sqlMethod.ExecuteSelectData("Accounts.pro_View_PaymentsInvoics_Code")
        ' التحقق من النتيجة

    End Function
    ''' <summary>
    ''' عرض بيانات برقم القيد
    ''' </summary>
    Private Function View_SalesInvoice_Code(cur As CurrencyManager) As DataTable
        AccFunction_Code = cur.Current("AccFunction_Code")
        Dim parameters As New List(Of SqlParameter) From {
            New SqlParameter("@AccFunction_code", SqlDbType.Int) With {.Value = AccFunction_Code}
        }

        ' إعداد الإجراء المخزن
        View_SalesInvoice_Code = sqlMethod.ExecuteSelectData("accounts.pro_View_Payments_Code", parameters.ToArray())
        ' التحقق من النتيجة

    End Function
    ''' <summary>
    ''' تنفيذ الإجراء المخزن لحذف البيع
    ''' </summary>
    ''' <returns>عدد السجلات المتأثرة (عادة 1 إذا تم التعديل بنجاح)</returns>
    Public Function DeleteSale() As Integer
        Dim parameters As New List(Of SqlParameter) From {
            New SqlParameter("@payment_ID", SqlDbType.Int) With {.Value = payment_ID}
        }

        Dim result As Integer = sqlMethod.ExecuteStoredProcedure("Accounts.Delete_Payment_Invoice", parameters.ToArray())
        If result > 0 Then
            MsgBox("تم حذف المصروف بنجاح.")
        Else
            MsgBox("حدث خطأ في حذف المصروف.")
        End If
        Return result
    End Function
#End Region
    ''' <summary>
    ''' تصميم datagridview
    ''' </summary>
    ''' <param name="dgv"></param>
    Public Shared Sub Dgv_Design(dgv As Guna2DataGridView)
        'Dim cel As DataGridViewCell
        'cel.Value = "حذف"
        'dg.CellTemplate = cel

        'dg.Name = "Del"
        'dg.Text = "حذف"

        'dgv.Columns.Add(Dg)

        'dgv.Columns("Del").Width = 50

        'dgv.Columns("Del").Visible = False

        'AddHandler dgv.CellClick, AddressOf Delete_item(sender, e)
        ' Column Header Disign

        'dgv.Columns("Del").Width = 50

        'dgv.Columns("Del").Visible = False
        'dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.BurlyWood
        'dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.DarkGreen
        dgv.ColumnHeadersDefaultCellStyle.Font =
        New Font("Cairo", 10, FontStyle.Bold)
        dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'dgv.BackgroundColor = Color.Black
        dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv.EnableHeadersVisualStyles = True

        'Column Header Text
        dgv.Columns("payment_Amount").HeaderText = "المبلغ"
        dgv.Columns("payment_ID").Visible = False
        dgv.Columns("AccFunction_Code").Visible = False
        ' dgv.Columns("ID_Items_").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'dgv.Columns("Customer_ID").Visible = False
        'dgv.Columns("Customer_Name").Visible = False

        dgv.Columns("payment_Date").Visible = False
        ' dgv.Columns("InvoicePD_Qty").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgv.Columns("payment_invoiceNo").HeaderText = "رقم الفاتوره"
        dgv.Columns("AccountSub_Name").HeaderText = "المصروف"
        'dgv.Columns("InvoicePD_price_Item").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgv.Columns("AccountSub_Code").Visible = False
        '  dgv.Columns("InvoicePD_Discount").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgv.Columns("Department_ID").Visible = False
        dgv.Columns("Department_Name").HeaderText = "القســـم"
        dgv.Columns("Store_Name").HeaderText = "الفـــرع"

        ' dgv.Columns("InvoicePD_Discount").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        '  dgv.Columns("InvoicePD_Total_Price").Width = 120
        dgv.Columns("Store_IDs").Visible = False
        dgv.Columns("Store_ID").Visible = False
        dgv.Columns("payment_Note").Visible = False

        'dgv.Columns("Items_NameAR").HeaderText = "اسم الصنف"
        'dgv.Columns("Unit_ID").Visible = False
        'dgv.Columns("unit_name").HeaderText = "الوحده"
        'dgv.Columns("Customer_Note").Visible = False
        'dgv.Columns("Customer_Qty").HeaderText = "الكميه"
        'dgv.Columns("Customer_price").HeaderText = "السعر"
        'dgv.Columns("Items_Cost").HeaderText = "التكلفة"
        'dgv.Columns("ISActive").Visible = False

        'Column Celles Disign
        'dgv.Columns("ID_InvoiceByeDetils").DefaultCellStyle.BackColor = Color.White
        'dgv.Columns("ID_Items_").DefaultCellStyle.BackColor = Color.White
        'dgv.Columns("ID_Invoice_").DefaultCellStyle.BackColor = Color.White
        'dgv.Columns("InvoiceBD_Qty").DefaultCellStyle.BackColor = Color.White
        'dgv.Columns("InvoiceBD_price_Item").DefaultCellStyle.BackColor = Color.White
        'dgv.Columns("InvoiceBD_Discount").DefaultCellStyle.BackColor = Color.White
        'dgv.Columns("InvoiceBD_Total_Price").DefaultCellStyle.BackColor = Color.White
        'dgv.Columns("InvoiceBD_UserName").DefaultCellStyle.BackColor = Color.White
        dgv.DefaultCellStyle.Font =
         New Font("Cairo", 9, FontStyle.Bold)
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgv.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal
        dgv.DefaultCellStyle.SelectionBackColor = Color.Black
        dgv.DefaultCellStyle.SelectionForeColor = Color.White
        dgv.RowHeadersVisible = False
        ' dgv.AutoResizeColumns()
        dgv.AutoResizeRows()
        dgv.AutoSize = False
        dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dgv.CellBorderStyle = DataGridViewCellBorderStyle.Sunken
        dgv.AllowUserToAddRows = False
        dgv.AllowUserToDeleteRows = False
        dgv.AllowUserToResizeRows = False


    End Sub

    Public Shared Sub Com_Payment(com As Guna2ComboBox)
        Dim dt As DataTable = sqlMethod.ExecuteSelectData("Accounts.pro_View_Payments")
        ' إعداد الإجراء المخزن
        com.DataSource = dt
        com.DisplayMember = "AccountSub_Name"
        com.ValueMember = "AccountSub_Code"
        ' التحقق من النتيجة

    End Sub
    ''' <summary>
    ''' فتح قيد جديد
    ''' </summary>
    ''' <returns></returns>
    Shared Function New_Acc_Code() As Integer
        New_Acc_Code = sqlMethod.ExecuteScalarOutput("Accounts.funNew_Function_NO", "@function_Code")
    End Function
End Class
