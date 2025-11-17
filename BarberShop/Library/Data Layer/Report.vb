Imports System.Data.SqlClient

Namespace DL

    Public Class Report

        Public Shared Function NotaryOrder(ByVal dtDateFrom As DateTime, _
                                            ByVal dtDateTo As DateTime, _
                                            ByVal intJenisAkta As Integer) As DataTable

            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "SELECT NoUrut as NoUrut, NoBulanan, TglAkta, TglDidaftarkan, SifatAkta, Nama1, Nama2, ISNULL(Nama3,'') AS Nama3  FROM ( " & _
                "SELECT 1 AS JenisClient, [INDEX], NoUrut, NoBulanan, TglAkta, TglDidaftarkan, SifatAkta, B.Nama+CHAR(10)+CHAR(13)+B.Remarks As Nama1, '' As Nama2, '' As Nama3, JenisAkta " & _
                "FROM NMS_traNotaryOrder A " & _
                "INNER JOIN NMS_traNotaryOrderClient1 B ON " & _
                "A.NotaryOrderID =B.NotaryOrderID " & _
                "WHERE [INDEX]<(CASE WHEN A.JenisTransaksi ='AKTA JAMINAN FIDUSIA' THEN 2 WHEN A.JenisTransaksi <>'AKTA JAMINAN FIDUSIA' THEN 100 END) " & _
                "UNION ALL " & _
                "SELECT 2 AS JenisClient, [INDEX], NoUrut, NoBulanan, TglAkta, TglDidaftarkan, SifatAkta, '' As Nama1, C.Nama+CHAR(10)+CHAR(13)+C.Remarks As Nama2, '' As Nama3, JenisAkta " & _
                "FROM NMS_traNotaryOrder A " & _
                "INNER JOIN NMS_traNotaryOrderClient2 C ON " & _
                "A.NotaryOrderID =C.NotaryOrderID " & _
                "WHERE [INDEX]<(CASE WHEN A.JenisTransaksi ='AKTA JAMINAN FIDUSIA' THEN 2 WHEN A.JenisTransaksi <>'AKTA JAMINAN FIDUSIA' THEN 100 END) " & _
                "UNION ALL " & _
                "SELECT 3 AS JenisClient, [INDEX],NoUrut, NoBulanan, TglAkta, TglDidaftarkan, SifatAkta, '' As Nama1, '' As Nama2, D.Nama+CHAR(10)+CHAR(13)+D.Remarks As Nama3, JenisAkta " & _
                "FROM NMS_traNotaryOrder A " & _
                "LEFT JOIN NMS_traNotaryOrderClient3 D ON  " & _
                "A.NotaryOrderID =D.NotaryOrderID  )X " & _
                "WHERE CONVERT(VARCHAR(8),TglAkta,112)>=  CONVERT(VARCHAR(8), @DateFrom,112) " & _
                "AND CONVERT(VARCHAR(8),TglAkta,112)<= CONVERT(VARCHAR(8), @DateTo,112) AND JenisAkta=@JenisAkta AND NoUrut<>'' " & _
                "ORDER BY NoUrut, NoBulanan, JenisClient, [INDEX], Nama1 DESC, Nama2 DESC, Nama3 DESC "

                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtDateTo
                .Parameters.Add("@JenisAkta", SqlDbType.Int).Value = intJenisAkta
            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function

    End Class

End Namespace