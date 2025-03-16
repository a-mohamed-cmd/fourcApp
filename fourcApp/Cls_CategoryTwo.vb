Imports Guna.UI2.WinForms
Imports Microsoft.Data.SqlClient

Public Class CategoryTwo

    ' المتغيرات الخاصة
    Private _CategoryTwo_ID As Integer
    Private _CategoryTwo_Name As String
    Private _dt As New DataTable
#Region "property"
    ' الخصائص العامة
    Public Property CategoryTwo_ID As Integer
        Get
            Return _CategoryTwo_ID
        End Get
        Set(value As Integer)
            _CategoryTwo_ID = value
        End Set
    End Property

    Public Property CategoryTwo_Name As String
        Get
            Return _CategoryTwo_Name
        End Get
        Set(value As String)
            _CategoryTwo_Name = value
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
        _CategoryTwo_ID = id
        _CategoryTwo_Name = name
    End Sub

#End Region

    Public Sub import_Data(Optional id As Integer = 0,
                            Optional nameCategory As String = "")

        _CategoryTwo_ID = id
        _CategoryTwo_Name = nameCategory

    End Sub
    ''' <summary>
    ''' عرض بيانات row
    ''' </summary>
    ''' <param name="cur"></param>
    Sub Load_Data(cur As CurrencyManager)

        _CategoryTwo_ID = cur.Current("CategoryTwo_ID")
        _CategoryTwo_Name = cur.Current("CategoryTwo_Name")

    End Sub
    Sub Send_Data(txt() As Guna2TextBox)
        txt(0).Text = CategoryTwo_Name

    End Sub


#Region "Methods"
    ''' <summary>
    ''' تنفيذ الإجراء المخزن لحفظ تصنيف ثاني جديد
    ''' </summary>
    ''' <returns>عدد السجلات المتأثرة (عادة 1 إذا تم الحفظ بنجاح)</returns>
    Public Function SaveNewCategoryTwo() As Integer
        ' اعداد قائمة من parameters
        Dim parameters As New List(Of SqlParameter)
        With parameters
            .Add(New SqlParameter("@CategoryTwo_Name", SqlDbType.NVarChar, 100) With {.Value = CategoryTwo_Name})
        End With

        ' إعداد الإجراء المخزن
        Dim result As Integer = sqlMethod.ExecuteStoredProcedure("items.AddNew_CategoryTwo", parameters.ToArray())
        ' التحقق من النتيجة
        If result > 0 Then
            MsgBox("تم حفظ التصنيف الثاني بنجاح.")
        Else
            MsgBox("حدث خطأ في الحفظ.")
        End If
        Return result
    End Function

    ''' <summary>
    ''' تنفيذ الإجراء المخزن لتعديل تصنيف ثاني موجود
    ''' </summary>
    ''' <returns>عدد السجلات المتأثرة (عادة 1 إذا تم التعديل بنجاح)</returns>
    Public Function UpdateCategoryTwo() As Integer
        ' اعداد قائمة من parameters
        Dim parameters As New List(Of SqlParameter)
        With parameters
            .Add(New SqlParameter("@CategoryTwo_Name", SqlDbType.NVarChar, 100) With {.Value = CategoryTwo_Name})
            .Add(New SqlParameter("@Category_ID", SqlDbType.Int) With {.Value = CategoryTwo_ID})
        End With

        ' إعداد الإجراء المخزن
        Dim result As Integer = sqlMethod.ExecuteStoredProcedure("items.Update_CategoryTwo", parameters.ToArray())
        ' التحقق من النتيجة
        If result > 0 Then
            MsgBox("تم تعديل التصنيف الثاني بنجاح.")
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
        View_Categorys = sqlMethod.ExecuteSelectData("Items.pro_View_CategoryTwo")
        ' التحقق من النتيجة

    End Function
#End Region

End Class

