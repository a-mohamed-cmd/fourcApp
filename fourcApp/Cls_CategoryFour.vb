Imports Guna.UI2.WinForms
Imports Microsoft.Data.SqlClient

Public Class CategoryFour

    ' المتغيرات الخاصة
    Private _CategoryFour_ID As Integer
    Private _CategoryFour_Name As String
    Private _dt As New DataTable
#Region "property"



    ' الخصائص العامة
    Public Property CategoryFour_ID As Integer
        Get
            Return _CategoryFour_ID
        End Get
        Set(value As Integer)
            _CategoryFour_ID = value
        End Set
    End Property

    Public Property CategoryFour_Name As String
        Get
            Return _CategoryFour_Name
        End Get
        Set(value As String)
            _CategoryFour_Name = value
        End Set
    End Property

    Public Property Dt As DataTable
        Get
            Return _dt
        End Get
        Set(value As DataTable)
            _dt = value
        End Set
    End Property

    ' المُنشئ لتعبئة البيانات عند إنشاء الكائن
    Public Sub New(Optional id As Integer = 0,
                   Optional name As String = "")
        _CategoryFour_ID = id
        _CategoryFour_Name = name
    End Sub

#End Region

    Public Sub import_Data(Optional id As Integer = 0,
                            Optional nameCategory As String = "")

        _CategoryFour_ID = id
        _CategoryFour_Name = nameCategory

    End Sub
    ''' <summary>
    ''' عرض بيانات row
    ''' </summary>
    ''' <param name="cur"></param>
    Sub Load_Data(cur As CurrencyManager)

        _CategoryFour_ID = cur.Current("CategoryFour_ID")
        _CategoryFour_Name = cur.Current("CategoryFour_Name")

    End Sub
    Sub Send_Data(txt() As Guna2TextBox)
        txt(0).Text = CategoryFour_Name

    End Sub


#Region "Methods"
    ''' <summary>
    ''' تنفيذ الإجراء المخزن لحفظ تصنيف رابع جديد
    ''' </summary>
    ''' <returns>عدد السجلات المتأثرة (عادة 1 إذا تم الحفظ بنجاح)</returns>
    Public Function SaveNewCategoryFour() As Integer
        ' اعداد قائمة من parameters
        Dim parameters As New List(Of SqlParameter)
        With parameters
            .Add(New SqlParameter("@CategoryFour_Name", SqlDbType.NVarChar, 100) With {.Value = CategoryFour_Name})
        End With

        ' إعداد الإجراء المخزن
        Dim result As Integer = sqlMethod.ExecuteStoredProcedure("items.AddNew_CategoryFour", parameters.ToArray())
        ' التحقق من النتيجة
        If result > 0 Then
            MsgBox("تم حفظ التصنيف الرابع بنجاح.")
        Else
            MsgBox("حدث خطأ في الحفظ.")
        End If
        Return result
    End Function

    ''' <summary>
    ''' تنفيذ الإجراء المخزن لتعديل تصنيف رابع موجود
    ''' </summary>
    ''' <returns>عدد السجلات المتأثرة (عادة 1 إذا تم التعديل بنجاح)</returns>
    Public Function UpdateCategoryFour() As Integer
        ' اعداد قائمة من parameters
        Dim parameters As New List(Of SqlParameter)
        With parameters
            .Add(New SqlParameter("@CategoryFour_Name", SqlDbType.NVarChar, 50) With {.Value = CategoryFour_Name})
            .Add(New SqlParameter("@Category_ID", SqlDbType.Int) With {.Value = CategoryFour_ID})
        End With

        ' إعداد الإجراء المخزن
        Dim result As Integer = sqlMethod.ExecuteStoredProcedure("items.Update_CategoryFour", parameters.ToArray())
        ' التحقق من النتيجة
        If result > 0 Then
            MsgBox("تم تعديل التصنيف الرابع بنجاح.")
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
        View_Categorys = sqlMethod.ExecuteSelectData("Items.pro_View_CategoryFour")
        ' التحقق من النتيجة

    End Function
#End Region

End Class

