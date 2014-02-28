Public Structure wakuseinterface
    Public ttno As Integer
    Public r_i As Integer
    Public c_i As Integer
    Public pass As Integer '通過していればその時の回数
End Structure

Public Class Form1

    Public waku(999) As Integer '枠は最大で500まで(行:0～499, 列:500～999)
    Public wakusei() As wakuseinterface
    Public N As Integer
    Public K As Integer
    Public wstr As String '小惑星情報文字列

    Private Sub 計算(sender As Object, e As EventArgs) Handles Button1.Click

        Call 初期化()
        Call 小惑星情報取得()

        If Not wakusei.Length = K Then
            MsgBox("Nの数が一致しません")
            Exit Sub
        End If

        Call 行列カウント()

        '答えを求める
        RichTextBox2.Text = 計算本体().Length

    End Sub

    Private Sub 初期化()
        RichTextBox2.Clear()
    End Sub

    Private Sub 小惑星情報取得()

        wstr = RichTextBox1.Text
        N = Val(TextBox1.Text)
        K = Val(TextBox2.Text)

        Dim wtmp() As String
        wtmp = Split(wstr.Replace("(", "").Replace(")", ""), ", ")
        For i As Integer = 0 To wtmp.Length - 1
            Select Case (i Mod 2)
                Case 0
                    ReDim Preserve wakusei(i \ 2)
                    wakusei(i \ 2).r_i = wtmp(i)
                    wakusei(i \ 2).pass = -1
                Case 1
                    wakusei(i \ 2).c_i = wtmp(i)
            End Select
        Next

        '十字カウント計算
        For i As Integer = 0 To wakusei.Length - 1
            wakusei(i).ttno = 十字カウント(wakusei(i).r_i, wakusei(i).c_i)
        Next

        '十字カウントで降順ソート
        Array.Sort(wakusei, New wakuseiCompare)
        Array.Reverse(wakusei)

    End Sub

    Private Function 十字カウント(ByVal wr As Integer, ByVal wc As Integer) As Integer
        Dim ans As Integer = 0
        For i As Integer = 0 To K - 1
            If wakusei(i).r_i = wr Or wakusei(i).c_i = wc Then
                ans += 1
            End If
        Next
        Return ans
    End Function

    Private Function 終了判定(ByVal waku_index As Integer) As Boolean
        For i As Integer = 0 To wakusei.Length - 1
            If waku_index < 500 Then '列を消した
                If wakusei(i).r_i = waku_index Then wakusei(i).pass = waku_index
            Else '列を消した
                If wakusei(i).c_i = (waku_index Mod 500) Then wakusei(i).pass = waku_index
            End If
            If wakusei(i).pass = -1 Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub 行列カウント()
        For i As Integer = 0 To wakusei.Length - 1
            waku(wakusei(i).r_i) += 1
            waku(wakusei(i).c_i + 500) += 1
        Next
    End Sub

    Private Function 計算本体() As Integer()
        'インデックスを作っただけ・・・
        Dim waku_index(999) As Integer
        For i As Integer = 0 To 999
            waku_index(i) = i
        Next
        '多い順にソート
        Array.Sort(waku, waku_index)
        Array.Reverse(waku)

        Dim ans() As Integer '出力カウント

        Dim finflg As Boolean = False
        Dim ansc As Integer = 0
        For i As Integer = 999 To 0 Step -1
            ReDim Preserve ans(ansc)
            ans(ansc) = waku_index(waku(i))
            finflg = 終了判定(ans(ansc))
            If finflg Then
                Return ans
            End If
            ansc += 1
        Next
        Return {-1}
    End Function
End Class

'flowerdistanceを比較するためのインターフェイス
Public Class wakuseiCompare : Implements System.Collections.IComparer
    Public Function Compare(ByVal awakusei As Object, ByVal bwakusei As Object) As Integer Implements IComparer.Compare
        If (CType(awakusei, wakuseinterface).ttno - CType(bwakusei, wakuseinterface).ttno) > 0 Then
            Return 1
        Else
            Return -1
        End If
    End Function
End Class
