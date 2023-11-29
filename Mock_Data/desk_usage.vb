Sub GenerateLibraryUsageDataForTwoWeeks()
    Dim ws As Worksheet
    Set ws = ThisWorkbook.Sheets("Sheet1") ' Change "Sheet1" to your sheet's name
    ws.Cells.Clear

    ' Header
    ws.Range("A1").Value = "Desk ID"
    ws.Range("B1").Value = "Seat ID"
    ws.Range("C1").Value = "Start Time"
    ws.Range("D1").Value = "End Time"
    ws.Range("E1").Value = "Duration (Minutes)"
    ws.Range("F1").Value = "Peak Time Occupancy"

    ' Modify these lines to adjust the number of sessions and duration range
    Const MaxSessionsPerDay As Integer = 16  ' Increase the maximum number of sessions per seat per day
    Const MinSessionDuration As Integer = 15 ' The minimum duration of a session in minutes
    Const MaxSessionDuration As Integer = 120 ' The maximum duration of a session in minutes

    Dim desk As Integer, seat As Integer
    Dim startTime As Date, endTime As Date, duration As Integer
    Dim row As Integer
    row = 2

    ' Define peak times
    Dim peakStart1 As Date, peakEnd1 As Date, peakStart2 As Date, peakEnd2 As Date
    peakStart1 = TimeSerial(10, 0, 0)
    peakEnd1 = TimeSerial(12, 0, 0)
    peakStart2 = TimeSerial(14, 0, 0)
    peakEnd2 = TimeSerial(16, 0, 0)

    ' Randomize data
    Randomize

    Dim currentDate As Date
    currentDate = DateSerial(Year(Now), Month(Now), Day(Now)) ' Start from the current date

    ' Generate data for two weeks (14 days)
    Dim endDate As Date
    endDate = DateAdd("d", 13, currentDate) ' End date after two weeks

    Do While currentDate <= endDate
        For desk = 1 To 25
            For seat = 1 To 4
                Dim numSessions As Integer
                numSessions = Int((MaxSessionsPerDay - 1 + 1) * Rnd + 1) ' Random number of sessions for each seat

                For i = 1 To numSessions
                    Dim sessionStart As Integer
                    sessionStart = Int(Rnd * 48) * 15 ' Random start time between 8 AM to 8 PM in increments of 15 minutes
                    startTime = DateAdd("n", sessionStart, currentDate)
                    duration = Int(((MaxSessionDuration - MinSessionDuration) / 15 + 1) * Rnd) * 15 + MinSessionDuration ' Random duration

                    endTime = DateAdd("n", duration, startTime)

                    ' Determine if the seat is occupied during peak times
                    Dim peakOccupancy As Boolean
                    peakOccupancy = False
                    If (TimeValue(startTime) <= peakEnd1 And TimeValue(endTime) >= peakStart1) Or _
                       (TimeValue(startTime) <= peakEnd2 And TimeValue(endTime) >= peakStart2) Then
                        peakOccupancy = True
                    End If

                    ' Ensure end time does not exceed the closing time of 8 PM
                    If TimeValue(endTime) <= TimeSerial(20, 0, 0) Then
                        ws.Cells(row, 1).Value = desk
                        ws.Cells(row, 2).Value = seat
                        ws.Cells(row, 3).Value = startTime
                        ws.Cells(row, 4).Value = endTime
                        ws.Cells(row, 5).Value = duration
                        ws.Cells(row, 6).Value = peakOccupancy
                        row = row + 1
                    End If
                Next i
            Next seat
        Next desk

        currentDate = DateAdd("d", 1, currentDate) ' Move to the next day
    Loop

    ws.Columns.AutoFit
End Sub
