Imports Centrafuse.ControlBase
Imports Centrafuse.Types
Imports Centrafuse.Types.ControlType

Public Class Panel
    Inherits ControlBase

    Private m_FullBounds As Rectangle = Nothing
    Private m_SecBounds As Rectangle = Nothing
    Private m_Enabled As Boolean = True

    Public Sub New()
        MyBase.ControlType = ControlType.Panel
    End Sub

    Public Property FullBounds() As Rectangle
        Get
            Return m_FullBounds
        End Get
        Set(ByVal value As Rectangle)
            m_FullBounds = value
        End Set
    End Property

    Public Property SecBounds() As Rectangle
        Get
            Return m_SecBounds
        End Get
        Set(ByVal value As Rectangle)
            m_SecBounds = value
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