Imports MaLibrarieCommune

Module ExerciceJediEtConcat
    Sub Main()
        Dim list As New List(Of Jedi) From {
            New Jedi(),
            New Jedi(),
            New Jedi(),
            New Jedi(),
            New Jedi()
        }

        AfficherInfoJedi(list)

        Dim listVide As New List(Of Jedi)()
        AfficherInfoJedi(list)

    End Sub

    Sub AfficherInfoJedi(maList As List(Of Jedi))
        Console.WriteLine($"Il y a {maList.Count} jedi{Plurialize(maList.Count)}")

        ' meme fonctionnement sans fonction appelée : 
        'Console.WriteLine($"Il y a {maList.Count} jedi{If(maList.Count > 1, "s", "")}")
    End Sub

    Function Plurialize(ByVal nbInteger As Integer) As String
        Return IIf(nbInteger > 1, "s", "")
    End Function
End Module
