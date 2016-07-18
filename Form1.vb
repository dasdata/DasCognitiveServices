Imports Microsoft.ProjectOxford.Face
Imports System.IO
Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Windows.Media.Imaging
Imports System.Windows
Imports System.Net
Imports Newtonsoft.Json.Linq
Imports System.Text
Imports Newtonsoft.Json

' FACE DETECTION based on a Arduino distance trigger 

Public Class Form1
    'change token with your own API https://www.microsoft.com/cognitive-services/en-us/face-api
    Private ReadOnly faceServiceClient As IFaceServiceClient = New FaceServiceClient("XXXX-XXXX-XXXX-XXXX-XXX")
    Private webcam As WebCam
    Private path As [String] = Directory.GetCurrentDirectory() & "\pics\" & Date.Now.ToString("yyyyMMdd") & "\"
    Private fileFace As [String] = ""
    Public _T0Val, _T1Val, _RezVal As Integer
    Public _das As New dasData.das
    Public dsKey, asKey As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            'DASDATA KEYS  http://dasdata.co/new   
            dsKey = "XXXX-XXXX-XXXX-XXXX-XXX"
            asKey = "XXXX-XXXX-XXXX-XXXX-XXX"

            cmdGetDasReq()

            If cbxDetectFace.Checked = True Then
                Timer1.Interval = 1000
                Timer1.Enabled = True
            End If


            If (Not System.IO.Directory.Exists(path)) Then
                System.IO.Directory.CreateDirectory(path)
            End If
        Catch ex As Exception
            Exit Sub
        End Try

    End Sub

    'GET DISTACE VALUES FROM ARDUINO 
    Private Sub Timer1XX_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            txtInfo.Text = Date.Now.ToString & " - Started!"
            If btnStart.Text = "Close" Then
                Using client As New WebClient
                    Dim stream As Stream = client.OpenRead("http://192.168.0.104/index.html")
                    Dim reader As New StreamReader(stream)
                    lblDistance.Text = "Connected!"
                    Dim rawresp As String
                    rawresp = reader.ReadToEnd()
                    Dim jResults As JObject = JObject.Parse(rawresp)
                    Dim results As List(Of JToken) = jResults.Children().ToList()

                    For Each item As JProperty In results
                        item.CreateReader()
                        Dim _itmVal As String = item.Value.ToString
                        If _itmVal.Contains("Distan") Then
                            Dim _distVal() As String = _itmVal.Split(":")
                            Dim _dist As String = _distVal(1).Replace(" ", "").Replace("}", "")

                            lblDistance.Text = _dist
                            If _dist < 60 Then
                                'take picture and detect!
                                txtInfo.Text = "Take pic! " & _dist
                                Dim _myImage As String = Helper.SaveImage(imgVideo.Image)

                                If cbxDetectFace.Checked = True Then
                                    'if detection is on then detect
                                    cmdUploadAndDetectFace(_myImage)
                                Else
                                    'just store some pics
                                    Dim _myHTMLFile As String = path & "\" & Date.Now.ToString("yyyyMMdd")
                                    Dim _strHTMLPage As String = "<img src='" & _myImage & ".jpg' width='100px'/>"
                                    WriteHTMLText(_myHTMLFile & ".html", _strHTMLPage)
                                End If

                                ' Threading.Thread.Sleep(500)
                            End If
                            '  MsgBox(_dist)
                        End If
                    Next
                    reader.Close()
                End Using

            End If
        Catch ex As Exception
            ' MsgBox(ex.Message.ToString)
        End Try


    End Sub

    'START 
    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        If btnStart.Text = "Close" Then
            txtInfo.Text = "Closing webcam"
            webcam.Stop()
            txtInfo.Text = ""
            btnStart.Text = "Start"
        Else
            txtInfo.Text = "Start webcam"
            webcam = New WebCam()
            webcam.InitializeWebCam(imgVideo)
            webcam.Start()
            txtInfo.Text = "Camera started"
            btnStart.Text = "Close"
        End If


    End Sub

    'UPLOAD PICTURE AND DETECT FACE 
    Private Async Sub cmdUploadAndDetectFace(ByVal fileFace As String)
        Try

            Dim _strFaceDetails As String = ""
            Dim fileWithTheFace As String = path & "\" & fileFace & ".jpg"

            Dim fileUri As New Uri(fileWithTheFace)
            Dim bitmapSource As New BitmapImage()

            bitmapSource.BeginInit()
            bitmapSource.CacheOption = BitmapCacheOption.None
            bitmapSource.UriSource = fileUri
            bitmapSource.EndInit()

            lblDetectIt.Text = "Detecting..."
            '      lblDetectIt.Text = "Detecting..."

            ResultCollection.Clear()
            DetectedFaces.Clear()


            Using fileStream = File.OpenRead(fileWithTheFace)
                Try

                    Dim faces As Microsoft.ProjectOxford.Face.Contract.Face() = Await faceServiceClient.DetectAsync(fileStream, False, True, New FaceAttributeType() {FaceAttributeType.Gender, FaceAttributeType.Age, FaceAttributeType.Smile, FaceAttributeType.Glasses})
                    lblDetectIt.Text = ("Detected " & faces.Length & " face(s) ")

                    For Each face In faces
                        DetectedFaces.Add(New face() With {
                                 .ImagePath = fileWithTheFace,
                                 .Left = face.FaceRectangle.Left,
                                 .Top = face.FaceRectangle.Top,
                                 .Width = face.FaceRectangle.Width,
                                 .Height = face.FaceRectangle.Height,
                                 .FaceId = face.FaceId.ToString(),
                                 .Gender = face.FaceAttributes.Gender,
                                 .Age = String.Format("{0:#} years old", face.FaceAttributes.Age),
                                 .IsSmiling = If(face.FaceAttributes.Smile > 0.0, "Smile", "Not Smile"),
                                 .Glasses = face.FaceAttributes.Glasses.ToString()
                            })

                    Next

                    For Each _elmFace In DetectedFaces
                        '  _strFaceDetails &= _elmFace.FaceId.ToString & " "
                        _strFaceDetails &= _elmFace.IsSmiling.ToString & "|"
                        _strFaceDetails &= _elmFace.Glasses.ToString & "|"
                        _strFaceDetails &= _elmFace.Gender.ToString & "|"
                        _strFaceDetails &= _elmFace.Age.ToString & "|" & vbNewLine
                    Next

                    lblDetectIt.Text = _strFaceDetails
                    Dim _myHTMLFile As String = path & "\" & Date.Now.ToString("yyyyMMdd")
                    Dim _strHTMLPage As String = "<img src='" & fileWithTheFace & "' width='100px'/> <h4>" & _strFaceDetails.Replace("|", "") & "</h4>"
                    WriteHTMLText(_myHTMLFile & ".html", _strHTMLPage)

                    cmdUpdateDasRequest(_strFaceDetails)
                Catch ex As FaceAPIException
                    txtInfo.Text = ("Response: " & ex.ErrorMessage)
                    Return
                End Try


            End Using


            txtInfo.Text = "Done!"
            System.Threading.Thread.Sleep(5000)

        Catch ex As Exception

        End Try

    End Sub


    '    DASDATA LOG  
    Public Sub cmdUpdateDasRequest(ByVal _myVals As String)
        Try
            If _myVals <> "" Then
                _das.sendDas(_myVals, dsKey, asKey)
                cmdGetDasReq()
            End If

        Catch ex As Exception

        End Try


    End Sub

    Public Sub cmdGetDasReq()
        Dim _dasResult As String = _das.getDas(dsKey, "json", 0, 100)
        Dim dataSet As DataSet = JsonConvert.DeserializeObject(Of DataSet)(_dasResult)
        Dim dataTable As DataTable = dataSet.Tables(0)

        DataGridView1.DataSource = dataSet.Tables(0)
        DataGridView1.AutoGenerateColumns = True
    End Sub


    Private Sub btnTakePic_Click(sender As Object, e As EventArgs) Handles btnTakePic.Click
        Dim _myImage As String = Helper.SaveImage(imgVideo.Image)
        cmdUploadAndDetectFace(_myImage)
    End Sub

    Private Sub btnVideoFormat_Click(sender As Object, e As EventArgs) Handles btnVideoFormat.Click
        webcam.ResolutionSetting()
    End Sub

    Private Sub btnVideoSource_Click(sender As Object, e As EventArgs) Handles btnVideoSource.Click
        webcam.AdvanceSetting()
    End Sub


    Public Async Sub WriteHTMLText(ByVal _file As String, ByVal _values As String)
        Try
            Dim sb As StringBuilder = New StringBuilder()

            sb.AppendLine("<hr size=1>")
            sb.Append(_values)
            sb.AppendLine()
            sb.AppendLine()

            Using outfile As StreamWriter = New StreamWriter(_file, True)
                Await outfile.WriteAsync(sb.ToString())
            End Using
        Catch ex As Exception

        End Try

    End Sub


