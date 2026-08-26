Imports System.Windows.Forms
Imports System.Xml
Imports System.Xml.XPath

Public Class ParentForm

    Private m_ChildFormNumber As Integer
    Private m_SkinFile As New Configuration.ConfigXmlDocument
    Private m_TabPage As TabPage
    Private m_Attributes As New Collections.Specialized.StringCollection
    Private m_Images As New Collections.Specialized.OrderedDictionary
    Private m_Icons As New Collections.Specialized.OrderedDictionary
    Private m_ButtonImages As New Collections.Specialized.OrderedDictionary
    Private m_SkinName As String = "Zed"
    Private m_ProgramFilesDirectory As String = My.Computer.FileSystem.SpecialDirectories.ProgramFiles & " (x86)"


    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles NewToolStripMenuItem.Click, NewToolStripButton.Click, NewWindowToolStripMenuItem.Click
        ' Create a new instance of the child form.
        Dim ChildForm As New MenuPage
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        'ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles OpenToolStripMenuItem.Click, OpenToolStripButton.Click
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

#Region " Menu items "

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub

    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CutToolStripMenuItem.Click
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CopyToolStripMenuItem.Click
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PasteToolStripMenuItem.Click
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolBarToolStripMenuItem.Click
        Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

#End Region

    Private Sub ParentForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Skinfilepath As String = ""

        Skinfilepath = m_ProgramFilesDirectory & "\Centrafuse\Centrafuse Auto\Skins\" & m_SkinName & "\skin.xml"
        'Skinfilepath = m_ProgramFilesDirectory & " (x86)\Centrafuse\Centrafuse Auto\Skins\" & m_SkinName & "\skin.xml"

        Dim XMLNode As XPathNavigator = GetXMLNavigator(Skinfilepath)


        ' Get Sections
        If Not XMLNode Is Nothing Then
            If XMLNode.HasChildren Then
                XMLNode.MoveToFirstChild()
                Do
                    If XMLNode.Name Like "IMAGES" Then
                        GetImages(XMLNode.Clone)
                    End If
                    If XMLNode.Name Like "ICONS" Then
                        GetImages(XMLNode.Clone)
                    End If
                    If XMLNode.Name Like "BUTTONIMAGES" Then
                        GetImages(XMLNode.Clone)
                    End If
                    If XMLNode.Name Like "SECTIONS" Then
                        GetSections(XMLNode.Clone)
                    End If
                Loop Until XMLNode.MoveToNext() = False
            End If
        End If

        'For Each item In m_Attributes
        '    Debug.Print(item.ToString)
        'Next
    End Sub

    Private Sub GetImages(ByVal StartingNode As XPathNavigator)
        StartingNode.MoveToFirstChild()

        Do
            Dim Name As String = StartingNode.GetAttribute("id", "")
            Dim Path As String = StartingNode.GetAttribute("path", "")

            m_Images.Add(Name, Path)
        Loop Until StartingNode.MoveToNext() = False

    End Sub

    Private Sub GetIcons(ByVal StartingNode As XPathNavigator)
        StartingNode.MoveToFirstChild()

        Do
            Dim Name As String = StartingNode.GetAttribute("id", "")
            Dim Path As String = StartingNode.GetAttribute("path", "")

            m_Icons.Add(Name, Path)
        Loop Until StartingNode.MoveToNext() = False
    End Sub

    Private Sub GetButtonImages(ByVal StartingNode As XPathNavigator)
        StartingNode.MoveToFirstChild()

        Do
            Dim Name As String = StartingNode.GetAttribute("id", "")
            Dim Path As String = StartingNode.GetAttribute("path", "")

            m_ButtonImages.Add(Name, Path)
        Loop Until StartingNode.MoveToNext() = False
    End Sub

    Private Sub GetSections(ByVal StartingNode As XPathNavigator)
        'Dim i As Integer = 0
        Dim OffImage As String = ""
        Dim DownImage As String = ""
        Dim Left As Int32 = 0
        Dim Top As Int32 = 0
        Dim Width As Int32 = 0
        Dim Height As Int32 = 0

        StartingNode.MoveToFirstChild()
        Do
            StartingNode.MoveToAttribute("id", Nothing)
            Dim SectionName As String = StartingNode.GetAttribute("id", "")

            Select Case SectionName
                Case "ListSlideLeft"
                Case "ListSlideRight"
                Case "MainFromMediaManager"
                Case "MainFromMedia"
                Case "MainSlide1"
                Case "MainSlide2"
                Case "Plugins"
                    'Case "Dvd"
                Case "Video"
                Case Else
                    Try
                        OffImage = StartingNode.GetAttribute("off", "")
                        DownImage = StartingNode.GetAttribute("down", "")
                    Catch
                    End Try

                    Try
                        Dim Bounds As String() = StartingNode.GetAttribute("bounds", "").Split(";")
                        Left = CInt(Bounds(0))
                        Top = CInt(Bounds(1))
                        Width = CInt(Bounds(2))
                        Height = CInt(Bounds(3))
                    Catch ex As Exception

                    End Try
                    AddPage(StartingNode, SectionName)

                    If OffImage.Length > 0 Then
                        Dim BackgroundImage As New Windows.Forms.PictureBox
                        Dim BackgroundImageFilename As String = m_ProgramFilesDirectory & "\Centrafuse\Centrafuse Auto\Skins\" & m_SkinName & "\" & m_Images(OffImage).ToString.Replace("/", "\")

                        BackgroundImage.Image = Bitmap.FromFile(BackgroundImageFilename)
                        BackgroundImage.Left = Left
                        BackgroundImage.Top = Top
                        BackgroundImage.Width = Width
                        BackgroundImage.Height = Height
                        m_TabPage.Controls.Add(BackgroundImage)
                    End If
            End Select

        Loop Until StartingNode.MoveToNext() = False

        ' Lastly, add the SplashOff page
        AddPage(StartingNode, "SplashOff")
    End Sub

    Private Sub AddPage(ByVal StartingNode As XPathNavigator, ByVal PageName As String)
        Static i As Integer = 0

        TabControl.TabPages.Add(PageName)

        ' Get a reference to this page
        m_TabPage = TabControl.TabPages.Item(i)
        i += 1
        If StartingNode.HasChildren Then
            Debug.Print("Page: " & PageName)
            GetPageControls(StartingNode.Clone)
            Debug.Print("----------------------------------------------------------------------")
        End If
    End Sub

    Private Sub GetPageControls(ByVal ControlNode As XPathNavigator)
        Dim i As Int32 = 0
        Dim MoveResult As Boolean = False

        'Debug.Print(ControlNode.Name)
        ControlNode.MoveToFirstChild() ' Will give us CONTROLS
        'Debug.Print(ControlNode.Name)
        Do
            ControlNode.MoveToFirstChild() ' Will give us CONTROL
            'Debug.Print("Control Node name: " & ControlNode.Name)


            i += 1
            'Debug.Print("Controls " & i)
            GetSingleControl(ControlNode.Clone)
            MoveResult = ControlNode.MoveToNext()
        Loop Until MoveResult = False
    End Sub

    Private Sub GetSingleControl(ByVal Node As XPathNavigator)
        Dim i As Int32 = 0
        Dim MoveResult As Boolean = False

        Do
            i += 1
            'Debug.Print("This is Control number " & i)
            GetControlAttributes(Node.Clone)
            MoveResult = Node.MoveToNext
        Loop Until MoveResult = False
    End Sub

    Private Sub GetControlAttributes(ByVal Node As XPathNavigator)
        Dim MoveResult As Boolean = False
        Dim AttributeValue As String = ""
        Dim i As Int32 = 0
        Dim MyNewControl As Object = Nothing
        Dim ControlName As String = ""
        Dim Left As Integer = 0
        Dim Top As Integer = 0
        Dim Width As Integer = 0
        Dim Height As Integer = 0
        Dim Enabled As Boolean = True
        Dim Text As String = ""
        Dim BackgroundImageFilename As String = ""
        Dim ImageFilename As String = ""
        Dim DownImageFilename As String = ""

        MoveResult = Node.MoveToFirstAttribute()
        If Node.NodeType <> XPathNodeType.Comment Then
            Do
                i += 1
                Dim AttributeType As String = Node.Name

                Select Case AttributeType
                    Case "type"
                        AttributeValue = Node.Value

                        Select Case AttributeValue.ToLower
                            Case "label"
                                MyNewControl = New Windows.Forms.Label
                                MyNewControl.borderStyle = Windows.Forms.BorderStyle.FixedSingle
                                Text = AttributeValue
                            Case "button"
                                MyNewControl = New Windows.Forms.Button
                                Text = AttributeValue
                            Case "dynbutton"
                                MyNewControl = New Windows.Forms.Button
                                Text = AttributeValue
                            Case "panel"
                                MyNewControl = New Windows.Forms.Panel
                                MyNewControl.borderStyle = Windows.Forms.BorderStyle.FixedSingle
                                Text = AttributeValue
                            Case "picturebox", "systemicon"
                                MyNewControl = New Windows.Forms.PictureBox
                                MyNewControl.borderStyle = Windows.Forms.BorderStyle.FixedSingle
                                Text = AttributeValue
                            Case Else
                                MyNewControl = New Windows.Forms.Label
                                MyNewControl.borderStyle = Windows.Forms.BorderStyle.FixedSingle
                                Text = AttributeValue
                                'Debug.Print("------------> Control type: " & AttributeValue)
                        End Select
                    Case "id"
                        ControlName = Node.Value
                        Debug.Print("  Control Name: " & ControlName)
                    Case "bounds"
                        Dim Bounds As String() = Node.Value.Split(";")
                        Left = CInt(Bounds(0))
                        Top = CInt(Bounds(1))
                        Width = CInt(Bounds(2))
                        Height = CInt(Bounds(3))
                        'Debug.Print("  Bounds set")
                    Case "fontclass"
                    Case "fontstyle"
                    Case "effect"
                    Case "tabindex"
                    Case "action"
                    Case "text"
                        Text = Node.Value
                        Debug.Print("  Text:" & Text)
                    Case "holdtime"
                    Case "holdaction"
                    Case "textenable"
                    Case "enabled"
                        Enabled = CBool(Node.Value)
                        'Case "down"
                        '    If Not Node.Value.ToLower.StartsWith("centrafuse.") Then
                        '        If Node.Value.EndsWith(".png") Then
                        '            Image = m_ProgramFilesDirectory & "\Centrafuse\Centrafuse Auto\Skins\" & m_SkinName & "\" & Node.Value
                        '        Else
                        '            Image = m_ProgramFilesDirectory & "\Centrafuse\Centrafuse Auto\Skins\" & m_SkinName & "\" & m_Images(Node.Value).ToString.Replace("/", "\")
                        '        End If
                        '    End If
                        'Debug.Print("  Enabled:" & Enabled.ToString)
                    Case "backgroundimage"
                        If Not Node.Value.ToLower.StartsWith("centrafuse.") Then
                            BackgroundImageFilename = m_ProgramFilesDirectory & "\Centrafuse\Centrafuse Auto\Skins\" & m_SkinName & "\" & Node.Value & ".png"
                            'Debug.Print("  BackgroundImage:" & BackgroundImageFilename)
                        Else
                            'Debug.Print("  BackgroundImage:<BLANK>")
                        End If
                    Case "iconimage"
                        If Not Node.Value.ToLower.StartsWith("centrafuse.") Then
                            If Node.Value.EndsWith(".png") Then
                                ImageFilename = m_ProgramFilesDirectory & "\Centrafuse\Centrafuse Auto\Skins\" & m_SkinName & "\" & Node.Value
                                'Debug.Print("  IconImage:" & ImageFilename)
                            Else
                                ImageFilename = m_ProgramFilesDirectory & "\Centrafuse\Centrafuse Auto\Skins\" & m_SkinName & "\" & m_Images(Node.Value).ToString.Replace("/", "\")
                                'Debug.Print("  IconImage:" & ImageFilename)
                            End If
                        Else
                            Debug.Print("  IconImage:<BLANK>")
                            'Debug.Print("")
                        End If
                    Case "off"
                        If Not Node.Value.ToLower.StartsWith("centrafuse.") Then
                            If Node.Value.EndsWith(".png") Then
                                ImageFilename = m_ProgramFilesDirectory & "\Centrafuse\Centrafuse Auto\Skins\" & m_SkinName & "\" & Node.Value
                                'Debug.Print("  Off Image:" & ImageFilename)
                            Else
                                ImageFilename = m_ProgramFilesDirectory & "\Centrafuse\Centrafuse Auto\Skins\" & m_SkinName & "\" & m_Images(Node.Value).ToString.Replace("/", "\")
                                'Debug.Print("  Off Image:" & ImageFilename)
                            End If
                        Else
                            Debug.Print("  Off Image:<BLANK>")
                            'Debug.Print("")
                        End If
                    Case "image"
                        If Not Node.Value.ToLower.StartsWith("centrafuse.") Then
                            If Node.Value.EndsWith(".png") Then
                                ImageFilename = m_ProgramFilesDirectory & "\Centrafuse\Centrafuse Auto\Skins\" & m_SkinName & "\" & Node.Value
                                'Debug.Print("  Image:" & ImageFilename)
                            Else
                                ImageFilename = m_ProgramFilesDirectory & "\Centrafuse\Centrafuse Auto\Skins\" & m_SkinName & "\" & m_Images(Node.Value).ToString.Replace("/", "\")
                                'Debug.Print("  Image:" & ImageFilename)
                            End If
                        Else
                            Debug.Print("")
                        End If
                    Case Else
                        'Debug.Print("***** Attribute " & AttributeType & " is unhandled")
                        If Not m_Attributes.Contains(AttributeType) Then
                            m_Attributes.Add(AttributeType)
                            'Debug.Print("  Added to attribute collection:" & AttributeType)
                        End If
                End Select

                MoveResult = Node.MoveToNextAttribute
            Loop Until MoveResult = False

            'Debug.Print("Attributes: " & i.ToString)

            If Not MyNewControl Is Nothing Then
                Try

                    MyNewControl.Name = ControlName
                    MyNewControl.Left = Left
                    MyNewControl.Top = Top
                    MyNewControl.Width = Width
                    MyNewControl.Height = Height
                    MyNewControl.Enabled = Enabled
                    Try
                        If BackgroundImageFilename <> "" Then
                            MyNewControl.BackgroundImage = Bitmap.FromFile(BackgroundImageFilename)
                        End If
                    Catch
                        Debug.Print("Bad BackgroundImage: " & BackgroundImageFilename)
                    End Try
                    Try
                        If ImageFilename <> "" Then
                            MyNewControl.Image = Bitmap.FromFile(ImageFilename)
                        End If
                    Catch
                        Debug.Print("Bad Image: " & ImageFilename)
                    End Try
                    Try
                        If DownImageFilename <> "" Then
                            MyNewControl.Image = Bitmap.FromFile(DownImageFilename)
                        End If
                    Catch
                        Debug.Print("Bad Image: " & ImageFilename)
                    End Try

                    If ImageFilename = "" And BackgroundImageFilename = "" Then
                        MyNewControl.Text = ControlName 'Text
                    End If

                    m_TabPage.Controls.Add(MyNewControl)
                    'Debug.Print("  Added " & TypeName(MyNewControl) & " control: " & ControlName)
                    Debug.Print("  ***************************************************")
                Catch ex As Exception
                    Debug.Print(ex.Message)
                End Try
            Else
                'Debug.Print("No control!!!!!!!!!!")
            End If
        End If
    End Sub

    Private Function GetXMLNavigator(ByVal Filename As String) As XPathNavigator
        Dim ConfigNode As XPathNavigator = Nothing

        Try
            If IO.File.Exists(Filename) Then
                m_SkinFile.Load(Filename)

                Dim Nav As XPathNavigator = m_SkinFile.CreateNavigator()
                ConfigNode = Nav.SelectSingleNode("/SKIN")

                Nav = Nothing
            End If
        Catch ex As Exception
            Debug.Print(ex.Message)
            'Debug.Print("")
        End Try
        Return ConfigNode
    End Function

End Class
