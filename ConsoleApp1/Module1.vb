Imports MaLibrarieCommune

Module Module1

    Sub Main()
        Dim monjedi As New Jedi()

        For index = 1 To 100
            monjedi.Attaquer(monjedi, index)
        Next

    End Sub

End Module
