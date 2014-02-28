Public Class Form1

    Public hstr As String '配列文字列(カンマ区切り)
    Public hairetsu() As String '配列

    '答えを格納
    Public min_index As Integer = 0
    Public max_index As Integer = 0

    Public Sub 下限インデックス探索()
        '下から持ち上げていく
        For i As Integer = 0 To hairetsu.Length - 2
            min_index = i
            For j As Integer = i + 1 To hairetsu.Length - 1
                If Val(hairetsu(i)) > Val(hairetsu(j)) Then
                    Exit Sub
                End If
            Next
        Next
    End Sub

    Public Sub 上限インデックス探索()
        '上から降ろしてくる
        For i As Integer = hairetsu.Length - 1 To 1 Step -1
            max_index = i
            For j As Integer = i - 1 To 0 Step -1
                If Val(hairetsu(i)) < Val(hairetsu(j)) Then
                    Exit Sub
                End If
            Next
        Next
    End Sub

    Private Sub ソート部分検出(sender As Object, e As EventArgs) Handles Button1.Click

        Call 初期化()
        If Not 入力チェック() Then '不正な入力
            Exit Sub
        End If

        Call 下限インデックス探索()
        Call 上限インデックス探索()

        TextBox1.Text = Val(min_index)
        TextBox2.Text = Val(max_index)
    End Sub

    Private Sub 初期化()
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Public Function 入力チェック() As Boolean

        hstr = RichTextBox1.Text
        hairetsu = Split(hstr, ", ") 'カンマ区切りで配列に挿入

        For i As Integer = 0 To hairetsu.Length - 1
            If hairetsu(i) = "" Then
                MsgBox("入力配列文字列の中に不正な部分があります")
                Return False
            End If
        Next

        Return True
    End Function

End Class
