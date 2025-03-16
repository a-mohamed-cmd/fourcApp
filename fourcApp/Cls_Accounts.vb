Imports Microsoft.Data.SqlClient
Public Class Accounts_General
    Private _AccountGen_ID As Integer
    Private _AccountGen_NameAr As String

#Region "Property"
    Public Property AccountGen_ID As Integer
        Get
            Return _AccountGen_ID
        End Get
        Set(value As Integer)
            _AccountGen_ID = value
        End Set
    End Property

    Public Property AccountGen_NameAr As String
        Get
            Return _AccountGen_NameAr
        End Get
        Set(value As String)
            _AccountGen_NameAr = value
        End Set
    End Property
#End Region
End Class

Public Class Cls_Accounts


    ' المتغيرات الخاصة
    Private _AccountSub_ID As Integer
    Private _AccountSub_Code As String
    Private _account_gen As Accounts_General
    Private _AccountSub_Name As String
        Private _AccountSub_ISActive As Boolean

#Region "property"
        ' الخصائص العامة
        Public Property AccountSub_ID As Integer
            Get
                Return _AccountSub_ID
            End Get
            Set(value As Integer)
                _AccountSub_ID = value
            End Set
        End Property

        Public Property AccountSub_Code As String
            Get
                Return _AccountSub_Code
            End Get
            Set(value As String)
                _AccountSub_Code = value
            End Set
        End Property

    Public Property account_gen As Accounts_General
        Get
            Return _account_gen
        End Get
        Set(value As Accounts_General)
            _account_gen = value

        End Set
    End Property

    Public Property AccountSub_Name As String
            Get
                Return _AccountSub_Name
            End Get
            Set(value As String)
                _AccountSub_Name = value
            End Set
        End Property

        Public Property AccountSub_ISActive As Boolean
            Get
                Return _AccountSub_ISActive
            End Get
            Set(value As Boolean)
                _AccountSub_ISActive = value
            End Set
        End Property

        ' المُنشئ لتعبئة البيانات عند إنشاء الكائن
        Public Sub New(Optional id As Integer = 0,
                   Optional code As String = "",
                   Optional genID As Integer = 0,
                   Optional name As String = "",
                   Optional isActive As Boolean = True)
            _AccountSub_ID = id
            _AccountSub_Code = code
        _account_gen.AccountGen_ID = genID
        _AccountSub_Name = name
            _AccountSub_ISActive = isActive
        End Sub

#End Region

#Region "Methods"
        ''' <summary>
        ''' تنفيذ الإجراء المخزن لحفظ حساب فرعي جديد
        ''' </summary>
        ''' <returns>عدد السجلات المتأثرة (عادة 1 إذا تم الحفظ بنجاح)</returns>
        Public Function SaveNewAccountSub() As Integer
            ' اعداد قائمة من parameters
            Dim parameters As New List(Of SqlParameter)
        With parameters
            .Add(New SqlParameter("@paymentName", SqlDbType.NVarChar, 150) With {.Value = AccountSub_Name})
            .Add(New SqlParameter("@IsActive", SqlDbType.Bit) With {.Value = AccountSub_ISActive})
        End With

        ' إعداد الإجراء المخزن
        Dim result As Integer = sqlMethod.ExecuteStoredProcedure("Accounts.AddNewPayment", parameters.ToArray())
        ' التحقق من النتيجة
        If result > 0 Then
                MsgBox("تم حفظ الحساب الفرعي بنجاح.")
            Else
                MsgBox("حدث خطأ في الحفظ.")
            End If
            Return result
        End Function

        ''' <summary>
        ''' تنفيذ الإجراء المخزن لتعديل حساب فرعي
        ''' </summary>
        ''' <returns>عدد السجلات المتأثرة (عادة 1 إذا تم التعديل بنجاح)</returns>
        Public Function UpdateAccountSub() As Integer
            ' اعداد قائمة من parameters
            Dim parameters As New List(Of SqlParameter)
            With parameters
            .Add(New SqlParameter("@paymentName", SqlDbType.NVarChar, 150) With {.Value = AccountSub_Name})
            .Add(New SqlParameter("@IsActive", SqlDbType.Bit) With {.Value = AccountSub_ISActive})
            .Add(New SqlParameter("@AccountSub_ID", SqlDbType.Int) With {.Value = AccountSub_ID})
        End With

        ' إعداد الإجراء المخزن
        Dim result As Integer = sqlMethod.ExecuteStoredProcedure("Accounts.Update_Payment", parameters.ToArray())
        ' التحقق من النتيجة
        If result > 0 Then
                MsgBox("تم تعديل الحساب الفرعي بنجاح.")
            Else
                MsgBox("حدث خطأ في التعديل.")
            End If
            Return result
        End Function

#End Region

    End Class

