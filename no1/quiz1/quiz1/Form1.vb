Public Class Form1

    Private Sub 文字列重複判定(sender As Object, e As EventArgs) Handles Button1.Click
        Dim str As String = TextBox1.Text
        If str Is vbNullString Then
            MsgBox("文字列が入力されていません")
            Exit Sub
        End If
        Dim flg As Boolean = Quiz1_a(str)
        Label2.Text = flg
    End Sub

End Class
