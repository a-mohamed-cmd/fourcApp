Imports Guna.UI2.WinForms
Imports System.Security.Cryptography.X509Certificates
Imports Microsoft.Data.SqlClient

Public Class Unit

    ' المتغيرات الخاصة
    Private _Unit_ID As Integer
    Private _Unit_Name As String

#Region "property"
    ' الخصائص العامة
    Public Property Unit_ID As Integer
        Get
            Return _Unit_ID
        End Get
        Set(value As Integer)
            _Unit_ID = value
        End Set
    End Property

    Public Property Unit_Name As String
        Get
            Return _Unit_Name
        End Get
        Set(value As String)
            _Unit_Name = value
        End Set
    End Property

    ' المُنشئ لتعبئة البيانات عند إنشاء الكائن
    Public Sub New(Optional id As Integer = 0,
                   Optional name As String = "")
        _Unit_ID = id
        _Unit_Name = name
    End Sub

#End Region


    Public Sub import_Data(Optional id As Integer = 0,
Optional name As String = "",
                   Optional unitName As String = "")
        _Unit_ID = id
        _Unit_Name = unitName

    End Sub
    ''' <summary>
    ''' عرض بيانات row
    ''' </summary>
    ''' <param name="cur"></param>
    Sub Load_Data(cur As CurrencyManager)

        Unit_ID = cur.Current("Unit_ID")
        Unit_Name = cur.Current("Unit_Name")


    End Sub
    Sub Send_Data(txt() As Guna2TextBox)
        txt(0).Text = Unit_Name

    End Sub

#Region "Methods"
    ''' <summary>
    ''' تنفيذ الإجراء المخزن لحفظ وحدة قياس جديدة
    ''' </summary>
    ''' <returns>عدد السجلات المتأثرة (عادة 1 إذا تم الحفظ بنجاح)</returns>
    Public Function SaveNewUnit() As Integer
        ' اعداد قائمة من parameters
        Dim parameters As New List(Of SqlParameter)
        With parameters
            .Add(New SqlParameter("@Unit_Name", SqlDbType.NVarChar, 10) With {.Value = Unit_Name})
        End With

        ' إعداد الإجراء المخزن
        Dim result As Integer = sqlMethod.ExecuteStoredProcedure("items.AddNew_Unit", parameters.ToArray())
        ' التحقق من النتيجة
        If result > 0 Then
            MsgBox("تم حفظ الوحدة بنجاح.")
        Else
            MsgBox("حدث خطأ في الحفظ.")
        End If
        Return result
    End Function

    ''' <summary>
    ''' تنفيذ الإجراء المخزن لتعديل وحدة قياس موجودة
    ''' </summary>
    ''' <returns>عدد السجلات المتأثرة (عادة 1 إذا تم التعديل بنجاح)</returns>
    Public Function UpdateUnit() As Integer
        ' اعداد قائمة من parameters
        Dim parameters As New List(Of SqlParameter)
        With parameters
            .Add(New SqlParameter("@Unit_Name", SqlDbType.NVarChar, 10) With {.Value = Unit_Name})
            .Add(New SqlParameter("@Unit_ID", SqlDbType.Int) With {.Value = Unit_ID})
        End With

        ' إعداد الإجراء المخزن
        Dim result As Integer = sqlMethod.ExecuteStoredProcedure("Items.Update_Unit", parameters.ToArray())
        ' التحقق من النتيجة
        If result > 0 Then
            MsgBox("تم تعديل الوحدة بنجاح.")
        Else
            MsgBox("حدث خطأ في التعديل.")
        End If
        Return result
    End Function
    Public Function View_Units() As DataTable

        ' إعداد الإجراء المخزن
        View_Units = sqlMethod.ExecuteSelectData("Items.pro_view_Units")
        ' التحقق من النتيجة

    End Function
#End Region

End Class
