using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

public class Class
{
    public void CrearReporte()
    {
        var htmlReporter = new AventStack.ExtentReports.Reporter.ExtentHtmlReporter("Reporte.html");
        var extent = new ExtentReports();
        extent.AttachReporter(htmlReporter);

        var test = extent.CreateTest("Test");
        test.Pass("Prueba exitosa");

        extent.Flush();
    }
}
