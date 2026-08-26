Public Class Dialog
    Inherits CFObject

    Private m_Bounds As Rectangle = Nothing
    Private m_Effect As String = ""
    Private m_Off As String = ""
    Private m_Down As String = ""
    Private m_Disabled As String = ""
    Private m_Controls As New Collections.Generic.List(Of Centrafuse.ControlBase)

    Public Sub New(ByVal ID As String)
        MyBase.ID = ID
    End Sub

    Public Property Bounds() As Rectangle
        Get
            Return m_Bounds
        End Get
        Set(ByVal value As Rectangle)
            m_Bounds = value
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

    Public Property Disabled() As String
        Get
            Return m_Disabled
        End Get
        Set(ByVal value As String)
            m_Disabled = value
        End Set
    End Property

    Public Property Controls() As Collections.Generic.List(Of Centrafuse.ControlBase)
        Get
            Return m_Controls
        End Get
        Set(ByVal value As Collections.Generic.List(Of Centrafuse.ControlBase))
            m_Controls = value
        End Set
    End Property

End Class
