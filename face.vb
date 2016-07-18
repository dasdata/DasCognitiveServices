Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Public Class face
#Region "Fields"

    ''' <summary>
    ''' Face gender text string
    ''' </summary>
    Private _gender As String

    ''' <summary>
    ''' Face age text string
    ''' </summary>
    Private _age As String

    ''' <summary>
    ''' Person name
    ''' </summary>
    Private _personName As String

    ''' <summary>
    ''' Face height in pixel
    ''' </summary>
    Private _height As Integer

    ''' <summary>
    ''' Face position X relative to image left-top in pixel
    ''' </summary>
    Private _left As Integer

    ''' <summary>
    ''' Face position Y relative to image left-top in pixel
    ''' </summary>
    Private _top As Integer

    ''' <summary>
    ''' Face width in pixel
    ''' </summary>
    Private _width As Integer

    ''' <summary>
    ''' Facial hair display string
    ''' </summary>
    Private _facialHair As String

    ''' <summary>
    ''' Indicates whether the face is smile or not
    ''' </summary>
    Private _isSmiling As String

    ''' <summary>
    ''' Indicates the glasses type
    ''' </summary>
    Private _glasses As String

#End Region

#Region "Events"

    ''' <summary>
    ''' Implement INotifyPropertyChanged interface
    ''' </summary>
    Public Event PropertyChanged As PropertyChangedEventHandler

#End Region

#Region "Properties"

    ''' <summary>
    ''' Gets or sets gender text string 
    ''' </summary>
    Public Property Gender() As String
        Get
            Return _gender
        End Get

        Set
            _gender = Value
            OnPropertyChanged(Of String)()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets age text string
    ''' </summary>
    Public Property Age() As String
        Get
            Return _age
        End Get

        Set
            _age = Value
            OnPropertyChanged(Of String)()
        End Set
    End Property

    ''' <summary>
    ''' Gets face rectangle on image
    ''' </summary>
    Public ReadOnly Property UIRect() As System.Windows.Int32Rect
        Get
            Return New System.Windows.Int32Rect(Left, Top, Width, Height)
        End Get
    End Property

    ''' <summary>
    ''' Gets or sets image path
    ''' </summary>
    Public Property ImagePath() As String
        Get
            Return m_ImagePath
        End Get
        Set
            m_ImagePath = Value
        End Set
    End Property
    Private m_ImagePath As String

    ''' <summary>
    ''' Gets or sets face id
    ''' </summary>
    Public Property FaceId() As String
        Get
            Return m_FaceId
        End Get
        Set
            m_FaceId = Value
        End Set
    End Property
    Private m_FaceId As String

    ''' <summary>
    ''' Gets or sets person's name
    ''' </summary>
    Public Property PersonName() As String
        Get
            Return _personName
        End Get

        Set
            _personName = Value
            OnPropertyChanged(Of String)()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets face height
    ''' </summary>
    Public Property Height() As Integer
        Get
            Return _height
        End Get

        Set
            _height = Value
            OnPropertyChanged(Of Integer)()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets face position X
    ''' </summary>
    Public Property Left() As Integer
        Get
            Return _left
        End Get

        Set
            _left = Value
            OnPropertyChanged(Of Integer)()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets face position Y
    ''' </summary>
    Public Property Top() As Integer
        Get
            Return _top
        End Get

        Set
            _top = Value
            OnPropertyChanged(Of Integer)()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets face width
    ''' </summary>
    Public Property Width() As Integer
        Get
            Return _width
        End Get

        Set
            _width = Value
            OnPropertyChanged(Of Integer)()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets facial hair display string
    ''' </summary>
    Public Property FacialHair() As String
        Get
            Return _facialHair
        End Get

        Set
            _facialHair = Value
            OnPropertyChanged(Of String)()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value indicating whether the face is smile or not
    ''' </summary>
    Public Property IsSmiling() As String
        Get
            Return _isSmiling
        End Get

        Set
            _isSmiling = Value
            OnPropertyChanged(Of Boolean)()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value indicating the glasses type 
    ''' </summary>
    Public Property Glasses() As String
        Get
            Return _glasses
        End Get

        Set
            _glasses = Value
            OnPropertyChanged(Of String)()
        End Set
    End Property

#End Region

#Region "Methods"

    ''' <summary>
    ''' NotifyProperty Helper functions
    ''' </summary>
    ''' <typeparam name="T">property type</typeparam>
    ''' <param name="caller">property change caller</param>
    Private Sub OnPropertyChanged(Of T)(<CallerMemberName> Optional caller As String = Nothing)
        ' Dim handler = PropertyChanged
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(caller))
    End Sub

#End Region
End Class
