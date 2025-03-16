Imports System.Drawing.Imaging

Public Class Frm_Customers
    Private _cur As CurrencyManager
    Private _dt As New DataTable
    Private customer As New Customer
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

        UC_cur1.Visibility(Cls_Users.LoginVaidateType("اضافه عملاء"),
                           Cls_Users.LoginVaidateType("اضافه عملاء"),
                           Cls_Users.LoginVaidateType("تعديل عملاء"),
                           False)

        customer.Country.loadCountries(cmd:=Com_CustomerCountry)
        Refresh_Database()
        Btn_First()


    End Sub

    Private Sub Btn_Addstore()

        customer.import_Data(
                                name:=txt_CustomerNameAr.Text,
                                countryID:=Com_CustomerCountry.SelectedValue,
                                phone:=txt_CustomerPhone.Text,
                                fax:=txt_CustomerFax.Text,
                                email:=txt_CustomerEmail.Text,
                                address:=txt_CustomerAddress.Text,
                                isActive:=swt_CustomerActive.Checked
                                )
        customer.SaveNewCustomer()
        Refresh_Database()
        UC_cur1.Btn_last.PerformClick()

    End Sub
    Private Sub Refresh_Database()
        Btn_Clear()
        _dt = customer.View_SuppliersData()
        If _dt.Rows.Count <> Nothing Then
            UC_cur1.Refresh_Data(_dt)


        End If
    End Sub
    Private Sub Btn_Clear()
        Cls_DataAccessLayer.ClearTextBoxes(panal_Customers)
        Com_CustomerCountry.SelectedIndex = -1

    End Sub
    Private Sub Btn_UpdateStore()
        Dim index As Integer = UC_cur1.Cur1.Position
        customer.import_Data(
                                id:=Txt_CustomerCode.Text,
                                name:=txt_CustomerNameAr.Text,
                                countryID:=Com_CustomerCountry.SelectedValue,
                                phone:=txt_CustomerPhone.Text,
                                fax:=txt_CustomerFax.Text,
                                email:=txt_CustomerEmail.Text,
                                address:=txt_CustomerAddress.Text,
                                isActive:=swt_CustomerActive.Checked
                                )
        customer.UpdateCustomer()
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
        customer.Load_Data(_cur)
        customer.Send_Data({Txt_CustomerCode,
                       txt_CustomerNameAr,
                       txt_CustomerPhone,
                        txt_CustomerFax,
                        txt_CustomerEmail,
                        txt_CustomerAddress},
                       swt_CustomerActive,
                        Com_CustomerCountry)
    End Sub



End Class