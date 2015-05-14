Option Compare Binary
Option Explicit On
Option Infer On
Option Strict On

Namespace osutoolkit

    ''' <summary>
    ''' Provider for mapsets. This class search and instanciate mapsets
    ''' </summary>
    ''' <remarks></remarks>
    Public Class MapsetProvider

        Private Shared _prepared As Boolean = False

        ''' <summary>
        ''' List of all found mapsets
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Mapsets As New List(Of Mapset)

        ''' <summary>
        ''' Thin preload of all mapsets
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub Prepare()
            If _prepared Then Return
            Dim directories As IEnumerable(Of String) = My.Computer.FileSystem.GetDirectories(Misc.SongsPath, FileIO.SearchOption.SearchTopLevelOnly)
            For Each directory As String In directories
                Dim mapset As New Mapset(directory)
                mapset.LoadByFilter(ProviderFilter.Difficulty)
                Mapsets.Add(mapset)
            Next
        End Sub

        Private Shared Sub PrepareIfRequired(prepareFilter As ProviderFilter, completeFilter As ProviderFilter)
            If prepareFilter = ProviderFilter.None Or Not completeFilter.HasFlag(prepareFilter) Then Return

            For Each current As Mapset In (From map As Mapset In Mapsets Where Not map.Invalid And Not map.IsLoaded(prepareFilter))
                current.LoadByFilter(prepareFilter)
            Next
        End Sub

        ''' <summary>
        ''' Load required properties in all mapsets
        ''' </summary>
        ''' <param name="filter"></param>
        ''' <remarks></remarks>
        Public Shared Sub PrepareSpecific(filter As ProviderFilter)
            Prepare()
            For Each name As String In [Enum].GetNames(GetType(ProviderFilter))
                PrepareIfRequired(DirectCast([Enum].Parse(GetType(ProviderFilter), name), ProviderFilter), filter)
            Next
        End Sub

        ''' <summary>
        ''' Search mapsets matching given considitons
        ''' </summary>
        ''' <param name="conditions"></param>
        ''' <remarks></remarks>
        Public Shared Function Find(conditions() As MapsetProviderLoadArgument) As IEnumerable(Of Mapset)
            Dim loadFilter As ProviderFilter = ProviderFilter.None
            For Each condition As MapsetProviderLoadArgument In conditions
                loadFilter = loadFilter Or condition.filter
            Next

            PrepareSpecific(loadFilter)

            Return Nothing
        End Function

    End Class

End Namespace
