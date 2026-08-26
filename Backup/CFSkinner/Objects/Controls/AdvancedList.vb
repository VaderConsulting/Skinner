Imports Centrafuse.ControlBase
Imports Centrafuse.Types
Imports Centrafuse.Types.ControlType

Public Class AdvancedList
    Inherits ControlBase

    Private m_TemplateFile As String = ""
    Private m_TemplateFileMediaManagerAlbumFile As String = ""
    Private m_TemplateFileMediaManagerSongFile As String = ""

    Public Sub New()
        MyBase.ControlType = ControlType.AdvancedList
    End Sub

    Public Property TemplateFile() As String
        Get
            Return m_TemplateFile
        End Get
        Set(ByVal value As String)
            m_TemplateFile = value
        End Set
    End Property

    Public Property TemplateFileMediaManagerAlbumFile() As String
        Get
            Return m_TemplateFileMediaManagerAlbumFile
        End Get
        Set(ByVal value As String)
            m_TemplateFileMediaManagerAlbumFile = value
        End Set
    End Property

    Public Property TemplateFileMediaManagerSongFile() As String
        Get
            Return m_TemplateFileMediaManagerSongFile
        End Get
        Set(ByVal value As String)
            m_TemplateFileMediaManagerSongFile = value
        End Set
    End Property

End Class
