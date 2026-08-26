Public Class Skin
    Inherits CFObject

    Private m_Width As Int16 = 848
    Private m_Height As Int16 = 480
    Private m_Comment As String = "Main Skin File"
    Private m_FontClasses As New Collections.Generic.List(Of Centrafuse.FontClass)
    Private m_Images As New Collections.Generic.List(Of Centrafuse.Image)
    Private m_Icons As New Collections.Generic.List(Of Centrafuse.Icon)
    Private m_ButtonImages As New Collections.Generic.List(Of Centrafuse.ButtonImage)
    Private m_Sections As New Collections.Generic.List(Of Centrafuse.Section)
    Private m_Dialogs As New Collections.Generic.List(Of Centrafuse.Dialog)

    Public Sub New(ByVal ID As String)
        MyBase.ID = ID
    End Sub

    ''' <summary>
    ''' Returns the string representation of this Centrafuse.Skin object
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>' TODO: Compose XML file and return</remarks>
    Public Overloads Function ToString() As String
        Dim ReturnValue As String = ""

        ' TODO: Compose XML file and return

        Return ReturnValue
    End Function

    Public Property FontClasses() As Collections.Generic.List(Of Centrafuse.FontClass)
        Get
            Return m_FontClasses
        End Get
        Set(ByVal value As Collections.Generic.List(Of Centrafuse.FontClass))
            m_FontClasses = value
        End Set
    End Property

    Public Property Images() As Collections.Generic.List(Of Centrafuse.Image)
        Get
            Return m_Images
        End Get
        Set(ByVal value As Collections.Generic.List(Of Centrafuse.Image))
            m_Images = value
        End Set
    End Property

    Public Property Icons() As Collections.Generic.List(Of Centrafuse.Icon)
        Get
            Return m_Icons
        End Get
        Set(ByVal value As Collections.Generic.List(Of Centrafuse.Icon))
            m_Icons = value
        End Set
    End Property

    Public Property ButtonImages() As Collections.Generic.List(Of Centrafuse.ButtonImage)
        Get
            Return m_ButtonImages
        End Get
        Set(ByVal value As Collections.Generic.List(Of Centrafuse.ButtonImage))
            m_ButtonImages = value
        End Set
    End Property

    Public Property Sections() As Collections.Generic.List(Of Centrafuse.Section)
        Get
            Return m_Sections
        End Get
        Set(ByVal value As Collections.Generic.List(Of Centrafuse.Section))
            m_Sections = value
        End Set
    End Property

    Public Property Dialogs() As Collections.Generic.List(Of Centrafuse.Dialog)
        Get
            Return m_Dialogs
        End Get
        Set(ByVal value As Collections.Generic.List(Of Centrafuse.Dialog))
            m_Dialogs = value
        End Set
    End Property

End Class
