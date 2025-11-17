Namespace VO

    Public Class PaymentIn

        Private strPaymentInID As String
        Private dtPaymentDetDateTime, dtPaymentDate As DateTime
        Private strItemID, strServiceID, strRemarks, strCreatedBy As String
        Private intPrice, intQuantity, intTotalPrice, intTotalPayment As Integer


        Public Property PaymentInID As String
            Get
                Return strPaymentInID
            End Get
            Set(ByVal value As String)
                strPaymentInID = value
            End Set
        End Property

        Public Property Remarks As String
            Get
                Return strRemarks
            End Get
            Set(ByVal value As String)
                strRemarks = value
            End Set
        End Property

        Public Property PaymentDate() As DateTime
            Get
                Return dtPaymentDate
            End Get
            Set(ByVal value As DateTime)
                dtPaymentDate = value
            End Set
        End Property

        Public Property PaymentDetDateTime() As DateTime
            Get
                Return dtPaymentDetDateTime
            End Get
            Set(ByVal value As DateTime)
                dtPaymentDetDateTime = value
            End Set
        End Property

        Public Property ItemID() As String
            Get
                Return strItemID
            End Get
            Set(ByVal value As String)
                strItemID = value
            End Set
        End Property

        Public Property ServiceID() As String
            Get
                Return strServiceID
            End Get
            Set(ByVal value As String)
                strServiceID = value
            End Set
        End Property

        Public Property Price() As Integer
            Get
                Return intPrice
            End Get
            Set(ByVal value As Integer)
                intPrice = value
            End Set
        End Property


        Public Property Quantity() As Integer
            Get
                Return intQuantity
            End Get
            Set(ByVal value As Integer)
                intQuantity = value
            End Set
        End Property

        Public Property TotalPrice() As Integer
            Get
                Return intTotalPrice
            End Get
            Set(ByVal value As Integer)
                intTotalPrice = value
            End Set
        End Property

        Public Property TotalPayment() As Integer
            Get
                Return intTotalPayment
            End Get
            Set(ByVal value As Integer)
                intTotalPayment = value
            End Set
        End Property

        Public Property CreatedBy() As String
            Get
                Return strCreatedBy
            End Get
            Set(ByVal value As String)
                strCreatedBy = value
            End Set
        End Property

    End Class

End Namespace