Imports System.Security.Cryptography.X509Certificates
Imports Guna.UI2.WinForms
Imports Microsoft.Data.SqlClient

Public Class Items
    ' المتغيرات الخاصة
    Private _Items_ID As Integer
    Private _Items_Code As String
    Private _Items_NameAR As String
    Private _Items_NameEn As String

    Private _Items_pricesale As Decimal
    Private _Unit As New Unit
    Private _Items_Cost As Decimal
    Private _Items_QtyBalance As Decimal
    Private _CategoryOne As New CategoryOne
    Private _CategoryTwo As New CategoryTwo
    Private _CategoryThree As New CategoryThree
    Private _CategoryFour As New CategoryFour
    Private _Dt As New DataTable
    Private _LastSalePrice As Decimal = 0.0
    Private _lastPurchasePrice As Decimal = 0.0
    Private _ItemAvgCost As Integer = 0
    Private _ItemAvailableQty As Integer = 0

#Region "Properties"
    ' الخصائص العامة
    Public Property Items_ID As Integer
        Get
            Return _Items_ID
        End Get
        Set(value As Integer)
            _Items_ID = value
        End Set
    End Property

    Public Property Items_Code As String
        Get
            Return _Items_Code
        End Get
        Set(value As String)
            _Items_Code = value
        End Set
    End Property

    Public Property Items_NameAR As String
        Get
            Return _Items_NameAR
        End Get
        Set(value As String)
            _Items_NameAR = value
        End Set
    End Property

    Public Property Items_NameEn As String
        Get
            Return _Items_NameEn
        End Get
        Set(value As String)
            _Items_NameEn = value
        End Set
    End Property


    Public Property Items_pricesale As Decimal
        Get
            Return _Items_pricesale
        End Get
        Set(value As Decimal)
            _Items_pricesale = value
        End Set
    End Property


    Public Property Items_Cost As Decimal
        Get
            Return _Items_Cost
        End Get
        Set(value As Decimal)
            _Items_Cost = value
        End Set
    End Property

    Public Property Items_QtyBalance As Decimal
        Get
            Return _Items_QtyBalance
        End Get
        Set(value As Decimal)
            _Items_QtyBalance = value
        End Set
    End Property

    Public Property CategoryOne As CategoryOne
        Get
            Return _CategoryOne
        End Get
        Set(value As CategoryOne)
            _CategoryOne = value
        End Set
    End Property

    Public Property CategoryTwo As CategoryTwo
        Get
            Return _CategoryTwo
        End Get
        Set(value As CategoryTwo)
            _CategoryTwo = value
        End Set
    End Property

    Public Property CategoryThree As CategoryThree
        Get
            Return _CategoryThree
        End Get
        Set(value As CategoryThree)
            _CategoryThree = value
        End Set
    End Property

    Public Property CategoryFour As CategoryFour
        Get
            Return _CategoryFour
        End Get
        Set(value As CategoryFour)
            _CategoryFour = value
        End Set
    End Property

    Public Property Dt As DataTable
        Get
            Return _Dt
        End Get
        Set(value As DataTable)
            _Dt = value
        End Set
    End Property

    Public Property Unit As Unit
        Get
            Return _Unit
        End Get
        Set(value As Unit)
            _Unit = value
        End Set
    End Property

    Public Property LastSalePrice As Decimal
        Get
            Return _LastSalePrice
        End Get
        Set(value As Decimal)
            _LastSalePrice = value
        End Set
    End Property

    Public Property LastPurchasePrice As Decimal
        Get
            Return _lastPurchasePrice
        End Get
        Set(value As Decimal)
            _lastPurchasePrice = value
        End Set
    End Property

    Public Property ItemAvgCost As Integer
        Get
            Return _ItemAvgCost
        End Get
        Set(value As Integer)
            _ItemAvgCost = value
        End Set
    End Property

    Public Property ItemAvailableQty As Integer
        Get
            Return _ItemAvailableQty
        End Get
        Set(value As Integer)
            _ItemAvailableQty = value
        End Set
    End Property
