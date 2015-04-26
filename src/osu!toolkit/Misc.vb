Option Compare Binary
Option Infer On
Option Explicit On
Option Strict On

Imports System.IO.Path
Imports System.Text.RegularExpressions

Namespace osutoolkit

    ''' <summary>
    ''' Miscellaneous functionality
    ''' </summary>
    ''' <remarks></remarks>
    Public Module Misc

        Private _osuRegistryPath As String = "HKEY_CLASSES_ROOT\osu!\shell\open\command"
        Private _songsPath As String = String.Empty
        Private _userName As String = String.Empty

        ''' <summary>
        ''' Users preferences. <seealso cref="LoadUserPreferences">Before use please load user preferences</seealso>.
        ''' </summary>
        ''' <remarks></remarks>
        Public UserPreferences As New Dictionary(Of String, String)

        ''' <summary>
        ''' osu! executable path
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property OsuPath As String
            Get
                Dim command As String = CStr(My.Computer.Registry.GetValue(_osuRegistryPath, "", Nothing))
                Dim commands() As String = command.Split(""""c)
                Return GetDirectoryName(commands(1))
            End Get
        End Property

        ''' <summary>
        ''' osu! skins path
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property SkinsPath As String
            Get
                Return Path("Skins")
            End Get
        End Property

        ''' <summary>
        ''' osu! exports path
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ExportsPath As String
            Get
                Return Path("Exports")
            End Get
        End Property

        ''' <summary>
        ''' osu! songs path depending on user preferences or default path
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property SongsPath As String
            Get
                If String.IsNullOrEmpty(_songsPath) Then
                    LoadUserPreferences({"BeatmapDirectory"})
                    _songsPath = StringSetting("BeatmapDirectory")
                End If

                Return Path(_songsPath)
            End Get
        End Property

        ''' <summary>
        ''' Combines osu! executables path with other path partial
        ''' </summary>
        ''' <param name="pathAddition">path addition</param>
        ''' <returns>New path based on osu! executable path</returns>
        ''' <remarks></remarks>
        Public Function Path(ByVal pathAddition As String) As String
            Return Combine(OsuPath, pathAddition)
        End Function

        ''' <summary>
        ''' Loads all user preferences
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub LoadUserPreferences()
            If String.IsNullOrEmpty(_userName) Then LoadUserName()

            Dim fileName As String = String.Format("osu!.{0}.cfg", _userName)
            Dim lines As IEnumerable(Of String) = IO.File.ReadAllLines(Path(fileName))
            Dim findPattern As New Regex("^@?(\w+)\s?=\s?(.+)$", RegexOptions.IgnoreCase)

            For Each line As String In lines
                Dim match As Match = findPattern.Match(line)
                If match.Success Then
                    UserPreferences(match.Groups(1).Value) = match.Groups(2).Value.Replace(Chr(13), vbNullString)
                End If
            Next
        End Sub

        ''' <summary>
        ''' Loads specific user preferences
        ''' </summary>
        ''' <param name="settings">List of settings to fetch</param>
        ''' <remarks></remarks>
        Public Sub LoadUserPreferences(ByVal settings() As String)
            If String.IsNullOrEmpty(_userName) Then LoadUserName()

            Dim fileName As String = String.Format("osu!.{0}.cfg", _userName)
            Dim content As String = IO.File.ReadAllText(Path(fileName))

            For Each setting As String In settings
                Dim expression As New Regex(String.Format("^{0}\s?=\s?(.+)$", setting), RegexOptions.Multiline Or RegexOptions.IgnoreCase)
                Dim result As Match = expression.Match(content)
                If result.Success Then
                    UserPreferences(setting) = result.Groups(1).Value.Replace(Chr(13), vbNullString)
                End If
            Next
        End Sub

        ''' <summary>
        ''' Returns specific preloaded user preference or nothing
        ''' </summary>
        ''' <param name="key">setting to fetch</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function StringSetting(ByVal key As String) As String
            If UserPreferences.Keys.Contains(key) Then
                Return UserPreferences(key)
            End If

            Return Nothing
        End Function

        ''' <summary>
        ''' Returns specific preloaded user preference as integer or nothing
        ''' </summary>
        ''' <param name="key">setting to fetch</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IntSetting(ByVal key As String) As Integer
            Dim setting As String = StringSetting(key)
            If Not String.IsNullOrEmpty(setting) Then
                Return CInt(setting)
            End If

            Return Nothing
        End Function

        ''' <summary>
        ''' Returns specific preloaded user preference as double or nothing
        ''' </summary>
        ''' <param name="key">setting to fetch</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function DblSetting(ByVal key As String) As Double
            Dim setting As String = StringSetting(key)
            If Not String.IsNullOrEmpty(setting) Then
                Return Convert.ToDouble(setting, New Globalization.CultureInfo("en-US"))
            End If

            Return Nothing
        End Function

        ''' <summary>
        ''' Returns specific preloaded user preference as boolean or nothing
        ''' </summary>
        ''' <param name="key">setting to fetch</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function BoolSetting(ByVal key As String) As Boolean
            Dim setting As String = StringSetting(key)
            If Not String.IsNullOrEmpty(setting) Then
                Return setting = "1"
            End If

            Return Nothing
        End Function

        ''' <summary>
        ''' Returns users profile link. Only works if 'SaveUsername' is set to TRUE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetOsuUserProfileLink() As String
            LoadUserPreferences({"Username"})
            Dim name As String = StringSetting("Username")
            Dim link As New Uri(String.Format("https://osu.ppy.sh/u/{0}", name))
            Return link.AbsoluteUri()
        End Function

        ''' <summary>
        ''' Returns users logon name (windows)
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetUserName() As String
            Return Environment.UserName
        End Function

        Private Sub LoadUserName()
            _userName = GetUserName()
        End Sub

    End Module

End Namespace
