Imports System.Data.SqlClient

Namespace DL

    Public Class Server

        Public Shared Function BackupDatabase(ByVal strBackup As String) As String
            Dim strBackupName As String = ""
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnectionMaster()
                With sqlcmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                        "EXECUTE master.dbo.usp_BS_sysBackup @fileName, @db_name "

                    'Penggunaan query langsung tdk bisa untuk syntax BACK UP

                    .Parameters.Add("@fileName", SqlDbType.VarChar).Value = strBackup
                    .Parameters.Add("@db_name", SqlDbType.VarChar).Value = "BS"

                    If SQL.bolUseTrans Then .Transaction = SQL.sqlTrans
                End With
                sqlrdData = sqlcmdExecute.ExecuteReader(CommandBehavior.SingleRow)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        strBackupName = .Item("@fileName")
                    End If
                    .Close()
                End With

                If Not SQL.bolUseTrans Then SQL.CloseConnection()
            Catch ex As Exception
                Throw ex
            End Try
            Return strBackupName
        End Function

        Public Shared Function RestoreDatabase(ByVal strRestore As String) As String
            Dim strBackupName As String = ""
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader

            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnectionMaster()
                With sqlcmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                        "ALTER DATABASE BS SET SINGLE_USER WITH ROLLBACK IMMEDIATE " & _
                        "RESTORE DATABASE BS " & _
                        "FROM DISK = @fileName " & _
                        "ALTER DATABASE BS SET MULTI_USER "

                    '"EXECUTE master.dbo.usp_BS_sysRestore @fileName, @db_name "

                    .Parameters.Add("@fileName", SqlDbType.VarChar).Value = strRestore
                    .Parameters.Add("@db_name", SqlDbType.VarChar).Value = "BS"

                    If SQL.bolUseTrans Then .Transaction = SQL.sqlTrans
                End With
                sqlrdData = sqlcmdExecute.ExecuteReader(CommandBehavior.SingleRow)
                If Not SQL.bolUseTrans Then SQL.CloseConnection()

            Catch ex As Exception
                Throw ex
            End Try
            Return strBackupName
        End Function

        Public Shared Function CheckLastBackup() As Boolean
            Dim bolValid As Boolean = False
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnection()
                With sqlcmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                        "SELECT TOP 1 1 AS Result " & _
                        "FROM BS_mstBackup " & _
                        "WHERE DATEDIFF(D,(SELECT TOP 1 BackupDate FROM BS_mstBackup ORDER BY BackupDate DESC),GETDATE()) >=1 " & _
                        "ORDER BY BackupDate DESC "

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

        Public Shared Sub SaveBackupDate()
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "INSERT INTO BS_mstBackup(BackupDate) VALUES (GETDATE()) "
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function BackupDatabaseAuto() As String
            If CheckLastBackup() Then
                Dim strBackupName As String = ""
                Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
                Try
                    If Not SQL.bolUseTrans Then SQL.OpenConnectionMaster()
                    With sqlcmdExecute
                        .Connection = SQL.sqlConn
                        .CommandText = _
                            "EXECUTE master.dbo.usp_app_sysBackup @fileName, @db_name "

                        'Penggunaan query langsung tdk bisa untuk syntax BACK UP

                        .Parameters.Add("@fileName", SqlDbType.VarChar).Value = UI.usUserApp.BackupLocation
                        .Parameters.Add("@db_name", SqlDbType.VarChar).Value = "BS"

                        If SQL.bolUseTrans Then .Transaction = SQL.sqlTrans
                    End With
                    sqlrdData = sqlcmdExecute.ExecuteReader(CommandBehavior.SingleRow)
                    With sqlrdData
                        If .HasRows Then
                            .Read()
                            strBackupName = .Item("@fileName")
                        End If
                        .Close()
                    End With

                    SaveBackupDate()

                    If Not SQL.bolUseTrans Then SQL.CloseConnection()
                Catch ex As Exception
                    Throw ex
                End Try
                Return strBackupName
            End If
            Return Nothing
        End Function

    End Class

End Namespace
