Imports Guna.UI2.WinForms

Imports Microsoft.Data.SqlClient

Public Class CategoryOne

    ' المتغيرات الخاصة
    Private _CategoryOne_ID As Integer
    Private _CategoryOne_Name As String
    Private _Dt As New DataTable
#Region "property"
    ' الخصائص العامة
    Public Property CategoryOne_ID As Integer
        Get
            Return _CategoryOne_ID
        End Get
        Set(value As Integer)
            _CategoryOne_ID = value
        End Set
    End Property

    Public Property CategoryOne_Name As String
        Get
            Return _CategoryOne_Name
        End Get
        Set(value As String)
            _CategoryOne_Name = value
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

    ' المُنشئ لتعبئة البيانات عند إنشاء الكائن
    Public Sub New(Optional id As Integer = 0,
                   Optional name As String = "")
        _CategoryOne_ID = id
        _CategoryOne_Name = name
    End Sub

#End Region

    Public Sub import_Data(Optional id As Integer = 0,
                            Optional nameCategory As String = "")

        _CategoryOne_ID = id
        _CategoryOne_Name = nameCategory

    End Sub
    ''' <summary>
    ''' عرض بيانات row
    ''' </summary>
    ''' <param name="cur"></param>
    Sub Load_Data(cur As CurrencyManager)

        CategoryOne_ID = cur.Current("CategoryOne_ID")
        CategoryOne_Name = cur.Current("CategoryOne_Name")

    End Sub
    Sub Send_Data(txt() As Guna2TextBox)
        txt(0).Text = CategoryOne_Name

    End Sub

#Region "Methods"
    ''' <summary>
    ''' تنفيذ الإجراء المخزن لحفظ تصنيف واحد جديد
    ''' </summary>
    ''' <returns>عدد السجلات المتأثرة (عادة 1 إذا تم الحفظ بنجاح)</returns>
    Public Function SaveNewCategoryOne() As Integer
        ' اعداد قائمة من parameters
        Dim parameters As New List(Of SqlParameter)
        With parameters
            .Add(New SqlParameter("@CategoryOne_Name", SqlDbType.NVarChar, 100) With {.Value = CategoryOne_Name})
        End With

        ' إعداد الإجراء المخزن
        Dim result As Integer = sqlMethod.ExecuteStoredProcedure("Items.AddNew_CategoryOne", parameters.ToArray())
        ' التحقق من النتيجة
        If result > 0 Then
            MsgBox("تم حفظ التصنيف الأول بنجاح.")
        Else
            MsgBox("حدث خطأ في الحفظ.")
        End If
        Return result
    End Function

    ''' <summary>
    ''' تنفيذ الإجراء المخزن لتعديل تصنيف واحد موجود
    ''' </summary>
    ''' <returns>عدد السجلات المتأثرة (عادة 1 إذا تم التعديل بنجاح)</returns>
    Public Function UpdateCategoryOne() As Integer
        ' اعداد قائمة من parameters
        Dim parameters As New List(Of SqlParameter)
        With parameters
            .Add(New SqlParameter("@CategoryOne_Name", SqlDbType.NVarChar, 100) With {.Value = CategoryOne_Name})
            .Add(New SqlParameter("@Category_ID", SqlDbType.Int) With {.Value = CategoryOne_ID})
        End With

        ' إعداد الإجراء المخزن
        Dim result As Integer = sqlMethod.ExecuteStoredProcedure("Items.Update_CategoryOne", parameters.ToArray())
        ' التحقق من النتيجة
        If result > 0 Then
            MsgBox("تم تعديل التصنيف الأول بنجاح.")
        Else
            MsgBox("حدث خطأ في التعديل.")
        End If
        Return result
    End Function
    ''' <summary>
    ''' عرض البيانات كامله views
    ''' </summary>
    ''' <returns></returns>
    Public Function View_Categorys() As DataTable

        ''' <summary>
        ''' تنفيذ الإجراء المخزن لعرض جميع المستودعات والاقسام
        ''' </summary>
        ' إعداد الإجراء المخزن
        View_Categorys = sqlMethod.ExecuteSelectData("Items.pro_View_CategoryOne")
        ' التحقق من النتيجة

    End Function
#End Region

End Class
