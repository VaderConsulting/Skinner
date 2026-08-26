Public Class Section
    Inherits CFObject

    Private m_Icon As String = ""
    Private m_Bounds As Rectangle = Nothing
    Private m_Effect As String = ""
    Private m_FullBounds As Rectangle = Nothing
    Private m_SecBounds As Rectangle = Nothing
    Private m_Off As String = ""
    Private m_Down As String = ""
    Private m_Controls As New Collections.Generic.List(Of Centrafuse.ControlBase)
    Private m_ShowMainControls As New Collections.Generic.List(Of Centrafuse.ControlBase)
    Private m_HideMainControls As New Collections.Generic.List(Of Centrafuse.ControlBase)

    Public Sub New(ByVal ID As String)
        MyBase.ID = ID
    End Sub

    Public Property Icon() As String
        Get
            Return m_Icon
        End Get
        Set(ByVal value As String)
            m_Icon = value
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

    Public Property Effect() As String
        Get
            Return m_Effect
        End Get
        Set(ByVal value As String)
            m_Effect = value
        End Set
    End Property

    Public Property FullBounds() As Rectangle
        Get
            Return m_FullBounds
        End Get
        Set(ByVal value As Rectangle)
            m_FullBounds = value
        End Set
    End Property

    Public Property FSecBounds() As Rectangle
        Get
            Return m_SecBounds
        End Get
        Set(ByVal value As Rectangle)
            m_SecBounds = value
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

    Public Property Controls() As Collections.Generic.List(Of Centrafuse.ControlBase)
        Get
            Return m_Controls
        End Get
        Set(ByVal value As Collections.Generic.List(Of Centrafuse.ControlBase))
            m_Controls = value
        End Set
    End Property

    Public Property ShowMainControls() As Collections.Generic.List(Of Centrafuse.ControlBase)
        Get
            Return m_ShowMainControls
        End Get
        Set(ByVal value As Collections.Generic.List(Of Centrafuse.ControlBase))
            m_ShowMainControls = value
        End Set
    End Property

    Public Property HideMainControls() As Collections.Generic.List(Of Centrafuse.ControlBase)
        Get
            Return m_HideMainControls
        End Get
        Set(ByVal value As Collections.Generic.List(Of Centrafuse.ControlBase))
            m_HideMainControls = value
        End Set
    End Property

End Class
