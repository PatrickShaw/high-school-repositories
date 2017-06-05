Imports System.IO
Imports Sorting_Algorithm___Prequisite__CSHARP_FOR_VB.NET_
Module VBSearcher

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

    Public Function PatricksBinarySearch(number As ULong, Optional path As String = ".\SearchData.txt") As Long
#If DEBUG Then
        Debug.WriteLine("Patrick's Binary Search INITIATED ~~~~~~")
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

End Module
