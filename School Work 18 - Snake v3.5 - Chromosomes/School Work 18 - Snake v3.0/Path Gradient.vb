Imports System
Imports System.Windows
Imports System.Windows.Media
Imports System.Windows.Shapes
Public Enum GradientMode
    Perpendicular
    Parallel
End Enum


Public Class GradientPath
    Inherits FrameworkElement
    Const outlinePenWidth As Double = 1

    Public Shared DataProperty As DependencyProperty = Path.DataProperty.AddOwner(GetType(GradientPath), New FrameworkPropertyMetadata(Nothing, FrameworkPropertyMetadataOptions.AffectsMeasure Or FrameworkPropertyMetadataOptions.AffectsRender))

    Public Shared GradientStopsProperty As DependencyProperty = GradientBrush.GradientStopsProperty.AddOwner(GetType(GradientPath), New FrameworkPropertyMetadata(Nothing, FrameworkPropertyMetadataOptions.AffectsRender))

    Public Shared GradientModeProperty As DependencyProperty = DependencyProperty.Register("GradientMode", GetType(GradientMode), GetType(GradientPath), New FrameworkPropertyMetadata(GradientMode.Perpendicular, FrameworkPropertyMetadataOptions.AffectsRender))

    Public Shared ColorInterpolationModeProperty As DependencyProperty = GradientBrush.ColorInterpolationModeProperty.AddOwner(GetType(GradientPath), New FrameworkPropertyMetadata(ColorInterpolationMode.SRgbLinearInterpolation, FrameworkPropertyMetadataOptions.AffectsRender))

    Public Shared StrokeThicknessProperty As DependencyProperty = Shape.StrokeThicknessProperty.AddOwner(GetType(GradientPath), New FrameworkPropertyMetadata(1.0, FrameworkPropertyMetadataOptions.AffectsMeasure Or FrameworkPropertyMetadataOptions.AffectsRender))

    Public Shared StrokeStartLineCapProperty As DependencyProperty = Shape.StrokeStartLineCapProperty.AddOwner(GetType(GradientPath), New FrameworkPropertyMetadata(PenLineCap.Flat, FrameworkPropertyMetadataOptions.AffectsMeasure Or FrameworkPropertyMetadataOptions.AffectsRender))

    Public Shared StrokeEndLineCapProperty As DependencyProperty = Shape.StrokeEndLineCapProperty.AddOwner(GetType(GradientPath), New FrameworkPropertyMetadata(PenLineCap.Flat, FrameworkPropertyMetadataOptions.AffectsMeasure Or FrameworkPropertyMetadataOptions.AffectsRender))

    Public Shared ToleranceProperty As DependencyProperty = DependencyProperty.Register("Tolerance", GetType(Double), GetType(GradientPath), New FrameworkPropertyMetadata(Geometry.StandardFlatteningTolerance, FrameworkPropertyMetadataOptions.AffectsRender))

    Public Sub New()

        GradientStops = New GradientStopCollection()
    End Sub

    Public Property Data As Geometry
        Set(value As Geometry)
            SetValue(DataProperty, value)
        End Set
        Get
            Return GetValue(DataProperty)
        End Get
    End Property



    Public Property GradientStops As GradientStopCollection

        Set(value As GradientStopCollection)
            SetValue(GradientStopsProperty, value)
        End Set
        Get
            Return GetValue(GradientStopsProperty)
        End Get
    End Property


    Public Property GradientMode As GradientMode
        Set(value As GradientMode)
            SetValue(GradientModeProperty, value)
        End Set
        Get
            Return GetValue(GradientModeProperty)
        End Get
    End Property
    Public Property ColorInterpolationMode As ColorInterpolationMode

        Set(value As ColorInterpolationMode)
            SetValue(ColorInterpolationModeProperty, value)
        End Set
        Get
            Return GetValue(ColorInterpolationModeProperty)
        End Get
    End Property

    Public Property StrokeThickness As Double

        Set(value As Double)
            SetValue(StrokeThicknessProperty, value)
        End Set
        Get
            Return CDbl(GetValue(StrokeThicknessProperty))
        End Get
    End Property

    Public Property StrokeStartLineCap As PenLineCap

        Set(value As PenLineCap)
            SetValue(StrokeStartLineCapProperty, value)
        End Set
        Get
            Return GetValue(StrokeStartLineCapProperty)
        End Get
    End Property
    Public Property StrokeEndLineCap As PenLineCap

        Set(value As PenLineCap)
            SetValue(StrokeEndLineCapProperty, value)
        End Set
        Get
            Return GetValue(StrokeEndLineCapProperty)
        End Get
    End Property

    Public Property Tolerance As Double
        Set(value As Double)
            SetValue(ToleranceProperty, value)
        End Set
        Get
            Return CDbl(GetValue(ToleranceProperty))
        End Get
    End Property

    Protected Overrides Function MeasureOverride(availableSize As Size) As Size
        If (Data Is Nothing) Then Return MyBase.MeasureOverride(availableSize)
        Dim Pen As Pen = New Pen()
        Pen.Brush = Brushes.Black
        Pen.Thickness = StrokeThickness
        Pen.StartLineCap = StrokeStartLineCap
        Pen.EndLineCap = StrokeEndLineCap

        Dim Rect As Rect = Data.GetRenderBounds(Pen)
        Return New Size(Rect.Right, Rect.Bottom)
    End Function

    Protected Overrides Sub OnRender(dc As DrawingContext)

        If Data Is Nothing Then Return


        ' Flatten the PathGeometry
        Dim PathGeometry As PathGeometry = Data.GetFlattenedPathGeometry(Tolerance, ToleranceType.Absolute)

        For Each pathFigure In PathGeometry.Figures

            If (pathFigure.Segments.Count <> 1) Then Throw New NotSupportedException("More than one PathSegment in a flattened PathFigure")


            If ((TypeOf pathFigure.Segments(0) Is PolyLineSegment) = False) Then Throw New NotSupportedException("Segment is not PolylineSegment in flattened PathFigure")


            Dim polylineSegment As PolyLineSegment = pathFigure.Segments(0)
            Dim points As PointCollection = polylineSegment.Points

            If (points.Count < 1) Then Throw New NotSupportedException("Empty PointCollection in PolylineSegment in flattened PathFigure")


            ' Calculate total length for ParallelMode
            Dim totalLength As Double = 0
            Dim accumLength As Double = 0
            Dim ptPrev As Point = pathFigure.StartPoint
            For Each pt In points

                totalLength += (pt - ptPrev).Length
                ptPrev = pt
            Next

            ' Get the first vector
            Dim vector As Vector = points(0) - pathFigure.StartPoint

            ' Use that to draw the start line cap
            DrawLineCap(dc, pathFigure.StartPoint, vector, StrokeStartLineCap, PenLineCap.Flat)

            ' Rotate the vector counter-clockwise 90 degrees
            Dim vector90 As Vector = New Vector(vector.Y, -vector.X)
            vector90.Normalize()

            ' Calculate perpendiculars
            Dim ptUpPrev As Point = pathFigure.StartPoint + StrokeThickness / 2 * vector90
            Dim ptDnPrev As Point = pathFigure.StartPoint - StrokeThickness / 2 * vector90

            ' Begin with the StartPoint
            ptPrev = pathFigure.StartPoint

            ' Loop through the PointCollection
            For index As Integer = 0 To points.Count - 1
                Dim ptUp As Point
                Dim ptDn As Point
                Dim point As Point = points(index)
                Dim vect1 As Vector = ptPrev - point
                Dim angle1 As Double = Math.Atan2(vect1.Y, vect1.X)

                ' Treat the last point much like the first
                If (index = points.Count - 1) Then

                    ' Rotate clockwise 90 degrees
                    vector90 = New Vector(-vect1.Y, vect1.X)
                    vector90.Normalize()
                    ptUp = point + (StrokeThickness / 2) * vector90
                    ptDn = point - (StrokeThickness / 2) * vector90


                Else

                    ' Get the next vector and average the two
                    Dim vect2 As Vector = points(index + 1) - point
                    Dim angle2 As Double = Math.Atan2(vect2.Y, vect2.X)
                    Dim diff As Double = angle2 - angle1

                    If (diff < 0) Then diff += 2 * Math.PI


                    Dim angle As Double = angle1 + diff / 2
                    Dim vect As Vector = New Vector(Math.Cos(angle), Math.Sin(angle))
                    vect.Normalize()
                    ptUp = point + StrokeThickness / 2 * vect
                    ptDn = point - StrokeThickness / 2 * vect
                End If
                ' Transform to horizontalize tetragon constructed of perpendiculars
                Dim rotate As RotateTransform = New RotateTransform(-180 * angle1 / Math.PI, ptPrev.X, ptPrev.Y)

                ' Construct the tetragon
                Dim tetragonGeo As PathGeometry = New PathGeometry()
                Dim tetragonFig As PathFigure = New PathFigure()
                tetragonFig.StartPoint = rotate.Transform(ptUpPrev)
                tetragonFig.IsClosed = True
                tetragonFig.IsFilled = True
                Dim tetragonSeg As PolyLineSegment = New PolyLineSegment()
                tetragonSeg.Points.Add(rotate.Transform(ptUp))
                tetragonSeg.Points.Add(rotate.Transform(ptDn))
                tetragonSeg.Points.Add(rotate.Transform(ptDnPrev))
                tetragonFig.Segments.Add(tetragonSeg)
                tetragonGeo.Figures.Add(tetragonFig)

                Dim Brush As LinearGradientBrush

                If (GradientMode = GradientMode.Perpendicular) Then

                    Brush = New LinearGradientBrush(GradientStops, New Point(0, 1), New Point(0, 0))

                Else

                    ' Find where we are in the total path
                    Dim offset1 As Double = accumLength / totalLength
                    accumLength += vect1.Length
                    Dim offset2 As Double = accumLength / totalLength

                    ' Calculate ax + b factors for gradientStop.Offset conversion
                    Dim a As Double = 1 / (offset2 - offset1)
                    Dim b As Double = -offset1 * a

                    ' Calculate a new GradientStopCollection based on restricted lenth
                    Dim GradientStops As GradientStopCollection = New GradientStopCollection()

                    If GradientStops IsNot Nothing Then

                        For Each gradientStop In GradientStops
                            GradientStops.Add(New GradientStop(gradientStop.Color, a * gradientStop.Offset + b))
                        Next
                    End If

                    Brush = New LinearGradientBrush(GradientStops, New Point(1, 0), New Point(0, 0))
                End If

                ' Draw the tetragon rotated back into place
                Brush.ColorInterpolationMode = ColorInterpolationMode
                Dim Pen As Pen = New Pen(Brush, outlinePenWidth)
                rotate.Angle = 180 * angle1 / Math.PI
                dc.PushTransform(rotate)
                dc.DrawGeometry(Brush, Pen, tetragonGeo)
                dc.Pop()

                ' Something special for the last point
                If (index = points.Count - 1) Then
                    DrawLineCap(dc, point, -vect1, PenLineCap.Flat, StrokeEndLineCap)

                End If

                ' Prepare for next iteration
                ptPrev = point
                ptUpPrev = ptUp
                ptDnPrev = ptDn

            Next
        Next
    End Sub

    Sub DrawLineCap(dc As DrawingContext, point As Point, vector As Vector, startLineCap As PenLineCap, endLineCap As PenLineCap)

        If (startLineCap = PenLineCap.Flat And endLineCap = PenLineCap.Flat) Then Return


        ' Construct really tiny horizontal line
        Vector.Normalize()
        Dim angle As Double = Math.Atan2(vector.Y, vector.X)
        Dim rotate As RotateTransform = New RotateTransform(-180 * angle / Math.PI, point.X, point.Y)
        Dim point1 As Point = rotate.Transform(point)
        Dim point2 As Point = rotate.Transform(point + 0.25 * vector)

        ' Construct pen for that line
        Dim Pen As Pen = New Pen()

        Pen.Thickness = StrokeThickness
        Pen.StartLineCap = startLineCap
        Pen.EndLineCap = endLineCap


        ' Why don't I just call dc.DrawLine at this point? Well, to avoid gaps between 
        '  the tetragons, I had to draw them with an 'outlinePenWidth' pen based on the 
        '  same brush as the fill. If I just called dc.DrawLine here, the caps would 
        '  look a little smaller than the line, so....

        Dim lineGeo As LineGeometry = New LineGeometry(point1, point2)
        Dim pathGeo As PathGeometry = lineGeo.GetWidenedPathGeometry(Pen)
        Dim Brush As Brush

        If (GradientMode = GradientMode.Perpendicular) Then

            Brush = New LinearGradientBrush(GradientStops, New Point(0, 0), New Point(0, 1))
            TryCast(Brush, LinearGradientBrush).ColorInterpolationMode = ColorInterpolationMode

        Else

            Dim offset As Double = endLineCap
            If endLineCap = PenLineCap.Flat Then offset = 0 Else offset = 1
            Brush = New SolidColorBrush(GetColorFromGradientStops(offset))
        End If

        Pen = New Pen(Brush, outlinePenWidth)
        rotate.Angle = 180 * angle / Math.PI
        dc.PushTransform(rotate)
        dc.DrawGeometry(Brush, Pen, pathGeo)
        dc.Pop()
    End Sub

    Function GetColorFromGradientStops(offset As Double) As Color

        If (GradientStops Is Nothing Or GradientStops.Count = 0) Then Return Color.FromArgb(0, 0, 0, 0)


        If (GradientStops.Count = 1) Then Return GradientStops(0).Color


        Dim lowerOffset As Double = Double.MinValue
        Dim upperOffset As Double = Double.MaxValue
        Dim lowerIndex As Integer = -1
        Dim upperIndex As Integer = -1

        For i As Integer = 0 To GradientStops.Count - 1
            Dim gradientStop As GradientStop = GradientStops(i)

            If (lowerOffset < GradientStop.Offset And GradientStop.Offset <= offset) Then

                lowerOffset = GradientStop.Offset
                lowerIndex = i
            End If

            If (upperOffset > GradientStop.Offset And GradientStop.Offset >= offset) Then
                upperOffset = GradientStop.Offset
                upperIndex = i
            End If
        Next

        If (lowerIndex = -1) Then Return GradientStops(upperIndex).Color Else If (upperIndex = -1) Then Return GradientStops(lowerIndex).Color



        If (lowerIndex = upperIndex) Then Return GradientStops(lowerIndex).Color


        Dim clr1 As Color = GradientStops(lowerIndex).Color
        Dim clr2 As Color = GradientStops(upperIndex).Color
        Dim den As Double = upperOffset - lowerOffset
        Dim wt1 As Single = CSng((upperOffset - offset) / den)
        Dim wt2 As Single = CSng((offset - lowerOffset) / den)
        Dim clr As Color = New Color()

        Select Case (ColorInterpolationMode)
            Case ColorInterpolationMode.SRgbLinearInterpolation
                clr = Color.FromArgb(CByte(wt1 * clr1.A + wt2 * clr2.A),
                                     CByte(wt1 * clr1.R + wt2 * clr2.R),
                                     CByte(wt1 * clr1.G + wt2 * clr2.G),
                                     CByte(wt1 * clr1.B + wt2 * clr2.B))
            Case ColorInterpolationMode.ScRgbLinearInterpolation
                clr = clr1 * wt1 + clr2 * wt2
        End Select
        Return clr
    End Function
End Class