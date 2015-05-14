osutoolkit.MapsetProvider
-------------------------
Provider for mapsets. This class search and instanciate mapsets

###Property Mapsets (List(Of Mapset))
List of all found mapsets
```
Dim list As List(Of Mapset) = osutoolkit.MapsetProvider.Mapsets
```

###Sub Prepare()
Thin preload of all mapsets
```
osutoolkit.MapsetProvider.Prepare()
Dim list As List(Of Mapset) = osutoolkit.MapsetProvider.Mapsets
```

###Sub PrepareSpecific(filter As ProviderFilter)
Load required properties in all mapsets
```
osutoolkit.MapsetProvider.PrepareSpecific(ProviderFilter.AudioFilename)
```

###Function Find(conditions() As MapsetProviderLoadArgument) (IEnumerable(of Mapset))
Search mapsets matching given considitons
```
Dim maps as IEnumerable(Of Mapset) = osutoolkit.MapsetProvider.Find({
		New MapsetProviderLoadArgument(ProviderFilter.Artist, "Natsume Chiaki"),
		New MapsetProviderLoadArgument(ProviderFilter.Title, "Hanairo Biyori")
})