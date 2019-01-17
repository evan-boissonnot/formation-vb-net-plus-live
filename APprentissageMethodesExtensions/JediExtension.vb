Imports System.Runtime.CompilerServices
Imports MaLibrarieCommune

Module JediExtension
    <Extension()>
    Public Sub SeDeplacer(Jedi As Jedi, x As Integer, y As Integer)
        Console.WriteLine($"Je me déplace {x} et {y}")
    End Sub
End Module
