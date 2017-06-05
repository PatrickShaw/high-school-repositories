Imports Neural_Network_v3b___Adapative_Chromosomes
Public Class SnakeStyle
    Public name As String = "Lel"
    Public fillBrush As Brush
    Public snakePattern As SnakePattern = snakePattern.stripe
    Public borderBrush As Brush
    Public borderThickness As Long = 0
    Sub New(fillT As Brush, borderBrushT As Brush, Optional snakePatternT As SnakePattern = snakePattern.rainbow, Optional borderThicknessT As Long = 0)
        fillBrush = fillT
        snakePattern = snakePatternT
        borderBrush = borderBrushT
        borderThickness = borderThicknessT
    End Sub
End Class
Public Class Letter
    ' M E R R Y   C H R I S T M A S
    '     S H A R O N   T S E !
    Public coords As Coord()
End Class
Public Class S
    Inherits Letter
    ' X X X X H     H A A A A R R R   O O O O N     N   T T T T S S S S E E E E
    ' X       H     H A     A R     R O     O N N   N     T     S       E
    ' X X X X H H H H A A A A R R R   O     O N   N N     T     S S S S E E 
    '       X H     H A     A R R     O     O N     N     T           S E
    ' X X X X H     H A     A R   R R O O O O N     N     T     S S S S E E E E

    ' M       M 
    ' M M   M M
    ' M   M   M
    ' M       M
    ' M       M
    Sub New()
        coords = New Coord() {New Coord()}
    End Sub
End Class
Public Enum CollisionType
    none
    snake
    food
End Enum
Public Enum SnakePattern
    rainbow
    stripe
End Enum
' Sensory neurons needed
' Snake head
' Snake tail
' Space prediction
' Previous directions
' Powerup sensor 
Public Module Search
    Public Class PatSearchNode
        Public turn As Integer
        Public coord As Coord
        Sub New(turnT As Integer, coordT As Coord)
            turn = turnT
            coord = coordT
        End Sub

        ' If returns true then it found what was being loocked for
        'Public Function SearchAndExpand(ByRef searchedGrid As Integer()()) As Boolean
        '    If coord Then
        'End Function
    End Class
End Module
Public Class ClosestFood
    Public 
End Class
Public Class MoveNeuron
    Inherits MotorNeuron
    Public direction As New Direction
    Public snake As Snake
    Public Overrides Sub PerformAction(summationValue As Double)

    End Sub
End Class
Public NotInheritable Class Snake
    Public matchesWon As Long = 0
    Public Class KeyV2
        Public key As Key
        Public downNow As Boolean = False
        Public downPrev As Boolean = False
        Sub New(keyT As Key)
            key = keyT
        End Sub
    End Class
    Public teamNo As Long = 1
    Public speedBonus As Single = 0
    Public speedBonusTime As Long = 0
    Const moveSpeed As Single = 50
    Dim ForceMovesInARow As Long = 0
    Dim beenUpdated As Boolean = False
    Dim movesTravelledInSameDirection As Long = 0
    Public score As Single = 0
    Public oldScore As Single = 0
    Public snakeNumber As Long
    Dim scoreMultiplier As Single = 1
    Public growthQueue As Long = 0
    Public isAI As Boolean = False
    Public isPassive As Boolean = False
    Public isLeaner As Boolean = False
    Public isCheater As Boolean = False
    Public speedFactor As Single = 1
    Public dNew As Direction = Direction.right
    Public dOld As Direction = dNew
    Public kUp As KeyV2 = New KeyV2(Key.W)
    Public kLeft As KeyV2 = New KeyV2(Key.A)
    Public kDown As KeyV2 = New KeyV2(Key.S)
    Public kRight As KeyV2 = New KeyV2(Key.D)
    Public dead As Boolean = False
    Public invicibilityTime As Long = 5

    Public naturalAgressivenessFactor As Double ' 0.25 To 3.0 (Aggressiveness per difference in score)
    Public Agressiveness As Double = 0
    Public snakeStyle As SnakeStyle = New SnakeStyle(Brushes.White, Brushes.White)
    Public segments As New List(Of SnakeSegment)
    Public snakeBlocks As List(Of SnakeBlock) = New List(Of SnakeBlock)
    Public directionHistory As New List(Of Direction)
    Public decisionHistory As New List(Of Decision)
    Dim moveStopWatch As Stopwatch = New Stopwatch()
    Public otherSnakes As List(Of Snake) = New List(Of Snake)
    Dim delta As Coord = New Coord(0, 0)
    Public attackMode As Boolean = False
    Public targetSnake As Snake
    Dim targetFoodCoord As Coord

    'NEURAL NETWORK
    Dim neurons As New List(Of Neuron)
