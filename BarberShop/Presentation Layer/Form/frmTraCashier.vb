Imports DevExpress.XtraEditors.Repository

Public Class frmTraCashier

    Private dtTable As DataTable
    Private dtRow, dtRowUpd As DataRow
    Private intTotalPayment As Integer
    Private bolnew As Boolean = False

    Private Sub prvSetGrid()
        UI.usForm.SetGrid(grdCustView, "CustQueueID", "No", 50, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdCustView, "CustName", "Customer Name", 180, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdCustView, "CreatedDate", "Date", 150, UI.usDefGrid.gFullDate)

        UI.usForm.SetGrid(grdStylistView, "StylistQueueID", "No", 50, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdStylistView, "StylistUserID", "Stylist", 150, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdStylistView, "CreatedDate", "Date", 130, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdStylistView, "IsAvailable", "Available", 100, UI.usDefGrid.gBoolean)

        'grdStylistView.Columns.Item("StylistQueueID").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending

        UI.usForm.SetGrid(grdInServiceView, "ServiceID", "No", 80, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdInServiceView, "StylistUserID", "Stylist", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdInServiceView, "CustName", "Customer Name", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdInServiceView, "CheckInDate", "Cek In", 150, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdInServiceView, "CheckOutDate", "Cek Out", 150, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdInServiceView, "IsCekOut", "Cek Out", 100, UI.usDefGrid.gBoolean)
        UI.usForm.SetGrid(grdInServiceView, "IsPaid", "Paid", 100, UI.usDefGrid.gBoolean)
        UI.usForm.SetGrid(grdInServiceView, "IsDeleted", "Deleted", 70, UI.usDefGrid.gBoolean)
        'UI.usForm.SetGrid(grdInServiceView, "DeletedRemarks", "Remarks", 100, UI.usDefGrid.gString)

        UI.usForm.SetGrid(grdItemView, "PaymentDetDateTime", "PaymentDetDateTime", 100, UI.usDefGrid.gFullDate, False)
        UI.usForm.SetGrid(grdItemView, "ItemID", "ItemID", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "ItemName", "Type", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "ServiceID", "Service ID", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "TotalPrice", "Total Price", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdItemView, "Price", "Price", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdItemView, "Quantity", "Quantity", 70, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdItemView, "StylistUserID", "Stylist", 120, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "CustName", "Customer", 120, UI.usDefGrid.gString)

        UI.usForm.SetGrid(grdPaymentListView, "PaymentInID", "Payment ID", 110, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdPaymentListView, "PaymentDate", "Payment Date", 120, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdPaymentListView, "CreatedBy", "CreatedBy", 120, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdPaymentListView, "IsDeleted", "Is Deleted", 120, UI.usDefGrid.gBoolean)
        UI.usForm.SetGrid(grdPaymentListView, "TotalPayment", "Total Payment", 120, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdPaymentListView, "Print", "Print", 80, UI.usDefGrid.gIntNum)

    End Sub

    Private Sub frmTraCashier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpPaymentListDateFrom.EditValue = Today
        dtpPaymentListDateTo.EditValue = Today
        dtpServiceDateFrom.EditValue = Today
        dtpServiceDateTo.EditValue = Today

        prvSetGrid()
        ListCustQueue()
        ListStylistQueue()
        ListInServiceQueue()
    End Sub

