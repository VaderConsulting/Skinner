Imports Centrafuse.ControlBase
Imports Centrafuse.Types
Imports Centrafuse.Types.ControlType

Public Class Slider
    Inherits ControlBase

    Private m_Effect As String = ""
    Private m_Max As Int16 = 100
    Private m_Min As Int16 = 0
    Private m_TabIndex As Int16 = 0
    Private m_Orientation As Orientation = Orientation.Horizontal
    Private m_SliderAlignment As Align = Align.Left
    Private m_SliderBackground As String = ""
    Private m_SliderForeground As String = ""
    Private m_SliderOff As String = ""
    Private m_SliderDown As String = ""
    Private m_Enabled As Boolean = False

    Public Sub New()
        MyBase.ControlType = ControlType.Slider
    End Sub

    Public Property Effect() As String
        Get
            Return m_Effect
        End Get
        Set(ByVal value As String)
            m_Effect = value
        End Set
    End Property

    Public Property Max() As Int16
        Get
            Return m_Max
        End Get
        Set(ByVal value As Int16)
            m_Max = value
        End Set
    End Property

    Public Property Min() As Int16
        Get
            Return m_Min
        End Get
        Set(ByVal value As Int16)
            m_Min = value
        End Set
    End Property

    Public Property TabIndex() As Int16
        Get
            Return m_TabIndex
        End Get
        Set(ByVal value As Int16)
            m_TabIndex = value
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

    Public Property SliderAlignment() As Align
        Get
            Return m_SliderAlignment
        End Get
        Set(ByVal value As Align)
            m_SliderAlignment = value
        End Set
    End Property

    Public Property SliderBackground() As String
        Get
            Return m_SliderBackground
        End Get
        Set(ByVal value As String)
            m_SliderBackground = value
        End Set
    End Property

    Public Property SliderForeground() As String
        Get
            Return m_SliderForeground
        End Get
        Set(ByVal value As String)
            m_SliderForeground = value
        End Set
    End Property

    Public Property SliderOff() As String
        Get
            Return m_SliderOff
        End Get
        Set(ByVal value As String)
            m_SliderOff = value
        End Set
    End Property

    Public Property SliderDown() As String
        Get
            Return m_SliderDown
        End Get
        Set(ByVal value As String)
            m_SliderDown = value
        End Set
    End Property

    Public Property Enabled() As Boolean
        Get
            Return m_Enabled
        End Get
        Set(ByVal value As Boolean)
            m_Enabled = value
        End Set
    End Property

End Class