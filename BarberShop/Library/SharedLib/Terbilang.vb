Namespace UI
    Public Class Terbilang

        Public Shared Function Terbilang(ByVal x As Double) As String
            Dim tampung As Double
            Dim teks As String
            Dim bagian As String
            Dim i As Integer
            Dim tanda As Boolean

            Dim letak(5)
            letak(1) = "ribu "
            letak(2) = "juta "
            letak(3) = "milyar "
            letak(4) = "trilyun "

            If (x = 0) Then
                Terbilang = "nol"
                Exit Function
            End If

            If (x < 2000) Then
                tanda = True
            End If

            teks = ""

            If (x >= 1.0E+15) Then
                Terbilang = "Nilai terlalu besar"
                Exit Function
            End If

            For i = 4 To 1 Step -1
                tampung = Int(x / (10 ^ (3 * i)))
                If (tampung > 0) Then
                    bagian = ratusan(tampung, tanda)
                    teks = teks & bagian & letak(i)
                End If
                x = x - tampung * (10 ^ (3 * i))
            Next

            teks = teks & ratusan(x, False)
            Terbilang = teks
        End Function

        Public Shared Function ratusan(ByVal y As Double, ByVal flag As Boolean) As String
            Dim tmp As Double
            Dim bilang As String
            Dim bag As String
            Dim j As Integer

            Dim angka(9)
            angka(1) = "se"
            angka(2) = "dua "
            angka(3) = "tiga "
            angka(4) = "empat "
            angka(5) = "lima "
            angka(6) = "enam "
            angka(7) = "tujuh "
            angka(8) = "delapan "
            angka(9) = "sembilan "

            Dim posisi(2)
            posisi(1) = "puluh "
            posisi(2) = "ratus "

            bilang = ""
            For j = 2 To 1 Step -1
                tmp = Int(y / (10 ^ j))
                If (tmp > 0) Then
                    bag = angka(tmp)
                    If (j = 1 And tmp = 1) Then
                        y = y - tmp * 10 ^ j
                        If (y >= 1) Then
                            posisi(j) = "belas "
                        Else
                            angka(y) = "se"
                        End If
                        bilang = bilang & angka(y) & posisi(j)
                        ratusan = bilang
                        Exit Function
                    Else
                        bilang = bilang & bag & posisi(j)
                    End If
                End If
                y = y - tmp * 10 ^ j
            Next

            If (flag = False) Then
                angka(1) = "satu "
            End If
            bilang = bilang & angka(y)
            ratusan = bilang
        End Function

        Public Shared Function Bulan(ByVal x As Integer) As String
            Bulan = ""
            Select Case x
                Case 1
                    Bulan = "Januari"
                Case 2
                    Bulan = "Februari"
                Case 3
                    Bulan = "Maret"
                Case 4
                    Bulan = "April"
                Case 5
                    Bulan = "Mei"
                Case 6
                    Bulan = "Juni"
                Case 7
                    Bulan = "Juli"
                Case 8
                    Bulan = "Agustus"
                Case 9
                    Bulan = "September"
                Case 10
                    Bulan = "Oktober"
                Case 11
                    Bulan = "November"
                Case 12
                    Bulan = "Desember"
            End Select
        End Function


    End Class
End Namespace
