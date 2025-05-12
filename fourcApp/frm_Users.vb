Imports System.Drawing.Imaging
Imports Guna.UI2.WinForms
Imports Microsoft.VisualBasic.ApplicationServices

Public Class Frm_Users
    Private _cur As CurrencyManager
    Private _dt As New DataTable
    Private _user As New Cls_Users
    Private _isloading As Boolean = True
    Public Property Users As Cls_Users
        Get
            Return _user
        End Get
        Set(value As Cls_Users)
            _user = value
        End Set
    End Property

    Public Property Isloading As Boolean
        Get
            Return _isloading
        End Get
        Set(value As Boolean)
            _isloading = value
        End Set
    End Property

    Private Sub Frm_Items_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UC_cur1.ColorCur = Color.FromArgb(196, 207, 137)
        Load_btn_Event_of_Cur()
    End Sub
#Region "Buttons Cur"
    Private Sub Load_btn_Event_of_Cur()
        AddHandler Me.UC_cur1.Btn_AddItem.Click, AddressOf Btn_Addstore
        AddHandler Me.UC_cur1.btn_newItem.Click, AddressOf Btn_Clear
        AddHandler Me.UC_cur1.btn_updateItem.Click, AddressOf Btn_UpdateStore
        AddHandler Me.UC_cur1.Btn_After.Click, AddressOf Btn_After
        AddHandler Me.UC_cur1.Btn_First.Click, AddressOf Btn_First
        AddHandler Me.UC_cur1.Btn_last.Click, AddressOf Btn_Last
        AddHandler Me.UC_cur1.Btn_Next.Click, AddressOf Btn_Next

        UC_cur1.Visibility(Cls_Users.LoginVaidateType("اضافه المستخدمين"),
                           Cls_Users.LoginVaidateType("اضافه المستخدمين"),
                           Cls_Users.LoginVaidateType("صلاحيات المستخدمين"),
                           False)
        LoadComData()
        Refresh_Database()
        Btn_First()
    End Sub
    Private Sub LoadComData()

        Cls_Users.Com_usertype(Cmd_UsersType)
    End Sub
    Private Sub Refresh_Database()
        Btn_Clear()
        _dt = Cls_Users.View_ItemsInfo()
        If _dt.Rows.Count <> Nothing Then
            UC_cur1.Refresh_Data(_dt)


        End If
    End Sub

    Private Sub Btn_Addstore()

        Users.Import_Data(user_NameAr:=txt_UsersNameAr.Text,
userType_ID:=Cmd_UsersType.SelectedValue,
user_NameEn:=txt_UsersNameEn.Text,
user_userName:=txt_UserName.Text,
user_password:=txt_Password.Text,
user_IsActive:=swt_UsersActive.Checked
)
        Users.AddNewUser()
        Refresh_Database()
        UC_cur1.Btn_last.PerformClick()

    End Sub

    Private Sub Btn_Clear()
        Cls_DataAccessLayer.ClearTextBoxes(panal_users)
        ClearCheck()
    End Sub
    Private Sub ClearCheck()
        Isloading = True
        For Each item In Grp_UsersPerssion.Controls
            If TypeOf item Is Guna2ToggleSwitch Then
                item.Checked = False
            End If
        Next
    End Sub
    Private Sub Btn_UpdateStore()
        Dim index As Integer = UC_cur1.Cur1.Position
        Users.import_Data(user_NameAr:=txt_UsersNameAr.Text,
userType_ID:=Cmd_UsersType.SelectedValue,
user_NameEn:=txt_UsersNameEn.Text,
user_userName:=txt_UserName.Text,
user_password:=txt_Password.Text,
user_IsActive:=swt_UsersActive.Checked
)
        Users.update_Users()
        Refresh_Database()
        UC_cur1.Cur1.Position = index
        Explore_Data()
    End Sub

    Private Sub Btn_After()

        Explore_Data()

    End Sub
    Private Sub Btn_First()
        UC_cur1.Cur_first()
        Explore_Data()

    End Sub
    Private Sub Btn_Last()

        Explore_Data()
    End Sub
    Private Sub Btn_Next()

        Explore_Data()
    End Sub
