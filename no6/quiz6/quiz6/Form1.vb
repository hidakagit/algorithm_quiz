'植物それぞれの情報を格納
Public Structure flowerstructure
    Public index As Integer
    Public x_i As Integer
    Public y_i As Integer
    Public cycle As Integer
End Structure

'2つの植物間の距離関係を格納 
Public Structure flowerdistance
    Public index_a As Integer
    Public index_b As Integer
    Public distance As Double
End Structure

Public Class Form1

    Public flower() As flowerstructure
    Public N As Integer
    Public flower_distance() As flowerdistance
    Public fstr As String '植物情報文字列

    Private Sub 初期化()
        flower = Nothing
        TextBox2.Text = ""
    End Sub

    Private Sub 植物情報取得()
        fstr = RichTextBox1.Text
        N = Val(TextBox1.Text)

        Dim ftmp() As String
        ftmp = Split(fstr.Replace("(", "").Replace(")", ""), ", ")
        For i As Integer = 0 To ftmp.Length - 1
            Select Case (i Mod 3)
                Case 0
                    ReDim Preserve flower(i \ 3)
                    With flower(i \ 3)
                        .index = i \ 3
                        .x_i = ftmp(i)
                    End With
                Case 1
                    flower(i \ 3).y_i = ftmp(i)
                Case 2
                    flower(i \ 3).cycle = ftmp(i)
            End Select
        Next

    End Sub

    '2つの植物の距離
    Private Function 植物距離(ByVal aflower As Integer, ByVal bflower As Integer) As Double
        Return ((flower(aflower).x_i - flower(bflower).x_i) ^ 2 + (flower(aflower).y_i - flower(bflower).y_i) ^ 2) ^ (1 / 2) + _
            flower(aflower).cycle + flower(bflower).cycle
    End Function

    Private Function 計算本体() As Double
        Dim counter As Integer = 0

        For i As Integer = 0 To flower.Length - 2
            For j As Integer = i + 1 To flower.Length - 1
                ReDim Preserve flower_distance(counter)
                With flower_distance(counter)
                    .distance = 植物距離(i, j)
                    .index_a = i
                    .index_b = j
                End With
                counter = counter + 1
            Next
        Next

        '降順にソートし、最も距離が遠いところで分割
        Array.Sort(flower_distance, New flowerdistanceCompare)
        Array.Reverse(flower_distance)

        Select Case N
            Case 1
                Return 0
            Case 2
                Return (flower_distance(0).distance / 2.0)
            Case Else 'Nが3個以上の時が問題
                Dim max_a, max_b As Integer
                Dim ave_a, ave_b As Double

                Dim decide_i As Integer = 1
                With flower_distance(0)
                    max_a = .index_a
                    max_b = .index_b
                End With

                'カウンター
                Dim counttmp_a As Integer = 0
                Dim counttmp_b As Integer = 0
                Dim sum_a As Double = 0
                Dim sum_b As Double = 0
                '最も離れている点から各点への平均距離
                For i As Integer = 1 To flower_distance.Length - 1
                    'max_aから各点への平均距離
                    If flower_distance(i).index_a = max_a Or flower_distance(i).index_b = max_a Then
                        sum_a = sum_a + flower_distance(i).distance
                        counttmp_a = counttmp_a + 1
                    End If
                    'max_bから各点への平均距離
                    If flower_distance(i).index_a = max_b Or flower_distance(i).index_b = max_b Then
                        sum_b = sum_b + flower_distance(i).distance
                        counttmp_b = counttmp_b + 1
                    End If
                    ave_a = sum_a / counttmp_a
                    ave_b = sum_b / counttmp_b
                Next

                'より周りから遠い点を下では避ける
                Dim max_dispoint As Integer
                If ave_a > ave_b Then
                    max_dispoint = max_a
                Else
                    max_dispoint = max_b
                End If

                'このmax_dispointを含むようなルートは基本的に避けなければならない
                For i As Integer = 1 To flower_distance.Length - 1
                    If Not (flower_distance(i).index_a = max_dispoint Or flower_distance(i).index_b = max_dispoint) Then
                        Return (flower_distance(i).distance / 2.0)
                    End If
                Next
        End Select
        'エラー
        Return -1
    End Function

    Private Sub 計算(sender As Object, e As EventArgs) Handles Button1.Click

        Call 初期化()
        Call 植物情報取得()

        If Not flower.Length = N Then
            MsgBox("Nの数と植物の数が一致しません")
            Exit Sub
        End If

        '答えを求める
        TextBox2.Text = 計算本体()

    End Sub

End Class

'flowerdistanceを比較するためのインターフェイス
Public Class flowerdistanceCompare : Implements System.Collections.IComparer
    Public Function Compare(ByVal aflower As Object, ByVal bflower As Object) As Integer Implements IComparer.Compare
        If (CType(aflower, flowerdistance).distance - CType(bflower, flowerdistance).distance) > 0 Then
            Return 1
        Else
            Return -1
        End If
    End Function
End Class