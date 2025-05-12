Public Class Form1

    Private _Users As New Cls_Users

    Public Property Users As Cls_Users
        Get
            Return _Users
        End Get
        Set(value As Cls_Users)
            _Users = value
        End Set
    End Property



    Private Sub Guna2GradientButton1_Click(sender As Object, e As EventArgs) Handles btn_login.Click

        Users.User_userName = txt_UserName.Text
        Users.User_password = txt_Password.Text
        If Users.Login_User() = 0 Then MsgBox("عفوا الباسورد او اسم المستخدم خطاً") : Exit Sub
        If Users.LoginVaildate() = False Then MsgBox("هذا المستخدم تم ايقاف صلاحياته") : Exit Sub
        GeneralForm.Show()

        Hide()
    End Sub

    Private Sub lbl_Forget_Click(sender As Object, e As EventArgs) Handles lbl_Forget.Click
        Cls_DataAccessLayer.ClearTextBoxes(Panal_ChangePassword)
        Panal_ChangePassword.Visible = True
        Panal_Login.Visible = False
        txt_Change_userName.Focus()
    End Sub

    Private Sub Guna2GradientButton1_Click_1(sender As Object, e As EventArgs) Handles btn_ChangePassword.Click
        'change password and save 
        If txt_Change_userName.Text.Length = Nothing Then
            Panal_ChangePassword.Visible = False
            Panal_Login.Visible = True
            txt_UserName.Focus()

            Exit Sub
        End If
        If txt_change_Newpassword.Text <> txt_Change_ConfigPassword.Text Then MsgBox("رقم الباسورد غير متماثل") : Exit Sub
        Users.User_userName = txt_Change_userName.Text
        Users.User_password = txt_change_Oldpassword.Text
        Users.UpdateUserPassword(txt_change_Newpassword.Text)
        Panal_ChangePassword.Visible = False
        Panal_Login.Visible = True
        txt_UserName.Focus()




    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_UserName.Focus()
    End Sub
End Class
