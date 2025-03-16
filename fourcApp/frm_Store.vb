Imports System.Drawing.Imaging

Public Class frm_store
    Private _cur As CurrencyManager
    Private _dt As New DataTable
    Private store As New Store
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
        Cls_DataAccessLayer.ClearTextBoxes(Grp_Department)
        _dt = store.View_StoresAndDepartments()
        If _dt.Rows.Count <> Nothing Then
            UC_cur1.Refresh_Data(_dt)


        End If
    End Sub

    Private Sub Btn_Addstore()

        store.import_Data(
                                 name:=txt_StoreName.Text,
                                 location:=txt_StoreLocation.Text,
                                 isActive:=swt_StoreActive.Checked)
        store.SaveNewStore()
        Refresh_Database()
        Btn_Last()

    End Sub

    Private Sub Btn_Clear()
        Cls_DataAccessLayer.ClearTextBoxes(panal_Store)
        swt_StoreActive.Checked = False
        Cls_DataAccessLayer.ClearTextBoxes(Grp_Department)
    End Sub
    Private Sub Btn_UpdateStore()
        Dim index As Integer = UC_cur1.Cur1.Position
        store.import_Data(id:=store.Store_ID,
                         name:=txt_StoreName.Text,
                         location:=txt_StoreLocation.Text,
                         isActive:=swt_StoreActive.Checked)
        store.UpdateStore()
        Refresh_Database()
        UC_cur1.Cur1.Position = index
        Explore_Data()
    End Sub

    Private Sub Btn_After()

        Explore_Data()

    End Sub
    Private Sub Btn_First()
        UC_cur1.cur_first()
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
        store.Load_Data(_cur)
        store.Send_Data({Txt_StoreCode, txt_StoreName, txt_StoreLocation,
                        txt_DepartmentCode, txt_DepartmentName, txt_DepartmentNote}, swt_StoreActive)
        dgv_ItemsMove.DataSource = ""
        dgv_ItemsMove.DataSource = store.Department.Department_Balance()
        Department.Dgv_Design_MoveItem(dgv_ItemsMove)
    End Sub

    Private Sub Btn_Add_Department_Click(sender As Object, e As EventArgs) Handles btn_ClearDepartment.Click
        Cls_DataAccessLayer.ClearTextBoxes(Grp_Department)
    End Sub

    Private Sub Btn_Add_Department_Click_1(sender As Object, e As EventArgs) Handles Btn_Add_Department.Click
        Dim index As Integer = UC_cur1.Cur1.Position
        store.Department.import_Data(
                                     name:=txt_DepartmentName.Text,
                                     Note:=txt_DepartmentNote.Text,
                                     Store_ID:=store.Store_ID)
        store.Department.SaveNewDepartment()
        Refresh_Database()
        UC_cur1.Cur1.Position = index
        Explore_Data()
    End Sub

    Private Sub Btn_updateDepartment_Click(sender As Object, e As EventArgs) Handles Btn_updateDepartment.Click
        Dim index As Integer = UC_cur1.Cur1.Position
        store.Department.import_Data(id:=store.Department.Department_ID,
                                     name:=txt_DepartmentName.Text,
                                     Note:=txt_DepartmentNote.Text,
                                     Store_ID:=store.Store_ID)
        store.Department.UpdateDepartment()
        Refresh_Database()
        UC_cur1.Cur1.Position = index
        Explore_Data()
    End Sub
End Class