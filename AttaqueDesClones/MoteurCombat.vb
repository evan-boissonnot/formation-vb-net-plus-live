Public Class MoteurCombat
    Public Function VerifierGagnant(jedi As Jedi, clone As Clone) As Boolean
        Dim rand As New Random()

        Dim resultat = rand.Next(0, 2)

        Return resultat = 0
    End Function
End Class
