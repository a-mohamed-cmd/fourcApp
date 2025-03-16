<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Unit

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
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Unit))
        Guna2ControlBox1 = New Guna.UI2.WinForms.Guna2ControlBox()
        Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        panal_Unit = New Guna.UI2.WinForms.Guna2ShadowPanel()
        txt_UnitName = New Guna.UI2.WinForms.Guna2TextBox()
        Label16 = New Label()
        Label1 = New Label()
        Label2 = New Label()
        UC_cur1 = New UC_CUR()
        Guna2Panel1.SuspendLayout()
        panal_Unit.SuspendLayout()
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
        Guna2Panel1.Controls.Add(panal_Unit)
        Guna2Panel1.CustomizableEdges = CustomizableEdges5
        Guna2Panel1.Location = New Point(7, 94)
        Guna2Panel1.Name = "Guna2Panel1"
        Guna2Panel1.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        Guna2Panel1.Size = New Size(795, 188)
        Guna2Panel1.TabIndex = 1
        ' 
        ' panal_Unit
        ' 
        panal_Unit.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        panal_Unit.BackColor = Color.Transparent
        panal_Unit.Controls.Add(txt_UnitName)
        panal_Unit.Controls.Add(Label16)
        panal_Unit.FillColor = Color.FromArgb(CByte(178), CByte(213), CByte(159))
        panal_Unit.Font = New Font("Cairo", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        panal_Unit.Location = New Point(5, 4)
        panal_Unit.Name = "panal_Unit"
        panal_Unit.ShadowColor = Color.Transparent
        panal_Unit.Size = New Size(782, 181)
        panal_Unit.TabIndex = 0
        ' 
        ' txt_UnitName
        ' 
        txt_UnitName.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        txt_UnitName.Animated = True
        txt_UnitName.BorderRadius = 10
        txt_UnitName.CustomizableEdges = CustomizableEdges3
        txt_UnitName.DefaultText = ""
        txt_UnitName.DisabledState.BorderColor = Color.FromArgb(CByte(208), CByte(208), CByte(208))
        txt_UnitName.DisabledState.FillColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        txt_UnitName.DisabledState.ForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        txt_UnitName.DisabledState.PlaceholderForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        txt_UnitName.FillColor = Color.FromArgb(CByte(97), CByte(129), CByte(124))
        txt_UnitName.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        txt_UnitName.Font = New Font("Cairo", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txt_UnitName.ForeColor = Color.White
        txt_UnitName.HoverState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        txt_UnitName.Location = New Point(418, 56)
        txt_UnitName.Margin = New Padding(3, 5, 3, 5)
        txt_UnitName.Name = "txt_UnitName"
        txt_UnitName.PlaceholderText = ""
        txt_UnitName.SelectedText = ""
        txt_UnitName.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        txt_UnitName.Size = New Size(235, 32)
        txt_UnitName.TabIndex = 1
        txt_UnitName.TextAlign = HorizontalAlignment.Right
        ' 
        ' Label16
        ' 
        Label16.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label16.AutoSize = True
        Label16.Location = New Point(666, 61)
        Label16.Name = "Label16"
        Label16.Size = New Size(88, 23)
        Label16.TabIndex = 6
        Label16.Text = "اسم الوحـــــده"
        Label16.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Playfair Display", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(40, 19)
        Label1.Name = "Label1"
        Label1.Size = New Size(106, 26)
        Label1.TabIndex = 2
        Label1.Text = "Units Card"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Cairo Black", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(25, 45)
        Label2.Name = "Label2"
        Label2.Size = New Size(136, 30)
        Label2.TabIndex = 2
        Label2.Text = "بطـــاقة الوحدات"
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
        ' frm_Unit
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
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
        Name = "frm_Unit"
        StartPosition = FormStartPosition.CenterScreen
        Text = "frm_Items"
        Guna2Panel1.ResumeLayout(False)
        panal_Unit.ResumeLayout(False)
        panal_Unit.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Guna2ControlBox1 As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents panal_Unit As Guna.UI2.WinForms.Guna2ShadowPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents UC_cur1 As UC_CUR
    Friend WithEvents txt_UnitName As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents com_ItemType As Guna.UI2.WinForms.Guna2ComboBox
End Class
