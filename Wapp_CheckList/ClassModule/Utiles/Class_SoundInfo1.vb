Imports System
Imports System.Text
Imports System.Runtime.InteropServices

Namespace Sound

    Public Class SoundInfo1

        ' Private Declare Function mciSendString Lib "winmm.dll" (ByVal command As String, ByVal returnValue As StringBuilder, ByVal returnLength As Integer, ByVal winHandle As IntPtr) As UInteger
        Public Declare Function mciSendString Lib "winmm.dll" Alias "PlaySound" (ByVal command As String, ByVal returnValue As StringBuilder, ByVal returnLength As Integer, ByVal winHandle As IntPtr) As UInteger





        Public Shared Function GetSoundLength(ByVal fileName As String) As Integer
            'Dim lengthBuf As StringBuilder = New StringBuilder(32)
            Dim lengthBuf As StringBuilder = New StringBuilder(Int32.MaxValue)
            SoundInfo1.mciSendString(String.Format("open ""{0}"" type waveaudio alias wave", fileName), Nothing, 0, IntPtr.Zero)
            SoundInfo1.mciSendString("status wave length", lengthBuf, lengthBuf.Capacity, IntPtr.Zero)
            SoundInfo1.mciSendString("close wave", Nothing, 0, IntPtr.Zero)
            Dim length As Integer = 0
            'Dim . As Integer
            'Int64.TryParse(lengthBuf.ToString, length)
            Integer.TryParse(lengthBuf.ToString, length)
            Return length
        End Function


        Public Shared Function GetSoundStringBuilder(ByVal fileName As String) As StringBuilder
            'Dim lengthBuf As StringBuilder = New StringBuilder(32)
            Dim lengthBuf As StringBuilder = New StringBuilder()
            SoundInfo1.mciSendString(String.Format("open ""{0}"" type waveaudio alias wave", fileName), Nothing, 0, IntPtr.Zero)
            SoundInfo1.mciSendString("status wave length", lengthBuf, lengthBuf.Capacity, IntPtr.Zero)
            SoundInfo1.mciSendString("close wave", Nothing, 0, IntPtr.Zero)
            Dim length As Integer = 0
            'Dim . As Integer
            'Int64.TryParse(lengthBuf.ToString, length)
            Integer.TryParse(lengthBuf.ToString, length)
            Return lengthBuf
        End Function


    End Class
End Namespace
