<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMstItem
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ToolBar = New System.Windows.Forms.ToolBar()
        Me.BarNew = New System.Windows.Forms.ToolBarButton()
        Me.BarDetail = New System.Windows.Forms.ToolBarButton()
        Me.BarDelete = New System.Windows.Forms.ToolBarButton()
        Me.BarSep1 = New System.Windows.Forms.ToolBarButton()
        Me.BarRefresh = New System.Windows.Forms.ToolBarButton()
        Me.pnlBrowse = New System.Windows.Forms.Panel()
        Me.cbStatus = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.btnExecute = New DevExpress.XtraEditors.SimpleButton()
        Me.grdMain = New DevExpress.XtraGrid.GridControl()
        Me.grdView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlBrowse.SuspendLayout()
        CType(Me.cbStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolBar
        '
        Me.ToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBar.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarNew, Me.BarDetail, Me.BarDelete, Me.BarSep1, Me.BarRefresh})
        Me.ToolBar.DropDownArrows = True
        Me.ToolBar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolBar.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar.Name = "ToolBar"
        Me.ToolBar.ShowToolTips = True
        Me.ToolBar.Size = New System.Drawing.Size(703, 28)
        Me.ToolBar.TabIndex = 4
        Me.ToolBar.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
        '
        'BarNew
        '
        Me.BarNew.Name = "BarNew"
        Me.BarNew.Text = "New"
        '
        'BarDetail
        '
        Me.BarDetail.Name = "BarDetail"
        Me.BarDetail.Text = "Detail"
        '
        'BarDelete
        '
        Me.BarDelete.Name = "BarDelete"
        Me.BarDelete.Text = "Delete"
        '
        'BarSep1
        '
        Me.BarSep1.Name = "BarSep1"
        Me.BarSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'BarRefresh
        '
        Me.BarRefresh.Name = "BarRefresh"
        Me.BarRefresh.Text = "Refresh"
        '
        'pnlBrowse
        '
        Me.pnlBrowse.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlBrowse.Controls.Add(Me.cbStatus)
        Me.pnlBrowse.Controls.Add(Me.LabelControl1)
        Me.pnlBrowse.Controls.Add(Me.btnExecute)
        Me.pnlBrowse.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBrowse.Location = New System.Drawing.Point(0, 28)
        Me.pnlBrowse.Name = "pnlBrowse"
        Me.pnlBrowse.Size = New System.Drawing.Size(703, 89)
        Me.pnlBrowse.TabIndex = 5
        '
        'cbStatus
        '
        Me.cbStatus.EditValue = "ACTIVE"
        Me.cbStatus.Location = New System.Drawing.Point(97, 21)
        Me.cbStatus.Name = "cbStatus"
        Me.cbStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbStatus.Properties.Items.AddRange(New Object() {"ACTIVE", "DELETED", "ALL"})
        Me.cbStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cbStatus.Size = New System.Drawing.Size(100, 20)
        Me.cbStatus.TabIndex = 47
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(34, 24)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl1.TabIndex = 46
        Me.LabelControl1.Text = "Status"
        '
        'btnExecute
        '
        Me.btnExecute.Location = New System.Drawing.Point(203, 47)
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(63, 21)
        Me.btnExecute.TabIndex = 24
        Me.btnExecute.Text = "Execute"
        '
        'grdMain
        '
        Me.grdMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdMain.EmbeddedNavigator.Buttons.Append.Enabled = False
        Me.grdMain.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.grdMain.EmbeddedNavigator.Buttons.CancelEdit.Enabled = False
        Me.grdMain.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.grdMain.EmbeddedNavigator.Buttons.Edit.Enabled = False
        Me.grdMain.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.grdMain.EmbeddedNavigator.Buttons.EndEdit.Enabled = False
        Me.grdMain.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.grdMain.EmbeddedNavigator.Buttons.NextPage.Enabled = False
        Me.grdMain.EmbeddedNavigator.Buttons.NextPage.Visible = False
        Me.grdMain.EmbeddedNavigator.Buttons.PrevPage.Enabled = False
        Me.grdMain.EmbeddedNavigator.Buttons.PrevPage.Visible = False
        Me.grdMain.EmbeddedNavigator.Buttons.Remove.Enabled = False
        Me.grdMain.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.grdMain.Location = New System.Drawing.Point(0, 117)
        Me.grdMain.MainView = Me.grdView
        Me.grdMain.Name = "grdMain"
        Me.grdMain.Size = New System.Drawing.Size(703, 263)
        Me.grdMain.TabIndex = 6
        Me.grdMain.UseEmbeddedNavigator = True
        Me.grdMain.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdView})
        '
        'grdView
        '
        Me.grdView.GridControl = Me.grdMain
        Me.grdView.Name = "grdView"
        Me.grdView.OptionsView.ColumnAutoWidth = False
        Me.grdView.OptionsView.ShowAutoFilterRow = True
        Me.grdView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        '
        'frmMstItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(703, 380)
        Me.Controls.Add(Me.grdMain)
        Me.Controls.Add(Me.pnlBrowse)
        Me.Controls.Add(Me.ToolBar)
        Me.Name = "frmMstItem"
        Me.Text = "Master Item"
        Me.pnlBrowse.ResumeLayout(False)
        Me.pnlBrowse.PerformLayout()
        CType(Me.cbStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdMain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolBar As System.Windows.Forms.ToolBar
    Friend WithEvents BarNew As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarDetail As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarDelete As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarSep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarRefresh As System.Windows.Forms.ToolBarButton
    Friend WithEvents pnlBrowse As System.Windows.Forms.Panel
    Friend WithEvents btnExecute As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grdMain As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cbStatus As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
End Class
