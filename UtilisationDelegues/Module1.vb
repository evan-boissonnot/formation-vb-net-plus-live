Module Module1

    Sub Main()
        Dim clone As New Clone()

        clone.Attaquer(AddressOf AfficherMessage)
        clone.Attaquer(AddressOf AfficherMessageRouge)

        clone.Attaquer(AddressOf Console.WriteLine)

        clone.Attaquer(Sub(ByVal message As String)
                           Console.WriteLine($"coucou {message}")
                       End Sub)

        clone.SeDeplacer(AddressOf CalculerCoordonnes, AddressOf Console.WriteLine)
    End Sub

    Function CalculerCoordonnes() As Tuple(Of Integer, Integer)
        Return New Tuple(Of Integer, Integer)(1, 3)
    End Function

    Sub AfficherMessage(ByVal message As String)
        Console.WriteLine(message)
    End Sub

    Sub AfficherMessageRouge(ByVal message As String)
        Console.ForegroundColor = ConsoleColor.Red
        Console.WriteLine(message)
    End Sub

End Module
