Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Drawing
Imports Cal_
Imports InfoSoftGlobal
Imports System.Net.Dns
Imports System.IO
Imports System.Web.UI

Public Class DowntimeGraph
    Dim SQL As String
    'Public Function DTMinuteByLineCharts(ByVal CR As String, ByVal CR_Detail As String, ByVal StartDate As DateTime, ByVal EndDate As DateTime, _
    '                                    ByRef LBTLL As Label, ByVal Width As String, ByVal Height As String, ByVal link As Boolean) As String
    '    Dim strXML As String = ""
    '    Dim Total As Integer = 0

    '    'strXML = strXML & "<graph bgcolor='feffe5' caption='Loss-Time by line of " + CR_Detail.ToString + "'"
    '    'strXML += " subCaption='Date : " + GetDateStart(StartDate).Replace("'", "%26apos;")
    '    'If StartDate <> EndDate Then
    '    '    strXML += " - " + getStrDate(EndDate).Replace("'", "%26apos;")
    '    'End If
    '    strXML += "' xAxisName='Line' yAxisName='Minutes' showvalues='1' baseFontSize='10' baseFont='Arial' outCnvBaseFontSize='14'"
    '    strXML += " rotateNames='1' yAxisMaxValue='100' thousandSeparator=',' formatNumberScale='1' decimalPrecision='0'>"

    '    Try
    '        Dim dTable2 As DataTable
    '        Dim dTable3 As DataTable
    '        SQL = "SELECT * FROM Line"
    '        SQL += " WHERE Line_Status=1 AND CR_ID='" + CR.ToString + "'"
    '        SQL += " ORDER BY Line_Order"
    '        dTable2 = DownTime.DataAccessLayer.DataAccess.GetDs(SQL).Tables(0).Copy

    '        'Set X-Axial Name
    '        strXML &= "<categories fontSize='11'>"
    '        For i As Integer = 0 To dTable2.Rows.Count - 1
    '            strXML &= "<category name='" + dTable2.Rows(i)("Line_Detail").ToString + "' />"
    '        Next
    '        strXML &= "</categories> "

    '        'Set X-Axial Value
    '        SQL = "SELECT * FROM LossTimeCode"
    '        SQL += " WHERE LT_Status=1"
    '        SQL += " ORDER BY LT_Code"
    '        dTable3 = DownTime.DataAccessLayer.DataAccess.GetDs(SQL).Tables(0).Copy

    '        If dTable3.Rows.Count > 0 Then
    '            For i As Integer = 0 To dTable3.Rows.Count - 1
    '                strXML &= "<dataset seriesname='" + dTable3.Rows(i)("LT_Code").ToString + ":" + dTable3.Rows(i)("LT_Mean").ToString.Replace("&", "%26") + "' color='" + GetColor(i) + "' alpha='100'>"
    '                Total = XMLStringMinuteLine(strXML, dTable2, CR, StartDate, EndDate, link, dTable3.Rows(i)("LT_ID").ToString)
    '                'LBTLL.Text = CR_Detail.ToString + " Motor = " + Total.ToString("#,##0") + " Minutes , "
    '                strXML &= "</dataset>"
    '            Next

    '            strXML &= "<dataset seriesname='N/A:Undefine' color='" + GetColor(25) + "' alpha='100'>"
    '            Total = XMLStringMinuteLine(strXML, dTable2, CR, StartDate, EndDate, link, "0")
    '            'LBTLL.Text = CR_Detail.ToString + " Motor = " + Total.ToString("#,##0") + " Minutes , "
    '            strXML &= "</dataset>"

    '        End If

    '        strXML &= "</graph>"
    '    Catch ex As Exception

    '    End Try

    '    'Create the chart - Column 3D Chart with data from strXML variable using dataXML method
    '    Return FusionCharts.RenderChartHTML("FusionCharts/FCF_StackedColumn3D.swf", "", strXML, "myNext", Width, Height, False)

    'End Function
    'Private Function XMLStringMinuteLine(ByRef strXML As String, ByVal dTable2 As DataTable, ByVal CR As String, _
    '                                     ByVal StartDate As DateTime, ByVal EndDate As DateTime, ByVal link As Boolean, ByVal CodeID As String) As Integer
    '    Dim Total As Integer = 0
    '    Dim DateStart As Date
    '    Dim DateEnd As Date

    '    For i As Integer = 0 To dTable2.Rows.Count - 1
    '        Dim StrDate1 As DateTime = StartDate
    '        Dim StrDate2 As DateTime = EndDate
    '        Dim TotalTmp As Integer = 0

    '        While StrDate1 <= StrDate2
    '            DateStart = New Date(StrDate1.Year, StrDate1.Month, StrDate1.Day, 8, 0, 0)
    '            DateEnd = New Date(StrDate1.Year, StrDate1.Month, StrDate1.Day, 7, 59, 59).AddDays(1)

    '            SQL = "SELECT (ISNULL(Sum(Total),0) + ISNULL(Sum(PCE_Total),0)) As Total FROM DownTimeRecord"
    '            SQL += " INNER JOIN ModelRelation ON ModelRelation.ML_ID=DownTimeRecord.ML_ID"
    '            SQL += " INNER JOIN Line ON ModelRelation.Line_ID=Line.Line_ID"
    '            'SQL += " INNER JOIN ProcessRelation ON ProcessRelation.PL_ID=DownTimeRecord.PL_ID"
    '            'SQL += " INNER JOIN Process ON Process.Process_ID=ProcessRelation.Process_ID"
    '            'SQL += " INNER JOIN LineType ON LineType.TY_ID=Process.TY_ID"
    '            SQL += " LEFT JOIN LossTimeRelation ON LossTimeRelation.DT_ID=DownTimeRecord.DT_ID"
    '            SQL += " LEFT JOIN LossTimeDetail ON LossTimeDetail.LTD_ID=LossTimeRelation.LTD_ID"
    '            SQL += " LEFT JOIN PCEData ON PCEData.DT_ID=DownTimeRecord.DT_ID"

    '            SQL += " WHERE Line.Line_ID='" + dTable2.Rows(i)("Line_ID").ToString + "'"
    '            'SQL += " AND LineType.TY_ID='" + LineType.ToString + "'"

    '            If CodeID.ToString = "0" Then
    '                SQL += " AND LossTimeDetail.LT_ID is null"
    '            Else
    '                SQL += " AND LossTimeDetail.LT_ID='" + CodeID.ToString + "'"
    '            End If

    '            SQL += " AND DT_Status = 1"
    '            SQL += " AND (StartTime >= '" + DateStart.ToString("yyyy/MM/dd HH:mm:ss") + "'"
    '            SQL += " AND StartTime <= '" + DateEnd.ToString("yyyy/MM/dd HH:mm:ss") + "')"

    '            dTable = DownTime.DataAccessLayer.DataAccess.GetDs(SQL).Tables(0).Copy

    '            TotalTmp += CInt(dTable.Rows(0)("Total"))

    '            StrDate1 = StrDate1.AddDays(1)
    '        End While

    '        If TotalTmp > 0 Then
    '            strXML &= "<set value='" + TotalTmp.ToString + "'"
    '            If link Then
    '                strXML &= " link='n-DataByLine.aspx%3FLine%3D" & dTable2.Rows(i)("Line_ID").ToString & _
    '                           "%26Start%3D" & StartDate.ToString("dd-MM-yyyy") & _
    '                           "%26End%3D" & EndDate.ToString("dd-MM-yyyy") & _
    '                           "%26CR%3D" & CR.ToString & _
    '                           "%26LTID%3D" & CodeID.ToString & "'"
    '            End If
    '            strXML &= " />"
    '            Total += TotalTmp
    '        Else
    '            strXML &= "<set />"
    '        End If
    '    Next

    '    Return Total
    'End Function
    ' Old version Downtime (14-May-2013)
    'Public Function DTMinuteByLineCharts(ByVal CR As String, ByVal CR_Detail As String, ByVal StartDate As DateTime, ByVal EndDate As DateTime, _
    '                                    ByRef LBTLL As Label, ByVal Width As String, ByVal Height As String, ByVal link As Boolean) As String
    '    Dim strXML As String = ""
    '    Dim Total As Integer = 0

    '    strXML = strXML & "<graph bgcolor='FFEFDB' caption='Summary Downtime By Line of " + CR_Detail.ToString
    '    strXML += " on " + getStrDate(StartDate).Replace("'", "%26apos;")
    '    If StartDate <> EndDate Then
    '        strXML += " - " + getStrDate(EndDate).Replace("'", "%26apos;")
    '    End If
    '    strXML += "' xAxisName='Line' yAxisName='Minutes' showvalues='1'"
    '    strXML += " rotateNames='1' yAxisMaxValue='100' thousandSeparator=',' formatNumberScale='1' decimalPrecision='0'>"

    '    Try
    '        Dim dTable2 As DataTable
    '        SQL = "SELECT * FROM Line"
    '        SQL += " WHERE Line_Status=1 AND CR_ID='" + CR.ToString + "'"
    '        SQL += " ORDER BY Line_Order"
    '        dTable2 = DownTime.DataAccessLayer.DataAccess.GetDs(SQL).Tables(0).Copy

    '        'Set X-Axial Name
    '        strXML &= "<categories>"
    '        For i As Integer = 0 To dTable2.Rows.Count - 1
    '            strXML &= "<category name='" + dTable2.Rows(i)("Line_Detail").ToString + "'/>"
    '        Next
    '        strXML &= "</categories> "

    '        'Set X-Axial Value
    '        If CR = "2" Then
    '            'MOTOR
    '            strXML &= "<dataset seriesname='MOTOR' color='9D080D' alpha='100'>"
    '            Total = XMLStringMinuteLine(strXML, dTable2, CR, StartDate, EndDate, link, 2)
    '            LBTLL.Text = CR_Detail.ToString + " Motor = " + Total.ToString("#,##0") + " Minutes , "
    '            strXML &= "</dataset>"

    '            'BASE
    '            strXML &= "<dataset seriesname='BASE' color='56B9F9' alpha='100'>"
    '            Total = XMLStringMinuteLine(strXML, dTable2, CR, StartDate, EndDate, link, 3)
    '            LBTLL.Text += "Base = " + Total.ToString("#,##0") + " Minutes , "
    '            strXML &= "</dataset>"

    '            'ROTOR
    '            strXML &= "<dataset seriesname='ROTOR' Color='008000' alpha='100'>"
    '            Total = XMLStringMinuteLine(strXML, dTable2, CR, StartDate, EndDate, link, 1)
    '            LBTLL.Text += "Rotor = " + Total.ToString("#,##0") + " Minutes."
    '            strXML &= "</dataset>"
    '        Else
    '            strXML &= "<dataset seriesname='" + CR_Detail.ToString + "' Color='9D080D' >"
    '            Total = XMLStringMinuteLine(strXML, dTable2, CR, StartDate, EndDate, link, CR)
    '            LBTLL.Text = CR_Detail.ToString + " Total = " + Total.ToString("#,##0") + " Minutes."
    '            strXML &= "</dataset>"
    '        End If

    '        strXML &= "</graph>"
    '    Catch ex As Exception

    '    End Try

    '    'Create the chart - Column 3D Chart with data from strXML variable using dataXML method
    '    Return FusionCharts.RenderChartHTML("FusionCharts/FCF_StackedColumn2D.swf", "", strXML, "myNext", Width, Height, False)

    'End Function

    'Private Function XMLStringPackoutLine(ByRef strXML As String, ByVal dTable2 As DataTable, ByVal CR As String, _
    '                               ByVal StartDate As DateTime, ByVal EndDate As DateTime) As Double
    '    Dim Total As Double = 0
    '    Dim Day As Double = CDbl(getAmountDay(CR, StartDate, EndDate))

    '    For i As Integer = 0 To dTable2.Rows.Count - 1
    '        Dim Packout As Double = 0
    '        Dim strDate As DateTime = StartDate

    '        While strDate <= EndDate
    '            Packout += getPackout(CR, dTable2.Rows(i)("Line_ID").ToString, strDate) / Day

    '            Total += (Packout / getAmountLine(CR, strDate))

    '            strDate = strDate.AddDays(1)
    '        End While

    '        If Packout > 0 Then
    '            strXML &= "<set value='" + Packout.ToString + "' />"
    '        Else
    '            strXML &= "<set />"
    '        End If
    '    Next

    '    Return Total
    'End Function

    'Private Function XMLStringMinuteLine(ByRef strXML As String, ByVal dTable2 As DataTable, ByVal CR As String, _
    '                               ByVal StartDate As DateTime, ByVal EndDate As DateTime, ByVal link As Boolean, ByVal LineType As Integer) As Integer
    '    Dim Total As Integer = 0
    '    Dim DateStart As Date
    '    Dim DateEnd As Date

    '    For i As Integer = 0 To dTable2.Rows.Count - 1
    '        Dim StrDate1 As DateTime = StartDate
    '        Dim StrDate2 As DateTime = EndDate
    '        Dim Totaltmp As Integer = 0

    '        While StrDate1 <= StrDate2
    '            DateStart = New Date(StrDate1.Year, StrDate1.Month, StrDate1.Day, 8, 0, 0)
    '            DateEnd = New Date(StrDate1.Year, StrDate1.Month, StrDate1.Day, 7, 59, 59).AddDays(1)

    '            SQL = "SELECT Sum(Total) As MTTotal, Sum(PCE_Total) As PCETotal FROM DownTimeRecord"
    '            SQL += " INNER JOIN ModelRelation ON ModelRelation.ML_ID=DownTimeRecord.ML_ID"
    '            SQL += " INNER JOIN Line ON ModelRelation.Line_ID=Line.Line_ID"
    '            SQL += " INNER JOIN ProcessRelation ON ProcessRelation.PL_ID=DownTimeRecord.PL_ID"
    '            SQL += " INNER JOIN Process ON Process.Process_ID=ProcessRelation.Process_ID"
    '            SQL += " INNER JOIN LineType ON LineType.TY_ID=Process.TY_ID"
    '            SQL += " LEFT JOIN PCEData ON PCEData.DT_ID=DownTimeRecord.DT_ID"

    '            SQL += " WHERE Line.Line_ID='" + dTable2.Rows(i)("Line_ID").ToString + "'"
    '            SQL += " AND LineType.TY_ID='" + LineType.ToString + "'"
    '            SQL += " AND DT_Status = 1" 'AND ProcessRelation_Status=1"
    '            SQL += " AND (StartTime >= '" + DateStart.ToString("yyyy/MM/dd HH:mm:ss") + "'"
    '            SQL += " AND StartTime <= '" + DateEnd.ToString("yyyy/MM/dd HH:mm:ss") + "')"
    '            dTable = DownTime.DataAccessLayer.DataAccess.GetDs(SQL).Tables(0).Copy

    '            If dTable.Rows.Count > 0 Then
    '                Dim sum As Integer = 0

    '                If Not IsDBNull(dTable.Rows(0)("MTTotal")) Then
    '                    sum += CInt(dTable.Rows(0)("MTTotal"))
    '                End If

    '                If Not IsDBNull(dTable.Rows(0)("PCETotal")) Then
    '                    sum += CInt(dTable.Rows(0)("PCETotal"))
    '                End If

    '                Totaltmp += sum
    '                'AVG += sum / getAmountLine(CR, DateStart)

    '            End If

    '            StrDate1 = StrDate1.AddDays(1)
    '        End While

    '        If Totaltmp > 0 Then
    '            strXML &= "<set value='" + Totaltmp.ToString + "'"
    '            If link Then
    '                strXML &= " link='n-DataByLine.aspx%3FLine%3D" & dTable2.Rows(i)("Line_ID").ToString & _
    '                           "%26Start%3D" & StartDate.ToString("dd-MM-yyyy") & _
    '                           "%26End%3D" & EndDate.ToString("dd-MM-yyyy") & _
    '                           "%26LineType%3D" & LineType.ToString & "'"
    '            End If
    '            strXML &= " />"
    '            Total += Totaltmp
    '        Else
    '            strXML &= "<set />"
    '        End If

    '    Next
    '    Return Total
    'End Function
    'Private Function XMLStringMinuteLine(ByRef strXML As String, ByVal dTable2 As DataTable, ByVal CR As String, _
    '                               ByVal StartDate As DateTime, ByVal EndDate As DateTime, ByVal link As Boolean, ByVal LineType As Integer) As Integer
    '    Dim Total As Integer = 0
    '    Dim DateStart As Date
    '    Dim DateEnd As Date

    '    For i As Integer = 0 To dTable2.Rows.Count - 1
    '        Dim StrDate1 As DateTime = StartDate
    '        Dim StrDate2 As DateTime = EndDate
    '        Dim Totaltmp As Integer = 0

    '        Select Case Type
    '            Case 1
    '                While StrDate1 <= StrDate2
    '                    DateStart = New Date(StrDate1.Year, StrDate1.Month, StrDate1.Day, 8, 0, 0)
    '                    DateEnd = New Date(StrDate1.Year, StrDate1.Month, StrDate1.Day, 7, 59, 59).AddDays(1)

    '                    SQL = "SELECT Sum(Total) As SumTotal FROM DownTimeRecord "
    '                    SQL += " INNER JOIN ModelRelation ON ModelRelation.ML_ID=DownTimeRecord.ML_ID"
    '                    SQL += " INNER JOIN Line ON ModelRelation.Line_ID=Line.Line_ID"
    '                    SQL += " INNER JOIN ProcessRelation ON ProcessRelation.PL_ID=DownTimeRecord.PL_ID"
    '                    SQL += " INNER JOIN Process ON Process.Process_ID=ProcessRelation.Process_ID"
    '                    SQL += " WHERE Line.Line_ID='" + dTable2.Rows(i)("Line_ID").ToString + "'"
    '                    SQL += " AND DT_Status = 1 AND ProcessRelation_Status=1"
    '                    SQL += " AND (StartTime >= '" + DateStart.ToString("yyyy/MM/dd HH:mm:ss") + "'"
    '                    SQL += " AND StartTime <= '" + DateEnd.ToString("yyyy/MM/dd HH:mm:ss") + "')"
    '                    dTable = DownTime.DataAccessLayer.DataAccess.GetDs(SQL).Tables(0).Copy

    '                    If dTable.Rows.Count > 0 Then
    '                        If Not IsDBNull(dTable.Rows(0)("SumTotal")) Then
    '                            Totaltmp += CInt(dTable.Rows(0)("SumTotal"))
    '                            AVG += CInt(dTable.Rows(0)("SumTotal")) / getAmountLine(CR, DateStart)
    '                        End If
    '                    End If

    '                    StrDate1 = StrDate1.AddDays(1)
    '                End While

    '                If Totaltmp > 0 Then
    '                    strXML &= "<set value='" + Totaltmp.ToString + "'"
    '                    If link Then
    '                        strXML &= " link='n-DataByLine.aspx%3FLine%3D" & dTable2.Rows(i)("Line_ID").ToString & _
    '                                   "%26Start%3D" & StartDate.ToString("dd-MM-yyyy") & _
    '                                   "%26End%3D" & EndDate.ToString("dd-MM-yyyy") & _
    '                                   "%26Type%3D" & Type.ToString & "'"
    '                    End If
    '                    strXML &= " />"
    '                    Total += Totaltmp
    '                Else
    '                    strXML &= "<set />"
    '                End If

    '            Case 2
    '                While StrDate1 <= StrDate2
    '                    DateStart = New Date(StrDate1.Year, StrDate1.Month, StrDate1.Day, 8, 0, 0)
    '                    DateEnd = New Date(StrDate1.Year, StrDate1.Month, StrDate1.Day, 7, 59, 59).AddDays(1)

    '                    SQL = "SELECT Sum(PCE_Total) As SumTotal FROM DownTimeRecord "
    '                    SQL += " INNER JOIN ModelRelation ON ModelRelation.ML_ID=DownTimeRecord.ML_ID"
    '                    SQL += " INNER JOIN Line ON ModelRelation.Line_ID=Line.Line_ID"
    '                    SQL += " INNER JOIN ProcessRelation ON ProcessRelation.PL_ID=DownTimeRecord.PL_ID"
    '                    SQL += " INNER JOIN Process ON Process.Process_ID=ProcessRelation.Process_ID"
    '                    SQL += " LEFT JOIN PCEData ON PCEData.DT_ID=DownTimeRecord.DT_ID"
    '                    SQL += " WHERE Line.Line_ID='" + dTable2.Rows(i)("Line_ID").ToString + "'"
    '                    SQL += " AND DT_Status = 1 AND ProcessRelation_Status=1"
    '                    SQL += " AND (StartTime >= '" + DateStart.ToString("yyyy/MM/dd HH:mm:ss") + "'"
    '                    SQL += " AND StartTime <= '" + DateEnd.ToString("yyyy/MM/dd HH:mm:ss") + "')"
    '                    dTable = DownTime.DataAccessLayer.DataAccess.GetDs(SQL).Tables(0).Copy

    '                    If dTable.Rows.Count > 0 Then
    '                        If Not IsDBNull(dTable.Rows(0)("SumTotal")) Then
    '                            Totaltmp += CInt(dTable.Rows(0)("SumTotal"))
    '                            AVG += CInt(dTable.Rows(0)("SumTotal")) / getAmountLine(CR, DateStart)
    '                        End If
    '                    End If

    '                    StrDate1 = StrDate1.AddDays(1)
    '                End While

    '                If Totaltmp > 0 Then
    '                    strXML &= "<set value='" + Totaltmp.ToString + "'"
    '                    If link Then
    '                        strXML &= " link='n-DataByLine.aspx%3FLine%3D" & dTable2.Rows(i)("Line_ID").ToString & _
    '                                   "%26Start%3D" & StartDate.ToString("dd-MM-yyyy") & _
    '                                   "%26End%3D" & EndDate.ToString("dd-MM-yyyy") & _
    '                                   "%26Type%3D" & Type.ToString & "'"
    '                    End If
    '                    strXML &= " />"
    '                    Total += Totaltmp
    '                Else
    '                    strXML &= "<set />"
    '                End If

    '            Case 0
    '                While StrDate1 <= StrDate2
    '                    DateStart = New Date(StrDate1.Year, StrDate1.Month, StrDate1.Day, 8, 0, 0)
    '                    DateEnd = New Date(StrDate1.Year, StrDate1.Month, StrDate1.Day, 7, 59, 59).AddDays(1)

    '                    SQL = "SELECT Sum(Total) As MTTotal, Sum(PCE_Total) As PCETotal FROM DownTimeRecord "
    '                    SQL += " INNER JOIN ModelRelation ON ModelRelation.ML_ID=DownTimeRecord.ML_ID"
    '                    SQL += " INNER JOIN Line ON ModelRelation.Line_ID=Line.Line_ID"
    '                    SQL += " INNER JOIN ProcessRelation ON ProcessRelation.PL_ID=DownTimeRecord.PL_ID"
    '                    SQL += " INNER JOIN Process ON Process.Process_ID=ProcessRelation.Process_ID"
    '                    SQL += " LEFT JOIN PCEData ON PCEData.DT_ID=DownTimeRecord.DT_ID"

    '                    SQL += " WHERE Line.Line_ID='" + dTable2.Rows(i)("Line_ID").ToString + "'"
    '                    SQL += " AND DT_Status = 1 AND ProcessRelation_Status=1"
    '                    SQL += " AND (StartTime >= '" + DateStart.ToString("yyyy/MM/dd HH:mm:ss") + "'"
    '                    SQL += " AND StartTime <= '" + DateEnd.ToString("yyyy/MM/dd HH:mm:ss") + "')"
    '                    dTable = DownTime.DataAccessLayer.DataAccess.GetDs(SQL).Tables(0).Copy

    '                    If dTable.Rows.Count > 0 Then
    '                        Dim sum As Integer = 0

    '                        If Not IsDBNull(dTable.Rows(0)("MTTotal")) Then
    '                            sum += CInt(dTable.Rows(0)("MTTotal"))
    '                        End If

    '                        If Not IsDBNull(dTable.Rows(0)("PCETotal")) Then
    '                            sum += CInt(dTable.Rows(0)("PCETotal"))
    '                        End If

    '                        Totaltmp += sum
    '                        AVG += sum / getAmountLine(CR, DateStart)

    '                    End If

    '                    StrDate1 = StrDate1.AddDays(1)
    '                End While

    '                If Totaltmp > 0 Then
    '                    strXML &= "<set value='" + Totaltmp.ToString + "'"
    '                    If link Then
    '                        strXML &= " link='n-DataByLine.aspx%3FLine%3D" & dTable2.Rows(i)("Line_ID").ToString & _
    '                                   "%26Start%3D" & StartDate.ToString("dd-MM-yyyy") & _
    '                                   "%26End%3D" & EndDate.ToString("dd-MM-yyyy") & _
    '                                   "%26Type%3D" & Type.ToString & "'"
    '                    End If
    '                    strXML &= " />"
    '                    Total += Totaltmp
    '                Else
    '                    strXML &= "<set />"
    '                End If
    '        End Select

    '    Next
    '    Return Total
    'End Function

    'Public Function DTPercentByLineCharts(ByVal CR As String, ByVal CR_Detail As String, ByVal StartDate As DateTime, ByVal EndDate As DateTime, _
    '                                    ByRef LBTLL As Label, ByVal Width As String, ByVal Height As String, ByVal link As Boolean) As String
    '    Dim strXML As String = ""
    '    Dim MTAVG As Double = 0.0
    '    Dim PCEQAAVG As Double = 0.0
    '    Dim ALLAVG As Double = 0.0
    '    Dim Packout As Long = 0

    '    strXML += "<graph bgcolor='ffe1e1' caption='Summary Downtime Percent By Line of " + CR_Detail.ToString
    '    strXML += " on " + getStrDate(StartDate).Replace("'", "%26apos;")
    '    If StartDate <> EndDate Then
    '        strXML += " - " + getStrDate(EndDate).Replace("'", "%26apos;")
    '    End If
    '    strXML += "' xAxisName='Line' PYAxisName='Percent(%25)' SYAxisName='Packout' showvalues='1'"
    '    strXML += " rotateNames='1' PYAxisMaxValue='20.00' thousandSeparator=',' formatNumberScale='1' decimalPrecision='2'>"

    '    Try
    '        Dim dTable2 As DataTable
    '        SQL = "SELECT * FROM Line"
    '        SQL += " WHERE Line_Status=1"
    '        'If CR.ToString <> "0" Then
    '        SQL += " AND CR_ID='" + CR.ToString + "'"
    '        'Else
    '        'SQL += " AND CR_ID IN (2,3)"
    '        'End If
    '        SQL += " ORDER BY Line_Order"
    '        dTable2 = DownTime.DataAccessLayer.DataAccess.GetDs(SQL).Tables(0).Copy

    '        strXML &= "<categories>"
    '        For i As Integer = 0 To dTable2.Rows.Count - 1
    '            strXML &= "<category name='" + dTable2.Rows(i)("Line_Detail").ToString + "'/>"
    '        Next
    '        strXML &= "</categories> "

    '        'MT
    '        strXML &= "<dataset seriesName='ME' color='9D080D'  parentYAxis='P'>"
    '        MTAVG = XMLStringPercentLine(strXML, dTable2, 1, CR, StartDate, EndDate, link)
    '        strXML &= "</dataset>"

    '        'PCE-QA-SETUP
    '        strXML &= "<dataset seriesName='PCE-QA-SETUP' color='B3AA00' parentYAxis='P'>"
    '        PCEQAAVG = XMLStringPercentLine(strXML, dTable2, 2, CR, StartDate, EndDate, link)
    '        strXML &= "</dataset>"

    '        'ALL
    '        strXML &= "<dataset seriesName='ALL' color='56B9F9' parentYAxis='P'>"
    '        ALLAVG = XMLStringPercentLine(strXML, dTable2, 0, CR, StartDate, EndDate, link)
    '        strXML &= "</dataset>"

    '        'Packout
    '        'strXML &= "<dataset seriesName='AVG Packout' Color='0000FF' parentYAxis='S' >"
    '        'Packout = XMLStringPackoutLine(strXML, dTable2, CR, StartDate, EndDate)
    '        'strXML &= "</dataset>"

    '        'strXML &= "<trendlines>"
    '        'strXML &= "<line startValue='" + MTAVG.ToString("##0.00") + "' displayValue='AVG " + MTAVG.ToString("##0.00") + "%25' color='9D080D' thickness='1' showOnTop='1'/>"
    '        'strXML &= "<line startValue='" + PCEQAAVG.ToString("##0.00") + "' displayValue='AVG " + PCEQAAVG.ToString("##0.00") + "%25' color='B3AA00' thickness='1' showOnTop='1'/>"
    '        'strXML &= "<line startValue='" + ALLAVG.ToString("##0.00") + "' displayValue='ALL AVG " + ALLAVG.ToString("##0.00") + "%25' color='56B9F9' thickness='1' showOnTop='1'/>"
    '        'strXML &= "</trendlines>"

    '        LBTLL.Text = CR_Detail.ToString + " ME = " + MTAVG.ToString("##0.00") + "%, "
    '        LBTLL.Text += "PCE-QA-SETUP = " + PCEQAAVG.ToString("##0.00") + "%, "
    '        LBTLL.Text += "ALL AVG = " + ALLAVG.ToString("##0.00") + "%"

    '        strXML = strXML & "</graph>"
    '    Catch ex As Exception

    '    End Try

    '    Return FusionCharts.RenderChartHTML("FusionCharts/FCF_MSColumn2DLineDY.swf", "", strXML, "myNext1", Width, Height, False)
    'End Function

    'Private Function XMLStringPercentLine(ByRef strXML As String, ByVal dTable4 As DataTable, ByVal Type As Integer, ByVal CR As String, _
    '                               ByVal StartDate As DateTime, ByVal EndDate As DateTime, ByVal link As Boolean) As Double
    '    Dim AVG As Double = 0.0
    '    Dim DateStart As Date
    '    Dim DateEnd As Date

    '    For i As Integer = 0 To dTable4.Rows.Count - 1
    '        Dim StrDate1 As DateTime = StartDate
    '        Dim StrDate2 As DateTime = EndDate
    '        Dim TotalPercent As Double = 0.0

    '        While StrDate1 <= StrDate2
    '            Dim TmpPercent As Double = 0.0
    '            DateStart = New Date(StrDate1.Year, StrDate1.Month, StrDate1.Day, 8, 0, 0)
    '            DateEnd = New Date(StrDate1.Year, StrDate1.Month, StrDate1.Day, 7, 59, 59).AddDays(1)

    '            SQL = "SELECT Total,PCE_Total,QTY FROM DownTimeRecord "
    '            SQL += " INNER JOIN ProcessRelation ON ProcessRelation.PL_ID=DownTimeRecord.PL_ID"
    '            SQL += " INNER JOIN Line ON Line.Line_ID=ProcessRelation.Line_ID "
    '            SQL += " INNER JOIN Process ON Process.Process_ID=ProcessRelation.Process_ID "
    '            SQL += " LEFT JOIN PCEData ON PCEData.DT_ID=DowntimeRecord.DT_ID"

    '            SQL += " WHERE Line.Line_ID='" + dTable4.Rows(i)("Line_ID").ToString + "'"
    '            SQL += " AND DT_Status = 1 AND ProcessRelation_Status=1"
    '            SQL += " AND (StartTime >= '" + DateStart.ToString("yyyy/MM/dd HH:mm:ss") + "'"
    '            SQL += " AND StartTime <= '" + DateEnd.ToString("yyyy/MM/dd HH:mm:ss") + "')"
    '            dTable = DownTime.DataAccessLayer.DataAccess.GetDs(SQL).Tables(0).Copy

    '            If dTable.Rows.Count > 0 Then
    '                Select Case Type
    '                    Case 1
    '                        For j As Integer = 0 To dTable.Rows.Count - 1
    '                            If Not IsDBNull(dTable.Rows(j)("Total")) Then
    '                                'ECM
    '                                If CR.ToString <> "4" Then
    '                                    TmpPercent += CDbl(dTable.Rows(j)("Total")) / (CDbl(dTable.Rows(j)("QTY") * 12.6))
    '                                Else
    '                                    TmpPercent += CDbl(dTable.Rows(j)("Total")) / 12.6
    '                                End If
    '                            End If
    '                        Next

    '                    Case 2
    '                        For j As Integer = 0 To dTable.Rows.Count - 1
    '                            If Not IsDBNull(dTable.Rows(j)("PCE_Total")) Then
    '                                'ECM
    '                                If CR.ToString <> "4" Then
    '                                    TmpPercent += CDbl(dTable.Rows(j)("PCE_Total")) / (CDbl(dTable.Rows(j)("QTY") * 12.6))
    '                                Else
    '                                    TmpPercent += CDbl(dTable.Rows(j)("PCE_Total")) / 12.6
    '                                End If
    '                            End If
    '                        Next

    '                    Case 0
    '                        For j As Integer = 0 To dTable.Rows.Count - 1
    '                            Dim sum As Integer = 0

    '                            If Not IsDBNull(dTable.Rows(j)("Total")) Then
    '                                sum += CInt(dTable.Rows(j)("Total"))
    '                            End If

    '                            If Not IsDBNull(dTable.Rows(j)("PCE_Total")) Then
    '                                sum += CInt(dTable.Rows(j)("PCE_Total"))
    '                            End If

    '                            'ECM
    '                            If CR.ToString <> "4" Then
    '                                TmpPercent += CDbl(sum) / (CDbl(dTable.Rows(j)("QTY") * 12.6))
    '                            Else
    '                                TmpPercent += CDbl(sum) / 12.6
    '                            End If
    '                        Next
    '                End Select

    '                If TmpPercent > 0 Then
    '                    AVG += TmpPercent / getAmountLine(CR, DateStart)
    '                    TotalPercent += TmpPercent
    '                End If

    '            End If

    '            StrDate1 = StrDate1.AddDays(1)
    '        End While

    '        TotalPercent /= getAmountDay(CR, StartDate, EndDate)

    '        If TotalPercent > 0 Then
    '            strXML &= "<set value='" + TotalPercent.ToString("##0.00") + "'"
    '            If link Then
    '                strXML &= " link='n-DataByLine.aspx%3FLine%3D" & dTable4.Rows(i)("Line_ID").ToString & _
    '                                  "%26Start%3D" & StartDate.ToString("dd-MM-yyyy") & _
    '                                  "%26End%3D" & EndDate.ToString("dd-MM-yyyy") & _
    '                                  "%26Type%3D" & Type.ToString & "'"
    '            End If
    '            strXML &= " />"
    '        Else
    '            strXML &= "<set />"
    '        End If
    '    Next

    '    Return AVG / getAmountDay(CR, StartDate, EndDate)
    'End Function
    'Public Function DTPercentByDailyCharts(ByVal CR As String, ByVal CR_Detail As String, ByVal StartDate As DateTime, ByVal EndDate As DateTime, _
    '                                    ByRef LBTLL As Label, ByVal Width As String, ByVal Height As String) As String

    '    Dim strXML As String = ""
    '    Dim TotalMT As Double = 0.0
    '    Dim TotalPCEQA As Double = 0.0
    '    Dim TotalALL As Double = 0.0

    '    Dim StrDate1 As DateTime = StartDate

    '    strXML = strXML & "<graph bgcolor='F3f3f3' caption='Summary Downtime Percent By Daily of " + CR_Detail.ToString
    '    strXML += " on " + getStrDate(StartDate).Replace("'", "%26apos;")
    '    If StartDate <> EndDate Then
    '        strXML += " - " + getStrDate(EndDate).Replace("'", "%26apos;")
    '    End If
    '    strXML += "' xAxisName='Date' yAxisName='Percent(%25)' decimalPrecision='2' formatNumberScale='0'"
    '    strXML += " yAxisMinValue='0.00' xAxisMaxValue='100.00' numberSuffix='%25' rotateNames='1' showvalues='1' >"

    '    strXML &= "<categories>"
    '    While StrDate1 <= EndDate
    '        strXML &= "<category name='" + getStrDate(StrDate1).Replace("'", "%26apos;") + "'/>"
    '        StrDate1 = StrDate1.AddDays(1)
    '    End While
    '    strXML &= "</categories>"

    '    Try
    '        'MT
    '        strXML &= "<dataset seriesName='MT' color='9D080D' anchorBorderColor='9D080D' anchorBgColor='FFFFFF'>"
    '        TotalMT = XMLStringPercentDialy(strXML, 1, CR, StartDate, EndDate)
    '        strXML &= "</dataset>"

    '        'PCE-QA-SETUP
    '        strXML &= "<dataset seriesName='PCE-QA-SETUP' color='B3AA00' anchorBorderColor='B3AA00' anchorBgColor='FFFFFF'>"
    '        TotalPCEQA = XMLStringPercentDialy(strXML, 2, CR, StartDate, EndDate)
    '        strXML &= "</dataset>"

    '        'ALL
    '        strXML &= "<dataset seriesName='ALL' color='56B9F9' anchorBorderColor='56B9F9' anchorBgColor='FFFFFF'>"
    '        TotalALL = XMLStringPercentDialy(strXML, 0, CR, StartDate, EndDate)
    '        strXML &= "</dataset>"

    '        strXML &= "<trendlines>"
    '        strXML &= "<line startValue='" + TotalMT.ToString("##0.00") + "' displayValue='AVG " + TotalMT.ToString("##0.00") + "%25' color='9D080D' thickness='1' showOnTop='1'/>"
    '        strXML &= "<line startValue='" + TotalPCEQA.ToString("##0.00") + "' displayValue='AVG " + TotalPCEQA.ToString("##0.00") + "%25' color='B3AA00' thickness='1' showOnTop='1'/>"
    '        strXML &= "<line startValue='" + TotalALL.ToString("##0.00") + "' displayValue='ALL AVG " + TotalALL.ToString("##0.00") + "%25' color='56B9F9' thickness='1' showOnTop='1'/>"
    '        strXML &= "</trendlines>"

    '        strXML = strXML & "</graph>"

    '        LBTLL.Text = CR_Detail + " MT = " + TotalMT.ToString("##0.00") + "%,"
    '        LBTLL.Text += " PCE-QA-SETUP = " + TotalPCEQA.ToString("##0.00") + "%,"
    '        LBTLL.Text += " ALL = " + TotalALL.ToString("##0.00") + "%"
    '    Catch ex As Exception

    '    End Try

    '    'Create the chart - Column 3D Chart with data from strXML variable using dataXML method
    '    Return FusionCharts.RenderChartHTML("FusionCharts/FCF_MSLine.swf", "", strXML, "myNext2", Width, Height, False)
    'End Function
    'Public Function XMLStringPercentDialy(ByRef strXML As String, ByVal Type As Integer, ByVal CR As String, ByVal StartDate As DateTime, ByVal EndDate As DateTime) As Double
    '    Dim Total As Double = 0.0
    '    Dim DateStart As DateTime
    '    Dim DateEnd As DateTime

    '    Dim Day As Integer = getAmountDay(CR, StartDate, EndDate)

    '    While StartDate <= EndDate
    '        Dim Percent As Double = 0.0

    '        If StartDate > Date.Now Then
    '            strXML = strXML & "<set />"
    '        End If

    '        DateStart = GetDateStart(StartDate.ToString("dd-MM-yyyy"))
    '        DateEnd = GetDateEnd(StartDate.ToString("dd-MM-yyyy"))

    '        SQL = " SELECT Total,QTY,PCE_Total FROM DownTimeRecord "
    '        SQL += " INNER JOIN ProcessRelation ON ProcessRelation.PL_ID=DownTimeRecord.PL_ID"
    '        SQL += " INNER JOIN Process ON Process.Process_ID=ProcessRelation.Process_ID"
    '        SQL += " INNER JOIN Line ON Line.Line_ID=ProcessRelation.Line_ID "
    '        SQL += " INNER JOIN CleanRoom ON Line.CR_ID=CleanRoom.CR_ID"
    '        SQL += " LEFT JOIN PCEData ON PCEData.DT_ID=DownTimeRecord.DT_ID"

    '        SQL += " WHERE DT_Status = 1 AND Line_Status=1 AND ProcessRelation_Status=1"
    '        SQL += " AND (StartTime >= '" + DateStart.ToString("yyyy/MM/dd HH:mm:ss") + "'"
    '        SQL += " AND StartTime <='" + DateEnd.ToString("yyyy/MM/dd HH:mm:ss") + "')"

    '        If CR.ToString <> "0" Then
    '            SQL += " AND CleanRoom.CR_ID='" + CR.ToString + "'"
    '        Else
    '            SQL += " AND CleanRoom.CR_ID IN (2,3)"
    '        End If

    '        SQL += " ORDER BY Line.Line_ID"
    '        dTable = DownTime.DataAccessLayer.DataAccess.GetDs(SQL).Tables(0).Copy

    '        If dTable.Rows.Count > 0 Then
    '            For j As Integer = 0 To dTable.Rows.Count - 1
    '                Select Case Type
    '                    Case 1
    '                        Percent += CDbl(dTable.Rows(j)("Total")) / (CDbl(dTable.Rows(j)("QTY") * 12.6))

    '                    Case 2
    '                        If Not IsDBNull(dTable.Rows(j)("PCE_Total")) Then
    '                            Percent += CDbl(dTable.Rows(j)("PCE_Total")) / (CDbl(dTable.Rows(j)("QTY") * 12.6))
    '                        End If

    '                    Case 0
    '                        If Not IsDBNull(dTable.Rows(j)("PCE_Total")) Then
    '                            Percent += CDbl(dTable.Rows(j)("PCE_Total")) / (CDbl(dTable.Rows(j)("QTY") * 12.6))
    '                        End If

    '                        Percent += CDbl(dTable.Rows(j)("Total")) / (CDbl(dTable.Rows(j)("QTY") * 12.6))

    '                End Select
    '            Next

    '            Percent /= CDbl(getAmountLine(CR.ToString, DateStart))

    '            If Percent > 0 Then
    '                strXML &= "<set value='" + Percent.ToString("##0.00") + "'"

    '                strXML = strXML & " link='n-DataByDaily.aspx%3FCR%3D" & CR.ToString & _
    '                                  "%26Date%3D" & DateStart.ToString("dd-MM-yyyy") & _
    '                                  "%26Type%3D" & Type.ToString & "'"
    '                strXML &= " />"
    '            Else
    '                strXML = strXML & "<set />"
    '            End If

    '            Total += Percent
    '        Else
    '            strXML = strXML & "<set />"
    '        End If

    '        StartDate = StartDate.AddDays(1)
    '    End While

    '    Return Total / Day
    'End Function
    'Public Function TOP5ByProblemChart(ByVal CR As String, ByVal CR_Detail As String, ByVal StartDate As DateTime, ByVal EndDate As DateTime, _
    '                                     ByVal Width As String, ByVal Height As String, ByVal line As String, ByVal line_Detail As String, ByVal isLink As Boolean, ByVal LTID As String) As String

    '    Dim StrDate1 As DateTime = GetDateStart(StartDate.ToString("dd-MM-yyyy"))
    '    Dim StrDate2 As DateTime = GetDateEnd(EndDate.ToString("dd-MM-yyyy"))

    '    Dim strXML As String = ""

    '    strXML = strXML & "<graph bgcolor='ffe1e1' caption='TOP-5 by Problem of " + CR_Detail.ToString
    '    If Not line_Detail Is Nothing Then
    '        strXML += " - " + line_Detail.ToString
    '    End If
    '    If StartDate = EndDate Then
    '        strXML += "' subCaption='Date : " + getStrDate(StartDate).Replace("'", "%26apos;") + "'"
    '    Else
    '        strXML += "' subCaption='Date : " + getStrDate(StartDate).Replace("'", "%26apos;")
    '        strXML += " - " + getStrDate(EndDate).Replace("'", "%26apos;") + "'"
    '    End If

    '    strXML += " xAxisName='Problem' yAxisMinValue='0' SYAxisMaxValue='10' formatNumberScale='0' decimalPrecision='2' limitsDecimalPrecision='0'"
    '    strXML += " PYAxisName='Minutes' SYAxisName='Percent(%25)' rotateNames='1' thousandSeparator=',' baseFontSize='10' baseFont='Arial' outCnvBaseFontSize='12' showLegend='0'>"

    '    Try
    '        SQL = "SELECT TOP 5 (ISNULL(Sum(Total),0) + ISNULL(Sum(PCE_Total),0)) As Total,"
    '        SQL += " ISNULL(LT_Code,'N/A') AS LT_Code, ISNULL(LT_Mean,'Undefine') AS LT_Mean, ISNULL(LossTimeCode.LT_ID,'0') AS LT_ID FROM DownTimeRecord"

    '        SQL += " INNER JOIN ModelRelation ON ModelRelation.ML_ID=DownTimeRecord.ML_ID"
    '        SQL += " INNER JOIN Line ON ModelRelation.Line_ID=Line.Line_ID"
    '        SQL += " INNER JOIN CleanRoom ON CleanRoom.CR_ID=Line.CR_ID"
    '        'SQL += " INNER JOIN ProcessRelation ON ProcessRelation.PL_ID=DowntimeRecord.PL_ID"
    '        'SQL += " INNER JOIN Process ON Process.Process_ID=ProcessRelation.Process_ID"
    '        'SQL += " INNER JOIN LineType ON LineType.TY_ID=Process.TY_ID"
    '        SQL += " LEFT JOIN LossTimeRelation ON LossTimeRelation.DT_ID=DownTimeRecord.DT_ID"
    '        SQL += " LEFT JOIN LossTimeDetail ON LossTimeDetail.LTD_ID=LossTimeRelation.LTD_ID"
    '        SQL += " LEFT JOIN LossTimeCode ON LossTimeCode.LT_ID=LossTimeDetail.LT_ID "
    '        SQL += " LEFT JOIN PCEData ON PCEData.DT_ID=DownTimeRecord.DT_ID"

    '        SQL += " WHERE CleanRoom.CR_ID='" + CR.ToString + "'"

    '        If Not line Is Nothing Then
    '            SQL += " AND Line.Line_ID='" + line.ToString + "'"
    '        Else
    '            SQL += " AND Line_Status=1"
    '        End If

    '        If LTID <> "0" Then
    '            SQL += " AND LossTimeDetail.LT_ID='" + LTID.ToString + "'"
    '        End If

    '        SQL += " AND DT_Status = 1"
    '        SQL += " AND (StartTime >= '" + StrDate1.ToString("yyyy/MM/dd HH:mm:ss") + "' "
    '        SQL += " AND StartTime <= '" + StrDate2.ToString("yyyy/MM/dd HH:mm:ss") + "')"

    '        SQL += " GROUP BY LT_Code,LT_Mean,LossTimeCode.LT_ID"
    '        SQL += " ORDER BY Total DESC"

    '        dTable = DownTime.DataAccessLayer.DataAccess.GetDs(SQL).Tables(0).Copy

    '        If dTable.Rows.Count > 0 Then
    '            ' Name - X Axis
    '            strXML &= "<categories fontSize='11'>"
    '            For i As Integer = 0 To dTable.Rows.Count - 1
    '                strXML &= "<category name='" + dTable.Rows(i)("LT_Code").ToString + ":" + dTable.Rows(i)("LT_Mean").ToString.Replace("&", "%26") + "'/>"
    '            Next
    '            strXML &= "</categories>"

    '            ' Value (Minutes)
    '            strXML += "<dataset seriesName='Minute' parentYAxis='P' color='B3AA00' showValues='1'>"
    '            For i As Integer = 0 To dTable.Rows.Count - 1

    '                strXML = strXML & "<set value='" + dTable.Rows(i)("Total").ToString + "'"

    '                If isLink Then
    '                    strXML = strXML & " link='n-DataByProblem.aspx%3FCR%3D" + CR.ToString
    '                    If Not line Is Nothing Then
    '                        strXML = strXML & "%26Line%3D" & line.ToString
    '                    End If
    '                    strXML = strXML & "%26LTID%3D" & dTable.Rows(i)("LT_ID").ToString
    '                    strXML = strXML & "%26Start%3D" & StartDate.ToString("dd-MM-yyyy")
    '                    strXML = strXML & "%26End%3D" & EndDate.ToString("dd-MM-yyyy") + "'"
    '                End If

    '                strXML = strXML & " />"
    '            Next
    '            strXML += "</dataset>"

    '            ' Value (Percent)
    '            Dim Day As Integer = getAmountDay(CR, StartDate, EndDate)
    '            strXML += "<dataset seriesName='Percent' parentYAxis='S' color='006600' numberSuffix='%25' showValues='1' anchorRadius='3' anchorBorderColor='009900'>"
    '            For i As Integer = 0 To dTable.Rows.Count - 1

    '                strXML = strXML & "<set value='" + (CDbl(dTable.Rows(i)("Total")) / _
    '                                 12.6 * CDbl(Day)).ToString("##0.00") + "'"

    '                If isLink Then
    '                    strXML = strXML & " link='n-DataByProblem.aspx%3FCR%3D" + CR.ToString
    '                    If Not line Is Nothing Then
    '                        strXML = strXML & "%26Line%3D" & line.ToString
    '                    End If
    '                    strXML = strXML & "%26LTID%3D" & dTable.Rows(i)("LT_ID").ToString
    '                    strXML = strXML & "%26Start%3D" & StartDate.ToString("dd-MM-yyyy")
    '                    strXML = strXML & "%26End%3D" & EndDate.ToString("dd-MM-yyyy") + "'"
    '                End If

    '                strXML = strXML & " />"

    '            Next
    '            strXML += "</dataset>"
    '        End If

    '    Catch ex As Exception

    '    End Try

    '    strXML = strXML & "</graph>"

    '    'Create the chart - Column 3D Chart with data from strXML variable using dataXML method
    '    Return FusionCharts.RenderChartHTML("FusionCharts/FCF_MSColumn3DLineDY.swf", "", strXML, "myNext3", Width, Height, False)

    'End Function

    'Public Function TOP5ByProblemDetailChart(ByVal CR As String, ByVal CR_Detail As String, ByVal StartDate As DateTime, ByVal EndDate As DateTime, _
    '                                     ByVal Width As String, ByVal Height As String, ByVal line As String, ByVal line_Detail As String, ByVal isLink As Boolean, ByVal LTID As String) As String
    '    Dim StrDate1 As DateTime = GetDateStart(StartDate.ToString("dd-MM-yyyy"))
    '    Dim StrDate2 As DateTime = GetDateEnd(EndDate.ToString("dd-MM-yyyy"))

    '    Dim strXML As String = ""

    '    strXML = strXML & "<graph  bgcolor='e0f8e0' caption='TOP-5 by Problem detail of " + CR_Detail.ToString

    '    If Not line_Detail Is Nothing Then
    '        strXML += " - " + line_Detail.ToString
    '    End If

    '    If StartDate = EndDate Then
    '        strXML += "' subcaption='Date : " + getStrDate(StartDate).Replace("'", "%26apos;") + "'"
    '    Else
    '        strXML += "' subcaption='Date : " + getStrDate(StartDate).Replace("'", "%26apos;")
    '        strXML += " - " + getStrDate(EndDate).Replace("'", "%26apos;") + "'"
    '    End If

    '    strXML += " xAxisName='Problem detail / Line' yAxisMinValue='0' formatNumberScale='0' SYAxisMaxValue='10' decimalPrecision='2' limitsDecimalPrecision='0'"
    '    strXML += " PYAxisName='Minutes' SYAxisName='Percent(%25)' rotateNames='1' thousandSeparator=',' baseFontSize='10' baseFont='Arial' outCnvBaseFontSize='12' showLegend='0' >"

    '    Try
    '        SQL = "SELECT TOP 5 (ISNULL(sum(Total),0) + ISNULL(sum(PCE_Total),0)) As Total,"
    '        SQL += " Line.Line_ID,Line_Detail,ISNULL(LT_Code,'N/A') AS LT_Code,ISNULL(LTD_ORDER,0) AS LTD_ORDER,"
    '        SQL += " ISNULL(LTD_Detail,'Undefine') AS LTD_Detail,ISNULL(LossTimeDetail.LTD_ID,0) AS LTD_ID,"
    '        SQL += " ISNULL(LT_Mean,'Undefine') AS LT_Mean FROM DownTimeRecord"

    '        SQL += " INNER JOIN ProcessRelation ON ProcessRelation.PL_ID=DowntimeRecord.PL_ID"
    '        SQL += " INNER JOIN Line ON ProcessRelation.Line_ID=Line.Line_ID"
    '        SQL += " INNER JOIN CleanRoom ON CleanRoom.CR_ID=Line.CR_ID"
    '        'SQL += " INNER JOIN Process ON ProcessRelation.Process_ID=Process.Process_ID"
    '        'SQL += " INNER JOIN LineType ON Process.TY_ID=LineType.TY_ID"
    '        SQL += " LEFT JOIN LossTimeRelation ON LossTimeRelation.DT_ID=DownTimeRecord.DT_ID"
    '        SQL += " LEFT JOIN LossTimeDetail ON LossTimeDetail.LTD_ID=LossTimeRelation.LTD_ID"
    '        SQL += " LEFT JOIN LossTimeCode ON LossTimeCode.LT_ID=LossTimeDetail.LT_ID"
    '        SQL += " LEFT JOIN PCEData ON PCEData.DT_ID=DownTimeRecord.DT_ID"

    '        SQL += " WHERE CleanRoom.CR_ID='" + CR.ToString + "'"

    '        If Not line Is Nothing Then
    '            SQL += " AND Line.Line_ID='" + line.ToString + "'"
    '        Else
    '            SQL += " AND Line_Status=1"
    '        End If

    '        If LTID <> "0" Then
    '            SQL += " AND LossTimeDetail.LT_ID='" + LTID.ToString + "'"
    '        End If

    '        SQL += " AND DT_Status = 1"
    '        SQL += " AND (StartTime >= '" + StrDate1.ToString("yyyy/MM/dd HH:mm:ss") + "' "
    '        SQL += " AND StartTime <= '" + StrDate2.ToString("yyyy/MM/dd HH:mm:ss") + "')"

    '        SQL += " GROUP BY Line.Line_ID,Line_Detail,LossTimeDetail.LTD_ID,LTD_Detail,LTD_Order,LT_Code,LT_Mean"
    '        SQL += " ORDER BY Total DESC"

    '        dTable = DownTime.DataAccessLayer.DataAccess.GetDs(SQL).Tables(0).Copy

    '        If dTable.Rows.Count > 0 Then
    '            ' Name - X Axis
    '            Dim str As String = ""

    '            strXML &= "<categories fontSize='11'>"
    '            For i As Integer = 0 To dTable.Rows.Count - 1
    '                strXML &= "<category name='" + (dTable.Rows(i)("LT_Code").ToString + ":" + dTable.Rows(i)("LT_Mean").ToString).Replace("&", "%26") + " - " + dTable.Rows(i)("Line_Detail") + "'"

    '                str = dTable.Rows(i)("LT_Code").ToString
    '                If CInt(dTable.Rows(i)("LTD_Order")) >= 1 Then
    '                    str += dTable.Rows(i)("LTD_Order").ToString
    '                End If
    '                str += ":" + dTable.Rows(i)("LTD_Detail").ToString

    '                strXML &= " hoverText='" + str.Replace("&", "%26") + " - " + dTable.Rows(i)("Line_Detail") + "' />"
    '            Next
    '            strXML &= "</categories>"

    '            ' Value (Minutes)
    '            strXML += "<dataset seriesName='Minute' parentYAxis='P' color='AFD8F8' showValues='1'>"
    '            For i As Integer = 0 To dTable.Rows.Count - 1

    '                strXML = strXML & "<set value='" + dTable.Rows(i)("Total").ToString + "'"

    '                If isLink Then
    '                    strXML = strXML & " link='n-DataByProblemDetail.aspx%3FLTDID%3D" + dTable.Rows(i)("LTD_ID").ToString
    '                    strXML = strXML & "%26Start%3D" & StartDate.ToString("dd-MM-yyyy")
    '                    strXML = strXML & "%26End%3D" & EndDate.ToString("dd-MM-yyyy")
    '                    strXML = strXML & "%26Line%3D" & dTable.Rows(i)("Line_ID").ToString + "'"
    '                End If

    '                strXML = strXML & " />"

    '            Next
    '            strXML += "</dataset>"

    '            ' Value (Percent)
    '            Dim Day As Integer = getAmountDay(CR, StartDate, EndDate)
    '            strXML += "<dataset seriesName='Percent' parentYAxis='S' color='006600' numberSuffix='%25' showValues='1' anchorRadius='3' anchorBorderColor='009900'>"
    '            For i As Integer = 0 To dTable.Rows.Count - 1

    '                strXML = strXML & "<set value='" + (CDbl(dTable.Rows(i)("Total")) / (12.6 * CDbl(Day))).ToString("##0.00") + "'"

    '                If isLink Then
    '                    strXML = strXML & " link='n-DataByProblemDetail.aspx%3FLTDID%3D" + dTable.Rows(i)("LTD_ID").ToString
    '                    strXML = strXML & "%26Start%3D" & StartDate.ToString("dd-MM-yyyy")
    '                    strXML = strXML & "%26End%3D" & EndDate.ToString("dd-MM-yyyy")
    '                    strXML = strXML & "%26Line%3D" & dTable.Rows(i)("Line_ID").ToString + "'"
    '                End If

    '                strXML = strXML & " />"

    '            Next
    '            strXML += "</dataset>"
    '        End If

    '    Catch ex As Exception

    '    End Try

    '    strXML = strXML & "</graph>"

    '    'Create the chart - Column 3D Chart with data from strXML variable using dataXML method
    '    Return FusionCharts.RenderChartHTML("FusionCharts/FCF_MSColumn3DLineDY.swf", "", strXML, "myNext4", Width, Height, False)

    'End Function
    'Public Function TOP5ByMachineChart(ByVal CR As String, ByVal CR_Detail As String, ByVal StartDate As DateTime, ByVal EndDate As DateTime, _
    '                                     ByVal Width As String, ByVal Height As String, ByVal line As String, ByVal line_Detail As String, ByVal isLink As Boolean, ByVal LTID As String) As String
    '    Dim StrDate1 As DateTime = GetDateStart(StartDate.ToString("dd-MM-yyyy"))
    '    Dim StrDate2 As DateTime = GetDateEnd(EndDate.ToString("dd-MM-yyyy"))

    '    Dim strXML As String = ""
    '    Dim LT As String = ""

    '    strXML = strXML & "<graph  bgcolor='f2e9f7' caption='TOP-5 Loss-Time by MC of " + CR_Detail.ToString

    '    If Not line_Detail Is Nothing Then
    '        strXML += " - " + line_Detail.ToString
    '    End If

    '    If LTID <> "0" Then
    '        SQL = "SELECT * FROM LossTimeCode WHERE LT_ID='" + LTID.ToString + "'"
    '        dTable = DownTime.DataAccessLayer.DataAccess.GetDs(SQL).Tables(0).Copy

    '        LT = "[" + dTable.Rows(0)("LT_Code").ToString + ":" + dTable.Rows(0)("LT_Mean").ToString.Replace("&", "%26") + "]"
    '    End If

    '    strXML += "' subcaption='" + LT.ToString

    '    If StartDate = EndDate Then
    '        strXML += " Date : " + getStrDate(StartDate).Replace("'", "%26apos;") + "'"
    '    Else
    '        strXML += " Date : " + getStrDate(StartDate).Replace("'", "%26apos;")
    '        strXML += " - " + getStrDate(EndDate).Replace("'", "%26apos;") + "'"
    '    End If

    '    strXML += " xAxisName='Machine' yAxisMinValue='0' formatNumberScale='0' SYAxisMaxValue='10' decimalPrecision='2' limitsDecimalPrecision='0'"
    '    strXML += " PYAxisName='Minutes' SYAxisName='Percent(%25)' rotateNames='1' thousandSeparator=',' baseFontSize='10' baseFont='Arial' outCnvBaseFontSize='12' showLegend='0' >"

    '    Try
    '        SQL = "SELECT TOP 5 (ISNULL(sum(Total),0) + ISNULL(sum(PCE_Total),0)) As Total,ProcessName,ProcessRelation.PL_ID FROM DownTimeRecord"

    '        SQL += " INNER JOIN ProcessRelation ON ProcessRelation.PL_ID=DowntimeRecord.PL_ID"
    '        SQL += " INNER JOIN Line ON ProcessRelation.Line_ID=Line.Line_ID"
    '        SQL += " INNER JOIN CleanRoom ON CleanRoom.CR_ID=Line.CR_ID"
    '        SQL += " INNER JOIN Process ON ProcessRelation.Process_ID=Process.Process_ID"
    '        SQL += " LEFT JOIN LossTimeRelation ON LossTimeRelation.DT_ID=DownTimeRecord.DT_ID"
    '        SQL += " LEFT JOIN LossTimeDetail ON LossTimeDetail.LTD_ID=LossTimeRelation.LTD_ID"
    '        SQL += " LEFT JOIN PCEData ON PCEData.DT_ID=DownTimeRecord.DT_ID"

    '        SQL += " WHERE CleanRoom.CR_ID='" + CR.ToString + "'"
    '        SQL += " AND DT_Status = 1"
    '        SQL += " AND (StartTime >= '" + StrDate1.ToString("yyyy/MM/dd HH:mm:ss") + "' "
    '        SQL += " AND StartTime <= '" + StrDate2.ToString("yyyy/MM/dd HH:mm:ss") + "')"

    '        If Not line Is Nothing Then
    '            SQL += " AND Line.Line_ID='" + line.ToString + "'"
    '        Else
    '            SQL += " AND Line_Status=1"
    '        End If

    '        If LTID <> "0" Then
    '            SQL += " AND LossTimeDetail.LT_ID='" + LTID.ToString + "'"
    '        End If

    '        SQL += " GROUP BY ProcessRelation.PL_ID,ProcessName"
    '        SQL += " ORDER BY Total DESC"

    '        dTable = DownTime.DataAccessLayer.DataAccess.GetDs(SQL).Tables(0).Copy

    '        If dTable.Rows.Count > 0 Then
    '            ' Name - X Axis
    '            strXML &= "<categories fontSize='11'>"
    '            For i As Integer = 0 To dTable.Rows.Count - 1
    '                Dim dTable2 As DataTable
    '                SQL = "SELECT * FROM Line "
    '                SQL += " INNER JOIN ProcessRelation ON ProcessRelation.Line_ID=Line.Line_ID"
    '                SQL += " INNER JOIN CleanRoom ON CleanRoom.CR_ID=Line.CR_ID"
    '                SQL += " WHERE PL_ID='" + dTable.Rows(i)("PL_ID").ToString + "'"
    '                dTable2 = DownTime.DataAccessLayer.DataAccess.GetDs(SQL).Tables(0).Copy

    '                strXML &= "<category name='" + dTable.Rows(i)("ProcessName").ToString.Replace("&", "%26") + _
    '                          " - " + dTable2.Rows(0)("Line_Detail") + "' />"
    '            Next
    '            strXML &= "</categories>"

    '            ' Value (Minutes)
    '            strXML += "<dataset seriesName='Minute' parentYAxis='P' color='80b240' showValues='1'>"
    '            For i As Integer = 0 To dTable.Rows.Count - 1
    '                Dim dTable2 As DataTable
    '                SQL = "SELECT * FROM Line "
    '                SQL += " INNER JOIN ProcessRelation ON ProcessRelation.Line_ID=Line.Line_ID"
    '                SQL += " INNER JOIN CleanRoom ON CleanRoom.CR_ID=Line.CR_ID"
    '                SQL += " WHERE PL_ID='" + dTable.Rows(i)("PL_ID").ToString + "'"
    '                dTable2 = DownTime.DataAccessLayer.DataAccess.GetDs(SQL).Tables(0).Copy

    '                If Not IsDBNull(dTable.Rows(i)("Total")) Then
    '                    strXML = strXML & "<set value='" + dTable.Rows(i)("Total").ToString + "'"
    '                    strXML = strXML & " hoverText='" + dTable.Rows(i)("ProcessName").ToString.Replace("&", "%26") + _
    '                                      " - " + dTable2.Rows(0)("CR_Detail") + " - " + dTable2.Rows(0)("Line_Detail") + "'"

    '                    If isLink Then
    '                        strXML = strXML & " link='n-DataByMachine.aspx%3FPLID%3D" + dTable.Rows(i)("PL_ID").ToString
    '                        strXML = strXML & "%26MCID%3D" & GetMCID(dTable.Rows(i)("ProcessName").ToString)
    '                        strXML = strXML & "%26Start%3D" & StartDate.ToString("dd-MM-yyyy")
    '                        strXML = strXML & "%26End%3D" & EndDate.ToString("dd-MM-yyyy")
    '                        strXML = strXML & "%26LTID%3D" & LTID.ToString + "'"
    '                    End If

    '                    strXML = strXML & " />"
    '                Else
    '                    strXML = strXML & "<set />"
    '                End If
    '            Next
    '            strXML += "</dataset>"

    '            ' Value (Percent)
    '            Dim Day As Integer = getAmountDay(CR, StartDate, EndDate)
    '            strXML += "<dataset seriesName='Percent' parentYAxis='S' color='006600' numberSuffix='%25 ' showValues='1' anchorRadius='3' anchorBorderColor='009900'>"
    '            For i As Integer = 0 To dTable.Rows.Count - 1

    '                Dim dTable2 As DataTable
    '                SQL = "SELECT * FROM Line "
    '                SQL += " INNER JOIN ProcessRelation ON ProcessRelation.Line_ID=Line.Line_ID"
    '                SQL += " INNER JOIN CleanRoom ON CleanRoom.CR_ID=Line.CR_ID"
    '                SQL += " WHERE PL_ID='" + dTable.Rows(i)("PL_ID").ToString + "'"
    '                dTable2 = DownTime.DataAccessLayer.DataAccess.GetDs(SQL).Tables(0).Copy

    '                If Not IsDBNull(dTable.Rows(i)("Total")) Then
    '                    strXML = strXML & "<set value='" + (CDbl(dTable.Rows(i)("Total")) / (12.6 * CDbl(Day))).ToString("##0.00") + "'"
    '                    strXML = strXML & " hoverText='" + dTable.Rows(i)("ProcessName").ToString.Replace("&", "%26") + _
    '                                      " - " + dTable2.Rows(0)("CR_Detail") + " - " + dTable2.Rows(0)("Line_Detail") + "'"

    '                    If isLink Then
    '                        strXML = strXML & " link='n-DataByMachine.aspx%3FPLID%3D" + dTable.Rows(i)("PL_ID").ToString
    '                        strXML = strXML & "%26MCID%3D" & GetMCID(dTable.Rows(i)("ProcessName").ToString)
    '                        strXML = strXML & "%26Start%3D" & StartDate.ToString("dd-MM-yyyy")
    '                        strXML = strXML & "%26End%3D" & EndDate.ToString("dd-MM-yyyy")
    '                        strXML = strXML & "%26LTID%3D" & LTID.ToString + "'"
    '                    End If

    '                    strXML = strXML & " />"
    '                Else
    '                    strXML = strXML & "<set />"
    '                End If
    '            Next
    '            strXML += "</dataset>"
    '        End If

    '    Catch ex As Exception

    '    End Try

    '    strXML = strXML & "</graph>"

    '    'Create the chart - Column 3D Chart with data from strXML variable using dataXML method
    '    Return FusionCharts.RenderChartHTML("FusionCharts/FCF_MSColumn3DLineDY.swf", "", strXML, "myNext4", Width, Height, False)

    'End Function
    'Private Function GetMCID(ByVal ProcessName As String) As String
    '    Dim MC As String = ""
    '    If ProcessName.Contains("M/C") Then
    '        MC = ProcessName.Remove(0, ProcessName.IndexOf("M/C") + 3)
    '    Else
    '        MC = "1"
    '    End If

    '    Return MC
    'End Function
    'Public Function TOP5ByProcessChart(ByVal CR As String, ByVal CR_Detail As String, ByVal StartDate As DateTime, ByVal EndDate As DateTime, _
    '                                    ByVal Width As String, ByVal Height As String, ByVal line As String, ByVal line_Detail As String, ByVal isLink As Boolean, ByVal LTID As String) As String

    '    Dim StrDate1 As DateTime = GetDateStart(StartDate.ToString("dd-MM-yyyy"))
    '    Dim StrDate2 As DateTime = GetDateEnd(EndDate.ToString("dd-MM-yyyy"))
    '    Dim LT As String = ""

    '    Dim strXML As String = ""
    '    Dim dTable4 As DataTable

    '    strXML = strXML & "<graph  bgcolor='E8E8E8' caption='TOP-5 Loss-Time by Process of " + CR_Detail.ToString
    '    If Not line_Detail Is Nothing Then
    '        strXML += " - " + line_Detail.ToString
    '    End If

    '    If LTID <> "0" Then
    '        SQL = "SELECT * FROM LossTimeCode WHERE LT_ID='" + LTID.ToString + "'"
    '        dTable = DownTime.DataAccessLayer.DataAccess.GetDs(SQL).Tables(0).Copy

    '        LT = "[" + dTable.Rows(0)("LT_Code").ToString + ":" + dTable.Rows(0)("LT_Mean").ToString.Replace("&", "%26") + "]"
    '    End If

    '    strXML += "' subcaption='" + LT.ToString

    '    If StartDate = EndDate Then
    '        strXML += " Date : " + getStrDate(StartDate).Replace("'", "%26apos;") + "'"
    '    Else
    '        strXML += " Date : " + getStrDate(StartDate).Replace("'", "%26apos;")
    '        strXML += " - " + getStrDate(EndDate).Replace("'", "%26apos;") + "'"
    '    End If

    '    strXML += " xAxisName='Process' yAxisMinValue='0' SYAxisMaxValue='10' formatNumberScale='0' showLegend='0' decimalPrecision='2' limitsDecimalPrecision='0'"
    '    strXML += " PYAxisName='Minutes' SYAxisName='Percent(%25)' rotateNames='1' thousandSeparator=',' baseFontSize='10' baseFont='Arial' outCnvBaseFontSize='12'>"

    '    Try
    '        SQL = "SELECT TOP 5 (ISNULL(Sum(Total),0) + ISNULL(Sum(PCE_Total),0)) As Total, Process.Process_ID,Process_Name FROM DownTimeRecord"
    '        SQL += " INNER JOIN ModelRelation ON ModelRelation.ML_ID=DownTimeRecord.ML_ID"
    '        SQL += " INNER JOIN Line ON ModelRelation.Line_ID=Line.Line_ID"
    '        SQL += " INNER JOIN CleanRoom ON CleanRoom.CR_ID=Line.CR_ID"
    '        SQL += " INNER JOIN ProcessRelation ON ProcessRelation.PL_ID=DowntimeRecord.PL_ID"
    '        SQL += " INNER JOIN Process ON Process.Process_ID=ProcessRelation.Process_ID"
    '        SQL += " INNER JOIN LineType ON LineType.TY_ID=Process.TY_ID"
    '        SQL += " LEFT JOIN PCEData ON PCEData.DT_ID=DownTimeRecord.DT_ID"
    '        SQL += " LEFT JOIN LossTimeRelation ON LossTimeRelation.DT_ID=DownTimeRecord.DT_ID"
    '        SQL += " LEFT JOIN LossTimeDetail ON LossTimeDetail.LTD_ID=LossTimeRelation.LTD_ID"

    '        SQL += " WHERE CleanRoom.CR_ID='" + CR.ToString + "'"
    '        If Not line Is Nothing Then
    '            SQL += " AND Line.Line_ID='" + line.ToString + "'"
    '        Else
    '            SQL += " AND Line_Status=1"
    '        End If

    '        If LTID <> "0" Then
    '            SQL += " AND LossTimeDetail.LT_ID='" + LTID.ToString + "'"
    '        End If

    '        SQL += " AND DT_Status = 1"
    '        SQL += " AND (StartTime >= '" + StrDate1.ToString("yyyy/MM/dd HH:mm:ss") + "' "
    '        SQL += " AND StartTime <= '" + StrDate2.ToString("yyyy/MM/dd HH:mm:ss") + "')"

    '        SQL += " GROUP BY Process.Process_ID,Process_Name"
    '        SQL += " ORDER BY Total DESC"

    '        dTable = DownTime.DataAccessLayer.DataAccess.GetDs(SQL).Tables(0).Copy

    '        If dTable.Rows.Count > 0 Then
    '            ' Name - X Axis
    '            strXML &= "<categories>"
    '            For i As Integer = 0 To dTable.Rows.Count - 1
    '                strXML &= "<category name='" + dTable.Rows(i)("Process_Name").ToString.Replace("&", "%26") + "'/>"
    '            Next
    '            strXML &= "</categories>"

    '            ' Value (Minutes)
    '            strXML += "<dataset seriesName='Minute' parentYAxis='P' color='ae6ecd' showValues='1'>"
    '            For i As Integer = 0 To dTable.Rows.Count - 1
    '                If Not IsDBNull(dTable.Rows(i)("Total")) Then

    '                    strXML = strXML & "<set value='" + dTable.Rows(i)("Total").ToString + "'"

    '                    If isLink Then
    '                        strXML = strXML & " link='n-DataByProcess.aspx%3FCR%3D" + CR.ToString
    '                        If Not line Is Nothing Then
    '                            strXML = strXML & "%26Line%3D" & line.ToString
    '                        End If
    '                        strXML = strXML & "%26Process%3D" & dTable.Rows(i)("Process_ID").ToString
    '                        strXML = strXML & "%26Start%3D" & StartDate.ToString("dd-MM-yyyy")
    '                        strXML = strXML & "%26End%3D" & EndDate.ToString("dd-MM-yyyy")
    '                        strXML = strXML & "%26LTID%3D" & LTID + "'"
    '                    End If

    '                    strXML = strXML & " />"
    '                Else
    '                    strXML = strXML & "<set />"
    '                End If
    '            Next
    '            strXML += "</dataset>"

    '            ' Value (Percent)
    '            Dim Day As Integer = getAmountDay(CR, StartDate, EndDate)
    '            strXML += "<dataset seriesName='Percent' parentYAxis='S' color='006600' numberSuffix='%25' showValues='1' anchorRadius='3' anchorBorderColor='009900'>"

    '            For i As Integer = 0 To dTable.Rows.Count - 1
    '                SQL = "SELECT sum(QTY) As sumqty FROM ProcessRelation"
    '                SQL += " INNER JOIN Line ON Line.Line_ID=ProcessRelation.Line_ID"
    '                SQL += " WHERE Process_ID='" + dTable.Rows(i)("Process_ID").ToString + "'"
    '                SQL += " AND CR_ID='" + CR.ToString + "'"

    '                If Not line Is Nothing Then
    '                    SQL += " AND Line.Line_ID='" + line.ToString + "'"
    '                Else
    '                    SQL += " AND Line_Status=1"
    '                End If

    '                dTable4 = DownTime.DataAccessLayer.DataAccess.GetDs(SQL).Tables(0).Copy

    '                If Not IsDBNull(dTable.Rows(i)("Total")) Then
    '                    strXML = strXML & "<set value='" + (CDbl(dTable.Rows(i)("Total")) / _
    '                                          (CDbl(dTable4.Rows(0)("sumqty")) * 12.6 * CDbl(Day))).ToString("##0.00") + "'"

    '                    If isLink Then
    '                        strXML = strXML & " link='n-DataByProcess.aspx%3FCR%3D" + CR.ToString
    '                        If Not line Is Nothing Then
    '                            strXML = strXML & "%26Line%3D" & line.ToString
    '                        End If
    '                        strXML = strXML & "%26Process%3D" & dTable.Rows(i)("Process_ID").ToString
    '                        strXML = strXML & "%26Start%3D" & StartDate.ToString("dd-MM-yyyy")
    '                        strXML = strXML & "%26End%3D" & EndDate.ToString("dd-MM-yyyy")
    '                        strXML = strXML & "%26LTID%3D" & LTID + "'"
    '                    End If

    '                    strXML = strXML & " />"
    '                Else
    '                    strXML = strXML & "<set />"
    '                End If
    '            Next
    '            strXML += "</dataset>"
    '        End If

    '    Catch ex As Exception

    '    End Try

    '    strXML = strXML & "</graph>"

    '    'Create the chart - Column 3D Chart with data from strXML variable using dataXML method
    '    Return FusionCharts.RenderChartHTML("FusionCharts/FCF_MSColumn3DLineDY.swf", "", strXML, "myNext3", Width, Height, False)

    'End Function

    'Public Function DownTimeByLineCharts() As String
    '    Dim strXML As String = ""
    '    Dim Total As Integer = 0

    '    strXML = strXML & "<graph bgcolor='ffe1e1' caption='Summary Downtime By Line of " + ddlCROption.SelectedItem.Text + " on " + getStrDate(GetDateStart(txtDate.Text)).Replace("'", "%26apos;") + "' xAxisName='Line' yAxisName='Minutes' decimalPrecision='0' formatNumberScale='0'"
    '    strXML += " yAxisMinValue='0' rotateNames='1'>"
    '    Try
    '        Dim dTable2 As DataTable
    '        SQL = "SELECT * FROM Line "
    '        SQL += " WHERE CR_ID='" + ddlCROption.SelectedValue.ToString + "'"
    '        SQL += " ORDER BY Line_ID"
    '        dTable2 = DownTime.DataAccessLayer.DataAccess.GetDs(SQL).Tables(0).Copy

    '        For i As Integer = 0 To dTable2.Rows.Count - 1
    '            strXML = strXML & "<set name='" + dTable2.Rows(i)("Line_Detail").ToString + "'"

    '            SQL = "SELECT Sum(Total) As SumTotal FROM DownTimeRecord "
    '            SQL += " INNER JOIN ModelRelation ON ModelRelation.ML_ID=DownTimeRecord.ML_ID"
    '            SQL += " INNER JOIN Line ON ModelRelation.Line_ID=Line.Line_ID"

    '            SQL += " WHERE Line.Line_ID='" + dTable2.Rows(i)("Line_ID").ToString + "'"
    '            SQL += " AND (DT_Status = 1 OR PCE_Adjust = 1)"
    '            SQL += " AND (StartTime >= '" + GetDateStart(txtDate.Text).ToString("yyyy/MM/dd HH:mm:ss") + "' AND StartTime <= '" + GetDateEnd(txtDate.Text).ToString("yyyy/MM/dd HH:mm:ss") + "')"

    '            dTable = DownTime.DataAccessLayer.DataAccess.GetDs(SQL).Tables(0).Copy

    '            If dTable.Rows.Count > 0 Then
    '                If Not IsDBNull(dTable.Rows(0)("SumTotal")) Then
    '                    strXML = strXML & " value='" + dTable.Rows(0)("SumTotal").ToString + "' color='9D080D' />"
    '                    Total += CInt(dTable.Rows(0)("SumTotal"))
    '                Else
    '                    strXML = strXML & " />"
    '                End If
    '            Else
    '                strXML = strXML & " />"
    '            End If
    '        Next

    '        Dim countline As Integer = getAmountLine(ddlCROption.SelectedValue.ToString, GetDateStart(txtDate.Text))
    '        strXML &= "<trendlines>"
    '        strXML &= "<line startValue='" + (CDbl(Total) / CDbl(countline)).ToString + "' displayValue='AVG " + (CDbl(Total) / CDbl(countline)).ToString("##0.00") + "' color='9D080D' thickness='1' showOnTop='1'/>"
    '        strXML &= "</trendlines>"

    '        LBTTLRotor.Text = "TOTAL = " + Total.ToString("#,##0") + " Minutes , AVG = " + (CDbl(Total) / CDbl(countline)).ToString("##0.00") + " Minutes."

    '        strXML = strXML & "</graph>"
    '    Catch ex As Exception

    '    End Try



    '    'Create the chart - Column 3D Chart with data from strXML variable using dataXML method
    '    Return FusionCharts.RenderChartHTML("FusionCharts/FCF_Column2D.swf", "", strXML, "myNext", "650", "500", False)

    'End Function

    'Public Function DownTimeDialyCharts() As String
    '    Dim strXML As String = ""
    '    Dim Total As Double = 0.0

    '    strXML += "<graph bgcolor='F3f3f3' caption='Summary Downtime Percent By Line of " + ddlCROption.SelectedItem.Text + " on " + getStrDate(GetDateStart(txtDate.Text)).Replace("'", "%26apos;") + "'"
    '    strXML += " xAxisName='Line' yAxisName='Percent(%25)' decimalPrecision='2' formatNumberScale='0'"
    '    strXML += " yAxisMinValue='0.00' xAxisMaxValue='100.00' showvalues='1' numberSuffix='%25' rotateNames='1'>"

    '    Try
    '        Dim dTable2 As DataTable
    '        SQL = "SELECT * FROM Line "
    '        SQL += " WHERE CR_ID='" + ddlCROption.SelectedValue.ToString + "'"
    '        SQL += " ORDER BY Line_ID"
    '        dTable2 = DownTime.DataAccessLayer.DataAccess.GetDs(SQL).Tables(0).Copy

    '        For i As Integer = 0 To dTable2.Rows.Count - 1
    '            strXML = strXML & "<set name='" + dTable2.Rows(i)("Line_Detail").ToString + "'"

    '            SQL = "SELECT Total,QTY FROM DownTimeRecord "
    '            SQL += " INNER JOIN ProcessRelation ON ProcessRelation.PL_ID=DownTimeRecord.PL_ID"
    '            SQL += " INNER JOIN Line ON Line.Line_ID=ProcessRelation.Line_ID "

    '            SQL += " WHERE Line.Line_ID='" + dTable2.Rows(i)("Line_ID").ToString + "'"
    '            SQL += " AND (DT_Status = 1 OR PCE_Adjust = 1)"
    '            SQL += " AND (StartTime >= '" + GetDateStart(txtDate.Text).ToString("yyyy/MM/dd HH:mm:ss") + "'"
    '            SQL += " AND StartTime <= '" + GetDateEnd(txtDate.Text).ToString("yyyy/MM/dd HH:mm:ss") + "')"

    '            dTable = DownTime.DataAccessLayer.DataAccess.GetDs(SQL).Tables(0).Copy

    '            Dim TmpPercent As Double = 0.0

    '            If dTable.Rows.Count > 0 Then
    '                For j As Integer = 0 To dTable.Rows.Count - 1
    '                    If Not IsDBNull(dTable.Rows(0)("Total")) Then
    '                        TmpPercent += CDbl(dTable.Rows(j)("Total")) / (CDbl(dTable.Rows(j)("QTY") * 12.6))
    '                    End If
    '                Next

    '                Total += TmpPercent
    '                strXML = strXML & " value='" + TmpPercent.ToString("##0.00") + "' color='B3AA00' />"
    '            Else
    '                strXML = strXML & " />"
    '            End If
    '        Next

    '        Dim countline As Integer = getAmountLine(ddlCROption.SelectedValue.ToString, GetDateStart(txtDate.Text))

    '        strXML &= "<trendlines>"
    '        strXML &= "<line startValue='" + (Total / CDbl(countline)).ToString("##0.00") + "' displayValue='AVG " + (Total / CDbl(countline)).ToString("##0.00") + "%25' color='B3AA00' thickness='1' showOnTop='1'/>"
    '        strXML &= "</trendlines>"

    '        strXML = strXML & "</graph>"

    '        LBTTLPercent.Text = ddlCROption.SelectedItem.Text + " on " + getStrDate(GetDateStart(txtDate.Text)) + " = " + (Total / CDbl(countline)).ToString("##0.00") + "%"

    '    Catch ex As Exception

    '    End Try

    '    Return FusionCharts.RenderChartHTML("FusionCharts/FCF_Line.swf", "", strXML, "myNext1", "650", "500", False)

    'End Function
End Class
