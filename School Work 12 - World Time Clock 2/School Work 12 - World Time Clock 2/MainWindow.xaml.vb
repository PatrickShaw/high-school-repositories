Imports System.ComponentModel
Imports System.Windows.Threading

Class MainWindow
    Implements INotifyPropertyChanged
    Dim Difference1 As Single = 0
    Dim Difference2 As Single = 0
    Dim changingFirst As Boolean = True
    Dim btnLocSelected As Button
    Dim btnDestSelected As Button

    Private timer As DispatcherTimer

    Private Sub Timer_Tick()
        txtLocTime.Text = Now
        txtDestTime.Text = Now.AddMinutes(Difference2 * 60 - Difference1 * 60)
    End Sub

    Public Event PropertyChanged As PropertyChangedEventHandler _
    Implements INotifyPropertyChanged.PropertyChanged

    Private Sub NotifyProperty(ByVal info As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))
    End Sub
    Dim btnsTimeZones As Button() = New Button(39) {}
    Public Shared Function TimeNotationify(Val As Single) As String

        Dim sign As String = ""
        If Val >= 0 Then sign = "+"
        Dim time As String = ""
        If CInt(Val) = Val Then
            time = Val & ":00"
        Else
            time = CInt(Val) & ":30"
        End If
        If Val = 0 Then Return "(UTC + 0:00)"
        Return "(GMT" + " " + sign + " " + time + ")"
    End Function
    Public Property GetDifference1 As String
        Get
            Return TimeNotationify(Difference1)
        End Get
        Set(value As String)
        End Set
    End Property

    Public Property GetDifference2 As String
        Get
            Return TimeNotationify(Difference2)
        End Get
        Set(value As String)
        End Set
    End Property

    Sub New()
        InitializeComponent()
        For i = 0 To 23
            Dim btnTemp As Button = New Button()
            Dim timeT As Integer = i - 11
            btnTemp.TabIndex = timeT
            If (btnTemp.TabIndex Mod 2) Then
                btnTemp.Background = New SolidColorBrush(Color.FromArgb(25, 0, 0, 0))
            Else
                btnTemp.Background = New SolidColorBrush(Color.FromArgb(50, 0, 0, 0))
            End If
            btnTemp.Width = 50
            btnTemp.Height = 715
            btnTemp.HorizontalAlignment = Windows.HorizontalAlignment.Left
            btnTemp.Content = ""
            btnTemp.AddHandler(Button.ClickEvent, New RoutedEventHandler(AddressOf TimeZone_Click))

            btnsTimeZones(i) = btnTemp
            theCanvas.Children.Add(btnsTimeZones(i))
            Canvas.SetLeft(btnsTimeZones(i), i * 50)
            Canvas.SetTop(btnsTimeZones(i), 0)
        Next
        txtDestTime.Text = ""
        txtLocTime.Text = ""
        timer = New DispatcherTimer
        timer.Interval = TimeSpan.FromMilliseconds(20)
        AddHandler timer.Tick, AddressOf Timer_Tick
        timer.Start()
    End Sub
    Private Sub ResetButtonColour(ByRef btn As Button)
        If (btn.TabIndex Mod 2) Then
            btn.Background = New SolidColorBrush(Color.FromArgb(25, 0, 0, 0))
        Else
            btn.Background = New SolidColorBrush(Color.FromArgb(50, 0, 0, 0))
        End If
    End Sub

    Private Sub TimeZone_Click(sender As Object, e As RoutedEventArgs)
        Dim btn As Button = sender
        If changingFirst Xor Keyboard.IsKeyDown(Key.LeftCtrl) Then
            Try
                ResetButtonColour(btnLocSelected)
            Catch
            End Try

            Difference1 = CDbl(btn.TabIndex)
            btnLocSelected = btn
            btn.Background = New SolidColorBrush(Color.FromArgb(125, 200, 240, 50))
        Else
            Try
                ResetButtonColour(btnDestSelected)
            Catch
            End Try

            Difference2 = CDbl(btn.TabIndex)
            btnDestSelected = btn
            btn.Background = New SolidColorBrush(Color.FromArgb(125, 200, 50, 240))
        End If
        NotifyProperty("GetDifference1")
        NotifyProperty("GetDifference2")
    End Sub


    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        If changingFirst Then
            changingFirst = False
            btnLocationChange.Content = "Setting Destination"
        Else
            changingFirst = True
            btnLocationChange.Content = "Setting Location"
        End If
    End Sub


    Private Sub btnClose_Click(sender As Object, e As RoutedEventArgs) Handles btnClose.Click
        Close()
    End Sub
End Class