#End Region
    Private Sub Explore_Data()
        Isloading = True
        _cur = UC_cur1.Cur1
        Users.Load_Data(_cur)

        Users.Send_Data({txt_UsersNameAr,
                        txt_UsersNameEn,
                        txt_UserName,
                        txt_Password,
                        Txt_UsersCode},
                        {Cmd_UsersType}, {swt_UsersActive})
        Users.View_UserPermission()
        Users.load_purmission(
            {
            swt_ID1, swt_ID7, swt_ID5,
           swt_ID19, swt_ID16, swt_ID22,
          swt_ID25, swt_ID13, swt_ID10, swt_ID29,
          swt_ID8, swt_ID20, swt_ID17, swt_ID23, swt_ID26, swt_ID14,
          swt_ID11, swt_ID30, swt_ID9, swt_ID21, swt_ID18, swt_ID24, swt_ID27, swt_ID15,
          swt_ID12, swt_ID31, swt_ID6, swt_ID36, swt_ID35, swt_ID34, swt_ID33, swt_ID28, swt_ID32},
            {Label_ID1, Label_ID7, Label_ID5,
            Label_ID19, Label_ID16, Label_ID22,
            Label_ID25, Label_ID13, Label_ID10, Label_ID29,
            Label_ID8, Label_ID20, Label_ID17, Label_ID23, Label_ID26, Label_ID14,
            Label_ID11, Label_ID30, Label_ID9, Label_ID21, Label_ID18, Label_ID24, Label_ID27, Label_ID15,
            Label_ID12, Label_ID31, Label_ID6, Label_ID36, Label_ID35, Label_ID34, Label_ID33, Label_ID28, Label_ID32})
        Isloading = False
    End Sub
