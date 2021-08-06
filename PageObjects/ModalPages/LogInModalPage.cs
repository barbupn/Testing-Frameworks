using OpenQA.Selenium;
using Test_Framework_Casino.PageObjects.ModalPages;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Test_Framework_Casino.PageObjects
{
    internal class LogInModalPage : BasePage
    {
        public LogInModalPage(IWebDriver webDriver) : base(webDriver)
        {

        }

        private IWebElement UserName => _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("rlLoginUsername")));
        private IWebElement Password => _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("rlLoginPassword")));
        private IWebElement LogInButton => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("rlLoginSubmit")));

        public void FillTheUsername(string username)
        {
            UserName.SendKeys(username);
        }

        public void FillThePassword(string password)
        {
            Password.SendKeys(password);
        }

        public AccountVerificationModalPage LogIn()
        {
            LogInButton.Click();

            return new AccountVerificationModalPage(_webDriver);
        }

    }
}
