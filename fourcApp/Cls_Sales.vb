Imports Guna.UI2.WinForms
Imports Microsoft.Data.SqlClient

Public Class Sales
    ' المتغيرات الخاصة
    Private _sales_ID As Integer
    Private _AccFunction_Code As Integer
    Private _customer As New Customer

    Private _Customer_invoiceDate As Date
    Private _Customer_invoiceNo As String
    Private _Department As New Department
    Private _store As New Store
    Private _Items As New Items
    Private _Unit As New Unit
    Private _Customer_Note As String
    Private _Customer_Qty As Integer
    Private _Customer_price As Decimal
    Private _Items_Cost As Decimal
    Private _ISActive As Boolean
    Private _TotalInvoice As Decimal = 0
    Private _dv As New DataView
    Private _Cur As CurrencyManager

#Region "Properties"
    Public Property Sales_ID As Integer
        Get
            Return _sales_ID
        End Get
        Set(value As Integer)
            _sales_ID = value
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



    Public Property Customer_InvoiceDate As Date
        Get
            Return _Customer_invoiceDate
        End Get
        Set(value As Date)
            _Customer_invoiceDate = value
        End Set
    End Property

    Public Property Customer_InvoiceNo As String
        Get
            Return _Customer_invoiceNo
        End Get
        Set(value As String)
            _Customer_invoiceNo = value
        End Set
    End Property





    Public Property Customer_Note As String
        Get
            Return _Customer_Note
        End Get
        Set(value As String)
            _Customer_Note = value
        End Set
    End Property

    Public Property Customer_Qty As Integer
        Get
            Return _Customer_Qty
        End Get
        Set(value As Integer)
            _Customer_Qty = value
        End Set
    End Property

    Public Property Customer_Price As Decimal
        Get
            Return _Customer_price
        End Get
        Set(value As Decimal)
            _Customer_price = value
        End Set
    End Property

    Public Property Items_Cost As Decimal
        Get
            Return _Items_Cost
        End Get
        Set(value As Decimal)
            _Items_Cost = value
        End Set
    End Property

    Public Property ISActive As Boolean
        Get
            Return _ISActive
        End Get
        Set(value As Boolean)
            _ISActive = value
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


    Public Property Customer As Customer
        Get
            Return _customer
        End Get
        Set(value As Customer)
            _customer = value
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

    Public Property Items As Items
        Get
            Return _Items
        End Get
        Set(value As Items)
            _Items = value
        End Set
    End Property

    Public Property Unit As Unit
        Get
            Return _Unit
        End Get
        Set(value As Unit)
            _Unit = value
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
#End Region

#Region "Constructor"
    ' المُنشئ لتعبئة البيانات عند إنشاء الكائن
    Public Sub New(Optional salesID As Integer = 0,
                   Optional accFunctionCode As Integer = 0,
                   Optional customerID As Integer = 0,
                   Optional customerInvoiceDate As Date = #1/1/1900#,
                   Optional customerInvoiceNo As String = "",
                   Optional departmentID As Integer = 0,
                   Optional itemsID As Integer = 0,
                   Optional unitID As Integer = 0,
                   Optional customerNote As String = "",
                   Optional customerQty As Integer = 0,
                   Optional customerPrice As Decimal = 0D,
                   Optional itemsCost As Decimal = 0D,
                   Optional isActive As Boolean = True)

        _sales_ID = salesID
        _AccFunction_Code = accFunctionCode
        _customer.Customer_ID = customerID
        _Customer_invoiceDate = customerInvoiceDate
        _Customer_invoiceNo = customerInvoiceNo
        _Department.Department_ID = departmentID
        _Items.Items_ID = itemsID
        _Unit.Unit_ID = unitID
        _Customer_Note = customerNote
        _Customer_Qty = customerQty
        _Customer_price = customerPrice
        _Items_Cost = itemsCost
        _ISActive = isActive
    End Sub
