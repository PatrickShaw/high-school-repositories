
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
    Const gridWidth_DEFAULT = 50
    Const gridHeight_DEFAULT = 50
    Public gridWidth As Long = gridWidth_DEFAULT
    Public gridHeight As Long = gridHeight_DEFAULT
    Public gridXCount As Long = gridWidth - 1
    Public gridYCount As Long = gridHeight - 1
    Public totalSpace As Long = gridXCount * gridYCount
    Public boxSize As Long = 6
    Public globalSpeed As Single
    Public snakeGrid As PictureBox
    Public graph As Graphics
    Public graphPen As New SolidBrush(Color.Black)
    Public snakeOccupied As CollisionType()()
    Public snakeList As List(Of Snake) = New List(Of Snake)
    Public foodList As List(Of Food) = New List(Of Food)
    Public foodToRemove As List(Of Long) = New List(Of Long)
    Public numberOfPlayers As Long
    Public numberOfUsers As Long = 1
    Public numberOfComputers As Long = 0
    Public numberDead As Long = 0
    Public numberOfFoodz As Long = 2
    ' Eddie: 2QWER
    ' IJKL

    Public keyForPlayer As Keys()() = New Keys(5)() {New Keys(3) {Keys.Up, Keys.Left, Keys.Down, Keys.Right}, New Keys(3) {Keys.D2, Keys.Q, Keys.W, Keys.E}, New Keys(3) {Keys.I, Keys.J, Keys.K, Keys.L}, New Keys(3) {Keys.D6, Keys.T, Keys.Y, Keys.U}, New Keys(3) {Keys.S, Keys.Z, Keys.X, Keys.C}, New Keys(3) {Keys.G, Keys.V, Keys.B, Keys.N}}
End Module