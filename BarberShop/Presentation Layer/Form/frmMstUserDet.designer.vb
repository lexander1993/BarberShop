<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMstUserDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMstUserDet))
        Me.gbDetail = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtJabatan = New System.Windows.Forms.ComboBox()
        Me.btnUserGroupID = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtUserGroupID = New System.Windows.Forms.TextBox()
        Me.txtTglLahirStr = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtNoHp = New System.Windows.Forms.TextBox()
        Me.cboIsActive = New System.Windows.Forms.ComboBox()
        Me.dtpStartWorkingDate = New System.Windows.Forms.DateTimePicker()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNoNPWP = New System.Windows.Forms.TextBox()
        Me.lblPekerjaan = New System.Windows.Forms.Label()
        Me.txtJamsostekID = New System.Windows.Forms.TextBox()
        Me.cboJenisID = New System.Windows.Forms.ComboBox()
        Me.txtAlamat = New System.Windows.Forms.TextBox()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtpTglLahir = New System.Windows.Forms.DateTimePicker()
        Me.txtUserID = New System.Windows.Forms.TextBox()
        Me.txtNoID = New System.Windows.Forms.TextBox()
        Me.txtTempatLahir = New System.Windows.Forms.TextBox()
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
        Me.Panel2.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbDetail
        '
        Me.gbDetail.Controls.Add(Me.Panel2)
        Me.gbDetail.Controls.Add(Me.StatusStrip)
        Me.gbDetail.Controls.Add(Me.lblHead)
        Me.gbDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbDetail.Location = New System.Drawing.Point(0, 28)
        Me.gbDetail.Name = "gbDetail"
        Me.gbDetail.Size = New System.Drawing.Size(557, 549)
        Me.gbDetail.TabIndex = 3
        Me.gbDetail.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.txtJabatan)
        Me.Panel2.Controls.Add(Me.btnUserGroupID)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.txtUserGroupID)
        Me.Panel2.Controls.Add(Me.txtTglLahirStr)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.txtNoHp)
        Me.Panel2.Controls.Add(Me.cboIsActive)
        Me.Panel2.Controls.Add(Me.dtpStartWorkingDate)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.txtNoNPWP)
        Me.Panel2.Controls.Add(Me.lblPekerjaan)
        Me.Panel2.Controls.Add(Me.txtJamsostekID)
        Me.Panel2.Controls.Add(Me.cboJenisID)
        Me.Panel2.Controls.Add(Me.txtAlamat)
        Me.Panel2.Controls.Add(Me.txtUserName)
        Me.Panel2.Controls.Add(Me.txtRemarks)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.dtpTglLahir)
        Me.Panel2.Controls.Add(Me.txtUserID)
        Me.Panel2.Controls.Add(Me.txtNoID)
        Me.Panel2.Controls.Add(Me.txtTempatLahir)
        Me.Panel2.Location = New System.Drawing.Point(8, 41)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(546, 474)
        Me.Panel2.TabIndex = 148
        '
        'txtJabatan
        '
        Me.txtJabatan.FormattingEnabled = True
        Me.txtJabatan.Items.AddRange(New Object() {"STYLIST", "KASIR" & Global.Microsoft.VisualBasic.ChrW(9), "OWNER"})
        Me.txtJabatan.Location = New System.Drawing.Point(193, 95)
        Me.txtJabatan.Name = "txtJabatan"
        Me.txtJabatan.Size = New System.Drawing.Size(121, 21)
        Me.txtJabatan.TabIndex = 10
        '
        'btnUserGroupID
        '
        Me.btnUserGroupID.BackColor = System.Drawing.Color.Transparent
        Me.btnUserGroupID.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUserGroupID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUserGroupID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUserGroupID.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnUserGroupID.Image = CType(resources.GetObject("btnUserGroupID.Image"), System.Drawing.Image)
        Me.btnUserGroupID.Location = New System.Drawing.Point(402, 67)
        Me.btnUserGroupID.Name = "btnUserGroupID"
        Me.btnUserGroupID.Size = New System.Drawing.Size(19, 20)
        Me.btnUserGroupID.TabIndex = 146
        Me.btnUserGroupID.TabStop = False
        Me.btnUserGroupID.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 71)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 13)
        Me.Label6.TabIndex = 148
        Me.Label6.Text = "User Group ID"
        '
        'txtUserGroupID
        '
        Me.txtUserGroupID.BackColor = System.Drawing.SystemColors.Window
        Me.txtUserGroupID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUserGroupID.Location = New System.Drawing.Point(193, 68)
        Me.txtUserGroupID.Name = "txtUserGroupID"
        Me.txtUserGroupID.ReadOnly = True
        Me.txtUserGroupID.Size = New System.Drawing.Size(204, 21)
        Me.txtUserGroupID.TabIndex = 3
        '
        'txtTglLahirStr
        '
        Me.txtTglLahirStr.Location = New System.Drawing.Point(403, 149)
        Me.txtTglLahirStr.Name = "txtTglLahirStr"
        Me.txtTglLahirStr.Size = New System.Drawing.Size(25, 21)
        Me.txtTglLahirStr.TabIndex = 7
        Me.txtTglLahirStr.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(18, 268)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 13)
        Me.Label10.TabIndex = 132
        Me.Label10.Text = "No Hp"
        '
        'txtNoHp
        '
        Me.txtNoHp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNoHp.Location = New System.Drawing.Point(193, 265)
        Me.txtNoHp.Name = "txtNoHp"
        Me.txtNoHp.Size = New System.Drawing.Size(204, 21)
        Me.txtNoHp.TabIndex = 9
        '
        'cboIsActive
        '
        Me.cboIsActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboIsActive.FormattingEnabled = True
        Me.cboIsActive.Items.AddRange(New Object() {"NOT ACTIVE", "ACTIVE"})
        Me.cboIsActive.Location = New System.Drawing.Point(193, 322)
        Me.cboIsActive.Name = "cboIsActive"
        Me.cboIsActive.Size = New System.Drawing.Size(99, 21)
        Me.cboIsActive.TabIndex = 12
        '
        'dtpStartWorkingDate
        '
        Me.dtpStartWorkingDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpStartWorkingDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpStartWorkingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartWorkingDate.Location = New System.Drawing.Point(193, 292)
        Me.dtpStartWorkingDate.Name = "dtpStartWorkingDate"
        Me.dtpStartWorkingDate.Size = New System.Drawing.Size(99, 21)
        Me.dtpStartWorkingDate.TabIndex = 11
        Me.dtpStartWorkingDate.Value = New Date(2014, 9, 16, 0, 0, 0, 0)
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(18, 353)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(48, 13)
        Me.Label16.TabIndex = 146
        Me.Label16.Text = "Remarks"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 295)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 13)
        Me.Label2.TabIndex = 136
        Me.Label2.Text = "Mulai Bekerja Sejak"
        '
        'txtNoNPWP
        '
        Me.txtNoNPWP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNoNPWP.Location = New System.Drawing.Point(434, 149)
        Me.txtNoNPWP.Name = "txtNoNPWP"
        Me.txtNoNPWP.Size = New System.Drawing.Size(19, 21)
        Me.txtNoNPWP.TabIndex = 8
        Me.txtNoNPWP.Visible = False
        '
        'lblPekerjaan
        '
        Me.lblPekerjaan.AutoSize = True
        Me.lblPekerjaan.Location = New System.Drawing.Point(15, 98)
        Me.lblPekerjaan.Name = "lblPekerjaan"
        Me.lblPekerjaan.Size = New System.Drawing.Size(46, 13)
        Me.lblPekerjaan.TabIndex = 134
        Me.lblPekerjaan.Text = "Jabatan"
        '
        'txtJamsostekID
        '
        Me.txtJamsostekID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtJamsostekID.Location = New System.Drawing.Point(459, 149)
        Me.txtJamsostekID.Name = "txtJamsostekID"
        Me.txtJamsostekID.Size = New System.Drawing.Size(19, 21)
        Me.txtJamsostekID.TabIndex = 9
        Me.txtJamsostekID.Visible = False
        '
        'cboJenisID
        '
        Me.cboJenisID.FormattingEnabled = True
        Me.cboJenisID.Items.AddRange(New Object() {"KTP", "SIM", "PASPOR"})
        Me.cboJenisID.Location = New System.Drawing.Point(193, 122)
        Me.cboJenisID.Name = "cboJenisID"
        Me.cboJenisID.Size = New System.Drawing.Size(110, 21)
        Me.cboJenisID.TabIndex = 4
        '
        'txtAlamat
        '
        Me.txtAlamat.Location = New System.Drawing.Point(193, 203)
        Me.txtAlamat.Multiline = True
        Me.txtAlamat.Name = "txtAlamat"
        Me.txtAlamat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAlamat.Size = New System.Drawing.Size(302, 56)
        Me.txtAlamat.TabIndex = 8
        '
        'txtUserName
        '
        Me.txtUserName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUserName.Location = New System.Drawing.Point(193, 39)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(240, 21)
        Me.txtUserName.TabIndex = 2
        '
        'txtRemarks
        '
        Me.txtRemarks.BackColor = System.Drawing.Color.Azure
        Me.txtRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemarks.Location = New System.Drawing.Point(193, 355)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRemarks.Size = New System.Drawing.Size(319, 101)
        Me.txtRemarks.TabIndex = 13
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(15, 127)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 13)
        Me.Label12.TabIndex = 129
        Me.Label12.Text = "Jenis Identitas"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(18, 323)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 13)
        Me.Label8.TabIndex = 117
        Me.Label8.Text = "Is Active"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(14, 203)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(40, 13)
        Me.Label14.TabIndex = 123
        Me.Label14.Text = "Alamat"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 111
        Me.Label4.Text = "Nama Lengkap"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 181)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 13)
        Me.Label1.TabIndex = 133
        Me.Label1.Text = "Tempat, Tanggal Lahir"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 110
        Me.Label3.Text = "User ID"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(15, 155)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 13)
        Me.Label11.TabIndex = 130
        Me.Label11.Text = "No Identitas"
        '
        'dtpTglLahir
        '
        Me.dtpTglLahir.CustomFormat = "dd/MM/yyyy"
        Me.dtpTglLahir.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTglLahir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTglLahir.Location = New System.Drawing.Point(298, 176)
        Me.dtpTglLahir.Name = "dtpTglLahir"
        Me.dtpTglLahir.Size = New System.Drawing.Size(99, 21)
        Me.dtpTglLahir.TabIndex = 7
        Me.dtpTglLahir.Value = New Date(2014, 9, 16, 0, 0, 0, 0)
        '
        'txtUserID
        '
        Me.txtUserID.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtUserID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUserID.Location = New System.Drawing.Point(193, 12)
        Me.txtUserID.MaxLength = 15
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(157, 21)
        Me.txtUserID.TabIndex = 1
        '
        'txtNoID
        '
        Me.txtNoID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNoID.Location = New System.Drawing.Point(193, 150)
        Me.txtNoID.Name = "txtNoID"
        Me.txtNoID.Size = New System.Drawing.Size(204, 21)
        Me.txtNoID.TabIndex = 5
        '
        'txtTempatLahir
        '
        Me.txtTempatLahir.Location = New System.Drawing.Point(193, 176)
        Me.txtTempatLahir.Name = "txtTempatLahir"
        Me.txtTempatLahir.Size = New System.Drawing.Size(99, 21)
        Me.txtTempatLahir.TabIndex = 6
        '
        'StatusStrip
        '
        Me.StatusStrip.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripEmpty, Me.ToolStripStatusLabel3, Me.ToolStripCreatedDate, Me.ToolStripModifiedDate})
        Me.StatusStrip.Location = New System.Drawing.Point(3, 524)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(551, 22)
        Me.StatusStrip.TabIndex = 118
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'ToolStripEmpty
        '
        Me.ToolStripEmpty.Name = "ToolStripEmpty"
        Me.ToolStripEmpty.Size = New System.Drawing.Size(536, 17)
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
        Me.lblHead.Size = New System.Drawing.Size(602, 22)
        Me.lblHead.TabIndex = 0
        Me.lblHead.Text = "« User Detail"
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
        Me.ToolBar.Size = New System.Drawing.Size(557, 28)
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
        'frmMstUserDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(557, 577)
        Me.Controls.Add(Me.gbDetail)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmMstUserDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Master User Detail"
        Me.gbDetail.ResumeLayout(False)
        Me.gbDetail.PerformLayout()
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
    Friend WithEvents txtUserID As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripEmpty As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripCreatedDate As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripModifiedDate As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtJamsostekID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNoNPWP As System.Windows.Forms.TextBox
    Friend WithEvents lblPekerjaan As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpTglLahir As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtTempatLahir As System.Windows.Forms.TextBox
    Friend WithEvents cboJenisID As System.Windows.Forms.ComboBox
    Friend WithEvents txtNoHp As System.Windows.Forms.TextBox
    Friend WithEvents txtNoID As System.Windows.Forms.TextBox
    Friend WithEvents txtAlamat As System.Windows.Forms.TextBox
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dtpStartWorkingDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboIsActive As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtTglLahirStr As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtUserGroupID As System.Windows.Forms.TextBox
    Friend WithEvents btnUserGroupID As System.Windows.Forms.Button
    Friend WithEvents txtJabatan As System.Windows.Forms.ComboBox
End Class
