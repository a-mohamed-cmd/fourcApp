Imports System.Windows.Forms

Public Class GeneralForm

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles NewToolStripMenuItem.Click, NewWindowToolStripMenuItem.Click
        ' صفحه بطاقه الصنف
        frm_Items.MdiParent = Me
        frm_Items.Dock = DockStyle.Fill
        frm_Items.Txt_itemCode.Focus()
        frm_Items.Show()

    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles OpenToolStripMenuItem.Click
        'صفحه بطاقة الموردين
        frm_Supplier.MdiParent = Me
        frm_Supplier.Dock = DockStyle.Fill
        frm_Supplier.Txt_SupplierCode.Focus()
        frm_Supplier.Show()
    End Sub
    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        'صفحه بطاقة العملاء
        frm_Customers.MdiParent = Me
        frm_Customers.Dock = DockStyle.Fill
        frm_Customers.Txt_CustomerCode.Focus()
        frm_Customers.Show()
    End Sub

    Private Sub سندمشترياتToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles سندمشترياتToolStripMenuItem.Click
        'صفحه سند مشتريات
        frm_PurchaseReceipt.MdiParent = Me
        frm_PurchaseReceipt.Dock = DockStyle.Fill
        frm_PurchaseReceipt.Txt_PurchaseCode.Focus()
        frm_PurchaseReceipt.Show()
    End Sub
    Private Sub سندمبيعاتToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles سندمبيعاتToolStripMenuItem.Click
        'صفحه سند مبيعات
        frm_SallesReceipt.MdiParent = Me
        frm_SallesReceipt.Dock = DockStyle.Fill
        frm_SallesReceipt.Txt_SallesCode.Focus()
        frm_SallesReceipt.Show()
    End Sub

    Private Sub سندتحويلToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles سندتحويلToolStripMenuItem.Click
        'صفحه سند التحويلات
        frm_TransReceipt.MdiParent = Me
        frm_TransReceipt.Dock = DockStyle.Fill
        frm_TransReceipt.Txt_TransCode.Focus()
        frm_TransReceipt.Show()
    End Sub

    Private Sub سندإهـــلاكToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles سندإهـــلاكToolStripMenuItem.Click
        'صفحه سند إهلاك مخزني
        frm_DepreciationReceipt.MdiParent = Me
        frm_DepreciationReceipt.Dock = DockStyle.Fill
        frm_DepreciationReceipt.Txt_DepreciationCode.Focus()
        frm_DepreciationReceipt.Show()
    End Sub

    Private Sub RedoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RedoToolStripMenuItem.Click
        'صفحه سند مصروفات
        frm_Payments.MdiParent = Me
        frm_Payments.Dock = DockStyle.Fill

        frm_Payments.Txt_PaymentCode.Focus()
        frm_Payments.Show()
    End Sub
    Private Sub UndoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem.Click
        'صفحه شجره الحسابات
        frm_Accounts.MdiParent = Me
        frm_Accounts.Dock = DockStyle.Fill
        frm_Accounts.Grp_AccountGeneral.Focus()
        frm_Accounts.Txt_AccountGeneralCode.Focus()
        frm_Accounts.Show()
    End Sub
    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolBarToolStripMenuItem.Click
        'صفحه اداره المستخدمين
        frm_Users.MdiParent = Me
        frm_Users.Dock = DockStyle.Fill
        'frm_Users.Grp_AccountGeneral.Focus()
        frm_Users.Txt_UsersCode.Focus()
        frm_Users.Show()
    End Sub
    Private Sub تقاريرالمخازنToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles تقاريرالمخازنToolStripMenuItem.Click
        'صفحه  تقارير المخازن

        frm_Stores.MdiParent = Me
        frm_Stores.Dock = DockStyle.Fill
        frm_Stores.txt_ItemCode.Focus()
        frm_Stores.Show()
    End Sub
    Private Sub المخازنToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles المخازنToolStripMenuItem.Click
        'صفحه  المخازن
        frm_store.MdiParent = Me
        frm_store.Dock = DockStyle.Fill
        frm_store.txt_DepartmentCode.Focus()
        frm_store.Show()
    End Sub
    Private Sub الأقسامToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles الأقسامToolStripMenuItem.Click
        'صفحه  الأنــواع
        frm_Categorys.MdiParent = Me
        frm_Categorys.StartPosition = FormStartPosition.CenterScreen
        frm_Categorys.txt_DepartmentName.Focus()
        frm_Categorys.Show()
    End Sub
    Private Sub الوحــــــــداتToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles الوحــــــــداتToolStripMenuItem.Click
        'صفحه  الوحدات
        frm_Unit.MdiParent = Me
        frm_Unit.StartPosition = FormStartPosition.CenterScreen
        frm_Unit.txt_UnitName.Focus()
        frm_Unit.Show()
    End Sub
    'Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaveAsToolStripMenuItem.Click
    '    Dim SaveFileDialog As New SaveFileDialog
    '    SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
    '    SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

    '    If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
    '        Dim FileName As String = SaveFileDialog.FileName
    '        ' TODO: Add code here to save the current contents of the form to a file.
    '    End If
    'End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CutToolStripMenuItem.Click
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CopyToolStripMenuItem.Click
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PasteToolStripMenuItem.Click
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub



    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub Guna2ControlBox1_Click(sender As Object, e As EventArgs) Handles Guna2ControlBox1.Click
        End
    End Sub

    Private Sub GeneralForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Cls_Users.LoginVaidateType("اداره المستخدمين") = False Then
            ToolBarToolStripMenuItem.Enabled = False
        End If
    End Sub
End Class
