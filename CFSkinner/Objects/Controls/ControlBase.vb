Imports Centrafuse.Types

Public Class ControlBase
    Inherits CFObject

    Private m_ControlType As ControlType
    Private m_Bounds As Rectangle

    Public Property ControlType() As ControlType
        Get
            Return m_ControlType
        End Get
        Set(ByVal value As ControlType)
            m_ControlType = value
        End Set
    End Property

    Public Property Bounds() As Rectangle
        Get
            Return m_Bounds
        End Get
        Set(ByVal value As Rectangle)
            m_Bounds = value
        End Set
    End Property

End Class