Partial Public Class Impression
    Private _type As String
    Public Property NewProperty() As String
        Get
            Return _type
        End Get
        Set(ByVal value As String)
            _type = value
        End Set
    End Property

    Public Sub Imprimer()
        Me.PremiereEtapeImpression()
    End Sub

    Partial Private Sub PremiereEtapeImpression()
    End Sub
End Class
