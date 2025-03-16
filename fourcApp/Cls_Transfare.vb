Imports Guna.UI2.WinForms
Imports Microsoft.Data.SqlClient
Imports Microsoft.Identity.Client.Cache

Public Class Transfer
    ' المتغيرات الخاصة
    Private _Transfar_ID As Integer
    Private _AccFunction_Code As Integer
    Private _Transfar_invoiceDate As Date
    Private _Transfar_invoiceNo As String
    Private _Department_out As New Department
    Private _Department_In As New Department

    Private _Store_Out As New Store
    Private _Store_IN As New Store
    Private _Items As New Items
    Private _Unit As New Unit
    Private _Transfar_note As String
    Private _Transfar_Qty As Integer
    Private _Transfar_cost As Decimal
    Private _ISActive As Boolean
    Private _TotalInvoice As Decimal = 0
    Private _dv As New DataView
    Private _Cur As CurrencyManager
#Region "Properties"
    Public Property Transfar_ID As Integer
        Get
            Return _Transfar_ID
        End Get
        Set(value As Integer)
            _Transfar_ID = value
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

    Public Property Transfar_InvoiceDate As Date
        Get
            Return _Transfar_invoiceDate
        End Get
        Set(value As Date)
            _Transfar_invoiceDate = value
        End Set
    End Property

    Public Property Transfar_InvoiceNo As String
        Get
            Return _Transfar_invoiceNo
        End Get
        Set(value As String)
            _Transfar_invoiceNo = value
        End Set
    End Property


    Public Property Transfar_Note As String
        Get
            Return _Transfar_note
        End Get
        Set(value As String)
            _Transfar_note = value
        End Set
    End Property

    Public Property Transfar_Qty As Integer
        Get
            Return _Transfar_Qty
        End Get
        Set(value As Integer)
            _Transfar_Qty = value
        End Set
    End Property

    Public Property Transfar_Cost As Decimal
        Get
            Return _Transfar_cost
        End Get
        Set(value As Decimal)
            _Transfar_cost = value
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

    Public Property Department_out As Department
        Get
            Return _Department_out
        End Get
        Set(value As Department)
            _Department_out = value
        End Set
    End Property

    Public Property Department_In As Department
        Get
            Return _Department_In
        End Get
        Set(value As Department)
            _Department_In = value
        End Set
    End Property

    Public Property Store_Out As Store
        Get
            Return _Store_Out
        End Get
        Set(value As Store)
            _Store_Out = value
        End Set
    End Property

    Public Property Store_IN As Store
        Get
            Return _Store_IN
        End Get
        Set(value As Store)
            _Store_IN = value
        End Set
    End Property
#End Region

