<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.ButtonConnect = New System.Windows.Forms.Button()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ComboBoxCOMPrt = New System.Windows.Forms.ComboBox()
        Me.GetPD = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.IDMes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RatioF4F5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VerdictMes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ANA_Temp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumericUpDownNbAcq = New System.Windows.Forms.NumericUpDown()
        Me.ButtonClrTab = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButtonReload = New System.Windows.Forms.Button()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.IndicatorVerdict = New System.Windows.Forms.Button()
        Me.IndicatorBLE = New System.Windows.Forms.Button()
        Me.IndicatorRSSI0 = New System.Windows.Forms.Button()
        Me.IndicatorRSSI1 = New System.Windows.Forms.Button()
        Me.IndicatorRSSI2 = New System.Windows.Forms.Button()
        Me.IndicatorRSSI3 = New System.Windows.Forms.Button()
        Me.LabelCOMError = New System.Windows.Forms.Label()
        Me.ButtonRefresh = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.CheckBoxHeating = New System.Windows.Forms.CheckBox()
        Me.IndicatorHET = New System.Windows.Forms.Button()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabelBLE = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownNbAcq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonConnect
        '
        Me.ButtonConnect.Location = New System.Drawing.Point(12, 11)
        Me.ButtonConnect.Name = "ButtonConnect"
        Me.ButtonConnect.Size = New System.Drawing.Size(100, 23)
        Me.ButtonConnect.TabIndex = 6
        Me.ButtonConnect.Text = "Connect"
        Me.ButtonConnect.UseVisualStyleBackColor = True
        '
        'SerialPort1
        '
        Me.SerialPort1.PortName = "COM5"
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'ComboBoxCOMPrt
        '
        Me.ComboBoxCOMPrt.FormattingEnabled = True
        Me.ComboBoxCOMPrt.Location = New System.Drawing.Point(119, 12)
        Me.ComboBoxCOMPrt.Name = "ComboBoxCOMPrt"
        Me.ComboBoxCOMPrt.Size = New System.Drawing.Size(70, 21)
        Me.ComboBoxCOMPrt.TabIndex = 7
        '
        'GetPD
        '
        Me.GetPD.Location = New System.Drawing.Point(12, 53)
        Me.GetPD.Name = "GetPD"
        Me.GetPD.Size = New System.Drawing.Size(100, 23)
        Me.GetPD.TabIndex = 47
        Me.GetPD.Text = "Start"
        Me.GetPD.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDMes, Me.RatioF4F5, Me.VerdictMes, Me.ANA_Temp})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 111)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(363, 395)
        Me.DataGridView1.TabIndex = 65
        '
        'IDMes
        '
        Me.IDMes.HeaderText = "ID#"
        Me.IDMes.Name = "IDMes"
        Me.IDMes.ReadOnly = True
        '
        'RatioF4F5
        '
        Me.RatioF4F5.HeaderText = "Result"
        Me.RatioF4F5.Name = "RatioF4F5"
        Me.RatioF4F5.ReadOnly = True
        '
        'VerdictMes
        '
        Me.VerdictMes.HeaderText = "Verdict"
        Me.VerdictMes.Name = "VerdictMes"
        Me.VerdictMes.ReadOnly = True
        '
        'ANA_Temp
        '
        Me.ANA_Temp.HeaderText = "Temperature"
        Me.ANA_Temp.Name = "ANA_Temp"
        Me.ANA_Temp.ReadOnly = True
        '
        'NumericUpDownNbAcq
        '
        Me.NumericUpDownNbAcq.Location = New System.Drawing.Point(187, 54)
        Me.NumericUpDownNbAcq.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDownNbAcq.Name = "NumericUpDownNbAcq"
        Me.NumericUpDownNbAcq.Size = New System.Drawing.Size(55, 20)
        Me.NumericUpDownNbAcq.TabIndex = 71
        Me.NumericUpDownNbAcq.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'ButtonClrTab
        '
        Me.ButtonClrTab.Location = New System.Drawing.Point(12, 82)
        Me.ButtonClrTab.Name = "ButtonClrTab"
        Me.ButtonClrTab.Size = New System.Drawing.Size(100, 23)
        Me.ButtonClrTab.TabIndex = 72
        Me.ButtonClrTab.Text = "Clear Table"
        Me.ButtonClrTab.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(118, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 73
        Me.Label1.Text = "Sampling #:"
        '
        'ButtonReload
        '
        Me.ButtonReload.Location = New System.Drawing.Point(118, 82)
        Me.ButtonReload.Name = "ButtonReload"
        Me.ButtonReload.Size = New System.Drawing.Size(100, 23)
        Me.ButtonReload.TabIndex = 74
        Me.ButtonReload.Text = "Reload Config File"
        Me.ButtonReload.UseVisualStyleBackColor = True
        Me.ButtonReload.Visible = False
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Size = New System.Drawing.Size(385, 518)
        Me.ShapeContainer1.TabIndex = 78
        Me.ShapeContainer1.TabStop = False
        '
        'IndicatorVerdict
        '
        Me.IndicatorVerdict.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IndicatorVerdict.BackColor = System.Drawing.SystemColors.GrayText
        Me.IndicatorVerdict.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.IndicatorVerdict.Enabled = False
        Me.IndicatorVerdict.Location = New System.Drawing.Point(295, 81)
        Me.IndicatorVerdict.Name = "IndicatorVerdict"
        Me.IndicatorVerdict.Size = New System.Drawing.Size(20, 20)
        Me.IndicatorVerdict.TabIndex = 76
        Me.IndicatorVerdict.UseVisualStyleBackColor = False
        '
        'IndicatorBLE
        '
        Me.IndicatorBLE.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IndicatorBLE.BackColor = System.Drawing.SystemColors.GrayText
        Me.IndicatorBLE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.IndicatorBLE.Location = New System.Drawing.Point(321, 81)
        Me.IndicatorBLE.Name = "IndicatorBLE"
        Me.IndicatorBLE.Size = New System.Drawing.Size(20, 20)
        Me.IndicatorBLE.TabIndex = 77
        Me.IndicatorBLE.UseVisualStyleBackColor = False
        '
        'IndicatorRSSI0
        '
        Me.IndicatorRSSI0.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IndicatorRSSI0.BackColor = System.Drawing.SystemColors.GrayText
        Me.IndicatorRSSI0.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.IndicatorRSSI0.Enabled = False
        Me.IndicatorRSSI0.FlatAppearance.BorderColor = System.Drawing.SystemColors.GrayText
        Me.IndicatorRSSI0.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IndicatorRSSI0.Location = New System.Drawing.Point(347, 88)
        Me.IndicatorRSSI0.Name = "IndicatorRSSI0"
        Me.IndicatorRSSI0.Size = New System.Drawing.Size(5, 10)
        Me.IndicatorRSSI0.TabIndex = 79
        Me.IndicatorRSSI0.UseVisualStyleBackColor = False
        '
        'IndicatorRSSI1
        '
        Me.IndicatorRSSI1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IndicatorRSSI1.BackColor = System.Drawing.SystemColors.GrayText
        Me.IndicatorRSSI1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.IndicatorRSSI1.Enabled = False
        Me.IndicatorRSSI1.FlatAppearance.BorderColor = System.Drawing.SystemColors.GrayText
        Me.IndicatorRSSI1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IndicatorRSSI1.Location = New System.Drawing.Point(354, 83)
        Me.IndicatorRSSI1.Name = "IndicatorRSSI1"
        Me.IndicatorRSSI1.Size = New System.Drawing.Size(5, 15)
        Me.IndicatorRSSI1.TabIndex = 80
        Me.IndicatorRSSI1.UseVisualStyleBackColor = False
        '
        'IndicatorRSSI2
        '
        Me.IndicatorRSSI2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IndicatorRSSI2.BackColor = System.Drawing.SystemColors.GrayText
        Me.IndicatorRSSI2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.IndicatorRSSI2.Enabled = False
        Me.IndicatorRSSI2.FlatAppearance.BorderColor = System.Drawing.SystemColors.GrayText
        Me.IndicatorRSSI2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IndicatorRSSI2.Location = New System.Drawing.Point(361, 78)
        Me.IndicatorRSSI2.Name = "IndicatorRSSI2"
        Me.IndicatorRSSI2.Size = New System.Drawing.Size(5, 20)
        Me.IndicatorRSSI2.TabIndex = 81
        Me.IndicatorRSSI2.UseVisualStyleBackColor = False
        '
        'IndicatorRSSI3
        '
        Me.IndicatorRSSI3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IndicatorRSSI3.BackColor = System.Drawing.SystemColors.GrayText
        Me.IndicatorRSSI3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.IndicatorRSSI3.Enabled = False
        Me.IndicatorRSSI3.FlatAppearance.BorderColor = System.Drawing.SystemColors.GrayText
        Me.IndicatorRSSI3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IndicatorRSSI3.Location = New System.Drawing.Point(368, 73)
        Me.IndicatorRSSI3.Name = "IndicatorRSSI3"
        Me.IndicatorRSSI3.Size = New System.Drawing.Size(5, 25)
        Me.IndicatorRSSI3.TabIndex = 82
        Me.IndicatorRSSI3.UseVisualStyleBackColor = False
        '
        'LabelCOMError
        '
        Me.LabelCOMError.AutoSize = True
        Me.LabelCOMError.Location = New System.Drawing.Point(14, 37)
        Me.LabelCOMError.Name = "LabelCOMError"
        Me.LabelCOMError.Size = New System.Drawing.Size(78, 13)
        Me.LabelCOMError.TabIndex = 83
        Me.LabelCOMError.Text = "Not connected"
        '
        'ButtonRefresh
        '
        Me.ButtonRefresh.ImageList = Me.ImageList1
        Me.ButtonRefresh.Location = New System.Drawing.Point(196, 10)
        Me.ButtonRefresh.Name = "ButtonRefresh"
        Me.ButtonRefresh.Size = New System.Drawing.Size(25, 25)
        Me.ButtonRefresh.TabIndex = 84
        Me.ButtonRefresh.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "refresh-icon-transparent-2.jpg")
        '
        'CheckBoxHeating
        '
        Me.CheckBoxHeating.Appearance = System.Windows.Forms.Appearance.Button
        Me.CheckBoxHeating.AutoSize = True
        Me.CheckBoxHeating.Location = New System.Drawing.Point(276, 16)
        Me.CheckBoxHeating.Name = "CheckBoxHeating"
        Me.CheckBoxHeating.Size = New System.Drawing.Size(54, 23)
        Me.CheckBoxHeating.TabIndex = 85
        Me.CheckBoxHeating.Text = "Heating"
        Me.CheckBoxHeating.UseVisualStyleBackColor = True
        '
        'IndicatorHET
        '
        Me.IndicatorHET.BackColor = System.Drawing.SystemColors.GrayText
        Me.IndicatorHET.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.IndicatorHET.Enabled = False
        Me.IndicatorHET.Location = New System.Drawing.Point(336, 17)
        Me.IndicatorHET.Name = "IndicatorHET"
        Me.IndicatorHET.Size = New System.Drawing.Size(20, 20)
        Me.IndicatorHET.TabIndex = 86
        Me.IndicatorHET.UseVisualStyleBackColor = False
        '
        'Timer2
        '
        Me.Timer2.Interval = 250
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabelBLE})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 496)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(385, 22)
        Me.StatusStrip1.TabIndex = 87
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabelBLE
        '
        Me.ToolStripStatusLabelBLE.Name = "ToolStripStatusLabelBLE"
        Me.ToolStripStatusLabelBLE.Size = New System.Drawing.Size(119, 17)
        Me.ToolStripStatusLabelBLE.Text = "ToolStripStatusLabel1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(385, 518)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.IndicatorHET)
        Me.Controls.Add(Me.CheckBoxHeating)
        Me.Controls.Add(Me.ButtonRefresh)
        Me.Controls.Add(Me.LabelCOMError)
        Me.Controls.Add(Me.IndicatorRSSI3)
        Me.Controls.Add(Me.IndicatorRSSI2)
        Me.Controls.Add(Me.IndicatorRSSI1)
        Me.Controls.Add(Me.IndicatorRSSI0)
        Me.Controls.Add(Me.IndicatorBLE)
        Me.Controls.Add(Me.IndicatorVerdict)
        Me.Controls.Add(Me.ButtonReload)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ButtonClrTab)
        Me.Controls.Add(Me.NumericUpDownNbAcq)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GetPD)
        Me.Controls.Add(Me.ComboBoxCOMPrt)
        Me.Controls.Add(Me.ButtonConnect)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Name = "Form1"
        Me.Text = "Principal"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownNbAcq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonConnect As System.Windows.Forms.Button
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ComboBoxCOMPrt As System.Windows.Forms.ComboBox
    Friend WithEvents GetPD As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents NumericUpDownNbAcq As System.Windows.Forms.NumericUpDown
    Friend WithEvents ButtonClrTab As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents StatusMes As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ButtonReload As System.Windows.Forms.Button
    Private WithEvents ShapeContainer1 As PowerPacks.ShapeContainer
    Friend WithEvents IndicatorVerdict As Button
    Friend WithEvents IndicatorBLE As Button
    Friend WithEvents IndicatorRSSI0 As Button
    Friend WithEvents IndicatorRSSI1 As Button
    Friend WithEvents IndicatorRSSI2 As Button
    Friend WithEvents IndicatorRSSI3 As Button
    Friend WithEvents LabelCOMError As Label
    Friend WithEvents ButtonRefresh As Button
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents IDMes As DataGridViewTextBoxColumn
    Friend WithEvents RatioF4F5 As DataGridViewTextBoxColumn
    Friend WithEvents VerdictMes As DataGridViewTextBoxColumn
    Friend WithEvents ANA_Temp As DataGridViewTextBoxColumn
    Friend WithEvents CheckBoxHeating As CheckBox
    Friend WithEvents IndicatorHET As Button
    Friend WithEvents Timer2 As Timer
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabelBLE As ToolStripStatusLabel
End Class
