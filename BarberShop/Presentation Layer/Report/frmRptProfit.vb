Public Class frmRptProfit

    Private Const _
        cPreview = 0, cClose = 1

    Private Sub prvSetIcon()
        UI.usForm.SetToolBar(Me, ToolBar, "0,Print,1,Close")
    End Sub

    Private Sub prvPreview()
        If txtReportTitle.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Report Title cannot blank")
            txtReportTitle.Focus()
            Exit Sub
        ElseIf dtpDateFrom.Value.Date > dtpDateTo.Value.Date Then
            UI.usForm.frmMessageBox("Invalid range date")
            dtpDateFrom.Focus()
            Exit Sub
        End If

        UI.usForm.CreateWaitDialog()

        Dim crReportFile As New rptProfit
        crReportFile.SetDataSource(DL.PaymentIn.ProfitReport(dtpDateFrom.Value.Date, dtpDateTo.Value.Date))

        crReportFile.SetParameterValue("CompanyName", UI.usUserApp.CompanyName)
        crReportFile.SetParameterValue("CompanyAddress", UI.usUserApp.CompanyAddress)
        crReportFile.SetParameterValue("UserID", UI.usUserApp.UserID)
        crReportFile.SetParameterValue("ReportTitle", txtReportTitle.Text.Trim)
        crReportFile.SetParameterValue("DateFrom", dtpDateFrom.Value.Date)
        crReportFile.SetParameterValue("DateTo", dtpDateTo.Value.Date)
        crReportFile.SetParameterValue("PengeluaranLain", numPengeluaranLain.Value)

        Dim frmDetail As New frmSysReport
        With frmDetail
            .MdiParent = frmMain
            .crvViewer.ReportSource = crReportFile
            .crvViewer.Refresh()
            .crvViewer.Show()
            .WindowState = FormWindowState.Maximized
            .StartPosition = FormStartPosition.CenterScreen
            .Show()
        End With

        UI.usForm.CloseWaitDialog()
    End Sub

#Region "Form Handle"

    Private Sub frmRptSummaryLocalPurchaseByCategory_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        prvSetIcon()
        dtpDateFrom.Value = Today.Year & "/" & Today.Month & "/" & "01 23:59:59"
        dtpDateTo.Value = Today
        txtReportTitle.Text = "Profit Report"
    End Sub

    Private Sub frmRptSummaryLocalPurchaseByCategory_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Close this form?") Then
                Me.Close()
            End If
        End If
    End Sub

    Private Sub ToolBar_ButtonClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Preview" : Me.prvPreview()
            Case "Close" : Me.Close()
        End Select
    End Sub

#End Region

End Class