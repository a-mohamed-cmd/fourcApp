Imports Guna.UI2.WinForms
Imports System.Security.Cryptography.X509Certificates
Imports Microsoft.Data.SqlClient

Public Class Purchase
    ' المتغيرات الخاصة
    Private _purchase_ID As Integer
    Private _AccFunction_Code As Integer
    Private _supplier As New Supplier
    Private _purchase_invoiceDate As Date
    Private _purchase_invoiceNo As String
    Private _Department As New Department
    Private _store As New Store
    Private _Items As New Items
    Private _Unit As New Unit
    Private _purchase_Note As String
    Private _purchase_Qty As Integer
    Private _purchase_price As Decimal
    Private _Items_Cost As Decimal
    Private _ISActive As Boolean
    Private _TotalInvoice As Decimal = 0
    Private _dv As New DataView
    Private _Cur As CurrencyManager
#Region "Properties"
    Public Property Purchase_ID As Integer
        Get
            Return _purchase_ID
        End Get
        Set(value As Integer)
            _purchase_ID = value
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



    Public Property Purchase_InvoiceDate As Date
        Get
            Return _purchase_invoiceDate
        End Get
        Set(value As Date)
            _purchase_invoiceDate = value
        End Set
    End Property

    Public Property Purchase_InvoiceNo As String
        Get
            Return _purchase_invoiceNo
        End Get
        Set(value As String)
            _purchase_invoiceNo = value
        End Set
    End Property



    Public Property Purchase_Note As String
        Get
            Return _purchase_Note
        End Get
        Set(value As String)
            _purchase_Note = value
        End Set
    End Property

    Public Property Purchase_Qty As Integer
        Get
            Return _purchase_Qty
        End Get
        Set(value As Integer)
            _purchase_Qty = value
        End Set
    End Property

    Public Property Purchase_Price As Decimal
        Get
            Return _purchase_price
        End Get
        Set(value As Decimal)
            _purchase_price = value
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

    Public Property Supplier As Supplier
        Get
            Return _supplier
        End Get
        Set(value As Supplier)
            _supplier = value
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

    Public Property Unit As Unit
        Get
            Return _Unit
        End Get
        Set(value As Unit)
            _Unit = value
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
#End Region

#Region "Constructor"
    ' المُنشئ لتعبئة البيانات عند إنشاء الكائن
    Public Sub New(Optional purchaseID As Integer = 0,
                   Optional accFunctionCode As Integer = 0,
                   Optional supplierID As Integer = 0,
                   Optional purchaseInvoiceDate As Date = #1/1/1900#,
                   Optional purchaseInvoiceNo As String = "",
                   Optional departmentID As Integer = 0,
                   Optional itemsID As Integer = 0,
                   Optional unitID As Integer = 0,
                   Optional purchaseNote As String = "",
                   Optional purchaseQty As Integer = 0,
                   Optional purchasePrice As Decimal = 0D,
                   Optional itemsCost As Decimal = 0D,
                   Optional isActive As Boolean = True)

        _purchase_ID = purchaseID
        _AccFunction_Code = accFunctionCode
        _supplier.Supplier_ID = supplierID
        _purchase_invoiceDate = purchaseInvoiceDate
        _purchase_invoiceNo = purchaseInvoiceNo
        _Department.Department_ID = departmentID
        _Items.Items_ID = itemsID
        _Unit.Unit_ID = unitID
        _purchase_Note = purchaseNote
        _purchase_Qty = purchaseQty
        _purchase_price = purchasePrice
        _Items_Cost = itemsCost
        _ISActive = isActive
    End Sub
