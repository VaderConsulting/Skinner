Imports Centrafuse.ControlBase
Imports Centrafuse.Types
Imports Centrafuse.Types.ControlType

Public Class Label
    Inherits ControlBase

    Private m_FontClass As FontClass = Nothing
    Private m_FontStyle As String = ""
    Private m_Action As String = ""
    Private m_Text As String = ""
    Private m_AutoLoad As Boolean = False

    Public Sub New()
        MyBase.ControlType = ControlType.Label
    End Sub

    Public Property FontClass() As FontClass
        Get
            Return m_FontClass
        End Get
        Set(ByVal value As FontClass)
            m_FontClass = value
        End Set
    End Property

    Public Property FontStyle() As String
        Get
            Return m_FontStyle
        End Get
        Set(ByVal value As String)
            m_FontStyle = value
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

    Public Property Text() As String
        Get
            Return m_Text
        End Get
        Set(ByVal value As String)
            m_Text = value
        End Set
    End Property

    Public Property AutoLoad() As Boolean
        Get
            Return m_AutoLoad
        End Get
        Set(ByVal value As Boolean)
            m_AutoLoad = value
        End Set
    End Property

End Class