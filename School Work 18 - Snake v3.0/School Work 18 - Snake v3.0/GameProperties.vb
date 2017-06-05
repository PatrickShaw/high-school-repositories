

Enum ArenaType
    open
    box
    maze
End Enum
Public Module GameProperties
    Public score01 As Single = 0
    Public score02 As Single = 0
    Public scoreMultiplier As Single = 1

    Public gameScores As TextBlock()

    Public firstGame As Boolean = True
    Public singlePlayer
    Public isTeamsEnabled As Boolean = False

    Const gridWidth_DEFAULT = 70
    Const gridHeight_DEFAULT = 45
    Public gridWidth As Long = gridWidth_DEFAULT
    Public gridHeight As Long = gridHeight_DEFAULT
    Public gridXCount As Long = gridWidth - 1
    Public gridYCount As Long = gridHeight - 1
    Public totalSpace As Long = gridXCount * gridYCount
    Public boxSize As Long = 6
    Public snakeGrid As Rectangle()()

    Public snakeStartingLength = 3

    Public globalSpeed As Single

    Public snakeOccupied As CollisionType()()
    Public snakeList As List(Of Snake) = New List(Of Snake)
    Public foodList As List(Of Food) = New List(Of Food)
    Public foodToRemove As List(Of Long) = New List(Of Long)

    Public numberOfPlayers As Long
    Public numberOfUsers As Long
    Public numberOfComputers As Long
    Public numberDead As Long = 0
    Public numberOfFoodz As Long = 2


    Public keyForPlayer As Key()() = New Key(5)() {New Key(3) {Key.Up, Key.Left, Key.Down, Key.Right}, New Key(3) {Key.D2, Key.Q, Key.W, Key.E}, New Key(3) {Key.I, Key.J, Key.K, Key.L}, New Key(3) {Key.D6, Key.T, Key.Y, Key.U}, New Key(3) {Key.S, Key.Z, Key.X, Key.C}, New Key(3) {Key.G, Key.V, Key.B, Key.N}}
End Module