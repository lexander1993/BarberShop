<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMstUserGroupDet
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.gbDetail = New System.Windows.Forms.GroupBox()
        Me.chkAll = New System.Windows.Forms.CheckBox()
        Me.pnlDetail = New System.Windows.Forms.Panel()
        Me.grdMenu = New DevExpress.XtraGrid.GridControl()
        Me.grdItemView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtUserGroupID = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripEmpty = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripCreatedDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripModifiedDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblHead = New System.Windows.Forms.Label()
        Me.ToolBar = New System.Windows.Forms.ToolBar()
        Me.BarSave = New System.Windows.Forms.ToolBarButton()
        Me.BarClose = New System.Windows.Forms.ToolBarButton()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gbDetail.SuspendLayout()
        Me.pnlDetail.SuspendLayout()
        CType(Me.grdMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdItemView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbDetail
        '
        Me.gbDetail.Controls.Add(Me.chkAll)
        Me.gbDetail.Controls.Add(Me.pnlDetail)
        Me.gbDetail.Controls.Add(Me.Panel2)
        Me.gbDetail.Controls.Add(Me.Label7)
        Me.gbDetail.Controls.Add(Me.StatusStrip)
        Me.gbDetail.Controls.Add(Me.lblHead)
        Me.gbDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbDetail.Location = New System.Drawing.Point(0, 28)
        Me.gbDetail.Name = "gbDetail"
        Me.gbDetail.Size = New System.Drawing.Size(614, 687)
        Me.gbDetail.TabIndex = 3
        Me.gbDetail.TabStop = False
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        Me.chkAll.Location = New System.Drawing.Point(28, 203)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(69, 17)
        Me.chkAll.TabIndex = 150
        Me.chkAll.Text = "Check All"
        Me.chkAll.UseVisualStyleBackColor = True
        '
        'pnlDetail
        '
        Me.pnlDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlDetail.Controls.Add(Me.grdMenu)
        Me.pnlDetail.Location = New System.Drawing.Point(9, 225)
        Me.pnlDetail.Name = "pnlDetail"
        Me.pnlDetail.Size = New System.Drawing.Size(595, 434)
        Me.pnlDetail.TabIndex = 149
        '
        'grdMenu
        '
        Me.grdMenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdMenu.EmbeddedNavigator.Buttons.Append.Enabled = False
        Me.grdMenu.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.grdMenu.EmbeddedNavigator.Buttons.CancelEdit.Enabled = False
        Me.grdMenu.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.grdMenu.EmbeddedNavigator.Buttons.Edit.Enabled = False
        Me.grdMenu.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.grdMenu.EmbeddedNavigator.Buttons.EndEdit.Enabled = False
        Me.grdMenu.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.grdMenu.EmbeddedNavigator.Buttons.NextPage.Enabled = False
        Me.grdMenu.EmbeddedNavigator.Buttons.NextPage.Visible = False
        Me.grdMenu.EmbeddedNavigator.Buttons.PrevPage.Enabled = False
        Me.grdMenu.EmbeddedNavigator.Buttons.PrevPage.Visible = False
        Me.grdMenu.EmbeddedNavigator.Buttons.Remove.Enabled = False
        Me.grdMenu.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.grdMenu.Location = New System.Drawing.Point(0, 0)
        Me.grdMenu.MainView = Me.grdItemView
        Me.grdMenu.Name = "grdMenu"
        Me.grdMenu.Size = New System.Drawing.Size(595, 434)
        Me.grdMenu.TabIndex = 3
        Me.grdMenu.UseEmbeddedNavigator = True
        Me.grdMenu.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdItemView})
        '
        'grdItemView
        '
        Me.grdItemView.DetailHeight = 150
        Me.grdItemView.GridControl = Me.grdMenu
        Me.grdItemView.Name = "grdItemView"
        Me.grdItemView.OptionsCustomization.AllowColumnMoving = False
        Me.grdItemView.OptionsCustomization.AllowGroup = False
        Me.grdItemView.OptionsView.ColumnAutoWidth = False
        Me.grdItemView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.grdItemView.OptionsView.ShowGroupPanel = False
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.txtRemarks)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.txtUserGroupID)
        Me.Panel2.Location = New System.Drawing.Point(8, 41)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(603, 133)
        Me.Panel2.TabIndex = 148
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(15, 44)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(48, 13)
        Me.Label16.TabIndex = 146
        Me.Label16.Text = "Remarks"
        '
        'txtRemarks
        '
        Me.txtRemarks.BackColor = System.Drawing.Color.Azure
        Me.txtRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemarks.Location = New System.Drawing.Point(145, 44)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRemarks.Size = New System.Drawing.Size(447, 76)
        Me.txtRemarks.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 13)
        Me.Label3.TabIndex = 110
        Me.Label3.Text = "User Group ID"
        '
        'txtUserGroupID
        '
        Me.txtUserGroupID.BackColor = System.Drawing.SystemColors.Window
        Me.txtUserGroupID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUserGroupID.Location = New System.Drawing.Point(145, 12)
        Me.txtUserGroupID.MaxLength = 200
        Me.txtUserGroupID.Name = "txtUserGroupID"
        Me.txtUserGroupID.Size = New System.Drawing.Size(447, 21)
        Me.txtUserGroupID.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.BackColor = System.Drawing.Color.CadetBlue
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(5, 177)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(659, 22)
        Me.Label7.TabIndex = 141
        Me.Label7.Text = "« User Menu Access Right"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'StatusStrip
        '
        Me.StatusStrip.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripEmpty, Me.ToolStripStatusLabel3, Me.ToolStripCreatedDate, Me.ToolStripModifiedDate})
        Me.StatusStrip.Location = New System.Drawing.Point(3, 662)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(608, 22)
        Me.StatusStrip.TabIndex = 118
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'ToolStripEmpty
        '
        Me.ToolStripEmpty.Name = "ToolStripEmpty"
        Me.ToolStripEmpty.Size = New System.Drawing.Size(593, 17)
        Me.ToolStripEmpty.Spring = True
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripCreatedDate
        '
        Me.ToolStripCreatedDate.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ToolStripCreatedDate.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripCreatedDate.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.ToolStripCreatedDate.Name = "ToolStripCreatedDate"
        Me.ToolStripCreatedDate.Size = New System.Drawing.Size(74, 17)
        Me.ToolStripCreatedDate.Text = "Created Date : "
        Me.ToolStripCreatedDate.Visible = False
        '
        'ToolStripModifiedDate
        '
        Me.ToolStripModifiedDate.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ToolStripModifiedDate.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripModifiedDate.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.ToolStripModifiedDate.Name = "ToolStripModifiedDate"
        Me.ToolStripModifiedDate.Size = New System.Drawing.Size(73, 17)
        Me.ToolStripModifiedDate.Text = "Modified Date :"
        Me.ToolStripModifiedDate.Visible = False
        '
        'lblHead
        '
        Me.lblHead.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblHead.BackColor = System.Drawing.Color.CadetBlue
        Me.lblHead.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHead.ForeColor = System.Drawing.Color.White
        Me.lblHead.Location = New System.Drawing.Point(8, 16)
        Me.lblHead.Name = "lblHead"
        Me.lblHead.Size = New System.Drawing.Size(659, 22)
        Me.lblHead.TabIndex = 0
        Me.lblHead.Text = "« User Group Detail"
        Me.lblHead.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolBar
        '
        Me.ToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBar.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarSave, Me.BarClose})
        Me.ToolBar.DropDownArrows = True
        Me.ToolBar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolBar.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar.Name = "ToolBar"
        Me.ToolBar.ShowToolTips = True
        Me.ToolBar.Size = New System.Drawing.Size(614, 28)
        Me.ToolBar.TabIndex = 2
        Me.ToolBar.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
        '
        'BarSave
        '
        Me.BarSave.Name = "BarSave"
        Me.BarSave.Text = "Save"
        '
        'BarClose
        '
        Me.BarClose.Name = "BarClose"
        Me.BarClose.Text = "Close"
        '
        'GridView1
        '
        Me.GridView1.Name = "GridView1"
        '
        'GridView2
        '
        Me.GridView2.Name = "GridView2"
        '
        'frmMstUserGroupDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(614, 715)
        Me.Controls.Add(Me.gbDetail)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmMstUserGroupDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Master User Group Detail"
        Me.gbDetail.ResumeLayout(False)
        Me.gbDetail.PerformLayout()
        Me.pnlDetail.ResumeLayout(False)
        CType(Me.grdMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdItemView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbDetail As System.Windows.Forms.GroupBox
    Friend WithEvents lblHead As System.Windows.Forms.Label
    Friend WithEvents ToolBar As System.Windows.Forms.ToolBar
    Friend WithEvents BarSave As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarClose As System.Windows.Forms.ToolBarButton
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents txtUserGroupID As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripEmpty As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripCreatedDate As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripModifiedDate As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents chkAll As System.Windows.Forms.CheckBox
    Friend WithEvents pnlDetail As System.Windows.Forms.Panel
    Friend WithEvents grdMenu As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdItemView As DevExpress.XtraGrid.Views.Grid.GridView
End Class