#Region "Constructor"
    ' المُنشئ لتعبئة البيانات عند إنشاء الكائن
    Public Sub New(Optional transfarID As Integer = 0,
                   Optional accFunctionCode As Integer = 0,
                   Optional transfarInvoiceDate As Date = #1/1/1900#,
                   Optional transfarInvoiceNo As String = "",
                   Optional Department_In As Integer = 0,
                   Optional Department_Out As Integer = 0,
                   Optional store_Out As Integer = 0,
                   Optional store_In As Integer = 0,
                   Optional itemsID As Integer = 0,
                   Optional unitID As Integer = 0,
                   Optional transfarNote As String = "",
                   Optional transfarQty As Integer = 0,
                   Optional transfarCost As Decimal = 0D,
                   Optional isActive As Boolean = True)

        _Transfar_ID = transfarID
        _AccFunction_Code = accFunctionCode
        _Transfar_invoiceDate = transfarInvoiceDate
        _Transfar_invoiceNo = transfarInvoiceNo
        _Department_In.Department_ID = Department_In
        _Department_out.Department_ID = Department_Out
        _Store_Out.Store_ID = store_Out
        _Store_IN.Store_ID = store_In
        _Items.Items_ID = itemsID
        _Unit.Unit_ID = unitID
        _Transfar_note = transfarNote
        _Transfar_Qty = transfarQty
        _Transfar_cost = transfarCost
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
                   Optional accFunctionCode As Integer = 0,
                   Optional transfarInvoiceDate As Date = #1/1/1900#,
                   Optional transfarInvoiceNo As String = "",
                   Optional Department_In As Integer = 0,
                   Optional Department_Out As Integer = 0,
                   Optional store_Out As Integer = 0,
                   Optional store_In As Integer = 0,
                   Optional itemsID As String = "",
                   Optional unitID As Integer = 0,
                   Optional transfarNote As String = "",
                   Optional transfarQty As Integer = 0,
                   Optional transfarCost As Decimal = 0D,
                   Optional isActive As Boolean = True)


        _AccFunction_Code = accFunctionCode
        _Transfar_invoiceDate = transfarInvoiceDate
        _Transfar_invoiceNo = transfarInvoiceNo
        _Department_In.Department_ID = Department_In
        _Department_out.Department_ID = Department_Out
        _Store_Out.Store_ID = store_Out
        _Store_IN.Store_ID = store_In
        _Items.Items_Code = itemsID
        _Unit.Unit_ID = unitID
        _Transfar_note = transfarNote
        _Transfar_Qty = transfarQty
        _Transfar_cost = transfarCost
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

        _Transfar_ID = cur.Current("Transfar_ID")
        _AccFunction_Code = cur.Current("AccFunction_Code")

        _Transfar_invoiceDate = If(IsDBNull(cur.Current("transfar_invoiceDate")), Nothing, cur.Current("transfar_invoiceDate"))
        _Transfar_invoiceNo = If(IsDBNull(cur.Current("Transfar_invoiceNo")), Nothing, cur.Current("Transfar_invoiceNo"))
        Department_out.Department_ID = If(IsDBNull(cur.Current("Department_out")), Nothing, cur.Current("Department_out"))
        Department_In.Department_ID = If(IsDBNull(cur.Current("Department_IDIN")), Nothing, cur.Current("Department_IDIN"))
        Store_Out.Store_ID = If(IsDBNull(cur.Current("store_out")), Nothing, cur.Current("store_out"))
        Store_IN.Store_ID = If(IsDBNull(cur.Current("store_In")), Nothing, cur.Current("store_In"))
        Items.Items_ID = cur.Current("Items_ID")
        Items.Items_Code = cur.Current("Items_Code")
        Items.Items_NameAR = If(IsDBNull(cur.Current("Items_NameAR")), Nothing, cur.Current("Items_NameAR"))
        Unit.Unit_ID = cur.Current("Unit_ID")
        _Transfar_note = If(IsDBNull(cur.Current("Transfar_note")), Nothing, cur.Current("Transfar_note"))
        _Transfar_Qty = If(IsDBNull(cur.Current("Transfar_Qty")), 0, cur.Current("Transfar_Qty"))
        _Transfar_cost = If(IsDBNull(cur.Current("Transfar_cost")), 0D, cur.Current("Transfar_cost"))
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
        txt(1).Text = Transfar_InvoiceNo
        txt(2).Text = Items.Items_Code
        dateinvoice.Value = Transfar_InvoiceDate
        txt(3).Text = Items.Items_NameAR
        com(0).SelectedValue = Department_out.Department_ID
        com(1).SelectedValue = Store_Out.Store_ID
        com(2).SelectedValue = Department_In.Department_ID
        com(3).SelectedValue = Store_IN.Store_ID
        txt(4).Text = Transfar_Note
        txt(5).Text = Transfar_Qty
        com(4).SelectedValue = Unit.Unit_ID
        txt(6).Text = Transfar_Cost
        txt(7).Text = (Transfar_Qty * Transfar_Cost)
        txt(8).Text = Dv.Count

        txt(9).Text = Dv.Table.Compute("sum(Transfar_Qty)", Nothing).ToString()
        txt(10).Text = Total_Price.ToString("N2")  ' صيغة جميلة بنتيجتين عشريتين
        txt(11).Text = Items.BalanceOfItemInDeprartment(item_ID:=Items.Items_ID,
Deprartment:=Department_out.Department_ID)

    End Sub
    ''' <summary>
    ''' الحصول علي مجموع الفاتوره
    ''' </summary>
    ''' <returns></returns>
    Private Function Total_Price() As Decimal



        For Each row As DataRowView In Dv
            If Not IsDBNull(row("Transfar_Qty")) AndAlso Not IsDBNull(row("Transfar_Cost")) Then
                Total_Price += Convert.ToDecimal(row("Transfar_Qty")) * Convert.ToDecimal(row("Transfar_Cost"))
            End If
        Next
        TotalInvoice = Total_Price
        Return Total_Price


    End Function

