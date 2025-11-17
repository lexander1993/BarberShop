<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSysUserChangePassword
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
        Me.Label15 = New System.Windows.Forms.Label()
        Me.BarSave = New System.Windows.Forms.ToolBarButton()
        Me.BarExit = New System.Windows.Forms.ToolBarButton()
        Me.gbDetail = New System.Windows.Forms.GroupBox()
        Me.txtNewPassword2 = New BarberShop.usTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNewPassword1 = New BarberShop.usTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCurrenctPassword = New BarberShop.usTextBox()
        Me.ToolBar = New System.Windows.Forms.ToolBar()
        Me.gbDetail.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(21, 30)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(155, 13)
        Me.Label15.TabIndex = 91
        Me.Label15.Text = "Type your currenct password :"
        '
        'BarSave
        '
        Me.BarSave.Name = "BarSave"
        Me.BarSave.Text = "Save"
        '
        'BarExit
        '
        Me.BarExit.Name = "BarExit"
        Me.BarExit.Text = "Exit"
        '
        'gbDetail
        '
        Me.gbDetail.Controls.Add(Me.txtNewPassword2)
        Me.gbDetail.Controls.Add(Me.Label2)
        Me.gbDetail.Controls.Add(Me.txtNewPassword1)
        Me.gbDetail.Controls.Add(Me.Label1)
        Me.gbDetail.Controls.Add(Me.txtCurrenctPassword)
        Me.gbDetail.Controls.Add(Me.Label15)
        Me.gbDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbDetail.Location = New System.Drawing.Point(0, 28)
        Me.gbDetail.Name = "gbDetail"
        Me.gbDetail.Size = New System.Drawing.Size(322, 216)
        Me.gbDetail.TabIndex = 1
        Me.gbDetail.TabStop = False
        '
        'txtNewPassword2
        '
        Me.txtNewPassword2.BackColor = System.Drawing.Color.LightCyan
        Me.txtNewPassword2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNewPassword2.Font = New System.Drawing.Font("Broadway BT", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtNewPassword2.Location = New System.Drawing.Point(23, 162)
        Me.txtNewPassword2.MaxLength = 20
        Me.txtNewPassword2.Name = "txtNewPassword2"
        Me.txtNewPassword2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNewPassword2.Size = New System.Drawing.Size(255, 21)
        Me.txtNewPassword2.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(21, 142)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(209, 13)
        Me.Label2.TabIndex = 101
        Me.Label2.Text = "Type the new password again to confirm :"
        '
        'txtNewPassword1
        '
        Me.txtNewPassword1.BackColor = System.Drawing.Color.LightCyan
        Me.txtNewPassword1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNewPassword1.Font = New System.Drawing.Font("Broadway BT", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtNewPassword1.Location = New System.Drawing.Point(23, 105)
        Me.txtNewPassword1.MaxLength = 20
        Me.txtNewPassword1.Name = "txtNewPassword1"
        Me.txtNewPassword1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNewPassword1.Size = New System.Drawing.Size(255, 21)
        Me.txtNewPassword1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(21, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 13)
        Me.Label1.TabIndex = 99
        Me.Label1.Text = "Type a new password :"
        '
        'txtCurrenctPassword
        '
        Me.txtCurrenctPassword.BackColor = System.Drawing.Color.LightGreen
        Me.txtCurrenctPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCurrenctPassword.Font = New System.Drawing.Font("Broadway BT", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurrenctPassword.Location = New System.Drawing.Point(23, 50)
        Me.txtCurrenctPassword.MaxLength = 20
        Me.txtCurrenctPassword.Name = "txtCurrenctPassword"
        Me.txtCurrenctPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtCurrenctPassword.Size = New System.Drawing.Size(255, 21)
        Me.txtCurrenctPassword.TabIndex = 0
        '
        'ToolBar
        '
        Me.ToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBar.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarSave, Me.BarExit})
        Me.ToolBar.DropDownArrows = True
        Me.ToolBar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolBar.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar.Name = "ToolBar"
        Me.ToolBar.ShowToolTips = True
        Me.ToolBar.Size = New System.Drawing.Size(322, 28)
        Me.ToolBar.TabIndex = 0
        Me.ToolBar.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
        '
        'frmSysUserChangePassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(322, 244)
        Me.Controls.Add(Me.gbDetail)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSysUserChangePassword"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Change Password"
        Me.gbDetail.ResumeLayout(False)
        Me.gbDetail.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents BarSave As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarExit As System.Windows.Forms.ToolBarButton
    Friend WithEvents gbDetail As System.Windows.Forms.GroupBox
    Friend WithEvents ToolBar As System.Windows.Forms.ToolBar
    Friend WithEvents txtNewPassword2 As usTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNewPassword1 As usTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCurrenctPassword As usTextBox
End Class
