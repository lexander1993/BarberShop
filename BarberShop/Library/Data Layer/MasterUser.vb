Imports System.Data.SqlClient

Namespace DL

    Public Class MasterUser

        Public Shared Function ListData(ByVal intIsActive As Integer) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "SELECT LocationID, UserID, LocationName, UserName, UserPosition, BirthPlace, BirthDate, Address, " & _
                    "IDType, IDNumber, NPWPNumber, JamsostekID, NoHP, Remarks, StartWorkingDate, CreatedDate, ModifiedDate, IsActive, UserGroupID " & _
                    "FROM BS_mstUser "

                If intIsActive <> 2 Then
                    .CommandText += " WHERE IsActive=@IsActive "
                End If

                .Parameters.Add("@IsActive", SqlDbType.Bit).Value = intIsActive
            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function

        Public Shared Function GetDetail(ByVal strUserID As String) As VO.MasterUser
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Dim clsReturn As New VO.MasterUser
            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnection()
                With sqlcmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                    "SELECT LocationID, UserID, LocationName, UserName, UserPosition, BirthPlace, BirthDate, Address, " & _
                    "IDType, IDNumber, NPWPNumber, JamsostekID, NoHP, Remarks, StartWorkingDate, CreatedDate, ModifiedDate, IsActive, UserGroupID " & _
                    "FROM BS_mstUser " & _
                    "WHERE UserID=@UserID "

                    .Parameters.Add("@UserID", SqlDbType.VarChar).Value = strUserID

                    If SQL.bolUseTrans Then .Transaction = SQL.sqlTrans
                End With
                sqlrdData = sqlcmdExecute.ExecuteReader(CommandBehavior.SingleResult)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        clsReturn.LocationID = .Item("LocationID")
                        clsReturn.UserID = .Item("UserID")
                        clsReturn.LocationName = .Item("LocationName")
                        clsReturn.UserName = .Item("UserName")
                        clsReturn.UserPosition = .Item("UserPosition")
                        clsReturn.BirthPlace = .Item("BirthPlace")
                        clsReturn.BirthDate = .Item("BirthDate")
                        clsReturn.Address = .Item("Address")
                        clsReturn.IDType = .Item("IDType")
                        clsReturn.IDNumber = .Item("IDNumber")
                        clsReturn.NPWPNumber = .Item("NPWPNumber")
                        clsReturn.JamsostekID = .Item("JamsostekID")
                        clsReturn.NoHP = .Item("NoHP")
                        clsReturn.Remarks = .Item("Remarks")
                        clsReturn.StartWorkingDate = .Item("StartWorkingDate")
                        clsReturn.CreatedDate = .Item("CreatedDate")
                        clsReturn.ModifiedDate = .Item("ModifiedDate")
                        clsReturn.IsActive = .Item("IsActive")
                        clsReturn.UserGroupID = .Item("UserGroupID")

                    End If
                    .Close()
                End With
                If Not SQL.bolUseTrans Then SQL.CloseConnection()
            Catch ex As Exception
                Throw ex
            End Try
            Return clsReturn
        End Function

        'abcde adalah Password Default
        Public Shared Sub SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.MasterUser)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                If bolNew Then

                    If DL.MasterUser.CheckValidUserID(clsData.UserID) Then
                        Err.Raise(515, "", "User ID sudah terdaftar di Master User. Pilih User ID lain. ")
                    End If

                    .CommandText = _
                        "INSERT INTO BS_mstUser (LocationID, UserID, LocationName, UserName, Password, UserPosition, BirthPlace, BirthDate, Address, " & _
                        "IDType, IDNumber, NPWPNumber, JamsostekID, NoHP, Remarks, StartWorkingDate, IsActive, UserGroupID) " & _
                        "VALUES (@LocationID, @UserID, @LocationName, @UserName, @Password, @UserPosition, @BirthPlace, @BirthDate, @Address, " & _
                        "@IDType, @IDNumber, @NPWPNumber, @JamsostekID, @NoHP, @Remarks, @StartWorkingDate, @IsActive, @UserGroupID) "
                Else
                    .CommandText = _
                        "UPDATE BS_mstUser SET " & _
                        "   LocationID=@LocationID, LocationName=@LocationName, UserName=@UserName, UserPosition=@UserPosition, BirthPlace=@BirthPlace, BirthDate=@BirthDate, Address=@Address, " & _
                        "   IDType=@IDType, IDNumber=@IDNumber, NPWPNumber=@NPWPNumber, JamsostekID=@JamsostekID, NoHP=@NoHP, Remarks=@Remarks, StartWorkingDate=@StartWorkingDate, IsActive=@IsActive, " & _
                        "   ModifiedDate=GETDATE(), UserGroupID=@UserGroupID " & _
                        "WHERE UserID=@UserID "
                End If

                .Parameters.Add("@LocationID", SqlDbType.VarChar).Value = clsData.LocationID
                .Parameters.Add("@UserID", SqlDbType.VarChar).Value = clsData.UserID
                .Parameters.Add("@LocationName", SqlDbType.VarChar).Value = clsData.LocationName
                .Parameters.Add("@UserName", SqlDbType.VarChar).Value = clsData.UserName
                .Parameters.Add("@Password", SqlDbType.VarChar).Value = BL.UserAccess.PasswordEncrypt("abcde")
                .Parameters.Add("@UserPosition", SqlDbType.VarChar).Value = clsData.UserPosition
                .Parameters.Add("@BirthPlace", SqlDbType.VarChar).Value = clsData.BirthPlace
                .Parameters.Add("@BirthDate", SqlDbType.DateTime).Value = clsData.BirthDate
                .Parameters.Add("@Address", SqlDbType.VarChar).Value = clsData.Address
                .Parameters.Add("@IDType", SqlDbType.VarChar).Value = clsData.IDType.ToUpper
                .Parameters.Add("@IDNumber", SqlDbType.VarChar).Value = clsData.IDNumber
                .Parameters.Add("@NPWPNumber", SqlDbType.VarChar).Value = clsData.NPWPNumber
                .Parameters.Add("@JamsostekID", SqlDbType.VarChar).Value = clsData.JamsostekID
                .Parameters.Add("@NoHP", SqlDbType.VarChar).Value = clsData.NoHP
                .Parameters.Add("@Remarks", SqlDbType.VarChar).Value = clsData.Remarks
                .Parameters.Add("@StartWorkingDate", SqlDbType.DateTime).Value = clsData.StartWorkingDate
                .Parameters.Add("@IsActive", SqlDbType.Int).Value = clsData.IsActive
                .Parameters.Add("@UserGroupID", SqlDbType.VarChar).Value = clsData.UserGroupID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteHeader(ByVal strUserID As String)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "DELETE BS_mstUser WHERE UserID=@UserID "

                .Parameters.Add("@UserID", SqlDbType.VarChar).Value = strUserID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function CheckValidUserID(ByVal strUserID As String) As Boolean
            Dim bolValid As Boolean = False
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnection()
                With sqlcmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                        "SELECT TOP 1 1 AS Result " & _
                        "FROM BS_mstUser " & _
                        "WHERE UserID=@UserID "

                    .Parameters.Add("@UserID", SqlDbType.VarChar).Value = strUserID

                    If SQL.bolUseTrans Then .Transaction = SQL.sqlTrans
                End With
                sqlrdData = sqlcmdExecute.ExecuteReader(CommandBehavior.SingleRow)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        bolValid = .Item("Result")
                    End If
                    .Close()
                End With
                If Not SQL.bolUseTrans Then SQL.CloseConnection()
            Catch ex As Exception
                Throw ex
            End Try
            Return bolValid
        End Function

        Public Shared Function GetAccessRigt() As UI.usUserApp
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Dim clsReturn As New UI.usUserApp
            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnection()
                With sqlcmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                        "SELECT LocationID FROM BS_mstUser " & _
                        "WHERE UserID =@UserID "

                    .Parameters.Add("@UserID", SqlDbType.VarChar).Value = UI.usUserApp.UserID

                    If SQL.bolUseTrans Then .Transaction = SQL.sqlTrans
                End With
                sqlrdData = sqlcmdExecute.ExecuteReader(CommandBehavior.SingleResult)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        UI.usUserApp.LocationID = .Item("LocationID")
                    End If
                    .Close()
                End With
                If Not SQL.bolUseTrans Then SQL.CloseConnection()
            Catch ex As Exception
                Throw ex
            End Try
            Return clsReturn
        End Function

        Public Shared Function GetLocation() As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "SELECT LocationID, LocationName FROM BS_mstUserLocation "
            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function

        Public Shared Function ListUserGroup() As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "SELECT UserGroupID, Remarks, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate FROM BS_mstUserGroup "
            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function

        Public Shared Sub DeleteUserGroup(ByVal strUserGroupID As String)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "DELETE BS_mstUserGroup WHERE UserGroupID=@UserGroupID " & _
                    "DELETE BS_mstUserGroupDet WHERE UserGroupID=@UserGroupID "

                .Parameters.Add("@UserGroupID", SqlDbType.VarChar).Value = strUserGroupID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function ListUserGroupMenuDet(ByVal strUserGroupID As String) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "SELECT A.MenuID, Remarks, CAST( CASE WHEN B.MenuID IS NULL THEN 0 ELSE 1 END AS BIT) AS Pick FROM BS_MstUserMenu A  " & _
                "LEFT JOIN BS_mstUserGroupDet B ON A.MenuID=B.MenuID AND B.UserGroupID =@UserGroupID " & _
                "ORDER BY A.SortNumber "

                .Parameters.Add("@UserGroupID", SqlDbType.VarChar).Value = strUserGroupID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function

        Public Shared Sub SaveMasterUserGroup(ByVal bolNew As Boolean, ByVal clsData As VO.MasterUser, ByVal clsMenu() As VO.MasterUser)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                If bolNew Then
                    .CommandText = _
                        "INSERT INTO BS_mstUserGroup (UserGroupID, Remarks, CreatedBy) " & _
                        "VALUES (@UserGroupID, @Remarks, @Admin)"
                Else
                    .CommandText = _
                        "UPDATE BS_mstUserGroup SET Remarks=@Remarks, ModifiedBy=@Admin, ModifiedDate=GETDATE() WHERE UserGroupID=@UserGroupID " & _
                        "DELETE BS_mstUserGroupDet WHERE UserGroupID=@UserGroupID "
                End If

                .Parameters.Add("@UserGroupID", SqlDbType.VarChar).Value = clsData.UserGroupID
                .Parameters.Add("@Remarks", SqlDbType.VarChar).Value = clsData.Remarks
                .Parameters.Add("@Admin", SqlDbType.VarChar).Value = UI.usUserApp.UserID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try

            'Save User Group Detail
            Dim intI As Integer = 1
            For Each DataItem As VO.MasterUser In clsMenu
                DL.MasterUser.SaveMenu(clsData.UserGroupID, DataItem)
                intI += 1
            Next
        End Sub

        Public Shared Sub SaveMenu(ByVal strUserGroupID As String, ByVal clsData As VO.MasterUser)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "INSERT INTO BS_mstUserGroupDet (UserGroupID, MenuID) " & _
                "VALUES (@UserGroupID, @MenuID) "

                .Parameters.Add("@UserGroupID", SqlDbType.VarChar).Value = strUserGroupID
                .Parameters.Add("@MenuID", SqlDbType.VarChar).Value = clsData.MenuID

            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function IsAccess(ByVal strMenuID As String) As Boolean
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Dim bolAccess As Boolean
            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnection()
                With sqlcmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                    "SELECT TOP 1 1 AS Result FROM BS_mstUser A " & _
                    "INNER JOIN BS_mstUserGroupDet B ON A.UserGroupID=B.UserGroupID  " & _
                    "WHERE A.UserID=@UserID AND B.MenuID=@MenuID "

                    .Parameters.Add("@MenuID", SqlDbType.VarChar).Value = strMenuID
                    .Parameters.Add("@UserID", SqlDbType.VarChar).Value = UI.usUserApp.UserID

                    If SQL.bolUseTrans Then .Transaction = SQL.sqlTrans
                End With
                sqlrdData = sqlcmdExecute.ExecuteReader(CommandBehavior.SingleResult)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        bolAccess = .Item("Result")
                    End If
                    .Close()
                End With
                If Not SQL.bolUseTrans Then SQL.CloseConnection()
            Catch ex As Exception
                Throw ex
            End Try
            Return bolAccess
        End Function

    End Class

End Namespace
