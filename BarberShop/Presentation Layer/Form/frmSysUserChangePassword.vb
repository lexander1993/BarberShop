Public Class frmSysUserChangePassword

    Private Sub prvSetIcon()
        UI.usForm.SetToolBar(Me, ToolBar, "0,Save,1,Close")
    End Sub

    Private Sub prvSave()

        If BL.UserAccess.GetPassword(UI.usUserApp.UserID) <> txtCurrenctPassword.Text Then
            UI.usForm.frmMessageBox("Cannot Save Password. Current Password is Wrong")
            txtCurrenctPassword.Focus()
            Exit Sub
        End If

        If txtCurrenctPassword.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Current Password cannot Blank")
            txtCurrenctPassword.Focus()
            Exit Sub
        End If

        If txtNewPassword1.Text.Trim = "" Then
            UI.usForm.frmMessageBox("New Password cannot Blank")
            txtNewPassword1.Focus()
            Exit Sub
        End If

        If txtNewPassword2.Text.Trim = "" Then
            UI.usForm.frmMessageBox("New Password cannot Blank")
            txtNewPassword2.Focus()
            Exit Sub
        End If

        If txtNewPassword1.Text.Trim <> txtNewPassword2.Text.Trim Then
            UI.usForm.frmMessageBox("New Password must Equal")
            txtNewPassword1.Focus()
            Exit Sub
        End If

        If Len(txtNewPassword1.Text.Trim) < 5 Then
            UI.usForm.frmMessageBox("Password At Least 5 Character ... ")
            txtNewPassword1.Focus()
            prvClearText()
            Exit Sub
        End If

        If Not UI.usForm.frmAskQuestion("Change Password ?") Then Exit Sub
        BL.Server.ServerDefault()
        Try
            BL.UserAccess.ChangePassword(UI.usUserApp.UserID, txtCurrenctPassword.Text.Trim, txtNewPassword1.Text.Trim)
            UI.usForm.frmMessageBox("Change Password Successful. Please remember your Password.")
            Me.Close()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
        BL.Server.ServerDefault()
    End Sub

    Private Sub prvClearText()
        txtNewPassword1.Text = ""
        txtNewPassword2.Text = ""
    End Sub

#Region "Form Handle"

    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtCurrenctPassword.CharacterCasing = CharacterCasing.Normal
        txtNewPassword1.CharacterCasing = CharacterCasing.Normal
        txtNewPassword2.CharacterCasing = CharacterCasing.Normal
        prvSetIcon()
    End Sub

    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Close This Form ?") Then Me.Close()
        End If
    End Sub

    Private Sub ToolBar_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        If e.Button.Text = "Save" Then
            prvSave()
        Else
            Me.Close()
        End If
    End Sub

#End Region

End Class