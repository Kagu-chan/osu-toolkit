osutoolkit.Misc
---------------

###Property UserPreferences (Dictionary(Of String, String))
Users preferences. [Before use please load user preferences](#sub-loaduserpreferences)
```
Dim mySetting As String = osutoolkit.Misc.UserPreferences("SettingName")
```

###ReadOnly Property OsuPath (String)
osu! executable path
```
Dim osuPath As String = osutoolkit.Misc.OsuPath
```

###ReadOnly Property SkinsPath (String)
osu! skins path
```
Dim skinPath As String = osutoolkit.Misc.SkinsPath
```

###ReadOnly Property ExportsPath (String)
osu! exports path
```
Dim exportsPath As String = osutoolkit.Misc.ExportsPath
```

###ReadOnly Property SongsPath (String)
osu! songs path depending on user preferences or default path
```
Dim songsPath As String = osutoolkit.Misc.SongsPath
```

###Function Path(pathAddition As String) (String)
Combines osu! executables path with other path partial
```
Dim chatsPath As String = osutoolkit.Misc.Path("Chat")
```

###Sub LoadUserPreferences()
Loads all user preferences
```
osutoolkit.Misc.LoadUserPreferences()
```

###Sub LoadUserPreferences(settings() As String)
Loads specific user preferences
```
osutoolkit.Misc.LoadUserPreferences({"Username", "LastPlayMode"})
Dim userName As String = osutoolkit.Misc.UserPreferences("Username")
```

###Function StringSetting(key As String) (String)
Returns specific preloaded user preference or nothing.

***This function will not raise an Exception if setting is not loaded. For this you have to check the result for NULL value***
```
Dim userName As String = osutoolkit.Misc.StringSetting("Username")
```

###Function IntSetting(key As String) (Integer)
Returns specific preloaded user preference as integer or nothing.

***This function will not raise an Exception if setting is not loaded. For this you have to check the result for NULL value***
```
Dim dimLevel As String = osutoolkit.Misc.IntSetting("DimLevel")
```

###Function DblSetting(key As String) (Double)
Returns specific preloaded user preference as double or nothing.

***This function will not raise an Exception if setting is not loaded. For this you have to check the result for NULL value***
```
Dim cursorSize As String = osutoolkit.Misc.DblSetting("CursorSize")
```

###Function BoolSetting(key As String) (Boolean)
Returns specific preloaded user preference as boolean or nothing.

***This function will not raise an Exception if setting is not loaded. For this you have to check the result for NULL value***
```
Dim autoCursorSizing As String = osutoolkit.Misc.BoolSetting("AutomaticCursorSizing")
```

###Function GetUserName()
Returns users logon name (windows)
```
Dim logonUserName = osutoolkit.Misc.GetUserName()
Dim osuConfigFile As String = String.Format("osu!.{0}.cfg", logonUserName)
```