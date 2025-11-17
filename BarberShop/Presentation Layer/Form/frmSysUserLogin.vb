Public Class frmSysUserLogin

#Region "License"

    Private kstrRegSubKeyName As String = "Finder\\FriendFinder" 'The name for the sub-key to store registry info
    Private mintUsedTrialDays As Integer
    Private mintTrialPeriod As Integer = 90 'Days in the trial.
    Private mblnInTrial As Boolean = True
    Private mblnFullVersion As Boolean = False

    Private Structure CurrentDate
        Dim Day As String
        Dim Month As String
        Dim Year As String
    End Structure

    Private Function prvCheckExpiredLicense() As Boolean
        Dim oReg As Microsoft.Win32.RegistryKey
        oReg = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software", True)
        oReg = oReg.CreateSubKey(kstrRegSubKeyName)
        oReg = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\" & kstrRegSubKeyName)
        Dim strOldDay As String = oReg.GetValue("UserSettings", "").ToString
        Dim strOldMonth As String = oReg.GetValue("operatingsystem", "").ToString
        Dim strOldYear As String = oReg.GetValue("GUID", "").ToString
        Dim strRegName As String = oReg.GetValue("USERID", "").ToString
        Dim strRegCode As String = oReg.GetValue("LOCALPATH", "").ToString
        Dim strCompID As String = oReg.GetValue("CompID", "").ToString
        Dim strTrialDone As String = oReg.GetValue("Enable", "").ToString
        oReg.Close()

        Dim strRN As String = Decrypt(UI.usUserApp.SuperAdminPassword, strRegName)

        If strRN Is Nothing Then
            UI.usForm.frmMessageBox("You are not authorized using application. Please contact Programmer for information")
            Return False
        End If

        If strRN <> UI.usUserApp.AdminID Then
            UI.usForm.frmMessageBox("You are not signed as this application User. Please Purchase your License")
            Return False
        End If

        ''If EncryptKeys = True Then
        'strOldDay = Decrypt(UI.usUserApp.SuperAdminPassword, strOldDay)
        'strOldMonth = Decrypt(UI.usUserApp.SuperAdminPassword, strOldMonth)
        'strOldYear = Decrypt(UI.usUserApp.SuperAdminPassword, strOldYear)
        ''End If

        ''Define global variables.
        'mintUsedTrialDays = DiffDate(strOldDay, strOldMonth, strOldYear)

        ''Cek masa expired License
        'Dim Check As Boolean
        'Check = DisplayApplicationStatus(DiffDate(strOldDay, strOldMonth, strOldYear), mintTrialPeriod)
        'Return Check

        ''Disable the continue button if the License is over set enabled 1
        'If DiffDate(strOldDay, strOldMonth, strOldYear) > mintTrialPeriod Then
        '    'unregbutton.Enabled = False
        '    mblnInTrial = False
        '    oReg = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software", True)
        '    oReg = oReg.CreateSubKey(kstrRegSubKeyName)
        '    oReg.SetValue("Enable", "1")
        '    oReg.Close()
        'End If

        ''If the date is earlier than possible, then disable the program.
        'If strOldMonth = "" Then
        'Else
        '    Dim dtmOldDate As Date = New Date(Convert.ToInt32(strOldYear), Convert.ToInt32(strOldMonth), Convert.ToInt32(strOldDay))
        '    If Date.Compare(DateTime.Now, dtmOldDate) < 0 Then
        '        'unregbutton.Enabled = False
        '        mblnInTrial = False
        '        oReg = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software", True)
        '        oReg = oReg.CreateSubKey(kstrRegSubKeyName)
        '        oReg.SetValue("Enable", "1")
        '        oReg.Close()
        '    End If
        'End If


        ''If the trial is done then disable the button
        'If strTrialDone = "1" Then
        '    'unregbutton.Enabled = False
        '    mblnInTrial = False
        '    UI.usForm.frmMessageBox("The system clock has been manually changed, and the application has been locked out to prevent unauthorized access!")
        '    Return False
        'End If

        Return True
    End Function

    Private Function Decrypt(ByRef pPassPhrase As String, ByVal pHexStream As String) As String
        Try
            Dim objSym As New Encryption.Symmetric(Encryption.Symmetric.Provider.Rijndael)
            Dim encryptedData As New Encryption.Data
            encryptedData.Hex = pHexStream
            Dim decryptedData As Encryption.Data
            decryptedData = objSym.Decrypt(encryptedData, New Encryption.Data(pPassPhrase))
            Return decryptedData.Text
        Catch
            Return Nothing
        End Try
    End Function

    Private Function DiffDate(ByVal OrigDay As String, ByVal OrigMonth As String, ByVal OrigYear As String) As Integer
        Try
            Dim D1 As Date = New Date(Convert.ToInt32(OrigYear), Convert.ToInt32(OrigMonth), Convert.ToInt32(OrigDay))
            Return Convert.ToInt32(DateDiff(DateInterval.Day, D1, DateTime.Now))
        Catch
            Return 0
        End Try
    End Function

    Private Function DisplayApplicationStatus(ByVal pDaysUsed As Integer, ByVal pTotalDays As Integer) As Boolean
        'Jika trial di set jadi 0 oleh Developer hrs contact developer
        'If pTotalDays < 0 Then
        '    UI.usForm.frmMessageBox("An error has occurred! Please contact IT Developer about this problem ")
        '    Return False
        'End If

        'Check if the trial is expired
        If pDaysUsed >= pTotalDays Then
            UI.usForm.frmMessageBox("Your License has been expired!")
            Return False
        End If

        'Draw the bar
        If pTotalDays - pDaysUsed < 7 Then
            UI.usForm.frmMessageBox("You have " + (pTotalDays - pDaysUsed).ToString + " days remaining in your License period. " & vbCrLf & "Please contact IT Developer. ")
        End If

        Return True
    End Function

