Sub GenerateEntryExitDataForTwoWeeks()
    Const MaxCapacity As Integer = 200
    Dim ws As Worksheet
    Set ws = ThisWorkbook.Sheets("Sheet1") ' Change "Sheet1" to your sheet's name
    ws.Cells.Clear

    ' Header
    ws.Range("A1").Value = "Timestamp"
    ws.Range("B1").Value = "Action"
    ws.Range("C1").Value = "Current Count"
    ws.Range("D1").Value = "Over Capacity"

    Dim currentCount As Integer
    Dim timestamp As Date
    Dim action As String
    Dim row As Integer
    row = 2
    currentCount = 0

    ' Randomize data
    Randomize

    Dim currentDate As Date
    currentDate = DateSerial(Year(Now), Month(Now), Day(Now)) ' Start from the current date

    ' Generate data for two weeks (14 days)
    Dim endDate As Date
    endDate = DateAdd("d", 13, currentDate) ' End date after two weeks

    Do While currentDate <= endDate
        Dim numEvents As Integer
        numEvents = 720 ' Approximately an event per minute for 12 hours

        For i = 1 To numEvents
            Dim eventTime As Integer
            eventTime = Int(Rnd * (12 * 60)) ' Random event time between 8 AM to 8 PM in minutes
            timestamp = DateAdd("n", eventTime, currentDate)
            
            ' Randomly decide if this event is an entry or an exit
            If currentCount = 0 Or Rnd < 0.5 Then
                action = "Entry"
                currentCount = currentCount + 1
            Else
                action = "Exit"
                currentCount = currentCount - 1
            End If

            ' Record the event
            ws.Cells(row, 1).Value = timestamp
            ws.Cells(row, 2).Value = action
            ws.Cells(row, 3).Value = currentCount
            ws.Cells(row, 4).Value = currentCount > MaxCapacity
            row = row + 1
        Next i

        currentDate = DateAdd("d", 1, currentDate) ' Move to the next day
    Loop

    ws.Columns.AutoFit
End Sub
