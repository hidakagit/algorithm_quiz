Public Class Queue_interface(Of T)

    '2つのスタックを使う
    Public stacktmp As Stack_interface(Of T)
    Public queue As Stack_interface(Of T)

    '指定された要素をキューに追加
    Public Sub add(ByVal value As T)
        queue.push(value)
    End Sub

    'キューの先頭を取得しますが削除しない
    Public Function peek() As T
        Dim qlength As Integer = queue.size 'キューのサイズ

        For i As Integer = 0 To qlength - 1
            stacktmp.push(queue.pop)
        Next
        For i As Integer = 0 To qlength - 1
            queue.push(stacktmp.pop)
        Next
        Return queue.peek
    End Function

    'キューの先頭を取得および削除
    Public Function remove(ByVal value As T) As T
        Dim qlength As Integer = queue.size 'キューのサイズ

        For i As Integer = 0 To qlength - 1
            stacktmp.push(queue.pop)
        Next
        For i As Integer = 0 To qlength - 1
            queue.push(stacktmp.pop)
        Next
        Return queue.pop
    End Function

    'キューのサイズを取得
    Public Function size(ByVal value As T)
        Return Val(queue.size + stacktmp.size)
    End Function

End Class
