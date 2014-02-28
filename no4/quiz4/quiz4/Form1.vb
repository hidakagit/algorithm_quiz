Public Class Form1

    Public enzan As String = vbNullString '演算種類
    Public int1 As Integer
    Public int2 As Integer

    Private Sub 演算種類(sender As Object, e As EventArgs) Handles ComboBox1.SelectedValueChanged
        Select Case (ComboBox1.SelectedIndex)
            Case 0
                enzan = "minus"
            Case 1
                enzan = "mult"
            Case 2
                enzan = "divi"
        End Select
    End Sub

    Private Sub 演算対象読み込み()
        If TextBox1.Text = "" Then
            int1 = -1
        Else
            int1 = Val(TextBox1.Text)
        End If
        If TextBox2.Text = "" Then
            int2 = -1
        Else
            int2 = Val(TextBox2.Text)
        End If
    End Sub

    Private Sub 演算(sender As Object, e As EventArgs) Handles Button1.Click

        Dim ans As Integer 'Answer
        TextBox3.Text = ""
        Call 演算対象読み込み()
        'エラー処理
        If int1 = -1 Or int2 = -1 Then
            MsgBox("変数入力が不正です")
            Exit Sub
        End If

        Select Case (enzan)
            Case "minus"
                ans = minus(int1, int2)
            Case "mult"
                ans = multiply(int1, int2)
            Case "divi"
                ans = divide(int1, int2)
        End Select

        TextBox3.Text = ans
    End Sub
End Class
