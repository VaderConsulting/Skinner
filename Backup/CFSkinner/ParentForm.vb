Imports System.Windows.Forms
Imports System.Xml
Imports System.Xml.XPath

Public Class ParentForm

    Private m_ChildFormNumber As Integer
    Private m_SkinFile As New Configuration.ConfigXmlDocument
    Private m_TabPage As TabPage

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
        Dim Skinfilepath As String = "C:\Program Files (x86)\Centrafuse\Centrafuse Auto\Skins\Zed\skin.xml"
        Dim XMLNode As XPathNavigator = GetXMLNavigator(Skinfilepath)
        Dim i As Integer = 0

        ' Get Sections
        If Not XMLNode Is Nothing Then
            If XMLNode.HasChildren Then
                XMLNode.MoveToFirstChild()
                Do
                    If XMLNode.Name Like "SECTIONS" Then
                        XMLNode.MoveToFirstChild()
                        Do
                            XMLNode.MoveToAttribute("id", Nothing)
                            Dim SectionName As String = XMLNode.GetAttribute("id", "")
                            
                            Select Case SectionName
                                Case "ListSlideLeft"
                                Case "ListSlideRight"
                                Case "MainFromMediaManager"
                                Case "MainFromMedia"
                                Case "MainSlide1"
                                Case "MainSlide2"
                                Case "Plugins"
                                Case "Dvd"
                                Case "Video"

                                Case Else
                                    TabControl.TabPages.Add(SectionName)

                                    ' Get a reference to this page
                                    m_TabPage = TabControl.TabPages.Item(i)
                                    i += 1
                                    If XMLNode.HasChildren Then
                                        'Debug.Print("Section: " & SectionName)
                                        GetControls(XMLNode.Clone)
                                    End If

                            End Select

                        Loop Until XMLNode.MoveToNext() = False
                    End If
                Loop Until XMLNode.MoveToNext() = False
            End If
        End If



        'Dim NewTextbox As New TextBox

        'NewTextbox.Bounds = New Rectangle(0, 0, 50, 100)

        'pnlMain.Controls.Add(NewTextbox)
    End Sub

    Private Sub GetControls(ByVal ControlNode As XPathNavigator)
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
            GetControl(ControlNode.Clone)
            MoveResult = ControlNode.MoveToNext()
        Loop Until MoveResult = False
    End Sub

    Private Sub GetControl(ByVal Node As XPathNavigator)
        Dim i As Int32 = 0
        Dim MoveResult As Boolean = False

        Do
            i += 1
            'Debug.Print("This is Control number " & i)
            GetAttributes(Node.Clone)
            MoveResult = Node.MoveToNext
        Loop Until MoveResult = False
    End Sub

    Private Sub GetAttributes(ByVal Node As XPathNavigator)
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
                                Text = "Label"
                            Case "button", "dynbutton"
                                MyNewControl = New Windows.Forms.Button
                                Text = "Button"
                            Case "panel"
                                MyNewControl = New Windows.Forms.Panel
                                MyNewControl.borderStyle = Windows.Forms.BorderStyle.FixedSingle
                                Text = "Panel"
                            Case "picturebox"
                                MyNewControl = New Windows.Forms.PictureBox
                                MyNewControl.borderStyle = Windows.Forms.BorderStyle.FixedSingle
                                Text = "PictureBox"
                            Case Else
                                MyNewControl = New Windows.Forms.Label
                                MyNewControl.borderStyle = Windows.Forms.BorderStyle.FixedSingle
                                Text = AttributeValue
                                'Debug.Print("Control type: " & AttributeValue)
                        End Select
                    Case "id"
                        ControlName = Node.Value
                    Case "bounds"
                        'Debug.Print("Bounds: " & Node.Value)
                        Dim Bounds As String() = Node.Value.Split(";")
                        Left = CInt(Bounds(0))
                        Top = CInt(Bounds(1))
                        Width = CInt(Bounds(2))
                        Height = CInt(Bounds(3))

                    Case "fontclass"
                    Case "fontstyle"
                    Case "effect"
                    Case "tabindex"
                    Case "action"
                    Case "off"
                    Case "text"
                        Text = Node.Value
                    Case "holdtime"
                    Case "holdaction"
                    Case "textenable"
                    Case "enabled"
                        Enabled = CBool(Node.Value)
                    Case "down"
                    Case Else
                        'Debug.Print("Attribute " & AttributeType & " is unhandled")
                End Select

                MoveResult = Node.MoveToNextAttribute
            Loop Until MoveResult = False

            'Debug.Print("Attributes: " & i.ToString)

            Try

                MyNewControl.Name = ControlName
                MyNewControl.Left = Left
                MyNewControl.Top = Top
                MyNewControl.Width = Width
                MyNewControl.Height = Height
                MyNewControl.Text = Text
                MyNewControl.Enabled = Enabled
                m_TabPage.Controls.Add(MyNewControl)
            Catch ex As Exception
            End Try
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
            Debug.Print("")
        End Try
        Return ConfigNode
    End Function

End Class
