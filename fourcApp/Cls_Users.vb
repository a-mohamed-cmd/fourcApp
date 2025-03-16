Imports Guna.UI2.WinForms
Imports Microsoft.Data.SqlClient

Public Class Cls_PermissionType

    Private _userType_Name As String

#Region "property"


    Public Property UserType_Name As String
        Get
            Return _userType_Name
        End Get
        Set(value As String)
            _userType_Name = value
        End Set
    End Property
#End Region

End Class

Public Class Cls_Users_Permission
    Private _userper_ID As Integer
    Private _userperType_ID As Integer

    Private _userPer_ISActive As Boolean
#Region "Properyt"
    Public Property Userper_ID As Integer
        Get
            Return _userper_ID
        End Get
        Set(value As Integer)
            _userper_ID = value
        End Set
    End Property


    Public Property UserPer_ISActive As Boolean
        Get
            Return _userPer_ISActive
        End Get
        Set(value As Boolean)
            _userPer_ISActive = value
        End Set
    End Property

    Public Property UserperType_ID As Integer
        Get
            Return _userperType_ID
        End Get
        Set(value As Integer)
            _userperType_ID = value
        End Set
    End Property
#End Region

End Class

Public Class Cls_Users
    Private _users_ID As Integer
    Private _user_NameAr As String
    Private _user_NameEn As String
    Private _user_userName As String
    Private _user_password As String
    Private _userType_ID As Integer
    Private _user_IsActive As Boolean
    Private _dtpermission As DataTable

    Dim Permission_type As New cls_PermissionType()
    Dim User_Permission As New Cls_Users_Permission()
#Region "property"
    Public Property Users_ID As Integer
        Get
            Return _users_ID
        End Get
        Set(value As Integer)
            _users_ID = value
        End Set
    End Property

    Public Property User_NameAr As String
        Get
            Return _user_NameAr
        End Get
        Set(value As String)
            _user_NameAr = value
        End Set
    End Property

    Public Property User_NameEn As String
        Get
            Return _user_NameEn
        End Get
        Set(value As String)
            _user_NameEn = value
        End Set
    End Property

    Public Property User_userName As String
        Get
            Return _user_userName
        End Get
        Set(value As String)
            _user_userName = value
        End Set
    End Property

    Public Property User_password As String
        Get
            Return _user_password
        End Get
        Set(value As String)
            _user_password = value
        End Set
    End Property

    Public Property UserType_ID As Integer
        Get
            Return _userType_ID
        End Get
        Set(value As Integer)
            _userType_ID = value
        End Set
    End Property

    Public Property User_IsActive As Boolean
        Get
            Return _user_IsActive
        End Get
        Set(value As Boolean)
            _user_IsActive = value
        End Set
    End Property

    Public Property Permission_type1 As cls_PermissionType
        Get
            Return Permission_type
        End Get
        Set(value As cls_PermissionType)
            Permission_type = value
        End Set
    End Property

    Public Property User_Permission1 As Cls_Users_Permission
        Get
            Return User_Permission
        End Get
        Set(value As Cls_Users_Permission)
            User_Permission = value
        End Set
    End Property

    Public Property Dtpermission As DataTable
        Get
            Return _dtpermission
        End Get
        Set(value As DataTable)
            _dtpermission = value
        End Set
    End Property

#End Region

#Region "constract"

    Public Sub New(Optional userType_ID As Integer = 0,
             Optional userType_Name As String = "",
            Optional userper_ID As Integer = 0,
               Optional users_ID As Integer = 0,
               Optional userperType_ID As Integer = 0,
               Optional userPer_ISActive As Boolean = True,
               Optional user_NameAr As String = "",
               Optional user_NameEn As String = "",
               Optional user_userName As String = "",
               Optional user_password As String = "",
               Optional user_IsActive As Boolean = True)



        Permission_type1.UserType_Name = userType_Name
        User_Permission1.UserperType_ID = userperType_ID
        User_Permission1.Userper_ID = userper_ID
        User_Permission1.UserPer_ISActive = userPer_ISActive

        _users_ID = users_ID
        _user_NameAr = user_NameAr
        _user_NameEn = user_NameEn
        _user_userName = user_userName
        _user_password = user_password
        _userType_ID = userType_ID
        _user_IsActive = user_IsActive

    End Sub
