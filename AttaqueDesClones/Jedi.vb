Public Class Jedi
    Public Property PointsDevie As Integer

    Public Sub Attaquer(clone As Clone, juge As Func(Of Jedi, Clone, Boolean))
        Dim resultat As Boolean = juge(Me, clone)

        If resultat Then
            clone.PointsDevie -= 10
        Else
            Me.PointsDevie -= 10
        End If
    End Sub
End Class
