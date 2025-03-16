Imports Guna.UI2.WinForms
Imports System.Diagnostics.Metrics
Imports Microsoft.Data.SqlClient

Public Class Customer

    ' المتغيرات الخاصة
    Private _Customer_ID As Integer
    Private _Customer_Name As String

    Private _country As New Countries
    Private _Customer_Phone As String
    Private _Customer_Fax As String
    Private _Customer_Email As String
    Private _Customer_Address As String
    Private _Customer_ISActive As Boolean

#Region "property"
    ' الخصائص العامة
    Public Property Customer_ID As Integer
        Get
            Return _Customer_ID
        End Get
        Set(value As Integer)
            _Customer_ID = value
        End Set
    End Property

    Public Property Customer_Name As String
        Get
            Return _Customer_Name
        End Get
        Set(value As String)
            _Customer_Name = value
        End Set
    End Property


    Public Property Customer_Phone As String
        Get
            Return _Customer_Phone
        End Get
        Set(value As String)
            _Customer_Phone = value
        End Set
    End Property

    Public Property Customer_Fax As String
        Get
            Return _Customer_Fax
        End Get
        Set(value As String)
            _Customer_Fax = value
        End Set
    End Property

    Public Property Customer_Email As String
        Get
            Return _Customer_Email
        End Get
        Set(value As String)
            _Customer_Email = value
        End Set
    End Property

    Public Property Customer_Address As String
        Get
            Return _Customer_Address
        End Get
        Set(value As String)
            _Customer_Address = value
        End Set
    End Property

    Public Property Customer_ISActive As Boolean
        Get
            Return _Customer_ISActive
        End Get
        Set(value As Boolean)
            _Customer_ISActive = value
        End Set
    End Property

    Public Property Country As Countries
        Get
            Return _country
        End Get
        Set(value As Countries)
            _country = value
        End Set
    End Property

    ' المُنشئ لتعبئة البيانات عند إنشاء الكائن
    Public Sub New(Optional id As Integer = 0,
                   Optional name As String = "",
                   Optional countryID As Integer = 0,
                   Optional phone As String = "",
                   Optional fax As String = "",
                   Optional email As String = "",
                   Optional address As String = "",
                   Optional isActive As Boolean = True)
        _Customer_ID = id
        _Customer_Name = name
        _country.Country_ID = countryID
        _Customer_Phone = phone
        _Customer_Fax = fax
        _Customer_Email = email
        _Customer_Address = address
        _Customer_ISActive = isActive
    End Sub

#End Region
    Public Sub import_Data(Optional id As Integer = 0,
                       Optional name As String = "",
                       Optional countryID As Integer = 0,
                       Optional phone As String = "",
                       Optional fax As String = "",
                       Optional email As String = "",
                       Optional address As String = "",
                       Optional isActive As Boolean = True)
        _Customer_ID = id
        _Customer_Name = name
        Country.Country_ID = countryID
        _Customer_Phone = phone
        _Customer_Fax = fax
        _Customer_Email = email
        _Customer_Address = address
        _Customer_ISActive = isActive
    End Sub

    ''' <summary>
    ''' عرض بيانات row
    ''' </summary>
    ''' <param name="cur"></param>
    Sub Load_Data(cur As CurrencyManager)

        Customer_ID = cur.Current("Customer_ID")
        Customer_Name = cur.Current("Customer_Name")
        Country.Country_ID = If(IsDBNull(cur.Current("country_ID")), 0, cur.Current("country_ID"))
        Customer_Phone = If(IsDBNull(cur.Current("Customer_Phone")), Nothing, cur.Current("Customer_Phone"))
        Customer_Fax = If(IsDBNull(cur.Current("Customer_Fax")), Nothing, cur.Current("Customer_Fax"))
        Customer_Email = If(IsDBNull(cur.Current("Customer_Email")), Nothing, cur.Current("Customer_Email"))
        Customer_Address = If(IsDBNull(cur.Current("Customer_Address")), Nothing, cur.Current("Customer_Address"))
        Customer_ISActive = cur.Current("Customer_ISActive")

    End Sub

    Sub Send_Data(txt() As Guna2TextBox, swt As Guna2ToggleSwitch, cmd As Guna2ComboBox)
        txt(0).Text = Customer_ID
        txt(1).Text = Customer_Name
        txt(2).Text = Customer_Phone

        txt(3).Text = Customer_Fax
        txt(4).Text = Customer_Email
        txt(5).Text = Customer_Address

        swt.Checked = Customer_ISActive
        cmd.SelectedValue = Country.Country_ID
    End Sub



