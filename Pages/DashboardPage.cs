using OpenQA.Selenium;
using System;
using System.Threading;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    class DashboardPage
    {
        IWebDriver driver;

        private readonly By _adminButton = By.XPath("//a[@href='/web/index.php/admin/viewAdminModule']");

        public DashboardPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public AdminPage GoToAdminPage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(_adminButton));
            Thread.Sleep(1000);

            driver.FindElement(_adminButton).Click();

            return new AdminPage(driver);
        }
    }
}
