Public Class Form1

    Public selalpha As String '機能選択 

    Public Sub 部品初期化()
        Label2.Text = "結果表示"
    End Sub

    Private Sub 機能選択(sender As Object, e As EventArgs) Handles ComboBox1.SelectedValueChanged
        Select Case (ComboBox1.SelectedIndex)
            Case 0
                selalpha = "a"
                TextBox2.Enabled = False
            Case 1
                selalpha = "b"
                TextBox2.Enabled = True
            Case 2
                selalpha = "c"
                TextBox2.Enabled = True
        End Select
    End Sub

    Private Sub 文字列判定(sender As Object, e As EventArgs) Handles Button1.Click
        Dim str As String = TextBox1.Text
        Dim str2 As String = vbNullString

        If str Is vbNullString Then
            MsgBox("文字列が入力されていません")
            Exit Sub
        End If
        If Not selalpha = "a" Then
            str2 = TextBox2.Text
            If str2 Is vbNullString Then
                MsgBox("文字列が入力されていません")
                Exit Sub
            End If
        End If
        Call 部品初期化()
        Dim flg As Boolean '判定結果を格納
        Select Case (selalpha)
            Case "a"
                flg = Quiz1_a(str)
            Case "b"
                flg = isSubstring(str, str2)
            Case "c"
                flg = Quiz1_c(str, str2)
        End Select
        Label2.Text = flg
    End Sub
End Class