#Region "AIFunctions"
    ' WARNING: CALC SPACE IS NOT dNew SAFE
    Public Function CalcSpace(passes As Long, starterCoord As Coord, collisionMap As CollisionType()(), Optional debug As Boolean = False) As Single
        Dim coordsToBePassed As List(Of Coord) = New List(Of Coord)
        Dim coordsCheckedAlready As Boolean()() = New Boolean(gridXCount)() {}
        For x = 0 To gridXCount
            coordsCheckedAlready(x) = New Boolean(gridYCount) {}
        Next
        Dim points As Single = 0
        Dim space As Single = 0
        coordsToBePassed.Add(starterCoord)
        Dim futureCoordsToBePassed As List(Of Coord) = New List(Of Coord)
        coordsCheckedAlready(starterCoord.x)(starterCoord.y) = True
        Dim foundFood As Boolean = False
        For currentPass As Long = 1 To passes
            For i As Long = 0 To coordsToBePassed.Count - 1
                If attackMode Then
                    If foundFood = False Then
                        If coordsToBePassed(i) = targetSnake.snakeBlocks.First.coord Then
                            points -= 0.0001 / currentPass
                            foundFood = True
                        End If
                    End If

                End If
                Select Case CheckCoordinatesFilled(coordsToBePassed(i), collisionMap)
                    Case CollisionType.snake
                        If (invicibilityTime < 10) Then
                            If IsOccupiedByInvincibleSnakeHead(coordsToBePassed(i)) And snakeBlocks.First.coord.GridDistanceFASTESTPATH(coordsToBePassed(i)) < 5 And isPassive Then points += 0.0001 / currentPass
                            Continue For
                        End If
                    Case CollisionType.none
                    Case CollisionType.food
                        If foundFood = False Then
                            points -= 0.0001 / currentPass '1.0 - (currentPass * (1.0 / CSng(passes)))
                            foundFood = True
                        End If
                End Select

                space += 1
                For o As Long = 0 To 3
                    dNew = o
                    DetermineDelta()
                    Dim cTemp As Coord = coordsToBePassed(i) + delta
                    If coordsCheckedAlready(cTemp.x)(cTemp.y) <> True Then
                        coordsCheckedAlready(cTemp.x)(cTemp.y) = True
                        futureCoordsToBePassed.Add(cTemp)
                    End If
                Next
            Next
            coordsToBePassed = New List(Of Coord)
            coordsToBePassed.AddRange(futureCoordsToBePassed)
            futureCoordsToBePassed = New List(Of Coord)
        Next
        ' Incase I forget: the lower the value below, the more preferable the direction is
        points += (CSng(totalSpace) - space) / CSng(totalSpace)
        Return points
    End Function
    Public Function IsOccupiedByInvincibleSnakeHead(coord As Coord)
        For Each Snake In otherSnakes
            If Snake.snakeBlocks.First.coord = coord Then Return True
        Next
        Return False
    End Function
    Public Sub AI()
        Dim options As List(Of Direction) = DirectionOptions() 'DirectionOptions() ' New List(Of Direction) 
        'options.AddRange({Direction.up, Direction.left, Direction.down, Direction.right})
        Dim highestOtherScore As Long = 0
        Dim foodRankingPreference As Long = 0
