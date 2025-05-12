Imports System.Drawing.Imaging

Public Class frm_Items

    Private _cur As CurrencyManager
    Private _dt As New DataTable
    Private _item As New Items

    Public Property Item As Items
        Get
            Return _item
        End Get
        Set(value As Items)
            _item = value
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

        UC_cur1.Visibility(Cls_Users.LoginVaidateType("اضافه الاصناف"),
                           Cls_Users.LoginVaidateType("اضافه الاصناف"),
                           Cls_Users.LoginVaidateType("تعديل الاصناف"),
                           False)
        LoadComData()
        Refresh_Database()
        Btn_First()


    End Sub
    Private Sub LoadComData()
        item.com_CategoryOne(com_ItemType1)
        item.com_CategoryTwo(com_ItemType2)
        item.com_CategoryThree(com_ItemType3)
        item.com_CategoryFour(com_ItemType4)
        item.Com_unit(Com_ItemUnit)
    End Sub
    Private Sub Refresh_Database()
        Btn_Clear()
        _dt = item.View_ItemsInfo()
        If _dt.Rows.Count <> Nothing Then
            UC_cur1.Refresh_Data(_dt)


        End If
    End Sub

    Private Sub Btn_Addstore()

        item.import_Data(
                            itemsCode:=Txt_itemCode.Text,
                            itemsNameAR:=txt_ItemNameAr.Text,
                            itemsNameEn:=txt_ItemNameEn.Text,
                            itemsPriceSale:=txt_ItemPriceSell.Text,
                            unit:=Com_ItemUnit.SelectedValue,
                            categoryOne:=com_ItemType1.SelectedValue,
                            categoryTwo:=com_ItemType2.SelectedValue,
                            categoryThree:=com_ItemType3.SelectedValue,
                            categoryFour:=com_ItemType4.SelectedValue)
        item.SaveNewItem()
        Refresh_Database()
        UC_cur1.Btn_last.PerformClick()

    End Sub

    Private Sub Btn_Clear()
        Cls_DataAccessLayer.ClearTextBoxes(panal_iteminfo)
        com_ItemType1.SelectedIndex = -1
        com_ItemType2.SelectedIndex = -1
        com_ItemType3.SelectedIndex = -1
        com_ItemType4.SelectedIndex = -1
        Com_ItemUnit.SelectedIndex = -1
    End Sub
    Private Sub Btn_UpdateStore()
        Dim index As Integer = UC_cur1.Cur1.Position
        item.import_Data(id:=item.Items_ID,
                            itemsCode:=Txt_itemCode.Text,
                            itemsNameAR:=txt_ItemNameAr.Text,
                            itemsNameEn:=txt_ItemNameEn.Text,
                            itemsPriceSale:=txt_ItemPriceSell.Text,
                            unit:=Com_ItemUnit.SelectedValue,
                            categoryOne:=com_ItemType1.SelectedValue,
                            categoryTwo:=com_ItemType2.SelectedValue,
                            categoryThree:=com_ItemType3.SelectedValue,
                            categoryFour:=com_ItemType4.SelectedValue)
        item.UpdateItem()
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
        Item.Load_Data(_cur)
        Item.load_AvgAndBalance()
        Item.Send_Data({Txt_itemCode,
                       txt_ItemNameAr,
                       txt_ItemNameEn,
                        txt_ItemPriceSell,
                        txt_ItemAvgCost,
                        txt_ItemAvailableQty},
                        {Com_ItemUnit,
                        com_ItemType1,
                        com_ItemType2,
                        com_ItemType3,
                        com_ItemType4})
        dgv_ItemsMove.DataSource = ""
        Dim dt As New DataTable

        dgv_ItemsMove.DataSource = If(Item.AllMove_Item, "")
        Item.Dgv_Design_MoveItem(dgv_ItemsMove)
    End Sub

    Private Sub Dgv_ItemsMove_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_ItemsMove.CellDoubleClick
        If e.RowIndex = -1 Then Exit Sub
        Dim info As String = dgv_ItemsMove.Rows(e.RowIndex).Cells("Info").Value
        Dim Department As Integer = dgv_ItemsMove.Rows(e.RowIndex).Cells("Department_ID").Value
        Dim details As New frm_ShowDetailsMove(Me.Item, info, Department)
        details.ShowDialog()
    End Sub


End Class