#End Region


    ''' <summary>
    ''' استقبال البيانات من interfase
    ''' </summary>
    ''' <param name="accFunction_Code"></param>
    ''' <param name="customer_ID"></param>
    ''' <param name="invoiceDate"></param>
    ''' <param name="invoiceNo"></param>
    ''' <param name="department_ID"></param>
    ''' <param name="items_ID"></param>
    ''' <param name="unit_ID"></param>
    ''' <param name="note"></param>
    ''' <param name="qty"></param>
    ''' <param name="price"></param>
    ''' <param name="isActive"></param>
    Public Sub import_Data(
                       Optional accFunction_Code As Integer = 0,
                       Optional customer_ID As Integer = 0,
                       Optional invoiceDate As Date = Nothing,
                       Optional invoiceNo As String = "",
                       Optional department_ID As Integer = 0,
                       Optional items_ID As String = "",
                       Optional unit_ID As Integer = 0,
                       Optional note As String = "",
                       Optional qty As Integer = 0,
                       Optional price As Decimal = 0,
                       Optional isActive As Boolean = True)


        _AccFunction_Code = accFunction_Code
        _customer.Customer_ID = customer_ID

        _Customer_invoiceDate = invoiceDate
        _Customer_invoiceNo = invoiceNo
        Department.Department_ID = department_ID
        Items.Items_Code = items_ID
        Unit.Unit_ID = unit_ID
        _Customer_Note = note
        _Customer_Qty = qty
        _Customer_price = price
        _ISActive = isActive

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

        _sales_ID = cur.Current("sales_ID")
        _AccFunction_Code = cur.Current("AccFunction_Code")
        _customer.Customer_ID = cur.Current("Customer_ID")
        _customer.Customer_Name = cur.Current("Customer_Name")
        _Customer_invoiceDate = If(IsDBNull(cur.Current("Customer_invoiceDate")), Nothing, cur.Current("Customer_invoiceDate"))
        _Customer_invoiceNo = If(IsDBNull(cur.Current("Customer_invoiceNo")), Nothing, cur.Current("Customer_invoiceNo"))
        Department.Department_ID = If(IsDBNull(cur.Current("Department_ID")), Nothing, cur.Current("Department_ID"))
        Department.Store_ID = If(IsDBNull(cur.Current("Store_ID")), Nothing, cur.Current("Store_ID"))
        Items.Items_ID = cur.Current("Items_ID")
        Items.Items_Code = cur.Current("Items_Code")
        Items.Items_NameAR = If(IsDBNull(cur.Current("Items_NameAR")), Nothing, cur.Current("Items_NameAR"))
        Unit.Unit_ID = cur.Current("Unit_ID")
        _Customer_Note = If(IsDBNull(cur.Current("Customer_Note")), Nothing, cur.Current("Customer_Note"))
        _Customer_Qty = If(IsDBNull(cur.Current("Customer_Qty")), 0, cur.Current("Customer_Qty"))
        _Customer_price = If(IsDBNull(cur.Current("Customer_price")), 0D, cur.Current("Customer_price"))
        _ISActive = cur.Current("ISActive")
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
        txt(1).Text = Customer.Customer_ID
        txt(2).Text = Customer.Customer_Name
        dateinvoice.Value = Customer_InvoiceDate
        txt(3).Text = Customer_InvoiceNo
        com(0).SelectedValue = Department.Department_ID
        com(1).SelectedValue = Department.Store_ID
        txt(4).Text = Items.Items_Code
        txt(5).Text = Items.Items_NameAR
        com(2).SelectedValue = Unit.Unit_ID
        txt(6).Text = Customer_Note
        txt(7).Text = Customer_Qty
        txt(8).Text = Customer_Price

        txt(9).Text = (Customer_Qty * Customer_Price)
        txt(10).Text = Dv.Count
        txt(11).Text = Dv.Table.Compute("sum(Customer_Qty)", Nothing).ToString()

        txt(12).Text = Total_Price.ToString("N2")  ' صيغة جميلة بنتيجتين عشريتين
        txt(13).Text = Items.BalanceOfItemInDeprartment(item_ID:=Items.Items_ID,
Deprartment:=Department.Department_ID)
    End Sub
    ''' <summary>
    ''' الحصول علي مجموع الفاتوره
    ''' </summary>
    ''' <returns></returns>
    Private Function Total_Price() As Decimal



        For Each row As DataRowView In Dv
            If Not IsDBNull(row("Customer_Qty")) AndAlso Not IsDBNull(row("Customer_Price")) Then
                Total_Price += Convert.ToDecimal(row("Customer_Qty")) * Convert.ToDecimal(row("Customer_Price"))
            End If
        Next
        TotalInvoice = Total_Price
        Return Total_Price


    End Function
