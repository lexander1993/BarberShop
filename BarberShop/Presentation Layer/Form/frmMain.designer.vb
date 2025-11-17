<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MenuStrip()
        Me.mnuMaster = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserGroupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaction = New System.Windows.Forms.ToolStripMenuItem()
        Me.PaymentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHQReports = New System.Windows.Forms.ToolStripMenuItem()
        Me.StylistFeeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProfitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTools = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuToolsLogOut = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuToolsChangePassword = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuWindows = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuWindowsTileVertical = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuWindowsTileHorizontal = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuWindowsCascade = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuWindowsSep1 = New System.Windows.Forms.ToolStripSeparator()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblUserID = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblCompany = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TimerNotification = New System.Windows.Forms.Timer(Me.components)
        Me.ProfitNewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMain.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuMain
        '
        Me.mnuMain.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.mnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMaster, Me.mnuTransaction, Me.mnuHQReports, Me.mnuTools, Me.mnuWindows})
        Me.mnuMain.Location = New System.Drawing.Point(0, 0)
        Me.mnuMain.MdiWindowListItem = Me.mnuWindows
        Me.mnuMain.Name = "mnuMain"
        Me.mnuMain.Size = New System.Drawing.Size(882, 28)
        Me.mnuMain.TabIndex = 1
        Me.mnuMain.Text = "mnuMain"
        '
        'mnuMaster
        '
        Me.mnuMaster.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UserToolStripMenuItem, Me.UserGroupToolStripMenuItem, Me.ItemToolStripMenuItem})
        Me.mnuMaster.Name = "mnuMaster"
        Me.mnuMaster.Size = New System.Drawing.Size(68, 24)
        Me.mnuMaster.Text = "&Master"
        '
        'UserToolStripMenuItem
        '
        Me.UserToolStripMenuItem.Name = "UserToolStripMenuItem"
        Me.UserToolStripMenuItem.Size = New System.Drawing.Size(166, 26)
        Me.UserToolStripMenuItem.Text = "User"
        '
        'UserGroupToolStripMenuItem
        '
        Me.UserGroupToolStripMenuItem.Name = "UserGroupToolStripMenuItem"
        Me.UserGroupToolStripMenuItem.Size = New System.Drawing.Size(166, 26)
        Me.UserGroupToolStripMenuItem.Text = "User Group"
        '
        'ItemToolStripMenuItem
        '
        Me.ItemToolStripMenuItem.Name = "ItemToolStripMenuItem"
        Me.ItemToolStripMenuItem.Size = New System.Drawing.Size(166, 26)
        Me.ItemToolStripMenuItem.Text = "Item"
        '
        'mnuTransaction
        '
        Me.mnuTransaction.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PaymentToolStripMenuItem})
        Me.mnuTransaction.Name = "mnuTransaction"
        Me.mnuTransaction.Size = New System.Drawing.Size(98, 24)
        Me.mnuTransaction.Text = "&Transaction"
        '
        'PaymentToolStripMenuItem
        '
        Me.PaymentToolStripMenuItem.Name = "PaymentToolStripMenuItem"
        Me.PaymentToolStripMenuItem.Size = New System.Drawing.Size(148, 26)
        Me.PaymentToolStripMenuItem.Text = "Payment"
        '
        'mnuHQReports
        '
        Me.mnuHQReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StylistFeeToolStripMenuItem, Me.ProfitToolStripMenuItem, Me.ProfitNewToolStripMenuItem})
        Me.mnuHQReports.Name = "mnuHQReports"
        Me.mnuHQReports.Size = New System.Drawing.Size(74, 24)
        Me.mnuHQReports.Text = "&Reports"
        '
        'StylistFeeToolStripMenuItem
        '
        Me.StylistFeeToolStripMenuItem.Name = "StylistFeeToolStripMenuItem"
        Me.StylistFeeToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.StylistFeeToolStripMenuItem.Text = "Stylist Fee"
        '
        'ProfitToolStripMenuItem
        '
        Me.ProfitToolStripMenuItem.Name = "ProfitToolStripMenuItem"
        Me.ProfitToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.ProfitToolStripMenuItem.Text = "Profit"
        '
        'mnuTools
        '
        Me.mnuTools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuToolsLogOut, Me.mnuToolsChangePassword})
        Me.mnuTools.Name = "mnuTools"
        Me.mnuTools.Size = New System.Drawing.Size(58, 24)
        Me.mnuTools.Text = "T&ools"
        '
        'mnuToolsLogOut
        '
        Me.mnuToolsLogOut.Name = "mnuToolsLogOut"
        Me.mnuToolsLogOut.Size = New System.Drawing.Size(207, 26)
        Me.mnuToolsLogOut.Text = "Log Out"
        '
        'mnuToolsChangePassword
        '
        Me.mnuToolsChangePassword.Name = "mnuToolsChangePassword"
        Me.mnuToolsChangePassword.Size = New System.Drawing.Size(207, 26)
        Me.mnuToolsChangePassword.Text = "Change Password"
        '
        'mnuWindows
        '
        Me.mnuWindows.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuWindowsTileVertical, Me.mnuWindowsTileHorizontal, Me.mnuWindowsCascade, Me.mnuWindowsSep1})
        Me.mnuWindows.Name = "mnuWindows"
        Me.mnuWindows.Size = New System.Drawing.Size(84, 24)
        Me.mnuWindows.Text = "&Windows"
        '
        'mnuWindowsTileVertical
        '
        Me.mnuWindowsTileVertical.Name = "mnuWindowsTileVertical"
        Me.mnuWindowsTileVertical.Size = New System.Drawing.Size(190, 26)
        Me.mnuWindowsTileVertical.Text = "Tile Vertical"
        '
        'mnuWindowsTileHorizontal
        '
        Me.mnuWindowsTileHorizontal.Name = "mnuWindowsTileHorizontal"
        Me.mnuWindowsTileHorizontal.Size = New System.Drawing.Size(190, 26)
        Me.mnuWindowsTileHorizontal.Text = "Tile Horizontal"
        '
        'mnuWindowsCascade
        '
        Me.mnuWindowsCascade.Name = "mnuWindowsCascade"
        Me.mnuWindowsCascade.Size = New System.Drawing.Size(190, 26)
        Me.mnuWindowsCascade.Text = "Cascade"
        '
        'mnuWindowsSep1
        '
        Me.mnuWindowsSep1.Name = "mnuWindowsSep1"
        Me.mnuWindowsSep1.Size = New System.Drawing.Size(187, 6)
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblUserID, Me.lblCompany})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 637)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(882, 27)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblUserID
        '
        Me.lblUserID.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.lblUserID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserID.ForeColor = System.Drawing.Color.Teal
        Me.lblUserID.Name = "lblUserID"
        Me.lblUserID.Size = New System.Drawing.Size(60, 21)
        Me.lblUserID.Text = "UserID"
        '
        'lblCompany
        '
        Me.lblCompany.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.lblCompany.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompany.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblCompany.Name = "lblCompany"
        Me.lblCompany.Size = New System.Drawing.Size(78, 21)
        Me.lblCompany.Text = "Company"
        '
        'TimerNotification
        '
        Me.TimerNotification.Enabled = True
        Me.TimerNotification.Interval = 30000
        '
        'ProfitNewToolStripMenuItem
        '
        Me.ProfitNewToolStripMenuItem.Name = "ProfitNewToolStripMenuItem"
        Me.ProfitNewToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.ProfitNewToolStripMenuItem.Text = "Profit New"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(882, 664)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.mnuMain)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.mnuMain
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Barber Shop"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.mnuMain.ResumeLayout(False)
        Me.mnuMain.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mnuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHQReports As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTools As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuWindows As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuWindowsTileVertical As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuWindowsTileHorizontal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuWindowsCascade As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuWindowsSep1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuToolsLogOut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuToolsChangePassword As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblUserID As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblCompany As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TimerNotification As System.Windows.Forms.Timer
    Friend WithEvents mnuTransaction As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UserToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UserGroupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PaymentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StylistFeeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProfitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProfitNewToolStripMenuItem As ToolStripMenuItem
End Class
