Imports System.Data.SqlClient

Namespace DL

    Public Class PaymentIn

        Public Shared Sub SavePayment(ByVal strPaymentInID As String, ByVal dtPaymentDate As DateTime, ByVal intTotalPayment As Integer)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "INSERT INTO BS_traPaymentIn (PaymentInID,PaymentDate,TotalPayment,CreatedBy) " & vbNewLine & _
                "VALUES (@PaymentInID,@PaymentDate,@TotalPayment,@CreatedBy) "

                .Parameters.Add("@PaymentInID", SqlDbType.VarChar).Value = strPaymentInID
                .Parameters.Add("@PaymentDate", SqlDbType.DateTime).Value = dtPaymentDate
                .Parameters.Add("@TotalPayment", SqlDbType.Int).Value = intTotalPayment
                .Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = UI.usUserApp.UserID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub SavePaymentDet(ByVal clsData As VO.PaymentIn)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "INSERT INTO BS_traPaymentInDet (PaymentInID,PaymentDetDateTime,ItemID,ServiceID,Price,Quantity,TotalPrice) " & vbNewLine & _
                "VALUES (@PaymentInID,@PaymentDetDateTime,@ItemID,@ServiceID,@Price,@Quantity,@TotalPrice) "

                .Parameters.Add("@PaymentInID", SqlDbType.VarChar).Value = clsData.PaymentInID
                .Parameters.Add("@PaymentDetDateTime", SqlDbType.DateTime).Value = clsData.PaymentDetDateTime
                .Parameters.Add("@ItemID", SqlDbType.VarChar).Value = clsData.ItemID
                .Parameters.Add("@ServiceID", SqlDbType.VarChar).Value = clsData.ServiceID
                .Parameters.Add("@Price", SqlDbType.Int).Value = clsData.Price
                .Parameters.Add("@Quantity", SqlDbType.Int).Value = clsData.Quantity
                .Parameters.Add("@TotalPrice", SqlDbType.Int).Value = clsData.TotalPrice
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeletePayment(ByVal strPaymentID As String)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "UPDATE BS_traPaymentIn SET IsDeleted=1 WHERE PaymentInID=@PaymentInID " & vbNewLine & _
                    "UPDATE BS_traQueueInService SET IsPaid=0 WHERE ServiceID IN (SELECT ServiceID FROM BS_traPaymentInDet WHERE PaymentInID=@PaymentInID) "

                .Parameters.Add("@PaymentInID", SqlDbType.VarChar).Value = strPaymentID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub UpdatePrintKe(ByVal strPaymentID As String)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "UPDATE BS_traPaymentIn SET [Print]+=1 WHERE PaymentInID=@PaymentInID "
                 
                .Parameters.Add("@PaymentInID", SqlDbType.VarChar).Value = strPaymentID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function PaymentCurrentService() As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "SELECT ServiceID, CustName as Customer, StylistUserID as Stylist FROM BS_traQueueInService  " & vbNewLine & _
                "WHERE CONVERT(VARCHAR(8),CheckInDate,112)=CONVERT(VARCHAR(8),GETDATE(),112) " & vbNewLine & _
                "AND IsCekOut=1 AND IsPaid=0 AND IsDeleted=0 "

            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function

        Public Shared Function Type() As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "SELECT ItemID AS TypeID, ItemName AS TypeName, CAST(SellingPrice as int) AS Price, IsBarber, IsAdd " & vbNewLine & _
                "FROM BS_mstItem  " & vbNewLine & _
                "WHERE IsDeleted=0 "

            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function

        Public Shared Function PaymentItemDet(ByVal strPaymentID As String) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "SELECT PaymentDetDateTime, A.ItemID, B.ItemName, " & vbNewLine & _
                "A.ServiceID, C.CustName, C.StylistUserID, A.Price,A.Quantity,A.TotalPrice FROM BS_traPaymentInDet A " & vbNewLine & _
                "INNER JOIN BS_mstItem B ON A.ItemID=B.ItemID  " & vbNewLine & _
                "LEFT JOIN BS_traQueueInService C ON A.ServiceID=C.ServiceID  " & vbNewLine & _
                "WHERE PaymentInID=@PaymentInID " & vbNewLine & _
                "ORDER BY PaymentDetDateTime"

                .Parameters.Add("@PaymentInID", SqlDbType.VarChar).Value = strPaymentID

            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function

        Public Shared Function PaymentAutoNumber() As String
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Dim strPaymentID As String = ""
            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnection()
                With sqlcmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                    "DECLARE @LastVal varchar(20), @i as int, @ID varchar(20)     " & vbNewLine & _
                    "SET @LastVal=(SELECT MAX(PaymentInID) FROM BS_traPaymentIn WHERE PaymentInID LIKE 'P'+SUBSTRING(CONVERT(VARCHAR(8),GETDATE(),112),3,6) + '%')     " & vbNewLine & _
                    "IF @LastVal IS NULL SET @LastVal= 'P'+SUBSTRING(CONVERT(VARCHAR(8),GETDATE(),112),3,6)+'000'     " & vbNewLine & _
                    "SET @i=RIGHT(@LastVal,3)+1     " & vbNewLine & _
                    "SET @ID='P'+SUBSTRING(CONVERT(VARCHAR(8),GETDATE(),112),3,6)+RIGHT('00'+CONVERT(VARCHAR(10),@i),3)     " & vbNewLine & _
                    "Select @ID AS PaymentID "

                    If SQL.bolUseTrans Then .Transaction = SQL.sqlTrans
                End With
                sqlrdData = sqlcmdExecute.ExecuteReader(CommandBehavior.SingleResult)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        strPaymentID = .Item("PaymentID")
                    End If
                    .Close()
                End With
                If Not SQL.bolUseTrans Then SQL.CloseConnection()
            Catch ex As Exception
                Throw ex
            End Try
            Return strPaymentID
        End Function

        Public Shared Function PaymentList(ByVal dtDateFrom As DateTime, ByVal dtDateTo As DateTime) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "SELECT PaymentInID,PaymentDate,TotalPayment,IsDeleted,[Print],CreatedBy " & vbNewLine & _
                "FROM BS_traPaymentIn  " & vbNewLine & _
                "WHERE CONVERT(VARCHAR(8),PaymentDate,112)>=CONVERT(VARCHAR(8),@DateFrom,112) " & vbNewLine & _
                "AND CONVERT(VARCHAR(8),PaymentDate,112)<=CONVERT(VARCHAR(8),@DateTo,112) " & vbNewLine & _
                "ORDER BY PaymentInID DESC "

                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtDateTo

            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function

        Public Shared Function PaymentPrint(ByVal strPaymentID As String) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "SELECT PaymentDetDateTime,B.ItemName, C.StylistUserID,    " & vbNewLine & _
                "A.Quantity, A.Price, A.TotalPrice " & vbNewLine & _
                "FROM BS_traPaymentInDet A         " & vbNewLine & _
                "INNER JOIN BS_mstItem B ON A.ItemID=B.ItemID        " & vbNewLine & _
                "LEFT JOIN BS_traQueueInService C ON A.ServiceID=C.ServiceID    " & vbNewLine & _
                "WHERE PaymentInID=@PaymentInID         " & vbNewLine & _
                "ORDER BY PaymentDetDateTime "


                .Parameters.Add("@PaymentInID", SqlDbType.VarChar).Value = strPaymentID

            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function
        
        Public Shared Function StylistFeeSmallReport(ByVal dtDateFrom As DateTime, ByVal dtDateTo As DateTime) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "SELECT C.StylistUserID,B.ItemName,SUM(A.Quantity) AS Quantity,B.BeginningPrice AS Price, " & vbNewLine & _
                "B.BeginningPrice*SUM(A.Quantity) AS TotalPrice " & vbNewLine & _
                "FROM BS_traPaymentInDet A     " & vbNewLine & _
                "INNER JOIN BS_mstItem B ON A.ItemID=B.ItemID      " & vbNewLine & _
                "INNER JOIN BS_traQueueInService C ON A.ServiceID =C.ServiceID  " & vbNewLine & _
                "WHERE CONVERT(VARCHAR(8),PaymentDetDateTime,112)>=CONVERT(VARCHAR(8),@DateFrom,112)  " & vbNewLine & _
                "AND CONVERT(VARCHAR(8),PaymentDetDateTime,112)<=CONVERT(VARCHAR(8),@DateTo,112)  " & vbNewLine & _
                "GROUP BY C.StylistUserID,B.ItemName,B.BeginningPrice " & vbNewLine & _
                "ORDER BY C.StylistUserID "

                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtDateTo

            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function

        Public Shared Function StylistFeeReport(ByVal dtDateFrom As DateTime, ByVal strStylistUserID As String) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "SELECT C.StylistUserID, C.CheckInDate AS CekIn, C.CheckOutDate AS CekOut, " & vbNewLine & _
                "B.AltName AS ItemName,B.SellingPrice,B.BeginningPrice  " & vbNewLine & _
                "FROM BS_traPaymentInDet A         " & vbNewLine & _
                "INNER JOIN BS_mstItem B ON A.ItemID=B.ItemID          " & vbNewLine & _
                "INNER JOIN BS_traQueueInService C ON A.ServiceID =C.ServiceID      " & vbNewLine & _
                "WHERE CONVERT(VARCHAR(8),PaymentDetDateTime,112)=CONVERT(VARCHAR(8),@DateFrom,112)      " & vbNewLine & _
                "AND (@StylistUserID ='' OR C.StylistUserID =@StylistUserID)   " & vbNewLine & _
                "ORDER BY C.StylistUserID, C.CheckInDate "

                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtDateFrom
                .Parameters.Add("@StylistUserID", SqlDbType.VarChar).Value = strStylistUserID

            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function

        Public Shared Function ProfitReport(ByVal dtDateFrom As DateTime, ByVal dtDateTo As DateTime) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText =
                "SELECT CAST(A.PaymentDetDateTime AS DATE) AS TransDate, " & vbNewLine &
                "SUM(CASE B.IsBarber WHEN 1 THEN SellingPrice ELSE 0 END) AS SellingPrice, " & vbNewLine &
                "SUM(CASE B.IsBarber WHEN 0 THEN SellingPrice ELSE 0 END) AS SellingPriceNS, " & vbNewLine &
                "SUM(CASE B.IsBarber WHEN 1 THEN BeginningPrice ELSE 0 END) AS BeginningPrice  " & vbNewLine &
                "FROM BS_traPaymentInDet A             " & vbNewLine &
                "INNER JOIN BS_mstItem B ON A.ItemID=B.ItemID              " & vbNewLine &
                "WHERE CONVERT(VARCHAR(8),PaymentDetDateTime,112)>=CONVERT(VARCHAR(8),@DateFrom,112)          " & vbNewLine &
                "AND CONVERT(VARCHAR(8),PaymentDetDateTime,112)<=CONVERT(VARCHAR(8),@DateTo,112)          " & vbNewLine &
                "GROUP BY  CAST(A.PaymentDetDateTime AS DATE)   " & vbNewLine &
                "ORDER BY 1 "

                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtDateTo
            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function

        Public Shared Function ProfitReportNew(ByVal dtDateFrom As DateTime, ByVal dtDateTo As DateTime) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText =
                "SELECT PaymentInID, PaymentDetDateTime, Price, (Price*5) as PriceDouble  " & vbNewLine &
                "FROM BS_traPaymentInDet A             " & vbNewLine &
                "WHERE CONVERT(VARCHAR(8),PaymentDetDateTime,112)>=CONVERT(VARCHAR(8),@DateFrom,112)          " & vbNewLine &
                "AND CONVERT(VARCHAR(8),PaymentDetDateTime,112)<=CONVERT(VARCHAR(8),@DateTo,112)          "


                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtDateTo
            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function

        Public Shared Function ProfitReportSmall(ByVal dtDateFrom As DateTime, ByVal dtDateTo As DateTime) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "SELECT CONVERT(VARCHAR(8),A.PaymentDetDateTime,112) AS TransDate,B.ItemID,B.ItemName,SUM(A.Quantity) AS Quantity, " & vbNewLine & _
                "(B.SellingPrice-B.BeginningPrice) AS Price,     " & vbNewLine & _
                "(B.SellingPrice-B.BeginningPrice)*SUM(A.Quantity) AS TotalPrice     " & vbNewLine & _
                "FROM BS_traPaymentInDet A         " & vbNewLine & _
                "INNER JOIN BS_mstItem B ON A.ItemID=B.ItemID          " & vbNewLine & _
                "WHERE CONVERT(VARCHAR(8),PaymentDetDateTime,112)>=CONVERT(VARCHAR(8),@DateFrom,112)      " & vbNewLine & _
                "AND CONVERT(VARCHAR(8),PaymentDetDateTime,112)<=CONVERT(VARCHAR(8),@DateTo,112)      " & vbNewLine & _
                "GROUP BY CONVERT(VARCHAR(8),A.PaymentDetDateTime,112),B.ItemID,B.ItemName,B.SellingPrice,B.BeginningPrice     " & vbNewLine & _
                "ORDER BY 1,B.ItemID "

                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtDateTo
            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function

    End Class

End Namespace
