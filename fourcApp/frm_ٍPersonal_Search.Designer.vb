<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Personal_search
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
        Dim CustomizableEdges9 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges10 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges7 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges8 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Guna2ControlBox1 = New Guna.UI2.WinForms.Guna2ControlBox()
        Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Guna2Panel2 = New Guna.UI2.WinForms.Guna2Panel()
        dgv_ItemsMove = New Guna.UI2.WinForms.Guna2DataGridView()
        panal_iteminfo = New Guna.UI2.WinForms.Guna2ShadowPanel()
        txt_SearchInfo = New Guna.UI2.WinForms.Guna2TextBox()
        Com_searchMode = New Guna.UI2.WinForms.Guna2ComboBox()
        Label6 = New Label()
        Guna2Panel1.SuspendLayout()
        Guna2Panel2.SuspendLayout()
        CType(dgv_ItemsMove, ComponentModel.ISupportInitialize).BeginInit()
        panal_iteminfo.SuspendLayout()
        SuspendLayout()
        ' 
        ' Guna2ControlBox1
        ' 
        Guna2ControlBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Guna2ControlBox1.Animated = True
        Guna2ControlBox1.CustomizableEdges = CustomizableEdges1
        Guna2ControlBox1.FillColor = Color.Transparent
        Guna2ControlBox1.IconColor = Color.DimGray
        Guna2ControlBox1.Location = New Point(900, 8)
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
        Guna2Panel1.Controls.Add(Guna2Panel2)
        Guna2Panel1.Controls.Add(panal_iteminfo)
        Guna2Panel1.CustomizableEdges = CustomizableEdges9
        Guna2Panel1.Location = New Point(12, 43)
        Guna2Panel1.Name = "Guna2Panel1"
        Guna2Panel1.ShadowDecoration.CustomizableEdges = CustomizableEdges10
        Guna2Panel1.Size = New Size(910, 511)
        Guna2Panel1.TabIndex = 1
        ' 
        ' Guna2Panel2
        ' 
        Guna2Panel2.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
        Guna2Panel2.AutoScroll = True
        Guna2Panel2.BorderRadius = 20
        Guna2Panel2.Controls.Add(dgv_ItemsMove)
        Guna2Panel2.CustomizableEdges = CustomizableEdges3
        Guna2Panel2.Location = New Point(9, 94)
        Guna2Panel2.Name = "Guna2Panel2"
        Guna2Panel2.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        Guna2Panel2.Size = New Size(893, 407)
        Guna2Panel2.TabIndex = 1
        ' 
        ' dgv_ItemsMove
        ' 
        dgv_ItemsMove.AllowUserToAddRows = False
        dgv_ItemsMove.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = Color.White
        dgv_ItemsMove.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        dgv_ItemsMove.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        dgv_ItemsMove.BackgroundColor = Color.FromArgb(CByte(163), CByte(223), CByte(187))
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(100), CByte(88), CByte(255))
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9.0F)
        DataGridViewCellStyle2.ForeColor = Color.White
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        dgv_ItemsMove.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        dgv_ItemsMove.ColumnHeadersHeight = 30
        dgv_ItemsMove.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = Color.White
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 9.0F)
        DataGridViewCellStyle3.ForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        DataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        DataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.False
        dgv_ItemsMove.DefaultCellStyle = DataGridViewCellStyle3
        dgv_ItemsMove.GridColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        dgv_ItemsMove.Location = New Point(3, 17)
        dgv_ItemsMove.Name = "dgv_ItemsMove"
        dgv_ItemsMove.ReadOnly = True
        dgv_ItemsMove.RowHeadersVisible = False
        dgv_ItemsMove.Size = New Size(887, 387)
        dgv_ItemsMove.TabIndex = 2
        dgv_ItemsMove.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White
        dgv_ItemsMove.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        dgv_ItemsMove.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty
        dgv_ItemsMove.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty
        dgv_ItemsMove.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty
        dgv_ItemsMove.ThemeStyle.BackColor = Color.FromArgb(CByte(163), CByte(223), CByte(187))
        dgv_ItemsMove.ThemeStyle.GridColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        dgv_ItemsMove.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(CByte(100), CByte(88), CByte(255))
        dgv_ItemsMove.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None
        dgv_ItemsMove.ThemeStyle.HeaderStyle.Font = New Font("Segoe UI", 9.0F)
        dgv_ItemsMove.ThemeStyle.HeaderStyle.ForeColor = Color.White
        dgv_ItemsMove.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        dgv_ItemsMove.ThemeStyle.HeaderStyle.Height = 30
        dgv_ItemsMove.ThemeStyle.ReadOnly = True
        dgv_ItemsMove.ThemeStyle.RowsStyle.BackColor = Color.White
        dgv_ItemsMove.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgv_ItemsMove.ThemeStyle.RowsStyle.Font = New Font("Segoe UI", 9.0F)
        dgv_ItemsMove.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        dgv_ItemsMove.ThemeStyle.RowsStyle.Height = 25
        dgv_ItemsMove.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        dgv_ItemsMove.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        ' 
        ' panal_iteminfo
        ' 
        panal_iteminfo.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        panal_iteminfo.BackColor = Color.Transparent
        panal_iteminfo.Controls.Add(txt_SearchInfo)
        panal_iteminfo.Controls.Add(Com_searchMode)
        panal_iteminfo.Controls.Add(Label6)
        panal_iteminfo.FillColor = Color.FromArgb(CByte(178), CByte(213), CByte(159))
        panal_iteminfo.Font = New Font("Cairo", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        panal_iteminfo.Location = New Point(124, 11)
        panal_iteminfo.Name = "panal_iteminfo"
        panal_iteminfo.ShadowColor = Color.Transparent
        panal_iteminfo.Size = New Size(665, 75)
        panal_iteminfo.TabIndex = 0
        ' 
        ' txt_SearchInfo
        ' 
        txt_SearchInfo.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        txt_SearchInfo.Animated = True
        txt_SearchInfo.BorderRadius = 10
        txt_SearchInfo.CustomizableEdges = CustomizableEdges5
        txt_SearchInfo.DefaultText = ""
        txt_SearchInfo.DisabledState.BorderColor = Color.FromArgb(CByte(208), CByte(208), CByte(208))
        txt_SearchInfo.DisabledState.FillColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        txt_SearchInfo.DisabledState.ForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        txt_SearchInfo.DisabledState.PlaceholderForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        txt_SearchInfo.FillColor = Color.FromArgb(CByte(97), CByte(129), CByte(124))
        txt_SearchInfo.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        txt_SearchInfo.Font = New Font("Segoe UI", 9.0F)
        txt_SearchInfo.ForeColor = Color.White
        txt_SearchInfo.HoverState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        txt_SearchInfo.Location = New Point(43, 24)
        txt_SearchInfo.Name = "txt_SearchInfo"
        txt_SearchInfo.PlaceholderText = ""
        txt_SearchInfo.SelectedText = ""
        txt_SearchInfo.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        txt_SearchInfo.Size = New Size(255, 30)
        txt_SearchInfo.TabIndex = 1
        txt_SearchInfo.TextAlign = HorizontalAlignment.Right
        ' 
        ' Com_searchMode
        ' 
        Com_searchMode.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Com_searchMode.BackColor = Color.Transparent
        Com_searchMode.BorderRadius = 10
        Com_searchMode.CustomizableEdges = CustomizableEdges7
        Com_searchMode.DrawMode = DrawMode.OwnerDrawFixed
        Com_searchMode.DropDownStyle = ComboBoxStyle.DropDownList
        Com_searchMode.FillColor = Color.FromArgb(CByte(97), CByte(129), CByte(124))
        Com_searchMode.FocusedColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        Com_searchMode.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        Com_searchMode.Font = New Font("Segoe UI", 10.0F)
        Com_searchMode.ForeColor = Color.White
        Com_searchMode.ItemHeight = 30
        Com_searchMode.Items.AddRange(New Object() {"بالكــــــــود", "بالاســــــــم العربي"})
        Com_searchMode.Location = New Point(349, 20)
        Com_searchMode.Name = "Com_searchMode"
        Com_searchMode.ShadowDecoration.CustomizableEdges = CustomizableEdges8
        Com_searchMode.Size = New Size(223, 36)
        Com_searchMode.TabIndex = 3
        Com_searchMode.TextAlign = HorizontalAlignment.Center
        ' 
        ' Label6
        ' 
        Label6.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label6.AutoSize = True
        Label6.Location = New Point(578, 24)
        Label6.Name = "Label6"
        Label6.Size = New Size(59, 23)
        Label6.TabIndex = 9
        Label6.Text = "البــــــحث"
        Label6.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' frm_Supplier_search
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        BackColor = Color.FromArgb(CByte(163), CByte(223), CByte(187))
        ClientSize = New Size(935, 562)
        Controls.Add(Guna2Panel1)
        Controls.Add(Guna2ControlBox1)
        FormBorderStyle = FormBorderStyle.None
        MaximizeBox = False
        MinimizeBox = False
        Name = "frm_Supplier_search"
        StartPosition = FormStartPosition.CenterScreen
        Text = "frm_Items"
        Guna2Panel1.ResumeLayout(False)
        Guna2Panel2.ResumeLayout(False)
        CType(dgv_ItemsMove, ComponentModel.ISupportInitialize).EndInit()
        panal_iteminfo.ResumeLayout(False)
        panal_iteminfo.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Guna2ControlBox1 As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents panal_iteminfo As Guna.UI2.WinForms.Guna2ShadowPanel
    Friend WithEvents Label6 As Label
    Friend WithEvents Com_searchMode As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents txt_SearchInfo As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2Panel2 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents dgv_ItemsMove As Guna.UI2.WinForms.Guna2DataGridView
End Class
