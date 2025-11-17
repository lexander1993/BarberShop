Namespace VO
    Public Class ReportProfit

        Private dtTransDate As Date
        Private decSellingPrice, decSellingPriceNS, decBeginningPrice As Decimal

        ' Property for dtTransDate
        Public Property TransDate() As Date
            Get
                Return dtTransDate
            End Get
            Set(ByVal value As Date)
                dtTransDate = value
            End Set
        End Property

        ' Property for decSellingPrice
        Public Property SellingPrice() As Decimal
            Get
                Return decSellingPrice
            End Get
            Set(ByVal value As Decimal)
                decSellingPrice = value
            End Set
        End Property

        ' Property for decSellingPriceNS
        Public Property SellingPriceNS() As Decimal
            Get
                Return decSellingPriceNS
            End Get
            Set(ByVal value As Decimal)
                decSellingPriceNS = value
            End Set
        End Property

        ' Property for decBeginningPrice
        Public Property BeginningPrice() As Decimal
            Get
                Return decBeginningPrice
            End Get
            Set(ByVal value As Decimal)
                decBeginningPrice = value
            End Set
        End Property

    End Class
End Namespace