#Region "Cust Queue"

    Private Sub prvAddCust()
        If txtQueueCustName.Text = "" Then
            UI.usForm.frmMessageBox("Nama Custumer harus diisi !")
            txtQueueCustName.Focus()
            Exit Sub
        End If

        DL.CustQueue.SaveData(txtQueueCustName.Text)
        ListCustQueue()
        txtQueueCustName.Text = ""
        txtQueueCustName.Focus()
    End Sub

    Private Sub bntAddCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntAddCust.Click
        prvAddCust()
    End Sub

    Private Sub txtQueueCustName_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQueueCustName.KeyDown
        If e.KeyCode = Keys.Enter Then
            prvAddCust()
        End If
    End Sub

    Private Sub btnRemoveCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveCust.Click
        Dim intPos As Integer = grdCustView.FocusedRowHandle
        Dim intCustQueueID As Integer = grdCustView.GetDataRow(intPos).Item("CustQueueID")
        Try
            DL.CustQueue.DeleteData(intCustQueueID)
            ListCustQueue()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub btnCustDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustDown.Click
        Dim intPos As Integer = grdCustView.FocusedRowHandle
        Dim intNextCustID As Integer = 0
        Dim intCustQueueID As Integer = grdCustView.GetDataRow(intPos).Item("CustQueueID")
        Dim strCustName As String = grdCustView.GetDataRow(intPos).Item("CustName")
        Dim dtCreatedDate As DateTime = grdCustView.GetDataRow(intPos).Item("CreatedDate")

        Try
            intNextCustID = DL.CustQueue.DownQueue(intCustQueueID, strCustName, dtCreatedDate)
            pubRefreshCustQueue(intNextCustID)
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub btnUpCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpCust.Click
        Dim intPos As Integer = grdCustView.FocusedRowHandle
        Dim intPrevCustID As Integer = 0
        Dim intCustQueueID As Integer = grdCustView.GetDataRow(intPos).Item("CustQueueID")
        Dim strCustName As String = grdCustView.GetDataRow(intPos).Item("CustName")
        Dim dtCreatedDate As DateTime = grdCustView.GetDataRow(intPos).Item("CreatedDate")

        Try
            intPrevCustID = DL.CustQueue.UpQueue(intCustQueueID, strCustName, dtCreatedDate)
            pubRefreshCustQueue(intPrevCustID)
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub btnRefreshCust_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRefreshCust.Click
        ListCustQueue()
    End Sub

    Private Sub ListCustQueue()
        grdCust.DataSource = DL.CustQueue.ListData()

        prvQueueInServiceName()

        If grdCustView.RowCount <= 0 Then
            btnRemoveCust.Enabled = False
            btnUpCust.Enabled = False
            btnCustDown.Enabled = False
        Else
            btnRemoveCust.Enabled = True
            btnUpCust.Enabled = True
            btnCustDown.Enabled = True
        End If
    End Sub

    Public Sub pubRefreshCustQueue(Optional ByVal intSearch As Integer = 0)
        With grdCustView
            If Not grdCustView.FocusedValue Is Nothing And intSearch = 0 Then
                intSearch = grdCustView.GetDataRow(grdCustView.FocusedRowHandle).Item("CustQueueID")
            End If
            ListCustQueue()
            If grdCustView.RowCount > 0 Then UI.usForm.GridMoveRow(grdCustView, "CustQueueID", intSearch)
        End With
    End Sub

#End Region

