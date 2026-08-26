Imports Centrafuse.ControlBase
Imports Centrafuse.Types
Imports Centrafuse.Types.ControlType

Public Class DynamicButton
    Inherits ControlBase

    Private m_Action As String = ""
    Private m_Effect As String = ""
    Private m_TabIndex As Int16 = 0
    Private m_Off As String = ""
    Private m_Down As String = ""
    Private m_FontClass As FontClass = Nothing
    Private m_Enabled As Boolean = True

    Public Sub New()
        MyBase.ControlType = ControlType.DynamicButton
    End Sub

    Public Property Action() As String
        Get
            Return m_Action
        End Get
        Set(ByVal value As String)
            m_Action = value
        End Set
    End Property

    Public Property Effect() As String
        Get
            Return m_Effect
        End Get
        Set(ByVal value As String)
            m_Effect = value
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

    Public Property FontClass() As FontClass
        Get
            Return m_FontClass
        End Get
        Set(ByVal value As FontClass)
            m_FontClass = value
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