Public Class Class_Tiempo




    ' Pad the end of a TimeSpan string with spaces if it does not 
    ' contain milliseconds.
    Function Align(interval As TimeSpan) As String

        Dim intervalStr As String = interval.ToString()
        Dim pointIndex As Integer = intervalStr.IndexOf(":"c)

        pointIndex = intervalStr.IndexOf("."c, pointIndex)
        If pointIndex < 0 Then intervalStr &= "        "
        Align = intervalStr
    End Function

    Sub Main1()

        Const numberFmt As String = "{0,-22}{1,18:N0}"
        Const timeFmt As String = "{0,-22}{1,26}"

        Console.WriteLine(
            "This example of the fields of the TimeSpan class" &
            vbCrLf & "generates the following output." & vbCrLf)
        Console.WriteLine(numberFmt, "Field", "Value")
        Console.WriteLine(numberFmt, "-----", "-----")

        ' Display the maximum, minimum, and zero TimeSpan values.
        Console.WriteLine(timeFmt, "Maximum TimeSpan", Align(TimeSpan.MaxValue))
        Console.WriteLine(timeFmt, "Minimum TimeSpan", Align(TimeSpan.MinValue))
        Console.WriteLine(timeFmt, "Zero TimeSpan", Align(TimeSpan.Zero))
        Console.WriteLine()

        ' Display the ticks-per-time-unit fields.
        Console.WriteLine(numberFmt, "Ticks per day", TimeSpan.TicksPerDay)
        Console.WriteLine(numberFmt, "Ticks per hour", TimeSpan.TicksPerHour)
        Console.WriteLine(numberFmt, "Ticks per minute", TimeSpan.TicksPerMinute)
        Console.WriteLine(numberFmt, "Ticks per second", TimeSpan.TicksPerSecond)
        Console.WriteLine(numberFmt, "Ticks per millisecond", TimeSpan.TicksPerMillisecond)
    End Sub

    Sub Main0()

        Dim centuryBegin As Date = #1/1/2001 0:0:0#
        Dim currentDate As Date = Date.Now
        Dim elapsedTicks As Long = currentDate.Ticks - centuryBegin.Ticks
        Dim elapsedSpan As New TimeSpan(elapsedTicks)

        Console.WriteLine("Elapsed from the beginning of the century to {0:f}:", currentDate)
        Console.WriteLine("   {0:N0} nanoseconds", elapsedTicks * 100)
        Console.WriteLine("   {0:N0} ticks", elapsedTicks)
        Console.WriteLine("   {0:N2} seconds", elapsedSpan.TotalSeconds)
        Console.WriteLine("   {0:N2} minutes", elapsedSpan.TotalMinutes)
        Console.WriteLine("   {0:N0} days, {1} hours, {2} minutes, {3} seconds", elapsedSpan.Days, elapsedSpan.Hours, elapsedSpan.Minutes, elapsedSpan.Seconds)
    End Sub


End Class
