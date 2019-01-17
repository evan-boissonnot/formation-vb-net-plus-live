Imports System.ComponentModel
Imports System.Threading

Public Class Form1
    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        Me.BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub backgroundwoerker_Progress(sender As Object, e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        Me.ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub backgroundwoerker_Completed(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Cancelled Then

        Else

        End If
    End Sub

    Private Sub backgroundWorker_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim index As Integer = 0

        While Not Me.BackgroundWorker1.CancellationPending AndAlso index <= 100
            If Me.BackgroundWorker1.CancellationPending Then
                e.Cancel = True

            Else
                Thread.Sleep(500)
                Me.BackgroundWorker1.ReportProgress(index)


                index = index + 1
            End If

        End While


    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.BackgroundWorker1.CancelAsync()
    End Sub
End Class
