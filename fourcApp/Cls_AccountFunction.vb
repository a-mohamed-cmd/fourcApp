Public Class Cls_AccountFunction
    ' المتغيرات الخاصة
    Private _AccFunction_ID As Integer
    Private _AccFunction_Depit As Decimal
    Private _AccFunction_Credit As Decimal
    Private _AccFunction_Note As String
    Private _AccFunction_Code As String
    Private _AccountSub_Code As String
    Private _AccFunction_Date As DateTime

    ' الخصائص العامة

    ''' <summary>
    ''' رقم العملية (المفتاح الأساسي)
    ''' </summary>
    Public Property AccFunction_ID As Integer
        Get
            Return _AccFunction_ID
        End Get
        Set(value As Integer)
            _AccFunction_ID = value
        End Set
    End Property

    ''' <summary>
    ''' المبلغ المدين
    ''' </summary>
    Public Property AccFunction_Depit As Decimal
        Get
            Return _AccFunction_Depit
        End Get
        Set(value As Decimal)
            _AccFunction_Depit = value
        End Set
    End Property

    ''' <summary>
    ''' المبلغ الدائن
    ''' </summary>
    Public Property AccFunction_Credit As Decimal
        Get
            Return _AccFunction_Credit
        End Get
        Set(value As Decimal)
            _AccFunction_Credit = value
        End Set
    End Property

    ''' <summary>
    ''' ملاحظات
    ''' </summary>
    Public Property AccFunction_Note As String
        Get
            Return _AccFunction_Note
        End Get
        Set(value As String)
            _AccFunction_Note = value
        End Set
    End Property

    ''' <summary>
    ''' كود الحركة
    ''' </summary>
    Public Property AccFunction_Code As String
        Get
            Return _AccFunction_Code
        End Get
        Set(value As String)
            _AccFunction_Code = value
        End Set
    End Property

    ''' <summary>
    ''' كود الحساب الفرعي
    ''' </summary>
    Public Property AccountSub_Code As String
        Get
            Return _AccountSub_Code
        End Get
        Set(value As String)
            _AccountSub_Code = value
        End Set
    End Property

    ''' <summary>
    ''' تاريخ الحركة
    ''' </summary>
    Public Property AccFunction_Date As DateTime
        Get
            Return _AccFunction_Date
        End Get
        Set(value As DateTime)
            _AccFunction_Date = value
        End Set
    End Property


    ''' <summary>
    ''' مُنشئ لتعبئة الكائن مباشرة عند الإنشاء
    ''' </summary>
    Public Sub New(Optional id As Integer = 0,
                   Optional depit As Decimal = 0,
                   Optional credit As Decimal = 0,
                   Optional note As String = "",
                   Optional code As String = "",
                   Optional subCode As String = "",
                   Optional transDate As DateTime = Nothing)

        _AccFunction_ID = id
        _AccFunction_Depit = depit
        _AccFunction_Credit = credit
        _AccFunction_Note = note
        _AccFunction_Code = code
        _AccountSub_Code = subCode
        _AccFunction_Date = If(transDate = Nothing, DateTime.Now, transDate)
    End Sub

End Class
