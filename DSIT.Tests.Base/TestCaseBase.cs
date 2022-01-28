using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace DSIT.Tests.Base;

[TestClass]
public abstract class TestCaseBase
{
    
        private static IWebDriver driver;
        private StringBuilder verificationErrors;
        private static string baseURL;
        private bool acceptNextAlert = true;

        protected abstract IWebDriver InitDriver();

//Comentario ovasquez@microsoft.com
        public TestCaseBase()
        {
            if (driver == null)
                driver = this.InitDriver();
            if (baseURL == null)
                baseURL = "about:blank";
        }

        [ClassCleanup]
        public static void CleanupClass()
        {
            try
            {
                driver.Quit();// quit does not close the window
                driver.Close();
                driver.Dispose();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

         [TestInitialize]
        public void InitializeTest()
        {
            verificationErrors = new StringBuilder();
        }

         [TestCleanup]
        public void CleanupTest()
        {
            Assert.AreEqual("", verificationErrors.ToString());
        }

        public void NavigateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void MouseOverPartialByLinkText(string partialText)
        {
            var mouseOverAction = new OpenQA.Selenium.Interactions.Actions(driver);
            var sobreNosotrosLink= driver.FindElement (By.PartialLinkText ( partialText));
            mouseOverAction.MoveToElement(sobreNosotrosLink);
            mouseOverAction.Perform();
        }
        public IWebElement GetLinkByText(string partialText)
        {
            
            return driver.FindElement (By.PartialLinkText ( partialText));
          
        }
        public void ClickElementByLinkText(string text)
        {
            driver.FindElement(By.LinkText(text)).Click();
        }

        public void WaitForSeconds(int seconds)
        {
            Thread.Sleep(seconds*1000);
        }

        public IWebElement GetImageByTitle(string title)
        {
            return driver.FindElement (By.CssSelector ("img[title='" + title + "']"));
        }
        public IWebElement GetElementByCssClass(string classes )
        {
            return driver.FindElement (By.CssSelector (classes));
        }

        public IWebElement EnterInformation (string id, string value)
        {
            IWebElement textbox=driver.FindElement(By.Id(id));
            textbox.Clear();
            textbox.SendKeys(value);
            return textbox;
        }

        public void SubmitFormByID (string id)
        {
            driver.FindElement(By.Id(id)).Click();
        }
        public void Maximize()
        {
            driver.Manage().Window.Maximize();
        }

}
