Option Compare Binary
Option Explicit On
Option Infer On
Option Strict On

Imports System.Text.RegularExpressions

Namespace osutoolkit

    ''' <summary>
    ''' Represents an osu! mapset
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Mapset

        ''' <summary>
        ''' Directory where this mapset is located
        ''' </summary>
        ''' <remarks></remarks>
        Public Directory As String

        ''' <summary>
        ''' Artist by first difficulty found in mapset
        ''' </summary>
        ''' <remarks></remarks>
        Public Artist As String = String.Empty

        ''' <summary>
        ''' Title by first difficulty found in mapset
        ''' </summary>
        ''' <remarks></remarks>
        Public Title As String = String.Empty

        ''' <summary>
        ''' Binary mask for loaded properties in mapset or difficulties
        ''' </summary>
        ''' <remarks></remarks>
        Public LoadedProperties As ProviderFilter = ProviderFilter.None

        ''' <summary>
        ''' Indicates if a mapset is invalid. Will set to TRUE if there are any problems with it.
        ''' </summary>
        ''' <remarks></remarks>
        Public Invalid As Boolean = False

        ''' <summary>
        ''' Rehash mapset by directory access
        ''' </summary>
        ''' <param name="directory"></param>
        ''' <remarks></remarks>
        Public Sub New(directory As String)
            Me.Directory = directory

            Dim referDiff As String = My.Computer.FileSystem.GetFiles(directory, FileIO.SearchOption.SearchTopLevelOnly, "*.osu").FirstOrDefault()
            If String.IsNullOrEmpty(referDiff) Then
                Invalid = True
                Return
            End If

            Dim text() As String = IO.Path.GetFileNameWithoutExtension(referDiff).Split({"-"c}, 2)
            If text.Length <> 2 Then
                Invalid = True
                Return
            End If

            Artist = text(0)
            Title = text(1)
            Title = Title.Substring(0, Title.IndexOf("("))
        End Sub

        ''' <summary>
        ''' Load properties of difficulties and mapset by given filter
        ''' </summary>
        ''' <param name="providerFilter"></param>
        ''' <remarks></remarks>
        Public Sub LoadByFilter(providerFilter As ProviderFilter)
            LoadedProperties = LoadedProperties Or providerFilter
        End Sub

        ''' <summary>
        ''' Returns wether a property of difficulties or mapset is loaded or not
        ''' </summary>
        ''' <param name="filter"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IsLoaded(filter As ProviderFilter) As Boolean
            Return LoadedProperties.HasFlag(filter)
        End Function

    End Class

End Namespace