Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports Cal_
Imports System.Web.UI.WebControls
Imports System.Windows.Forms
Imports FusionCharts.Charts

Partial Class _Default
    Inherits System.Web.UI.Page
    
    Public Function CreateChart() As String

        'This page demonstrates the ease of generating charts using FusionCharts.
        'For this chart, we've used a string variable to contain our entire XML data.

        'Ideally, you would generate XML data documents at run-time, after interfacing with
        'forms or databases etc.Such examples are also present.
        'Here, we've kept this example very simple.

        'Create an XML data document in a string variable
        Dim strXML As String = ""
        strXML = ""

        strXML = strXML & "<chart caption=' My Machine item remaining HGST model by line  '"
        strXML = strXML & " xAxisName='Line' yAxisName='Item' decimalPrecision='0' formatNumberScale='2' showvalues='1' baseFontSize='12' baseFont='Arial' outCnvBaseFontSize='12' bgcolor='F3f3f3'"
        strXML = strXML & " plotfillalpha='0'>" ' This attribute should be defined for image annotations. More guide here "http://www.fusioncharts.com/dev/chart-attributes.html?chart=column2d" search for plotfillalpha

        strXML += "<annotations width='500' height='300' autoscale='1'>"
        strXML += "<annotationgroup id='user-images' xscale_='20' yscale_='20'>"

        

        strXML += "<annotation id='butterFinger-icon' type='image' url='Images/SPM1.png' x='$xaxis.label.0.x - 30' y='$canvasEndY - 150' xscale='50' yscale='40' />"
        strXML += "<annotation id='tom-user-icon' type='image' url='Images/SPM3.png' x='$xaxis.label.1.x - 26' y='$canvasEndY - 141' xscale='48' yscale='38' />"
        strXML += "<annotation id='Milton-user-icon' type='image' url='Images/SPM4.png' x='$xaxis.label.2.x - 22' y='$canvasEndY - 134' xscale='43' yscale='36' />"
        strXML += "<annotation id='Brian-user-icon' type='image' url='Images/SPM5.png' x='$xaxis.label.3.x - 22' y='$canvasEndY - 131' xscale='43' yscale='35' />"

        
        strXML += "</annotationgroup>"
        strXML += "</annotations>"
        strXML += "<set label='SPM1' value='90' />"
        strXML += "<set label='SPM3' value='80' />"
        strXML += "<set label='SPM4' value='70'/>"
        strXML += "<set label='SPM5' value='60' />"
      

        strXML += "</chart>"

        'Create the chart - Column 3D Chart with data from strXML variable using dataXML method
        'Return FusionCharts.RenderChartHTML("FusionCharts/Column2D.swf", "", strXML, "myNext", "500", "300", False)
        Dim sales As New Chart("column2d", "myNext", "500", "300", "xml", strXML)
        Return sales.Render()
    End Function


    

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
     
        FCLiteral.Text = CreateChart()

    End Sub



End Class
