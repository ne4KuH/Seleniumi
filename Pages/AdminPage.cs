using OpenQA.Selenium;
using System;
using System.Threading;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    class AdminPage
    {
        IWebDriver driver;

        private readonly By _add_user_button = By.XPath("//*[@id='app']/div[1]/div[2]/div[2]/div/div[2]/div[1]/button");
        private readonly By _admin_name_label = By.XPath("//*[@id='app']/div[1]/div[1]/header/div[1]/div[2]/ul/li/span/p");

        public AdminPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string getAdminName()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_admin_name_label));
            string adminName = driver.FindElement(_admin_name_label).Text;
            int i = adminName.IndexOf(' ');
            string adminName_ = adminName.Substring(0, i);
            return adminName_;
        }

        public AddUserPage GoToAddUserPage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_add_user_button));

            Thread.Sleep(200);
            driver.FindElement(_add_user_button).Click();
            Thread.Sleep(200);

            return new AddUserPage(driver);
        }
    }
}
