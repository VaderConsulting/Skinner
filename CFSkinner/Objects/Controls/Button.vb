Imports Centrafuse.ControlBase
Imports Centrafuse.Types
Imports Centrafuse.Types.ControlType

Public Class Button
    Inherits ControlBase

    Private m_HoldTime As Int16 = 2
    Private m_HoldAction As String = ""
    Private m_Effect As String = ""
    Private m_FontClass As FontClass = Nothing
    Private m_TextEnable As Boolean = True
    Private m_Text As String = ""
    Private m_TabIndex As Int16 = 0
    Private m_Enabled As Boolean = True

    Public Sub New()
        MyBase.ControlType = ControlType.Button
    End Sub

    Public Property HoldTime() As Int16
        Get
            Return m_HoldTime
        End Get
        Set(ByVal value As Int16)
            m_HoldTime = value
        End Set
    End Property

    Public Property HoldAction() As String
        Get
            Return m_HoldAction
        End Get
        Set(ByVal value As String)
            m_HoldAction = value
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

    Public Property FontClass() As FontClass
        Get
            Return m_FontClass
        End Get
        Set(ByVal value As FontClass)
            m_FontClass = value
        End Set
    End Property

    Public Property TextEnable() As Boolean
        Get
            Return m_TextEnable
        End Get
        Set(ByVal value As Boolean)
            m_TextEnable = value
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

    Public Property TabIndex() As Int16
        Get
            Return m_TabIndex
        End Get
        Set(ByVal value As Int16)
            m_TabIndex = value
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
