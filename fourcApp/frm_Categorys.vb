Imports System.Drawing.Imaging

Public Class Frm_Categorys
    Private _cur As CurrencyManager
    Private _dt As New DataTable
    Private CategoryOne As New CategoryOne
    Private CategoryTwo As New CategoryTwo
    Private CategoryThree As New CategoryThree
    Private CategoryFour As New CategoryFour
    Private Sub Frm_Items_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UC_cur1.ColorCur = Color.FromArgb(196, 207, 137)

        com_ItemType.SelectedIndex = 0

        Load_btn_Event_of_Cur()

    End Sub

#Region "Buttons Cur"
    Private Sub Load_btn_Event_of_Cur()
        AddHandler Me.UC_cur1.Btn_AddItem.Click, AddressOf Btn_AddCategory
        AddHandler Me.UC_cur1.btn_newItem.Click, AddressOf Btn_Clear
        AddHandler Me.UC_cur1.btn_updateItem.Click, AddressOf Btn_UpdateCategory
        AddHandler Me.UC_cur1.Btn_After.Click, AddressOf Btn_After
        AddHandler Me.UC_cur1.Btn_First.Click, AddressOf Btn_First
        AddHandler Me.UC_cur1.Btn_last.Click, AddressOf Btn_Last
        AddHandler Me.UC_cur1.Btn_Next.Click, AddressOf Btn_Next

        UC_cur1.Visibility(True, True, True, False)
        Refresh_Database()
        Btn_First()


    End Sub
    Private Sub Refresh_Database()
        Cls_DataAccessLayer.ClearTextBoxes(panal_Category)
        Select Case com_ItemType.SelectedIndex
            Case 0
                _dt = CategoryOne.View_Categorys()
            Case 1
                _dt = CategoryTwo.View_Categorys()
            Case 2
                _dt = CategoryThree.View_Categorys()
            Case 3
                _dt = CategoryFour.View_Categorys()
        End Select

        If _dt.Rows.Count <> Nothing Then
            UC_cur1.Refresh_Data(_dt)
        End If
    End Sub

    Private Sub Btn_AddCategory()
        Select Case com_ItemType.SelectedIndex
            Case 0
                Save_CategoryOne()
            Case 1
                Save_CategoryTwo()
            Case 2
                Save_CategoryThree()
            Case 3
                Save_CategoryFour()
        End Select

        Refresh_Database()
        UC_cur1.Btn_last.PerformClick()

    End Sub

#Region "Save Code Category"

    Private Sub Save_CategoryOne()
        CategoryOne.import_Data(
                                nameCategory:=txt_DepartmentName.Text
)
        CategoryOne.SaveNewCategoryOne()
    End Sub
    Private Sub Save_CategoryTwo()
        CategoryTwo.import_Data(
                        nameCategory:=txt_DepartmentName.Text
)
        CategoryTwo.SaveNewCategoryTwo()
    End Sub
    Private Sub Save_CategoryThree()
        CategoryThree.import_Data(
                 nameCategory:=txt_DepartmentName.Text
)
        CategoryThree.SaveNewCategoryThree()
    End Sub
    Private Sub Save_CategoryFour()
        CategoryFour.import_Data(
                 nameCategory:=txt_DepartmentName.Text
)
        CategoryFour.SaveNewCategoryFour()
    End Sub



#End Region


#Region "Update Code Category"

    Private Sub Update_CategoryOne()
        CategoryOne.import_Data(id:=CategoryOne.CategoryOne_ID,
                                nameCategory:=txt_DepartmentName.Text
)
        CategoryOne.UpdateCategoryOne()
    End Sub
    Private Sub Update_CategoryTwo()
        CategoryTwo.import_Data(id:=CategoryTwo.CategoryTwo_ID,
                        nameCategory:=txt_DepartmentName.Text
)
        CategoryTwo.UpdateCategoryTwo()
    End Sub
    Private Sub Update_CategoryThree()
        CategoryThree.import_Data(id:=CategoryThree.CategoryThree_ID,
                 nameCategory:=txt_DepartmentName.Text
)
        CategoryThree.UpdateCategoryThree()
    End Sub
    Private Sub Update_CategoryFour()
        CategoryFour.import_Data(id:=CategoryFour.CategoryFour_ID,
                 nameCategory:=txt_DepartmentName.Text
)
        CategoryFour.UpdateCategoryFour()
    End Sub



#End Region

#Region "Explore Data"

    Private Sub Explore_Data_CategoryOne()
        CategoryOne.Load_Data(_cur)
        CategoryOne.Send_Data({txt_DepartmentName})
    End Sub
    Private Sub Explore_Data_CategoryTwo()
        CategoryTwo.Load_Data(_cur)
        CategoryTwo.Send_Data({txt_DepartmentName})
    End Sub
    Private Sub Explore_Data_CategoryThree()
        CategoryThree.Load_Data(_cur)
        CategoryThree.Send_Data({txt_DepartmentName})
    End Sub
    Private Sub Explore_Data_CategoryFour()
        CategoryFour.Load_Data(_cur)
        CategoryFour.Send_Data({txt_DepartmentName})
    End Sub
#End Region

    Private Sub Btn_Clear()
        Cls_DataAccessLayer.ClearTextBoxes(panal_Category)
    End Sub

    Private Sub Btn_UpdateCategory()
        Dim index As Integer = UC_cur1.Cur1.Position
        Select Case com_ItemType.SelectedIndex
            Case 0
                Update_CategoryOne()
            Case 1
                Update_CategoryTwo()
            Case 2
                Update_CategoryThree()
            Case 3
                Update_CategoryFour()
        End Select

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
        Select Case com_ItemType.SelectedIndex
            Case 0
                Explore_Data_CategoryOne()
            Case 1
                Explore_Data_CategoryTwo()
            Case 2
                Explore_Data_CategoryThree()
            Case 3
                Explore_Data_CategoryFour()
        End Select
    End Sub



    Private Sub Com_ItemType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles com_ItemType.SelectedIndexChanged
        Refresh_Database()
        Btn_First()
    End Sub
End Class