#End Region


    Public Sub import_Data(Optional id As Integer = 0,
                       Optional itemsCode As String = "",
                       Optional itemsNameAR As String = "",
                       Optional itemsNameEn As String = "",
                       Optional itemsPriceSale As Decimal = 0D,
                       Optional unit As Integer = 0,
                       Optional itemsCost As Decimal = 0D,
                       Optional itemsQtyBalance As Integer = 0,
                       Optional categoryOne As String = "",
                       Optional categoryTwo As String = "",
                       Optional categoryThree As String = "",
                       Optional categoryFour As String = "")


        _Items_ID = id
        _Items_Code = itemsCode
        _Items_NameAR = itemsNameAR
        _Items_NameEn = itemsNameEn
        _Items_pricesale = itemsPriceSale
        _Unit.Unit_ID = unit
        _Items_Cost = itemsCost
        _Items_QtyBalance = itemsQtyBalance
        _CategoryOne.CategoryOne_ID = categoryOne
        _CategoryTwo.CategoryTwo_ID = categoryTwo
        _CategoryThree.CategoryThree_ID = categoryThree
        _CategoryFour.CategoryFour_ID = categoryFour
    End Sub

    ''' <summary>
    ''' عرض بيانات row
    ''' </summary>
    ''' <param name="cur"></param>
    Sub Load_Data(cur As CurrencyManager)
        Items_ID = cur.Current("Items_ID")
        Items_Code = cur.Current("Items_Code")
        Items_NameAR = cur.Current("Items_NameAR")
        Items_NameEn = If(IsDBNull(cur.Current("Items_NameEn")),
                                    Nothing, cur.Current("Items_NameEn"))
        Unit.Unit_ID = cur.Current("Unit_ID")
        Items_pricesale = If(IsDBNull(cur.Current("Items_pricesale")),
                                    Nothing, cur.Current("Items_pricesale"))
        CategoryOne.CategoryOne_ID = If(IsDBNull(cur.Current("CategoryOne_ID")),
                                            Nothing, cur.Current("CategoryOne_ID"))
        CategoryTwo.CategoryTwo_ID = If(IsDBNull(cur.Current("CategoryTwo_ID")),
                                            Nothing, cur.Current("CategoryTwo_ID"))
        CategoryThree.CategoryThree_ID = If(IsDBNull(cur.Current("CategoryThree_ID")),
                                    Nothing, (cur.Current("CategoryThree_ID")))
        CategoryFour.CategoryFour_ID = If(IsDBNull(cur.Current("CategoryFour_ID")),
                                    Nothing, (cur.Current("CategoryFour_ID")))

    End Sub
    ''' <summary>
    ''' ارسال البيانات 
    ''' </summary>
    ''' <param name="txt"></param>
    ''' <param name="com"></param>
    Sub Send_Data(txt() As Guna2TextBox, com() As Guna2ComboBox)
        txt(0).Text = Items_Code
        txt(1).Text = Items_NameAR
        txt(2).Text = Items_NameEn
        txt(3).Text = Items_pricesale
        com(0).SelectedValue = Unit.Unit_ID
        com(1).SelectedValue = CategoryOne.CategoryOne_ID
        com(2).SelectedValue = CategoryTwo.CategoryTwo_ID
        com(3).SelectedValue = CategoryThree.CategoryThree_ID
        com(4).SelectedValue = CategoryFour.CategoryFour_ID
        'txt(4).Text = LastSalePrice
        'txt(5).Text = LastSalePrice
        txt(4).Text = ItemAvgCost
        txt(5).Text = ItemAvailableQty

    End Sub


#Region "Constructor"
    ' المُنشئ لتعبئة البيانات عند إنشاء الكائن
    Public Sub New(Optional id As Integer = 0,
                   Optional code As String = "",
                   Optional nameAR As String = "",
                   Optional nameEn As String = "",
                   Optional unitId As Integer = 0,
                   Optional priceSale As Decimal = 0D,
                   Optional categoryOneId As Integer = 0,
                   Optional categoryTwoId As Integer = 0,
                   Optional categoryThreeId As Integer = 0,
                   Optional categoryFourId As Integer = 0,
                   Optional cost As Decimal = 0D,
                   Optional qtyBalance As Decimal = 0D)

        _Items_ID = id
        _Items_Code = code
        _Items_NameAR = nameAR
        _Items_NameEn = nameEn
        _Unit.Unit_ID = unitId
        _Items_pricesale = priceSale
        _CategoryOne.CategoryOne_ID = categoryOneId
        _CategoryTwo.CategoryTwo_ID = categoryTwoId
        _CategoryThree.CategoryThree_ID = categoryThreeId
        _CategoryFour.CategoryFour_ID = categoryFourId
        _Items_Cost = cost
        _Items_QtyBalance = qtyBalance
    End Sub
#End Region



#Region "Methods"
    ''' <summary>
    ''' تنفيذ الإجراء المخزن لحفظ صنف جديد
    ''' </summary>
    ''' <returns>عدد السجلات المتأثرة (عادة 1 إذا تم الحفظ بنجاح)</returns>
    Public Function SaveNewItem() As Integer
        Dim parameters As New List(Of SqlParameter) From {
          New SqlParameter("@Items_Code", SqlDbType.NVarChar, 20) With {.Value = Items_Code},
        New SqlParameter("@Items_NameAR", SqlDbType.NVarChar, 200) With {.Value = Items_NameAR},
        New SqlParameter("@Items_NameEn", SqlDbType.NVarChar, 200) With {.Value = If(Items_NameEn, DBNull.Value)},
        New SqlParameter("@Unit_ID", SqlDbType.Int) With {.Value = Unit.Unit_ID},
        New SqlParameter("@Items_pricesale", SqlDbType.Decimal) With {.Value = Items_pricesale},
        New SqlParameter("@CategoryOne_ID", SqlDbType.Int) With {.Value =
                       If(CategoryOne.CategoryOne_ID <> Nothing, CategoryOne.CategoryOne_ID, -1)},
        New SqlParameter("@CategoryTwo_ID", SqlDbType.Int) With {.Value =
                       If(CategoryTwo.CategoryTwo_ID <> Nothing, CategoryTwo.CategoryTwo_ID, -1)},
        New SqlParameter("@CategoryThree_ID", SqlDbType.Int) With {.Value =
                       If(CategoryThree.CategoryThree_ID <> Nothing, CategoryThree.CategoryThree_ID, -1)},
        New SqlParameter("@CategoryFour_ID", SqlDbType.Int) With {.Value =
                       If(CategoryFour.CategoryFour_ID <> Nothing, CategoryFour.CategoryFour_ID, -1)},
        New SqlParameter("@Items_Cost", SqlDbType.Decimal) With {.Value =
                       If(Items_Cost <> Nothing, Items_Cost, DBNull.Value)},
        New SqlParameter("@Items_QtyBalance", SqlDbType.Int) With {.Value =
                       If(Items_QtyBalance <> Nothing, Items_QtyBalance, DBNull.Value)}
        }


        Dim result As Integer = sqlMethod.ExecuteStoredProcedure("Items.AddNew_Item", parameters.ToArray())

        If result > 0 Then
            MsgBox("تم حفظ المنتج بنجاح.")
        Else
            MsgBox("حدث خطأ في الحفظ.")
        End If
        Return result
    End Function
    ''' <summary>
    ''' تنفيذ الإجراء المخزن لتعديل صنف جديد
    ''' </summary>
    ''' <returns>عدد السجلات المتأثرة (عادة 1 إذا تم الحفظ بنجاح)</returns>
    Public Function UpdateItem() As Integer
        Dim parameters As New List(Of SqlParameter) From {
             New SqlParameter("@Items_Code", SqlDbType.NVarChar, 20) With {.Value = Items_Code},
             New SqlParameter("@Items_NameAR", SqlDbType.NVarChar, 200) With {.Value = Items_NameAR},
             New SqlParameter("@Items_NameEn", SqlDbType.NVarChar, 200) With {.Value = If(Items_NameEn, DBNull.Value)},
             New SqlParameter("@Unit_ID", SqlDbType.Int) With {.Value = Unit.Unit_ID},
             New SqlParameter("@Items_pricesale", SqlDbType.Decimal) With {.Value = Items_pricesale},
             New SqlParameter("@CategoryOne_ID", SqlDbType.Int) With {.Value =
                       If(CategoryOne.CategoryOne_ID <> Nothing, CategoryOne.CategoryOne_ID, -1)},
             New SqlParameter("@CategoryTwo_ID", SqlDbType.Int) With {.Value =
                       If(CategoryTwo.CategoryTwo_ID <> Nothing, CategoryTwo.CategoryTwo_ID, -1)},
             New SqlParameter("@CategoryThree_ID", SqlDbType.Int) With {.Value =
                       If(CategoryThree.CategoryThree_ID <> Nothing, CategoryThree.CategoryThree_ID, -1)},
            New SqlParameter("@CategoryFour_ID", SqlDbType.Int) With {.Value =
                       If(CategoryFour.CategoryFour_ID <> Nothing, CategoryFour.CategoryFour_ID, -1)},
            New SqlParameter("@Items_Cost", SqlDbType.Decimal) With {.Value =
                       If(Items_Cost <> Nothing, Items_Cost, DBNull.Value)},
              New SqlParameter("@Items_QtyBalance", SqlDbType.Int) With {.Value =
                       If(Items_QtyBalance <> Nothing, Items_QtyBalance, DBNull.Value)},
                New SqlParameter("@ITems_ID", SqlDbType.Int) With {.Value = Items_ID}
            }


        Dim result As Integer = sqlMethod.ExecuteStoredProcedure("Items.Update_Item", parameters.ToArray())

        If result > 0 Then
            MsgBox("تم تعديل المنتج بنجاح.")
        Else
            MsgBox("حدث خطأ في التعديل.")
        End If
        Return result
    End Function

    ''' <summary>
    ''' تنفيذ الإجراء المخزن لعرض جميع المستودعات والاقسام
    ''' </summary>

    Public Function View_ItemsInfo() As DataTable

        ' إعداد الإجراء المخزن
        View_ItemsInfo = sqlMethod.ExecuteSelectData("Items.pro_view_items")
        ' التحقق من النتيجة

    End Function
    ''' <summary>
    ''' البحث باستخدام الكود عن طريق %%%%
    ''' </summary>
    ''' <param name="Items_Code"></param>
    ''' <returns></returns>
    Function Search_by_code(Items_Code As String) As DataTable
        Dim parametars As New List(Of SqlParameter) From {
               New SqlParameter("@Items_Code", SqlDbType.NVarChar, 50) With {.Value = Items_Code}}
        Search_by_code = sqlMethod.ExecuteSelectData("Items.pro_View_Items_Code", parametars.ToArray())
    End Function
    ''' <summary>
    ''' البحث عن طريق الاسم العربي %%%%%
    ''' </summary>
    ''' <param name="Item_Name"></param>
    ''' <returns></returns>
    Function Search_by_NameAr(Item_NameAr As String) As DataTable
        Dim parametars As New List(Of SqlParameter) From {
               New SqlParameter("@Items_NameAr", SqlDbType.NVarChar, 150) With {.Value = Item_NameAr}}
        Search_by_NameAr = sqlMethod.ExecuteSelectData("Items.Pro_View_Items_NameAr", parametars.ToArray())
    End Function
    ''' <summary>
    ''' البحث عن طريق الاسم الانجليزي %%%%%
    ''' </summary>
    ''' <param name="Item_NameEn"></param>
    ''' <returns></returns>
    Function Search_by_NameEn(Items_NameEn As String) As DataTable
        Dim parametars As New List(Of SqlParameter) From {
               New SqlParameter("@Items_NameEn", SqlDbType.NVarChar, 150) With {.Value = Items_NameEn}}
        Search_by_NameEn = sqlMethod.ExecuteSelectData("Items.Pro_View_Items_NameEn", parametars.ToArray())
    End Function
    ''' <summary>
    ''' استقبال الرصيد في كل المخازن لصنف 
    ''' </summary>
    ''' <param name="item_ID"></param>
    ''' <returns></returns>
    Function BalanceOfItem(item_ID As Integer) As Integer
        Dim parameters As New List(Of SqlParameter) From {
           New SqlParameter("@item_ID", SqlDbType.Int) With {.Value = item_ID}}
        Dim dt As New DataTable
        dt = sqlMethod.ExecuteSelectData("Items.pro_ItemBalance", parameters.ToArray())

        If dt.Rows.Count <> Nothing Then
            BalanceOfItem = If(IsDBNull(dt(0)("Item_Qty")), 0, dt(0)("Item_Qty"))
        Else
            Return 0
        End If
    End Function
    ''' <summary>
    ''' رصيد الصنف في المستودع الحالي 
    ''' </summary>
    ''' <param name="item_ID"></param>
    ''' <param name="Deprartment"></param>
    ''' <returns></returns>
    Function BalanceOfItemInDeprartment(item_ID As Integer, Deprartment As Integer) As Integer
        Dim parameters As New List(Of SqlParameter) From {
           New SqlParameter("@item_ID", SqlDbType.Int) With {.Value = item_ID},
           New SqlParameter("@DepartmentID", SqlDbType.Int) With {.Value = Deprartment}}
        ' معامل الإخراج بشكل منفصل
        Dim _Dt As New DataTable
        _Dt = sqlMethod.ExecuteSelectData("Items.pro_ItemBalanceInDepartment ", parameters.ToArray())

        If _Dt.Rows.Count <> Nothing Then
            BalanceOfItemInDeprartment = If(Not IsDBNull(_Dt(0)("Item_Qty")), 0, _Dt(0)("Item_Qty"))
        Else
            Return 0
        End If
    End Function
    ''' <summary>
    ''' عرض كل الحركات في كل المخازن 
    ''' </summary>
    ''' <param name="item_ID"></param>
    ''' <returns></returns>
    Function AllMove_Item() As DataTable
        Dim parameters As New List(Of SqlParameter) From {
           New SqlParameter("@Items_ID", SqlDbType.Int) With {.Value = Items_ID}}
        ' معامل الإخراج بشكل منفصل

        AllMove_Item = sqlMethod.ExecuteSelectData("Stores.pro_AllMoves", parameters.ToArray())
    End Function
    ''' <summary>
    ''' عرض التكلفه ورصيد في كل المخازن 
    ''' </summary>
    ''' <param name="item_ID"></param>
    ''' <returns></returns>
    Function AvgCostAndBalance() As Integer
        Dim parameters As New List(Of SqlParameter) From {
           New SqlParameter("@Items_ID", SqlDbType.Int) With {.Value = Items_ID}}
        ' معامل الإخراج بشكل منفصل
        Dim dt As New DataTable
        dt = sqlMethod.ExecuteSelectData("Stores.pro_AvgCostAndBalans", parameters.ToArray())
        If dt.Rows.Count <> Nothing Then

            AvgCostAndBalance = If(IsDBNull(dt(0)("avg_Cost")), 0, dt(0)("avg_Cost"))
        Else
            Return 0
        End If

    End Function
    Function Show_DetailsMove(info As String, department As Integer) As DataTable
        Dim parameters As New List(Of SqlParameter) From {
           New SqlParameter("@Items_ID", SqlDbType.Int) With {.Value = Items_ID},
          New SqlParameter("@info", SqlDbType.NVarChar = 10) With {.Value = info},
          New SqlParameter("@Department", SqlDbType.Int) With {.Value = department}}
        ' معامل الإخراج بشكل منفصل
        Dim dt As New DataTable
        Show_DetailsMove = sqlMethod.ExecuteSelectData("Stores.pro_DetailsMove", parameters.ToArray())
    End Function
