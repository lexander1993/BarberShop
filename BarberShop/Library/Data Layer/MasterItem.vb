Imports System.Data.SqlClient

Namespace DL

    Public Class MasterItem

        Public Shared Function ListData(ByVal intIsActive As Integer) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "SELECT ItemID,AltName,ItemName,BeginningPrice,SellingPrice,Remarks,IsBarber,IsAdd,IsDeleted, " & vbNewLine & _
                "CreatedBy,CreatedDate,ModifiedBy,ModifiedDate FROM BS_mstItem "

                If intIsActive <> 2 Then
                    .CommandText += " WHERE IsDeleted=@IsDeleted "
                End If

                .Parameters.Add("@IsDeleted", SqlDbType.Bit).Value = intIsActive
            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function

        Public Shared Function GetDetail(ByVal strItemID As String) As VO.MasterItem
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Dim clsReturn As New VO.MasterItem
            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnection()
                With sqlcmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                    "SELECT ItemID,ItemName,AltName,BeginningPrice,SellingPrice,Remarks,IsBarber,IsAdd,IsDeleted, " & vbNewLine & _
                    "CreatedBy,CreatedDate,ModifiedBy,ModifiedDate FROM BS_mstItem " & vbNewLine & _
                    "WHERE ItemID=@ItemID "

                    .Parameters.Add("@ItemID", SqlDbType.VarChar).Value = strItemID

                    If SQL.bolUseTrans Then .Transaction = SQL.sqlTrans
                End With
                sqlrdData = sqlcmdExecute.ExecuteReader(CommandBehavior.SingleResult)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        clsReturn.ItemID = .Item("ItemID")
                        clsReturn.ItemName = .Item("ItemName")
                        clsReturn.AltName = .Item("AltName")
                        clsReturn.BeginningPrice = .Item("BeginningPrice")
                        clsReturn.SellingPrice = .Item("SellingPrice")
                        clsReturn.Remarks = .Item("Remarks")
                        clsReturn.IsBarber = .Item("IsBarber")
                        clsReturn.IsAdd = .Item("IsAdd")
                    End If
                    .Close()
                End With
                If Not SQL.bolUseTrans Then SQL.CloseConnection()
            Catch ex As Exception
                Throw ex
            End Try
            Return clsReturn
        End Function

        Public Shared Sub SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.MasterItem)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                If bolNew Then

                    If CheckValidItemName(clsData.ItemName) Then
                        Err.Raise(515, "", "Item Name has been used. Please select another Item Name. ")
                    End If

                    .CommandText = _
                        "INSERT INTO BS_mstItem (ItemID, ItemName, AltName, BeginningPrice, SellingPrice, Remarks, IsBarber, IsAdd, CreatedBy, CreatedDate) " & _
                        "VALUES (@ItemID, @ItemName, @AltName, @BeginningPrice, @SellingPrice, @Remarks, @IsBarber, @IsAdd, @UserID, GETDATE() ) "
                Else
                    .CommandText = _
                        "UPDATE BS_mstItem SET " & _
                        "   ItemName=@ItemName, AltName=@AltName, BeginningPrice=@BeginningPrice, SellingPrice=@SellingPrice, Remarks=@Remarks, IsBarber=@IsBarber, IsAdd=@IsAdd, ModifiedBy=@UserID, ModifiedDate=GETDATE() " & _
                        "WHERE ItemID=@ItemID "
                End If

                .Parameters.Add("@ItemID", SqlDbType.VarChar).Value = clsData.ItemID
                .Parameters.Add("@ItemName", SqlDbType.VarChar).Value = clsData.ItemName
                .Parameters.Add("@AltName", SqlDbType.VarChar).Value = clsData.AltName
                .Parameters.Add("@BeginningPrice", SqlDbType.Int).Value = clsData.BeginningPrice
                .Parameters.Add("@SellingPrice", SqlDbType.Int).Value = clsData.SellingPrice
                .Parameters.Add("@Remarks", SqlDbType.VarChar).Value = clsData.Remarks
                .Parameters.Add("@IsBarber", SqlDbType.Bit).Value = clsData.IsBarber
                .Parameters.Add("@IsAdd", SqlDbType.Bit).Value = clsData.IsAdd
                .Parameters.Add("@UserID", SqlDbType.VarChar).Value = UI.usUserApp.UserID
              
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteHeader(ByVal strItemID As String)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "UPDATE BS_mstItem SET IsDeleted=1 WHERE ItemID=@ItemID "

                .Parameters.Add("@ItemID", SqlDbType.VarChar).Value = strItemID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function CheckValidItemName(ByVal strItemName As String) As Boolean
            Dim bolValid As Boolean = False
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnection()
                With sqlcmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                        "SELECT TOP 1 1 AS Result " & _
                        "FROM BS_mstItem " & _
                        "WHERE ItemName=@ItemName "

                    .Parameters.Add("@ItemName", SqlDbType.VarChar).Value = strItemName

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

        Public Shared Function ItemAutoNumber() As String
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Dim strItemID As String = ""
            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnection()
                With sqlcmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                    "DECLARE @LastVal varchar(20), @i as int, @ID varchar(20)         " & vbNewLine & _
                    "SET @LastVal=(SELECT MAX(ItemID) FROM BS_mstItem WHERE ItemID LIKE 'I-'+ '%')         " & vbNewLine & _
                    "IF @LastVal IS NULL SET @LastVal= 'I-'+'000'         " & vbNewLine & _
                    "SET @i=RIGHT(@LastVal,3)+1         " & vbNewLine & _
                    "SET @ID='I-'+RIGHT('00'+CONVERT(VARCHAR(10),@i),3)         " & vbNewLine & _
                    "Select @ID AS ItemID "

                    If SQL.bolUseTrans Then .Transaction = SQL.sqlTrans
                End With
                sqlrdData = sqlcmdExecute.ExecuteReader(CommandBehavior.SingleResult)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        strItemID = .Item("ItemID")
                    End If
                    .Close()
                End With
                If Not SQL.bolUseTrans Then SQL.CloseConnection()
            Catch ex As Exception
                Throw ex
            End Try
            Return strItemID
        End Function

    End Class

End Namespace
