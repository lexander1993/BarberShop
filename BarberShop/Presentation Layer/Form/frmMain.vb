Public Class frmMain

    Dim frmMstUser As frmMstUser
    Dim frmMstUserGroup As frmMstUserGroup
    Dim frmTraCashier As frmTraCashier
    Dim frmRptStylistFee As frmRptStylistFee
    Dim frmRptProfit As frmRptProfit
    Dim frmRptProfitNew As frmRptProfitNew

    Dim frmMstItem As frmMstItem

    Dim frmSysUserChangePassword As frmSysUserChangePassword

    Dim bolLogOut As Boolean

    'Untuk kolom yg tidak perlu diisi warna Azure cth Remarks
    'Untuk field AutoGenerate atau harus pilih dari master warna LemonChiffon cth NotaryOrderID

    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Backup Database Otomatis
        'Try
        '    Dim strBackupPath As String
        '    strBackupPath = DL.Server.BackupDatabaseAuto()
        'Catch ex As Exception
        '    UI.usForm.frmMessageBox(ex.Message)
        'End Try

        bolLogOut = False
        lblUserID.Text = "LOGIN BY : " & UI.usUserApp.UserID
        lblCompany.Text = UI.usUserApp.CompanyName

        'DL.MasterUser.GetAccessRigt()
        'prvSetMenuAccess()


    End Sub

    Private Sub prvSetMenuAccess()
        Dim bolEditMasterUser As Boolean = DL.MasterUser.IsAccess("MASTER USER EDIT")
        Dim bolEditMasterUserGroup As Boolean = DL.MasterUser.IsAccess("MASTER USER GROUP EDIT")
        Dim bolEditMasterItem As Boolean = DL.MasterUser.IsAccess("MASTER ITEM EDIT")

        Dim bolEditPayment As Boolean = DL.MasterUser.IsAccess("TRANSACTION PAYMENT IN EDIT")

        Dim bolViewReportStylistFee As Boolean = DL.MasterUser.IsAccess("REPORT STYLIST FEE VIEW")
        Dim bolViewReportProfit As Boolean = DL.MasterUser.IsAccess("REPORT PROFIT VIEW")


        'PaymentToolStripMenuItem.Visible = IIf(bolEditPayment, bolEditPayment, bolViewPayment)

        UserToolStripMenuItem.Visible = bolEditMasterUser
        UserGroupToolStripMenuItem.Visible = bolEditMasterUserGroup
        ItemToolStripMenuItem.Visible = bolEditMasterItem

        PaymentToolStripMenuItem.Visible = bolEditPayment

        StylistFeeToolStripMenuItem.Visible = bolViewReportStylistFee
        ProfitToolStripMenuItem.Visible = bolViewReportProfit




    End Sub

    Private Sub Form_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not bolLogOut Then
            If UI.usForm.frmAskQuestion("Exit From System ?") Then
                Application.Exit()
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub mnuWindowsTileVertical_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuWindowsTileVertical.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub mnuWindowsTileHorizontal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuWindowsTileHorizontal.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub mnuToolsLogOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsLogOut.Click
        If UI.usForm.frmAskQuestion("Log Out From Program ?") Then
            bolLogOut = True
            Dim frmDetail As New frmSysUserLogin
            frmDetail.Show()
            Me.Close()
        End If
    End Sub

    Private Sub UserToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserToolStripMenuItem.Click
        UI.usForm.frmOpen(frmMstUser, "frmMstUser", Me)
    End Sub

    Private Sub mnuToolsChangePassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsChangePassword.Click
        UI.usForm.frmOpen(frmSysUserChangePassword, "frmSysUserChangePassword", Me)
    End Sub

    Private Sub UserGroupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserGroupToolStripMenuItem.Click
        UI.usForm.frmOpen(frmMstUserGroup, "frmMstUserGroup", Me)
    End Sub

    Private Sub PaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaymentToolStripMenuItem.Click
        UI.usForm.frmOpen(frmTraCashier, "frmTraCashier", Me)
    End Sub

    Private Sub StylistFeeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StylistFeeToolStripMenuItem.Click
        UI.usForm.frmOpen(frmRptStylistFee, "frmRptStylistFee", Me)
    End Sub

    Private Sub ProfitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProfitToolStripMenuItem.Click
        UI.usForm.frmOpen(frmRptProfit, "frmRptProfit", Me)
    End Sub

    Private Sub ItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemToolStripMenuItem.Click
        UI.usForm.frmOpen(frmMstItem, "frmMstItem", Me)
    End Sub

    Private Sub ProfitNewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProfitNewToolStripMenuItem.Click
        UI.usForm.frmOpen(frmRptProfitNew, "frmRptProfitNew", Me)
    End Sub
End Class
