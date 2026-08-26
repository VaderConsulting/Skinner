Imports Centrafuse.ControlBase
Imports Centrafuse.Types
Imports Centrafuse.Types.ControlType

Public Class SystemIcon
    Inherits ControlBase

    Private m_IconImage As String = ""
    Private m_AutoLoad As Boolean = False

    Public Sub New()
        MyBase.ControlType = ControlType.SystemIcon
    End Sub

    Public Property IconImage() As String
        Get
            Return m_IconImage
        End Get
        Set(ByVal value As String)
            m_IconImage = value
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