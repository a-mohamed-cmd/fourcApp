Imports System.Drawing.Imaging

Public Class Frm_Unit
    Private _cur As CurrencyManager
    Private _dt As New DataTable
    Private Unit As New Unit
    Private Sub Frm_Items_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UC_cur1.ColorCur = Color.FromArgb(196, 207, 137)



        Load_btn_Event_of_Cur()

    End Sub

#Region "Buttons Cur"
    Private Sub Load_btn_Event_of_Cur()
        AddHandler Me.UC_cur1.Btn_AddItem.Click, AddressOf Btn_AddUnit
        AddHandler Me.UC_cur1.btn_newItem.Click, AddressOf Btn_Clear
        AddHandler Me.UC_cur1.btn_updateItem.Click, AddressOf Btn_UpdateUnit
        AddHandler Me.UC_cur1.Btn_After.Click, AddressOf Btn_After
        AddHandler Me.UC_cur1.Btn_First.Click, AddressOf Btn_First
        AddHandler Me.UC_cur1.Btn_last.Click, AddressOf Btn_Last
        AddHandler Me.UC_cur1.Btn_Next.Click, AddressOf Btn_Next

        UC_cur1.Visibility(True, True, True, False)
        Refresh_Database()
        Btn_First()


    End Sub
    Private Sub Refresh_Database()
        Cls_DataAccessLayer.ClearTextBoxes(panal_Unit)

        _dt = Unit.View_Units()


        If _dt.Rows.Count <> Nothing Then
            UC_cur1.Refresh_Data(_dt)
        End If
    End Sub

    Private Sub Btn_AddUnit()

        Save_Unit()


        Refresh_Database()
        UC_cur1.Btn_last.PerformClick()

    End Sub

#Region "Save Code Category"

    Private Sub Save_Unit()
        Unit.import_Data(
                                unitName:=txt_UnitName.Text
)
        Unit.SaveNewUnit()
    End Sub



#End Region


#Region "Update Code Category"

    Private Sub Update_Unit()
        Unit.import_Data(id:=Unit.Unit_ID,
                                unitName:=txt_UnitName.Text
)
        Unit.UpdateUnit()
    End Sub



#End Region

#Region "Explore Data"

    Private Sub Explore_Data_Unit()
        Unit.Load_Data(_cur)
        Unit.Send_Data({txt_UnitName})
    End Sub

#End Region

    Private Sub Btn_Clear()
        Cls_DataAccessLayer.ClearTextBoxes(panal_Unit)
    End Sub

    Private Sub Btn_UpdateUnit()
        Dim index As Integer = UC_cur1.Cur1.Position

        Update_Unit()


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

        Explore_Data_Unit()

    End Sub




End Class