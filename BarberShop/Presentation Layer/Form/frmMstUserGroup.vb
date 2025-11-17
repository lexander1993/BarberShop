Public Class frmMstUserGroup

#Region "Look Up"

    Private bolLookUp As Boolean = False
    Private bolLookUpGet As Boolean = False
    Private strLUUserGroupID As String
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

    Public Property pubLUUserGroupID() As String
        Get
            Return strLUUserGroupID
        End Get
        Set(ByVal Value As String)
            strLUUserGroupID = Value
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
        cNew = 0, cDetail = 1, cDelete = 2, cRefresh = 4

    Private intPos As Integer

    Private Sub prvSetIcon()
        UI.usForm.SetToolBar(Me, ToolBar, "0,New,1,Detail,2,Delete,4,Refresh")
    End Sub

    Private Sub prvSetButton()
        Dim bolEdit, bolView As Boolean
        bolEdit = DL.MasterUser.IsAccess("MASTER USER GROUP EDIT")
        bolView = DL.MasterUser.IsAccess("MASTER USER GROUP VIEW")

        With ToolBar.Buttons
            .Item(cNew).Enabled = bolEdit
            .Item(cDetail).Enabled = IIf(bolEdit, bolEdit, bolView)
            .Item(cDelete).Enabled = bolEdit
        End With
    End Sub

    Private Sub prvSetGrid()
        UI.usForm.SetGrid(grdView, "UserGroupID", "User Group ID", 250, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "Remarks", "Remarks", 580, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "CreatedBy", "CreatedBy", 120, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "CreatedDate", "Created Date", 130, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdView, "ModifiedBy", "ModifiedBy", 120, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "ModifiedDate", "Modified Date", 130, UI.usDefGrid.gFullDate)
    End Sub

    Private Sub prvSetLookUp()
        If bolLookUp Then
            UI.usForm.GridMoveRow(grdView, "UserGroupID", strLUUserGroupID)
        End If
    End Sub

    Private Sub prvGet()
        intPos = grdView.FocusedRowHandle
        If bolLookUp And intPos >= 0 Then
            strLUUserGroupID = grdView.GetDataRow(intPos).Item("UserGroupID")
            dtrLUDataRow = grdView.GetDataRow(grdView.FocusedRowHandle)
            bolLookUpGet = True
            Me.Close()
        End If
    End Sub

    Private Sub prvNew()
        Dim frmDetail As New frmMstUserGroupDet
        With frmDetail
            .pubIsNew = True
            .pubShowDialog(Me)
        End With
    End Sub

    Private Sub prvDetail()
        intPos = grdView.FocusedRowHandle
        Dim frmDetail As New frmMstUserGroupDet
        With frmDetail
            .pubIsNew = False
            .pubUserGroupID = grdView.GetDataRow(intPos).Item("UserGroupID")
            .pubRemarks = grdView.GetDataRow(intPos).Item("Remarks")
            .pubShowDialog(Me)
            If .pubIsSave Then pubRefresh()
        End With
    End Sub

    Private Sub prvDelete()
        intPos = grdView.FocusedRowHandle
        Dim strUserGroupID As String = grdView.GetDataRow(intPos).Item("UserGroupID")
        Try
            If Not UI.usForm.frmAskQuestion("Hapus User Group ID " & strUserGroupID & " ?") Then Exit Sub
            DL.MasterUser.DeleteUserGroup(strUserGroupID)
            UI.usForm.frmMessageBox(strUserGroupID & " berhasil dihapus ! ")
            pubRefresh()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub prvQuery()
        Try
            grdMain.DataSource = DL.MasterUser.ListUserGroup()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
        'prvSetButton()
    End Sub

    Public Sub pubRefresh(Optional ByVal strSearch As String = "")
        With grdView
            If Not grdView.FocusedValue Is Nothing And strSearch = "" Then
                strSearch = grdView.GetDataRow(grdView.FocusedRowHandle).Item("UserGroupID")
            End If
            prvQuery()
            If grdView.RowCount > 0 Then UI.usForm.GridMoveRow(grdView, "UserGroupID", strSearch)
        End With
    End Sub

#End Region

#Region "Form Handle"

    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
                Case "Delete" : prvDelete()
            End Select
        End If
    End Sub

    Private Sub btnExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        prvQuery()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        grdMain.DataSource = Nothing
    End Sub

    Private Sub grdMain_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdMain.DoubleClick
        If bolLookUp = True Then
            Me.prvGet()
        Else
            prvDetail()
        End If
    End Sub

#End Region


End Class