Public Class Form1

    Public number As Integer '括弧の組数
    Public pattrn() As String '括弧総パターン
    Public good() As String '正しい括弧総パターン

    Private Sub 表示初期化()
        RichTextBox1.Clear()
        Label3.Text = ""
    End Sub

    Private Sub 括弧組数確定(sender As Object, e As EventArgs) Handles Button1.Click
        number = Val(TextBox1.Text)
        If number = 0 Then
            MsgBox("1以上の整数を入力してください")
            Exit Sub
        End If

        Call 表示初期化()
        Call 括弧組み合わせ書き出し()
        Call 括弧不当組み合わせ除去()

        Dim outputstring As String = vbNullString
        For i As Integer = 0 To good.Length - 1
            If i = 0 Then
                outputstring = good(i)
            Else
                outputstring = outputstring & " ," & good(i)
            End If
        Next
        If outputstring Is vbNullString Then
            MsgBox("表示できる括弧パターンがありません")
            Exit Sub
        End If
        RichTextBox1.Text = outputstring
        Label3.Text = good.Length
    End Sub

    '0->「(」, 1->「)」
    Public Function 括弧選択(ByVal str As String) As String
        Dim strtmp As String = vbNullString
        strtmp = str.Replace("0", "(").Replace("1", ")")
        Return strtmp
    End Function

    Public Sub 括弧組み合わせ書き出し()
        Dim kc As Long = 0 '存在カウンター
        For i As Long = 0 To 2 ^ (2 * number) - 1
            Dim knum As String = Convert.ToString(CInt(i), 2).PadLeft(2 * number, "0"c)
            If (knum.Length - knum.Replace("1", "").Length = number) Then
                ReDim Preserve pattrn(kc)
                pattrn(kc) = knum
                kc = kc + 1
            End If
        Next
    End Sub

    Public Sub 括弧不当組み合わせ除去()

        Dim kc As Integer = 0 'カウンター

        For i As Integer = 0 To pattrn.Length - 1
            Dim kpattrn As String = pattrn(i)
            Dim ktmp As String = kpattrn 'tmp
            Dim cc As Integer = 0 'パターンが見つからない時に抜けるためのカウンタ
            While Not (ktmp.Length <= 2)
                If InStr(kpattrn, "01") Then
                    ktmp = ktmp.Replace("01", "")
                End If
                cc = cc + 1
                If cc > 1 Then Exit While
            End While
            If ktmp = "01" Or ktmp = "" Then
                ReDim Preserve good(kc)
                good(kc) = 括弧選択(kpattrn)
                kc = kc + 1
            End If
        Next
    End Sub

End Class
