Public Class ResizeableControl

    Public Event ResizeOccurred(ByRef c As System.Windows.Forms.Control)

    Private WithEvents m_Control As Control
    Private m_MouseDown As Boolean = False
    Private m_Edge As EdgeEnum = EdgeEnum.None
    Private m_Width As Integer = 4
    Private m_OutlineDrawn As Boolean = False
    Private m_HighlightColor As Drawing.Color = Color.Fuchsia
    Private m_Last_Location As Point = New Point(0, 0)

    Friend m_AllowEdges As EdgeEnum = EdgeEnum.All 'Default Behavior

    Public Enum EdgeEnum
        None = 0
        Right = 1
        Left = 2
        Top = 4
        Bottom = 8
        TopLeft = 16
        'added
        All = TopLeft Or Left Or Right Or Top Or Bottom
        ResizeAnchorTopLeft = Right Or Bottom
        OnlyMove = TopLeft
        'end added
    End Enum

    Public Property AllowEdges() As EdgeEnum
        Get
            Return m_AllowEdges
        End Get
        Set(ByVal value As EdgeEnum)
            m_AllowEdges = value
        End Set
    End Property

    Public Property HighlightColor() As Drawing.Color
        Get
            Return m_HighlightColor
        End Get
        Set(ByVal value As Drawing.Color)
            m_HighlightColor = value
        End Set
    End Property

    Public Sub New(ByVal Control As Control)
        m_Control = Control
    End Sub

    'added
    Public Sub New(ByVal Control As Control, ByVal AllowedEdges As EdgeEnum)
        m_Control = Control
        m_AllowEdges = AllowedEdges
    End Sub
    'end added

    Private Sub Control_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles m_Control.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then m_MouseDown = True
    End Sub

    Private Sub Control_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles m_Control.MouseUp
        m_MouseDown = False
    End Sub

    Private Sub Control_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles m_Control.MouseMove
        Dim c As Control = CType(sender, Control)
        Dim g As Graphics = c.CreateGraphics
        Dim B As New System.Drawing.SolidBrush(m_HighlightColor)
        'added 'Moved from Select Case mEdge : Case EdgeEnum.None
        If m_OutlineDrawn Then
            c.Refresh()
            m_OutlineDrawn = False
        End If
        'end added
        Select Case m_Edge
            Case EdgeEnum.TopLeft
                g.FillRectangle(B, 0, 0, m_Width * 4, m_Width * 4)
                m_OutlineDrawn = True
            Case EdgeEnum.Left
                g.FillRectangle(B, 0, 0, m_Width, c.Height)
                m_OutlineDrawn = True
            Case EdgeEnum.Right
                g.FillRectangle(B, c.Width - m_Width, 0, c.Width, c.Height)
                m_OutlineDrawn = True
            Case EdgeEnum.Top
                g.FillRectangle(B, 0, 0, c.Width, m_Width)
                m_OutlineDrawn = True
            Case EdgeEnum.Bottom
                g.FillRectangle(B, 0, c.Height - m_Width, c.Width, m_Width)
                m_OutlineDrawn = True
                'Case EdgeEnum.None 'Moved before Select Case
                '    If mOutlineDrawn Then
                '        c.Refresh()
                '        mOutlineDrawn = False
                '    End If
        End Select

        If m_MouseDown And m_Edge <> EdgeEnum.None Then
            c.SuspendLayout()
            Select Case m_Edge
                Case EdgeEnum.TopLeft
                    'added
                    Dim iX_Delta As Integer = e.X
                    Dim iY_Delta As Integer = e.Y
                    If Not (m_Last_Location = New Point(0, 0)) Then
                        iX_Delta -= m_Last_Location.X
                        iY_Delta -= m_Last_Location.Y
                    End If
                    c.SetBounds(c.Left + iX_Delta, c.Top + iY_Delta, c.Width, c.Height)
                    'end added
                    'c.SetBounds(c.Left + e.X, c.Top + e.Y, c.Width, c.Height) 'Original
                    RaiseEvent ResizeOccurred(c)
                Case EdgeEnum.Left
                    c.SetBounds(c.Left + e.X, c.Top, c.Width - e.X, c.Height)
                    RaiseEvent ResizeOccurred(c)
                Case EdgeEnum.Right
                    c.SetBounds(c.Left, c.Top, c.Width - (c.Width - e.X), c.Height)
                    RaiseEvent ResizeOccurred(c)
                    'added
                    m_Last_Location = e.Location
                    'end added
                Case EdgeEnum.Top
                    c.SetBounds(c.Left, c.Top + e.Y, c.Width, c.Height - e.Y)
                    RaiseEvent ResizeOccurred(c)
                Case EdgeEnum.Bottom
                    c.SetBounds(c.Left, c.Top, c.Width, c.Height - (c.Height - e.Y))
                    RaiseEvent ResizeOccurred(c)
            End Select
            c.ResumeLayout()
        Else
            Select Case True
                Case e.X <= (m_Width * 4) And e.Y <= (m_Width * 4) 'top left corner
                    c.Cursor = Cursors.SizeAll
                    m_Edge = EdgeEnum.TopLeft
                Case e.X <= m_Width 'left edge
                    c.Cursor = Cursors.VSplit
                    m_Edge = EdgeEnum.Left
                Case e.X > c.Width - (m_Width + 1) 'right edge
                    c.Cursor = Cursors.VSplit
                    m_Edge = EdgeEnum.Right
                Case e.Y <= m_Width 'top edge
                    c.Cursor = Cursors.HSplit
                    m_Edge = EdgeEnum.Top
                Case e.Y > c.Height - (m_Width + 1) 'bottom edge
                    c.Cursor = Cursors.HSplit
                    m_Edge = EdgeEnum.Bottom
                Case Else 'no edge
                    c.Cursor = Cursors.Default
                    m_Edge = EdgeEnum.None
            End Select
            m_Edge = m_Edge And m_AllowEdges
            If m_Edge = EdgeEnum.None Then c.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub Control_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_Control.MouseLeave
        Dim c As Control = CType(sender, Control)
        c.Cursor = Cursors.Default
        m_Edge = EdgeEnum.None
        c.Refresh()
    End Sub

End Class