Begin:
        Dim noSnakesCloserToFood As Long = 0
        targetFoodCoord = GetFoodCoord(foodRankingPreference)
        For Each Snake In otherSnakes
            Dim oSnakesClosestFoodCoord As Coord = Snake.GetFoodCoord(0)
            If Snake.score > highestOtherScore Then highestOtherScore = Snake.score
            If targetFoodCoord = oSnakesClosestFoodCoord Then
                If Snake.snakeBlocks.First.coord.GridDistanceFASTESTPATH(targetFoodCoord) < snakeBlocks.First.coord.GridDistanceFASTESTPATH(targetFoodCoord) Then
                    noSnakesCloserToFood += 1
                End If
            End If
        Next

        FindTarget()
        If IsNothing(targetSnake) Or isPassive Then
            attackMode = False
        Else
            If ((10000 + score > highestOtherScore Or speedBonusTime > 50) And (noSnakesCloserToFood >= 1 Or targetSnake.snakeBlocks.First.coord.GridDistanceFASTESTPATH(snakeBlocks.First.coord) > 10)) Or noSnakesCloserToFood >= 2 Then
                If (CDbl(foodRankingPreference) + 1.0 < CDbl(foodList.Count - 1) * 0.75) Then
                    foodRankingPreference += 1
                    GoTo Begin
                End If
                attackMode = True
            Else
                attackMode = False
            End If
        End If


        dNew = FindBestDOption(options)
    End Sub
    Public Function GetFoodCoord(closenessRanking As Long) As Coord
        Dim distOrderedFood As New List(Of Food)
        Dim OrderedFoodDist As New List(Of Long)
        For i As Long = 1 To foodList.Count - 1
            Dim foodTDist As Long = foodList(i).Coordinate.GridDistanceFASTESTPATH(snakeBlocks.First.coord)
            For o As Long = 0 To distOrderedFood.Count - 1
                If o = distOrderedFood.Count - 1 Then
                    distOrderedFood.Add(foodList(i))
                    OrderedFoodDist.Add(foodTDist)
                    Continue For
                End If
                If OrderedFoodDist(o) < foodTDist Then Continue For
                distOrderedFood.Insert(o, foodList(i))
                OrderedFoodDist.Insert(o, foodTDist)
            Next
            If distOrderedFood.Count = 0 Then
                distOrderedFood.Add(foodList(i))
                OrderedFoodDist.Add(foodTDist)
            End If
        Next
        If distOrderedFood.Count = 0 Then Return New Coord(0, 0)
        Return distOrderedFood(closenessRanking).Coordinate
    End Function

    ' SNAKE LEARNER v2

    ' Snake Learner
    ' Likes change within a timely manner
    ' Loves points
    ' Equally dislikes other snakes getting points
    ' Absolutely hates dieing
    ' CURRENT TASK: Single Player Learning
    Public deltaPoints As Long = 0
    Const TIME_SIG As Single = 0.0025 ' The exponent on the exponential
    Const N_EXP As Single = 2.71828
    Public negFeedbacks As New List(Of Feedback)
    Public posFeedbacks As New List(Of Feedback)
    Public Sub RecNEGFeedback(feedback As Feedback)
        negFeedbacks.Add(feedback)
    End Sub
    Private Sub RecDEATHFeedback()
        negFeedbacks.Add(New DeathFeedback())
        negFeedbacks.Last.significanceFactor = 4000
        negFeedbacks.Last.FillDetails(Me)
    End Sub
    Public Sub RecPOSFeedback(feedback As Feedback)
        posFeedbacks.Add(feedback)
    End Sub

    Public MustInherit Class Feedback
        Public timeSignificance As Single = 0
        Public age As Single = 0
        Public significanceFactor As Single = 0
        Public MustOverride Sub FillDetails(ByVal snake As Snake)
        Public MustOverride Function GetTotalSignificance(fDistanceFromFood As Long, fDirectionHistory As List(Of Decision), fSpace As Long, IsInvincible As Boolean) As Single
        Public Overridable Sub RecalcTimeSignificance()
            If age > 1000 Then Return
            timeSignificance = Math.Pow(N_EXP, (-TIME_SIG * age))
        End Sub
        Protected Function GetSnakeSpace(ByVal snake As Snake)
            ' BROKEN: should use a archival snakeOccupied
            Return snake.CalcSpace(300, snake.PlusDelta(snake.snakeBlocks.First.coord), snakeOccupied)
        End Function
        Protected Function GetDecisionHistory(ByVal snake As Snake) As List(Of Decision)
            Return snake.decisionHistory
        End Function
        Protected Overridable Function GetDirectionSignificance(feedbacksDirections As List(Of Decision), ByVal snakeDirectionHistory As List(Of Decision)) As Single
            ' NOTE: Direction RECOGS could be improved
            Dim recogs As Single = 0
            For i As Long = 0 To snakeDirectionHistory.Count - 1
                If i >= feedbacksDirections.Count Then Return recogs
                If snakeDirectionHistory(i) = feedbacksDirections(i) Then recogs += i + 1 Else Return recogs
            Next
            Return recogs
        End Function
        Protected Overridable Function GetSpaceSignificance(feedbackSpace As Long, futureSpace As Long) As Single
            Return 1 / (Math.Abs(feedbackSpace - futureSpace) + 1)
        End Function
        Protected Overridable Function CalcDistanceFromFoodSignificance(feedbackDistFromFood As Long, distanceFromFood As Long) As Single
            Return 1 / (Math.Abs(feedbackDistFromFood - distanceFromFood) + 1)
        End Function
        Protected Function GetDistanceFromFood(snake As Snake) As Long
            Return snake.snakeBlocks.First.coord.GridDistanceFASTESTPATH(snake.targetFoodCoord)
        End Function
    End Class
    Public Class DeathFeedback
        Inherits FoodFoundFeedback
        Public Overrides Sub RecalcTimeSignificance()
            timeSignificance = Math.Pow(N_EXP, (-TIME_SIG * 0.001 * age))
        End Sub
    End Class
    Public Class FoodFoundFeedback
        Inherits Feedback
        Dim directions As List(Of Decision)
        Dim invincible As Boolean
        Dim space As Long
        Dim distanceFromTargetFood
        Public Overrides Sub FillDetails(snake As Snake)
            directions = GetDecisionHistory(snake)
            space = GetSnakeSpace(snake)
            If snake.invicibilityTime > 0 Then
                invincible = True
            Else
                invincible = False
            End If
            distanceFromTargetFood = GetDistanceFromFood(snake)
        End Sub

        Public Overrides Function GetTotalSignificance(fDistanceFromFood As Long, fDirectionHistory As List(Of Decision), fSpace As Long, IsInvincible As Boolean) As Single
            If invincible And IsInvincible = False Then Return 0
            Dim factors As Single = GetSpaceSignificance(space, fSpace) + GetDirectionSignificance(directions, fDirectionHistory) / 2.0 + 30 * CalcDistanceFromFoodSignificance(distanceFromTargetFood, fDistanceFromFood)
            If invincible And IsInvincible Then factors *= 2
            Return factors * timeSignificance * significanceFactor
        End Function
    End Class
    Public Class StagnancyFeedback
        Inherits Feedback
        Dim directions As List(Of Decision)
        Dim space As Long
        Dim distanceFromTargetFood As Long
        Public Overrides Sub FillDetails(snake As Snake)
            directions = GetDecisionHistory(snake)
            space = GetSnakeSpace(snake)
            distanceFromTargetFood = GetDistanceFromFood(snake)
        End Sub
        Public Overrides Function GetTotalSignificance(fDistanceFromFood As Long, fDirectionHistory As List(Of Decision), fSpace As Long, IsInvincible As Boolean) As Single
            Dim factors As Single = GetSpaceSignificance(space, fSpace) + GetDirectionSignificance(directions, fDirectionHistory) + CalcDistanceFromFoodSignificance(distanceFromTargetFood, fDistanceFromFood)
            'Debug.WriteLine(factors)
            Return factors * timeSignificance * significanceFactor
        End Function
        Public Overrides Sub RecalcTimeSignificance()
            If age > 100 Then
                timeSignificance = 0
                Return
            End If
            timeSignificance = Math.Pow(N_EXP, (-TIME_SIG * 20 * age))
        End Sub
    End Class

    Private Function CloneSnakeBlocksByVal() As List(Of SnakeBlock)
        Dim newList As New List(Of SnakeBlock)
        For x As Long = 0 To snakeBlocks.Count - 1
            newList.Add(New SnakeBlock(snakeBlocks(x).colour, snakeBlocks(x).coord.x, snakeBlocks(x).coord.y, snakeBlocks(x).dNew))
        Next
        Return newList
    End Function
    Private Function CloneDirectionHistory() As List(Of Decision)
        Dim newList As New List(Of Decision)
        For x As Long = 0 To decisionHistory.Count - 1
            newList.Add(decisionHistory(x))
        Next
        Return newList
    End Function
    Public Function ConstructFutureSnakeBlocks() As List(Of SnakeBlock)
        Dim TempSnakeBlocks As List(Of SnakeBlock) = CloneSnakeBlocksByVal()
        Dim lastSnakeBlock As SnakeBlock = TempSnakeBlocks.Last
        TempSnakeBlocks.Insert(0, lastSnakeBlock)
        TempSnakeBlocks.RemoveAt(TempSnakeBlocks.Count - 1)
        TempSnakeBlocks.First.dNew = dNew
        TempSnakeBlocks.First.coord = PlusDelta(snakeBlocks.First.coord)
        Return TempSnakeBlocks
    End Function
    Public Sub DecideMove()
        Try

            Dim dPoints As Double() = New Double(3) {0, 0, 0, 0}
            Dim highestDPoints As Double = -999999999999999
            Dim decision As Double = 0
            For i As Long = 0 To 3
                If OppositeDirection(dOld) = i Then Continue For
                Dim futureDHistory As List(Of Decision) = CloneDirectionHistory()
                futureDHistory.Insert(0, i)
                futureDHistory.RemoveAt(futureDHistory.Count - 1)
                dNew = i
                Dim inv As Boolean = True
                If invicibilityTime <= 1 Then inv = False
                DetermineDelta()
                For o As Long = 0 To posFeedbacks.Count
                    dPoints(i) += posFeedbacks(o).GetTotalSignificance(snakeBlocks(0).coord.GridDistanceFASTESTPATH(GetFoodCoord(0)), futureDHistory, CalcSpace(300, snakeBlocks.First.coord + delta, snakeOccupied, False), inv)
                Next
                For o As Long = 0 To negFeedbacks.Count
                    dPoints(i) -= negFeedbacks(o).GetTotalSignificance(snakeBlocks(0).coord.GridDistanceFASTESTPATH(GetFoodCoord(0)), futureDHistory, CalcSpace(300, snakeBlocks.First.coord + delta, snakeOccupied, False), inv)
                Next
                If dPoints(i) > highestDPoints Then
                    decision = i
                    highestDPoints = dPoints(i)
                End If
                dNew = i
            Next
        Catch ex As Exception

        End Try
    End Sub
    Public Sub PreUpdate(Optional force As Boolean = False)
        If (moveStopWatch.ElapsedMilliseconds < (moveSpeed / (speedFactor + speedBonus)) / globalSpeed) And force = False Then Return
        beenUpdated = True
        deltaPoints = score - oldScore
    End Sub
    Dim movesWithoutChange As Long = 0
    Public Sub ReUpdate()
        If beenUpdated = False Then Return
        deltaPoints = score - oldScore
        If isAI And isLeaner Then
            If dead = False Then
                Dim posToRemove As New List(Of Long)
                Dim negToRemove As New List(Of Long)
                For i As Long = 0 To negFeedbacks.Count - 1
                    negFeedbacks(i).age += 1
                    negFeedbacks(i).RecalcTimeSignificance()
                    'Debug.WriteLine(negFeedbacks(i).timeSignificance)
                    If negFeedbacks(i).timeSignificance * negFeedbacks(i).significanceFactor < 0.01 Then negToRemove.Add(i)
                Next
                For i As Long = 0 To posFeedbacks.Count - 1
                    posFeedbacks(i).age += 1
                    posFeedbacks(i).RecalcTimeSignificance()
                    If posFeedbacks(i).timeSignificance * posFeedbacks(i).significanceFactor < 0.01 Then posToRemove.Add(i)
                Next
                negToRemove.Sort()
                posToRemove.Sort()
                negToRemove.Reverse()
                posToRemove.Reverse()
                ' Debug.WriteLine(negToRemove.Count)
                ' Debug.WriteLine(negFeedbacks.Count)
                For Each index In negToRemove
                    negFeedbacks.RemoveAt(index)

                Next
                For Each index In posToRemove
                    posFeedbacks.RemoveAt(index)
                Next
                If deltaPoints = 0 Then movesWithoutChange += 1 Else movesWithoutChange = 0
                If movesWithoutChange > 20 Then
                    negFeedbacks.Add(New StagnancyFeedback())
                    negFeedbacks.Last.significanceFactor = CDbl(movesWithoutChange) / 2.0
                    negFeedbacks.Last.FillDetails(Me)
                End If
                If growthQueue > 0 Or growthQueue < 0 Then
                    RecPOSFeedback(New FoodFoundFeedback())
                    posFeedbacks.Last.significanceFactor = deltaPoints
                    posFeedbacks.Last.FillDetails(Me)
                End If
                Debug.WriteLine(posFeedbacks.Count)
            End If
        Else
            ' Give feedback to AI
            Dim actualdNew As Direction = dNew
            If growthQueue > 0 Or growthQueue < 0 Then
                For i As Long = 0 To otherSnakes.Count - 1
                    otherSnakes(i).RecPOSFeedback(New FoodFoundFeedback())
                    otherSnakes(i).posFeedbacks.Last.significanceFactor = deltaPoints
                    otherSnakes(i).posFeedbacks.Last.FillDetails(Me)
                Next
            End If
            dNew = actualdNew
        End If
        moveStopWatch.Restart()
        beenUpdated = False
        oldScore = score
    End Sub
    Private Sub FindTarget()
        Dim snakeChosen As Snake
        Dim distance As Integer = 999999999
        For i As Long = 0 To otherSnakes.Count - 1
            If (teamNo = otherSnakes(i).teamNo) Then Continue For
            If (25 > otherSnakes(i).invicibilityTime) Then Continue For
            If (otherSnakes(i).dead) Then Continue For
            If (otherSnakes(i).snakeBlocks.First.coord.GridDistanceFASTESTPATH(snakeBlocks.First.coord) < distance) Then
                snakeChosen = otherSnakes(i)
            End If
        Next
        targetSnake = snakeChosen
        If IsNothing(snakeChosen) Then
            attackMode = False
        Else
            attackMode = True
        End If
    End Sub
    Private Function DirectionOptions() As List(Of Direction)
        ' Up, Left, Down, Right
        Dim directions As List(Of Direction) = New List(Of Direction)
        directions.AddRange({Direction.up, Direction.left, Direction.down, Direction.right})
        Dim optionsToRemove As List(Of Direction) = New List(Of Direction)
        For i = 0 To directions.Count - 1
            dNew = directions(i)
            If dNew = dOld And movesTravelledInSameDirection >= gridHeight Then
                optionsToRemove.Add(dNew)
                Continue For
            End If
            If invicibilityTime < 5 Then
                If CheckCoordinatesFilled(PlusDelta(snakeBlocks(0).coord), snakeOccupied) = CollisionType.snake Then

                    optionsToRemove.Add(dNew)
                    Continue For
                End If
            End If
            If dNew = OppositeDirection(dOld) Then
                optionsToRemove.Add(dNew)
                Continue For
            End If
        Next
        If optionsToRemove.Count = 0 Then Return directions
        For i = 0 To optionsToRemove.Count - 1
            directions.Remove(optionsToRemove(i))
        Next
        Return directions
    End Function
    ' Check if there is a way to get to the food if you go in this direction
    Private Function FindBestDOption(options As List(Of Direction)) As Direction
        Dim lowestCount As Single = 99999999
        Dim chosenOption As Direction = dOld ' By default
        For i = 0 To options.Count - 1
            Dim count As Single = 0.0
            'If dNew = dOld Then count -= 0.2
            dNew = options(i)
            Dim cTemp As Coord = snakeBlocks(0).coord + delta

            'If i = 0 And snakeNumber = 2 And Keyboard.IsKeyDown(Key.C) Then CalcSpace(300, snakeBlocks.First.coord + delta, True)
            dNew = options(i)
            DetermineDelta()
            ' To be boxed in is to be in a situation where it is impossible to obtain food, in this case, the number of paths doesn't matter
            count += CalcSpace(300, snakeBlocks.First.coord + delta, snakeOccupied, )

            ' reapply correct dNew
            'dNew = options(i)
            'Dim futureSnakeOccupied As CollisionType()() = CloneCollisionTypes(snakeOccupied)
            'futureSnakeOccupied(cTemp.x)(cTemp.y) = CollisionType.snake
            'count += CalcSpace(300, snakeBlocks.First.coord, futureSnakeOccupied)
            If count < lowestCount Then
                lowestCount = count
                chosenOption = options(i)
            End If
        Next
        Return chosenOption
    End Function
    Private Function CloneCollisionTypes(ByVal collisionMap As CollisionType()()) As CollisionType()()
        Dim newCMap As CollisionType()() = New CollisionType(gridXCount)() {}
        For x As Long = 0 To collisionMap.Length - 1
            newCMap(x) = New CollisionType(gridYCount) {}
            For y As Long = 0 To collisionMap(x).Length - 1
                newCMap(x)(y) = collisionMap(x)(y)
            Next
        Next
        Return newCMap
    End Function
