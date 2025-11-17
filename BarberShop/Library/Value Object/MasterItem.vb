Namespace VO

    Public Class MasterItem

        Private strItemID, strItemName, strAltName, strRemarks As String
        Private intBeginningPrice, intSellingPrice As Integer
        Private bolIsBarber, bolIsAdd As Boolean


        Public Property ItemID() As String
            Get
                Return strItemID
            End Get
            Set(ByVal value As String)
                strItemID = value
            End Set
        End Property

        Public Property ItemName() As String
            Get
                Return strItemName
            End Get
            Set(ByVal value As String)
                strItemName = value
            End Set
        End Property

        Public Property AltName() As String
            Get
                Return strAltName
            End Get
            Set(ByVal value As String)
                strAltName = value
            End Set
        End Property

        Public Property Remarks() As String
            Get
                Return strRemarks
            End Get
            Set(ByVal value As String)
                strRemarks = value
            End Set
        End Property

        Public Property BeginningPrice() As Integer
            Get
                Return intBeginningPrice
            End Get
            Set(ByVal value As Integer)
                intBeginningPrice = value
            End Set
        End Property

        Public Property SellingPrice() As Integer
            Get
                Return intSellingPrice
            End Get
            Set(ByVal value As Integer)
                intSellingPrice = value
            End Set
        End Property

        Public Property IsBarber() As Boolean
            Get
                Return bolIsBarber
            End Get
            Set(ByVal value As Boolean)
                bolIsBarber = value
            End Set
        End Property

        Public Property IsAdd() As Boolean
            Get
                Return bolIsAdd
            End Get
            Set(ByVal value As Boolean)
                bolIsAdd = value
            End Set
        End Property
    End Class

End Namespace