#Region "Stylist Queue"

    Private Sub btnAddStylist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddStylist.Click
        If cbQueueStylistName.Text = "" Then
            UI.usForm.frmMessageBox("Nama Stylist tidak boleh kosong!")
            cbQueueStylistName.Focus()
            Exit Sub
        End If

        DL.StylistQueue.SaveData(cbQueueStylistName.Text)
        ListStylistQueue()
        prvQueueStylistName()

    End Sub

    Private Sub btnRemoveStylist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveStylist.Click
        Dim intPos As Integer = grdStylistView.FocusedRowHandle
        Dim intStylistQueueID As Integer = grdStylistView.GetDataRow(intPos).Item("StylistQueueID")
        Try
            DL.StylistQueue.DeleteData(intStylistQueueID)
            ListStylistQueue()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub btnStylistDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStylistDown.Click
        Dim intPos As Integer = grdStylistView.FocusedRowHandle
        Dim intNextStylistID As Integer = 0
        Dim intStylistQueueID As Integer = grdStylistView.GetDataRow(intPos).Item("StylistQueueID")
        Dim strStylistName As String = grdStylistView.GetDataRow(intPos).Item("StylistUserID")
        Dim dtCreatedDate As DateTime = grdStylistView.GetDataRow(intPos).Item("CreatedDate")

        Try
            intNextStylistID = DL.StylistQueue.DownQueue(intStylistQueueID, strStylistName, dtCreatedDate)
            pubRefreshStylistQueue(intNextStylistID)
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub btnStylistUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStylistUp.Click
        Dim intPos As Integer = grdStylistView.FocusedRowHandle
        Dim intPrevStylistID As Integer = 0
        Dim intStylistQueueID As Integer = grdStylistView.GetDataRow(intPos).Item("StylistQueueID")
        Dim strStylistName As String = grdStylistView.GetDataRow(intPos).Item("StylistUserID")
        Dim dtCreatedDate As DateTime = grdStylistView.GetDataRow(intPos).Item("CreatedDate")

        Try
            intPrevStylistID = DL.StylistQueue.UpQueue(intStylistQueueID, strStylistName, dtCreatedDate)
            pubRefreshStylistQueue(intPrevStylistID)
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub btnRefreshStylist_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRefreshStylist.Click
        ListStylistQueue()
    End Sub

    Private Sub ListStylistQueue()
        grdStylist.DataSource = DL.StylistQueue.ListData()
        prvQueueStylistName()
        prvQueueInServiceName()

        If grdStylistView.RowCount <= 0 Then
            btnRemoveStylist.Enabled = False
            btnStylistUp.Enabled = False
            btnStylistDown.Enabled = False
        Else
            btnRemoveStylist.Enabled = True
            btnStylistUp.Enabled = True
            btnStylistDown.Enabled = True
        End If
    End Sub

    Public Sub pubRefreshStylistQueue(Optional ByVal intSearch As Integer = 0)
        With grdStylistView
            If Not grdStylistView.FocusedValue Is Nothing And intSearch = 0 Then
                intSearch = grdStylistView.GetDataRow(grdStylistView.FocusedRowHandle).Item("StylistQueueID")
            End If
            ListStylistQueue()
            If grdStylistView.RowCount > 0 Then UI.usForm.GridMoveRow(grdStylistView, "StylistQueueID", intSearch)
        End With
    End Sub

    Private Sub prvQueueStylistName()
        cbQueueStylistName.Properties.DataSource = DL.StylistQueue.ListStylistName()
        cbQueueStylistName.Properties.DisplayMember = "UserID"
    End Sub

    Private Sub grdStylistView_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles grdStylistView.RowStyle
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
        If (e.RowHandle >= 0) Then
            Dim bolIsAvailable As Boolean = View.GetRowCellValue(e.RowHandle, View.Columns("IsAvailable"))

            If bolIsAvailable = True Then
                e.Appearance.BackColor = Color.SkyBlue
                e.Appearance.BackColor2 = Color.WhiteSmoke
            Else
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.BackColor2 = Color.WhiteSmoke
            End If
        End If
    End Sub

#End Region