#End Region
    Private Function PlusDelta(oCoord As Coord) As Coord
        DetermineDelta()
        Return oCoord + delta
    End Function
    Public Function CheckCoordinatesFilled(coordinates As Coord, ByVal collisionMap As CollisionType()()) As CollisionType
        Return collisionMap(coordinates.x)(coordinates.y)
    End Function
    Public Sub SetOtherSnake(ByRef snakeList As List(Of Snake))
        otherSnakes.AddRange(snakeList.ToArray)
        otherSnakes.RemoveAt(snakeNumber - 1)
    End Sub
    Private Sub InitializeSnake(coordinates As Coord, snakeNoT As Long)
        moveStopWatch.Start()
        snakeNumber = snakeNoT
        decisionHistory.Add(0)
        Dim temp As Long = Rnd()
        If temp = 1 Then
            For i As Long = 0 To snakeStartingLength - 1
                snakeBlocks.Add(New SnakeBlock(ColourValue(snakeBlocks.Count - 1, snakeNumber, snakeStyle.snakePattern), coordinates.x + i, coordinates.y, dNew))
            Next
        Else
            dNew = Direction.left
            For i As Long = snakeStartingLength - 1 To 0 Step -1
                snakeBlocks.Add(New SnakeBlock(ColourValue(snakeBlocks.Count - 1, snakeNumber, snakeStyle.snakePattern), coordinates.x + i, coordinates.y, dNew))
            Next
        End If

    End Sub
    Public Sub SnakeGameBegun()
        segments.Add(New SnakeSegment())
        For i As Long = 0 To snakeBlocks.Count - 1
            segments.First.Add(snakeBlocks(i))
        Next

        segments.First.FullSegRecalc()
    End Sub
    Public Sub Reset(coordinates As Coord)
        score = 0
        deltaPoints = 0
        oldScore = 0


        speedFactor = 1
        growthQueue = 0
        movesTravelledInSameDirection = 0
        snakeBlocks.Clear()
        dead = False
        moveStopWatch.Restart()
        invicibilityTime = 5
        segments.Clear()
        speedBonusTime = 0
        InitializeSnake(coordinates, snakeNumber)
    End Sub
    Sub New(snakeStyleT As SnakeStyle, coordinates As Coord, snakeNoT As Long)
        isAI = True
        'posFeedbacks.Add(New Feedback)
        'posFeedbacks.Last.space = gridXCount * gridYCount
        'posFeedbacks.Last.distanceToFood = 0
        'posFeedbacks.Last.feedbackValue = 300

        snakeStyle = snakeStyleT
        InitializeSnake(coordinates, snakeNoT)
    End Sub
    Sub New(snakeStyleT As SnakeStyle, coordinates As Coord, snakeNoT As Long, ByRef keys As Key())
        InitializeSnake(coordinates, snakeNoT)
        snakeStyle = snakeStyleT
        kUp.key = keys(0)
        kLeft.key = keys(1)
        kDown.key = keys(2)
        kRight.key = keys(3)
    End Sub
    Public Sub IncreaseScore()
        score += scoreMultiplier * 10 * snakeBlocks.Count
        SetScore()
    End Sub
    Public Sub IncreaseScore(delta As Long)
        score += delta
        SetScore()
    End Sub
    Public name As String

    Public Sub SetScore()
        gameScores(snakeNumber - 1).Text = name + ": " & score
    End Sub
    Public Sub SetMatchesWon()
        GameProperties.matchesWon(snakeNumber - 1).Text = name + ": " & Me.matchesWon
    End Sub
    Private Sub SetDirection(d As Direction)
        If d = OppositeDirection(dOld) Then Return
        dNew = d
        If isAI Then Return
        If (dOld = dNew) Then Return
        If ForceMovesInARow >= 2 Then Return
        moveStopWatch.Restart()
        PreUpdate(True)
        ForceMovesInARow += 1
        beenUpdated = True
        DetermineDelta()
        'Move()
    End Sub
    Public Sub GoLeft()
        SetDirection(Direction.left)
    End Sub
    Public Sub GoRight()
        SetDirection(Direction.right)
    End Sub
    Public Sub GoUp()
        SetDirection(Direction.up)
    End Sub
    Public Sub GoDown()
        SetDirection(Direction.down)
    End Sub
    Public Sub Update()
        If dead Then Return
        If speedBonusTime > 0 Then
            speedBonusTime -= 1
        Else
            speedBonus = 0
            speedBonusTime = 0
        End If
        If isAI = False Then
            kUp.downNow = Keyboard.IsKeyDown(kUp.key)
            kLeft.downNow = Keyboard.IsKeyDown(kLeft.key)
            kDown.downNow = Keyboard.IsKeyDown(kDown.key)
            kRight.downNow = Keyboard.IsKeyDown(kRight.key)
            If kUp.downNow And kUp.downPrev = False Then
                GoUp()
            End If

            If kLeft.downNow And kLeft.downPrev = False Then
                GoLeft()
            End If

            If kDown.downNow And kDown.downPrev = False Then
                GoDown()
            End If

            If kRight.downNow And kRight.downPrev = False Then
                GoRight()
            End If

            kUp.downPrev = kUp.downNow
            kLeft.downPrev = kLeft.downNow
            kDown.downPrev = kDown.downNow
            kRight.downPrev = kRight.downNow
        End If
        If (moveStopWatch.ElapsedMilliseconds < (moveSpeed / (speedFactor + speedBonus)) / globalSpeed) Then Return
        If isAI And isLeaner = False Then AI() Else If isAI And isLeaner Then DecideMove()
        If dNew = dOld Then
            movesTravelledInSameDirection += 1
        Else
            movesTravelledInSameDirection = 0
        End If
        If isCheater Then
            Dim dOldd As Direction = dNew
            Dim currentNextCoord As Coord = PlusDelta(snakeBlocks.First.coord)
            If CheckCoordinatesFilled(currentNextCoord, snakeOccupied) = CollisionType.snake And (invicibilityTime < 10) Then
                AI()
            Else
                Dim d As Direction = FindBestDOption(DirectionOptions())
                dNew = d
                Dim fCoord As Coord = PlusDelta(snakeBlocks.First.coord)
                If CheckCoordinatesFilled(fCoord, snakeOccupied) = CollisionType.food Then
                    dNew = d
                Else
                    dNew = dOldd
                End If
            End If
        End If
        Dim nextCoord = PlusDelta(snakeBlocks(0).coord)
        snakeOccupied(nextCoord.x)(nextCoord.y) = CollisionType.snake
        ForceMovesInARow = 0
    End Sub

    Public Sub Grow(coordLastOld As Coord)
        snakeBlocks.Add(New SnakeBlock(ColourValue(snakeBlocks.Count - 1, snakeNumber, snakeStyle.snakePattern), coordLastOld.x, coordLastOld.y, snakeBlocks.Last.dNew))
        If gameWindowOpened Then segments.Last.Add(snakeBlocks.Last)
    End Sub
    Public Sub RemoveLastSegBlock()
        For i As Long = segments.Count - 1 To 0 Step -1
            If segments(i).blocks.Count > 0 Then
                segments(i).blocks.RemoveAt(segments(i).blocks.Count() - 1)
                Return
            End If
        Next
    End Sub
    Public Function GetDecision() As Decision ' Works out whether the snake is turning right, left or forward from dNew
        Select Case True
            Case dNew = dOld
                Return Decision.forward
            Case IsClockWise(dNew, dOld)
                Return Decision.right
            Case (IsClockWise(dNew, dOld) = False)
                Return Decision.left
        End Select
    End Function
    Public Sub Move()
        If dead Then Return
        If beenUpdated = False Then Return

        If invicibilityTime > 0 Then invicibilityTime -= 1 Else invicibilityTime = 0
        targetFoodCoord = GetFoodCoord(0)
        DetermineDelta()
        Dim coordLastOld As Coord = snakeBlocks.Last.coord
        Dim coordFirstOld As Coord = snakeBlocks.First.coord
        directionHistory.Insert(0, dNew)
        If directionHistory.Count > 15 Then directionHistory.RemoveAt(directionHistory.Count - 1)
        decisionHistory.Insert(0, GetDecision())
        If decisionHistory.Count > 20 Then decisionHistory.RemoveAt(decisionHistory.Count - 1)
        snakeOccupied(snakeBlocks.Last.coord.x)(snakeBlocks.Last.coord.y) = CollisionType.none
        'graph.FillRectangle(New SolidBrush(Color.Black), snakeBlocks.Last.coord.x * boxSize, snakeBlocks.Last.coord.y * boxSize, boxSize, boxSize)
        For i = snakeBlocks.Count - 1 To 1 Step -1
            snakeBlocks(i).coord = snakeBlocks(i - 1).coord
            snakeBlocks(i).dNew = snakeBlocks(i - 1).dNew
        Next
        snakeBlocks.First.coord += delta
        If snakeBlocks.First.coord.GridDistance(coordFirstOld) > 1 Then
            segments.Insert(0, New SnakeSegment)
        End If
        For i As Long = segments.Count - 1 To 1 Step -1
            segments(i - 1).Add(segments(i).blocks.First)
            segments(i).blocks.RemoveAt(0)
        Next
        snakeBlocks.First.dNew = dNew
        ' snakeBlock.First = Head
        ' snakeBlock.Last = Tail
        ' segments.First = Head segment
        ' segments.Last = Tail segment
        If growthQueue > 0 Then

            snakeOccupied(snakeBlocks.Last.coord.x)(snakeBlocks.Last.coord.y) = CollisionType.snake
            Grow(coordLastOld)
            growthQueue -= 1
        End If
        If growthQueue < 0 Then
            If snakeBlocks.Count() >= 2 Then
                SpawnFood(New EdibleSnake(New SolidColorBrush(snakeBlocks.Last.colour)), snakeBlocks.Last.coord)
                snakeOccupied(snakeBlocks.Last.coord.x)(snakeBlocks.Last.coord.y) = CollisionType.food
                snakeBlocks.RemoveAt(snakeBlocks.Count - 1)
                RemoveLastSegBlock()
                SegmentCheck()
                growthQueue += 1
            End If
        End If

        If snakeBlocks.First.coord.x < 0 Then snakeBlocks.First.coord.x = gridXCount
        If snakeBlocks.First.coord.y < 0 Then snakeBlocks.First.coord.y = gridYCount
        If snakeBlocks.First.coord.x > gridXCount Then snakeBlocks.First.coord.x = 0
        If snakeBlocks.First.coord.y > gridYCount Then snakeBlocks.First.coord.y = 0

        For i = 0 To foodList.Count - 1
            If snakeBlocks.First.coord = foodList(i).Coordinate Then
                foodList(i).Interact(Me)
                foodList(i).Destruct()
            End If
        Next
        dOld = dNew
        SegmentCheck()
        'segments.First.FirstSegRecalc()
        'segments.Last.LastSegRecalc()
        For i As Long = 0 To segments.Count - 1
            segments(i).FullSegRecalc()
        Next

        ' DRAW
        Dim blockNo As Long = 0
        For i As Long = 0 To segments.Count - 1
            Dim fillBrush As New LinearGradientBrush()
            fillBrush.StartPoint = New Point(0, 0)
            For o As Long = 0 To segments(i).blocks.Count() - 1
                Dim gradientSection As New GradientStop()
                gradientSection.Color = GetColour(blockNo)
                gradientSection.Offset = CDbl(o) / CDbl(segments(i).blocks.Count)
                fillBrush.GradientStops.Add(gradientSection)
                blockNo += 1
            Next
            fillBrush.SpreadMethod = GradientSpreadMethod.Reflect
            fillBrush.MappingMode = BrushMappingMode.Absolute
            fillBrush.StartPoint = New Point(segments(i).blocks.First.coord.x * boxSize, segments(i).blocks.First.coord.y * boxSize)
            ' If Difference(segments(i).blocks.First.coord.x, segments(i).blocks.Last.coord.x) > Difference(segments(i).blocks.First.coord.y, segments(i).blocks.Last.coord.y) Then
            fillBrush.EndPoint = fillBrush.StartPoint + New Point(((segments(i).blocks.Count - 1) * boxSize) / 2.0, ((segments(i).blocks.Count - 1) * boxSize) / 2.0)
            'Else
            'fillBrush.EndPoint = fillBrush.StartPoint + New Point(segments(i).blocks.Last.coord.x * boxSize, segments(i).blocks.Count * boxSize)
            ' End If
            segments(i).polygon.Fill = fillBrush
            segments(i).polygon.Stroke = GetBorderBrush()
            segments(i).polygon.StrokeThickness = GetBorderThickness()
        Next
    End Sub
    Private Sub SegmentCheck()
        If segments.Last.blocks.Count = 0 Then
            GameCanvasPublic.Children.Remove(segments.Last.polygon)
            segments.RemoveAt(segments.Count - 1)
        End If
    End Sub
    Public Function GetBorderThickness() As Double
        If invicibilityTime > 0 Then Return 0.9
        If isTeamsEnabled Then Return 1
        Return 0
    End Function
    Public Function GetBorderBrush() As Brush
        If speedBonus > 0 And invicibilityTime > 0 Then

            Dim fiveColorLGB As LinearGradientBrush = New LinearGradientBrush()
            fiveColorLGB.StartPoint = New Point(0, 0)
            fiveColorLGB.EndPoint = New Point(1, 1)

            Dim blueGS As GradientStop = New GradientStop()
            blueGS.Color = Colors.Gray
            blueGS.Offset = 0.0
            fiveColorLGB.GradientStops.Add(blueGS)

            Dim redGS As GradientStop = New GradientStop()
            redGS.Color = Colors.Red
            redGS.Offset = 1.0
            fiveColorLGB.GradientStops.Add(redGS)
            Return fiveColorLGB
        End If
        If speedBonus > 0 Then
            Dim fiveColorLGB As LinearGradientBrush = New LinearGradientBrush()
            fiveColorLGB.StartPoint = New Point(0, 0)
            fiveColorLGB.EndPoint = New Point(1, 1)

            Dim blueGS As GradientStop = New GradientStop()
            blueGS.Color = Colors.Orange
            blueGS.Offset = 0.0
            fiveColorLGB.GradientStops.Add(blueGS)

            Dim redGS As GradientStop = New GradientStop()
            redGS.Color = Colors.Red
            redGS.Offset = 1.0
            fiveColorLGB.GradientStops.Add(redGS)
            Return fiveColorLGB
        End If

        If invicibilityTime > 0 Then Return Brushes.Gray
        If isTeamsEnabled Then Return New SolidColorBrush(ColourValue(teamNo * 30, 0, SnakePattern.rainbow))
        Return Brushes.Gainsboro
    End Function
    Public Function GetColour(index As Long) As Color
        If invicibilityTime > 0 Then Return HighlightColour(snakeBlocks(index).colour)
        Return snakeBlocks(index).colour
    End Function
    Public Function HighlightColour(colourDefault As Color) As Color
        Return Color.FromRgb(calcHighVal(colourDefault.R), calcHighVal(colourDefault.G), calcHighVal(colourDefault.B))
    End Function
    Public Function calcHighVal(val As Long) As Long
        val /= 1.75
        Dim valTemp As Long = 255 - val
        valTemp /= 2
        val += valTemp
        Return val
    End Function
    Public Shared Function ColourValue(input As Long, snakeNo As Long, snakePatternT As SnakePattern) As Color
        Dim R As Long = 255
        Dim G As Long = 255
        Dim B As Long = 255


        'RAIIIIIIIIIIIIIIINBBBBBBBBBBBBBBOOOOOOOOOOOOOWWWWWWWWWWSSSSSSS!

        Select Case snakePatternT
            Case SnakePattern.rainbow
                Dim rainbowOption As Long = snakeNo Mod 8
                Select Case rainbowOption
                    Case 0
                        CalcRainbowColour(input + snakeNo, G, B, R)
                    Case 1
                        CalcRainbowColour(input + snakeNo, R, G, B)
                    Case 2
                        CalcRainbowColour(input + snakeNo, B, G, R)
                    Case 3
                        CalcRainbowColour(input + snakeNo, G, B, R)
                    Case 4
                        CalcRainbowColour(input + snakeNo, R, B, G)
                    Case 5
                        CalcRainbowColour(input + snakeNo, G, R, B)
                    Case 6
                        CalcRainbowColour(input + snakeNo, B, R, G)
                    Case 7
                        CalcRainbowColour(input + snakeNo, R, G, B)
                    Case 8
                        CalcRainbowColour(input + snakeNo, B, R, G)
                End Select
            Case SnakePattern.stripe
                CalcRainbowColour(25.5 + snakeNo * 10, R, G, B)
                CalcStripeColour(input, R, G, B)
        End Select
        Return Color.FromRgb(R, G, B)
    End Function
    Private Shared Sub CalcStripeColour(ByVal input As Single, ByRef R As Long, ByRef G As Long, ByRef B As Long)
        Dim sineTemp As Single = Math.Sin(input / 0.8) * 100.0

        R += sineTemp
        If R > 255 Then R = 255
        If R < 0 Then R = 0
        G += sineTemp
        If G > 255 Then G = 255
        If G < 0 Then G = 0
        B += sineTemp
        If B > 255 Then B = 255
        If B < 0 Then B = 0
    End Sub
    Private Shared Sub CalcRainbowColour(ByVal input As Long, ByRef R As Long, ByRef G As Long, ByRef B As Long)
        Const Rate = 20
        input *= Rate
