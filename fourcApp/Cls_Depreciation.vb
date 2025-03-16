
Imports Guna.UI2.WinForms
Imports Microsoft.Data.SqlClient
Imports Microsoft.Identity.Client.Cache

Public Class Depreciation
    ' المتغيرات الخاصة
    Private _Depreciation_ID As Integer
    Private _AccFunction_Code As Integer
    Private _Depreciation_invoiceDate As Date
    Private _Department As New Department
    Private _Items As New Items
    Private _store As New Store
    Private _Unit As New Unit
    Private _Depreciation_Case As String
    Private _Depreciation_Qty As Integer
    Private _Depreciation_cost As Decimal
    Private _ISActive As Boolean
    Private _TotalInvoice As Decimal = 0
    Private _dv As New DataView
    Private _Cur As CurrencyManager
#Region "Properties"
    ' الخصائص العامة
    Public Property Depreciation_ID As Integer
        Get
            Return _Depreciation_ID
        End Get
        Set(value As Integer)
            _Depreciation_ID = value
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

    Public Property Depreciation_invoiceDate As Date
        Get
            Return _Depreciation_invoiceDate
        End Get
        Set(value As Date)
            _Depreciation_invoiceDate = value
        End Set
    End Property



    Public Property Depreciation_Case As String
        Get
            Return _Depreciation_Case
        End Get
        Set(value As String)
            _Depreciation_Case = value
        End Set
    End Property

    Public Property Depreciation_Qty As Integer
        Get
            Return _Depreciation_Qty
        End Get
        Set(value As Integer)
            _Depreciation_Qty = value
        End Set
    End Property

    Public Property Depreciation_cost As Decimal
        Get
            Return _Depreciation_cost
        End Get
        Set(value As Decimal)
            _Depreciation_cost = value
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
    Public Sub New(Optional depreciationID As Integer = 0, Optional accFunctionCode As Integer = 0,
                   Optional depreciationDate As Date = Nothing, Optional departmentID As Integer = 0,
                   Optional itemsID As Integer = 0, Optional unitID As Integer = 0,
                   Optional depreciationCase As String = "", Optional depreciationQty As Integer = 0,
                   Optional depreciationCost As Decimal = 0.0D, Optional isActive As Boolean = True)
        _Depreciation_ID = depreciationID
        _AccFunction_Code = accFunctionCode
        _Depreciation_invoiceDate = depreciationDate
        _Department.Department_ID = departmentID
        _Items.Items_ID = itemsID
        _Unit.Unit_ID = unitID
        _Depreciation_Case = depreciationCase
        _Depreciation_Qty = depreciationQty
        _Depreciation_cost = depreciationCost
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
    Public Sub import_Data(Optional accFunctionCode As Integer = 0,
                   Optional depreciationDate As Date = Nothing, Optional departmentID As Integer = 0,
                   Optional itemsID As String = "", Optional unitID As Integer = 0,
                   Optional depreciationCase As String = "", Optional depreciationQty As Integer = 0,
                   Optional depreciationCost As Decimal = 0.0D, Optional isActive As Boolean = True
                      )



        _AccFunction_Code = accFunctionCode
        _Depreciation_invoiceDate = depreciationDate
        _Department.Department_ID = departmentID
        _Items.Items_Code = itemsID
        _Unit.Unit_ID = unitID
        _Depreciation_Case = depreciationCase
        _Depreciation_Qty = depreciationQty
        _Depreciation_cost = depreciationCost
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

        _Depreciation_ID = cur.Current("Depreciation_ID")
        _AccFunction_Code = cur.Current("AccFunction_Code")

        _Depreciation_invoiceDate = If(IsDBNull(cur.Current("Depreciation_invoiceDate")), Nothing, cur.Current("Depreciation_invoiceDate"))
        _Department.Department_ID = If(IsDBNull(cur.Current("Department_ID")), Nothing, cur.Current("Department_ID"))
        _Department.Store_ID = If(IsDBNull(cur.Current("Store_ID")), Nothing, cur.Current("Store_ID"))
        Items.Items_ID = cur.Current("Items_ID")
        Items.Items_Code = cur.Current("Items_Code")
        Items.Items_NameAR = If(IsDBNull(cur.Current("Items_NameAR")), Nothing, cur.Current("Items_NameAR"))
        Unit.Unit_ID = cur.Current("Unit_ID")
        _Depreciation_Case = If(IsDBNull(cur.Current("Depreciation_Case")), Nothing, cur.Current("Depreciation_Case"))
        _Depreciation_Qty = If(IsDBNull(cur.Current("Depreciation_Qty")), 0, cur.Current("Depreciation_Qty"))
        _Depreciation_cost = If(IsDBNull(cur.Current("Depreciation_cost")), 0D, cur.Current("Depreciation_cost"))
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
        txt(1).Text = Items.Items_Code
        txt(2).Text = Items.Items_NameAR
        dateinvoice.Value = Depreciation_invoiceDate
        txt(3).Text = Depreciation_Case
        com(0).SelectedValue = Department.Department_ID
        com(1).SelectedValue = Department.Store_ID
        txt(4).Text = Depreciation_Qty
        txt(5).Text = Depreciation_cost
        com(2).SelectedValue = Unit.Unit_ID
        txt(6).Text = (Depreciation_Qty * Depreciation_cost)
        txt(7).Text = Dv.Count
        txt(8).Text = Dv.Table.Compute("sum(Depreciation_Qty)", Nothing).ToString()

        txt(9).Text = Total_Price.ToString("N2")  ' صيغة جميلة بنتيجتين عشريتين
        txt(10).Text = Items.BalanceOfItemInDeprartment(item_ID:=Items.Items_ID, Deprartment:=Department.Department_ID)

    End Sub
    ''' <summary>
    ''' الحصول علي مجموع الفاتوره
    ''' </summary>
    ''' <returns></returns>
    Private Function Total_Price() As Decimal



        For Each row As DataRowView In Dv
            If Not IsDBNull(row("Depreciation_Qty")) AndAlso Not IsDBNull(row("Depreciation_cost")) Then
                Total_Price += Convert.ToDecimal(row("Depreciation_Qty")) * Convert.ToDecimal(row("Depreciation_cost"))
            End If
        Next
        TotalInvoice = Total_Price
        Return Total_Price


    End Function



