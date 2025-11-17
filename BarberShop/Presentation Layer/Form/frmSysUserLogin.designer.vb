<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSysUserLogin
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSysUserLogin))
        Me.Panel = New System.Windows.Forms.Panel()
        Me.txtUserPassword = New BarberShop.usTextBox()
        Me.txtUserID = New BarberShop.usTextBox()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblUserPassword = New System.Windows.Forms.Label()
        Me.lblUserCode = New System.Windows.Forms.Label()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Panel.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel
        '
        Me.Panel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel.BackgroundImage = CType(resources.GetObject("Panel.BackgroundImage"), System.Drawing.Image)
        Me.Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel.Controls.Add(Me.txtUserPassword)
        Me.Panel.Controls.Add(Me.txtUserID)
        Me.Panel.Controls.Add(Me.pnlHeader)
        Me.Panel.Controls.Add(Me.lblUserPassword)
        Me.Panel.Controls.Add(Me.lblUserCode)
        Me.Panel.Controls.Add(Me.btnOk)
        Me.Panel.Controls.Add(Me.btnClose)
        Me.Panel.Location = New System.Drawing.Point(0, 0)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(320, 177)
        Me.Panel.TabIndex = 0
        '
        'txtUserPassword
        '
        Me.txtUserPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUserPassword.Location = New System.Drawing.Point(118, 101)
        Me.txtUserPassword.MaxLength = 50
        Me.txtUserPassword.Name = "txtUserPassword"
        Me.txtUserPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtUserPassword.Size = New System.Drawing.Size(118, 21)
        Me.txtUserPassword.TabIndex = 1
        '
        'txtUserID
        '
        Me.txtUserID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUserID.Location = New System.Drawing.Point(118, 78)
        Me.txtUserID.MaxLength = 15
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(118, 21)
        Me.txtUserID.TabIndex = 0
        '
        'pnlHeader
        '
        Me.pnlHeader.BackgroundImage = CType(resources.GetObject("pnlHeader.BackgroundImage"), System.Drawing.Image)
        Me.pnlHeader.Controls.Add(Me.lblVersion)
        Me.pnlHeader.Controls.Add(Me.lblTitle)
        Me.pnlHeader.Location = New System.Drawing.Point(-1, -1)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(323, 63)
        Me.pnlHeader.TabIndex = 7
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.BackColor = System.Drawing.Color.Transparent
        Me.lblVersion.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.ForeColor = System.Drawing.Color.White
        Me.lblVersion.Location = New System.Drawing.Point(70, 28)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(70, 14)
        Me.lblVersion.TabIndex = 7
        Me.lblVersion.Text = "Version 1.0.0"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(69, 8)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(228, 16)
        Me.lblTitle.TabIndex = 6
        Me.lblTitle.Text = "Barber Shop Management System"
        '
        'lblUserPassword
        '
        Me.lblUserPassword.AutoSize = True
        Me.lblUserPassword.BackColor = System.Drawing.Color.Transparent
        Me.lblUserPassword.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserPassword.ForeColor = System.Drawing.Color.DimGray
        Me.lblUserPassword.Location = New System.Drawing.Point(43, 104)
        Me.lblUserPassword.Name = "lblUserPassword"
        Me.lblUserPassword.Size = New System.Drawing.Size(61, 13)
        Me.lblUserPassword.TabIndex = 6
        Me.lblUserPassword.Text = "Password"
        '
        'lblUserCode
        '
        Me.lblUserCode.AutoSize = True
        Me.lblUserCode.BackColor = System.Drawing.Color.Transparent
        Me.lblUserCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserCode.ForeColor = System.Drawing.Color.DimGray
        Me.lblUserCode.Location = New System.Drawing.Point(43, 81)
        Me.lblUserCode.Name = "lblUserCode"
        Me.lblUserCode.Size = New System.Drawing.Size(49, 13)
        Me.lblUserCode.TabIndex = 5
        Me.lblUserCode.Text = "User ID"
        '
        'btnOk
        '
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnOk.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.ForeColor = System.Drawing.Color.Black
        Me.btnOk.Location = New System.Drawing.Point(191, 141)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(56, 23)
        Me.btnOk.TabIndex = 2
        Me.btnOk.Text = "OK"
        '
        'btnClose
        '
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnClose.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Black
        Me.btnClose.Location = New System.Drawing.Point(253, 141)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(56, 23)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        '
        'frmSysUserLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(320, 177)
        Me.Controls.Add(Me.Panel)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "frmSysUserLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BarberShop"
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel As System.Windows.Forms.Panel
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblUserPassword As System.Windows.Forms.Label
    Friend WithEvents lblUserCode As System.Windows.Forms.Label
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents txtUserPassword As usTextBox
    Friend WithEvents txtUserID As usTextBox
End Class
