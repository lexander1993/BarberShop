Public Class frmMstUserDet
#Region "Property"

    Private frmParent As frmMstUser
    Private bolNew, bolSave As Boolean
    Private strUserID As String = ""

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

    Public Property pubUserID() As String
        Get
            Return strUserID
        End Get
        Set(ByVal Value As String)
            strUserID = Value
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
        'bolEdit = DL.MasterUser.IsAccess("MASTER USER EDIT")
        bolEdit = True

        With ToolBar.Buttons
            .Item(0).Enabled = bolEdit
        End With
        btnUserGroupID.Enabled = bolEdit
    End Sub

    Private Sub prvSetTitleForm()
        If bolNew Then
            Me.Text += " [new] "
        Else
            Me.Text += " [edit] " & strUserID
        End If
    End Sub

    Private Sub prvFillForm()
        Try
            clsData = DL.MasterUser.GetDetail(strUserID)

            If Not bolNew Then
                txtUserID.Text = strUserID
                txtUserName.Text = clsData.UserName
                cboJenisID.Text = clsData.IDType
                txtNoID.Text = clsData.IDNumber
                txtTempatLahir.Text = clsData.BirthPlace
                dtpTglLahir.Value = clsData.BirthDate
                txtTglLahirStr.Text = clsData.BirthDateStr
                txtAlamat.Text = clsData.Address
                txtNoNPWP.Text = clsData.NPWPNumber
                txtJamsostekID.Text = clsData.JamsostekID
                txtNoHp.Text = clsData.NoHP
                txtUserGroupID.Text = clsData.UserGroupID

                'cboLocationName.DataSource = DL.MasterUser.GetLocation()
                'cboLocationName.ValueMember = "LocationID"
                'cboLocationName.DisplayMember = "LocationName"
                'cboLocationName.Text = clsData.LocationName

                txtJabatan.Text = clsData.UserPosition
                dtpStartWorkingDate.Value = clsData.StartWorkingDate
                cboIsActive.SelectedIndex = IIf(clsData.IsActive = True, 1, 0)
                txtRemarks.Text = clsData.Remarks

                ToolStripCreatedDate.Text = "CREATED DATE : " & Format(clsData.CreatedDate, UI.usDefCons.DateFull)
                ToolStripModifiedDate.Text = "MODIFIED DATE : " & Format(clsData.ModifiedDate, UI.usDefCons.DateFull)
                ToolStripCreatedDate.Visible = True
                ToolStripModifiedDate.Visible = True
                txtUserID.Enabled = False
            Else
                dtpTglLahir.Value = Today
                dtpStartWorkingDate.Value = Today
                cboJenisID.SelectedIndex = 0
                'cboLocationName.DataSource = DL.MasterUser.GetLocation()
                'cboLocationName.ValueMember = "LocationID"
                'cboLocationName.DisplayMember = "LocationName"

                'cboLocationName.SelectedIndex = 0
                cboIsActive.SelectedIndex = 1

            End If
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub


    Private Function ValidateData() As Boolean

        If txtUserID.Text.Trim = "" Then
            UI.usForm.frmMessageBox("User ID harus diisi !")
            txtUserID.Focus()
            Return False
        End If


        If txtUserName.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Username harus diisi !")
            txtUserName.Focus()
            Return False
        End If

        If txtUserGroupID.Text.Trim = "" Then
            UI.usForm.frmMessageBox("User Group ID harus diisi !")
            txtAlamat.Focus()
            Return False
        End If

        If txtJabatan.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Jabatan harus diisi !")
            txtJabatan.Focus()
            Return False
        End If

        'If txtNoID.Text.Trim = "" Then
        '    UI.usForm.frmMessageBox("No ID harus diisi !")
        '    txtNoID.Focus()
        '    Return False
        'End If

        'If txtTempatLahir.Text.Trim = "" Then
        '    UI.usForm.frmMessageBox("Tempat Lahir harus diisi !")
        '    txtTempatLahir.Focus()
        '    Return False
        'End If

        'If dtpTglLahir.Value = Today Then
        '    UI.usForm.frmMessageBox("Tanggal Lahir harus diisi dengan benar")
        '    dtpTglLahir.Focus()
        '    Return False
        'End If

        'If txtAlamat.Text.Trim = "" Then
        '    UI.usForm.frmMessageBox("Alamat harus diisi !")
        '    txtAlamat.Focus()
        '    Return False
        'End If

        'If txtJabatan.Text.Trim = "" Then
        '    UI.usForm.frmMessageBox("Jabatan harus diisi !")
        '    txtJabatan.Focus()
        '    Return False
        'End If

        Return True
    End Function

    Private Sub prvSave()
        txtUserID.Focus()
        If Not ValidateData() Then Exit Sub
        'Simpan Header Notary Order di VO
        clsData.UserID = txtUserID.Text.Trim
        clsData.UserName = txtUserName.Text.Trim
        clsData.IDType = cboJenisID.Text.Trim
        clsData.IDNumber = txtNoID.Text.Trim
        clsData.BirthPlace = txtTempatLahir.Text.Trim
        clsData.BirthDate = dtpTglLahir.Value
        clsData.BirthDateStr = txtTglLahirStr.Text.Trim
        clsData.Address = txtAlamat.Text.Trim
        clsData.NPWPNumber = txtNoNPWP.Text.Trim
        clsData.JamsostekID = txtJamsostekID.Text.Trim
        clsData.NoHP = txtNoHp.Text.Trim

        clsData.LocationName = "" 'cboLocationName.Text.Trim
        clsData.LocationID = "" 'cboLocationName.SelectedValue
        clsData.UserPosition = txtJabatan.Text.Trim
        clsData.StartWorkingDate = dtpStartWorkingDate.Value
        clsData.IsActive = cboIsActive.SelectedIndex
        clsData.Remarks = txtRemarks.Text.Trim
        clsData.UserGroupID = txtUserGroupID.Text.Trim
      
        Try
            'Simpan semua Data Header dan Detail
            DL.MasterUser.SaveData(bolNew, clsData)
            bolSave = True
            If bolNew Then
                UI.usForm.frmMessageBox("Save Success ! User ID : " & txtUserID.Text)
                frmParent.pubRefresh(txtUserID.Text)
                Me.Close()
            Else
                UI.usForm.frmMessageBox("Update Success ! User ID : " & txtUserID.Text)
                frmParent.pubRefresh(txtUserID.Text)
                Me.Close()
            End If
        Catch ex As Exception
            bolSave = False
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    

#End Region

#Region "Form Handle"

    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

    Private Sub dtpTglLahir_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpTglLahir.ValueChanged
        Dim Tanggal, Bulan, Tahun As String
        Tanggal = UI.Terbilang.Terbilang(CDbl(dtpTglLahir.Value.ToString("dd"))).Trim
        Bulan = UI.Terbilang.Bulan(CInt(dtpTglLahir.Value.ToString("MM")))
        Tahun = UI.Terbilang.Terbilang(CDbl(dtpTglLahir.Value.ToString("yyyy"))).Trim

        txtTglLahirStr.Text = dtpTglLahir.Value.ToString("dd-MM-yyyy") & " (" & Tanggal & " " & Bulan & " " & Tahun & ")"

    End Sub

    Private Sub btnUserGroupID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUserGroupID.Click
        Dim frmDetail As New frmMstUserGroup
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                txtUserGroupID.Text = .pubLUDataRow("UserGroupID")
            End If
        End With
    End Sub

#End Region
    
End Class