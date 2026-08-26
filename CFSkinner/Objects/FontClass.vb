Imports Centrafuse.Types
Imports System.Windows

Public Class FontClass
    Inherits CFObject

    Private m_Font As String = ""
    Private m_Comment As String = ""
    Private m_Case As FontCase = FontCase.None
    Private m_Color As Color = Color.White
    Private m_Color2 As Color = System.Drawing.ColorTranslator.FromWin32(&H333333)
    Private m_Size As Int16 = 10
    Private m_Align As Align = Align.Left
    Private m_Wrap As TextWrap = TextWrap.False
    Private m_XOffset As Int16 = 0
    Private m_YOffset As Int16 = 0

    Public Sub New(ByVal ID As String)
        MyBase.ID = ID
    End Sub

    Public Property Font() As String
        Get
            Return m_Font
        End Get
        Set(ByVal value As String)
            m_Font = value
        End Set
    End Property

    Public Property Comment() As String
        Get
            Return m_Comment
        End Get
        Set(ByVal value As String)
            m_Comment = value
        End Set
    End Property

    Public Property [Case]() As FontCase
        Get
            Return m_Case
        End Get
        Set(ByVal value As FontCase)
            m_Case = value
        End Set
    End Property

    Public Property Color() As Color
        Get
            Return m_Color
        End Get
        Set(ByVal value As Color)
            m_Color = value
        End Set
    End Property

    Public Property Color2() As Color
        Get
            Return m_Color2
        End Get
        Set(ByVal value As Color)
            m_Color2 = value
        End Set
    End Property

    Public Property Size() As Int16
        Get
            Return m_Size
        End Get
        Set(ByVal value As Int16)
            m_Size = value
        End Set
    End Property

    Public Property Align() As Align
        Get
            Return m_Align
        End Get
        Set(ByVal value As Align)
            m_Align = value
        End Set
    End Property

    Public Property Wrap() As TextWrap
        Get
            Return m_Wrap
        End Get
        Set(ByVal value As TextWrap)
            m_Wrap = value
        End Set
    End Property

    Public Property XOffset() As Int16
        Get
            Return m_XOffset
        End Get
        Set(ByVal value As Int16)
            m_XOffset = value
        End Set
    End Property

    Public Property YOffset() As Int16
        Get
            Return m_YOffset
        End Get
        Set(ByVal value As Int16)
            m_YOffset = value
        End Set
    End Property

End Class
