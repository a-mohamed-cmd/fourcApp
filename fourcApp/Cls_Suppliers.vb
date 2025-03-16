Imports Guna.UI2.WinForms
Imports System.Security.Cryptography.X509Certificates
Imports Microsoft.Data.SqlClient

Public Class Supplier

    ' المتغيرات الخاصة
    Private _Supplier_ID As Integer
    Private _Supplier_Name As String
    Private _country As New Countries
    Private _Supplier_Phone As String
    Private _Supplier_Fax As String
    Private _Supplier_Email As String
    Private _Supplier_Address As String
    Private _Supplier_ISActive As Boolean

#Region "property"
    ' الخصائص العامة
    Public Property Supplier_ID As Integer
        Get
            Return _Supplier_ID
        End Get
        Set(value As Integer)
            _Supplier_ID = value
        End Set
    End Property

    Public Property Supplier_Name As String
        Get
            Return _Supplier_Name
        End Get
        Set(value As String)
            _Supplier_Name = value
        End Set
    End Property



    Public Property Supplier_Phone As String
        Get
            Return _Supplier_Phone
        End Get
        Set(value As String)
            _Supplier_Phone = value
        End Set
    End Property

    Public Property Supplier_Fax As String
        Get
            Return _Supplier_Fax
        End Get
        Set(value As String)
            _Supplier_Fax = value
        End Set
    End Property

    Public Property Supplier_Email As String
        Get
            Return _Supplier_Email
        End Get
        Set(value As String)
            _Supplier_Email = value
        End Set
    End Property

    Public Property Supplier_Address As String
        Get
            Return _Supplier_Address
        End Get
        Set(value As String)
            _Supplier_Address = value
        End Set
    End Property

    Public Property Supplier_ISActive As Boolean
        Get
            Return _Supplier_ISActive
        End Get
        Set(value As Boolean)
            _Supplier_ISActive = value
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
        _Supplier_ID = id
        _Supplier_Name = name
        _country.Country_ID = countryID
        _Supplier_Phone = phone
        _Supplier_Fax = fax
        _Supplier_Email = email
        _Supplier_Address = address
        _Supplier_ISActive = isActive
    End Sub

#End Region
    Public Sub Import_Data(Optional id As Integer = 0,
                       Optional name As String = "",
                       Optional countryID As Integer = 0,
                       Optional phone As String = "",
                       Optional fax As String = "",
                       Optional email As String = "",
                       Optional address As String = "",
                       Optional isActive As Boolean = True)
        _Supplier_ID = id
        _Supplier_Name = name
        _country.Country_ID = countryID
        _Supplier_Phone = phone
        _Supplier_Fax = fax
        _Supplier_Email = email
        _Supplier_Address = address
        _Supplier_ISActive = isActive
    End Sub

    ''' <summary>
    ''' عرض بيانات row
    ''' </summary>
    ''' <param name="cur"></param>
    Sub Load_Data(cur As CurrencyManager)

        Supplier_ID = cur.Current("supplier_ID")
        Supplier_Name = cur.Current("supplier_Name")
        Country.Country_ID = If(IsDBNull(cur.Current("country_ID")), 0, cur.Current("country_ID"))
        Supplier_Phone = If(IsDBNull(cur.Current("supplier_phone")), Nothing, cur.Current("supplier_phone"))
        Supplier_Fax = If(IsDBNull(cur.Current("supplier_fax")), Nothing, cur.Current("supplier_fax"))
        Supplier_Email = If(IsDBNull(cur.Current("supplier_Email")), Nothing, cur.Current("supplier_Email"))
        Supplier_Address = If(IsDBNull(cur.Current("supplier_Address")), Nothing, cur.Current("supplier_Address"))
        Supplier_ISActive = cur.Current("supplier_ISActive")

    End Sub

    Sub Send_Data(txt() As Guna2TextBox, swt As Guna2ToggleSwitch, cmd As Guna2ComboBox)
        txt(0).Text = Supplier_ID
        txt(1).Text = Supplier_Name
        txt(2).Text = Supplier_Phone

        txt(3).Text = Supplier_Fax
        txt(4).Text = Supplier_Email
        txt(5).Text = Supplier_Address

        swt.Checked = Supplier_ISActive
        cmd.SelectedValue = Country.Country_ID
    End Sub