#Region "Fields"

    ''' <summary>
    ''' Description dependency property
    ''' </summary>
    Public Shared ReadOnly DescriptionProperty As DependencyProperty = DependencyProperty.Register("Description", GetType(String), GetType(Form1))

    ''' <summary>
    ''' Face detection results in list container
    ''' </summary>
    Private _detectedFaces As New ObservableCollection(Of face)()

    ''' <summary>
    ''' Face detection results in text string
    ''' </summary>
    Private _detectedResultsInText As String

    ''' <summary>
    ''' Face detection results container
    ''' </summary>
    Private _resultCollection As New ObservableCollection(Of face)()

    ''' <summary>
    ''' Image path used for rendering and detecting
    ''' </summary>
    Private _selectedFile As String

#End Region

#Region "Constructors"

    ''' <summary>
    ''' Initializes a new instance of the <see cref="FaceDetectionPage" /> class
    ''' </summary>
    Public Sub New()
        InitializeComponent()
    End Sub

#End Region

#Region "Events"

    ''' <summary>
    ''' Implement INotifyPropertyChanged event handler
    ''' </summary>
    Public Event PropertyChanged As PropertyChangedEventHandler

#End Region

#Region "Properties"

    ''' <summary>
    ''' Gets or sets description
    ''' </summary>
    Public Property Description() As String
        Get
            '  Return DirectCast(GetValue(DescriptionProperty), String)
        End Get

        Set
            '  SetValue(DescriptionProperty, Value)
        End Set
    End Property

    ''' <summary>
    ''' Gets face detection results
    ''' </summary>
    Public ReadOnly Property DetectedFaces() As ObservableCollection(Of face)
        Get
            Return _detectedFaces
        End Get
    End Property

    ''' <summary>
    ''' Gets or sets face detection results in text string
    ''' </summary>
    Public Property DetectedResultsInText() As String
        Get
            Return _detectedResultsInText
        End Get

        Set
            _detectedResultsInText = Value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("DetectedResultsInText"))
        End Set
    End Property

    Private Sub cbxDetectFace_CheckedChanged(sender As Object, e As EventArgs) Handles cbxDetectFace.CheckedChanged
        Timer1.Interval = 1000
        If cbxDetectFace.Checked = True Then
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
        End If
    End Sub

    ''' <summary>
    ''' Gets constant maximum image size for rendering detection result
    ''' </summary>
    Public ReadOnly Property MaxImageSize() As Integer
        Get
            Return 300
        End Get
    End Property

    ''' <summary>
    ''' Gets face detection results
    ''' </summary>
    Public ReadOnly Property ResultCollection() As ObservableCollection(Of face)
        Get
            Return _resultCollection
        End Get
    End Property

    ''' <summary>
    ''' Gets or sets image path for rendering and detecting
    ''' </summary>
    Public Property SelectedFile() As String
        Get
            Return _selectedFile
        End Get

        Set
            _selectedFile = Value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("SelectedFile"))
        End Set
    End Property





#End Region



End Class
