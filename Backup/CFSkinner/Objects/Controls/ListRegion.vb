Imports Centrafuse.ControlBase
Imports Centrafuse.Types
Imports Centrafuse.Types.ControlType

Public Class ListRegion
    Inherits ControlBase

    Private m_Path As String = ""

    Public Sub New()
        MyBase.ControlType = ControlType.ListRegion
    End Sub

    Public Property Path() As String
        Get
            Return m_Path
        End Get
        Set(ByVal value As String)
            m_Path = value
        End Set
    End Property

End Class