#Region "In Service"

    Private Sub btnAddService_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddService.Click
        If cboCustInService.Text = "" Then
            UI.usForm.frmMessageBox("Nama Custumer tidak boleh kosong!")
            cboCustInService.Focus()
            Exit Sub
        End If

        If cboStylistInService.Text = "" Then
            UI.usForm.frmMessageBox("Nama Stylist tidak boleh kosong!")
            cboStylistInService.Focus()
            Exit Sub
        End If

        If Not UI.usForm.frmAskQuestion("Tambah Customer : " & cboCustInService.Text & " Stylist :" & cboStylistInService.Text & " ?") Then
            Exit Sub
        End If

        DL.InServiceQueue.SaveData(cboStylistInService.Text, cboCustInService.Text)
        DL.CustQueue.DeleteData(cboCustInService.GetColumnValue("CustNo"))
        DL.StylistQueue.UpdateIsAvailable(False, cboStylistInService.Text)
        DL.StylistQueue.MoveBackQueue(cboStylistInService.Text)

        ListInServiceQueue()
        ListStylistQueue()
        ListCustQueue()
        PaymentCurrentService()
    End Sub

    Private Sub btnCekOutInService_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCekOutInService.Click
        Dim intPos As Integer = grdInServiceView.FocusedRowHandle
        Dim strServiceQueueID As String = grdInServiceView.GetDataRow(intPos).Item("ServiceID")
        Dim strStylistUserID As String = grdInServiceView.GetDataRow(intPos).Item("StylistUserID")
        Dim bolIsCekOut As Boolean = grdInServiceView.GetDataRow(intPos).Item("IsCekOut")
        Dim bolIsDeleted As Boolean = grdInServiceView.GetDataRow(intPos).Item("IsDeleted")
        Dim bolIsPaid As Boolean = grdInServiceView.GetDataRow(intPos).Item("IsPaid")

        If bolIsDeleted = True Then
            UI.usForm.frmMessageBox("Service ID :" & strServiceQueueID & " sudah pernah dihapus")
            Exit Sub
        End If

        If bolIsPaid = True Then
            UI.usForm.frmMessageBox("Service ID :" & strServiceQueueID & " tidak bisa cek out karena sudah dibayar")
            Exit Sub
        End If

        If bolIsCekOut = True Then
            UI.usForm.frmMessageBox("Service ID :" & strServiceQueueID & " sudah pernah Cek Out")
            Exit Sub
        End If

        If Not UI.usForm.frmAskQuestion("Cek Out Service ID :" & strServiceQueueID & " ?") Then
            Exit Sub
        End If

        Try
            DL.InServiceQueue.UpdateIsCekOut(strServiceQueueID)
            ' DL.StylistQueue.UpdateIsAvailable(True, strStylistUserID)
            DL.StylistQueue.MoveBehindAvailableQueue(strStylistUserID)
            ListInServiceQueue()
            ListStylistQueue()
            UI.usForm.frmMessageBox("Service ID :" & strServiceQueueID & " berhasil dicek out")
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
        PaymentCurrentService()

    End Sub

    Private Sub btnRemoveService_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveService.Click
        Dim intPos As Integer = grdInServiceView.FocusedRowHandle
        Dim strServiceQueueID As String = grdInServiceView.GetDataRow(intPos).Item("ServiceID")
        Dim bolIsCekOut As Boolean = grdInServiceView.GetDataRow(intPos).Item("IsCekOut")
        Dim bolIsDeleted As Boolean = grdInServiceView.GetDataRow(intPos).Item("IsDeleted")
        Dim bolIsPaid As Boolean = grdInServiceView.GetDataRow(intPos).Item("IsPaid")

        If bolIsDeleted = True Then
            UI.usForm.frmMessageBox("Service ID :" & strServiceQueueID & " sudah pernah dihapus")
            Exit Sub
        End If

        If bolIsPaid = True Then
            UI.usForm.frmMessageBox("Service ID :" & strServiceQueueID & " tidak bisa dihapus karena sudah dibayar")
            Exit Sub
        End If

        If bolIsCekOut = True Then
            UI.usForm.frmMessageBox("Service ID :" & strServiceQueueID & " tidak bisa dihapus karena sudah Cek Out")
            Exit Sub
        End If

        If Not UI.usForm.frmAskQuestion("Hapus Service ID :" & strServiceQueueID & " ?") Then
            Exit Sub
        End If

        Try
            DL.InServiceQueue.DeleteData(strServiceQueueID)

            ListInServiceQueue()
            UI.usForm.frmMessageBox("Service ID :" & strServiceQueueID & " berhasil dihapus")
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
        PaymentCurrentService()
    End Sub

    Private Sub btnRefreshInService_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRefreshInService.Click
        ListInServiceQueue()
    End Sub

    Private Sub prvQueueInServiceName()
        cboCustInService.Properties.DataSource = DL.CustQueue.ListCustInService()
        cboCustInService.Properties.ValueMember = "CustNo"
        cboCustInService.Properties.DisplayMember = "CustName"

        cboCustInService.ItemIndex = 0
        'cboCustInService.GetSelectedDataRow()

        cboStylistInService.Properties.DataSource = DL.StylistQueue.ListStylistInService()
        cboStylistInService.Properties.DisplayMember = "StylistUserID"
        cboStylistInService.Properties.ValueMember = "StylistUserID"
        cboStylistInService.ItemIndex = 0
    End Sub

    Private Sub ListInServiceQueue()
        grdInService.DataSource = DL.InServiceQueue.ListData(dtpServiceDateFrom.EditValue, dtpServiceDateTo.EditValue)

        If grdInServiceView.RowCount <= 0 Then
            btnRemoveStylist.Enabled = False
        Else
            btnRemoveStylist.Enabled = True
        End If
    End Sub

    Public Sub pubRefreshServiceQueue(Optional ByVal intSearch As Integer = 0)
        With grdInServiceView
            If Not grdInServiceView.FocusedValue Is Nothing And intSearch = 0 Then
                intSearch = grdInServiceView.GetDataRow(grdInServiceView.FocusedRowHandle).Item("ServiceID")
            End If
            ListInServiceQueue()
            If grdInServiceView.RowCount > 0 Then UI.usForm.GridMoveRow(grdInServiceView, "ServiceID", intSearch)
        End With
    End Sub

    Private Sub grdInServiceView_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles grdInServiceView.RowStyle
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
        If (e.RowHandle >= 0) Then
            Dim bolIsDeleted As Boolean = View.GetRowCellValue(e.RowHandle, View.Columns("IsDeleted"))
            Dim bolIsCekOut As Boolean = View.GetRowCellValue(e.RowHandle, View.Columns("IsCekOut"))
            Dim bolIsPaid As Boolean = View.GetRowCellValue(e.RowHandle, View.Columns("IsPaid"))

            If bolIsDeleted = True Then
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.BackColor2 = Color.WhiteSmoke
            ElseIf bolIsPaid = True Then
                e.Appearance.BackColor = Color.LightGreen
                e.Appearance.BackColor2 = Color.WhiteSmoke
            ElseIf bolIsCekOut = True Then
                e.Appearance.BackColor = Color.SkyBlue
                e.Appearance.BackColor2 = Color.WhiteSmoke
            End If
        End If
    End Sub

    Private Sub btnSearchInService_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchInService.Click
        ListInServiceQueue()
    End Sub