#End Region

    Private Sub prvCheckUserPassword()
        'If Not prvCheckExpiredLicense() Then Exit Sub

        If txtUserID.Text.Trim = "" Then
            UI.usForm.frmMessageBox("User ID Cannot Blank ... ")
            txtUserID.Focus()
            Exit Sub
        End If
        If txtUserPassword.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Password Cannot Blank ... ")
            txtUserPassword.Focus()
            Exit Sub
        End If

        'If Format(Now, "yyyyMMddHHmm") >= "201310112100" Then
        '    UI.usForm.frmMessageBox("CPS tidak dapat dipergunakan..." & vbCrLf & "Sedang dilakukan maintenance server." & vbCrLf & "Estimasi dapat dipergunakan kembali pada tanggal 12 Oktober 2013 jam 09:00 WIB.")
        '    Exit Sub
        'End If

        Dim strUserID As String = txtUserID.Text.Trim

        If strUserID.IndexOf("@") > 0 Then
            UI.usUserApp.UserID = strUserID.Substring(0, strUserID.IndexOf("@"))
        Else
            UI.usUserApp.UserID = txtUserID.Text.Trim
        End If

        If BL.UserAccess.CheckUserLogin(UI.usUserApp.UserID, txtUserPassword.Text.Trim) Then
            frmMain.Show()
            Me.Hide()
        ElseIf txtUserID.Text = UI.usUserApp.SuperAdminID And txtUserPassword.Text = UI.usUserApp.SuperAdminPassword Then
            frmMain.Show()
            Me.Hide()
        Else
            UI.usForm.frmMessageBox("User Login Failed ... ")
            txtUserPassword.Text = ""
            txtUserPassword.Focus()
        End If
    End Sub

#Region "Form Handle"

    Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtUserPassword.CharacterCasing = CharacterCasing.Normal
        lblVersion.Text = UI.usUserApp.AppVersion

        Dim strXML As String = Application.StartupPath & "\BARBERSHOP-CONFIG.XML"
        If Not IO.File.Exists(strXML) Then
            UI.usForm.frmMessageBox("XML File Not Found ... ")
            Exit Sub
        End If
        Dim xmlHandle As New usXML(strXML)
        With xmlHandle
            VO.DefaultServer.Server = .GetConfigInfo("CONNECTION", "SERVER", ".").Item(1)
            VO.DefaultServer.Database = .GetConfigInfo("CONNECTION", "DATABASE", ".").Item(1)
            UI.usUserApp.AdminID = .GetConfigInfo("CONNECTION", "ADMINID", ".").Item(1)
            UI.usUserApp.BackupLocation = .GetConfigInfo("CONNECTION", "BACKUPLOCATION", ".").Item(1)
            UI.usUserApp.CompanyName = .GetConfigInfo("CONNECTION", "COMPANYNAME", ".").Item(1)
            UI.usUserApp.CompanyAddress = .GetConfigInfo("CONNECTION", "COMPANYADDRESS", ".").Item(1)
            UI.usUserApp.PrintPayment = .GetConfigInfo("CONNECTION", "PRINTPAYMENT", ".").Item(1)
        End With
    End Sub

    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then prvCheckUserPassword()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        prvCheckUserPassword()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Application.Exit()
    End Sub

#End Region


End Class

