Public Class MoteurDeJeu
    Public Sub Demarrer(afficher As Action(Of String))
        Dim jedi As New Jedi() With {.PointsDevie = 100}
        Dim clone As New Clone() With {.PointsDevie = 100}

        Dim juge As New MoteurCombat()

        jedi.Attaquer(clone, AddressOf Me.VerifierGagnantAMoi)

        jedi.Attaquer(clone, Function(j As Jedi, c As Clone) As Boolean
                                 Return True
                             End Function)

        afficher($"le jedi a {jedi.PointsDevie}, le clone a {clone.PointsDevie}")
    End Sub

    Public Function VerifierGagnantAMoi(jedi As Jedi, clone As Clone) As Boolean
        Dim rand As New Random()

        Dim resultat = rand.Next(0, 20)

        Return resultat = 18
    End Function
End Class
