Namespace VO

    Public Class User

        Private strID, strName, strPassword, strEmail, strExtNumber, strHeadID As String

        Public Property ID() As String
            Get
                Return strID
            End Get
            Set(ByVal value As String)
                strID = value
            End Set
        End Property

        Public Property Name() As String
            Get
                Return strName
            End Get
            Set(ByVal value As String)
                strName = value
            End Set
        End Property

        Public Property Password() As String
            Get
                Return strPassword
            End Get
            Set(ByVal value As String)
                strPassword = value
            End Set
        End Property

        Public Property Email() As String
            Get
                Return strEmail
            End Get
            Set(ByVal value As String)
                strEmail = value
            End Set
        End Property

        Public Property ExtNumber() As String
            Get
                Return strExtNumber
            End Get
            Set(ByVal value As String)
                strExtNumber = value
            End Set
        End Property

        Public Property HeadID() As String
            Get
                Return strHeadID
            End Get
            Set(ByVal value As String)
                strHeadID = value
            End Set
        End Property

    End Class

End Namespace
