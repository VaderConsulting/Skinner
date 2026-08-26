Public Class Icon
    Inherits CFObject

    Private m_Path As String = ""

    Public Property Path() As String
        Get
            Return m_Path
        End Get
        Set(ByVal value As String)
            m_Path = value
        End Set
    End Property

    Public Sub New(ByVal ID As String)
        MyBase.ID = ID
    End Sub

End Class