#Region "Methods"
    ''' <summary>
    ''' تنفيذ الإجراء المخزن لإضافة بيع جديد
    ''' </summary>
    ''' <returns>عدد السجلات المتأثرة (عادة 1 إذا تم الحفظ بنجاح)</returns>
    Public Function SaveNewSale() As Integer
        Dim parameters As New List(Of SqlParameter) From {
            New SqlParameter("@AccFunction_Code", SqlDbType.Int) With {.Value = AccFunction_Code},
            New SqlParameter("@Customer_ID", SqlDbType.Int) With {.Value = Customer.Customer_ID},
            New SqlParameter("@Customer_invoiceDate", SqlDbType.Date) With {.Value = Customer_InvoiceDate},
            New SqlParameter("@Customer_invoiceNo", SqlDbType.NVarChar, 10) With {.Value = Customer_InvoiceNo},
            New SqlParameter("@Department_ID", SqlDbType.Int) With {.Value = Department.Department_ID},
            New SqlParameter("@Items_ID", SqlDbType.Int) With {.Value = Items.Items_ID},
            New SqlParameter("@Unit_ID", SqlDbType.Int) With {.Value = Unit.Unit_ID},
            New SqlParameter("@Customer_Note", SqlDbType.NVarChar, 100) With {.Value = If(Customer_Note, DBNull.Value)},
            New SqlParameter("@Customer_Qty", SqlDbType.Int) With {.Value = Customer_Qty},
            New SqlParameter("@Customer_price", SqlDbType.Decimal) With {.Value = Customer_Price},
            New SqlParameter("@Items_Cost", SqlDbType.Decimal) With {.Value = If(Items_Cost <> Nothing, Items_Cost, DBNull.Value)},
            New SqlParameter("@ISActive", SqlDbType.Bit) With {.Value = ISActive}
        }

        Dim result As Integer = sqlMethod.ExecuteStoredProcedure("Invoices.AddNew_sales", parameters.ToArray())
        If result > 0 Then
            MsgBox("تم إضافة البيع بنجاح.")
        Else
            MsgBox("حدث خطأ في إضافة البيع.")
        End If
        Return result
    End Function

    ''' <summary>
    ''' تنفيذ الإجراء المخزن لتعديل بيع
    ''' </summary>
    ''' <returns>عدد السجلات المتأثرة (عادة 1 إذا تم التعديل بنجاح)</returns>
    Public Function UpdateSale() As Integer
        Dim parameters As New List(Of SqlParameter) From {
           New SqlParameter("@AccFunction_Code", SqlDbType.Int) With {.Value = AccFunction_Code},
            New SqlParameter("@Customer_ID", SqlDbType.Int) With {.Value = Customer.Customer_ID},
            New SqlParameter("@Customer_invoiceDate", SqlDbType.Date) With {.Value = Customer_InvoiceDate},
            New SqlParameter("@Customer_invoiceNo", SqlDbType.NVarChar, 10) With {.Value = Customer_InvoiceNo},
            New SqlParameter("@Department_ID", SqlDbType.Int) With {.Value = Department.Department_ID},
            New SqlParameter("@Items_ID", SqlDbType.Int) With {.Value = Items.Items_ID},
            New SqlParameter("@Unit_ID", SqlDbType.Int) With {.Value = Unit.Unit_ID},
            New SqlParameter("@Customer_Note", SqlDbType.NVarChar, 100) With {.Value = If(Customer_Note, DBNull.Value)},
            New SqlParameter("@Customer_Qty", SqlDbType.Int) With {.Value = Customer_Qty},
            New SqlParameter("@Customer_price", SqlDbType.Decimal) With {.Value = Customer_Price},
            New SqlParameter("@Items_Cost", SqlDbType.Decimal) With {.Value = If(Items_Cost <> Nothing, Items_Cost, DBNull.Value)},
            New SqlParameter("@ISActive", SqlDbType.Bit) With {.Value = ISActive},
            New SqlParameter("@Sales_ID", SqlDbType.Int) With {.Value = Sales_ID}
        }

        Dim result As Integer = sqlMethod.ExecuteStoredProcedure("Invoices.Update_Sales", parameters.ToArray())
        If result > 0 Then
            MsgBox("تم تعديل البيع بنجاح.")
        Else
            MsgBox("حدث خطأ في تعديل البيع.")
        End If
        Return result
    End Function
    ''' <summary>
    ''' تنفيذ الإجراء  لعرض جميع ارقام قيود الفواتير
    ''' </summary>

    Public Function View_SalesInvoice() As DataTable

        ' إعداد الإجراء المخزن
        View_SalesInvoice = sqlMethod.ExecuteSelectData("Invoices.pro_View_SalesInvoics_Code")
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
        View_SalesInvoice_Code = sqlMethod.ExecuteSelectData("Invoices.pro_View_Sales_Code", parameters.ToArray())
        ' التحقق من النتيجة

    End Function
    ''' <summary>
    ''' تنفيذ الإجراء المخزن لحذف البيع
    ''' </summary>
    ''' <returns>عدد السجلات المتأثرة (عادة 1 إذا تم التعديل بنجاح)</returns>
    Public Function DeleteSale() As Integer
        Dim parameters As New List(Of SqlParameter) From {
            New SqlParameter("@sales_ID", SqlDbType.Int) With {.Value = Sales_ID}
        }

        Dim result As Integer = sqlMethod.ExecuteStoredProcedure("invoices.Delete_salesInvoice", parameters.ToArray())
        If result > 0 Then
            MsgBox("تم حذف البيع بنجاح.")
        Else
            MsgBox("حدث خطأ في حذف البيع.")
        End If
        Return result
    End Function
#End Region
    ''' <summary>
    ''' تصميم datagridview
    ''' </summary>
    ''' <param name="dgv"></param>
    Public Sub Dgv_Design(dgv As Guna2DataGridView)
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
        dgv.Columns("sales_ID").Visible = False
        dgv.Columns("AccFunction_Code").Visible = False
        ' dgv.Columns("ID_Items_").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgv.Columns("Customer_ID").Visible = False
        dgv.Columns("Customer_Name").Visible = False

        dgv.Columns("Customer_invoiceDate").Visible = False
        ' dgv.Columns("InvoicePD_Qty").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgv.Columns("Customer_invoiceNo").HeaderText = "رقم الفاتوره"
        'dgv.Columns("InvoicePD_price_Item").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgv.Columns("Department_ID").Visible = False
        '  dgv.Columns("InvoicePD_Discount").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgv.Columns("Store_ID").Visible = False
        ' dgv.Columns("InvoicePD_Discount").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        '  dgv.Columns("InvoicePD_Total_Price").Width = 120
        dgv.Columns("Items_ID").Visible = False
        dgv.Columns("Items_Code").HeaderText = "كود الصنف"
        dgv.Columns("Items_NameAR").HeaderText = "اسم الصنف"
        dgv.Columns("Unit_ID").Visible = False
        dgv.Columns("unit_name").HeaderText = "الوحده"
        dgv.Columns("Customer_Note").Visible = False
        dgv.Columns("Customer_Qty").HeaderText = "الكميه"
        dgv.Columns("Customer_price").HeaderText = "السعر"
        dgv.Columns("Items_Cost").HeaderText = "التكلفة"
        dgv.Columns("ISActive").Visible = False

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
    ''' <summary>
    ''' فتح قيد جديد
    ''' </summary>
    ''' <returns></returns>
    Function New_Acc_Code() As Integer
        New_Acc_Code = sqlMethod.ExecuteScalarOutput("Accounts.funNew_Function_NO", "@function_Code")
    End Function
End Class
