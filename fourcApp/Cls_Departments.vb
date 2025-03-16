Imports Guna.UI2.WinForms
Imports System.Security.Cryptography.X509Certificates
Imports Microsoft.Data.SqlClient
Imports System.Reflection.Metadata

Public Class Department

    ' المتغيرات الخاصة
    Private _Department_ID As Integer
    Private _Department_Name As String
    Private _Department_Note As String
    Private _Store_ID As Integer
    Private _Dep_TotalBalance As Decimal

#Region "property"
    ' الخصائص العامة
    Public Property Department_ID As Integer
        Get
            Return _Department_ID
        End Get
        Set(value As Integer)
            _Department_ID = value
        End Set
    End Property

    Public Property Department_Name As String
        Get
            Return _Department_Name
        End Get
        Set(value As String)
            _Department_Name = value
        End Set
    End Property

    Public Property Department_Note As String
        Get
            Return _Department_Note
        End Get
        Set(value As String)
            _Department_Note = value
        End Set
    End Property

    Public Property Store_ID As Integer
        Get
            Return _Store_ID
        End Get
        Set(value As Integer)
            _Store_ID = value
        End Set
    End Property

    Public Property Dep_TotalBalance As Decimal
        Get
            Return _Dep_TotalBalance
        End Get
        Set(value As Decimal)
            _Dep_TotalBalance = value
        End Set
    End Property

    ' المُنشئ لتعبئة البيانات عند إنشاء الكائن
    Public Sub New(Optional id As Integer = 0,
                   Optional name As String = "",
                   Optional note As String = "",
                   Optional storeId As Integer = 0,
                   Optional totalBalance As Decimal = 0.0D)
        _Department_ID = id
        _Department_Name = name
        _Department_Note = note
        _Store_ID = storeId
        _Dep_TotalBalance = totalBalance
    End Sub

#End Region

#Region "Methods"
    ''' <summary>
    ''' تنفيذ الإجراء المخزن لحفظ قسم جديد
    ''' </summary>
    ''' <returns>عدد السجلات المتأثرة (عادة 1 إذا تم الحفظ بنجاح)</returns>
    Public Function SaveNewDepartment() As Integer
        ' اعداد قائمة من parameters
        Dim parameters As New List(Of SqlParameter) From {
            New SqlParameter("@Department_Name", SqlDbType.NVarChar, 20) With {.Value = Department_Name},
            New SqlParameter("@Department_Note", SqlDbType.NVarChar, 30) With {.Value = If(Department_Note, DBNull.Value)},
            New SqlParameter("@Store_ID", SqlDbType.Int) With {.Value = Store_ID},
            New SqlParameter("@Dep_TotalBalance", SqlDbType.Decimal) With {.Value = Dep_TotalBalance}
            }


        ' إعداد الإجراء المخزن
        Dim result As Integer = sqlMethod.ExecuteStoredProcedure("stores.NewDepartment", parameters.ToArray())
        ' التحقق من النتيجة
        If result > 0 Then
            MsgBox("تم حفظ القسم بنجاح.")
        Else
            MsgBox("حدث خطأ في الحفظ.")
        End If
        Return result
    End Function

    ''' <summary>
    ''' تنفيذ الإجراء المخزن لتعديل قسم موجود
    ''' </summary>
    ''' <returns>عدد السجلات المتأثرة (عادة 1 إذا تم التعديل بنجاح)</returns>
    Public Function UpdateDepartment() As Integer
        ' اعداد قائمة من parameters
        Dim parameters As New List(Of SqlParameter) From {
        New SqlParameter("@Department_Name", SqlDbType.NVarChar, 20) With {.Value = Department_Name},
        New SqlParameter("@Department_Note", SqlDbType.NVarChar, 30) With {.Value = If(Department_Note, DBNull.Value)},
        New SqlParameter("@Store_ID", SqlDbType.Int) With {.Value = Store_ID},
        New SqlParameter("@Department_ID", SqlDbType.Int) With {.Value = Department_ID}
        }


        ' إعداد الإجراء المخزن
        Dim result As Integer = sqlMethod.ExecuteStoredProcedure("stores.UpdateDepartment", parameters.ToArray())
        ' التحقق من النتيجة
        If result > 0 Then
            MsgBox("تم تعديل القسم بنجاح.")
        Else
            MsgBox("حدث خطأ في التعديل.")
        End If
        Return result
    End Function

