Imports System.Data.SqlClient

Namespace DL

    Public Class UserAccess

        Public Shared aRight(,) As String

        Public Shared Function GetDetail(ByVal strUserID As String) As VO.User
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Dim voUser As New VO.User
            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnection()
                With sqlcmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                        "SELECT TOP 1 " & _
                        "   UserID,UserName,Password " & _
                        "FROM BS_mstUser " & _
                        "WHERE UserID=@UserID "

                    .Parameters.Add("@UserID", SqlDbType.VarChar, 20).Value = strUserID
                    If SQL.bolUseTrans Then .Transaction = SQL.sqlTrans
                End With
                sqlrdData = sqlcmdExecute.ExecuteReader(CommandBehavior.SingleRow)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        voUser.ID = .Item("UserID")
                        voUser.Name = .Item("UserName")
                        voUser.Password = .Item("Password")
                    Else
                        voUser.ID = ""
                        voUser.Name = ""
                        voUser.Password = ""
                    End If
                    .Close()
                End With
                If Not SQL.bolUseTrans Then SQL.CloseConnection()
            Catch ex As Exception
                Throw (ex)
            End Try
            Return voUser
        End Function

        Public Shared Function GetPassword(ByVal strUserID As String) As String
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Dim strPassword As String = ""
            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnection()
                With sqlcmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                        "SELECT TOP 1  " & _
                        "   Password " & _
                        "FROM BS_mstUser " & _
                        "WHERE " & _
                        "   UserID=@UserID "

                    .Parameters.Add("@UserID", SqlDbType.VarChar, 20).Value = strUserID
                    If SQL.bolUseTrans Then .Transaction = SQL.sqlTrans
                End With
                sqlrdData = sqlcmdExecute.ExecuteReader(CommandBehavior.SingleRow)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        strPassword = .Item("Password")
                    End If
                    .Close()
                End With
                If Not SQL.bolUseTrans Then SQL.CloseConnection()
            Catch ex As Exception
                Throw ex
            End Try
            Return strPassword
        End Function

        Public Shared Sub ChangePassword(ByVal strUserID As String, ByVal strNewPassword As String)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "UPDATE BS_mstUser SET " & _
                    "   Password=@NewPassword " & _
                    "WHERE " & _
                    "   UserID=@UserID "

                .Parameters.Add("@UserID", SqlDbType.VarChar, 20).Value = strUserID
                .Parameters.Add("@NewPassword", SqlDbType.VarChar, 100).Value = strNewPassword
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

      
    End Class

End Namespace
