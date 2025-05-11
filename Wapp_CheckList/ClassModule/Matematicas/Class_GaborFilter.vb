
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Math

Public Class Class_GaborFilter
    Private Function GaborKernel(x As Double, y As Double, lambda As Double, theta As Double, psi As Double, sigma As Double, gamma As Double) As Double
        Dim xTheta = x * Cos(theta) + y * Sin(theta)
        Dim yTheta = -x * Sin(theta) + y * Cos(theta)
        Dim gb = Exp(-(xTheta ^ 2 + gamma ^ 2 * yTheta ^ 2) / (2 * sigma ^ 2)) * Cos(2 * PI * xTheta / lambda + psi)
        Return gb
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="image">imagen en el objeto del tipo Bitmap</param>
    ''' <param name="lambda">lambda (λ) en el contexto del filtrado Gabor representa la longitud de onda de la sinusoidal utilizada en la función Gabor</param>
    ''' <param name="theta">Theta (θ): Representa la orientación del filtro Gabor en el dominio espacial. Controla la orientación preferida del filtro para detectar características en una dirección específica.</param>
    ''' <param name="psi">Psi (ψ): Es la fase de la onda sinusoidal en el dominio espacial. Controla la orientación del filtro Gabor, es decir, la dirección de las características que el filtro es sensible a detectar.</param>
    ''' <param name="sigma">Sigma (σ): Representa la desviación estándar de la envolvente gaussiana utilizada en la función Gabor. Controla la extensión espacial del filtro Gabor, es decir, cuán localizada o extendida está la respuesta del filtro en el dominio espacial.</param>
    ''' <param name="gamma">Gamma (γ): Controla la relación de aspecto de la función Gabor, lo que significa que afecta la elipticidad de la función. Un valor de gamma diferente de 1 permite que la función Gabor capture características alargadas en la imagen, como bordes y líneas.</param>
    ''' <returns></returns>
    Public Function ApplyGaborFilter(image As Bitmap, lambda As Double, theta As Double, psi As Double, sigma As Double, gamma As Double) As Bitmap
        Dim width = image.Width
        Dim height = image.Height
        Dim rect = New Rectangle(0, 0, width, height)
        Dim data = image.LockBits(rect, ImageLockMode.ReadWrite, image.PixelFormat)
        Dim bytes = Math.Abs(data.Stride) * height
        Dim rgbValues(bytes - 1) As Byte
        System.Runtime.InteropServices.Marshal.Copy(data.Scan0, rgbValues, 0, bytes)

        For y = 0 To height - 1
            For x = 0 To width - 1
                Dim pixelIndex = y * data.Stride + x * 4
                Dim color = System.Drawing.Color.FromArgb(rgbValues(pixelIndex + 2), rgbValues(pixelIndex + 1), rgbValues(pixelIndex + 0))
                Dim gray = 0.299 * color.R + 0.587 * color.G + 0.114 * color.B
                Dim gb = GaborKernel(x, y, lambda, theta, psi, sigma, gamma)
                Dim value = gray * gb
                rgbValues(pixelIndex + 0) = value
                rgbValues(pixelIndex + 1) = value
                rgbValues(pixelIndex + 2) = value
            Next
        Next

        System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, data.Scan0, bytes)
        image.UnlockBits(data)
        Return image
    End Function
End Class