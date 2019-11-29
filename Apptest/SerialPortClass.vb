Imports System.Threading
Imports System.IO
Imports System.Text
Imports System.IO.Ports
Imports System.Xml
Imports System.Xml.Serialization

Public Class SerialPortClass
    Public Shared Sub SerialPortInit()
        Form1.SerialPort1.BaudRate = 9600
        Form1.SerialPort1.DataBits = 8
        Form1.SerialPort1.Parity = Parity.None
        Form1.SerialPort1.StopBits = StopBits.One
        Form1.SerialPort1.Handshake = Handshake.None
        Form1.SerialPort1.Encoding = System.Text.Encoding.Default
        Form1.SerialPort1.ReadTimeout = 1000
        Form1.SerialPort1.RtsEnable = True
        Form1.SerialPort1.DtrEnable = True
    End Sub
    Public Shared Sub RefreshCOMPortList()
        Form1.ComboBoxCOMPrt.Items.Clear()
        For Each sp As String In My.Computer.Ports.SerialPortNames
            Form1.ComboBoxCOMPrt.Items.Add(sp)
        Next
        Form1.ComboBoxCOMPrt.SelectedIndex = Form1.ComboBoxCOMPrt.Items.Count - 1
    End Sub
    Public Shared Function TryToconnect(ComPortName As String) As String
        Form1.SerialPort1.Close()
        Form1.SerialPort1.PortName = ComPortName
        Dim returnStr As Byte = &H0
        Dim COMPortFinded As Boolean = True

        Try
            Form1.SerialPort1.Open()
        Catch ex As Exception
            COMPortFinded = False
        End Try

        If COMPortFinded = True Then
            Return CheckCom()
        Else
            Return ConstClass.ErrorListing.Error_1
        End If

    End Function
    Public Shared Function SendData(OutputData As String) As String
        If Form1.SerialPort1.IsOpen Then
            Form1.SerialPort1.WriteLine(OutputData)
            Return ConstClass.ErrorListing.Error_null
        Else
            Return ConstClass.ErrorListing.Error_3
        End If
    End Function
    Public Shared Function CheckCom() As String
        If Form1.SerialPort1.IsOpen Then


            Form1.SerialPort1.WriteLine(ConstClass.CmdListing.Ser_Con)

            Dim comptage As Integer = 0
            While (ConstClass.DataReceived_bool = False And comptage < 40)
                comptage = comptage + 1
                System.Threading.Thread.Sleep(50)
            End While

            If ConstClass.DataReceived_bool = False Then
                Return ConstClass.ErrorListing.Error_3
                Form1.SerialPort1.Close()
            Else
                Return ConstClass.ErrorListing.Error_null
            End If
        Else
            Return ConstClass.ErrorListing.Error_3
        End If


    End Function

End Class
