Namespace VO

    Public Class MasterUser

        Private strLocationID, strUserID, strLocationName, strUserName, strPassword, strUserPosition As String
        Private strBirthPlace, strAddress, strIDType, strIDNumber, strNPWPNumber, strJamsostekID, strNoHP, strRemarks, strTitle, strBirthDateStr As String
        Private dtBirthDate, dtStartWorkingDate, dtCreatedDate, dtModifiedDate As DateTime
        Private bolIsActive, bolIsMasterUser As Boolean
        Private bolIsNotary, bolIsNotaryNew, bolIsNotaryProcess, bolIsNotaryCompleted, bolIsNotaryFalse As Boolean
        Private bolIsPPAT, bolIsPPATNew, bolIsPPATProcess, bolIsPPATBPNFinish, bolIsPPATCompleted, bolIsPPATFalse As Boolean
        Private bolIsAdminFee, bolIsP, bolIsCertificateSave As Boolean
        Private strUserGroupID, strMenuID As String

        Public Property LocationID() As String
            Get
                Return strLocationID
            End Get
            Set(ByVal value As String)
                strLocationID = value
            End Set
        End Property

        Public Property UserID() As String
            Get
                Return strUserID
            End Get
            Set(ByVal value As String)
                strUserID = value
            End Set
        End Property

        Public Property UserGroupID() As String
            Get
                Return strUserGroupID
            End Get
            Set(ByVal value As String)
                strUserGroupID = value
            End Set
        End Property

        Public Property LocationName() As String
            Get
                Return strLocationName
            End Get
            Set(ByVal value As String)
                strLocationName = value
            End Set
        End Property

        Public Property UserName() As String
            Get
                Return strUserName
            End Get
            Set(ByVal value As String)
                strUserName = value
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

        Public Property UserPosition() As String
            Get
                Return strUserPosition
            End Get
            Set(ByVal value As String)
                strUserPosition = value
            End Set
        End Property

        Public Property BirthPlace() As String
            Get
                Return strBirthPlace
            End Get
            Set(ByVal value As String)
                strBirthPlace = value
            End Set
        End Property

        Public Property BirthDate() As DateTime
            Get
                Return dtBirthDate
            End Get
            Set(ByVal value As DateTime)
                dtBirthDate = value
            End Set
        End Property

        Public Property Address() As String
            Get
                Return strAddress
            End Get
            Set(ByVal value As String)
                strAddress = value
            End Set
        End Property

        Public Property IDType() As String
            Get
                Return strIDType
            End Get
            Set(ByVal value As String)
                strIDType = value
            End Set
        End Property

        Public Property IDNumber() As String
            Get
                Return strIDNumber
            End Get
            Set(ByVal value As String)
                strIDNumber = value
            End Set
        End Property

        Public Property NPWPNumber() As String
            Get
                Return strNPWPNumber
            End Get
            Set(ByVal value As String)
                strNPWPNumber = value
            End Set
        End Property

        Public Property JamsostekID() As String
            Get
                Return strJamsostekID
            End Get
            Set(ByVal value As String)
                strJamsostekID = value
            End Set
        End Property

        Public Property NoHP() As String
            Get
                Return strNoHP
            End Get
            Set(ByVal value As String)
                strNoHP = value
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

        Public Property StartWorkingDate() As DateTime
            Get
                Return dtStartWorkingDate
            End Get
            Set(ByVal value As DateTime)
                dtStartWorkingDate = value
            End Set
        End Property

        Public Property CreatedDate() As DateTime
            Get
                Return dtCreatedDate
            End Get
            Set(ByVal value As DateTime)
                dtCreatedDate = value
            End Set
        End Property

        Public Property ModifiedDate() As DateTime
            Get
                Return dtModifiedDate
            End Get
            Set(ByVal value As DateTime)
                dtModifiedDate = value
            End Set
        End Property

        Public Property IsActive() As Boolean
            Get
                Return bolIsActive
            End Get
            Set(ByVal value As Boolean)
                bolIsActive = value
            End Set
        End Property

        Public Property IsMasterUser() As Boolean
            Get
                Return bolIsMasterUser
            End Get
            Set(ByVal value As Boolean)
                bolIsMasterUser = value
            End Set
        End Property

        Public Property IsNotary() As Boolean
            Get
                Return bolIsNotary
            End Get
            Set(ByVal value As Boolean)
                bolIsNotary = value
            End Set
        End Property

        Public Property IsNotaryNew() As Boolean
            Get
                Return bolIsNotaryNew
            End Get
            Set(ByVal value As Boolean)
                bolIsNotaryNew = value
            End Set
        End Property

        Public Property IsNotaryProcess() As Boolean
            Get
                Return bolIsNotaryProcess
            End Get
            Set(ByVal value As Boolean)
                bolIsNotaryProcess = value
            End Set
        End Property

        Public Property IsNotaryCompleted() As Boolean
            Get
                Return bolIsNotaryCompleted
            End Get
            Set(ByVal value As Boolean)
                bolIsNotaryCompleted = value
            End Set
        End Property

        Public Property IsNotaryFalse() As Boolean
            Get
                Return bolIsNotaryFalse
            End Get
            Set(ByVal value As Boolean)
                bolIsNotaryFalse = value
            End Set
        End Property

        Public Property IsPPAT() As Boolean
            Get
                Return bolIsPPAT
            End Get
            Set(ByVal value As Boolean)
                bolIsPPAT = value
            End Set
        End Property

        Public Property IsPPATNew() As Boolean
            Get
                Return bolIsPPATNew
            End Get
            Set(ByVal value As Boolean)
                bolIsPPATNew = value
            End Set
        End Property

        Public Property IsPPATProcess() As Boolean
            Get
                Return bolIsPPATProcess
            End Get
            Set(ByVal value As Boolean)
                bolIsPPATProcess = value
            End Set
        End Property

        Public Property IsPPATBPNFinish() As Boolean
            Get
                Return bolIsPPATBPNFinish
            End Get
            Set(ByVal value As Boolean)
                bolIsPPATBPNFinish = value
            End Set
        End Property

        Public Property IsPPATCompleted() As Boolean
            Get
                Return bolIsPPATCompleted
            End Get
            Set(ByVal value As Boolean)
                bolIsPPATCompleted = value
            End Set
        End Property

        Public Property IsPPATFalse() As Boolean
            Get
                Return bolIsPPATFalse
            End Get
            Set(ByVal value As Boolean)
                bolIsPPATFalse = value
            End Set
        End Property

        Public Property BirthDateStr() As String
            Get
                Return strBirthDateStr
            End Get
            Set(ByVal value As String)
                strBirthDateStr = value
            End Set
        End Property

        Public Property Title() As String
            Get
                Return strTitle
            End Get
            Set(ByVal value As String)
                strTitle = value
            End Set
        End Property

        Public Property IsAdminFee() As Boolean
            Get
                Return bolIsAdminFee
            End Get
            Set(ByVal value As Boolean)
                bolIsAdminFee = value
            End Set
        End Property

        Public Property IsP() As Boolean
            Get
                Return bolIsP
            End Get
            Set(ByVal value As Boolean)
                bolIsP = value
            End Set
        End Property

        Public Property IsCertificateSave() As Boolean
            Get
                Return bolIsCertificateSave
            End Get
            Set(ByVal value As Boolean)
                bolIsCertificateSave = value
            End Set
        End Property

        Public Property MenuID() As String
            Get
                Return strMenuID
            End Get
            Set(ByVal value As String)
                strMenuID = value
            End Set
        End Property
    End Class



End Namespace