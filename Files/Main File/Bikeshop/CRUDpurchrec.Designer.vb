<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CRUDpurchrec
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CRUDpurchrec))
        Dim StateProperties1 As Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties = New Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties()
        Dim StateProperties2 As Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties = New Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties()
        Dim StateProperties3 As Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties = New Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties()
        Dim StateProperties4 As Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties = New Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties()
        Dim BorderEdges1 As Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges = New Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges()
        Dim StateProperties5 As Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties = New Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties()
        Dim StateProperties6 As Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties = New Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.suppID = New Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox()
        Me.Check = New Bunifu.UI.WinForms.BunifuButton.BunifuButton()
        Me.Dgrid1 = New Bunifu.UI.WinForms.BunifuDataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BunifuDragControl1 = New Bunifu.Framework.UI.BunifuDragControl(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.Dgrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'suppID
        '
        Me.suppID.AcceptsReturn = False
        Me.suppID.AcceptsTab = False
        Me.suppID.AnimationSpeed = 200
        Me.suppID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.suppID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.suppID.BackColor = System.Drawing.Color.Transparent
        Me.suppID.BackgroundImage = CType(resources.GetObject("suppID.BackgroundImage"), System.Drawing.Image)
        Me.suppID.BorderColorActive = System.Drawing.Color.DodgerBlue
        Me.suppID.BorderColorDisabled = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(161, Byte), Integer))
        Me.suppID.BorderColorHover = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.suppID.BorderColorIdle = System.Drawing.Color.Silver
        Me.suppID.BorderRadius = 1
        Me.suppID.BorderThickness = 1
        Me.suppID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.suppID.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.suppID.DefaultFont = New System.Drawing.Font("Segoe UI Semibold", 9.75!)
        Me.suppID.DefaultText = ""
        Me.suppID.FillColor = System.Drawing.Color.White
        Me.suppID.ForeColor = System.Drawing.SystemColors.Desktop
        Me.suppID.HideSelection = True
        Me.suppID.IconLeft = Nothing
        Me.suppID.IconLeftCursor = System.Windows.Forms.Cursors.IBeam
        Me.suppID.IconPadding = 10
        Me.suppID.IconRight = Nothing
        Me.suppID.IconRightCursor = System.Windows.Forms.Cursors.IBeam
        Me.suppID.Lines = New String(-1) {}
        Me.suppID.Location = New System.Drawing.Point(51, 33)
        Me.suppID.MaxLength = 32767
        Me.suppID.MinimumSize = New System.Drawing.Size(100, 35)
        Me.suppID.Modified = False
        Me.suppID.Multiline = False
        Me.suppID.Name = "suppID"
        StateProperties1.BorderColor = System.Drawing.Color.DodgerBlue
        StateProperties1.FillColor = System.Drawing.Color.Empty
        StateProperties1.ForeColor = System.Drawing.Color.Empty
        StateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty
        Me.suppID.OnActiveState = StateProperties1
        StateProperties2.BorderColor = System.Drawing.Color.Empty
        StateProperties2.FillColor = System.Drawing.Color.White
        StateProperties2.ForeColor = System.Drawing.Color.Empty
        StateProperties2.PlaceholderForeColor = System.Drawing.Color.Silver
        Me.suppID.OnDisabledState = StateProperties2
        StateProperties3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(255, Byte), Integer))
        StateProperties3.FillColor = System.Drawing.Color.Empty
        StateProperties3.ForeColor = System.Drawing.Color.Empty
        StateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty
        Me.suppID.OnHoverState = StateProperties3
        StateProperties4.BorderColor = System.Drawing.Color.Silver
        StateProperties4.FillColor = System.Drawing.Color.White
        StateProperties4.ForeColor = System.Drawing.SystemColors.Desktop
        StateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty
        Me.suppID.OnIdleState = StateProperties4
        Me.suppID.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.suppID.PlaceholderForeColor = System.Drawing.Color.Silver
        Me.suppID.PlaceholderText = "ID NUMBER"
        Me.suppID.ReadOnly = False
        Me.suppID.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.suppID.SelectedText = ""
        Me.suppID.SelectionLength = 0
        Me.suppID.SelectionStart = 0
        Me.suppID.ShortcutsEnabled = True
        Me.suppID.Size = New System.Drawing.Size(239, 40)
        Me.suppID.Style = Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox._Style.Bunifu
        Me.suppID.TabIndex = 51
        Me.suppID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.suppID.TextMarginBottom = 0
        Me.suppID.TextMarginLeft = 5
        Me.suppID.TextMarginTop = 0
        Me.suppID.TextPlaceholder = "ID NUMBER"
        Me.suppID.UseSystemPasswordChar = False
        Me.suppID.WordWrap = True
        '
        'Check
        '
        Me.Check.AllowToggling = False
        Me.Check.AnimationSpeed = 200
        Me.Check.AutoGenerateColors = False
        Me.Check.BackColor = System.Drawing.Color.Transparent
        Me.Check.BackColor1 = System.Drawing.Color.DodgerBlue
        Me.Check.BackgroundImage = CType(resources.GetObject("Check.BackgroundImage"), System.Drawing.Image)
        Me.Check.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid
        Me.Check.ButtonText = "Search"
        Me.Check.ButtonTextMarginLeft = 0
        Me.Check.ColorContrastOnClick = 45
        Me.Check.ColorContrastOnHover = 45
        Me.Check.Cursor = System.Windows.Forms.Cursors.Hand
        BorderEdges1.BottomLeft = True
        BorderEdges1.BottomRight = True
        BorderEdges1.TopLeft = True
        BorderEdges1.TopRight = True
        Me.Check.CustomizableEdges = BorderEdges1
        Me.Check.DialogResult = System.Windows.Forms.DialogResult.None
        Me.Check.DisabledBorderColor = System.Drawing.Color.Empty
        Me.Check.DisabledFillColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Check.DisabledForecolor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(168, Byte), Integer))
        Me.Check.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed
        Me.Check.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!)
        Me.Check.ForeColor = System.Drawing.Color.White
        Me.Check.IconLeftCursor = System.Windows.Forms.Cursors.Hand
        Me.Check.IconMarginLeft = 11
        Me.Check.IconPadding = 10
        Me.Check.IconRightCursor = System.Windows.Forms.Cursors.Hand
        Me.Check.IdleBorderColor = System.Drawing.Color.DodgerBlue
        Me.Check.IdleBorderRadius = 3
        Me.Check.IdleBorderThickness = 1
        Me.Check.IdleFillColor = System.Drawing.Color.DodgerBlue
        Me.Check.IdleIconLeftImage = Nothing
        Me.Check.IdleIconRightImage = Nothing
        Me.Check.IndicateFocus = False
        Me.Check.Location = New System.Drawing.Point(296, 33)
        Me.Check.Name = "Check"
        StateProperties5.BorderColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(255, Byte), Integer))
        StateProperties5.BorderRadius = 3
        StateProperties5.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid
        StateProperties5.BorderThickness = 1
        StateProperties5.FillColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(255, Byte), Integer))
        StateProperties5.ForeColor = System.Drawing.Color.White
        StateProperties5.IconLeftImage = Nothing
        StateProperties5.IconRightImage = Nothing
        Me.Check.onHoverState = StateProperties5
        StateProperties6.BorderColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(144, Byte), Integer))
        StateProperties6.BorderRadius = 3
        StateProperties6.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid
        StateProperties6.BorderThickness = 1
        StateProperties6.FillColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(144, Byte), Integer))
        StateProperties6.ForeColor = System.Drawing.Color.White
        StateProperties6.IconLeftImage = Nothing
        StateProperties6.IconRightImage = Nothing
        Me.Check.OnPressedState = StateProperties6
        Me.Check.Size = New System.Drawing.Size(113, 40)
        Me.Check.TabIndex = 50
        Me.Check.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Check.TextMarginLeft = 0
        Me.Check.UseDefaultRadiusAndThickness = True
        '
        'Dgrid1
        '
        Me.Dgrid1.AllowCustomTheming = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.Dgrid1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgrid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Dgrid1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Dgrid1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.Dgrid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI Semibold", 11.75!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgrid1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Dgrid1.ColumnHeadersHeight = 40
        Me.Dgrid1.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Dgrid1.CurrentTheme.AlternatingRowsStyle.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Dgrid1.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black
        Me.Dgrid1.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Dgrid1.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.Dgrid1.CurrentTheme.BackColor = System.Drawing.Color.White
        Me.Dgrid1.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Dgrid1.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue
        Me.Dgrid1.CurrentTheme.HeaderStyle.Font = New System.Drawing.Font("Segoe UI Semibold", 11.75!, System.Drawing.FontStyle.Bold)
        Me.Dgrid1.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.Dgrid1.CurrentTheme.Name = Nothing
        Me.Dgrid1.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White
        Me.Dgrid1.CurrentTheme.RowsStyle.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Dgrid1.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black
        Me.Dgrid1.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Dgrid1.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Dgrid1.DefaultCellStyle = DataGridViewCellStyle3
        Me.Dgrid1.EnableHeadersVisualStyles = False
        Me.Dgrid1.GridColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Dgrid1.HeaderBackColor = System.Drawing.Color.DodgerBlue
        Me.Dgrid1.HeaderBgColor = System.Drawing.Color.Empty
        Me.Dgrid1.HeaderForeColor = System.Drawing.Color.White
        Me.Dgrid1.Location = New System.Drawing.Point(41, 79)
        Me.Dgrid1.Name = "Dgrid1"
        Me.Dgrid1.RowHeadersVisible = False
        Me.Dgrid1.RowHeadersWidth = 51
        Me.Dgrid1.RowTemplate.Height = 40
        Me.Dgrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgrid1.Size = New System.Drawing.Size(1154, 359)
        Me.Dgrid1.TabIndex = 49
        Me.Dgrid1.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(44, 450)
        Me.Panel1.TabIndex = 48
        '
        'BunifuDragControl1
        '
        Me.BunifuDragControl1.Fixed = True
        Me.BunifuDragControl1.Horizontal = True
        Me.BunifuDragControl1.TargetControl = Nothing
        Me.BunifuDragControl1.Vertical = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Leelawadee", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(46, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 29)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "Cart ID"
        '
        'CRUDpurchrec
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1207, 450)
        Me.Controls.Add(Me.suppID)
        Me.Controls.Add(Me.Check)
        Me.Controls.Add(Me.Dgrid1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "CRUDpurchrec"
        Me.Text = "CRUDpurchrec"
        CType(Me.Dgrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents suppID As Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox
    Friend WithEvents Check As Bunifu.UI.WinForms.BunifuButton.BunifuButton
    Friend WithEvents Dgrid1 As Bunifu.UI.WinForms.BunifuDataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BunifuDragControl1 As Bunifu.Framework.UI.BunifuDragControl
    Friend WithEvents Label1 As Label
End Class
