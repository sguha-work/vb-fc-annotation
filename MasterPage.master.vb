
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US")
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("en-US")
        lblTime.Text = DateTime.Now.ToString("dd/MMM/yyyy")
    End Sub
End Class

