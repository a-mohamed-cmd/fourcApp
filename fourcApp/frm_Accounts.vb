Imports System.Drawing.Imaging

Public Class frm_Accounts
    Private _cur As CurrencyManager
    Private _dt As New DataTable
    Private account As New Cls_Accounts
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

        UC_cur1.Visibility(True, True, True, False)
        Refresh_Database()
        Btn_First()


    End Sub
    Private Sub Refresh_Database()
        'Cls_DataAccessLayer.ClearTextBoxes(Grp_AccountGeneral)
        Cls_DataAccessLayer.ClearTextBoxes(Grp_AccountSub)
        _dt = account.View_StoresAndDepartments()
        If _dt.Rows.Count <> Nothing Then
            UC_cur1.Refresh_Data(_dt)


        End If
    End Sub

    Private Sub Btn_Addstore()

        account.import_Data(
                                code:=txt_AccountSubCode.Text,
                                genID:=Txt_AccountGeneralCode.Text,
                                account_gen_name:=txt_AccountGeneralNameAr.Text,
                                name:=txt_AccountSubName.Text,
                                isActive:=swt_AccontSubActive.Checked
)
        account.SaveNewAccountSub()
        Refresh_Database()
        UC_cur1.Btn_last.PerformClick()


    End Sub

    Private Sub Btn_Clear()
        'Cls_DataAccessLayer.ClearTextBoxes(Grp_AccountGeneral)
        swt_AccontSubActive.Checked = False
        Cls_DataAccessLayer.ClearTextBoxes(Grp_AccountSub)
    End Sub
    Private Sub Btn_UpdateStore()
        Dim index As Integer = UC_cur1.Cur1.Position
        account.import_Data(
                                code:=txt_AccountSubCode.Text,
                                genID:=Txt_AccountGeneralCode.Text,
                                account_gen_name:=txt_AccountGeneralNameAr.Text,
                                name:=txt_AccountSubName.Text,
                                isActive:=swt_AccontSubActive.Checked)
        account.UpdateAccountSub()
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
        _cur = UC_cur1.Cur1
        account.Load_Data(_cur)
        account.Send_Data({Txt_AccountGeneralCode,
                          txt_AccountGeneralNameAr,
                          txt_AccountSubCode,
                          txt_AccountSubName
}, swt_AccontSubActive)

    End Sub
End Class