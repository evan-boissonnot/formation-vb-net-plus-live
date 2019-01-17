Module Module1

    Sub Main()
        Dim listVerres As New List(Of Verre) From
        {
            New Verre() With {.Id = 1, .Nom = "Orma"},
            New Verre() With {.Id = 1, .Nom = "Ormix"},
            New Verre() With {.Id = 1, .Nom = "Varilux"}
        }

        Dim listClients As New List(Of Client) From
        {
            New Client() With {.Id = 1, .Nom = "Martin", .Prenom = "Jean-Yves"},
            New Client() With {.Id = 2, .Nom = "Durand", .Prenom = "JSophie"},
            New Client() With {.Id = 3, .Nom = "Dupond", .Prenom = "Archibal"}
        }

        Dim listLunettes As New List(Of Lunette) From
        {
            New Lunette() With {.Monture = "Rayban", .ClientId = 1, .Prix = 500, .VerreList = New List(Of Verre)() From {listVerres(0), listVerres(0)}},
            New Lunette() With {.Monture = "Rayban", .ClientId = 1, .Prix = 800, .VerreList = New List(Of Verre)() From {listVerres(1), listVerres(1)}},
            New Lunette() With {.Monture = "Channel", .ClientId = 2, .Prix = 800, .VerreList = New List(Of Verre)() From {listVerres(2), listVerres(2)}},
            New Lunette() With {.Monture = "Ripcurl", .ClientId = 3, .Prix = 300, .VerreList = New List(Of Verre)() From {listVerres(1), listVerres(2)}},
            New Lunette() With {.Monture = "Channel", .ClientId = 3, .Prix = 700, .VerreList = New List(Of Verre)() From {listVerres(0), listVerres(2)}},
            New Lunette() With {.Monture = "Rayban", .ClientId = 3, .Prix = 200, .VerreList = New List(Of Verre)() From {listVerres(2), listVerres(1)}}
        }

        'Dim query = From item In listClients
        '            Where item.Nom.StartsWith("D")
        '            Select item

        'Dim resultat = query.ToList()

        'For Each item As Client In query.OrderBy(Function(client) client.Nom)
        '    Console.WriteLine(item.Nom)
        'Next

        'Dim totalCA As Decimal = listClients.Sum(AddressOf RetournerCA)

        'Dim sousTotalCA As Decimal = query.Sum(Function(client As Client) As Decimal

        '                                           Return client.ChiffreAffaire
        '                                       End Function)

        'Dim sousTotalCA2 As Decimal = query.Sum(Function(client) client.ChiffreAffaire)

        'AfficherMinMaxClient(listClients)

        ClientEtLunettes_DecouverteJointure(listClients, listLunettes)
        RecuperationClientAvecVerre(listClients, listLunettes, "Varilux")
    End Sub

    Sub RecuperationClientAvecVerre(listCLients As List(Of Client), listLunettes As List(Of Lunette), ByVal nomVerre As String)
        Dim query = From client In listCLients
                    Join lunette In listLunettes
                        On client.Id Equals lunette.ClientId
                    Where lunette.VerreList.Any(Function(verre) verre.Nom = nomVerre)
                    Select client

        For Each item In query
            Console.WriteLine(item.Nom)
        Next
    End Sub

    Sub ClientEtLunettes_DecouverteJointure(listClients As List(Of Client), listLunettes As List(Of Lunette))
        Dim query = From client In listClients
                    Group Join lunette In listLunettes
                        On client.Id Equals lunette.ClientId
                    Into lunettes = Group, NbLunettes = Count(), MaxVerres = Max(lunette.VerreList.Count), PrixTotal = Sum(lunette.Prix)
                    Select client, lunettes, NbLunettes, MaxVerres, PrixTotal

        For Each item In query.Where(Function(it) it.PrixTotal > 800)
            Console.WriteLine($"Le client {item.client.Nom} a les lunettes suivantes ({item.NbLunettes} : {item.PrixTotal} €) : ")

            For Each lunette In item.lunettes
                Console.WriteLine($"- Lunette {lunette.Monture} ")
            Next
        Next

        ' pour récup client et lunettes, meme si pas de lunettes affectées à un client
        Dim queryLeftJoin = From client In listClients
                            Group Join lunette In listLunettes
                                On client.Id Equals lunette.ClientId Into Group
                            From gr In Group.DefaultIfEmpty()


    End Sub

    Sub AfficherMinMaxClient(listClient As List(Of Client))
        Dim min As Decimal = 0

        min = listClient.Min(Function(client) client.ChiffreAffaire)

        Dim query = From client In listClient
                    Where client.ChiffreAffaire = min


        Dim query2 = From client In listClient
                     Let minLocal = listClient.Min(Function(clt) clt.ChiffreAffaire)
                     Let caTTC = client.ChiffreAffaire * 1.2
                     Where client.ChiffreAffaire = minLocal
                     Select client, caTTC

        For Each item In query2
            Console.WriteLine($"Le {item.client.Nom} a un CA TTC de {item.caTTC}")
            Next

        Dim queryAgregat = Aggregate client In listClient
                           Into MinCA = Min(client.ChiffreAffaire), MaxCA = Max(client.ChiffreAffaire)

        Console.WriteLine($"Le min est {queryAgregat.MinCA} et le max est {queryAgregat.MaxCA}")
    End Sub

    Function RetournerCA(client As Client) As Decimal

        Return client.ChiffreAffaire
    End Function

End Module
