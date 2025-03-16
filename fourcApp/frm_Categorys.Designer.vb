<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Categorys

    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges7 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges8 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Categorys))
        Guna2ControlBox1 = New Guna.UI2.WinForms.Guna2ControlBox()
        Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        panal_Category = New Guna.UI2.WinForms.Guna2ShadowPanel()
        com_ItemType = New Guna.UI2.WinForms.Guna2ComboBox()
        txt_DepartmentName = New Guna.UI2.WinForms.Guna2TextBox()
        Label16 = New Label()
        Label6 = New Label()
        Label1 = New Label()
        Label2 = New Label()
        UC_cur1 = New UC_CUR()
        Guna2Panel1.SuspendLayout()
        panal_Category.SuspendLayout()
        SuspendLayout()
        ' 
        ' Guna2ControlBox1
        ' 
        Guna2ControlBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Guna2ControlBox1.Animated = True
        Guna2ControlBox1.CustomizableEdges = CustomizableEdges1
        Guna2ControlBox1.FillColor = Color.Transparent
        Guna2ControlBox1.IconColor = Color.DimGray
        Guna2ControlBox1.Location = New Point(769, 8)
        Guna2ControlBox1.Name = "Guna2ControlBox1"
        Guna2ControlBox1.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        Guna2ControlBox1.Size = New Size(25, 23)
        Guna2ControlBox1.TabIndex = 1
        ' 
        ' Guna2Panel1
        ' 
        Guna2Panel1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Guna2Panel1.AutoSize = True
        Guna2Panel1.BorderRadius = 10
        Guna2Panel1.Controls.Add(panal_Category)
        Guna2Panel1.CustomizableEdges = CustomizableEdges7
        Guna2Panel1.Location = New Point(7, 94)
        Guna2Panel1.Name = "Guna2Panel1"
        Guna2Panel1.ShadowDecoration.CustomizableEdges = CustomizableEdges8
        Guna2Panel1.Size = New Size(795, 188)
        Guna2Panel1.TabIndex = 1
        ' 
        ' panal_Category
        ' 
        panal_Category.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        panal_Category.BackColor = Color.Transparent
        panal_Category.Controls.Add(com_ItemType)
        panal_Category.Controls.Add(txt_DepartmentName)
        panal_Category.Controls.Add(Label16)
        panal_Category.Controls.Add(Label6)
        panal_Category.FillColor = Color.FromArgb(CByte(178), CByte(213), CByte(159))
        panal_Category.Font = New Font("Cairo", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        panal_Category.Location = New Point(5, 4)
        panal_Category.Name = "panal_Category"
        panal_Category.ShadowColor = Color.Transparent
        panal_Category.Size = New Size(782, 181)
        panal_Category.TabIndex = 0
        ' 
        ' com_ItemType
        ' 
        com_ItemType.BackColor = Color.Transparent
        com_ItemType.BorderRadius = 10
        com_ItemType.CustomizableEdges = CustomizableEdges3
        com_ItemType.DrawMode = DrawMode.OwnerDrawFixed
        com_ItemType.DropDownStyle = ComboBoxStyle.DropDownList
        com_ItemType.FillColor = Color.FromArgb(CByte(97), CByte(129), CByte(124))
        com_ItemType.FocusedColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        com_ItemType.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        com_ItemType.Font = New Font("Playfair Display", 9.749998F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        com_ItemType.ForeColor = Color.White
        com_ItemType.ItemHeight = 30
        com_ItemType.Items.AddRange(New Object() {"Category One", "Category Two", "Category Three", "Category Four"})
        com_ItemType.Location = New Point(416, 23)
        com_ItemType.Name = "com_ItemType"
        com_ItemType.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        com_ItemType.Size = New Size(235, 36)
        com_ItemType.TabIndex = 10
        ' 
        ' txt_DepartmentName
        ' 
        txt_DepartmentName.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        txt_DepartmentName.Animated = True
        txt_DepartmentName.BorderRadius = 10
        txt_DepartmentName.CustomizableEdges = CustomizableEdges5
        txt_DepartmentName.DefaultText = ""
        txt_DepartmentName.DisabledState.BorderColor = Color.FromArgb(CByte(208), CByte(208), CByte(208))
        txt_DepartmentName.DisabledState.FillColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        txt_DepartmentName.DisabledState.ForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        txt_DepartmentName.DisabledState.PlaceholderForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        txt_DepartmentName.FillColor = Color.FromArgb(CByte(97), CByte(129), CByte(124))
        txt_DepartmentName.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        txt_DepartmentName.Font = New Font("Cairo", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txt_DepartmentName.ForeColor = Color.White
        txt_DepartmentName.HoverState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        txt_DepartmentName.Location = New Point(416, 97)
        txt_DepartmentName.Margin = New Padding(3, 5, 3, 5)
        txt_DepartmentName.Name = "txt_DepartmentName"
        txt_DepartmentName.PlaceholderText = ""
        txt_DepartmentName.SelectedText = ""
        txt_DepartmentName.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        txt_DepartmentName.Size = New Size(235, 32)
        txt_DepartmentName.TabIndex = 1
        txt_DepartmentName.TextAlign = HorizontalAlignment.Right
        ' 
        ' Label16
        ' 
        Label16.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label16.AutoSize = True
        Label16.Location = New Point(664, 102)
        Label16.Name = "Label16"
        Label16.Size = New Size(90, 23)
        Label16.TabIndex = 6
        Label16.Text = "اسم النـــــــــوع"
        Label16.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' Label6
        ' 
        Label6.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label6.AutoSize = True
        Label6.Location = New Point(692, 30)
        Label6.Name = "Label6"
        Label6.Size = New Size(62, 23)
        Label6.TabIndex = 9
        Label6.Text = "كود الفرع"
        Label6.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Playfair Display", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(12, 19)
        Label1.Name = "Label1"
        Label1.Size = New Size(148, 26)
        Label1.TabIndex = 2
        Label1.Text = "Categorys Card"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Cairo Black", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(25, 45)
        Label2.Name = "Label2"
        Label2.Size = New Size(123, 30)
        Label2.TabIndex = 2
        Label2.Text = "بطـــاقة الأنواع"
        ' 
        ' UC_cur1
        ' 
        UC_cur1.Anchor = AnchorStyles.Top
        UC_cur1.BackColor = Color.Transparent
        UC_cur1.ColorCur = Color.Transparent
        UC_cur1.colorToolstrip = Color.Transparent
        UC_cur1.Cur1 = Nothing
        UC_cur1.Location = New Point(166, 8)
        UC_cur1.Margin = New Padding(4, 3, 4, 3)
        UC_cur1.Name = "UC_cur1"
        UC_cur1.Size = New Size(472, 78)
        UC_cur1.TabIndex = 3
        ' 
        ' frm_Categorys
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        BackColor = Color.FromArgb(CByte(163), CByte(223), CByte(187))
        ClientSize = New Size(804, 284)
        Controls.Add(UC_cur1)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(Guna2Panel1)
        Controls.Add(Guna2ControlBox1)
        FormBorderStyle = FormBorderStyle.None
        MaximizeBox = False
        MinimizeBox = False
        Name = "frm_Categorys"
        StartPosition = FormStartPosition.CenterScreen
        Text = "frm_Items"
        Guna2Panel1.ResumeLayout(False)
        panal_Category.ResumeLayout(False)
        panal_Category.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Guna2ControlBox1 As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents panal_Category As Guna.UI2.WinForms.Guna2ShadowPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents UC_cur1 As UC_CUR
    Friend WithEvents txt_DepartmentName As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents com_ItemType As Guna.UI2.WinForms.Guna2ComboBox
End Class