#End Region
    Public Sub Import_Data(Optional userType_ID As Integer = 0,
               Optional user_NameAr As String = "",
               Optional user_NameEn As String = "",
               Optional user_userName As String = "",
               Optional user_password As String = "",
               Optional user_IsActive As Boolean = True)


        _user_NameAr = user_NameAr
        _user_NameEn = user_NameEn
        _user_userName = user_userName
        _user_password = user_password
        _userType_ID = userType_ID
        _user_IsActive = user_IsActive

    End Sub
    Sub load_purmission(swt() As Guna2ToggleSwitch, label() As Label)
        swt(0).Checked = Dtpermission(0)("userPer_ISActive")
        label(0).Text = Dtpermission(0)("userperType_Name")
        swt(1).Checked = Dtpermission(1)("userPer_ISActive")
        label(1).Text = Dtpermission(1)("userperType_Name")
        swt(2).Checked = Dtpermission(2)("userPer_ISActive")
        label(2).Text = Dtpermission(2)("userperType_Name")
        swt(3).Checked = Dtpermission(3)("userPer_ISActive")
        label(3).Text = Dtpermission(3)("userperType_Name")
        swt(4).Checked = Dtpermission(4)("userPer_ISActive")
        label(4).Text = Dtpermission(4)("userperType_Name")
        swt(5).Checked = Dtpermission(5)("userPer_ISActive")
        label(5).Text = Dtpermission(5)("userperType_Name")
        swt(6).Checked = Dtpermission(6)("userPer_ISActive")
        label(6).Text = Dtpermission(6)("userperType_Name")
        swt(7).Checked = Dtpermission(7)("userPer_ISActive")
        label(7).Text = Dtpermission(7)("userperType_Name")
        swt(8).Checked = Dtpermission(8)("userPer_ISActive")
        label(8).Text = Dtpermission(8)("userperType_Name")
        swt(9).Checked = Dtpermission(9)("userPer_ISActive")
        label(9).Text = Dtpermission(9)("userperType_Name")
        swt(10).Checked = Dtpermission(10)("userPer_ISActive")
        label(10).Text = Dtpermission(10)("userperType_Name")
        swt(11).Checked = Dtpermission(11)("userPer_ISActive")
        label(11).Text = Dtpermission(11)("userperType_Name")
        swt(12).Checked = Dtpermission(12)("userPer_ISActive")
        label(12).Text = Dtpermission(12)("userperType_Name")
        swt(13).Checked = Dtpermission(13)("userPer_ISActive")
        label(13).Text = Dtpermission(13)("userperType_Name")
        swt(14).Checked = Dtpermission(14)("userPer_ISActive")
        label(14).Text = Dtpermission(14)("userperType_Name")
        swt(15).Checked = Dtpermission(15)("userPer_ISActive")
        label(15).Text = Dtpermission(15)("userperType_Name")
        swt(16).Checked = Dtpermission(16)("userPer_ISActive")
        label(16).Text = Dtpermission(16)("userperType_Name")
        swt(17).Checked = Dtpermission(17)("userPer_ISActive")
        label(17).Text = Dtpermission(17)("userperType_Name")
        swt(18).Checked = Dtpermission(18)("userPer_ISActive")
        label(18).Text = Dtpermission(18)("userperType_Name")
        swt(19).Checked = Dtpermission(19)("userPer_ISActive")
        label(19).Text = Dtpermission(19)("userperType_Name")
        swt(20).Checked = Dtpermission(20)("userPer_ISActive")
        label(20).Text = Dtpermission(20)("userperType_Name")
        swt(21).Checked = Dtpermission(21)("userPer_ISActive")
        label(21).Text = Dtpermission(21)("userperType_Name")
        swt(22).Checked = Dtpermission(22)("userPer_ISActive")
        label(22).Text = Dtpermission(22)("userperType_Name")
        swt(23).Checked = Dtpermission(23)("userPer_ISActive")
        label(23).Text = Dtpermission(23)("userperType_Name")
        swt(24).Checked = Dtpermission(24)("userPer_ISActive")
        label(24).Text = Dtpermission(24)("userperType_Name")
        swt(25).Checked = Dtpermission(25)("userPer_ISActive")
        label(25).Text = Dtpermission(25)("userperType_Name")
        swt(26).Checked = Dtpermission(26)("userPer_ISActive")
        label(26).Text = Dtpermission(26)("userperType_Name")
        swt(27).Checked = Dtpermission(27)("userPer_ISActive")
        label(27).Text = Dtpermission(27)("userperType_Name")
        swt(28).Checked = Dtpermission(28)("userPer_ISActive")
        label(28).Text = Dtpermission(28)("userperType_Name")
        swt(29).Checked = Dtpermission(29)("userPer_ISActive")
        label(29).Text = Dtpermission(29)("userperType_Name")
        swt(30).Checked = Dtpermission(30)("userPer_ISActive")
        label(30).Text = Dtpermission(30)("userperType_Name")
        swt(31).Checked = Dtpermission(31)("userPer_ISActive")
        label(31).Text = Dtpermission(31)("userperType_Name")
        swt(32).Checked = Dtpermission(32)("userPer_ISActive")
        label(32).Text = Dtpermission(32)("userperType_Name")


    End Sub

    ''' <summary>
    ''' عرض بيانات row
    ''' </summary>
    ''' <param name="cur"></param>
    Sub Load_Data(cur As CurrencyManager)
        Users_ID = cur.Current("users_ID")
        User_NameAr = cur.Current("User_NameAr")
        User_NameEn = If(IsDBNull(cur.Current("User_NameEn")),
                                    Nothing, cur.Current("User_NameEn"))
        User_userName = If(IsDBNull(cur.Current("User_userName")),
                                    Nothing, cur.Current("User_userName"))
        User_password = cur.Current("User_password")
        UserType_ID = If(IsDBNull(cur.Current("UserType_ID")),
                                    Nothing, cur.Current("UserType_ID"))

        User_IsActive = If(IsDBNull(cur.Current("User_IsActive")),
                                    Nothing, (cur.Current("User_IsActive")))
        'Permission_type1.UserType_Name = If(IsDBNull(cur.Current("UserType_Name")),
        '                            Nothing, (cur.Current("UserType_Name")))
        'User_Permission1.UserperType_ID = If(IsDBNull(cur.Current("UserperType_ID")),
        '                            Nothing, (cur.Current("UserperType_ID")))
        'User_Permission1.Userper_ID = If(IsDBNull(cur.Current("Userper_ID")),
        '                            Nothing, (cur.Current("Userper_ID")))
        'User_Permission1.UserPer_ISActive = If(IsDBNull(cur.Current("UserPer_ISActive")),
        '                            Nothing, (cur.Current("UserPer_ISActive")))
    End Sub
    ''' <summary>
    ''' ارسال البيانات 
    ''' </summary>
    ''' <param name="txt"></param>
    ''' <param name="com"></param>
    Sub Send_Data(txt() As Guna2TextBox, com() As Guna2ComboBox, swt() As Guna2ToggleSwitch)
        txt(0).Text = User_NameAr
        txt(1).Text = User_NameEn
        txt(2).Text = User_userName
        txt(3).Text = User_password
        txt(4).Text = Users_ID
        com(0).SelectedValue = UserType_ID

        'txt(4).Text = LastSalePrice
        'txt(5).Text = LastSalePrice
        swt(0).Checked = User_IsActive


    End Sub

    Sub Update_Users()
        UpdateUser()
        'UpdateUserPermission()
    End Sub
#Region "Methods"
    ''' <summary>
    ''' تنفيذ الإجراء المخزن لتعديل صلاحيات المستخدمين
    ''' </summary>
    ''' <returns>عدد السجلات المتأثرة (عادة 1 إذا تم الحفظ بنجاح)</returns>
    Public Function UpdateUserPermission() As Integer
        Dim parameters As New List(Of SqlParameter) From {
            New SqlParameter("@userPer_ISActive", SqlDbType.Bit) With {.Value = User_Permission1.UserPer_ISActive},
            New SqlParameter("@Userper_type", SqlDbType.NVarChar, 150) With {.Value = Permission_type1.UserType_Name},
            New SqlParameter("@users_ID", SqlDbType.Int) With {.Value = Users_ID}
        }

        Dim result As Integer = sqlMethod.ExecuteStoredProcedure("Users.update_UsersPermission", parameters.ToArray())
        If result > 0 Then
            MsgBox("تم تحديث الصلاحية بنجاح.")
        Else
            MsgBox("حدث خطأ أثناء تحديث الصلاحية.")
        End If
        Return result
    End Function

    ''' <summary>
    ''' تقوم بتحديث بيانات مستخدم موجود في قاعدة البيانات باستخدام الإجراء المخزن "Users.Update_Users".
    ''' </summary>
    ''' <returns>رقم صحيح يمثل عدد الصفوف المتأثرة. إذا كانت القيمة أكبر من صفر، فإن التحديث تم بنجاح.</returns>
    ''' <remarks>
    ''' يجب أن تكون خاصيات الكائن (User_NameAr، User_UserName، User_Password، UserType_ID، Users_ID) معبأة بشكل صحيح.
    ''' يتم التعامل مع الاسم الإنجليزي كقيمة اختيارية.
    ''' </remarks>
    Public Function UpdateUser() As Integer
        Dim parameters As New List(Of SqlParameter) From {
        New SqlParameter("@user_NameAr", SqlDbType.NVarChar, 50) With {.Value = User_NameAr},
        New SqlParameter("@user_NameEn", SqlDbType.NVarChar, 50) With {.Value = If(User_NameEn, DBNull.Value)},
        New SqlParameter("@user_userName", SqlDbType.NVarChar, 20) With {.Value = User_userName},
        New SqlParameter("@userType_ID", SqlDbType.Int) With {.Value = UserType_ID},
        New SqlParameter("@user_IsActive", SqlDbType.Bit) With {.Value = User_IsActive},
        New SqlParameter("@User_ID", SqlDbType.Int) With {.Value = Users_ID}
    }

        Dim result As Integer = sqlMethod.ExecuteStoredProcedure("Users.Update_Users", parameters.ToArray())
        If result > 0 Then
            MsgBox("تم تحديث المستخدم بنجاح.")
        Else
            MsgBox("حدث خطأ أثناء تحديث المستخدم.")
        End If
        Return result
    End Function

    ''' <summary>
    ''' يقوم بإضافة مستخدم جديد إلى جدول [Users].[TB_Users] في قاعدة البيانات.
    ''' يستخدم الإجراء المخزن "Users.AddNew_Users".
    ''' </summary>
    ''' <param name="User_NameAr">اسم المستخدم باللغة العربية (إجباري).</param>
    ''' <param name="User_NameEn">اسم المستخدم باللغة الإنجليزية (اختياري).</param>
    ''' <param name="User_UserName">اسم الدخول الخاص بالمستخدم (إجباري).</param>
    ''' <param name="User_Password">كلمة المرور الخاصة بالمستخدم (إجباري).</param>
    ''' <param name="UserType_ID">معرّف نوع المستخدم (إجباري).</param>
    ''' <param name="User_IsActive">حالة تفعيل المستخدم (افتراضيًا: مفعّل).</param>
    ''' <returns>عدد الصفوف المتأثرة عند نجاح الإضافة (عادة يكون 1).</returns>
    ''' <remarks>تأكد من التحقق من عدم تكرار اسم الدخول قبل تنفيذ هذه العملية.</remarks>
    Public Function AddNewUser() As Integer
        Dim parameters As New List(Of SqlParameter) From {
        New SqlParameter("@user_NameAr", SqlDbType.NVarChar, 50) With {.Value = User_NameAr},
        New SqlParameter("@user_NameEn", SqlDbType.NVarChar, 50) With {.Value = If(User_NameEn, DBNull.Value)},
        New SqlParameter("@user_userName", SqlDbType.NVarChar, 20) With {.Value = User_userName},
        New SqlParameter("@user_password", SqlDbType.NVarChar, 255) With {.Value = User_password},
        New SqlParameter("@userType_ID", SqlDbType.Int) With {.Value = UserType_ID},
        New SqlParameter("@user_IsActive", SqlDbType.Bit) With {.Value = User_IsActive}
    }

        Dim result As Integer = sqlMethod.ExecuteStoredProcedure("Users.AddNew_Users", parameters.ToArray())
        If result > 0 Then
            MsgBox("تم إضافة المستخدم بنجاح.")
        Else
            MsgBox("حدث خطأ أثناء إضافة المستخدم.")
        End If
        Return result
    End Function

    ''' <summary>
    ''' يقوم بتحديث كلمة مرور المستخدم في جدول [Users].[TB_Users].
    ''' يستخدم الإجراء المخزن "Users.Update_Users_Password".
    ''' </summary>
    ''' <param name="User_Password">كلمة المرور الجديدة للمستخدم.</param>
    ''' <param name="Users_ID">معرّف المستخدم الذي سيتم تحديث كلمة مروره.</param>
    ''' <returns>عدد الصفوف المتأثرة (عادة يكون 1 إذا تم التحديث بنجاح).</returns>
    ''' <remarks>تأكد من تأمين كلمة المرور (مثل التشفير) قبل حفظها في قاعدة البيانات.</remarks>
    Public Function UpdateUserPassword(new_password As String) As Integer
        Dim parameters As New List(Of SqlParameter) From {
        New SqlParameter("@old_user_password", SqlDbType.NVarChar, 255) With {.Value = User_password},
        New SqlParameter("@user_userName", SqlDbType.NVarChar, 255) With {.Value = User_userName},
        New SqlParameter("@user_password", SqlDbType.NVarChar, 255) With {.Value = new_password}
    }

        Dim result As Integer = sqlMethod.ExecuteStoredProcedure("Users.Update_Users_Password", parameters.ToArray())
        If result > 0 Then
            MsgBox("تم تحديث كلمة المرور بنجاح.")
        Else
            MsgBox("حدث خطأ أثناء تحديث كلمة المرور.")
        End If
        Return result
    End Function
    Public Shared Function View_ItemsInfo() As DataTable

        ' إعداد الإجراء المخزن
        View_ItemsInfo = sqlMethod.ExecuteSelectData("users.pro_view_Users")
        ' التحقق من النتيجة

    End Function

    Public Function View_UserPermission() As DataTable
        Dim parameters As New List(Of SqlParameter) From {
       New SqlParameter("@userID", SqlDbType.Int) With {.Value = Users_ID}}
        ' إعداد الإجراء المخزن
        Dtpermission = sqlMethod.ExecuteSelectData("Users.UsersPermision", parameters.ToArray())
        ' التحقق من النتيجة
        Return Dtpermission
    End Function

    Public Function Login_User() As Integer
        Dim parameters As New List(Of SqlParameter) From {
       New SqlParameter("@user_userName", SqlDbType.NVarChar, 255) With {.Value = User_userName},
       New SqlParameter("@user_Password", SqlDbType.NVarChar, 255) With {.Value = User_password}}
        ' إعداد الإجراء المخزن
        DtLogin = sqlMethod.ExecuteSelectData("Users.Users_Login", parameters.ToArray())
        ' التحقق من النتيجة
        If DtLogin.Rows.Count = Nothing Then Return 0
        Return 1
    End Function
    Public Function LoginVaildate() As Boolean
        LoginVaildate = DtLogin.Rows(0)("user_IsActive")
    End Function
    Public Shared Sub Com_usertype(com As Guna2ComboBox)

        ' إعداد الإجراء المخزن
        com.DataSource = sqlMethod.ExecuteSelectData("Users.pro_View_userType")
        com.DisplayMember = "userType_Name"
        com.ValueMember = "userType_ID"
        ' التحقق من النتيجة

    End Sub
    Public Shared Function LoginVaidateType(type As String) As Boolean
        For Each vaildate In DtLogin.Rows
            If vaildate("userperType_Name") = type Then
                LoginVaidateType = vaildate("userPer_ISActive")
                Exit For
            End If
        Next
        Return LoginVaidateType
    End Function
#End Region

End Class
