<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_ShowDetailsMove
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
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Guna2ControlBox1 = New Guna.UI2.WinForms.Guna2ControlBox()
        Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        dgv_ItemsMove = New Guna.UI2.WinForms.Guna2DataGridView()
        Guna2Panel1.SuspendLayout()
        CType(dgv_ItemsMove, ComponentModel.ISupportInitialize).BeginInit()
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
        Guna2Panel1.Controls.Add(dgv_ItemsMove)
        Guna2Panel1.CustomizableEdges = CustomizableEdges3
        Guna2Panel1.Location = New Point(12, 43)
        Guna2Panel1.Name = "Guna2Panel1"
        Guna2Panel1.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        Guna2Panel1.Size = New Size(910, 511)
        Guna2Panel1.TabIndex = 1
        ' 
        ' dgv_ItemsMove
        ' 
        dgv_ItemsMove.AllowUserToAddRows = False
        dgv_ItemsMove.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = Color.White
        dgv_ItemsMove.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        dgv_ItemsMove.BackgroundColor = Color.FromArgb(CByte(163), CByte(223), CByte(187))
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(100), CByte(88), CByte(255))
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle2.ForeColor = Color.White
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        dgv_ItemsMove.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        dgv_ItemsMove.ColumnHeadersHeight = 30
        dgv_ItemsMove.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = Color.White
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle3.ForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        DataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        DataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.False
        dgv_ItemsMove.DefaultCellStyle = DataGridViewCellStyle3
        dgv_ItemsMove.Dock = DockStyle.Fill
        dgv_ItemsMove.GridColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        dgv_ItemsMove.Location = New Point(0, 0)
        dgv_ItemsMove.Name = "dgv_ItemsMove"
        dgv_ItemsMove.ReadOnly = True
        dgv_ItemsMove.RowHeadersVisible = False
        dgv_ItemsMove.Size = New Size(910, 511)
        dgv_ItemsMove.TabIndex = 3
        dgv_ItemsMove.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White
        dgv_ItemsMove.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        dgv_ItemsMove.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty
        dgv_ItemsMove.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty
        dgv_ItemsMove.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty
        dgv_ItemsMove.ThemeStyle.BackColor = Color.FromArgb(CByte(163), CByte(223), CByte(187))
        dgv_ItemsMove.ThemeStyle.GridColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        dgv_ItemsMove.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(CByte(100), CByte(88), CByte(255))
        dgv_ItemsMove.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None
        dgv_ItemsMove.ThemeStyle.HeaderStyle.Font = New Font("Segoe UI", 9F)
        dgv_ItemsMove.ThemeStyle.HeaderStyle.ForeColor = Color.White
        dgv_ItemsMove.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        dgv_ItemsMove.ThemeStyle.HeaderStyle.Height = 30
        dgv_ItemsMove.ThemeStyle.ReadOnly = True
        dgv_ItemsMove.ThemeStyle.RowsStyle.BackColor = Color.White
        dgv_ItemsMove.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgv_ItemsMove.ThemeStyle.RowsStyle.Font = New Font("Segoe UI", 9F)
        dgv_ItemsMove.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        dgv_ItemsMove.ThemeStyle.RowsStyle.Height = 25
        dgv_ItemsMove.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        dgv_ItemsMove.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        ' 
        ' frm_ShowDetailsMove
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        BackColor = Color.FromArgb(CByte(163), CByte(223), CByte(187))
        ClientSize = New Size(935, 562)
        Controls.Add(Guna2Panel1)
        Controls.Add(Guna2ControlBox1)
        FormBorderStyle = FormBorderStyle.None
        MaximizeBox = False
        MinimizeBox = False
        Name = "frm_ShowDetailsMove"
        StartPosition = FormStartPosition.CenterScreen
        Text = "frm_Items"
        Guna2Panel1.ResumeLayout(False)
        CType(dgv_ItemsMove, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Guna2ControlBox1 As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents dgv_ItemsMove As Guna.UI2.WinForms.Guna2DataGridView
End Class