#Region "Methods"
    ''' <summary>
    ''' تنفيذ الإجراء المخزن لحفظ عميل جديد
    ''' </summary>
    ''' <returns>عدد السجلات المتأثرة (عادة 1 إذا تم الحفظ بنجاح)</returns>
    Public Function SaveNewCustomer() As Integer
        ' اعداد قائمة من parameters
        Dim parameters As New List(Of SqlParameter) From {
         New SqlParameter("@Customer_Name", SqlDbType.NVarChar, 150) With {.Value = Customer_Name},
         New SqlParameter("@country_ID", SqlDbType.Int) With {.Value = Country.Country_ID},
         New SqlParameter("@Customer_phone", SqlDbType.NVarChar, 15) With {.Value = Customer_Phone},
         New SqlParameter("@Customer_fax", SqlDbType.NVarChar, 15) With {.Value = If(Customer_Fax, DBNull.Value)},
         New SqlParameter("@Customer_Email", SqlDbType.NVarChar, 50) With {.Value = If(Customer_Email, DBNull.Value)},
         New SqlParameter("@Customer_Address", SqlDbType.NVarChar, 100) With {.Value = If(Customer_Address, DBNull.Value)},
         New SqlParameter("@Customer_ISActive", SqlDbType.Bit) With {.Value = Customer_ISActive}
        }

        ' إعداد الإجراء المخزن
        Dim result As Integer = sqlMethod.ExecuteStoredProcedure("personal.AddNew_Customer", parameters.ToArray())
        ' التحقق من النتيجة
        If result > 0 Then
            MsgBox("تم حفظ العميل بنجاح.")
        Else
            MsgBox("حدث خطأ في الحفظ.")
        End If
        Return result
    End Function

    ''' <summary>
    ''' تنفيذ الإجراء المخزن لتعديل بيانات العميل
    ''' </summary>
    ''' <returns>عدد السجلات المتأثرة (عادة 1 إذا تم التعديل بنجاح)</returns>
    Public Function UpdateCustomer() As Integer
        ' اعداد قائمة من parameters
        Dim parameters As New List(Of SqlParameter) From {
         New SqlParameter("@Customer_Name", SqlDbType.NVarChar, 150) With {.Value = Customer_Name},
         New SqlParameter("@country_ID", SqlDbType.Int) With {.Value = Country.Country_ID},
         New SqlParameter("@Customer_phone", SqlDbType.NVarChar, 15) With {.Value = Customer_Phone},
         New SqlParameter("@Customer_fax", SqlDbType.NVarChar, 15) With {.Value = If(Customer_Fax, DBNull.Value)},
         New SqlParameter("@Customer_Email", SqlDbType.NVarChar, 50) With {.Value = If(Customer_Email, DBNull.Value)},
         New SqlParameter("@Customer_Address", SqlDbType.NVarChar, 100) With {.Value = If(Customer_Address, DBNull.Value)},
         New SqlParameter("@Customer_ISActive", SqlDbType.Bit) With {.Value = Customer_ISActive},
         New SqlParameter("@Customer_ID", SqlDbType.Int) With {.Value = Customer_ID}
        }


        ' إعداد الإجراء المخزن
        Dim result As Integer = sqlMethod.ExecuteStoredProcedure("personal.Update_Customer", parameters.ToArray())
        ' التحقق من النتيجة
        If result > 0 Then
            MsgBox("تم تعديل العميل بنجاح.")
        Else
            MsgBox("حدث خطأ في التعديل.")
        End If
        Return result
    End Function
    ''' <summary>
    ''' عرض بيانات الاشخاص
    ''' </summary>
    ''' <returns></returns>
    Public Function View_SuppliersData() As DataTable

        ' إعداد الإجراء المخزن
        View_SuppliersData = sqlMethod.ExecuteSelectData("personal.pro_view_Customers")
        ' التحقق من النتيجة

    End Function


    ''' <summary>
    ''' البحث باستخدام الكود عن طريق %%%%
    ''' </summary>
    ''' <param name="Items_Code"></param>
    ''' <returns></returns>
    Function Search_by_code(Supplier_Code As String) As DataTable
        Dim parametars As New List(Of SqlParameter) From {
               New SqlParameter("@Customer_Code", SqlDbType.NVarChar, 10) With {.Value = Supplier_Code}}
        Search_by_code = sqlMethod.ExecuteSelectData("personal.pro_View_Customer_Code", parametars.ToArray())
    End Function
    ''' <summary>
    ''' البحث عن طريق الاسم العربي %%%%%
    ''' </summary>
    ''' <param name="Item_Name"></param>
    ''' <returns></returns>
    Function Search_by_NameAr(Supplier_NameAr As String) As DataTable
        Dim parametars As New List(Of SqlParameter) From {
               New SqlParameter("@Customer_Name", SqlDbType.NVarChar, 150) With {.Value = Supplier_NameAr}}
        Search_by_NameAr = sqlMethod.ExecuteSelectData("personal.pro_View_Customer_Name", parametars.ToArray())
    End Function


#End Region
    ''' <summary>
    ''' عرض في datagridview
    ''' </summary>
    ''' <param name="dgv"></param>
    Public Sub Dgv_Design_view_items(dgv As Guna2DataGridView)
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
        'dgv.Columns("Items_Code").Visible = False
        'dgv.Columns("Items_ID").Visible = False
        '' dgv.Columns("ID_Items_").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'dgv.Columns("Items_NameAR").Visible = False
        'dgv.Columns("supplier_Name").Visible = False

        'dgv.Columns("purchase_invoiceDate").Visible = False
        '' dgv.Columns("InvoicePD_Qty").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'dgv.Columns("purchase_invoiceNo").HeaderText = "رقم الفاتوره"
        ''dgv.Columns("InvoicePD_price_Item").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'dgv.Columns("Department_ID").Visible = False
        ''  dgv.Columns("InvoicePD_Discount").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'dgv.Columns("Store_ID").Visible = False
        ' dgv.Columns("InvoicePD_Discount").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        '  dgv.Columns("InvoicePD_Total_Price").Width = 120
        'dgv.Columns("Items_ID").Visible = False

        dgv.Columns("Customer_ID").HeaderText = "كود العميل"
        dgv.Columns("Customer_Name").HeaderText = "اسم العميل"
        dgv.Columns("Customer_phone").HeaderText = "Phone"
        dgv.Columns("Customer_fax").HeaderText = "Fax"
        dgv.Columns("Customer_Email").HeaderText = "Email"
        dgv.Columns("Customer_Address").HeaderText = "العنوان"
        dgv.Columns("Customer_ISActive").HeaderText = "الحاله"
        'dgv.Columns("country_ID1").Visible = False

        dgv.Columns("country_ID").Visible = False
        dgv.Columns("Country_Name").Visible = False
        dgv.Columns("Country_PhoneKey").Visible = False


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

End Class
