''' <summary>
''' Cette classe représente un jedi
''' </summary>
Public Class Jedi
    Private _maProp As Integer
    Public Property NewProperty() As Integer
        Get
            Return _maProp
        End Get
        Set(ByVal value As Integer)
            _maProp = value
        End Set
    End Property

    ''' <summary>
    ''' Utilisez cette méthode pour attaquer un jedi du cote obscur
    ''' </summary>
    ''' <param name="jediMechant">Attention c'est un jedi et pas atre chose</param>
    ''' <param name="i"></param>
    Public Sub Attaquer(ByVal jediMechant As Jedi, i As Integer)
        If i = 99 Then
            Throw New Exception()
        End If
    End Sub

End Class
