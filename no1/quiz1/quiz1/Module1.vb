Module Module1

    Public Function Quiz1_a(ByVal str1 As String) As Boolean

        Dim str_buf() As String 'バッファ
        Dim flg As Boolean = False '重複を見つければTrue

        For i As Integer = 0 To str1.Length - 1
            ReDim Preserve str_buf(i)
            str_buf(i) = str1(i) 'バッファに文字列を一文字ずつ入れる

            If i >= 1 Then '2文字目以降から比較開始
                For j As Integer = 0 To i
                    If Not j = i Then '同じ文字数部分は一致して当たり前なので飛ばす
                        If str_buf(j) = str1(i) Then
                            flg = True
                        End If
                    End If
                Next
            End If
            If flg = True Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Function isSubstring(ByVal str1 As String, ByVal str2 As String) As Boolean
        Dim strindex As Integer = InStr(str1, str2)
        If Not strindex = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function Quiz1_c(ByVal str1 As String, ByVal str2 As String) As Boolean

        Dim str1buf As String = vbNullString 'バッファ
        Dim flg As Boolean = False '重複を見つければTrue
        Dim s1, s2 As String

        For i As Integer = 0 To str1.Length - 1
            str1buf = str1buf & str1(i)
            If isSubstring(str2, str1buf) = False Then
                str1buf.Remove(str1buf.Length - 1, 1)
                Exit For
            End If
        Next

        s1 = str1.Replace(str1buf, "")
        s2 = str2.Replace(str1buf, "")

        If s1 = s2 Then
            Return True
        Else
            Return False
        End If
    End Function

End Module
