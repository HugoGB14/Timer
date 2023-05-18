Public Class Form1
    Private ReadOnly dataDirectory = AppDomain.CurrentDomain.BaseDirectory
    Private Const Zero As Integer = 0
    Dim Sec = 0
    Dim Min = 0
    Dim SSec
    Dim SMin
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Sec -= 1
        ReCon()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Sec += 1
        ReCon()
    End Sub

    Public Sub ReCon()
        'Conitions of the Variables'
        If Sec = 60 Then
            Min += 1
            Sec = 0
        ElseIf Sec < 0 Then
            Min -= 1
            Sec = 59
        End If

        If Min < 0 Then
            Min = 0
            Sec = 0
        ElseIf Min > 60 Then
            Min = 60
        ElseIf Sec < 0 Then
            Sec = 0
        End If

        'Conitions to the Refresh'

        If Sec < 10 Then
            Label1.Text = Min.ToString + ":" + "0" + Sec.ToString
        Else
            Label1.Text = Min.ToString + ":" + Sec.ToString
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        SMin = Min
        SSec = Sec
        While Min > 0 Or Sec > 0
            SSSS()
            ReCon()
            Slepp()
        End While
        My.Computer.Audio.Play(dataDirectory + "..\..\sounds\Zero.wav")
    End Sub

    Private Sub SSSS()
        Sec -= 1
    End Sub

    Private Shared Sub Slepp()
        Threading.Thread.Sleep(1000)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Min = SMin
        Sec = SSec
        ReCon()
    End Sub
End Class
