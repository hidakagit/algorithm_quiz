Module Module1

    Public Function Quiz1_a(ByVal str1 As String) As Boolean

        Dim str_length As Integer = str1.Length '文字列の長さ
        Dim str_buf() As String 'バッファ
        Dim flg As Boolean = False '重複を見つければTrue

        Call 部品初期化()

        For i As Integer = 0 To str_length - 1
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

    Public Sub 部品初期化()
        Form1.Label2.Text = "結果表示"
    End Sub

End Module
