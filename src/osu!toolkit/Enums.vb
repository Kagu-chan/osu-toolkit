Option Compare Binary
Option Explicit On
Option Infer On
Option Strict On

Namespace osutoolkit

    ''' <summary>
    ''' Represent Mode of osu!game
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum GameMode
        Undefined = -1
        Standard = 0
        Taiko = 1
        CatchTheBeat = 2
        Mania = 3
    End Enum

    ''' <summary>
    ''' Represent sample type of hitsound addition or beatmap sampleset
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum SampleType
        None = -1
        Auto = 0
        Normal = 1
        Soft = 2
        Drum = 3
    End Enum

    ''' <summary>
    ''' Represent sample to play
    ''' </summary>
    ''' <remarks></remarks>
    <Flags()>
    Public Enum Hitsound
        None = 0
        Whistle = 2
        Finnish = 4
        Clap = 8
    End Enum

    ''' <summary>
    ''' Represents a filter for MapsetProvider
    ''' </summary>
    ''' <remarks></remarks>
    <Flags()>
    Public Enum ProviderFilter
        None = 0
        Difficulty = 1
        AudioFilename = 2
        Title = 4
        Artist = 8
    End Enum

End Namespace