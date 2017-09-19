<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.grpExtension = New System.Windows.Forms.GroupBox()
        Me.txtExtension = New System.Windows.Forms.TextBox()
        Me.chbDirRecur = New System.Windows.Forms.CheckBox()
        Me.chbGlass = New System.Windows.Forms.CheckBox()
        Me.grpTextFormat = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtKeyConf = New System.Windows.Forms.TextBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.grpExtension.SuspendLayout()
        Me.grpTextFormat.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(470, 231)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.grpExtension)
        Me.TabPage2.Controls.Add(Me.chbDirRecur)
        Me.TabPage2.Controls.Add(Me.chbGlass)
        Me.TabPage2.Controls.Add(Me.grpTextFormat)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(462, 205)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "General"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'grpExtension
        '
        Me.grpExtension.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpExtension.Controls.Add(Me.txtExtension)
        Me.grpExtension.Location = New System.Drawing.Point(6, 81)
        Me.grpExtension.Name = "grpExtension"
        Me.grpExtension.Size = New System.Drawing.Size(448, 42)
        Me.grpExtension.TabIndex = 5
        Me.grpExtension.TabStop = False
        Me.grpExtension.Text = "&Extension"
        '
        'txtExtension
        '
        Me.txtExtension.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtExtension.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtExtension.Location = New System.Drawing.Point(8, 16)
        Me.txtExtension.Name = "txtExtension"
        Me.txtExtension.Size = New System.Drawing.Size(434, 19)
        Me.txtExtension.TabIndex = 5
        '
        'chbDirRecur
        '
        Me.chbDirRecur.AutoSize = True
        Me.chbDirRecur.Location = New System.Drawing.Point(8, 151)
        Me.chbDirRecur.Name = "chbDirRecur"
        Me.chbDirRecur.Size = New System.Drawing.Size(132, 16)
        Me.chbDirRecur.TabIndex = 7
        Me.chbDirRecur.Text = "&Directory Reccursion"
        Me.chbDirRecur.UseVisualStyleBackColor = True
        '
        'chbGlass
        '
        Me.chbGlass.AutoSize = True
        Me.chbGlass.Location = New System.Drawing.Point(8, 129)
        Me.chbGlass.Name = "chbGlass"
        Me.chbGlass.Size = New System.Drawing.Size(81, 16)
        Me.chbGlass.TabIndex = 6
        Me.chbGlass.Text = "&Aero Glass"
        Me.chbGlass.UseVisualStyleBackColor = True
        '
        'grpTextFormat
        '
        Me.grpTextFormat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpTextFormat.Controls.Add(Me.Label2)
        Me.grpTextFormat.Controls.Add(Me.Label1)
        Me.grpTextFormat.Controls.Add(Me.txtTitle)
        Me.grpTextFormat.Controls.Add(Me.txtStatus)
        Me.grpTextFormat.Location = New System.Drawing.Point(6, 6)
        Me.grpTextFormat.Name = "grpTextFormat"
        Me.grpTextFormat.Size = New System.Drawing.Size(448, 69)
        Me.grpTextFormat.TabIndex = 2
        Me.grpTextFormat.TabStop = False
        Me.grpTextFormat.Text = "Text Format"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "&Status"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "&Title"
        '
        'txtTitle
        '
        Me.txtTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtTitle.Location = New System.Drawing.Point(50, 18)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(392, 19)
        Me.txtTitle.TabIndex = 3
        '
        'txtStatus
        '
        Me.txtStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtStatus.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtStatus.Location = New System.Drawing.Point(50, 43)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(392, 19)
        Me.txtStatus.TabIndex = 4
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtKeyConf)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(462, 205)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Key Config"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtKeyConf
        '
        Me.txtKeyConf.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtKeyConf.Location = New System.Drawing.Point(3, 3)
        Me.txtKeyConf.Multiline = True
        Me.txtKeyConf.Name = "txtKeyConf"
        Me.txtKeyConf.Size = New System.Drawing.Size(456, 199)
        Me.txtKeyConf.TabIndex = 1
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(470, 231)
        Me.Controls.Add(Me.TabControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Option - dePic"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.grpExtension.ResumeLayout(False)
        Me.grpExtension.PerformLayout()
        Me.grpTextFormat.ResumeLayout(False)
        Me.grpTextFormat.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents txtKeyConf As System.Windows.Forms.TextBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents grpTextFormat As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chbGlass As System.Windows.Forms.CheckBox
    Friend WithEvents chbDirRecur As System.Windows.Forms.CheckBox
    Friend WithEvents grpExtension As System.Windows.Forms.GroupBox
    Friend WithEvents txtExtension As System.Windows.Forms.TextBox
End Class
