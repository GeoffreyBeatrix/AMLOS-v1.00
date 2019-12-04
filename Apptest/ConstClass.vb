Public Class ConstClass
    Public Shared DataReceived_bool As Boolean = False
    Public Shared MeasReceived_bool As Boolean = False
    Public Shared SerialConnected_bool As Boolean = False
    Public Shared DataReceived As String = ""
    Public Shared BLEMeasStr, TempStr, BLEConStr, F5Str, F4Str, HET_checked, HET_Stab, BLE_Address As String
    Public Shared AGAIN, ATIME, ASTEP, RatioLimMin, RatioLimMax, TargetTemp As Integer
    Public Shared RSSILvl As Integer = 0

    Public Structure ErrorListing
        Const Error_1 = "COMPort does not Exist"
        Const Error_2 = "No Communication"
        Const Error_3 = "Connection lost"
        Const Error_4 = "COM Port Disconnected"
        Const Error_null = "No error"
    End Structure

    Public Structure CmdListing
        Const Ser_Con = "SER!0!"
        Const Ser_Dis = "SER!1!"
        Const BLE_Dis = "BLE!0!"
        Const HET_Str = "HET!1!"
        Const HET_End = "HET!0!"
        Const Get_Meas = "gM/"
    End Structure

End Class
