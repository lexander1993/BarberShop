Imports System.Data.SqlClient

Namespace DL

    Public Class CustQueue

        Public Shared Function ListData() As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "SELECT CustQueueID,CustName,CreatedDate FROM BS_traQueueCust " & vbNewLine & _
                "ORDER BY CustQueueID "
            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function

        Public Shared Sub SaveData(ByVal strCustName As String)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "INSERT INTO BS_traQueueCust(CustQueueID,CustName) " & vbNewLine & _
                    "SELECT (SELECT ISNULL(MAX(CustQueueID),0)+1 FROM BS_traQueueCust),@CustName "

                .Parameters.Add("@CustName", SqlDbType.VarChar).Value = strCustName
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteData(ByVal intCustQueueID As Integer)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "DELETE BS_traQueueCust WHERE CustQueueID=@CustQueueID "

                .Parameters.Add("@CustQueueID", SqlDbType.Int).Value = intCustQueueID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function DownQueue(ByVal intCustQueueID As Integer, ByVal strCustName As String, ByVal dtCreatedDate As DateTime) As Integer
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Dim intNextQueueID As Integer
            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnection()
                With sqlcmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                    "DECLARE @NextQueueID int=(SELECT TOP 1 CustQueueID FROM BS_traQueueCust WHERE CustQueueID > @CustQueueID ORDER BY CustQueueID)  " & vbNewLine & _
                    "IF @NextQueueID IS NULL " & vbNewLine & _
                    "SET @NextQueueID=@CustQueueID " & vbNewLine & _
                     "--Hapus CureentQueue " & vbNewLine & _
                    "DELETE BS_traQueueCust WHERE CustQueueID=@CustQueueID     " & vbNewLine & _
                    "--Update NextQueueID menjadi CureentQueue " & vbNewLine & _
                    "UPDATE BS_traQueueCust SET CustQueueID =@CustQueueID      " & vbNewLine & _
                    "WHERE CustQueueID=@NextQueueID " & vbNewLine & _
                    "--Update CureentQueue menjadi NextQueueID  " & vbNewLine & _
                    "INSERT INTO BS_traQueueCust(CustQueueID,CustName,CreatedDate) " & vbNewLine & _
                    "SELECT @NextQueueID,@CustName,@CreatedDate " & vbNewLine & _
                    "SELECT @NextQueueID AS NextQueueID "

                    .Parameters.Add("@CustQueueID", SqlDbType.Int).Value = intCustQueueID
                    .Parameters.Add("@CustName", SqlDbType.VarChar).Value = strCustName
                    .Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = dtCreatedDate

                    If SQL.bolUseTrans Then .Transaction = SQL.sqlTrans
                End With
                sqlrdData = sqlcmdExecute.ExecuteReader(CommandBehavior.SingleResult)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        intNextQueueID = .Item("NextQueueID")
                    End If
                    .Close()
                End With
                If Not SQL.bolUseTrans Then SQL.CloseConnection()
            Catch ex As Exception
                Throw ex
            End Try
            Return intNextQueueID
        End Function

        Public Shared Function UpQueue(ByVal intCustQueueID As Integer, ByVal strCustName As String, ByVal dtCreatedDate As DateTime) As Integer
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Dim intPrevQueueID As Integer
            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnection()
                With sqlcmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                    "DECLARE @PrevQueueID int=(SELECT TOP 1 CustQueueID FROM BS_traQueueCust WHERE CustQueueID < @CustQueueID ORDER BY CustQueueID DESC)  " & vbNewLine & _
                    "IF @PrevQueueID IS NULL " & vbNewLine & _
                    "SET @PrevQueueID=@CustQueueID " & vbNewLine & _
                    "--Hapus CureentQueue " & vbNewLine & _
                    "DELETE BS_traQueueCust WHERE CustQueueID=@CustQueueID     " & vbNewLine & _
                    "--Update NextQueueID menjadi CureentQueue " & vbNewLine & _
                    "UPDATE BS_traQueueCust SET CustQueueID =@CustQueueID      " & vbNewLine & _
                    "WHERE CustQueueID=@PrevQueueID " & vbNewLine & _
                    "--Update CureentQueue menjadi NextQueueID  " & vbNewLine & _
                    "INSERT INTO BS_traQueueCust(CustQueueID,CustName,CreatedDate) " & vbNewLine & _
                    "SELECT @PrevQueueID,@CustName,@CreatedDate " & vbNewLine & _
                    "SELECT @PrevQueueID AS PrevQueueID "

                    .Parameters.Add("@CustQueueID", SqlDbType.Int).Value = intCustQueueID
                    .Parameters.Add("@CustName", SqlDbType.VarChar).Value = strCustName
                    .Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = dtCreatedDate

                    If SQL.bolUseTrans Then .Transaction = SQL.sqlTrans
                End With
                sqlrdData = sqlcmdExecute.ExecuteReader(CommandBehavior.SingleResult)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        intPrevQueueID = .Item("PrevQueueID")
                    End If
                    .Close()
                End With
                If Not SQL.bolUseTrans Then SQL.CloseConnection()
            Catch ex As Exception
                Throw ex
            End Try
            Return intPrevQueueID
        End Function

        Public Shared Function ListCustInService() As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "SELECT CAST(CustQueueID AS VARCHAR(100)) AS CustNo, CustName FROM BS_traQueueCust ORDER BY CustQueueID  "
            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function


    End Class

End Namespace