#End Region

#Region "Payment"

    Private Sub PaymentAutoNumber()
        txtPaymentID.Text = DL.PaymentIn.PaymentAutoNumber
    End Sub

    Private Sub PaymentCurrentService()
        cbPayServiceID.EditValue = Nothing
        cbPayServiceID.Properties.DataSource = DL.PaymentIn.PaymentCurrentService()
        cbPayServiceID.Properties.ValueMember = "ServiceID"
        cbPayServiceID.Properties.DisplayMember = "ServiceID"
    End Sub

    Private Sub Type()
        cbType.Properties.DataSource = DL.PaymentIn.Type()

        cbType.Properties.ValueMember = "TypeName"
        cbType.Properties.DisplayMember = "TypeName"
        cbType.ItemIndex = 0
    End Sub

    Private Sub prvNewPayment()
        btnSavePayment.Enabled = True
        btnDeletePayment.Enabled = False
        btnAddPayDet.Enabled = True
        btnDelPayDet.Enabled = True
        btnPrint.Enabled = False
        numPrintKe.EditValue = 1

        PaymentAutoNumber()
        dtpPaymentDate.EditValue = Today.ToString("dd MMM yy ") + DateTime.Now.ToString("HH:mm:ss")
        PaymentCurrentService()
        Type()
        grdItemDet.DataSource = DL.PaymentIn.PaymentItemDet(txtPaymentID.Text)
    End Sub

    Private Sub btnNewPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewPayment.Click
        prvNewPayment()
    End Sub

    Private Sub cbType_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbType.EditValueChanged
        txtPrice.Text = cbType.GetColumnValue("Price")
        numTotalPrice.EditValue = numQty.EditValue * txtPrice.EditValue

        Dim bolIsBarber As Boolean = cbType.GetColumnValue("IsBarber")
        If bolIsBarber Then
            numQty.EditValue = 1
            numQty.Properties.ReadOnly = True
            PaymentCurrentService()
        Else
            cbPayServiceID.Properties.DataSource = Nothing
            txtPaymentDetCust.Text = ""
            txtPaymentDetStylist.Text = ""
            numQty.EditValue = 1
            numQty.Properties.ReadOnly = False
        End If
    End Sub

    Private Sub SpinEdit1_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numQty.EditValueChanged
        numTotalPrice.EditValue = numQty.EditValue * txtPrice.EditValue
    End Sub

    Private Sub btnAddPayDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddPayDet.Click
        If cbType.GetColumnValue("IsBarber") = True And cbPayServiceID.Text = "" Then
            UI.usForm.frmMessageBox("Pilih Service ID")
            Exit Sub
        End If

        dtTable = grdItemDet.DataSource

        Dim bolFind As Boolean = False
        If cbType.GetColumnValue("IsAdd") = False Then
            For Each drData As DataRow In dtTable.Rows
                If drData.Item("ServiceID") = cbPayServiceID.Text And cbPayServiceID.Text <> "" Then
                    bolFind = True
                End If
            Next
        End If

        If bolFind Then
            UI.usForm.frmMessageBox("Service ID " & cbPayServiceID.Text & " sudah pernah diinput!")
            Exit Sub
        Else
            dtTable.AcceptChanges()
        End If

        dtRow = dtTable.NewRow
        dtRow.BeginEdit()
        dtRow.Item("PaymentDetDateTime") = DateTime.Now.ToString("dd/MMM/yy HH:mm:ss")
        dtRow.Item("ItemID") = cbType.GetColumnValue("TypeID")
        dtRow.Item("ItemName") = cbType.GetColumnValue("TypeName")
        dtRow.Item("ServiceID") = cbPayServiceID.Text
        dtRow.Item("CustName") = txtPaymentDetCust.Text
        dtRow.Item("StylistUserID") = txtPaymentDetStylist.Text
        dtRow.Item("Price") = txtPrice.EditValue
        dtRow.Item("Quantity") = numQty.EditValue
        dtRow.Item("TotalPrice") = numTotalPrice.EditValue
        dtRow.EndEdit()

        dtTable.Rows.Add(dtRow)
        dtTable.AcceptChanges()
        grdItemDet.DataSource = dtTable
        grdItemDet.Refresh()

        CalculateTotalPayment()
        'Clear
        PaymentCurrentService()
        Type()
    End Sub

    Private Sub btnDelPayDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelPayDet.Click
        If grdItemView.RowCount = 0 Then
            Exit Sub
        End If

        Dim dtTable As DataTable = grdItemDet.DataSource
        Dim intPos As Integer = grdItemView.FocusedRowHandle
        Dim dtPaymentDetDateTime As DateTime = grdItemView.GetDataRow(intPos).Item("PaymentDetDateTime")

        For Each drdata As DataRow In dtTable.Rows
            If drdata.Item("PaymentDetDateTime") = dtPaymentDetDateTime Then
                drdata.Delete()
            End If
        Next
        dtTable.AcceptChanges()
        grdItemDet.Refresh()

        CalculateTotalPayment()
    End Sub

    Private Sub cbPayServiceID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbPayServiceID.TextChanged
        txtPaymentDetCust.Text = cbPayServiceID.GetColumnValue("Customer")
        txtPaymentDetStylist.Text = cbPayServiceID.GetColumnValue("Stylist")
    End Sub

    Private Sub CalculateTotalPayment()
        Dim dtData As DataTable = grdItemDet.DataSource
        intTotalPayment = 0
        For Each drData As DataRow In dtData.Rows
            intTotalPayment += drData.Item("TotalPrice")
        Next
        numTotalPayment.Text = intTotalPayment
    End Sub

    Private Sub grdView_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles grdPaymentListView.RowStyle
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
        If (e.RowHandle >= 0) Then
            Dim bolIsDeleted As Boolean = View.GetRowCellValue(e.RowHandle, View.Columns("IsDeleted"))
            If bolIsDeleted = True Then
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.BackColor2 = Color.WhiteSmoke
            End If
        End If
    End Sub

    Private Sub btnSavePayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSavePayment.Click
        Dim dtData As DataTable = grdItemDet.DataSource
        Dim clsData As VO.PaymentIn

        If grdItemView.RowCount = 0 Then
            UI.usForm.frmMessageBox("Payment Detail harus diisi!")
            Exit Sub
        End If

        If Not UI.usForm.frmAskQuestion("Save Data?") Then Exit Sub

        Try
            DL.PaymentIn.SavePayment(txtPaymentID.Text, dtpPaymentDate.EditValue, numTotalPayment.EditValue)

            For Each drData As DataRow In dtData.Rows
                clsData = New VO.PaymentIn
                clsData.PaymentInID = txtPaymentID.Text
                clsData.PaymentDetDateTime = drData.Item("PaymentDetDateTime")
                clsData.ItemID = drData.Item("ItemID")
                clsData.ServiceID = drData.Item("ServiceID")
                clsData.Price = drData.Item("Price")
                clsData.Quantity = drData.Item("Quantity")
                clsData.TotalPrice = drData.Item("TotalPrice")
                DL.PaymentIn.SavePaymentDet(clsData)
                If clsData.ServiceID <> "" Then DL.InServiceQueue.UpdateIsPaid(clsData.ServiceID)
            Next

            UI.usForm.frmMessageBox("Save Success ! Payment ID : " & txtPaymentID.Text)
            prvPrint()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        PaymentList()
        prvNewPayment()
        ListInServiceQueue()
    End Sub

    Private Sub PaymentList()
        grdPaymentList.DataSource = DL.PaymentIn.PaymentList(dtpPaymentListDateFrom.EditValue, dtpPaymentListDateTo.EditValue)
    End Sub

    Private Sub btnSearchPaymentList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchPaymentList.Click
        PaymentList()
    End Sub

    Private Sub grdPaymentList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdPaymentList.DoubleClick
        Dim intPos As Integer = grdPaymentListView.FocusedRowHandle

        txtPaymentID.Text = grdPaymentListView.GetDataRow(intPos).Item("PaymentInID")
        dtpPaymentDate.EditValue = grdPaymentListView.GetDataRow(intPos).Item("PaymentDate")
        numPrintKe.EditValue = grdPaymentListView.GetDataRow(intPos).Item("Print") + 1

        btnSavePayment.Enabled = False
        btnDeletePayment.Enabled = True
        btnPrint.Enabled = True
        btnAddPayDet.Enabled = False
        btnDelPayDet.Enabled = False

        cbType.EditValue = Nothing
        cbType.Properties.DataSource = Nothing

        cbPayServiceID.EditValue = Nothing
        cbPayServiceID.Properties.DataSource = Nothing

        grdItemDet.DataSource = DL.PaymentIn.PaymentItemDet(txtPaymentID.Text)
        CalculateTotalPayment()
    End Sub

    Private Sub btnDeletePayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeletePayment.Click
        Dim intPos As Integer = grdPaymentListView.FocusedRowHandle

        Dim strPaymentID As String = grdPaymentListView.GetDataRow(intPos).Item("PaymentInID")

        If grdPaymentListView.GetDataRow(intPos).Item("IsDeleted") = "TRUE" Then
            UI.usForm.frmMessageBox("Payment ID " & strPaymentID & " has been deleted before")
            Exit Sub
        End If

        Try
            If Not UI.usForm.frmAskQuestion("Delete Payment ID " & strPaymentID & " ?") Then Exit Sub
            DL.PaymentIn.DeletePayment(strPaymentID)

            UI.usForm.frmMessageBox("Payment ID " & strPaymentID & " has been deleted ! ")
            prvNewPayment()
            PaymentList()
            ListInServiceQueue()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        DL.PaymentIn.UpdatePrintKe(txtPaymentID.Text)
        prvPrint()
        PaymentList()

        Dim intPos As Integer = grdPaymentListView.FocusedRowHandle
        numPrintKe.EditValue = grdPaymentListView.GetDataRow(intPos).Item("Print") + 1
    End Sub

    Private Sub prvPrint()
        UI.usForm.CreateWaitDialog()

        Dim strPrintKe As String = numPrintKe.EditValue.ToString
        Select Case numPrintKe.EditValue
            Case 1 : strPrintKe = "I"
            Case 2 : strPrintKe = "II"
            Case 3 : strPrintKe = "III"
            Case 4 : strPrintKe = "IV"
            Case 5 : strPrintKe = "V"
            Case 6 : strPrintKe = "VI"
            Case 7 : strPrintKe = "VII"
            Case 8 : strPrintKe = "VIII"
            Case 9 : strPrintKe = "IX"
            Case 10 : strPrintKe = "X"
        End Select


        Try

       
        Dim crReportFile As New rptPrintPayment
        crReportFile.SetDataSource(DL.PaymentIn.PaymentPrint(txtPaymentID.Text))

        crReportFile.SetParameterValue("PaymentID", txtPaymentID.Text.Trim)
        crReportFile.SetParameterValue("PaymentDate", dtpPaymentDate.EditValue)
        crReportFile.SetParameterValue("CompanyName", UI.usUserApp.CompanyName)
        crReportFile.SetParameterValue("CompanyAddress", UI.usUserApp.CompanyAddress)
        crReportFile.SetParameterValue("UserID", UI.usUserApp.UserID)
        crReportFile.SetParameterValue("PrintKe", strPrintKe)

        ' crReportFile.PrintOptions.PrinterName = System.Drawing.Printing.PrinterSettings.InstalledPrinters(6)

            If UI.usUserApp.PrintPayment = "TRUE" Then
                'lgsg print
                crReportFile.PrintToPrinter(1, False, 0, 0)
                crReportFile.Dispose()
            Else
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
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Print Payment", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

       

        UI.usForm.CloseWaitDialog()
    End Sub

    Private Sub TabCashier_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TabCashier.KeyDown
        If e.KeyCode = Keys.F1 Then
            TabCashier.SelectedTabPage = tabPembayaran
        ElseIf e.KeyCode = Keys.F2 Then
            TabCashier.SelectedTabPage = tabAntrian
        End If
    End Sub

#End Region

    
   

   

    
End Class