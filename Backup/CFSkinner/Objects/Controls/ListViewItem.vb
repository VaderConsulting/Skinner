Imports Centrafuse.ControlBase
Imports Centrafuse.Types
Imports Centrafuse.Types.ControlType

Public Class ListViewItem
    Inherits ControlBase

    Private m_Checked As Boolean = False
    Private m_SystemIconFlag As Boolean = False
    Private m_ImageIndex As Int16 = 0
    Private m_IsDirectory As Boolean = False
    Private m_Text As String = ""
    Private m_Value As String = ""

    Public Sub New()
        MyBase.ControlType = ControlType.ListViewItem
    End Sub

    Public Property Checked() As Boolean
        Get
            Return m_Checked
        End Get
        Set(ByVal value As Boolean)
            m_Checked = value
        End Set
    End Property

    Public Property SystemIconFlag() As Boolean
        Get
            Return m_SystemIconFlag
        End Get
        Set(ByVal value As Boolean)
            m_SystemIconFlag = value
        End Set
    End Property

    Public Property ImageIndex() As Int16
        Get
            Return m_ImageIndex
        End Get
        Set(ByVal value As Int16)
            m_ImageIndex = value
        End Set
    End Property

    Public Property IsDirectory() As Boolean
        Get
            Return m_IsDirectory
        End Get
        Set(ByVal value As Boolean)
            m_IsDirectory = value
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

    Public Property Value() As String
        Get
            Return m_Value
        End Get
        Set(ByVal value As String)
            m_Value = value
        End Set
    End Property

End Class