Imports System.Net.Http
Imports System.Threading

Public Class Form1
    Private cancel As CancellationTokenSource

    Private Async Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        Try
            Me.cancel = New CancellationTokenSource()

            Me.TextBox1.Text = Await Me.GetContentAsync(Me.cancel.Token)


        Catch ex As OperationCanceledException
            Me.Label1.Text = "L'opération a bien été annulée"


        Catch ex2 As Exception
        Finally
            Me.cancel?.Dispose()
        End Try
    End Sub

    Private Async Function GetContentAsync(cancelToken As CancellationToken) As Task(Of String)
        Dim client As New HttpClient()

        Await Task.Delay(1000)

        Dim reponse As HttpResponseMessage = Await client.GetAsync("http://www.google.fr", cancelToken)

        Dim content As String = Await reponse.Content.ReadAsStringAsync()

        Return content
    End Function

    Private Sub btnAnnuler_Click(sender As Object, e As EventArgs) Handles btnAnnuler.Click
        'equivalent 
        ' If Me.cancel IsNot Nothing Then
        '    Me.cancel.Cancel()
        'End If

        Me.cancel?.Cancel()
    End Sub
End Class
