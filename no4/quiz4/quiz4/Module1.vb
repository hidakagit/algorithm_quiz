Module Module1

    Public Function minus(ByVal a As Integer, ByVal b As Integer) As Integer

        Return (a + (Not b) + 1)
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
