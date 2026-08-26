Imports Centrafuse.ControlBase
Imports Centrafuse.Types
Imports Centrafuse.Types.ControlType

Public Class ListView
    Inherits ControlBase

    Private m_FontClass As FontClass = Nothing
    Private m_RowHeight As Int16 = 0
    Private m_HLColor As Color = System.Drawing.ColorTranslator.FromWin32(&H3399FF)
    Private m_SelFontColorColor As Color = System.Drawing.ColorTranslator.FromWin32(&H66)
    Private m_ArtFontClass As String = ""
    Private m_ArtWidth As Int16 = 0
    Private m_ArtHeight As Int16 = 0
    Private m_ArtSpacer As Int16 = 1

    Public Sub New()
        MyBase.ControlType = ControlType.ListView
    End Sub

    Public Property FontClass() As FontClass
        Get
            Return m_FontClass
        End Get
        Set(ByVal value As FontClass)
            m_FontClass = value
        End Set
    End Property

    Public Property RowHeight() As Int16
        Get
            Return m_RowHeight
        End Get
        Set(ByVal value As Int16)
            m_RowHeight = value
        End Set
    End Property

    Public Property HLColor() As Color
        Get
            Return m_HLColor
        End Get
        Set(ByVal value As Color)
            m_HLColor = value
        End Set
    End Property

    Public Property SelFontColorColor() As Color
        Get
            Return m_SelFontColorColor
        End Get
        Set(ByVal value As Color)
            m_SelFontColorColor = value
        End Set
    End Property

    Public Property ArtFontClass() As String
        Get
            Return m_ArtFontClass
        End Get
        Set(ByVal value As String)
            m_ArtFontClass = value
        End Set
    End Property

    Public Property ArtWidth() As Int16
        Get
            Return m_ArtWidth
        End Get
        Set(ByVal value As Int16)
            m_ArtWidth = value
        End Set
    End Property

    Public Property ArtHeight() As Int16
        Get
            Return m_ArtHeight
        End Get
        Set(ByVal value As Int16)
            m_ArtHeight = value
        End Set
    End Property

    Public Property ArtSpacer() As Int16
        Get
            Return m_ArtSpacer
        End Get
        Set(ByVal value As Int16)
            m_ArtSpacer = value
        End Set
    End Property

End Class