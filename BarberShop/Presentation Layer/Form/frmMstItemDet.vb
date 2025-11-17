Public Class frmMstItemDet

#Region "Property"

    Private frmParent As frmMstItem
    Private bolNew, bolSave As Boolean
    Private strItemID As String = ""

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

    Public Property pubItemID() As String
        Get
            Return strItemID
        End Get
        Set(ByVal Value As String)
            strItemID = Value
        End Set
    End Property

#End Region


#Region "Function"

    Private Const _
       cSave = 0, cExit = 1

    Private clsData As New VO.MasterItem

    Public Sub pubShowDialog(ByVal frmGetParent As Form)
        frmParent = frmGetParent
        Me.ShowDialog()
    End Sub

    Private Sub prvSetIcon()
        UI.usForm.SetToolBar(Me, ToolBar, "0,Save,1,Close")
    End Sub

    Private Sub prvSetButton()
        Dim bolEdit As Boolean
        bolEdit = DL.MasterUser.IsAccess("MASTER ITEM EDIT")

        With ToolBar.Buttons
            .Item(0).Enabled = bolEdit
        End With
    End Sub

    Private Sub prvSetTitleForm()
        If bolNew Then
            Me.Text += " [new] "
        Else
            Me.Text += " [edit] " & strItemID
        End If
    End Sub

    Private Sub prvFillForm()
        Try

            If Not bolNew Then
                clsData = DL.MasterItem.GetDetail(strItemID)
                txtItemID.Text = strItemID
                txtItemName.Text = clsData.ItemName
                txtAltName.Text = clsData.AltName
                numBeginningPrice.EditValue = clsData.BeginningPrice
                numSellingPrice.EditValue = clsData.SellingPrice
                txtRemarks.Text = clsData.Remarks
                chkIsBarber.Checked = clsData.IsBarber
                chkIsAdd.Checked = clsData.IsAdd
            Else
                txtItemID.Text = DL.MasterItem.ItemAutoNumber
            End If
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Function ValidateData() As Boolean
        If txtItemName.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Item Name harus diisi !")
            txtItemName.Focus()
            Return False
        End If

        If numSellingPrice.EditValue <= numBeginningPrice.EditValue Then
            UI.usForm.frmMessageBox("Selling Price harus lebih besar dari Beginning Price !")
            numSellingPrice.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub prvSave()
        If Not ValidateData() Then Exit Sub

        clsData.ItemID = txtItemID.Text.Trim
        clsData.ItemName = txtItemName.Text.Trim
        clsData.AltName = txtAltName.Text.Trim
        clsData.BeginningPrice = numBeginningPrice.EditValue
        clsData.SellingPrice = numSellingPrice.EditValue
        clsData.Remarks = txtRemarks.Text.Trim
        clsData.IsBarber = chkIsBarber.Checked
        clsData.IsAdd = chkIsAdd.Checked
        Try
            DL.MasterItem.SaveData(bolNew, clsData)
            bolSave = True
            If bolNew Then
                UI.usForm.frmMessageBox("Save Success ! Item Name : " & txtItemName.Text)
                frmParent.pubRefresh(txtItemID.Text)
                Me.Close()
            Else
                UI.usForm.frmMessageBox("Update Success ! Item Name : " & txtItemName.Text)
                frmParent.pubRefresh(txtItemID.Text)
                Me.Close()
            End If
        Catch ex As Exception
            bolSave = False
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub frmMstItemDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        prvSetIcon()
        prvSetTitleForm()
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

#End Region


End Class