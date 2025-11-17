Public Class frmMstItem


#Region "Function"
    Private Const _
        cNew = 0, cDetail = 1, cDelete = 2, cRefresh = 4

    Private intPos As Integer

    Private Sub prvSetIcon()
        UI.usForm.SetToolBar(Me, ToolBar, "0,New,1,Detail,2,Delete,4,Refresh")
    End Sub

    Private Sub prvSetButton()
        Dim bolEdit, bolView As Boolean
        bolEdit = DL.MasterUser.IsAccess("MASTER ITEM EDIT")
        bolView = DL.MasterUser.IsAccess("MASTER ITEM VIEW")

        With ToolBar.Buttons
            .Item(cNew).Enabled = bolEdit
            .Item(cDetail).Enabled = IIf(bolEdit, bolEdit, bolView)
            .Item(cDelete).Enabled = bolEdit
        End With
    End Sub

    Private Sub prvSetGrid()
        UI.usForm.SetGrid(grdView, "ItemID", "Item ID", 80, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "ItemName", "Item Name", 150, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "AltName", "Alt Name", 80, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "BeginningPrice", "Beginning Price", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdView, "SellingPrice", "Selling Price", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdView, "Remarks", "Remarks", 150, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "IsBarber", "Is Barber", 100, UI.usDefGrid.gBoolean)
        UI.usForm.SetGrid(grdView, "IsAdd", "Is Add", 70, UI.usDefGrid.gBoolean)
        UI.usForm.SetGrid(grdView, "IsDeleted", "Is Deleted", 100, UI.usDefGrid.gBoolean)
        UI.usForm.SetGrid(grdView, "CreatedBy", "Created By", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "CreatedDate", "Created Date", 130, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdView, "ModifiedBy", "Modified By", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "ModifiedDate", "Modified Date", 130, UI.usDefGrid.gFullDate)
    End Sub

    Private Sub prvNew()
        Dim frmDetail As New frmMstItemDet
        With frmDetail
            .pubIsNew = True
            .pubShowDialog(Me)
        End With
    End Sub

    Private Sub prvDetail()
        intPos = grdView.FocusedRowHandle
        Dim frmDetail As New frmMstItemDet
        With frmDetail
            .pubIsNew = False
            .pubItemID = grdView.GetDataRow(intPos).Item("ItemID")
            .pubShowDialog(Me)
            If .pubIsSave Then pubRefresh()
        End With
    End Sub

    Private Sub prvDelete()
        intPos = grdView.FocusedRowHandle
        Dim strItemID As String = grdView.GetDataRow(intPos).Item("ItemID")
        Dim strItemName As String = grdView.GetDataRow(intPos).Item("ItemName")
        Try
            If Not UI.usForm.frmAskQuestion("Delete Item Name " & strItemName & " ?") Then Exit Sub
            DL.MasterItem.DeleteHeader(strItemID)
            UI.usForm.frmMessageBox(strItemName & " has been deleted ! ")
            pubRefresh()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub prvQuery()
        Try
            grdMain.DataSource = DL.MasterItem.ListData(cbStatus.SelectedIndex)
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
        'prvSetButton()
    End Sub

    Public Sub pubRefresh(Optional ByVal strSearch As String = "")
        With grdView
            If Not grdView.FocusedValue Is Nothing And strSearch = "" Then
                strSearch = grdView.GetDataRow(grdView.FocusedRowHandle).Item("ItemID")
            End If
            prvQuery()
            If grdView.RowCount > 0 Then UI.usForm.GridMoveRow(grdView, "ItemID", strSearch)
        End With
    End Sub

#End Region

#Region "Form Handle"

      Private Sub frmMstItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

    Private Sub btnExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExecute.Click
        prvQuery()
    End Sub

    Private Sub grdMain_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdMain.DoubleClick
        prvDetail()
    End Sub

    'Agar Data Grid View Berwarna
    Private Sub grdView_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles grdView.RowStyle
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
        If (e.RowHandle >= 0) Then
            Dim bolIsDeleted As Boolean = View.GetRowCellValue(e.RowHandle, View.Columns("IsDeleted"))

            If bolIsDeleted = True Then
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.BackColor2 = Color.WhiteSmoke
            End If
        End If
    End Sub

#End Region
End Class