<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMstItemDet
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
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtItemID = New DevExpress.XtraEditors.TextEdit()
        Me.txtItemName = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.numBeginningPrice = New DevExpress.XtraEditors.SpinEdit()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.numSellingPrice = New DevExpress.XtraEditors.SpinEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.txtRemarks = New DevExpress.XtraEditors.MemoEdit()
        Me.ToolBar = New System.Windows.Forms.ToolBar()
        Me.BarSave = New System.Windows.Forms.ToolBarButton()
        Me.BarClose = New System.Windows.Forms.ToolBarButton()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.chkIsBarber = New System.Windows.Forms.CheckBox()
        Me.chkIsAdd = New System.Windows.Forms.CheckBox()
        Me.txtAltName = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.txtItemID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtItemName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numBeginningPrice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSellingPrice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRemarks.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.txtAltName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(17, 24)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Item ID"
        '
        'txtItemID
        '
        Me.txtItemID.Location = New System.Drawing.Point(112, 21)
        Me.txtItemID.Name = "txtItemID"
        Me.txtItemID.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtItemID.Properties.Appearance.Options.UseBackColor = True
        Me.txtItemID.Properties.ReadOnly = True
        Me.txtItemID.Size = New System.Drawing.Size(90, 20)
        Me.txtItemID.TabIndex = 1
        Me.txtItemID.TabStop = False
        '
        'txtItemName
        '
        Me.txtItemName.Location = New System.Drawing.Point(112, 47)
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemName.Size = New System.Drawing.Size(220, 20)
        Me.txtItemName.TabIndex = 3
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(17, 51)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(52, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Item Name"
        '
        'numBeginningPrice
        '
        Me.numBeginningPrice.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numBeginningPrice.Location = New System.Drawing.Point(112, 102)
        Me.numBeginningPrice.Name = "numBeginningPrice"
        Me.numBeginningPrice.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.numBeginningPrice.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.[Default]
        Me.numBeginningPrice.Properties.IsFloatValue = False
        Me.numBeginningPrice.Properties.Mask.EditMask = "N00"
        Me.numBeginningPrice.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.numBeginningPrice.Properties.MaxValue = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.numBeginningPrice.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numBeginningPrice.Size = New System.Drawing.Size(100, 20)
        Me.numBeginningPrice.TabIndex = 4
        '
        'LabelControl9
        '
        Me.LabelControl9.Location = New System.Drawing.Point(17, 105)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(72, 13)
        Me.LabelControl9.TabIndex = 49
        Me.LabelControl9.Text = "Beginning Price"
        '
        'numSellingPrice
        '
        Me.numSellingPrice.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numSellingPrice.Location = New System.Drawing.Point(112, 130)
        Me.numSellingPrice.Name = "numSellingPrice"
        Me.numSellingPrice.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.numSellingPrice.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.[Default]
        Me.numSellingPrice.Properties.IsFloatValue = False
        Me.numSellingPrice.Properties.Mask.EditMask = "N00"
        Me.numSellingPrice.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.numSellingPrice.Properties.MaxValue = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.numSellingPrice.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numSellingPrice.Size = New System.Drawing.Size(100, 20)
        Me.numSellingPrice.TabIndex = 5
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(17, 133)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(56, 13)
        Me.LabelControl3.TabIndex = 51
        Me.LabelControl3.Text = "Selling Price"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(17, 161)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(41, 13)
        Me.LabelControl4.TabIndex = 53
        Me.LabelControl4.Text = "Remarks"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(112, 159)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemarks.Size = New System.Drawing.Size(218, 64)
        Me.txtRemarks.TabIndex = 6
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
        Me.ToolBar.Size = New System.Drawing.Size(357, 28)
        Me.ToolBar.TabIndex = 55
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
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.txtAltName)
        Me.PanelControl1.Controls.Add(Me.LabelControl5)
        Me.PanelControl1.Controls.Add(Me.chkIsAdd)
        Me.PanelControl1.Controls.Add(Me.chkIsBarber)
        Me.PanelControl1.Controls.Add(Me.txtItemID)
        Me.PanelControl1.Controls.Add(Me.txtRemarks)
        Me.PanelControl1.Controls.Add(Me.LabelControl9)
        Me.PanelControl1.Controls.Add(Me.LabelControl4)
        Me.PanelControl1.Controls.Add(Me.numBeginningPrice)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.txtItemName)
        Me.PanelControl1.Controls.Add(Me.numSellingPrice)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl1.Location = New System.Drawing.Point(0, 28)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(357, 259)
        Me.PanelControl1.TabIndex = 57
        '
        'chkIsBarber
        '
        Me.chkIsBarber.AutoSize = True
        Me.chkIsBarber.Location = New System.Drawing.Point(112, 238)
        Me.chkIsBarber.Name = "chkIsBarber"
        Me.chkIsBarber.Size = New System.Drawing.Size(70, 17)
        Me.chkIsBarber.TabIndex = 7
        Me.chkIsBarber.Text = "Is Barber"
        Me.chkIsBarber.UseVisualStyleBackColor = True
        '
        'chkIsAdd
        '
        Me.chkIsAdd.AutoSize = True
        Me.chkIsAdd.Location = New System.Drawing.Point(188, 238)
        Me.chkIsAdd.Name = "chkIsAdd"
        Me.chkIsAdd.Size = New System.Drawing.Size(57, 17)
        Me.chkIsAdd.TabIndex = 54
        Me.chkIsAdd.Text = "Is Add"
        Me.chkIsAdd.UseVisualStyleBackColor = True
        '
        'txtAltName
        '
        Me.txtAltName.Location = New System.Drawing.Point(112, 73)
        Me.txtAltName.Name = "txtAltName"
        Me.txtAltName.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAltName.Size = New System.Drawing.Size(90, 20)
        Me.txtAltName.TabIndex = 56
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(17, 76)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(43, 13)
        Me.LabelControl5.TabIndex = 55
        Me.LabelControl5.Text = "Alt Name"
        '
        'frmMstItemDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(357, 287)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.ToolBar)
        Me.Name = "frmMstItemDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Item Detail"
        CType(Me.txtItemID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtItemName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numBeginningPrice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSellingPrice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRemarks.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.txtAltName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtItemID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtItemName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents numBeginningPrice As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents numSellingPrice As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtRemarks As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents ToolBar As System.Windows.Forms.ToolBar
    Friend WithEvents BarSave As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarClose As System.Windows.Forms.ToolBarButton
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents chkIsBarber As System.Windows.Forms.CheckBox
    Friend WithEvents txtAltName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkIsAdd As System.Windows.Forms.CheckBox
End Class