#End Region

    Sub load_AvgAndBalance()
        ItemAvgCost = AvgCostAndBalance()
        ItemAvailableQty = BalanceOfItem(item_ID:=Items_ID)
    End Sub


#Region "CombBox load Data"
    Sub com_CategoryOne(cmd As Guna2ComboBox)
        cmd.DataSource = CategoryOne.View_Categorys
        cmd.ValueMember = "CategoryOne_ID"
        cmd.DisplayMember = "CategoryOne_Name"
    End Sub
    Sub com_CategoryTwo(cmd As Guna2ComboBox)
        cmd.DataSource = CategoryTwo.View_Categorys
        cmd.ValueMember = "CategoryTwo_ID"
        cmd.DisplayMember = "CategoryTwo_Name"
    End Sub
    Sub com_CategoryThree(cmd As Guna2ComboBox)
        cmd.DataSource = CategoryThree.View_Categorys
        cmd.ValueMember = "CategoryThree_ID"
        cmd.DisplayMember = "CategoryThree_Name"
    End Sub
    Sub com_CategoryFour(cmd As Guna2ComboBox)
        cmd.DataSource = CategoryFour.View_Categorys
        cmd.ValueMember = "CategoryFour_ID"
        cmd.DisplayMember = "CategoryFour_Name"
    End Sub
    Sub Com_unit(cmd As Guna2ComboBox)
        cmd.DataSource = Unit.View_Units
        cmd.ValueMember = "Unit_ID"
        cmd.DisplayMember = "Unit_Name"
    End Sub
