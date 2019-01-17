Public Class Clone
    Delegate Sub Afficher(message As String)

    Public Sub Attaquer(affichage As Afficher)
        affichage("J'attaque")
    End Sub

    Public Sub SeDeplacer(ByVal donnerCoordonnes As Func(Of Tuple(Of Integer, Integer)),
                          affichage As Afficher)

        Dim tuple = donnerCoordonnes()

        affichage($"je me déplace vers x={tuple.Item1}, y={tuple.Item2}")
    End Sub

End Class
