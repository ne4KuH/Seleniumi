using NUnit.Framework;
using OpenQA.Selenium;
using System;


namespace SeleniumTests
{
    public class Tests
    {
        private String _admin_name = "Admin";
        private String _password = "admin123";
        private String _username = "Vania Payevskij";
        private String _user_password = "Selenium*14A";
        private String _employee_name = "Odis  Adalwin";

        IWebDriver driver = new OpenQA.Selenium.Chrome.ChromeDriver("D:\\Seleniumi\\bin\\Debug\\netcoreapp3.1.exe");

        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            LoginPage loginPage = new LoginPage(driver);
            DashboardPage homePage = loginPage.Login(_admin_name, _password);

            AdminPage adminPage = homePage.GoToAdminPage();
            string adminName = adminPage.getAdminName();
            
           

            AddUserPage addUserPage = adminPage.GoToAddUserPage();
            AdminPage adminPageWithUser = addUserPage.addUser(_employee_name, _username, _user_password);
            String bodyText = driver.FindElement(By.TagName("body")).Text;
            
            Assert.IsTrue(bodyText.Contains(_username));
        }

        [TearDown]
        public void EndTest()
        {
            driver.Close();
        }
    }
}


