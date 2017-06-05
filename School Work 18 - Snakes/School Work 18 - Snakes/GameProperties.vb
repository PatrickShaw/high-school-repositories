Enum Difficulty
    easy
    hard
    medium
End Enum
Enum ArenaType
    open
    box
End Enum
Public Module GameProperties
    Public score01 As Single = 0
    Public score02 As Single = 0
    Public scoreMultiplier As Single = 1
    Public firstGame As Boolean = True
    Public singlePlayer
    Const gridWidth_DEFAULT = 29
    Const gridHeight_DEFAULT = 29
    Public gridWidth As Long = gridWidth_DEFAULT
    Public gridHeight As Long = gridHeight_DEFAULT
    Public gridXCount As Long = gridWidth - 1
    Public gridYCount As Long = gridHeight - 1
    Public totalSpace As Long = gridXCount * gridYCount
    Public Const boxSize = 6
    Public snakeGrid As Panel()()
    Public snakeOccupied As CollisionType()()
    Public snakeList As List(Of Snake) = New List(Of Snake)
    Public foodList As List(Of Food) = New List(Of Food)
    Public foodToRemove As List(Of Long) = New List(Of Long)
    Public diff = Difficulty.medium
    Public numberOfPlayers As Long
    Public numberOfUsers As Long = 0
    Public numberOfComputers As Long = 5
    Public numberDead As Long = 0
    Public keyForPlayer As Keys()() = New Keys(1)() {New Keys(3) {Keys.W, Keys.A, Keys.S, Keys.D}, New Keys(3) {Keys.Up, Keys.Left, Keys.Down, Keys.Right}}
End Module