#End Region
    Public Sub Import_Data(Optional id As Integer = 0,
                            Optional name As String = "",
                   Optional Note As String = "",
                   Optional Store_ID As Integer = 0)
        _Department_ID = id
        _Department_Name = name
        _Department_Note = Note
        _Store_ID = Store_ID
    End Sub

    Public Shared Sub Com_Department(com As Guna2ComboBox, stor_id As Integer)

        Dim parameters As New List(Of SqlParameter) From {
        New SqlParameter("@store_ID", SqlDbType.Int, 20) With {.Value = stor_id}}
        ' إعداد الإجراء المخزن
        com.DataSource = sqlMethod.ExecuteSelectData("Stores.pro_View_Department", parameters.ToArray())
        com.DisplayMember = "Department_Name"
        com.ValueMember = "Department_ID"
        ' التحقق من النتيجة

    End Sub
    Public Shared Sub Com_DepartmentwithNull(com As Guna2ComboBox, stor_id As Integer)

        Dim parameters As New List(Of SqlParameter) From {
        New SqlParameter("@store_ID", SqlDbType.Int, 20) With {.Value = stor_id}}
        ' إعداد الإجراء المخزن

        Dim dt As DataTable = sqlMethod.ExecuteSelectData("Stores.pro_View_Department", parameters.ToArray())
        ' اضافه صف فارغ
        Dim dt_row As DataRow = dt.NewRow()
        dt_row("Department_ID") = DBNull.Value
        dt_row("Department_Name") = "كل الفرع"
        dt.Rows.InsertAt(dt_row, 0)
        com.DataSource = dt
        com.DisplayMember = "Department_Name"
        com.ValueMember = "Department_ID"
        ' التحقق من النتيجة

    End Sub
    Function Department_Balance() As DataTable

        Dim parameters As New List(Of SqlParameter) From {
        New SqlParameter("@Department_ID", SqlDbType.Int, 20) With {.Value = Department_ID}}
        ' إعداد الإجراء المخزن

        Department_Balance = sqlMethod.ExecuteSelectData("Stores.pro_Department_Balance", parameters.ToArray())
    End Function

    Public Shared Sub Dgv_Design_MoveItem(dgv As Guna2DataGridView)
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
        dgv.Columns("Items_ID").Visible = False
        dgv.Columns("Items_Code").HeaderText = "كود الصنف"
        dgv.Columns("Items_NameAR").HeaderText = "اسم الصنف"
        dgv.Columns("Item_Qty").HeaderText = "الكميه"
        dgv.Columns("Department_ID").Visible = False
        dgv.Columns("Department_Name").Visible = False
        dgv.Columns("Store_Name").Visible = False
        dgv.Columns("Department_Name").Visible = False
        dgv.Columns("Store_Name").Visible = False
        'dgv.Columns("CategoryOne_Name").HeaderText = "الفئه 1"
        'dgv.Columns("CategoryTwo_ID").Visible = False
        'dgv.Columns("CategoryTwo_ID").Visible = False
        'dgv.Columns("CategoryThree_ID").Visible = False
        'dgv.Columns("CategoryTwo_Name").HeaderText = "الفئه 2"
        'dgv.Columns("CategoryThree_Name").HeaderText = "الفئه 3"
        'dgv.Columns("Categoryfour_ID").Visible = False
        'dgv.Columns("CategoryFour_Name").HeaderText = "الفئه 4"
        ''Column Celles Disign
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
