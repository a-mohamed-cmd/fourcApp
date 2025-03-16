Imports Guna.UI2.WinForms
Imports System.Security.Cryptography.X509Certificates
Imports Microsoft.Data.SqlClient

Public Class Countries

    ' المتغيرات الخاصة
    Private _country_ID As Integer
    Private _Country_Name As String
    Private _Country_PhoneKey As String

#Region "property"
    ' الخصائص العامة

    Public Property Country_ID As Integer
        Get
            Return _country_ID
        End Get
        Set(value As Integer)
            _country_ID = value
        End Set
    End Property

    Public Property Country_Name As String
        Get
            Return _Country_Name
        End Get
        Set(value As String)
            _Country_Name = value
        End Set
    End Property

    Public Property Country_PhoneKey As String
        Get
            Return _Country_PhoneKey
        End Get
        Set(value As String)
            _Country_PhoneKey = value
        End Set
    End Property

    ' المُنشئ لتعبئة البيانات عند إنشاء الكائن
    Public Sub New(Optional id As Integer = 0,
                   Optional name As String = "")
        _country_ID = id
        _Country_Name = name
    End Sub

#End Region


    Public Sub import_Data(Optional id As Integer = 0,
Optional countryName As String = "",
                   Optional Country_PhoneKey As String = "")
        _country_ID = id
        _Country_Name = countryName
        _Country_PhoneKey = Country_PhoneKey
    End Sub
    ''' <summary>
    ''' عرض بيانات row
    ''' </summary>
    ''' <param name="cur"></param>
    Sub Load_Data(cur As CurrencyManager)

        Country_ID = cur.Current("country_ID")
        Country_Name = cur.Current("Country_Name")
        Country_PhoneKey = cur.Current("Country_PhoneKey")

    End Sub
    Sub Send_Data(txt() As Guna2TextBox)
        txt(0).Text = Country_Name

    End Sub

#Region "Methods"

    Public Function View_Countries() As DataTable

        ' إعداد الإجراء المخزن
        View_Countries = sqlMethod.ExecuteSelectData("personal.pro_view_Country")
        ' التحقق من النتيجة

    End Function
#End Region
    Public Sub loadCountries(cmd As Guna2ComboBox)
        cmd.DataSource = View_Countries()
        cmd.ValueMember = "country_ID"
        cmd.DisplayMember = "Country_Name"
    End Sub
End Class
