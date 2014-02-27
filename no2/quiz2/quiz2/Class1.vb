Public Class Stack_interface(Of T)

    Public stack() As T 'スタック

    'スタックが空かどうかを判定します。
    '空ならばtrue, 空でなければfalse
    Public Function empty() As Boolean
        If stack Is Nothing Then
            Return True
        Else
            Return False
        End If
    End Function

    'スタックの先頭にあるオブジェクトを取り出す
    '取り出したオブジェクトはスタックに残る
    Public Function peek() As T
        If empty() Then
            MsgBox("スタックは空です")
            Exit Function
        End If
        Return stack(0)
    End Function

    'スタックの先頭にあるオブジェクトの値を取り出す
    '取り出したオブジェクトはスタックから消去される
    Public Function pop() As T
        If empty() Then
            MsgBox("スタックは空です")
            Exit Function
        End If
        Dim tmp As T = stack(0) '返す値
        Dim slength As Integer = stack.Length - 1 'スタックの現在の長さ
        For i As Integer = 1 To stack.Length - 1
            stack(i - 1) = stack(i)
        Next

        ReDim Preserve stack(slength - 1)
        Return tmp
    End Function

    'スタックの先頭に要素を挿入
    Public Function push(ByVal value As T) As T
        If empty() Then
            ReDim Preserve stack(0)
            stack(0) = value
        Else
            Dim slength As Integer = stack.Length - 1
            ReDim Preserve stack(slength + 1)

            For i As Integer = stack.Length - 2 To 1 Step -1
                stack(i + 1) = stack(i)
            Next
            stack(0) = value '挿入
        End If
        Return value
    End Function

    'スタックの中の要素数を返す
    Public Function size() As Integer
        If empty() Then
            Return 0
        Else
            Return (stack.Length - 1)
        End If
    End Function

End Class