#Region "swt_Changed"
    Private Sub swt_ID1_CheckedChanged(sender As Object, e As EventArgs) Handles swt_ID1.CheckedChanged
        If Isloading = True Then Exit Sub
        Users.Permission_type1.UserType_Name = Label_ID1.Text
        Users.User_Permission1.UserPer_ISActive = swt_ID1.Checked
        Users.UpdateUserPermission()
        Isloading = False
    End Sub

    Private Sub swt_ID7_CheckedChanged(sender As Object, e As EventArgs) Handles swt_ID7.CheckedChanged
        If Isloading = True Then Exit Sub
        Users.Permission_type1.UserType_Name = Label_ID7.Text
        Users.User_Permission1.UserPer_ISActive = swt_ID7.Checked
        Users.UpdateUserPermission()
        Isloading = False
    End Sub

    Private Sub swt_ID5_CheckedChanged(sender As Object, e As EventArgs) Handles swt_ID5.CheckedChanged
        If Isloading = True Then Exit Sub
        Users.Permission_type1.UserType_Name = Label_ID5.Text
        Users.User_Permission1.UserPer_ISActive = swt_ID5.Checked
        Users.UpdateUserPermission()
        Isloading = False
    End Sub

    Private Sub swt_ID19_CheckedChanged(sender As Object, e As EventArgs) Handles swt_ID19.CheckedChanged
        If Isloading = True Then Exit Sub
        Users.Permission_type1.UserType_Name = Label_ID19.Text
        Users.User_Permission1.UserPer_ISActive = swt_ID19.Checked
        Users.UpdateUserPermission()
        Isloading = False
    End Sub

    Private Sub swt_ID16_CheckedChanged(sender As Object, e As EventArgs) Handles swt_ID16.CheckedChanged
        If Isloading = True Then Exit Sub
        Users.Permission_type1.UserType_Name = Label_ID16.Text
        Users.User_Permission1.UserPer_ISActive = swt_ID16.Checked
        Users.UpdateUserPermission()
        Isloading = False
    End Sub

    Private Sub swt_ID22_CheckedChanged(sender As Object, e As EventArgs) Handles swt_ID22.CheckedChanged
        If Isloading = True Then Exit Sub
        Users.Permission_type1.UserType_Name = Label_ID22.Text
        Users.User_Permission1.UserPer_ISActive = swt_ID22.Checked
        Users.UpdateUserPermission()
        Isloading = False
    End Sub

    Private Sub swt_ID25_CheckedChanged(sender As Object, e As EventArgs) Handles swt_ID25.CheckedChanged
        If Isloading = True Then Exit Sub
        Users.Permission_type1.UserType_Name = Label_ID25.Text
        Users.User_Permission1.UserPer_ISActive = swt_ID25.Checked
        Users.UpdateUserPermission()
        Isloading = False
    End Sub

    Private Sub swt_ID13_CheckedChanged(sender As Object, e As EventArgs) Handles swt_ID13.CheckedChanged
        If Isloading = True Then Exit Sub
        Users.Permission_type1.UserType_Name = Label_ID13.Text
        Users.User_Permission1.UserPer_ISActive = swt_ID13.Checked
        Users.UpdateUserPermission()
        Isloading = False
    End Sub

    Private Sub swt_ID10_CheckedChanged(sender As Object, e As EventArgs) Handles swt_ID10.CheckedChanged
        If Isloading = True Then Exit Sub
        Users.Permission_type1.UserType_Name = Label_ID10.Text
        Users.User_Permission1.UserPer_ISActive = swt_ID10.Checked
        Users.UpdateUserPermission()
        Isloading = False
    End Sub

    Private Sub swt_ID29_CheckedChanged(sender As Object, e As EventArgs) Handles swt_ID29.CheckedChanged
        If Isloading = True Then Exit Sub
        Users.Permission_type1.UserType_Name = Label_ID29.Text
        Users.User_Permission1.UserPer_ISActive = swt_ID29.Checked
        Users.UpdateUserPermission()
        Isloading = False
    End Sub

    Private Sub swt_ID8_CheckedChanged(sender As Object, e As EventArgs) Handles swt_ID8.CheckedChanged
        If Isloading = True Then Exit Sub
        Users.Permission_type1.UserType_Name = Label_ID8.Text
        Users.User_Permission1.UserPer_ISActive = swt_ID8.Checked
        Users.UpdateUserPermission()
        Isloading = False
    End Sub

    Private Sub swt_ID20_CheckedChanged(sender As Object, e As EventArgs) Handles swt_ID20.CheckedChanged
        If Isloading = True Then Exit Sub
        Users.Permission_type1.UserType_Name = Label_ID20.Text
        Users.User_Permission1.UserPer_ISActive = swt_ID20.Checked
        Users.UpdateUserPermission()
        Isloading = False
    End Sub

    Private Sub swt_ID17_CheckedChanged(sender As Object, e As EventArgs) Handles swt_ID17.CheckedChanged
        If Isloading = True Then Exit Sub
        Users.Permission_type1.UserType_Name = Label_ID17.Text
        Users.User_Permission1.UserPer_ISActive = swt_ID17.Checked
        Users.UpdateUserPermission()
        Isloading = False
    End Sub

    Private Sub swt_ID23_CheckedChanged(sender As Object, e As EventArgs) Handles swt_ID23.CheckedChanged
        If Isloading = True Then Exit Sub
        Users.Permission_type1.UserType_Name = Label_ID23.Text
        Users.User_Permission1.UserPer_ISActive = swt_ID23.Checked
        Users.UpdateUserPermission()
        Isloading = False
    End Sub

    Private Sub swt_ID26_CheckedChanged(sender As Object, e As EventArgs) Handles swt_ID26.CheckedChanged
        If Isloading = True Then Exit Sub
        Users.Permission_type1.UserType_Name = Label_ID26.Text
        Users.User_Permission1.UserPer_ISActive = swt_ID26.Checked
        Users.UpdateUserPermission()
        Isloading = False
    End Sub

    Private Sub swt_ID14_CheckedChanged(sender As Object, e As EventArgs) Handles swt_ID14.CheckedChanged
        If Isloading = True Then Exit Sub
        Users.Permission_type1.UserType_Name = Label_ID14.Text
        Users.User_Permission1.UserPer_ISActive = swt_ID14.Checked
        Users.UpdateUserPermission()
        Isloading = False
    End Sub

    Private Sub swt_ID11_CheckedChanged(sender As Object, e As EventArgs) Handles swt_ID11.CheckedChanged
        If Isloading = True Then Exit Sub
        Users.Permission_type1.UserType_Name = Label_ID11.Text
        Users.User_Permission1.UserPer_ISActive = swt_ID11.Checked
        Users.UpdateUserPermission()
        Isloading = False
    End Sub

    Private Sub swt_ID30_CheckedChanged(sender As Object, e As EventArgs) Handles swt_ID30.CheckedChanged
        If Isloading = True Then Exit Sub
        Users.Permission_type1.UserType_Name = Label_ID30.Text
        Users.User_Permission1.UserPer_ISActive = swt_ID30.Checked
        Users.UpdateUserPermission()
        Isloading = False
    End Sub

    Private Sub swt_ID9_CheckedChanged(sender As Object, e As EventArgs) Handles swt_ID9.CheckedChanged
        If Isloading = True Then Exit Sub
        Users.Permission_type1.UserType_Name = Label_ID9.Text
        Users.User_Permission1.UserPer_ISActive = swt_ID9.Checked
        Users.UpdateUserPermission()
        Isloading = False
    End Sub

    Private Sub swt_ID21_CheckedChanged(sender As Object, e As EventArgs) Handles swt_ID21.CheckedChanged
        If Isloading = True Then Exit Sub
        Users.Permission_type1.UserType_Name = Label_ID21.Text
        Users.User_Permission1.UserPer_ISActive = swt_ID21.Checked
        Users.UpdateUserPermission()
        Isloading = False
    End Sub

    Private Sub swt_ID18_CheckedChanged(sender As Object, e As EventArgs) Handles swt_ID18.CheckedChanged
        If Isloading = True Then Exit Sub
        Users.Permission_type1.UserType_Name = Label_ID18.Text
        Users.User_Permission1.UserPer_ISActive = swt_ID18.Checked
        Users.UpdateUserPermission()
        Isloading = False
    End Sub

    Private Sub swt_ID24_CheckedChanged(sender As Object, e As EventArgs) Handles swt_ID24.CheckedChanged
        If Isloading = True Then Exit Sub
        Users.Permission_type1.UserType_Name = Label_ID24.Text
        Users.User_Permission1.UserPer_ISActive = swt_ID24.Checked
        Users.UpdateUserPermission()
        Isloading = False
    End Sub

    Private Sub swt_ID27_CheckedChanged(sender As Object, e As EventArgs) Handles swt_ID27.CheckedChanged
        If Isloading = True Then Exit Sub
        Users.Permission_type1.UserType_Name = Label_ID27.Text
        Users.User_Permission1.UserPer_ISActive = swt_ID27.Checked
        Users.UpdateUserPermission()
        Isloading = False
    End Sub

    Private Sub swt_ID15_CheckedChanged(sender As Object, e As EventArgs) Handles swt_ID15.CheckedChanged
        If Isloading = True Then Exit Sub
        Users.Permission_type1.UserType_Name = Label_ID15.Text
        Users.User_Permission1.UserPer_ISActive = swt_ID15.Checked
        Users.UpdateUserPermission()
        Isloading = False
    End Sub

    Private Sub swt_ID12_CheckedChanged(sender As Object, e As EventArgs) Handles swt_ID12.CheckedChanged
        If Isloading = True Then Exit Sub
        Users.Permission_type1.UserType_Name = Label_ID12.Text
        Users.User_Permission1.UserPer_ISActive = swt_ID12.Checked
        Users.UpdateUserPermission()
        Isloading = False
    End Sub

    Private Sub swt_ID31_CheckedChanged(sender As Object, e As EventArgs) Handles swt_ID31.CheckedChanged
        If Isloading = True Then Exit Sub
        Users.Permission_type1.UserType_Name = Label_ID31.Text
        Users.User_Permission1.UserPer_ISActive = swt_ID31.Checked
        Users.UpdateUserPermission()
        Isloading = False
    End Sub

    Private Sub swt_ID6_CheckedChanged(sender As Object, e As EventArgs) Handles swt_ID6.CheckedChanged
        If Isloading = True Then Exit Sub
        Users.Permission_type1.UserType_Name = Label_ID6.Text
        Users.User_Permission1.UserPer_ISActive = swt_ID6.Checked
        Users.UpdateUserPermission()
        Isloading = False
    End Sub

    Private Sub swt_ID36_CheckedChanged(sender As Object, e As EventArgs) Handles swt_ID36.CheckedChanged
        If Isloading = True Then Exit Sub
        Users.Permission_type1.UserType_Name = Label_ID36.Text
        Users.User_Permission1.UserPer_ISActive = swt_ID36.Checked
        Users.UpdateUserPermission()
        Isloading = False
    End Sub

    Private Sub swt_ID35_CheckedChanged(sender As Object, e As EventArgs) Handles swt_ID35.CheckedChanged
        If Isloading = True Then Exit Sub
        Users.Permission_type1.UserType_Name = Label_ID35.Text
        Users.User_Permission1.UserPer_ISActive = swt_ID35.Checked
        Users.UpdateUserPermission()
        Isloading = False
    End Sub

    Private Sub swt_ID34_CheckedChanged(sender As Object, e As EventArgs) Handles swt_ID34.CheckedChanged
        If Isloading = True Then Exit Sub
        Users.Permission_type1.UserType_Name = Label_ID34.Text
        Users.User_Permission1.UserPer_ISActive = swt_ID34.Checked
        Users.UpdateUserPermission()
        Isloading = False
    End Sub

    Private Sub swt_ID33_CheckedChanged(sender As Object, e As EventArgs) Handles swt_ID33.CheckedChanged
        If Isloading = True Then Exit Sub
        Users.Permission_type1.UserType_Name = Label_ID33.Text
        Users.User_Permission1.UserPer_ISActive = swt_ID33.Checked
        Users.UpdateUserPermission()
        Isloading = False
    End Sub

    Private Sub swt_ID28_CheckedChanged(sender As Object, e As EventArgs) Handles swt_ID28.CheckedChanged
        If Isloading = True Then Exit Sub
        Users.Permission_type1.UserType_Name = Label_ID28.Text
        Users.User_Permission1.UserPer_ISActive = swt_ID28.Checked
        Users.UpdateUserPermission()
        Isloading = False
    End Sub

    Private Sub swt_ID32_CheckedChanged(sender As Object, e As EventArgs) Handles swt_ID32.CheckedChanged
        If Isloading = True Then Exit Sub
        Users.Permission_type1.UserType_Name = Label_ID32.Text
        Users.User_Permission1.UserPer_ISActive = swt_ID32.Checked
        Users.UpdateUserPermission()
        Isloading = False
    End Sub


#End Region

End Class