Imports System.Data.SqlClient

Namespace DL

    Public Class SQL

        Public Shared sqlConn As SqlConnection
        Public Shared sqlTrans As SqlTransaction
        Public Shared strServer, strDatabase As String
        Public Shared strSAID As String = "", strSAPassword As String = ""

        Public Shared bolUseTrans As Boolean = False

        Public Shared Function OpenConnection() As Boolean
            Dim strSqlConnect As String = "Server=" & "LAPTOP-RK2GHE4N\SQLEXPRESS" & ";" &
                                          "DataBase=" & "BS" & ";"
            Dim bolSuccess As Boolean = False

            If strSAID = "" Then
                strSqlConnect += "Trusted_Connection=SSPI;"
            Else
                strSqlConnect += "Trusted_Connection=SSPI;"
                'strSqlConnect += "Trusted_Connection=FALSE;" &
                '                 "User Id=" & strSAID & ";" &
                '                 "Password=" & strSAPassword & ";"
            End If

            Try
                sqlConn = New SqlConnection(strSqlConnect)
                sqlConn.Open()
                bolSuccess = True
            Catch ex As Exception
                Throw ex
            End Try
            Return bolSuccess
        End Function

        Public Shared Function OpenConnectionMaster() As Boolean
            Dim strSqlConnect As String = "Server=" & strServer & ";" & _
                                          "DataBase='master';"
            Dim bolSuccess As Boolean = False

            If strSAID = "" Then
                strSqlConnect += "Trusted_Connection=SSPI;"
            Else
                strSqlConnect += "Trusted_Connection=FALSE;" & _
                                 "User Id=" & strSAID & ";" & _
                                 "Password=" & strSAPassword & ";"
            End If

            Try
                sqlConn = New SqlConnection(strSqlConnect)
                sqlConn.Open()
                bolSuccess = True
            Catch ex As Exception
                Throw ex
            End Try
            Return bolSuccess
        End Function

        Public Shared Sub CloseConnection()
            If sqlConn.State <> ConnectionState.Closed Then sqlConn.Close()
        End Sub

        Public Shared Sub BeginTransaction()
            sqlTrans = sqlConn.BeginTransaction()
            bolUseTrans = True
        End Sub

        Public Shared Sub CommitTransaction()
            sqlTrans.Commit()
            bolUseTrans = False
        End Sub

        Public Shared Sub RollBackTransaction()
            sqlTrans.Rollback()
            bolUseTrans = False
        End Sub

        Public Shared Function QueryDataTable(ByVal sqlcmdExecute As SqlCommand) As DataTable
            Dim sqldapQuery As New SqlDataAdapter
            Dim dtbQuerry As New DataTable
            Try
                If Not bolUseTrans Then OpenConnection()
                With sqlcmdExecute
                    .Connection = sqlConn
                    .CommandTimeout = 300
                    If bolUseTrans Then .Transaction = sqlTrans
                End With
                sqldapQuery.SelectCommand = sqlcmdExecute
                sqldapQuery.Fill(dtbQuerry)
                If Not bolUseTrans Then CloseConnection()
            Catch ex As Exception
                Throw ex
            End Try
            Return dtbQuerry
        End Function

        Public Shared Function QueryDataSet(ByVal sqlcmdExecute As SqlCommand) As DataSet
            Dim sqldapQuery As New SqlDataAdapter
            Dim dtbQuerry As New DataSet
            Try
                If Not bolUseTrans Then OpenConnection()
                With sqlcmdExecute
                    .Connection = sqlConn
                    .CommandTimeout = 300
                    If bolUseTrans Then .Transaction = sqlTrans
                End With
                sqldapQuery.SelectCommand = sqlcmdExecute
                sqldapQuery.Fill(dtbQuerry)
                If Not bolUseTrans Then CloseConnection()
            Catch ex As Exception
                Throw ex
            End Try
            Return dtbQuerry
        End Function

        Public Shared Function ExecuteNonQuery(ByRef sqlcmdExecute As SqlCommand) As Boolean
            Dim bolSuccess As Boolean = False
            Try
                If Not bolUseTrans Then OpenConnection()
                With sqlcmdExecute
                    .Connection = sqlConn
                    .CommandTimeout = 300
                    If bolUseTrans Then .Transaction = sqlTrans
                    .ExecuteNonQuery()
                End With
                If Not bolUseTrans Then CloseConnection()
                bolSuccess = True
            Catch ex As Exception
                Throw ex
            End Try
            Return bolSuccess
        End Function

    End Class

End Namespace