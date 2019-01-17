Imports System.Net.Http

Module Module1

    Sub Main()
        Console.WriteLine($"Avant appel vers google ?")

        Task.Run(AddressOf GetContenuGoogle).Wait()

        ' pour lancer plus tard
        Dim tache As Task(Of String) = GetContenuWeb("sss")



        Console.WriteLine($"Apres appel vers google ?")

    End Sub

    Async Sub GetContenuGoogle()
        Dim contenu = Await GetContenuWeb("https://docs.microsoft.com/en-us/dotnet/visual-basic/getting-started/whats-new#visual-basic-14")
    End Sub

    Async Function GetContenuWeb(url As String) As Task(Of String)
        Dim client As New HttpClient()
        Dim content As String = ""

        Console.WriteLine("juste avant la reponse ? ")


        Try
            Dim reponse As HttpResponseMessage = Await client.GetAsync(url)

            Console.WriteLine("juste apres la reponse ? ")

            content = Await reponse.Content.ReadAsStringAsync()

            Console.WriteLine("juste apres la recup du contenu ? ")
        Catch ex As Exception
            Console.WriteLine(ex)
        End Try

        Return content
    End Function

End Module
