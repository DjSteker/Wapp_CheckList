'Imports System.IO
'Imports System.Linq
'Imports System.Text
'Imports WebCam_Capture
'Imports System.Collections.Generic



Imports System.IO

Imports System.Linq
Imports System.Text
Imports System.Collections.Generic
'Imports WebCam_Capture

Public Class Form_WebCam
    Private Sub Form_WebCam_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        webcam = New WebCam()
        webcam.InitializeWebCam(imgVideo)
    End Sub

    Private webcam As WebCam

    Private Sub bntStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntStart.Click
        webcam.Start()
    End Sub

    Private Sub bntStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntStop.Click
        webcam.Stop()
    End Sub

    Private Sub bntContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntContinue.Click
        webcam.Continue()
    End Sub

    Private Sub bntCapture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntCapture.Click
        imgCapture.Image = imgVideo.Image
    End Sub

    Private Sub bntSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntSave.Click
        Helper.SaveImageCapture(imgCapture.Image)
    End Sub

    Private Sub bntVideoFormat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntVideoFormat.Click
        webcam.ResolutionSetting()
    End Sub

    Private Sub bntVideoSource_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntVideoSource.Click
        webcam.AdvanceSetting()
    End Sub


End Class

Class WebCam
    Private webcam As WebCamCapture
    Private _FrameImage As System.Windows.Forms.PictureBox
    Private FrameNumber As Integer = 30
    Public Sub InitializeWebCam(ByRef ImageControl As System.Windows.Forms.PictureBox)
        webcam = New WebCamCapture()
        webcam.FrameNumber = CULng((0))
        webcam.TimeToCapture_milliseconds = FrameNumber
        AddHandler webcam.ImageCaptured, AddressOf webcam_ImageCaptured
        _FrameImage = ImageControl
    End Sub

    Private Sub webcam_ImageCaptured(ByVal source As Object, ByVal e As WebcamEventArgs)
        _FrameImage.Image = e.WebCamImage
    End Sub

    Public Sub Start()
        webcam.TimeToCapture_milliseconds = FrameNumber
        webcam.Start(0)
    End Sub

    Public Sub [Stop]()
        webcam.[Stop]()
    End Sub

    Public Sub [Continue]()
        ' change the capture time frame
        webcam.TimeToCapture_milliseconds = FrameNumber

        ' resume the video capture from the stop
        webcam.Start(Me.webcam.FrameNumber)
    End Sub

    Public Sub ResolutionSetting()
        webcam.Config()
    End Sub

    Public Sub AdvanceSetting()
        webcam.Config2()
    End Sub

End Class

Class Helper

    Public Shared Sub SaveImageCapture(ByVal image As System.Drawing.Image)

        Dim s As New SaveFileDialog()
        s.FileName = "Image"
        ' Default file name
        s.DefaultExt = ".Jpg"
        ' Default file extension
        s.Filter = "Image (.jpg)|*.jpg"
        ' Filter files by extension
        ' Show save file dialog box
        ' Process save file dialog box results
        If s.ShowDialog() = DialogResult.OK Then
            ' Save Image
            Dim filename As String = s.FileName
            Dim fstream As New FileStream(filename, FileMode.Create)
            image.Save(fstream, System.Drawing.Imaging.ImageFormat.Jpeg)

            fstream.Close()

        End If
    End Sub
End Class