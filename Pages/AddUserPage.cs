using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    class AddUserPage
    {
        IWebDriver driver;

        private readonly By _save_button = By.XPath("//*[@id='app']/div[1]/div[2]/div[2]/div/div/form/div[3]/button[2]");

        private readonly By _role_box = By.XPath("//*[@id='app']/div[1]/div[2]/div[2]/div/div/form/div[1]/div/div[1]/div/div[2]/div/div/div[1]");
        /////*[@id="app"]/div[1]/div[2]/div[2]/div/div/form/div[1]/div/div[1]/div/div[2]/div/div/div[1]
        
        private readonly By _name_box = By.XPath("//*[@id='app']/div[1]/div[2]/div[2]/div/div/form/div[1]/div/div[2]/div/div[2]/div/div/input");
        ////*[@id="app"]/div[1]/div[2]/div[2]/div/div/form/div[1]/div/div[2]/div/div[2]/div/div/input
        //
        private readonly By _status_box = By.XPath("//*[@id='app']/div[1]/div[2]/div[2]/div/div/form/div[1]/div/div[3]/div/div[2]/div/div/div[1]");
        
        private readonly By _username_box = By.XPath("//*[@id='app']/div[1]/div[2]/div[2]/div/div/form/div[1]/div/div[4]/div/div[2]/input");
        
        private readonly By _password_box = By.XPath("//*[@id='app']/div[1]/div[2]/div[2]/div/div/form/div[2]/div/div[1]/div/div[2]/input");
        
        private readonly By _confirm_password_box = By.XPath("//*[@id='app']/div[1]/div[2]/div[2]/div/div/form/div[2]/div/div[2]/div/div[2]/input");

        private readonly By _users = By.XPath("//*[@id='app']/div[1]/div[2]/div[2]/div/div[2]/div[3]/div");
        public AddUserPage(IWebDriver driver)
        {
            this.driver = driver;

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_save_button));
        }

        public AdminPage addUser(string name, string username, string password)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_save_button));

            //Роль
            Thread.Sleep(1000);
            driver.FindElement(_role_box).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[text()='ESS']")).Click();
            Thread.Sleep(1000);

            IWebElement ele = driver.FindElement(_name_box);
            Thread.Sleep(2000);
            ele.SendKeys(name);//Чомусь так не робить, необхідно вибирати з випадаючого списку
            Thread.Sleep(2000);
            driver.FindElement(By.ClassName("oxd-autocomplete-dropdown")).Click();
            Thread.Sleep(2000);

           
            
            driver.FindElement(_status_box).Click();
            Thread.Sleep(500);
            driver.FindElement(By.XPath("//*[text()='Enabled']")).Click();

            

            IWebElement ele3 = driver.FindElement(_username_box);
            Thread.Sleep(1000);
            ele3.SendKeys(username);
            Thread.Sleep(1000);


            IWebElement ele4 = driver.FindElement(_password_box);
            Thread.Sleep(1000);
            ele4.SendKeys(password);
            Thread.Sleep(1000);



            Thread.Sleep(1000);
            driver.FindElement(_confirm_password_box).SendKeys(password);

            Thread.Sleep(1000);
            driver.FindElement(_save_button).Click();

            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait2.Until(ExpectedConditions.ElementIsVisible(_users));

            return new AdminPage(driver);
        }
    }
}