Begin:

        If input >= 1785 Then
            input -= 1530
            GoTo Begin
        End If
        Select Case input
            Case 0 To 255
                'White to Yellow'
                CCDown(B, input)
            Case 256 To 510
                'Yellow to Red'
                input -= 255
                B = 0
                CCDown(G, input)
            Case 511 To 765
                'Red to Purple'
                G = 0
                B = 0
                input -= 510
                CCUp(B, input)
            Case 766 To 1020
                'Purple to Blue'
                input -= 765
                G = 0
                CCDown(R, input)
            Case 1021 To 1275
                'Blue to Cyan'
                input -= 1020
                R = 0
                G = 0
                CCUp(G, input)
            Case 1276 To 1530
                'Cyan to Green'
                input -= 1275
                R = 0
                CCDown(B, input)
            Case 1531 To 1785
                'Green to Yellow'
                B = 0
                R = 0
                input -= 1530
                CCUp(R, input)
        End Select
    End Sub

    Private Shared Sub CCDown(ByRef colour As Long, ByRef input As Long)
        If input >= 255 Then
            colour = 0
            input -= 255
        Else
            colour -= input
            input = 0
        End If
    End Sub
    Private Shared Sub CCUp(ByRef colour As Long, ByRef input As Long)
        If input >= 255 Then
            colour = 255
            input -= 255
        Else
            colour += input
            input = 0
        End If
    End Sub
    Private Function OppositeDirection(d As Direction) As Direction
        Select Case d
            Case Direction.up
                Return Direction.down
            Case Direction.left
                Return Direction.right
            Case Direction.down
                Return Direction.up
            Case Direction.right
                Return Direction.left
        End Select
        Return -1
    End Function
    Public Sub DetermineDelta()
        Select Case dNew
            Case Direction.right
                delta.x = 1
                delta.y = 0
            Case Direction.left
                delta.x = -1
                delta.y = 0
            Case Direction.up
                delta.x = 0
                delta.y = -1
            Case Direction.down
                delta.x = 0
                delta.y = 1
        End Select
    End Sub
    Public Sub Kill()
        If dead = True Then Return
        RecDEATHFeedback()
        dead = True
        numberDead += 1
        If singlePlayer Then Return
        For Each segment In segments
            segment.polygon.Fill = Brushes.Gray
        Next
    End Sub
End Class
Public Enum Direction
    up = 0
    left = 1
    down = 2
    right = 3
End Enum