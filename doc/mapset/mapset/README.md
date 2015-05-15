osutoolkit.Mapset
-----------------
Represents an osu! mapset

###Property Directory (String)
Directory where this mapset is located
```
Dim directory As String = instance.Directory
```

###Property Artist (String)
Artist by first difficulty found in mapset
***Artist may not be correct since its generated from first found difficulty filename and may be incorrect depending on '-' characters in filename!***
```
Dim title As String = instance.Title
```

###Property Title (String)
Title by first difficulty found in mapset
***Title may not be correct since its generated from first found difficulty filename and may be incorrect depending on '-' characters in filename!***
```
Dim artist As String = instance.Artist
```

###Property LoadedProperties (ProviderFilter)
Binary mask for loaded properties in mapset or difficulties
```
Dim properties As osutoolkit.ProviderFilter = instance.LoadedProperties
Dim hasLoadedTitle As Boolean = properties.HasFlag(osutoolkit.ProviderFilter.Title)
```

###Property Invalid (Boolean)
Indicates if a mapset is invalid. Will set to TRUE if there are any problems with it.
***An Beatmap will be set as Invalid if there any errors found. It can be used, but may contain lesser informations. An example of invalid beatmaps is a beatmapset where first difficulty don't contain artist information before first '-' character.***
```
If instance.Invalid Then Return
```

###Sub New(directory As String) (CONSTRUCTOR)
Rehash mapset by directory access
***An Beatmap-Instance don't contains many informations for performance reasons! To load informations, use [MapsetProvider](../mapsetprovider/README.md) or [LoadByFilter Function](#sub-loadbyfilter)***
```
Dim instance As New osutoolkit.Mapset(directory_of_map)
```

###Sub LoadByFilter(providerFilter As ProviderFilter)
Load properties of difficulties and mapset by given filter
```
instance.LoadByFilter(osutoolkit.ProviderFilter.Filter)
Console.WriteLine("Beatmaps Title is {0}", instance.Title)
```

###Function IsLoaded(filter As ProviderFilter) (Boolean)
Returns wether a property of difficulties or mapset is loaded or not
```
Dim directory As String = instance.Directory
```