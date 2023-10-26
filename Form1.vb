Imports System.Threading

Public Class Form1
    Private ReadOnly dataDirectory = AppDomain.CurrentDomain.BaseDirectory
    Private Const Zero As Integer = 0
    Dim ms = 0
    Dim Sec = 0
    Dim Min = 0
    Dim SSec = 1
    Dim SMin = 0
    Dim J = 1
    Dim xD = 59
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Sec -= J
        ReCon()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Sec += J
        ReCon()
    End Sub

    Public Sub ReCon()
        'Conitions of the Variables'
        If Sec > 59 Then
            Min += 1
            Sec = Sec - 60
        ElseIf Sec < 0 Then
            Min -= 1
            Sec = xD
        End If

        If Min < 0 Then
            Min = 0
            Sec = 0
        ElseIf Min > 60 Then
            Min = 60
            If Sec > 0 Then
                Sec = 60
            End If
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
        J = 1
        xD = 59
        ' Creamos un nuevo hilo para contar el tiempo
        Dim thread As New Thread(Sub()
                                     While Min > 0 Or Sec > 0
                                         SSSS()

                                         ' Actualizar la interfaz de usuario utilizando Invoke
                                         Me.Invoke(Sub()
                                                       ReCon()
                                                   End Sub)

                                         Slepp()
                                     End While

                                     ' Cuando termine, reproducir el sonido
                                     Me.Invoke(Sub()
                                                   My.Computer.Audio.Play(dataDirectory + "..\..\sounds\Zero.wav")
                                               End Sub)
                                 End Sub)

        ' Iniciamos el hilo
        thread.Start()
        If ms = 1 Then
            J = 60
            xD = 0
        End If
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

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        J = 1
        xD = 59
        ms = 0
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        J = 60
        xD = 0
        ms = 1
    End Sub
End Class
