Public Class frmMstUserGroupDet
#Region "Property"

    Private frmParent As frmMstUserGroup
    Private bolNew, bolSave As Boolean
    Private strUserGroupID As String = "", strRemarks As String = ""

    Public WriteOnly Property pubIsNew() As Boolean
        Set(ByVal Value As Boolean)
            bolNew = Value
        End Set
    End Property

    Public ReadOnly Property pubIsSave() As Boolean
        Get
            Return bolSave
        End Get
    End Property

    Public Property pubUserGroupID() As String
        Get
            Return strUserGroupID
        End Get
        Set(ByVal Value As String)
            strUserGroupID = Value
        End Set
    End Property

    Public Property pubRemarks() As String
        Get
            Return strRemarks
        End Get
        Set(ByVal Value As String)
            strRemarks = Value
        End Set
    End Property

#End Region

#Region "Function"

    Private Const _
       cSave = 0, cExit = 1

    Private clsData As New VO.MasterUser

    Public Sub pubShowDialog(ByVal frmGetParent As Form)
        frmParent = frmGetParent
        Me.ShowDialog()
    End Sub

    Private Sub prvSetIcon()
        UI.usForm.SetToolBar(Me, ToolBar, "0,Save,1,Close")
    End Sub

    Private Sub prvSetButton()
        Dim bolEdit As Boolean
        bolEdit = DL.MasterUser.IsAccess("MASTER USER GROUP EDIT")

        With ToolBar.Buttons
            .Item(0).Enabled = bolEdit
        End With
    End Sub

    Private Sub prvSetTitleForm()
        If bolNew Then
            Me.Text += " [new] "
        Else
            Me.Text += " [edit] " & strUserGroupID
        End If
    End Sub

    Private Sub prvSetGrid()
        UI.usForm.SetGrid(grdItemView, "Pick", "Pick", 80, UI.usDefGrid.gBoolean, True, False)

        UI.usForm.SetGrid(grdItemView, "MenuID", "Menu ID", 210, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "Remarks", "Remarks", 280, UI.usDefGrid.gString)
    End Sub

    Private Sub prvFillForm()
        Try
            If Not bolNew Then
                txtUserGroupID.Text = strUserGroupID
                txtUserGroupID.ReadOnly = True
                txtRemarks.Text = strRemarks
            End If

            grdMenu.DataSource = DL.MasterUser.ListUserGroupMenuDet(txtUserGroupID.Text)

        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub


    Private Function ValidateData() As Boolean

        If txtUserGroupID.Text.Trim = "" Then
            UI.usForm.frmMessageBox("User Group ID harus diisi !")
            txtUserGroupID.Focus()
            Return False
        End If

       
        Return True
    End Function

    Private Sub prvSave()
        txtUserGroupID.Focus()
        If Not ValidateData() Then Exit Sub

        clsData.UserGroupID = txtUserGroupID.Text.Trim
        clsData.Remarks = txtRemarks.Text.Trim

        Dim dtTable As DataTable = grdMenu.DataSource
        dtTable.AcceptChanges()

        Dim dv As New DataView(dtTable)
        dv.RowFilter = "Pick = True"

        If dv.Count = 0 Then
            UI.usForm.frmMessageBox("Pilih Menu ID!")
            Exit Sub
        End If

        Dim clsDataMenu As VO.MasterUser
        Dim clsDataAllMenu() As VO.MasterUser
        ReDim clsDataAllMenu(dv.Count - 1)
        Dim intPos1 As Integer = 0
        For Each drData1 As DataRowView In dv
            clsDataMenu = New VO.MasterUser
            clsDataMenu.MenuID = drData1.Item("MenuID")
            clsDataAllMenu(intPos1) = clsDataMenu
            intPos1 += 1
        Next

        Try
            DL.MasterUser.SaveMasterUserGroup(bolNew, clsData, clsDataAllMenu)
            bolSave = True
            If bolNew Then
                UI.usForm.frmMessageBox("Save Success ! User Group ID : " & txtUserGroupID.Text)
                frmParent.pubRefresh(txtUserGroupID.Text)
                Me.Close()
            Else
                UI.usForm.frmMessageBox("Update Success ! User Group ID : " & txtUserGroupID.Text)
                frmParent.pubRefresh(txtUserGroupID.Text)
                Me.Close()
            End If
        Catch ex As Exception
            bolSave = False
            UI.usForm.frmMessageBox("Pilih nama User Group ID yang berbeda!")
            txtUserGroupID.Focus()
        End Try
    End Sub



#End Region

#Region "Form Handle"

    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        prvSetIcon()
        prvSetTitleForm()
        prvSetGrid()
        prvFillForm()
        prvSetButton()
    End Sub


    Private Sub ToolBar_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        If e.Button.Text = "Save" Then
            prvSave()
        Else
            Me.Close()
        End If
    End Sub

    Private Sub chkAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAll.CheckedChanged
        Dim intI As Integer
        For intI = 0 To grdItemView.RowCount - 1
            If chkAll.Checked Then
                grdItemView.SetRowCellValue(intI, "Pick", True)
            Else
                grdItemView.SetRowCellValue(intI, "Pick", False)
            End If
        Next
    End Sub

#End Region


End Class