Public Class frmMstUser

#Region "Look Up"

    Private bolLookUp As Boolean = False
    Private bolLookUpGet As Boolean = False
    Private strLUUserID As String
    Private dtrLUDataRow As DataRow

    Public WriteOnly Property pubIsLookUp() As Boolean
        Set(ByVal Value As Boolean)
            bolLookUp = Value
        End Set
    End Property

    Public ReadOnly Property pubIsLookUpGet() As String
        Get
            Return bolLookUpGet
        End Get
    End Property

    Public Property pubLUUserID() As String
        Get
            Return strLUUserID
        End Get
        Set(ByVal Value As String)
            strLUUserID = Value
        End Set
    End Property

    Public Property pubLUDataRow() As DataRow
        Get
            Return dtrLUDataRow
        End Get
        Set(ByVal Value As DataRow)
            dtrLUDataRow = Value
        End Set
    End Property

#End Region

#Region "Function"
    Private Const _
        cNew = 0, cDetail = 1, cDelete = 2, cReset = 4, cRefresh = 5

    Private intPos As Integer

    Private Sub prvSetIcon()
        UI.usForm.SetToolBar(Me, ToolBar, "0,New,1,Detail,2,Delete,4,Misc,5,Refresh")
    End Sub

    Private Sub prvSetButton()
        'If Not (UI.usUserApp.UserID = UI.usUserApp.SuperAdminID Or UI.usUserApp.UserID = UI.usUserApp.AdminID) Then
        'End If
        Dim bolEdit, bolView As Boolean
        bolEdit = True
        bolView = True

        'bolEdit = DL.MasterUser.IsAccess("MASTER USER EDIT")
        'bolView = DL.MasterUser.IsAccess("MASTER USER VIEW")

        With ToolBar.Buttons
            .Item(cNew).Enabled = bolEdit
            .Item(cDetail).Enabled = IIf(bolEdit, bolEdit, bolView)
            .Item(cDelete).Enabled = bolEdit
            .Item(cReset).Enabled = bolEdit
        End With
    End Sub

    Private Sub prvSetGrid()
        UI.usForm.SetGrid(grdView, "LocationID", "Location ID", 120, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "UserID", "User ID", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "UserGroupID", "User Group ID", 120, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "LocationName", "Location Name", 150, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "UserName", "User Name", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "UserPosition", "Jabatan", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "BirthPlace", "Tempat Lahir", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "BirthDate", "Tanggal Lahir", 100, UI.usDefGrid.gSmallDate)
        UI.usForm.SetGrid(grdView, "Address", "Alamat", 150, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "IDType", "Jenis ID", 80, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "IDNumber", "No ID", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "NPWPNumber", "No NPWP", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "JamsostekID", "No Jamsostek", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "NoHP", "No HP", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "Remarks", "Remarks", 150, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "StartWorkingDate", "Tanggal Mulai Kerja", 150, UI.usDefGrid.gSmallDate)
        UI.usForm.SetGrid(grdView, "CreatedDate", "Created Date", 130, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdView, "ModifiedDate", "Modified Date", 130, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdView, "IsActive", "Is Active", 80, UI.usDefGrid.gBoolean)
        UI.usForm.SetGrid(grdView, "Title", "Title", 150, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "BirthDateStr", "BirthDateStr", 150, UI.usDefGrid.gString, False)
    End Sub

    Private Sub prvSetLookUp()
        If bolLookUp Then
            UI.usForm.GridMoveRow(grdView, "UserID", strLUUserID)
        End If
    End Sub

    Private Sub prvGet()
        intPos = grdView.FocusedRowHandle
        If bolLookUp And intPos >= 0 Then
            strLUUserID = grdView.GetDataRow(intPos).Item("UserID")
            dtrLUDataRow = grdView.GetDataRow(grdView.FocusedRowHandle)
            bolLookUpGet = True
            Me.Close()
        End If
    End Sub

    Private Sub prvNew()
        Dim frmDetail As New frmMstUserDet
        With frmDetail
            .pubIsNew = True
            .pubShowDialog(Me)
        End With
    End Sub

    Private Sub prvDetail()
        intPos = grdView.FocusedRowHandle
        Dim frmDetail As New frmMstUserDet
        With frmDetail
            .pubIsNew = False
            .pubUserID = grdView.GetDataRow(intPos).Item("UserID")
            .pubShowDialog(Me)
            If .pubIsSave Then pubRefresh()
        End With
    End Sub

    Private Sub prvDelete()
        intPos = grdView.FocusedRowHandle
        Dim strUserID As String = grdView.GetDataRow(intPos).Item("UserID")
        Try
            If Not UI.usForm.frmAskQuestion("Hapus User ID " & strUserID & " ?") Then Exit Sub
            DL.MasterUser.DeleteHeader(strUserID)
            UI.usForm.frmMessageBox(strUserID & " berhasil dihapus ! ")
            pubRefresh()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub prvReset()
        intPos = grdView.FocusedRowHandle
        Dim strUserID As String = grdView.GetDataRow(intPos).Item("UserID")
        Try
            If Not UI.usForm.frmAskQuestion("Reset Password User ID " & strUserID & " menjadi abcde ?") Then Exit Sub
            DL.UserAccess.ChangePassword(strUserID, BL.UserAccess.PasswordEncrypt("abcde"))
            UI.usForm.frmMessageBox("Password " & strUserID & " berhasil direset ! ")
            pubRefresh()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub prvQuery()
        Try
            grdMain.DataSource = DL.MasterUser.ListData(cboStatus.SelectedIndex)
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
        'prvSetButton()
    End Sub

    Public Sub pubRefresh(Optional ByVal strSearch As String = "")
        With grdView
            If Not grdView.FocusedValue Is Nothing And strSearch = "" Then
                strSearch = grdView.GetDataRow(grdView.FocusedRowHandle).Item("UserID")
            End If
            prvQuery()
            If grdView.RowCount > 0 Then UI.usForm.GridMoveRow(grdView, "UserID", strSearch)
        End With
    End Sub