#End Region
    ''' <summary>
    ''' استقبال البيانات من interfase
    ''' </summary>
    ''' <param name="accFunction_Code"></param>
    ''' <param name="supplier_ID"></param>
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
                       Optional supplier_ID As Integer = 0,
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
        _supplier.Supplier_ID = supplier_ID

        _purchase_invoiceDate = invoiceDate
        _purchase_invoiceNo = invoiceNo
        _Department.Department_ID = department_ID
        _Items.Items_Code = items_ID
        _Unit.Unit_ID = unit_ID
        _purchase_Note = note
        _purchase_Qty = qty
        _purchase_price = price
        _ISActive = isActive

    End Sub
    ''' <summary>
    ''' استقبال البيانات من row في هيئه current manager
    ''' </summary>
    ''' <param name="cur1"></param>
    Sub Load_data_invoice_Code(cur1 As CurrencyManager, frm As Control)
        Dv = View_PurchaseInvoice_Code(cur1).DefaultView()
        Cur = CType(frm.BindingContext(Dv), CurrencyManager)
    End Sub

    ''' <summary>
    ''' عرض بيانات row
    ''' </summary>
    ''' <param name="cur"></param>
    Sub Load_Data(cur As CurrencyManager)

        _purchase_ID = cur.Current("purchase_ID")
        _AccFunction_Code = cur.Current("AccFunction_Code")
        _supplier.Supplier_ID = cur.Current("supplier_ID")
        _supplier.Supplier_Name = cur.Current("supplier_Name")
        _purchase_invoiceDate = If(IsDBNull(cur.Current("purchase_invoiceDate")), Nothing, cur.Current("purchase_invoiceDate"))
        _purchase_invoiceNo = If(IsDBNull(cur.Current("purchase_invoiceNo")), Nothing, cur.Current("purchase_invoiceNo"))
        _Department.Department_ID = If(IsDBNull(cur.Current("Department_ID")), Nothing, cur.Current("Department_ID"))
        _Department.Store_ID = If(IsDBNull(cur.Current("Store_ID")), Nothing, cur.Current("Store_ID"))
        _Items.Items_ID = cur.Current("Items_ID")
        _Items.Items_Code = cur.Current("Items_Code")
        _Items.Items_NameAR = If(IsDBNull(cur.Current("Items_NameAR")), Nothing, cur.Current("Items_NameAR"))
        _Unit.Unit_ID = cur.Current("Unit_ID")
        _purchase_Note = If(IsDBNull(cur.Current("purchase_Note")), Nothing, cur.Current("purchase_Note"))
        _purchase_Qty = If(IsDBNull(cur.Current("purchase_Qty")), 0, cur.Current("purchase_Qty"))
        _purchase_price = If(IsDBNull(cur.Current("purchase_price")), 0D, cur.Current("purchase_price"))
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
        txt(1).Text = Supplier.Supplier_ID
        txt(2).Text = Supplier.Supplier_Name
        dateinvoice.Value = Purchase_InvoiceDate
        txt(3).Text = Purchase_InvoiceNo
        com(0).SelectedValue = Department.Department_ID
        com(1).SelectedValue = Department.Store_ID
        txt(4).Text = Items.Items_Code
        txt(5).Text = Items.Items_NameAR
        com(2).SelectedValue = Unit.Unit_ID
        txt(6).Text = Purchase_Note
        txt(7).Text = Purchase_Qty
        txt(8).Text = Purchase_Price

        txt(9).Text = (Purchase_Qty * Purchase_Price)
        txt(10).Text = Dv.Count
        txt(11).Text = Dv.Table.Compute("sum(purchase_Qty)", Nothing).ToString()

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
            If Not IsDBNull(row("purchase_Qty")) AndAlso Not IsDBNull(row("purchase_price")) Then
                Total_Price += Convert.ToDecimal(row("purchase_Qty")) * Convert.ToDecimal(row("purchase_price"))
            End If
        Next
        TotalInvoice = Total_Price
        Return Total_Price


    End Function
#Region "Methods"
    ''' <summary>
    ''' تنفيذ الإجراء المخزن لإضافة شراء جديد
    ''' </summary>
    ''' <returns>عدد السجلات المتأثرة (عادة 1 إذا تم الحفظ بنجاح)</returns>
    Public Function SaveNewPurchase() As Integer
        Dim parameters As New List(Of SqlParameter) From {
            New SqlParameter("@AccFunction_Code", SqlDbType.Int) With {.Value = AccFunction_Code},
            New SqlParameter("@supplier_ID", SqlDbType.Int) With {.Value = Supplier.Supplier_ID},
            New SqlParameter("@purchase_invoiceDate", SqlDbType.Date) With {.Value = Purchase_InvoiceDate},
            New SqlParameter("@purchase_invoiceNo", SqlDbType.NVarChar, 10) With {.Value = Purchase_InvoiceNo},
            New SqlParameter("@Department_ID", SqlDbType.Int) With {.Value = Department.Department_ID},
            New SqlParameter("@Items_ID", SqlDbType.Int) With {.Value = Items.Items_ID},
            New SqlParameter("@Unit_ID", SqlDbType.Int) With {.Value = Unit.Unit_ID},
            New SqlParameter("@purchase_Note", SqlDbType.NVarChar, 100) With {.Value = If(Purchase_Note, DBNull.Value)},
            New SqlParameter("@purchase_Qty", SqlDbType.Int) With {.Value = Purchase_Qty},
            New SqlParameter("@purchase_price", SqlDbType.Decimal) With {.Value = Purchase_Price},
            New SqlParameter("@Items_Cost", SqlDbType.Decimal) With {.Value = If(Items_Cost <> Nothing, Items_Cost, DBNull.Value)},
            New SqlParameter("@ISActive", SqlDbType.Bit) With {.Value = ISActive}
        }

        Dim result As Integer = sqlMethod.ExecuteStoredProcedure("Invoices.AddNew_purchase", parameters.ToArray())
        If result > 0 Then
            MsgBox("تم إضافة الشراء بنجاح.")
        Else
            MsgBox("حدث خطأ في إضافة الشراء.")
        End If
        Return result
    End Function

    ''' <summary>
    ''' تنفيذ الإجراء المخزن لتعديل شراء
    ''' </summary>
    ''' <returns>عدد السجلات المتأثرة (عادة 1 إذا تم التعديل بنجاح)</returns>
    Public Function UpdatePurchase() As Integer
        Dim parameters As New List(Of SqlParameter) From {
            New SqlParameter("@AccFunction_Code", SqlDbType.Int) With {.Value = AccFunction_Code},
            New SqlParameter("@supplier_ID", SqlDbType.Int) With {.Value = Supplier.Supplier_ID},
            New SqlParameter("@purchase_invoiceDate", SqlDbType.Date) With {.Value = Purchase_InvoiceDate},
            New SqlParameter("@purchase_invoiceNo", SqlDbType.NVarChar, 10) With {.Value = Purchase_InvoiceNo},
            New SqlParameter("@Department_ID", SqlDbType.Int) With {.Value = Department.Department_ID},
            New SqlParameter("@Items_ID", SqlDbType.Int) With {.Value = Items.Items_ID},
            New SqlParameter("@Unit_ID", SqlDbType.Int) With {.Value = Unit.Unit_ID},
            New SqlParameter("@purchase_Note", SqlDbType.NVarChar, 100) With {.Value = If(Purchase_Note, DBNull.Value)},
            New SqlParameter("@purchase_Qty", SqlDbType.Int) With {.Value = Purchase_Qty},
            New SqlParameter("@purchase_price", SqlDbType.Decimal) With {.Value = Purchase_Price},
            New SqlParameter("@purchase_ID", SqlDbType.Int) With {.Value = Purchase_ID}
        }

        Dim result As Integer = sqlMethod.ExecuteStoredProcedure("Invoices.Update_Purchase", parameters.ToArray())
        If result > 0 Then
            MsgBox("تم تعديل الشراء بنجاح.")
        Else
            MsgBox("حدث خطأ في تعديل الشراء.")
        End If
        Return result
    End Function

    ''' <summary>
    ''' تنفيذ الإجراء  لعرض جميع ارقام قيود الفواتير
    ''' </summary>

    Public Function View_PurchaseInvoice() As DataTable

        ' إعداد الإجراء المخزن
        View_PurchaseInvoice = sqlMethod.ExecuteSelectData("Invoices.pro_View_PurchaseInvoics_Code")
        ' التحقق من النتيجة

    End Function
    ''' <summary>
    ''' عرض بيانات برقم القيد
    ''' </summary>
    Private Function View_PurchaseInvoice_Code(cur As CurrencyManager) As DataTable
        AccFunction_Code = cur.Current("AccFunction_Code")
        Dim parameters As New List(Of SqlParameter) From {
            New SqlParameter("@AccFunction_code", SqlDbType.Int) With {.Value = AccFunction_Code}
        }

        ' إعداد الإجراء المخزن
        View_PurchaseInvoice_Code = sqlMethod.ExecuteSelectData("Invoices.pro_View_Purchase_Code", parameters.ToArray())
        ' التحقق من النتيجة

    End Function
    ''' <summary>
    ''' تنفيذ الإجراء المخزن لحذف الشراء
    ''' </summary>
    ''' <returns>عدد السجلات المتأثرة (عادة 1 إذا تم التعديل بنجاح)</returns>
    Public Function Deletepurchase() As Integer
        Dim parameters As New List(Of SqlParameter) From {
            New SqlParameter("@Purchase_ID", SqlDbType.Int) With {.Value = Purchase_ID}
        }

        Dim result As Integer = sqlMethod.ExecuteStoredProcedure("invoices.Delete_PurchaseInvoice", parameters.ToArray())
        If result > 0 Then
            MsgBox("تم حذف الشراء بنجاح.")
        Else
            MsgBox("حدث خطأ في حذف الشراء.")
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
        dgv.Columns("purchase_ID").Visible = False
        dgv.Columns("AccFunction_Code").Visible = False
        ' dgv.Columns("ID_Items_").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgv.Columns("supplier_ID").Visible = False
        dgv.Columns("supplier_Name").Visible = False

        dgv.Columns("purchase_invoiceDate").Visible = False
        ' dgv.Columns("InvoicePD_Qty").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgv.Columns("purchase_invoiceNo").HeaderText = "رقم الفاتوره"
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
        dgv.Columns("purchase_Note").Visible = False
        dgv.Columns("purchase_Qty").HeaderText = "الكميه"
        dgv.Columns("purchase_price").HeaderText = "السعر"
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