#Region "Methods"
    ''' <summary>
    ''' تنفيذ الإجراء المخزن لإضافة تحويل جديد
    ''' </summary>
    ''' <returns>عدد السجلات المتأثرة (عادة 1 إذا تم الحفظ بنجاح)</returns>
    Public Function SaveNewTransfer() As Integer
        Dim parameters As New List(Of SqlParameter) From {
            New SqlParameter("@AccFunction_Code", SqlDbType.Int) With {.Value = AccFunction_Code},
            New SqlParameter("@Transfar_invoiceDate", SqlDbType.Date) With {.Value = Transfar_InvoiceDate},
            New SqlParameter("@Transfar_invoiceNo", SqlDbType.NVarChar, 10) With {.Value = If(Transfar_InvoiceNo, DBNull.Value)},
            New SqlParameter("@Department_ID", SqlDbType.Int) With {.Value = Department_out.Department_ID},
            New SqlParameter("@Department_IDIN", SqlDbType.Int) With {.Value = Department_In.Department_ID},
            New SqlParameter("@Items_ID", SqlDbType.Int) With {.Value = Items.Items_ID},
            New SqlParameter("@Unit_ID", SqlDbType.Int) With {.Value = Unit.Unit_ID},
            New SqlParameter("@Transfar_note", SqlDbType.NVarChar, 200) With {.Value = If(Transfar_Note, DBNull.Value)},
            New SqlParameter("@Transfar_Qty", SqlDbType.Int) With {.Value = Transfar_Qty},
            New SqlParameter("@Transfar_cost", SqlDbType.Decimal) With {.Value = DBNull.Value},
            New SqlParameter("@ISActive", SqlDbType.Bit) With {.Value = ISActive}
        }

        Dim result As Integer = sqlMethod.ExecuteStoredProcedure("Invoices.AddNew_Transfar", parameters.ToArray())
        If result > 0 Then
            MsgBox("تم إضافة التحويل بنجاح.")
        Else
            MsgBox("حدث خطأ في إضافة التحويل.")
        End If
        Return result
    End Function

    ''' <summary>
    ''' تنفيذ الإجراء المخزن لتعديل تحويل
    ''' </summary>
    ''' <returns>عدد السجلات المتأثرة (عادة 1 إذا تم التعديل بنجاح)</returns>
    Public Function UpdateTransfer() As Integer
        Dim parameters As New List(Of SqlParameter) From {
             New SqlParameter("@AccFunction_Code", SqlDbType.Int) With {.Value = AccFunction_Code},
            New SqlParameter("@Transfar_invoiceDate", SqlDbType.Date) With {.Value = Transfar_InvoiceDate},
            New SqlParameter("@Transfar_invoiceNo", SqlDbType.NVarChar, 10) With {.Value = If(Transfar_InvoiceNo, DBNull.Value)},
            New SqlParameter("@Department_ID", SqlDbType.Int) With {.Value = Department_out.Department_ID},
            New SqlParameter("@Department_IDIN", SqlDbType.Int) With {.Value = Department_In.Department_ID},
            New SqlParameter("@Items_ID", SqlDbType.Int) With {.Value = Items.Items_ID},
            New SqlParameter("@Unit_ID", SqlDbType.Int) With {.Value = Unit.Unit_ID},
            New SqlParameter("@Transfar_note", SqlDbType.NVarChar, 200) With {.Value = If(Transfar_Note, DBNull.Value)},
            New SqlParameter("@Transfar_Qty", SqlDbType.Int) With {.Value = Transfar_Qty},
            New SqlParameter("@Transfar_cost", SqlDbType.Decimal) With {.Value = DBNull.Value},
            New SqlParameter("@ISActive", SqlDbType.Bit) With {.Value = ISActive},
            New SqlParameter("@Transfar_ID", SqlDbType.Int) With {.Value = Transfar_ID}
        }

        Dim result As Integer = sqlMethod.ExecuteStoredProcedure("Invoices.Update_Transfar", parameters.ToArray())
        If result > 0 Then
            MsgBox("تم تعديل التحويل بنجاح.")
        Else
            MsgBox("حدث خطأ في تعديل التحويل.")
        End If
        Return result
    End Function

    ''' <summary>
    ''' تنفيذ الإجراء  لعرض جميع ارقام قيود الفواتير
    ''' </summary>

    Public Function View_SalesInvoice() As DataTable

        ' إعداد الإجراء المخزن
        View_SalesInvoice = sqlMethod.ExecuteSelectData("Invoices.pro_View_TransfarInvoics_Code")
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
        View_SalesInvoice_Code = sqlMethod.ExecuteSelectData("Invoices.pro_View_Trans_Code", parameters.ToArray())
        ' التحقق من النتيجة

    End Function
    ''' <summary>
    ''' تنفيذ الإجراء المخزن لحذف البيع
    ''' </summary>
    ''' <returns>عدد السجلات المتأثرة (عادة 1 إذا تم التعديل بنجاح)</returns>
    Public Function DeleteSale() As Integer
        Dim parameters As New List(Of SqlParameter) From {
            New SqlParameter("@Transfar_ID", SqlDbType.Int) With {.Value = Transfar_ID}
        }

        Dim result As Integer = sqlMethod.ExecuteStoredProcedure("invoices.Delete_TransInvoice", parameters.ToArray())
        If result > 0 Then
            MsgBox("تم حذف التحويل بنجاح.")
        Else
            MsgBox("حدث خطأ في حذف التحويل.")
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
        dgv.Columns("Transfar_ID").Visible = False
        dgv.Columns("AccFunction_Code").Visible = False
        ' dgv.Columns("ID_Items_").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'dgv.Columns("Customer_ID").Visible = False
        'dgv.Columns("Customer_Name").Visible = False

        dgv.Columns("Transfar_invoiceDate").Visible = False
        ' dgv.Columns("InvoicePD_Qty").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgv.Columns("Transfar_invoiceNo").HeaderText = "رقم الفاتوره"
        'dgv.Columns("InvoicePD_price_Item").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgv.Columns("Department_out").Visible = False
        '  dgv.Columns("InvoicePD_Discount").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgv.Columns("store_out").Visible = False
        dgv.Columns("Department_IDIN").Visible = False
        dgv.Columns("store_In").Visible = False
        ' dgv.Columns("InvoicePD_Discount").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        '  dgv.Columns("InvoicePD_Total_Price").Width = 120
        dgv.Columns("Items_ID").Visible = False
        dgv.Columns("Items_Code").HeaderText = "كود الصنف"
        dgv.Columns("Items_NameAR").HeaderText = "اسم الصنف"
        dgv.Columns("Unit_ID").Visible = False
        dgv.Columns("unit_name").HeaderText = "الوحده"
        dgv.Columns("Transfar_note").Visible = False
        dgv.Columns("Transfar_Qty").HeaderText = "الكميه"
        'dgv.Columns("Transfar_cost").HeaderText = "السعر"
        dgv.Columns("Transfar_cost").HeaderText = "التكلفة"
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
