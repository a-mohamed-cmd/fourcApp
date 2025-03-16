Imports Guna.UI2.WinForms
Imports Microsoft.Data.SqlClient

Public Class CategoryThree

    ' المتغيرات الخاصة
    Private _CategoryThree_ID As Integer
    Private _CategoryThree_Name As String
    Private _dt As New DataTable
#Region "property"
    ' الخصائص العامة
    Public Property CategoryThree_ID As Integer
        Get
            Return _CategoryThree_ID
        End Get
        Set(value As Integer)
            _CategoryThree_ID = value
        End Set
    End Property

    Public Property CategoryThree_Name As String
        Get
            Return _CategoryThree_Name
        End Get
        Set(value As String)
            _CategoryThree_Name = value
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
        _CategoryThree_ID = id
        _CategoryThree_Name = name
    End Sub

#End Region

    Public Sub import_Data(Optional id As Integer = 0,
                            Optional nameCategory As String = "")

        _CategoryThree_ID = id
        _CategoryThree_Name = nameCategory

    End Sub
    ''' <summary>
    ''' عرض بيانات row
    ''' </summary>
    ''' <param name="cur"></param>
    Sub Load_Data(cur As CurrencyManager)

        _CategoryThree_ID = cur.Current("CategoryThree_ID")
        _CategoryThree_Name = cur.Current("CategoryThree_Name")

    End Sub
    Sub Send_Data(txt() As Guna2TextBox)
        txt(0).Text = CategoryThree_Name

    End Sub



#Region "Methods"
    ''' <summary>
    ''' تنفيذ الإجراء المخزن لحفظ تصنيف ثالث جديد
    ''' </summary>
    ''' <returns>عدد السجلات المتأثرة (عادة 1 إذا تم الحفظ بنجاح)</returns>
    Public Function SaveNewCategoryThree() As Integer
        ' اعداد قائمة من parameters
        Dim parameters As New List(Of SqlParameter)
        With parameters
            .Add(New SqlParameter("@CategoryThree_Name", SqlDbType.NVarChar, 100) With {.Value = CategoryThree_Name})
        End With

        ' إعداد الإجراء المخزن
        Dim result As Integer = sqlMethod.ExecuteStoredProcedure("items.AddNew_CategoryThree", parameters.ToArray())
        ' التحقق من النتيجة
        If result > 0 Then
            MsgBox("تم حفظ التصنيف الثالث بنجاح.")
        Else
            MsgBox("حدث خطأ في الحفظ.")
        End If
        Return result
    End Function

    ''' <summary>
    ''' تنفيذ الإجراء المخزن لتعديل تصنيف ثالث موجود
    ''' </summary>
    ''' <returns>عدد السجلات المتأثرة (عادة 1 إذا تم التعديل بنجاح)</returns>
    Public Function UpdateCategoryThree() As Integer
        ' اعداد قائمة من parameters
        Dim parameters As New List(Of SqlParameter)
        With parameters
            .Add(New SqlParameter("@CategoryThree_Name", SqlDbType.NVarChar, 100) With {.Value = CategoryThree_Name})
            .Add(New SqlParameter("@Category_ID", SqlDbType.Int) With {.Value = CategoryThree_ID})
        End With

        ' إعداد الإجراء المخزن
        Dim result As Integer = sqlMethod.ExecuteStoredProcedure("items.Update_CategoryThree", parameters.ToArray())
        ' التحقق من النتيجة
        If result > 0 Then
            MsgBox("تم تعديل التصنيف الثالث بنجاح.")
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
        View_Categorys = sqlMethod.ExecuteSelectData("Items.pro_View_CategoryThree")
        ' التحقق من النتيجة

    End Function
#End Region

End Class
