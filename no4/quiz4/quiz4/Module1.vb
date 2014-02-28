Module Module1

    Public Function minus(ByVal a As Integer, ByVal b As Integer) As Integer
        Dim be_keta As Integer = CStr(a).Length 'aの桁数
        Dim atmp As Integer = a
        Dim btmp As Integer = 0
        Dim achange As Integer = 0 '桁上がりまでの差
        Dim ans As Integer = 0

        While (CStr(a + achange).Length = be_keta)
            achange = achange + 1 'aの桁が一つ上がるまで足す
        End While

        While Not (CStr(a + achange).Length = CStr(b + achange + ans).Replace("-", "").Length)
            ans = ans + 1
        End While

        Return ans
    End Function

    Public Function multiply(ByVal a As Integer, ByVal b As Integer) As Integer
        Dim mul As Integer = 0

        For i As Integer = 1 To b
            mul = mul + a
        Next
        Return mul
    End Function

    Public Function divide(ByVal a As Integer, ByVal b As Integer) As Integer
        Dim divcount As Integer = 0
        Dim div As Integer = a

        While (True)
            div = minus(div, b)
            divcount = divcount + 1
            If div < 0 Then Exit While
        End While
        Return minus(divcount, 1)
    End Function

End Module
