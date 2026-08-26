Imports Centrafuse.ControlBase
Imports Centrafuse.Types
Imports Centrafuse.Types.ControlType

Public Class PositionIndicator
    Inherits ControlBase

    Private m_CurrentPosition As Int16 = 1
    Private m_PositionCount As Int16 = 4
    Private m_Orientation As Orientation = Orientation.Horizontal
    Private m_PositionAlignment As Align = Align.Center
    Private m_Offset As Int16 = 0
    Private m_IndicatorImageBounds As Rectangle = Nothing
    Private m_Action As String = ""
    Private m_Off As String = ""
    Private m_Down As String = ""

    Public Sub New()
        MyBase.ControlType = ControlType.PositionIndicator
    End Sub

    Public Property CurrentPosition() As Int16
        Get
            Return m_CurrentPosition
        End Get
        Set(ByVal value As Int16)
            m_CurrentPosition = value
        End Set
    End Property

    Public Property PositionCount() As Int16
        Get
            Return m_PositionCount
        End Get
        Set(ByVal value As Int16)
            m_PositionCount = value
        End Set
    End Property

    Public Property Orientation() As Orientation
        Get
            Return m_Orientation
        End Get
        Set(ByVal value As Orientation)
            m_Orientation = value
        End Set
    End Property

    Public Property PositionAlignment() As Align
        Get
            Return m_PositionAlignment
        End Get
        Set(ByVal value As Align)
            m_PositionAlignment = value
        End Set
    End Property

    Public Property Offset() As Int16
        Get
            Return m_Offset
        End Get
        Set(ByVal value As Int16)
            m_Offset = value
        End Set
    End Property

    Public Property IndicatorImageBounds() As Rectangle
        Get
            Return m_IndicatorImageBounds
        End Get
        Set(ByVal value As Rectangle)
            m_IndicatorImageBounds = value
        End Set
    End Property

    Public Property Action() As String
        Get
            Return m_Action
        End Get
        Set(ByVal value As String)
            m_Action = value
        End Set
    End Property

    Public Property Off() As String
        Get
            Return m_Off
        End Get
        Set(ByVal value As String)
            m_Off = value
        End Set
    End Property

    Public Property Down() As String
        Get
            Return m_Down
        End Get
        Set(ByVal value As String)
            m_Down = value
        End Set
    End Property

End Class