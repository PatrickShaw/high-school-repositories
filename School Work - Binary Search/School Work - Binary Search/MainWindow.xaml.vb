Imports System.IO
Imports Microsoft.Win32
Imports Cause_I_hate_VB.NET
Imports Library__CSHARP____Crappy_Number_Compression
Class MainWindow
    Public Function NumberToNumber(startingNo As Long, endingNo As Long) As Long()
        Dim noArray As Long() = New Long(endingNo - startingNo) {}
        For i As Long = startingNo To endingNo
            noArray(i) = i
        Next
        Return noArray
    End Function
    Public Sub GenerateRandomNumberFile(Optional Length As Long = 10000000)
        Dim longs As Long() = NumberToNumber(0, 10000000)
        PSCompressor.ByteWriter(longs, ".\BinaryTest.cnumbers")
        Return
        Dim lNo As New List(Of Long)
        Dim random As New Random
        For i As ULong = 0 To Length
            lNo.Add(Convert.ToInt64(random.Next(0, 1000000)))
        Next
        lNo.Sort()
        Dim lString As New List(Of String)
        For Each n In lNo
            lString.Add(n)
        Next
        Dim path As String = (".\" + Length.ToString() + " Elements.numbers")
        If File.Exists(path) Then
            File.Delete(path)
        End If
        Using fs As FileStream = File.Create(path)
        End Using
        File.AppendAllLines(path, lString.ToArray())
        Dim path2 As String = (".\" + Length.ToString() + " Elements.cnumbers")
        If File.Exists(path2) Then
            File.Delete(path2)
        End If
        Using fs As FileStream = File.Create(path2)
        End Using
        Dim lfString As String() = PSCompressor.Compress(lNo.ToArray()).ToArray()
        File.AppendAllLines(path2, lfString)

    End Sub
    Public Function LinearSearch(number As ULong, Optional path As String = ".\SearchData.txt") As Long
#If DEBUG Then
        Debug.WriteLine("Linear Search INITIATED ~~~~~~")
        Dim perfStopWatcher As New Stopwatch
        perfStopWatcher.Restart()
#End If
        Dim lines As String() = File.ReadAllLines(path)
        For i As ULong = 0 To lines.Count - 1
            If Convert.ToInt64(lines(i)) = number Then
#If DEBUG Then
                perfStopWatcher.Stop()
                Debug.WriteLine("Found at: " & i)
                Debug.WriteLine(perfStopWatcher.ElapsedTicks.ToString() + Environment.NewLine)
#End If
                Return i
            End If
        Next
#If DEBUG Then
        perfStopWatcher.Stop()
        Debug.WriteLine("Worst Case Scenerio")
        Debug.WriteLine(perfStopWatcher.ElapsedTicks.ToString() + Environment.NewLine)
#End If
        Return -1
    End Function
    Public Function PatricksBinarySearch(number As Long, numbers As Long()) As Long
        If numbers.Count = 1 Then If Convert.ToInt64(numbers.First) = number Then Return 0 Else Return -1
        Dim i As ULong = 0
        Dim b As ULong = 1 << Log2.log2_64(numbers.Count - 1)
        Do Until (b = 0)
            Dim j As ULong = i Or b
            'MsgBox(j)
            If (numbers.Count <= j) Then
                b >>= 1
                Continue Do
            End If
            If Convert.ToInt64(numbers(j)) <= number Then
                i = j
            Else
                b >>= 1
                Do Until (b = 0)
                    If (numbers(i Or b) <= number) Then i = i Or b
                    'MsgBox(i)
                    b >>= 1
                Loop
                Exit Do
            End If
            b >>= 1
        Loop
        Return i - 1
    End Function
    Public Function PatricksBinarySearch(number As ULong, Optional path As String = ".\SearchData.txt") As Long
#If DEBUG Then
        Debug.WriteLine("Patrick's Binary Search INITIATED (Binary search with interweaved string reading) ~~~~~~")
        Dim perfStopWatcher As New Stopwatch
        perfStopWatcher.Restart()
#End If
        Dim count As Long = File.ReadLines(path).Count()
        If count = 1 Then If Convert.ToInt64(File.ReadLines(path).First) = number Then Return 0 Else Return -1
        Dim i As ULong = 0
        Dim b As ULong = 1 << Log2.log2_64(count - 1)
        Do Until (b = 0)
            Dim j As ULong = i Or b
            'MsgBox(j)
            If (count <= j) Then
                b >>= 1
                Continue Do
            End If
            If Convert.ToInt64(File.ReadLines(path).Skip(j - 1).Take(1).First()) <= number Then
                i = j
            Else
                b >>= 1
                Do Until (b = 0)
                    If (Convert.ToInt64(File.ReadLines(path).Skip((i Or b) - 1).Take(1).First) <= number) Then i = i Or b
                    'MsgBox(i)
                    b >>= 1
                Loop
                Exit Do
            End If
            b >>= 1
        Loop
#If DEBUG Then
        perfStopWatcher.Stop()
        Debug.WriteLine("Finished")
        Debug.WriteLine(perfStopWatcher.ElapsedTicks.ToString() + Environment.NewLine)
#End If
        Return i - 1
    End Function

    Public Function ConventionalBinarySearch(number As ULong, Optional path As String = ".\SearchData.txt") As Long
#If DEBUG Then
        Debug.WriteLine("Conventional Binary Search INITIATED ~~~~~~")
        Dim perfStopWatcher As New Stopwatch
        perfStopWatcher.Restart()
#End If
        Dim lines As String() = File.ReadAllLines(path)
        Dim high As ULong = lines.Count - 1
        Dim low As ULong = 0
        Do While low < high
            Dim iSelected As ULong = low + ((high + 1 - low) \ 2)
            If (low = 0 And high = 1) Then iSelected = 0
            Dim noSelected As ULong = Convert.ToInt64(lines(iSelected))
            If noSelected = number Then
#If DEBUG Then
                perfStopWatcher.Stop()
                Debug.WriteLine(perfStopWatcher.ElapsedTicks.ToString() + Environment.NewLine)
#End If
                Return iSelected
            End If
            If number > noSelected Then
                low = iSelected
            Else
                high = iSelected
            End If
        Loop
#If DEBUG Then
        perfStopWatcher.Stop()
        Debug.WriteLine("Worst Case Scenerio")
        Debug.WriteLine(perfStopWatcher.ElapsedTicks.ToString() + Environment.NewLine)
#End If
        Return -1
    End Function

    Private Sub btnCancel_Click(sender As Object, e As RoutedEventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As RoutedEventArgs) Handles btnSearch.Click
        If File.Exists(txtPath.Text) = False Then
            MessageBox.Show("Path doesn't exist")
            Return
        End If
        Dim wndSelectNumber As New Select_Number
        wndSelectNumber.ShowDialog()
        If wndSelectNumber.canceled Then Return
        Dim index As ULong = Nothing
        Select Case cmbSearchType.SelectedIndex
            Case 0
                index = LinearSearch(wndSelectNumber.amount, txtPath.Text)
            Case 1
                index = ConventionalBinarySearch(wndSelectNumber.amount, txtPath.Text)
            Case 2
                index = PatricksBinarySearch(wndSelectNumber.amount, txtPath.Text)
            Case 3
#If DEBUG Then
                Debug.WriteLine("VB.NET Binary Search INITIATED ~~~~~~")
                Dim perfStopWatcher As New Stopwatch
                perfStopWatcher.Restart()
#End If
                Dim numbers As New List(Of ULong)
                Using sr As StreamReader = New StreamReader(txtPath.Text)
                    While (sr.Peek() >= 0)
                        numbers.Add(Convert.ToInt64((sr.ReadLine())))
                    End While
                End Using
                index = numbers.BinarySearch(wndSelectNumber.amount)
#If DEBUG Then
                perfStopWatcher.Stop()
                If index = -1 Then
                    Debug.WriteLine("Worst Case Scenerio")
                Else
                    Debug.WriteLine("Found at: " & index)
                End If
                Debug.WriteLine(perfStopWatcher.ElapsedTicks.ToString() + Environment.NewLine)
#End If
            Case 4
#If DEBUG Then
                Debug.WriteLine("Patrick Compressed Binary Search ~~~~~~")
                Dim perfStopWatcher As New Stopwatch
                perfStopWatcher.Restart()
#End If
                Dim compressedStrings As String() = File.ReadAllLines(txtPath.Text)
                Dim numbers As New List(Of Long)
                For i As Long = 0 To compressedStrings.Count - 1
                    Dim deltaNum As Long() = PSCompressor.ReadCompressed(compressedStrings(i))
                    numbers.AddRange(deltaNum)


                Next
                index = PatricksBinarySearch(wndSelectNumber.amount, numbers.ToArray())
#If DEBUG Then
                perfStopWatcher.Stop()
                If index = -1 Then
                    Debug.WriteLine("Worst Case Scenerio")
                Else
                    Debug.WriteLine("Found at: " & index)
                End If
                Debug.WriteLine(perfStopWatcher.ElapsedTicks.ToString() + Environment.NewLine)
#End If

            Case 5
#If DEBUG Then
                Debug.WriteLine("Patrick Binary (Lel) Binary Search ~~~~~~")
                Dim perfStopWatcher As New Stopwatch
                perfStopWatcher.Restart()
#End If
                Dim numbers As Long() = PSCompressor.ByteReader(txtPath.Text)
                index = PatricksBinarySearch(wndSelectNumber.amount, numbers)
#If DEBUG Then
                perfStopWatcher.Stop()
                If index = -1 Then
                    Debug.WriteLine("Worst Case Scenerio")
                Else
                    Debug.WriteLine("Found at: " & index)
                End If
                Debug.WriteLine(perfStopWatcher.ElapsedTicks.ToString() + Environment.NewLine)
#End If
        End Select
        If index <= -1 Then
            MsgBox(wndSelectNumber.amount & " was not found.")
            Return
        End If
        MsgBox(wndSelectNumber.amount & " was found at position: " & index, )
    End Sub

    Private Sub btnCreateNumberArray_Click(sender As Object, e As RoutedEventArgs) Handles btnCreateNumberArray.Click
        Dim wndLength As New Select_Number
        wndLength.lblTitle.Content = "Array Length: "
        wndLength.ShowDialog()
        If wndLength.canceled Then Return
        GenerateRandomNumberFile(wndLength.amount)
    End Sub

    Dim openDialog As New OpenFileDialog
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        openDialog.DefaultExt = ".numbers"
        openDialog.Filter = "Number Array File|*.numbers|Patrick's Compressed Number Array File|*.cnumbers"
        openDialog.CheckPathExists = True
        openDialog.CheckFileExists = True
        openDialog.RestoreDirectory = True
        openDialog.InitialDirectory = Path.GetFullPath(".\")
        cmbSearchType.SelectedIndex = 0
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub btnBrowse_Click(sender As Object, e As RoutedEventArgs) Handles btnBrowse.Click
        If openDialog.ShowDialog() = False Then Return
        txtPath.Text = openDialog.FileName
    End Sub
End Class
