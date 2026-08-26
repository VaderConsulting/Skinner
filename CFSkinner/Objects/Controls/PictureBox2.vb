Imports Centrafuse.ControlBase
Imports Centrafuse.Types
Imports Centrafuse.Types.ControlType

Public Class PictureBox2
    Inherits ControlBase

    Private m_IconImage As String = ""
    Private m_Action As String = ""

    Public Sub New()
        MyBase.ControlType = ControlType.PictureBox
    End Sub

    Public Property IconImage() As String
        Get
            Return m_IconImage
        End Get
        Set(ByVal value As String)
            m_IconImage = value
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

End Class