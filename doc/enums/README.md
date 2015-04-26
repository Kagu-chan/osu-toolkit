osutoolkit Enums
-----------------

###Enum GameMode
Represent Mode of osu!game
```
Dim mode As GameMode = osutoolkit.GameMode.Standard
```

###Enum SampleType
Represent sample type of hitsound addition or beatmap sampleset
```
Dim sampleType As SampleType = osutoolkit.SampleType.Soft
```

###Enum Hitsound
Represent sample to play

This is a flags enum (bitmask)!
```
Dim hitsound As Hitsound = osutoolkit.Hitsound.Whiste Or osutoolkit.Hitsound.Finnish
```