#End Region

#Region "Form Handle"

    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboStatus.SelectedIndex = 2
        prvSetIcon()
        prvSetGrid()
        prvQuery()
        prvSetButton()
    End Sub

    Private Sub ToolBar_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        If e.Button.Text = "New" Then
            prvNew()
        ElseIf e.Button.Text = "Refresh" Then
            pubRefresh()
        ElseIf grdView.FocusedRowHandle >= 0 Then
            Select Case e.Button.Text
                Case "Detail" : prvDetail()
                Case "Reset" : prvReset()
                Case "Delete" : prvDelete()
            End Select
        End If
    End Sub

    Private Sub btnExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExecute.Click
        prvQuery()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        grdMain.DataSource = Nothing
    End Sub

    Private Sub grdMain_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdMain.DoubleClick
        If bolLookUp = True Then
            Me.prvGet()
        Else
            prvDetail()
        End If
    End Sub

    'Agar Data Grid View Berwarna
    'Private Sub grdView_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles grdView.RowStyle
    '    Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
    '    If (e.RowHandle >= 0) Then
    '        Dim strStatus As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Status"))
    '        If strStatus = "DRAFT" Then
    '            e.Appearance.BackColor = Color.DeepSkyBlue
    '            e.Appearance.BackColor2 = Color.LightCyan
    '        ElseIf strStatus = "PROCESS" Then
    '            e.Appearance.BackColor = Color.MediumPurple
    '            e.Appearance.BackColor2 = Color.LightCyan
    '        ElseIf strStatus = "COMPLETED" Then
    '            e.Appearance.BackColor = Color.LawnGreen
    '            e.Appearance.BackColor2 = Color.LightCyan
    '        End If
    '    End If
    'End Sub

#End Region

   
End Class