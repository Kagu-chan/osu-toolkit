Option Compare Binary
Option Explicit On
Option Infer On
Option Strict On

Namespace osutoolkit

    ''' <summary>
    ''' Structure used for Filter Search in Mapsetprovider
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure MapsetProviderLoadArgument
        Public filter As ProviderFilter
        Public value As String

        Sub New(providerFilter As ProviderFilter, value As String)
            Me.filter = providerFilter
            Me.value = value
        End Sub

    End Structure

End Namespace