using Microsoft.VisualStudio.TestTools.UnitTesting;
using DSIT.Tests.Base;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace DSIT.Tests.PlantillaTests;

[TestClass]
public class PlantillaTestSobreNosotrosUnitTest: TestCaseBase
{
    protected override IWebDriver InitDriver(){
        return new ChromeDriver();
    }
    [TestMethod]
    public void TestMethodSobreNosotros()
    {
        base.NavigateToUrl("https://plantillatest.uniandes.edu.co/#");
        base.Maximize();

        base.MouseOverPartialByLinkText("Sobre Nosotros");
        var imgLaFacultad= base.GetImageByTitle("sobre-nosotros");
        var linkQuienesSomos= base.GetLinkByText("Quienes Somos");
        Assert.IsTrue(imgLaFacultad.Location.X > linkQuienesSomos.Location.X, "La imagen debería estar del lado derecho");
       
        base.ClickElementByLinkText("Quienes Somos");
        base.ClickElementByLinkText("La Facultad");

        base.WaitForSeconds(10);

        var imgFacultad = base.GetImageByTitle("La facultad");
        
        string rutaImagen=imgFacultad.GetAttribute("src");

        Assert.AreEqual (rutaImagen.Contains("sites/default/files/imagen/2020/11/25/banner-interno-la-facultad.jpg"),true, "ruta imagen="+rutaImagen);
        base.WaitForSeconds(5);
    }
    [ClassCleanup]
        public static void CleanupClass()
        {
            TestCaseBase.CleanupClass();
         
        }
}