Namespace BL

    Public Class UserAccess

        'Public Shared Function UserList() As DataTable
        '    Return DL.UserAccess.UserList
        'End Function

        Public Shared Function CheckUserLogin(ByVal strUserID As String, ByVal strUserPassword As String) As Boolean
            BL.Server.ServerDefault()
            Dim voUser As New VO.User
            Dim bolLogin As Boolean = False
            voUser = DL.UserAccess.GetDetail(strUserID)
            If PasswordDecrypt(voUser.Password) = strUserPassword Then
                bolLogin = True
            End If
            Return bolLogin
        End Function

        Public Shared Function GetPassword(ByVal strUserID As String) As String
            Return PasswordDecrypt(DL.UserAccess.GetPassword(strUserID))
        End Function

        Public Shared Sub ChangePassword(ByVal strUserID As String, ByVal strCurrenctPassword As String, ByVal strNewPassword As String)
            'mengganti setiap password di masing2 server
                'Dim dtDB As New DataTable
                'dtDB = DL.Server.ServerList

                'For Each drDB As DataRow In dtDB.Rows
                '    DL.SQL.strServer = drDB.Item("Server")
                '    DL.SQL.strDatabase = drDB.Item("DBName")
                '    DL.SQL.strSAID = ""
                '    DL.SQL.strSAPassword = ""
                '    DL.UserAccess.ChangePassword(strUserID, PasswordEncrypt(strNewPassword))
                'Next

                DL.UserAccess.ChangePassword(strUserID, PasswordEncrypt(strNewPassword))

        End Sub

        'Public Shared Function CheckAccess(ByVal strUserID As String, strDelegateUserID As String, ByVal strProgramID As String, ByVal strModuleID As String, ByVal strAccessCode As String) As Boolean

        '    Dim bolAccess As Boolean
        '    Dim strDelegatedUserID As String = ""
        '    bolAccess = DL.UserAccess.CheckAccess(strUserID, strProgramID, strModuleID, strAccessCode)

        '    If Not bolAccess And strDelegatedUserID <> "" Then
        '        bolAccess = DL.UserAccess.CheckAccess(strDelegatedUserID, strProgramID, strModuleID, strAccessCode)
        '    End If

        '    Return bolAccess
        'End Function

        'Private diubah ke Public untuk Kriptografi
        Public Shared Function PasswordDecrypt(ByVal strText As String) As String
            Dim strKey As String
            Dim intI As Integer
            Dim strResult As String = ""
            If Len(strText) < 50 Then Return ""
            strKey = Microsoft.VisualBasic.Right(strText, 50)
            For intI = 1 To Len(strKey)
                If intI > Len(strText) Then
                    strResult &= Chr(255 - Asc(Mid(strKey, intI, 1)))
                ElseIf Mid(strText, intI, 1) = Chr(255 - Asc(Mid(strKey, intI, 1))) Then
                    strResult &= ""
                Else
                    strResult &= Chr(Asc(Mid(strText, intI, 1)) - Asc(Mid(strKey, intI, 1)))
                End If
            Next
            Return strResult
        End Function

        Public Shared Function PasswordEncrypt(ByVal strText As String) As String
            Dim strKey As String = RandomBigString()
            Dim intI As Integer
            Dim strResult As String = ""
            For intI = 1 To Len(strKey)
                If intI <= Len(strText) Then
                    strResult &= Chr(Asc(Mid(strText, intI, 1)) + Asc(Mid(strKey, intI, 1)))
                Else
                    strResult &= Chr(255 - Asc(Mid(strKey, intI, 1)))
                End If
            Next
            strResult &= strKey
            Return strResult
        End Function

        Public Shared Function RandomBigString() As String
            Const Numcharacters As Integer = 50
            Dim intI As Integer
            Dim intRand As Integer
            Dim strText As String = ""
            Dim oRand As New Random
            For intI = 1 To Numcharacters
                intRand = oRand.Next(100)
                If intRand < 15 Then
                    strText &= " "
                ElseIf intRand < 20 Then
                    strText &= Mid("aeiou", oRand.Next(1, 5), 1)
                Else
                    strText &= Chr(oRand.Next(97, 122))
                End If
            Next
            Return strText
        End Function

    End Class

End Namespace