#End Region

    Public Sub Dgv_Design_view_items(dgv As Guna2DataGridView)
        'Dim cel As DataGridViewCell
        'cel.Value = "حذف"
        'dg.CellTemplate = cel

        'dg.Name = "Del"
        'dg.Text = "حذف"

        'dgv.Columns.Add(Dg)

        'dgv.Columns("Del").Width = 50

        'dgv.Columns("Del").Visible = False

        'AddHandler dgv.CellClick, AddressOf Delete_item(sender, e)
        ' Column Header Disign

        'dgv.Columns("Del").Width = 50

        'dgv.Columns("Del").Visible = False
        'dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.BurlyWood
        'dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.DarkGreen
        dgv.ColumnHeadersDefaultCellStyle.Font =
        New Font("Cairo", 10, FontStyle.Bold)
        dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'dgv.BackgroundColor = Color.Black
        dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv.EnableHeadersVisualStyles = True

        'Column Header Text
        'dgv.Columns("Items_Code").Visible = False
        'dgv.Columns("Items_ID").Visible = False
        '' dgv.Columns("ID_Items_").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'dgv.Columns("Items_NameAR").Visible = False
        'dgv.Columns("supplier_Name").Visible = False

        'dgv.Columns("purchase_invoiceDate").Visible = False
        '' dgv.Columns("InvoicePD_Qty").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'dgv.Columns("purchase_invoiceNo").HeaderText = "رقم الفاتوره"
        ''dgv.Columns("InvoicePD_price_Item").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'dgv.Columns("Department_ID").Visible = False
        ''  dgv.Columns("InvoicePD_Discount").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'dgv.Columns("Store_ID").Visible = False
        ' dgv.Columns("InvoicePD_Discount").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        '  dgv.Columns("InvoicePD_Total_Price").Width = 120
        dgv.Columns("Items_ID").Visible = False

        dgv.Columns("Items_Code").HeaderText = "كود الصنف"
        dgv.Columns("Items_NameAR").HeaderText = "Ar اسم الصنف"
        dgv.Columns("Items_NameEn").HeaderText = "En اسم الصنف"
        dgv.Columns("Unit_ID").Visible = False
        dgv.Columns("unit_name").HeaderText = "الوحده"
        dgv.Columns("CategoryOne_ID").Visible = False
        dgv.Columns("Items_pricesale").HeaderText = "سعر البيع"
        dgv.Columns("CategoryOne_Name").HeaderText = "الفئه 1"
        dgv.Columns("CategoryTwo_ID").Visible = False
        dgv.Columns("CategoryTwo_ID").Visible = False
        dgv.Columns("CategoryThree_ID").Visible = False
        dgv.Columns("CategoryTwo_Name").HeaderText = "الفئه 2"
        dgv.Columns("CategoryThree_Name").HeaderText = "الفئه 3"
        dgv.Columns("Categoryfour_ID").Visible = False
        dgv.Columns("CategoryFour_Name").HeaderText = "الفئه 4"
        'Column Celles Disign
        'dgv.Columns("ID_InvoiceByeDetils").DefaultCellStyle.BackColor = Color.White
        'dgv.Columns("ID_Items_").DefaultCellStyle.BackColor = Color.White
        'dgv.Columns("ID_Invoice_").DefaultCellStyle.BackColor = Color.White
        'dgv.Columns("InvoiceBD_Qty").DefaultCellStyle.BackColor = Color.White
        'dgv.Columns("InvoiceBD_price_Item").DefaultCellStyle.BackColor = Color.White
        'dgv.Columns("InvoiceBD_Discount").DefaultCellStyle.BackColor = Color.White
        'dgv.Columns("InvoiceBD_Total_Price").DefaultCellStyle.BackColor = Color.White
        'dgv.Columns("InvoiceBD_UserName").DefaultCellStyle.BackColor = Color.White
        dgv.DefaultCellStyle.Font =
         New Font("Cairo", 9, FontStyle.Bold)
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgv.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal
        dgv.DefaultCellStyle.SelectionBackColor = Color.Black
        dgv.DefaultCellStyle.SelectionForeColor = Color.White
        dgv.RowHeadersVisible = False
        ' dgv.AutoResizeColumns()
        dgv.AutoResizeRows()
        dgv.AutoSize = False
        dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dgv.CellBorderStyle = DataGridViewCellBorderStyle.Sunken
        dgv.AllowUserToAddRows = False
        dgv.AllowUserToDeleteRows = False
        dgv.AllowUserToResizeRows = False


    End Sub
    Public Sub Dgv_Design_MoveItem(dgv As Guna2DataGridView)
        'Dim cel As DataGridViewCell
        'cel.Value = "حذف"
        'dg.CellTemplate = cel

        'dg.Name = "Del"
        'dg.Text = "حذف"

        'dgv.Columns.Add(Dg)

        'dgv.Columns("Del").Width = 50

        'dgv.Columns("Del").Visible = False

        'AddHandler dgv.CellClick, AddressOf Delete_item(sender, e)
        ' Column Header Disign

        'dgv.Columns("Del").Width = 50

        'dgv.Columns("Del").Visible = False
        'dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.BurlyWood
        'dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.DarkGreen
        dgv.ColumnHeadersDefaultCellStyle.Font =
        New Font("Cairo", 10, FontStyle.Bold)
        dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'dgv.BackgroundColor = Color.Black
        dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv.EnableHeadersVisualStyles = True

        'Column Header Text
        'dgv.Columns("Items_Code").Visible = False
        'dgv.Columns("Items_ID").Visible = False
        '' dgv.Columns("ID_Items_").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'dgv.Columns("Items_NameAR").Visible = False
        'dgv.Columns("supplier_Name").Visible = False

        'dgv.Columns("purchase_invoiceDate").Visible = False
        '' dgv.Columns("InvoicePD_Qty").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'dgv.Columns("purchase_invoiceNo").HeaderText = "رقم الفاتوره"
        ''dgv.Columns("InvoicePD_price_Item").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'dgv.Columns("Department_ID").Visible = False
        ''  dgv.Columns("InvoicePD_Discount").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'dgv.Columns("Store_ID").Visible = False
        ' dgv.Columns("InvoicePD_Discount").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        '  dgv.Columns("InvoicePD_Total_Price").Width = 120
        dgv.Columns("Items_ID").Visible = False

        dgv.Columns("Info").HeaderText = "INFo"
        dgv.Columns("total").HeaderText = "الاجــمالي"
        dgv.Columns("Item_Cost").HeaderText = "التكلفة"
        dgv.Columns("Item_Qty").HeaderText = "الكمية"
        dgv.Columns("Department_ID").Visible = False
        dgv.Columns("Department_Name").HeaderText = "القسم"
        dgv.Columns("Store_Name").HeaderText = "الفرع"
        'dgv.Columns("CategoryOne_Name").HeaderText = "الفئه 1"
        'dgv.Columns("CategoryTwo_ID").Visible = False
        'dgv.Columns("CategoryTwo_ID").Visible = False
        'dgv.Columns("CategoryThree_ID").Visible = False
        'dgv.Columns("CategoryTwo_Name").HeaderText = "الفئه 2"
        'dgv.Columns("CategoryThree_Name").HeaderText = "الفئه 3"
        'dgv.Columns("Categoryfour_ID").Visible = False
        'dgv.Columns("CategoryFour_Name").HeaderText = "الفئه 4"
        ''Column Celles Disign
        'dgv.Columns("ID_InvoiceByeDetils").DefaultCellStyle.BackColor = Color.White
        'dgv.Columns("ID_Items_").DefaultCellStyle.BackColor = Color.White
        'dgv.Columns("ID_Invoice_").DefaultCellStyle.BackColor = Color.White
        'dgv.Columns("InvoiceBD_Qty").DefaultCellStyle.BackColor = Color.White
        'dgv.Columns("InvoiceBD_price_Item").DefaultCellStyle.BackColor = Color.White
        'dgv.Columns("InvoiceBD_Discount").DefaultCellStyle.BackColor = Color.White
        'dgv.Columns("InvoiceBD_Total_Price").DefaultCellStyle.BackColor = Color.White
        'dgv.Columns("InvoiceBD_UserName").DefaultCellStyle.BackColor = Color.White
        dgv.DefaultCellStyle.Font =
         New Font("Cairo", 9, FontStyle.Bold)
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgv.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal
        dgv.DefaultCellStyle.SelectionBackColor = Color.Black
        dgv.DefaultCellStyle.SelectionForeColor = Color.White
        dgv.RowHeadersVisible = False
        ' dgv.AutoResizeColumns()
        dgv.AutoResizeRows()
        dgv.AutoSize = False
        dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dgv.CellBorderStyle = DataGridViewCellBorderStyle.Sunken
        dgv.AllowUserToAddRows = False
        dgv.AllowUserToDeleteRows = False
        dgv.AllowUserToResizeRows = False


    End Sub

    Public Sub Dgv_Design_DetailsMove(dgv As Guna2DataGridView)
        'Dim cel As DataGridViewCell
        'cel.Value = "حذف"
        'dg.CellTemplate = cel

        'dg.Name = "Del"
        'dg.Text = "حذف"

        'dgv.Columns.Add(Dg)

        'dgv.Columns("Del").Width = 50

        'dgv.Columns("Del").Visible = False

        'AddHandler dgv.CellClick, AddressOf Delete_item(sender, e)
        ' Column Header Disign

        'dgv.Columns("Del").Width = 50

        'dgv.Columns("Del").Visible = False
        'dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.BurlyWood
        'dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.DarkGreen
        dgv.ColumnHeadersDefaultCellStyle.Font =
        New Font("Cairo", 10, FontStyle.Bold)
        dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'dgv.BackgroundColor = Color.Black
        dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv.EnableHeadersVisualStyles = True

        'Column Header Text
        'dgv.Columns("Items_Code").Visible = False
        'dgv.Columns("Items_ID").Visible = False
        '' dgv.Columns("ID_Items_").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'dgv.Columns("Items_NameAR").Visible = False
        'dgv.Columns("supplier_Name").Visible = False

        'dgv.Columns("purchase_invoiceDate").Visible = False
        '' dgv.Columns("InvoicePD_Qty").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'dgv.Columns("purchase_invoiceNo").HeaderText = "رقم الفاتوره"
        ''dgv.Columns("InvoicePD_price_Item").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'dgv.Columns("Department_ID").Visible = False
        ''  dgv.Columns("InvoicePD_Discount").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'dgv.Columns("Store_ID").Visible = False
        ' dgv.Columns("InvoicePD_Discount").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        '  dgv.Columns("InvoicePD_Total_Price").Width = 120
        dgv.Columns("Items_ID").Visible = False

        dgv.Columns("Info").Visible = False
        dgv.Columns("total").HeaderText = "الاجــمالي"
        dgv.Columns("Item_Cost").HeaderText = "التكلفة"
        dgv.Columns("Item_Qty").HeaderText = "الكمية"
        dgv.Columns("Department_ID").Visible = False
        dgv.Columns("Department_Name").HeaderText = "القسم"
        dgv.Columns("Store_Name").HeaderText = "الفرع"
        dgv.Columns("function_ID").HeaderText = "Function No"
        dgv.Columns("AccFunction_type").HeaderText = "نوع العمليه"
        'dgv.Columns("CategoryTwo_ID").Visible = False
        'dgv.Columns("CategoryTwo_ID").Visible = False
        'dgv.Columns("CategoryThree_ID").Visible = False
        'dgv.Columns("CategoryTwo_Name").HeaderText = "الفئه 2"
        'dgv.Columns("CategoryThree_Name").HeaderText = "الفئه 3"
        'dgv.Columns("Categoryfour_ID").Visible = False
        'dgv.Columns("CategoryFour_Name").HeaderText = "الفئه 4"
        ''Column Celles Disign
        'dgv.Columns("ID_InvoiceByeDetils").DefaultCellStyle.BackColor = Color.White
        'dgv.Columns("ID_Items_").DefaultCellStyle.BackColor = Color.White
        'dgv.Columns("ID_Invoice_").DefaultCellStyle.BackColor = Color.White
        'dgv.Columns("InvoiceBD_Qty").DefaultCellStyle.BackColor = Color.White
        'dgv.Columns("InvoiceBD_price_Item").DefaultCellStyle.BackColor = Color.White
        'dgv.Columns("InvoiceBD_Discount").DefaultCellStyle.BackColor = Color.White
        'dgv.Columns("InvoiceBD_Total_Price").DefaultCellStyle.BackColor = Color.White
        'dgv.Columns("InvoiceBD_UserName").DefaultCellStyle.BackColor = Color.White
        dgv.DefaultCellStyle.Font =
         New Font("Cairo", 9, FontStyle.Bold)
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgv.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal
        dgv.DefaultCellStyle.SelectionBackColor = Color.Black
        dgv.DefaultCellStyle.SelectionForeColor = Color.White
        dgv.RowHeadersVisible = False
        ' dgv.AutoResizeColumns()
        dgv.AutoResizeRows()
        dgv.AutoSize = False
        dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dgv.CellBorderStyle = DataGridViewCellBorderStyle.Sunken
        dgv.AllowUserToAddRows = False
        dgv.AllowUserToDeleteRows = False
        dgv.AllowUserToResizeRows = False


    End Sub
End Class

