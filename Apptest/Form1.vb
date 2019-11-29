Imports System
Imports System.IO.Ports
Imports System.Configuration
Imports System.Xml
Imports System.Xml.Serialization

Public Class Form1

    Private Property i As Integer
    Private Property _Form1Reset As Boolean = False
    Private ValLED1, ValLED2 As String
    Dim Tooltip1 As ToolTip = New ToolTip()



    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        SerialPortClass.SerialPortInit()
        SerialPortClass.RefreshCOMPortList()
        InitForm()
        ReizeTab()
        LoadConfFile()

    End Sub
    Private Sub Connect_Click(sender As Object, e As EventArgs) Handles ButtonConnect.Click
        If sender.text = "Connect" Then

            Dim ErrorRtrn As String = SerialPortClass.TryToconnect(ComboBoxCOMPrt.Text)
            If ErrorRtrn = ConstClass.ErrorListing.Error_null Then
                Connected()
                LabelCOMError.Text = "Connected"
                LabelCOMError.ForeColor = SystemColors.ControlText
            Else
                LabelCOMError.Text = ErrorRtrn
                LabelCOMError.ForeColor = Color.Red
            End If
        Else

            Disconnecting()
            LabelCOMError.Text = "Not connected"
            LabelCOMError.ForeColor = SystemColors.ControlText
        End If

    End Sub


    Private Sub GetPD_Click(sender As Object, e As EventArgs) Handles GetPD.Click

        Me.Cursor = Cursors.WaitCursor

        TestRuning()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub TestRuning()
        Dim nbAcq As Integer = NumericUpDownNbAcq.Value
        Dim index As Integer


        For index = 1 To nbAcq Step 1

            Dim ErrorRtrn As String = SerialPortClass.SendData(ConstClass.CmdListing.Get_Meas)
            If ErrorRtrn <> ConstClass.ErrorListing.Error_null Then
                LabelCOMError.Text = ErrorRtrn
                LabelCOMError.ForeColor = Color.Red
                Disconnecting()
                Exit Sub
            End If

            Dim comptage As Integer = 0
            While (ConstClass.MeasReceived_bool = False Or comptage < 20)
                comptage = comptage + 1
                System.Threading.Thread.Sleep(50)
            End While

            If ConstClass.MeasReceived_bool = False Then
                If SerialPort1.IsOpen = False Then
                    LabelCOMError.Text = ConstClass.ErrorListing.Error_4
                Else
                    LabelCOMError.Text = ConstClass.ErrorListing.Error_2
                End If
                LabelCOMError.ForeColor = Color.Red
                Disconnecting()
                Exit Sub
            End If

            ConstClass.MeasReceived_bool = False

            WriteResult()

        Next



    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If MouseButtons.HasFlag(MouseButtons.Left) = True Then

            If Me.Width >= Me.MinimumSize.Width And Me.Height >= Me.MinimumSize.Height Then
                ReizeTab()
                _Form1Reset = False
            Else
                Me.Cursor = New Cursor(Cursor.Current.Handle)
                Cursor.Position = New Point(Me.MinimumSize.Width + 50, Me.MinimumSize.Height + 50)
                Cursor.Clip = New Rectangle(Me.Location, Me.Size)
                _Form1Reset = True
            End If
        End If

    End Sub

    Private Sub Form1_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd
        If _Form1Reset = True Then
            Me.Width = Me.MinimumSize.Width
            Me.Height = Me.MinimumSize.Height
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ConstClass.DataReceived_bool Then
            ConstClass.DataReceived_bool = False
            BLEIndicatorRefresh()
            HETIndicator()
            If ConstClass.MeasReceived_bool Then
                ConstClass.MeasReceived_bool = False
                WriteResult()
                ConstClass.BLEMeasStr = "0"
            End If
        End If
        'Dim ErrorRtrn As String = SerialPortClass.CheckCom()
        'If ErrorRtrn <> ConstClass.ErrorListing.Error_null Then
        '    LabelCOMError.Text = ErrorRtrn
        '    LabelCOMError.ForeColor = Color.Red
        '    Disconnecting()
        '    Exit Sub
        'End If
    End Sub

    Private Sub ReizeTab()
        Dim TabWidth As Integer = DataGridView1.Width
        Dim colWidth As Integer = (TabWidth - DataGridView1.RowHeadersWidth) / DataGridView1.Columns.Count
        For Each Col As DataGridViewColumn In DataGridView1.Columns
            Col.Width = colWidth
        Next
    End Sub

    Private Sub ButtonReload_Click(sender As Object, e As EventArgs) Handles ButtonReload.Click
        LoadConfFile()
        SendConfFile()

    End Sub

    Private Sub ButtonClrTab_Click(sender As Object, e As EventArgs) Handles ButtonClrTab.Click
        DataGridView1.Rows.Clear()
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        For Each Ligne As DataGridViewRow In DataGridView1.Rows
            If Ligne.Selected Then
                IndicatorVerdict.BackColor = Ligne.Cells(2).Style.ForeColor
            End If

        Next
    End Sub

    Private Sub IndicatorBLE_Click(sender As Object, e As EventArgs) Handles IndicatorBLE.Click
        SerialPort1.WriteLine("BLE!0!")
    End Sub


    Private Sub InitForm()
        Me.Text = "AMLOS v2.0.0"
        AddHandler SerialPort1.DataReceived, AddressOf DataReceivedHandler
        ButtonRefresh.Image = ImageList1.Images(0)
        For Each Ctl As Control In Me.Controls
            Dim Indicator As Integer = Ctl.Name.IndexOf("Indicator")
            If TypeOf Ctl Is Button And (Ctl.Name <> "ButtonConnect" And Ctl.Name <> "ButtonRefresh") Then Ctl.Enabled = False
            If TypeOf Ctl Is Button And Indicator <> -1 Then Ctl.BackColor = SystemColors.GrayText
            If TypeOf Ctl Is NumericUpDown Then Ctl.Enabled = False
            If TypeOf Ctl Is ComboBox Then Ctl.Enabled = True
            If TypeOf Ctl Is CheckBox Then Ctl.Enabled = False
        Next
        Me.MinimumSize = New System.Drawing.Size(Me.Width, Me.Height)
        Timer1.Enabled = False
        ToolStripStatusLabelBLE.Text = "BLE disconnected"
    End Sub
    Private Sub LoadConfFile()
        ConstClass.AGAIN = ConfigurationManager.AppSettings("AGAIN")
        ConstClass.ATIME = ConfigurationManager.AppSettings("ATIME")
        ConstClass.ASTEP = ConfigurationManager.AppSettings("ASTEP")
        ConstClass.RatioLimMin = ConfigurationManager.AppSettings("RATIO_Limit_inf")
        ConstClass.RatioLimMax = ConfigurationManager.AppSettings("RATIO_Limit_sup")
        ConstClass.TargetTemp = ConfigurationManager.AppSettings("TargetTemp")
    End Sub
    Private Sub Connected()
        ButtonConnect.Text = "Disconnect"
        Timer1.Enabled = True
        For Each Ctl As Control In Me.Controls
            Dim Indicator As Integer = Ctl.Name.IndexOf("Indicator")
            If TypeOf Ctl Is Button And Indicator = -1 Then Ctl.Enabled = True
            If TypeOf Ctl Is Button And Ctl.Name = "ButtonRefresh" Then Ctl.Enabled = False
            If TypeOf Ctl Is NumericUpDown Then Ctl.Enabled = True
            If TypeOf Ctl Is ComboBox Then Ctl.Enabled = False
            If TypeOf Ctl Is CheckBox Then Ctl.Enabled = True
        Next
    End Sub
    Private Sub Disconnecting()
        If CheckBoxHeating.Checked Then
            MsgBox("Stop heating before disconnecting")
            Exit Sub
        End If
        For Each Ctl As Control In Me.Controls
            Dim Indicator As Integer = Ctl.Name.IndexOf("Indicator")
            If TypeOf Ctl Is Button And (Ctl.Name <> "ButtonConnect" And Ctl.Name <> "ButtonRefresh") Then Ctl.Enabled = False
            If TypeOf Ctl Is Button And Indicator <> -1 Then Ctl.BackColor = SystemColors.GrayText
            If TypeOf Ctl Is NumericUpDown Then Ctl.Enabled = False
            If TypeOf Ctl Is ComboBox Then Ctl.Enabled = True
            If TypeOf Ctl Is CheckBox Then Ctl.Enabled = False
        Next

        NumericUpDownNbAcq.Value = 1
        SerialPortClass.SendData(ConstClass.CmdListing.Ser_Dis)
        SerialPort1.Close()
        Timer1.Enabled = False
        ButtonConnect.Text = "Connect"
        SerialPortClass.RefreshCOMPortList()
    End Sub
    Private Sub WriteResult()

        DataGridView1.Rows.Add()
        Dim Rowindex = DataGridView1.Rows.Count
        Dim F4 As Integer = CInt(ConstClass.F4Str)
        Dim F5 As Integer = CInt(ConstClass.F5Str)
        Dim Ratio As Double = Math.Round(F4 / F5, 3)
        Dim VerdictRat() As String = New String(2) {"Positive", "Negative", "Not Conclusive"}
        If ConstClass.BLEMeasStr = "1" Then
            DataGridView1.Rows(Rowindex - 1).Cells(0).Style.ForeColor = Color.DeepSkyBlue
            DataGridView1.Rows(Rowindex - 1).Cells(0).Style.Font = New Font(Control.DefaultFont, FontStyle.Bold)
        End If
        DataGridView1.Rows(Rowindex - 1).Cells(0).Value = Rowindex
        DataGridView1.Rows(Rowindex - 1).Cells(1).Value = Ratio
        DataGridView1.Rows(Rowindex - 1).Cells(2).Style.Font = New Font(Control.DefaultFont, FontStyle.Bold)
        If Ratio < 4 Then
            DataGridView1.Rows(Rowindex - 1).Cells(2).Value = VerdictRat(0)
            DataGridView1.Rows(Rowindex - 1).Cells(2).Style.ForeColor = Color.Green
        ElseIf Ratio >= 4 And Ratio <= 5 Then
            DataGridView1.Rows(Rowindex - 1).Cells(2).Value = VerdictRat(2)
            DataGridView1.Rows(Rowindex - 1).Cells(2).Style.ForeColor = Color.Orange
        Else
            DataGridView1.Rows(Rowindex - 1).Cells(2).Value = VerdictRat(1)
            DataGridView1.Rows(Rowindex - 1).Cells(2).Style.ForeColor = Color.Red
        End If
        DataGridView1.Rows(Rowindex - 1).Cells(3).Value = ConstClass.TempStr

        IndicatorVerdict.BackColor = DataGridView1.Rows(Rowindex - 1).Cells(2).Style.ForeColor

        DataGridView1.Rows(Rowindex - 1).Selected = True
        Me.Refresh()
    End Sub
    Private Shared Sub DataReceivedHandler(sender As Object, e As SerialDataReceivedEventArgs)

        Dim sp As SerialPort = CType(sender, SerialPort)
        Dim indata As String = sp.ReadExisting()
        If indata <> "" Then
            Dim IndexBLE As Integer = indata.IndexOf("BLE")
            Dim IndexMSR As Integer = indata.IndexOf("MSR")
            Dim IndexSER As Integer = indata.IndexOf("SER")
            Dim IndexHET As Integer = indata.IndexOf("HET")
            If IndexBLE <> -1 Then
                Dim ValeurP1 As String = indata.Substring(IndexBLE + 4)
                Dim ValeurP1Arr() As String = ValeurP1.Split("!")
                Dim ValeursStr As String = ValeurP1Arr(0)
                Dim ArrayString() As String = ValeursStr.Split(";")
                ConstClass.BLEConStr = ArrayString(0)
                ConstClass.RSSILvl = ArrayString(1) + 100
                ConstClass.BLE_Address = ArrayString(2)
            End If

            If IndexMSR <> -1 Then
                Dim ValeurP1 As String = indata.Substring(IndexBLE + 5)
                Dim ValeurP1Arr() As String = ValeurP1.Split("!")
                Dim ValeursStr As String = ValeurP1Arr(0)
                Dim ArrayString() As String = ValeursStr.Split(";")
                ConstClass.BLEConStr = ArrayString(0)
                ConstClass.F4Str = ArrayString(1)
                ConstClass.F5Str = ArrayString(2)
                ConstClass.BLEMeasStr = ArrayString(3)
                ConstClass.TempStr = ArrayString(4)
                ConstClass.MeasReceived_bool = True
            End If

            If IndexSER <> -1 Then
                Dim ValeurP1 As String = indata.Substring(IndexBLE + 4)
                Dim ValeurP1Arr() As String = ValeurP1.Split("!")
                Dim ValeursStr As String = ValeurP1Arr(0)
                Dim ArrayString() As String = ValeursStr.Split(";")
                If ArrayString(0) = "1" Then
                    ConstClass.SerialConnected_bool = True
                End If
            End If

            If IndexHET <> -1 Then
                Dim ValeurP1 As String = indata.Substring(IndexHET + 4)
                Dim ValeurP1Arr() As String = ValeurP1.Split("!")
                Dim ValeursStr As String = ValeurP1Arr(0)
                Dim ArrayString() As String = ValeursStr.Split(";")
                ConstClass.HET_checked = ArrayString(0)
                ConstClass.HET_Stab = ArrayString(1)
            End If

            ConstClass.DataReceived_bool = True
        End If
    End Sub

    Private Sub ButtonRefresh_Click(sender As Object, e As EventArgs) Handles ButtonRefresh.Click
        SerialPortClass.RefreshCOMPortList()
    End Sub

    Private Sub CheckBoxHeating_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxHeating.CheckedChanged
        If (CheckBoxHeating.Checked) Then
            Dim ErrorRtrn As String = SerialPortClass.SendData("HET!1!")
            If ErrorRtrn <> ConstClass.ErrorListing.Error_null Then
                LabelCOMError.Text = ErrorRtrn
                LabelCOMError.ForeColor = Color.Red
                Disconnecting()
                Exit Sub
            End If
        Else
            Dim ErrorRtrn As String = SerialPortClass.SendData("HET!0!")
            If ErrorRtrn <> ConstClass.ErrorListing.Error_null Then
                LabelCOMError.Text = ErrorRtrn
                LabelCOMError.ForeColor = Color.Red
                Disconnecting()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub BLEIndicatorRefresh()
        If ConstClass.BLEConStr = "1" Then
            Tooltip1.SetToolTip(IndicatorBLE, ConstClass.BLE_Address)
            ToolStripStatusLabelBLE.Text = "BLE Connected to: " & ConstClass.BLE_Address
            IndicatorBLE.BackColor = Color.RoyalBlue
            If ConstClass.RSSILvl < 100 And ConstClass.RSSILvl > 0 Then
                If ConstClass.RSSILvl > 0 Then
                    IndicatorRSSI0.BackColor = Color.DeepSkyBlue
                Else
                    IndicatorRSSI0.BackColor = SystemColors.GrayText
                End If
                If ConstClass.RSSILvl > 26 Then
                    IndicatorRSSI1.BackColor = Color.DeepSkyBlue
                Else
                    IndicatorRSSI1.BackColor = SystemColors.GrayText
                End If
                If ConstClass.RSSILvl > 51 Then
                    IndicatorRSSI2.BackColor = Color.DeepSkyBlue
                Else
                    IndicatorRSSI2.BackColor = SystemColors.GrayText
                End If
                If ConstClass.RSSILvl > 76 Then
                    IndicatorRSSI3.BackColor = Color.DeepSkyBlue
                Else
                    IndicatorRSSI3.BackColor = SystemColors.GrayText
                End If
            ElseIf ConstClass.RSSILvl = 100 Then
                IndicatorBLE.Enabled = True
            End If
        Else
            Tooltip1.SetToolTip(IndicatorBLE, "")
            ToolStripStatusLabelBLE.Text = "BLE disconnected"
            IndicatorBLE.BackColor = SystemColors.GrayText
            IndicatorRSSI0.BackColor = SystemColors.GrayText
            IndicatorRSSI1.BackColor = SystemColors.GrayText
            IndicatorRSSI2.BackColor = SystemColors.GrayText
            IndicatorRSSI3.BackColor = SystemColors.GrayText
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If IndicatorHET.BackColor = SystemColors.GrayText Then IndicatorHET.BackColor = Color.Orange Else IndicatorHET.BackColor = SystemColors.GrayText
    End Sub

    Private Sub HETIndicator()
        If ConstClass.HET_checked = "1" Then
            CheckBoxHeating.Checked = True
            If ConstClass.HET_Stab = "0" Then
                Timer2.Enabled = True
            Else
                Timer2.Enabled = False
                IndicatorHET.BackColor = Color.GreenYellow
            End If
        Else
            IndicatorHET.BackColor = SystemColors.GrayText
            CheckBoxHeating.Checked = False
            Timer2.Enabled = False
        End If

    End Sub
    Private Sub SendConfFile()
        Dim gain_string As String = ConstClass.AGAIN.ToString("00")
        Dim atime_string As String = ConstClass.ATIME.ToString("000")
        Dim astep_string As String = ConstClass.ASTEP.ToString("00000")
        Dim RatioLimMin_string As String = ConstClass.RatioLimMin.ToString("00")
        Dim RatioLimMax_string As String = ConstClass.RatioLimMax.ToString("00")
        Dim TargetTemp_string As String = ConstClass.TargetTemp.ToString("00")

        Dim ErrorRtrn As String = SerialPortClass.SendData("sParam" & gain_string & ";" & atime_string & ";" & astep_string & ";" & RatioLimMin_string & ";" & RatioLimMax_string & ";" & TargetTemp_string & "/")
        If ErrorRtrn <> ConstClass.ErrorListing.Error_null Then
            LabelCOMError.Text = ErrorRtrn
            LabelCOMError.ForeColor = Color.Red
            Disconnecting()
            Exit Sub
        End If
    End Sub
End Class
