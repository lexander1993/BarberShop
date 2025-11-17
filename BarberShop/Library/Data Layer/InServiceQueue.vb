Imports System.Data.SqlClient

Namespace DL

    Public Class InServiceQueue

        Public Shared Function ListData(ByVal dtDateFrom As DateTime, ByVal dtDateTo As DateTime) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "SELECT ServiceID,StylistUserID,CustName,CheckInDate,CheckOutDate,IsCekOut,IsPaid,IsDeleted FROM BS_traQueueInService " & vbNewLine & _
                "WHERE CONVERT(VARCHAR(8),CheckInDate,112)>=CONVERT(VARCHAR(8),@DateFrom,112) " & vbNewLine & _
                "AND CONVERT(VARCHAR(8),CheckInDate,112)<=CONVERT(VARCHAR(8),@DateTo,112) " & vbNewLine & _
                "ORDER BY ServiceID DESC "

                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtDateTo
            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function

        Public Shared Sub SaveData(ByVal strStylistUserID As String, ByVal strCustName As String)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "DECLARE @LastVal varchar(20), @i as int, @ID varchar(20) " & vbNewLine & _
                "SET @LastVal=(SELECT MAX(ServiceID) FROM BS_traQueueInService WHERE ServiceID LIKE 'S'+SUBSTRING(CONVERT(VARCHAR(8),GETDATE(),112),3,6) + '%') " & vbNewLine & _
                "IF @LastVal IS NULL SET @LastVal= 'S'+SUBSTRING(CONVERT(VARCHAR(8),GETDATE(),112),3,6)+'000' " & vbNewLine & _
                "SET @i=RIGHT(@LastVal,3)+1 " & vbNewLine & _
                "SET @ID='S'+SUBSTRING(CONVERT(VARCHAR(8),GETDATE(),112),3,6)+RIGHT('00'+CONVERT(VARCHAR(10),@i),3) " & vbNewLine & _
                " " & vbNewLine & _
                "INSERT BS_traQueueInService(ServiceID,StylistUserID,CustName,CheckInDate) " & vbNewLine & _
                "VALUES (@ID,@StylistUserID,@CustName,GETDATE()) "

                .Parameters.Add("@StylistUserID", SqlDbType.VarChar).Value = strStylistUserID
                .Parameters.Add("@CustName", SqlDbType.VarChar).Value = strCustName
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try


        End Sub

        Public Shared Sub DeleteData(ByVal strServiceQueueID As String)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "UPDATE BS_traQueueInService SET IsDeleted=1 WHERE ServiceID=@ServiceID "

                .Parameters.Add("@ServiceID", SqlDbType.VarChar).Value = strServiceQueueID
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
                "SELECT CustName FROM BS_traQueueCust ORDER BY CustQueueID  "
            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function

        Public Shared Sub UpdateIsCekOut(ByVal strServiceID As String)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "UPDATE BS_traQueueInService SET CheckOutDate=GETDATE(), IsCekOut=1 WHERE ServiceID=@ServiceID "

                .Parameters.Add("@ServiceID", SqlDbType.VarChar).Value = strServiceID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub UpdateIsPaid(ByVal strServiceID As String)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "UPDATE BS_traQueueInService SET IsPaid=1 WHERE ServiceID=@ServiceID "

                .Parameters.Add("@ServiceID", SqlDbType.VarChar).Value = strServiceID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

    End Class

End Namespace
