'Imports System.Data.SqlClient
Imports System.Data

Namespace DAL
    Public MustInherit Class DALBase
        Private connectionStringValue As String

        Protected ReadOnly Property connectionString() As String
            Get
                Return connectionStringValue
            End Get
        End Property

        Public Sub New()
            connectionStringValue = CommonUtility.DBUtility.GetConnectionString
        End Sub

    End Class

End Namespace
