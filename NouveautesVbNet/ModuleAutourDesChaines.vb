Imports System.Text
Imports MaLibrarieCommune

Module ModuleAutourDesChaines
    Sub Main()
        Dim maChaine As String = ""

        For index = 1 To 1500
            maChaine += CStr(index)
        Next

        Dim builder As New StringBuilder()
        For index = 1 To 150000
            builder.Append(index)
        Next

        ' Console.WriteLine(builder.ToString())


        Dim nom As String = Console.ReadLine()
        Console.WriteLine("Bonjour, vous vous appelez " & nom)

        Console.WriteLine(String.Format("Bonjour, vous vous appelez {1} {0} ", nom, "toto"))

        Dim jedi As New Jedi() With {.NewProperty = "coucou"}

        Dim str As String = $"je teste avec une variable { jedi.NewProperty } "

        Console.WriteLine(str)
    End Sub
End Module
