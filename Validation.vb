Module Validation
    ''' <summary>
    ''' Validate IDs
    ''' </summary>
    ''' <param name="idToValidate"></param>
    ''' <returns>True if integer > 0; otherwise false</returns>
    ''' <remarks></remarks>
    Function IsIdValid(ByVal idToValidate As String) As Boolean
        Dim parsedIdToValidate As Integer = 0

        If (String.IsNullOrWhiteSpace(idToValidate.Trim)) Then
            Return False
        Else
            If (Integer.TryParse(idToValidate.Trim, parsedIdToValidate)) Then
                If (parsedIdToValidate > 0) Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        End If
    End Function
End Module