#Region "Methods"
    ''' <summary>
    ''' تنفيذ الإجراء المخزن لإضافة استهلاك جديد
    ''' </summary>
    ''' <returns>عدد السجلات المتأثرة (عادة 1 إذا تم الحفظ بنجاح)</returns>
    Public Function SaveNewDepreciation() As Integer
        ' إعداد قائمة من parameters
        Dim parameters As New List(Of SqlParameter)
        With parameters
            .Add(New SqlParameter("@AccFunction_Code", SqlDbType.Int) With {.Value = AccFunction_Code})
            .Add(New SqlParameter("@Depreciation_invoiceDate", SqlDbType.Date) With {.Value = Depreciation_invoiceDate})
            .Add(New SqlParameter("@Department_ID", SqlDbType.Int) With {.Value = Department.Department_ID})
            .Add(New SqlParameter("@Items_ID", SqlDbType.Int) With {.Value = Items.Items_ID})
            .Add(New SqlParameter("@Unit_ID", SqlDbType.Int) With {.Value = Unit.Unit_ID})
            .Add(New SqlParameter("@Depreciation_Case", SqlDbType.NVarChar, 200) With {.Value = If(Depreciation_Case, DBNull.Value)})
            .Add(New SqlParameter("@Depreciation_Qty", SqlDbType.Int) With {.Value = Depreciation_Qty})
            .Add(New SqlParameter("@Depreciation_cost", SqlDbType.Decimal) With {.Value =
                  DBNull.Value})
            .Add(New SqlParameter("@ISActive", SqlDbType.Bit) With {.Value = ISActive})
        End With

        ' تنفيذ الإجراء المخزن
        Dim result As Integer = sqlMethod.ExecuteStoredProcedure("Invoices.AddNew_Depreciation", parameters.ToArray())
        ' التحقق من النتيجة
        If result > 0 Then
            MsgBox("تم إضافة الاستهلاك بنجاح.")
        Else
            MsgBox("حدث خطأ في إضافة الاستهلاك.")
        End If
        Return result
    End Function

    ''' <summary>
    ''' تنفيذ الإجراء المخزن لتعديل بيانات الاستهلاك
    ''' </summary>
    ''' <returns>عدد السجلات المتأثرة (عادة 1 إذا تم التعديل بنجاح)</returns>
    Public Function UpdateDepreciation() As Integer
        ' إعداد قائمة من parameters
        Dim parameters As New List(Of SqlParameter)
        With parameters
            .Add(New SqlParameter("@AccFunction_Code", SqlDbType.Int) With {.Value = AccFunction_Code})
            .Add(New SqlParameter("@Depreciation_invoiceDate", SqlDbType.Date) With {.Value = Depreciation_invoiceDate})
            .Add(New SqlParameter("@Department_ID", SqlDbType.Int) With {.Value = Department.Department_ID})
            .Add(New SqlParameter("@Items_ID", SqlDbType.Int) With {.Value = Items.Items_ID})
            .Add(New SqlParameter("@Unit_ID", SqlDbType.Int) With {.Value = Unit.Unit_ID})
            .Add(New SqlParameter("@Depreciation_Case", SqlDbType.NVarChar, 200) With {.Value =
                 If(Depreciation_Case, DBNull.Value)})
            .Add(New SqlParameter("@Depreciation_Qty", SqlDbType.Int) With {.Value = Depreciation_Qty})
            .Add(New SqlParameter("@Depreciation_cost", SqlDbType.Decimal) With {.Value =
          DBNull.Value})
            .Add(New SqlParameter("@ISActive", SqlDbType.Bit) With {.Value = ISActive})
            .Add(New SqlParameter("@Depreciation_ID", SqlDbType.Int) With {.Value = Depreciation_ID})
        End With

        ' تنفيذ الإجراء المخزن
        Dim result As Integer = sqlMethod.ExecuteStoredProcedure("Invoices.Update_Depreciation", parameters.ToArray())
        ' التحقق من النتيجة
        If result > 0 Then
            MsgBox("تم تعديل الاستهلاك بنجاح.")
        Else
            MsgBox("حدث خطأ في تعديل الاستهلاك.")
        End If
        Return result
    End Function
    ''' <summary>
    ''' تنفيذ الإجراء  لعرض جميع ارقام قيود الفواتير
    ''' </summary>

    Public Function View_SalesInvoice() As DataTable

        ' إعداد الإجراء المخزن
        View_SalesInvoice = sqlMethod.ExecuteSelectData("Invoices.pro_View_DeprecationInvoics_Code")
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
        View_SalesInvoice_Code = sqlMethod.ExecuteSelectData("Invoices.pro_View_Deprecation_Code", parameters.ToArray())
        ' التحقق من النتيجة

    End Function
    ''' <summary>
    ''' تنفيذ الإجراء المخزن لحذف البيع
    ''' </summary>
    ''' <returns>عدد السجلات المتأثرة (عادة 1 إذا تم التعديل بنجاح)</returns>
    Public Function DeleteSale() As Integer
        Dim parameters As New List(Of SqlParameter) From {
            New SqlParameter("@Depreciation_ID", SqlDbType.Int) With {.Value = Depreciation_ID}
        }

        Dim result As Integer = sqlMethod.ExecuteStoredProcedure("invoices.Delete_DeprecationInvoice", parameters.ToArray())
        If result > 0 Then
            MsgBox("تم حذف الاهلاك بنجاح.")
        Else
            MsgBox("حدث خطأ في حذف الاهلاك.")
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
        dgv.Columns("Depreciation_ID").Visible = False
        dgv.Columns("AccFunction_Code").Visible = False
        ' dgv.Columns("ID_Items_").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgv.Columns("Depreciation_invoiceDate").Visible = False
        ' dgv.Columns("InvoicePD_Qty").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
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
        dgv.Columns("Depreciation_Case").Visible = False
        dgv.Columns("Depreciation_Qty").HeaderText = "الكميه"
        dgv.Columns("Depreciation_cost").HeaderText = "التكلفة"
        'dgv.Columns("Items_Cost").HeaderText = "التكلفة"
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