#Region "Methods"
    ''' <summary>
    ''' تنفيذ الإجراء المخزن لحفظ مورد جديد
    ''' </summary>
    ''' <returns>عدد السجلات المتأثرة (عادة 1 إذا تم الحفظ بنجاح)</returns>
    Public Function SaveNewSupplier() As Integer
        ' اعداد قائمة من parameters
        Dim parameters As New List(Of SqlParameter) From {
             New SqlParameter("@supplier_Name", SqlDbType.NVarChar, 150) With {.Value = Supplier_Name},
             New SqlParameter("@country_ID", SqlDbType.Int) With {.Value = Country.Country_ID},
             New SqlParameter("@supplier_phone", SqlDbType.NVarChar, 15) With {.Value = Supplier_Phone},
             New SqlParameter("@supplier_fax", SqlDbType.NVarChar, 15) With {.Value = If(Supplier_Fax, DBNull.Value)},
             New SqlParameter("@supplier_Email", SqlDbType.NVarChar, 50) With {.Value = If(Supplier_Email, DBNull.Value)},
             New SqlParameter("@supplier_Address", SqlDbType.NVarChar, 100) With {.Value = If(Supplier_Address, DBNull.Value)},
             New SqlParameter("@supplier_ISActive", SqlDbType.Bit) With {.Value = Supplier_ISActive}
            }


        ' إعداد الإجراء المخزن
        Dim result As Integer = sqlMethod.ExecuteStoredProcedure("personal.AddNew_Supplier", parameters.ToArray())
        ' التحقق من النتيجة
        If result > 0 Then
            MsgBox("تم حفظ المورد بنجاح.")
        Else
            MsgBox("حدث خطأ في الحفظ.")
        End If
        Return result
    End Function

    ''' <summary>
    ''' تنفيذ الإجراء المخزن لتعديل بيانات المورد
    ''' </summary>
    ''' <returns>عدد السجلات المتأثرة (عادة 1 إذا تم التعديل بنجاح)</returns>
    Public Function UpdateSupplier() As Integer
        ' اعداد قائمة من parameters
        Dim parameters As New List(Of SqlParameter) From {
            New SqlParameter("@supplier_Name", SqlDbType.NVarChar, 150) With {.Value = Supplier_Name},
            New SqlParameter("@country_ID", SqlDbType.Int) With {.Value = Country.Country_ID},
            New SqlParameter("@supplier_phone", SqlDbType.NVarChar, 15) With {.Value = Supplier_Phone},
            New SqlParameter("@supplier_fax", SqlDbType.NVarChar, 15) With {.Value = If(Supplier_Fax, DBNull.Value)},
            New SqlParameter("@supplier_Email", SqlDbType.NVarChar, 50) With {.Value = If(Supplier_Email, DBNull.Value)},
            New SqlParameter("@supplier_Address", SqlDbType.NVarChar, 100) With {.Value = If(Supplier_Address, DBNull.Value)},
            New SqlParameter("@supplier_ISActive", SqlDbType.Bit) With {.Value = Supplier_ISActive},
            New SqlParameter("@supplier_ID", SqlDbType.Int) With {.Value = Supplier_ID}
            }


        ' إعداد الإجراء المخزن
        Dim result As Integer = sqlMethod.ExecuteStoredProcedure("personal.Update_Supplier", parameters.ToArray())
        ' التحقق من النتيجة
        If result > 0 Then
            MsgBox("تم تعديل المورد بنجاح.")
        Else
            MsgBox("حدث خطأ في التعديل.")
        End If
        Return result
    End Function
    ''' <summary>
    ''' عرض بيانات الاشخاص
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function View_SuppliersData() As DataTable

        ' إعداد الإجراء المخزن
        View_SuppliersData = sqlMethod.ExecuteSelectData("personal.pro_view_suppliers")
        ' التحقق من النتيجة

    End Function


    ''' <summary>
    ''' البحث باستخدام الكود عن طريق %%%%
    ''' </summary>
    ''' <param name="Items_Code"></param>
    ''' <returns></returns>
    Shared Function Search_by_code(Supplier_Code As String) As DataTable
        Dim parametars As New List(Of SqlParameter) From {
               New SqlParameter("@Supplier_Code", SqlDbType.NVarChar, 10) With {.Value = Supplier_Code}}
        Search_by_code = sqlMethod.ExecuteSelectData("personal.pro_View_Supplier_Code", parametars.ToArray())
    End Function
    ''' <summary>
    ''' البحث عن طريق الاسم العربي %%%%%
    ''' </summary>
    ''' <param name="Item_Name"></param>
    ''' <returns></returns>
    Shared Function Search_by_NameAr(Supplier_NameAr As String) As DataTable
        Dim parametars As New List(Of SqlParameter) From {
               New SqlParameter("@Supplier_Name", SqlDbType.NVarChar, 150) With {.Value = Supplier_NameAr}}
        Search_by_NameAr = sqlMethod.ExecuteSelectData("personal.pro_View_Supplier_Name", parametars.ToArray())
    End Function


#End Region
    ''' <summary>
    ''' عرض في datagridview
    ''' </summary>
    ''' <param name="dgv"></param>
    Public Shared Sub Dgv_Design_view_items(dgv As Guna2DataGridView)
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

        dgv.Columns("supplier_ID").HeaderText = "كود المورد"
        dgv.Columns("supplier_Name").HeaderText = "اسم المورد"
        dgv.Columns("supplier_phone").HeaderText = "Phone"
        dgv.Columns("supplier_fax").HeaderText = "Fax"
        dgv.Columns("supplier_Email").HeaderText = "Email"
        dgv.Columns("supplier_Address").HeaderText = "العنوان"
        dgv.Columns("supplier_ISActive").HeaderText = "الحاله"
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
