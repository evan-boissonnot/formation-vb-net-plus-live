Module ModulePartial

    Sub Main()
        Dim monImrimeur As New Impression()

        monImrimeur.Imprimer()

        DecouverteParamArray(1, 2, 3)
        DecouverteParamArray(1, 2, 3, 4, 19, 35)
    End Sub

    Function DecouverteParamArray(ParamArray ByVal values As Integer()) As Integer
        Dim resultat As Integer = 0

        For index = 1 To values.Length
            resultat += values(index)
        Next

        Return resultat
    End Function
End Module
