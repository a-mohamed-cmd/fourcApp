Imports System.Drawing.Imaging

Public Class frm_Supplier
    Private _cur As CurrencyManager
    Private _dt As New DataTable
    Private Supplier As New Supplier
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

        UC_cur1.Visibility(Cls_Users.LoginVaidateType("اضافه موردين"),
                           Cls_Users.LoginVaidateType("اضافه موردين"),
                           Cls_Users.LoginVaidateType("تعديل موردين"),
                           False
                           )
        Supplier.Country.loadCountries(cmd:=Com_SupplierCountry)
        Refresh_Database()
        Btn_First()


    End Sub

    Private Sub Btn_Addstore()

        Supplier.import_Data(
                                name:=txt_SupplierNameAr.Text,
                                countryID:=Com_SupplierCountry.SelectedValue,
                                phone:=txt_SupplierPhone.Text,
                                fax:=txt_SupplierFax.Text,
                                email:=txt_SupplierEmail.Text,
                                address:=txt_SupplierAddress.Text,
                                isActive:=swt_SupplierActive.Checked
                                )
        Supplier.SaveNewSupplier()
        Refresh_Database()
        UC_cur1.Btn_last.PerformClick()

    End Sub
    Private Sub Refresh_Database()
        Btn_Clear()
        _dt = Supplier.View_SuppliersData()
        If _dt.Rows.Count <> Nothing Then
            UC_cur1.Refresh_Data(_dt)


        End If
    End Sub
    Private Sub Btn_Clear()
        Cls_DataAccessLayer.ClearTextBoxes(panal_suppliers)
        Com_SupplierCountry.SelectedIndex = -1

    End Sub
    Private Sub Btn_UpdateStore()
        Dim index As Integer = UC_cur1.Cur1.Position
        Supplier.import_Data(
                                id:=Txt_SupplierCode.Text,
                                name:=txt_SupplierNameAr.Text,
                                countryID:=Com_SupplierCountry.SelectedValue,
                                phone:=txt_SupplierPhone.Text,
                                fax:=txt_SupplierFax.Text,
                                email:=txt_SupplierEmail.Text,
                                address:=txt_SupplierAddress.Text,
                                isActive:=swt_SupplierActive.Checked
                                )
        Supplier.UpdateSupplier()
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
        Supplier.Load_Data(_cur)
        Supplier.Send_Data({Txt_SupplierCode,
                       txt_SupplierNameAr,
                       txt_SupplierPhone,
                        txt_SupplierFax,
                        txt_SupplierEmail,
                        txt_SupplierAddress},
                       swt_SupplierActive,
                        Com_SupplierCountry)
    End Sub




End Class