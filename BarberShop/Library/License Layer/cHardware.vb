Option Strict On

Imports System.Management

Public Class cHardware

    'Author: khurram saddique (skhurams)
    'Ref: http://www.codeproject.com/KB/vb/hardware_Security_2.aspx

    Public Shared Function GetProcessorId() As String
        Dim strProcessorId As String = String.Empty
        Dim query As New SelectQuery("Win32_processor")
        Dim search As New ManagementObjectSearcher(query)

        For Each info As ManagementObject In search.Get()
            strProcessorId = info("processorId").ToString()
        Next

        Return strProcessorId
    End Function

    Public Shared Function GetMotherBoardID() As String
        Dim strMotherBoardID As String = String.Empty
        Dim query As New SelectQuery("Win32_BaseBoard")
        Dim search As New ManagementObjectSearcher(query)

        For Each info As ManagementObject In search.Get()
            strMotherBoardID = info("SerialNumber").ToString()
        Next

        Return strMotherBoardID
    End Function

End Class
