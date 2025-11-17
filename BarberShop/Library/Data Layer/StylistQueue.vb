Imports System.Data.SqlClient

Namespace DL

    Public Class StylistQueue

        Public Shared Function ListData() As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "SELECT StylistQueueID,StylistUserID,CreatedDate,IsAvailable FROM BS_traQueueStylist     " & vbNewLine & _
                "ORDER BY StylistQueueID, IsAvailable DESC "

            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function

        Public Shared Sub SaveData(ByVal strStylistUserID As String)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "INSERT INTO BS_traQueueStylist(StylistQueueID,StylistUserID) " & vbNewLine & _
                    "SELECT (SELECT ISNULL(MAX(StylistQueueID),0)+1 FROM BS_traQueueStylist),@StylistUserID "

                .Parameters.Add("@StylistUserID", SqlDbType.VarChar).Value = strStylistUserID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteData(ByVal intStylistQueueID As Integer)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "DELETE BS_traQueueStylist WHERE StylistQueueID=@StylistQueueID "

                .Parameters.Add("@StylistQueueID", SqlDbType.Int).Value = intStylistQueueID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub MoveBackQueue(ByVal strStylistUserID As String)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "DECLARE @Max as int " & vbNewLine & _
                "SET @Max=(SELECT ISNULL(MAX(StylistQueueID),0)+1  FROM BS_traQueueStylist) " & vbNewLine & _
                "UPDATE BS_traQueueStylist SET StylistQueueID=@Max " & vbNewLine & _
                "WHERE StylistUserID=@StylistUserID "

                .Parameters.Add("@StylistUserID", SqlDbType.VarChar).Value = strStylistUserID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub MoveBehindAvailableQueue(ByVal strStylistUserID As String)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "DECLARE @Max as int, @CreatedDate datetime    " & vbNewLine & _
                "SET @Max=(SELECT ISNULL(MAX(StylistQueueID),0)+1  FROM BS_traQueueStylist WHERE IsAvailable=1)     " & vbNewLine & _
                "SET @CreatedDate=(SELECT CreatedDate  FROM BS_traQueueStylist WHERE StylistUserID=@StylistUserID )     " & vbNewLine & _
                "DELETE FROM BS_traQueueStylist WHERE StylistUserID=@StylistUserID  " & vbNewLine & _
                "UPDATE BS_traQueueStylist SET StylistQueueID=StylistQueueID+1     " & vbNewLine & _
                "WHERE StylistQueueID>=@Max  " & vbNewLine & _
                "INSERT BS_traQueueStylist(StylistQueueID,StylistUserID,CreatedDate,IsAvailable) " & vbNewLine & _
                "VALUES (@Max,@StylistUserID,@CreatedDate,1) "


                .Parameters.Add("@StylistUserID", SqlDbType.VarChar).Value = strStylistUserID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub


        Public Shared Function DownQueue(ByVal intStylistQueueID As Integer, ByVal strStylistUserID As String, ByVal dtCreatedDate As DateTime) As Integer
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Dim intNextQueueID As Integer
            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnection()
                With sqlcmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                    "DECLARE @NextQueueID int=(SELECT TOP 1 StylistQueueID FROM BS_traQueueStylist WHERE StylistQueueID > @StylistQueueID ORDER BY StylistQueueID)  " & vbNewLine & _
                    "IF @NextQueueID IS NULL " & vbNewLine & _
                    "SET @NextQueueID=@StylistQueueID " & vbNewLine & _
                    "--Hapus CureentQueue " & vbNewLine & _
                    "DELETE BS_traQueueStylist WHERE StylistQueueID=@StylistQueueID     " & vbNewLine & _
                    "--Update NextQueueID menjadi CureentQueue " & vbNewLine & _
                    "UPDATE BS_traQueueStylist SET StylistQueueID =@StylistQueueID      " & vbNewLine & _
                    "WHERE StylistQueueID=@NextQueueID " & vbNewLine & _
                    "--Update CureentQueue menjadi NextQueueID  " & vbNewLine & _
                    "INSERT INTO BS_traQueueStylist(StylistQueueID,StylistUserID,CreatedDate) " & vbNewLine & _
                    "SELECT @NextQueueID,@StylistUserID,@CreatedDate " & vbNewLine & _
                    "SELECT @NextQueueID AS NextQueueID "

                    .Parameters.Add("@StylistQueueID", SqlDbType.Int).Value = intStylistQueueID
                    .Parameters.Add("@StylistUserID", SqlDbType.VarChar).Value = strStylistUserID
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

        Public Shared Function UpQueue(ByVal intStylistQueueID As Integer, ByVal strStylistUserID As String, ByVal dtCreatedDate As DateTime) As Integer
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Dim intPrevQueueID As Integer
            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnection()
                With sqlcmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                    "DECLARE @PrevQueueID int=(SELECT TOP 1 StylistQueueID FROM BS_traQueueStylist WHERE StylistQueueID < @StylistQueueID ORDER BY StylistQueueID DESC)  " & vbNewLine & _
                    "IF @PrevQueueID IS NULL " & vbNewLine & _
                    "SET @PrevQueueID=@StylistQueueID " & vbNewLine & _
                    "--Hapus CureentQueue " & vbNewLine & _
                    "DELETE BS_traQueueStylist WHERE StylistQueueID=@StylistQueueID     " & vbNewLine & _
                    "--Update NextQueueID menjadi CureentQueue " & vbNewLine & _
                    "UPDATE BS_traQueueStylist SET StylistQueueID =@StylistQueueID      " & vbNewLine & _
                    "WHERE StylistQueueID=@PrevQueueID " & vbNewLine & _
                    "--Update CureentQueue menjadi NextQueueID  " & vbNewLine & _
                    "INSERT INTO BS_traQueueStylist(StylistQueueID,StylistUserID,CreatedDate) " & vbNewLine & _
                    "SELECT @PrevQueueID,@StylistUserID,@CreatedDate " & vbNewLine & _
                    "SELECT @PrevQueueID AS PrevQueueID "

                    .Parameters.Add("@StylistQueueID", SqlDbType.Int).Value = intStylistQueueID
                    .Parameters.Add("@StylistUserID", SqlDbType.VarChar).Value = strStylistUserID
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

        Public Shared Function ListStylistName() As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "SELECT UserID FROM BS_mstUser A " & vbNewLine & _
                "LEFT JOIN BS_traQueueStylist B ON A.UserID =B.StylistUserID  " & vbNewLine & _
                "WHERE A.UserPosition ='STYLIST' AND B.StylistUserID IS NULL "

            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function

        Public Shared Function ListStylistAllName() As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "SELECT UserID FROM BS_mstUser  " & vbNewLine & _
                "WHERE UserPosition ='STYLIST'  "

            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function

        Public Shared Function ListStylistInService() As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "SELECT StylistUserID FROM BS_traQueueStylist ORDER BY StylistQueueID  "
            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function

        Public Shared Sub UpdateIsAvailable(ByVal bolAvailable As Boolean, ByVal strStylistID As String)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "UPDATE BS_traQueueStylist SET IsAvailable=@IsAvailable WHERE StylistUserID=@StylistID "

                .Parameters.Add("@StylistID", SqlDbType.VarChar).Value = strStylistID
                .Parameters.Add("@IsAvailable", SqlDbType.Bit).Value = bolAvailable
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

    End Class

End Namespace
