Module DecouverteTuples
    Sub Main()
        Dim valeur = RetournerTuple()

        Console.WriteLine(valeur.Item1)

        ' valeur.Item1 = "Hello" => readonly

        Dim valueTuple As (String, Integer) = valeur.ToValueTuple()

        valueTuple.Item1 = "Hello"


        Dim valueTuple2 As (String, Integer)
        valueTuple2 = ("DirectCast va ?", 18)

        Dim valueTupleNomme = (Nom:="jean-peirre", Index:=1)

        valueTupleNomme.Nom = "Gilbert"


    End Sub

    Function RetournerTuple() As Tuple(Of String, Integer)
        Dim monTuple As New Tuple(Of String, Integer)("coucou", 1)

        Return monTuple
    End Function

    Function RetournerSecondTuple() As Tuple(Of String, Integer)
        Dim str As String = "coucou"
        Dim i As Integer = 3

        Return New Tuple(Of String, Integer)(str, i)
    End Function
End Module
