
Imports Guna.UI2.WinForms
Imports Microsoft.Data.SqlClient
Public Class Store

    ' المتغيرات الخاصة
    Private _Store_ID As Integer
    Private _Store_Name As String
    Private _Store_Location As String
    Private _Store_IsActive As Boolean
    Private _department As New Department
    Private _Dt As New DataTable
#Region "property"
    ' الخصائص العامة
    Public Property Store_ID As Integer
        Get
            Return _Store_ID
        End Get
        Set(value As Integer)
            _Store_ID = value
        End Set
    End Property

    Public Property Store_Name As String
        Get
            Return _Store_Name
        End Get
        Set(value As String)
            _Store_Name = value
        End Set
    End Property

    Public Property Store_Location As String
        Get
            Return _Store_Location
        End Get
        Set(value As String)
            _Store_Location = value
        End Set
    End Property
    Public Property Store_IsActive As Boolean
        Get
            Return _Store_IsActive
        End Get
        Set(value As Boolean)
            _Store_IsActive = value
        End Set
    End Property

    Public Property Dt As DataTable
        Get
            Return _Dt
        End Get
        Set(value As DataTable)
            _Dt = value
        End Set
    End Property

    Public Property Department As Department
        Get
            Return _department
        End Get
        Set(value As Department)
            _department = value
        End Set
    End Property

    ' المُنشئ لتعبئة البيانات عند إنشاء الكائن
    Public Sub New(Optional id As Integer = 0,
Optional name As String = "",
                   Optional location As String = "",
                   Optional isActive As Boolean = True)
        _Store_ID = id
        _Store_Name = name
        _Store_Location = location
        _Store_IsActive = isActive
    End Sub

#End Region
    Public Sub import_Data(Optional id As Integer = 0,
Optional name As String = "",
                   Optional location As String = "",
                   Optional isActive As Boolean = True)
        _Store_ID = id
        _Store_Name = name
        _Store_Location = location
        _Store_IsActive = isActive
    End Sub
    ''' <summary>
    ''' عرض بيانات row
    ''' </summary>
    ''' <param name="cur"></param>
    Sub Load_Data(cur As CurrencyManager)

        Store_ID = cur.Current("Store_ID")
        Store_Name = cur.Current("Store_Name")
        Store_Location = If(IsDBNull(cur.Current("Store_Location")),
                                    Nothing, cur.Current("Store_Location"))
        Store_IsActive = cur.Current("store_IsActive")
        Department.Department_ID = If(IsDBNull(cur.Current("Department_ID")),
                                            Nothing, cur.Current("Department_ID"))
        Department.Department_Name = If(IsDBNull(cur.Current("Department_Name")),
                                            Nothing, cur.Current("Department_Name"))
        Department.Department_Note = If(IsDBNull(cur.Current("Department_Note")),
                                    Nothing, (cur.Current("Department_Note")))

    End Sub
    Sub Send_Data(txt() As Guna2TextBox, swt As Guna2ToggleSwitch)
        txt(0).Text = Store_ID
        txt(1).Text = Store_Name
        txt(2).Text = Store_Location
        swt.Checked = Store_IsActive
        txt(3).Text = Department.Department_ID
        txt(4).Text = Department.Department_Name
        txt(5).Text = Department.Department_Note
    End Sub

#Region "Methods"
    ''' <summary>
    ''' تنفيذ الإجراء المخزن لحفظ مستودع جديد
    ''' </summary>
    ''' <returns>عدد السجلات المتأثرة (عادة 1 إذا تم الحفظ بنجاح)</returns>
    Public Function SaveNewStore() As Integer
        ' اعداد قائمه من parameters
        Dim parameters As new List(Of SqlParameter) from{
            New SqlParameter("@storeName", SqlDbType.NVarChar, 30) With {.Value = Store_Name} ,
        New SqlParameter("@storeLocateion", SqlDbType.NVarChar, 30) With {.Value = If(Store_Location, DBNull.Value)} ,
         New SqlParameter("@isActive", SqlDbType.Bit) With {.Value = Store_IsActive} 
        }

            ' إعداد الإجراء المخزن
            Dim result As Integer = sqlMethod.ExecuteStoredProcedure("stores.NewStore", parameters.ToArray())
        ' التحقق من النتيجة
        If result > 0 Then
            MsgBox("تم حفظ المستودع بنجاح.")
        Else
            MsgBox("حدث خطأ في الحفظ.")
        End If
        Return result
    End Function


    ''' <summary>
    ''' تنفيذ الإجراء المخزن لتعديل مستودع جديد
    ''' </summary>
    ''' <returns>عدد السجلات المتأثرة (عادة 1 إذا تم التعديل بنجاح)</returns>
    Public Function UpdateStore() As Integer
        ' اعداد قائمه من parameters
        Dim parameters As New List(Of SqlParameter) From {
            New SqlParameter("@storeName", SqlDbType.NVarChar, 30) With {.Value = Store_Name},
            New SqlParameter("@storeLocateion", SqlDbType.NVarChar, 30) With {.Value = If(Store_Location, DBNull.Value)},
             New SqlParameter("@isActive", SqlDbType.Bit) With {.Value = Store_IsActive},
             New SqlParameter("@ID_store", SqlDbType.Int) With {.Value = Store_ID}
      }

        ' إعداد الإجراء المخزن
        Dim result As Integer = sqlMethod.ExecuteStoredProcedure("stores.UpdateStore", parameters.ToArray())
        ' التحقق من النتيجة
        If result > 0 Then
            MsgBox("تم تعديل المستودع بنجاح.")
        Else
            MsgBox("حدث خطأ في التعديل.")
        End If
        Return result
    End Function

    ''' <summary>
    ''' تنفيذ الإجراء المخزن لعرض جميع المستودعات والاقسام
    ''' </summary>

    Public Function View_StoresAndDepartments() As DataTable

        ' إعداد الإجراء المخزن
        View_StoresAndDepartments = sqlMethod.ExecuteSelectData("Stores.pro_View_DepartmentandStores")
        ' التحقق من النتيجة

    End Function
    Public Sub Com_store(com As Guna2ComboBox)
        Dim dt As DataTable = sqlMethod.ExecuteSelectData("Stores.pro_View_Stores")
        ' إعداد الإجراء المخزن
        com.DataSource = dt
        com.DisplayMember = "Store_Name"
        com.ValueMember = "Store_ID"
        ' التحقق من النتيجة

    End Sub
#End Region
End Class

