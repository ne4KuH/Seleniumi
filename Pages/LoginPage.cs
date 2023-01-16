using OpenQA.Selenium;
using System;
using System.Threading;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    class LoginPage
    {
        IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public DashboardPage Login(String name, String password)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name("username")));

            driver.FindElement(By.Name("username")).SendKeys(name);
            Thread.Sleep(1000);
            driver.FindElement(By.Name("password")).SendKeys(password);
            Thread.Sleep(1000);
            driver.FindElement(By.TagName("button")).Click();
            
            return new DashboardPage(driver);
        }
    }
}
