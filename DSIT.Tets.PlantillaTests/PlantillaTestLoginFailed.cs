using Microsoft.VisualStudio.TestTools.UnitTesting;
using DSIT.Tests.Base;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
namespace DSIT.Tests.PlantillaTests;

[TestClass]
public class PlantillaTestLoginFailed : TestCaseBase
{
    protected override IWebDriver InitDriver()
    {
        return new ChromeDriver();
    }
    [TestMethod]
    public void TestMethodLoginFailed()
    {
        base.NavigateToUrl("https://plantillatest.uniandes.edu.co/USER");
        base.Maximize();

        base.EnterInformation("edit-name", "l.herreno");
        base.EnterInformation("edit-pass", "gjdfgkdjgdlj");
     
        base.SubmitFormByID("edit-submit");

        base.WaitForSeconds(10);

        //var divMensajeError=base.GetElementByCssClass (".alert .alert-block .alert-dismissible .alert-danger .messages .error");
        IWebElement divMensajeError;
        try {
                divMensajeError = base.GetElementByCssClass(".alert");
        }
        catch (NoSuchElementException ex){
            Assert.Fail("Div del mensaje de error no encontrado (Clase .alert no encontrada)");
            return;
        }

        Assert.AreEqual(true, divMensajeError.Text.Contains("Lo sentimos. No reconocemos el nombre de usuario o la contraseña."), "El mensaje de error encontrado fue:" + divMensajeError.Text);

        //Edicion desde visual studio code
    }
    [ClassCleanup]
    public static void CleanupClass()
    {
        TestCaseBase.CleanupClass();

    }

}