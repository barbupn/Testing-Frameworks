using OpenQA.Selenium;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Test_Framework_Casino.PageObjects.ModalPages
{
    internal class AccountVerificationModalPage : BasePage
    {
        public AccountVerificationModalPage(IWebDriver webDriver ) : base(webDriver)
        {

        }

        public IWebElement WindowTitle => _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(text(), 'Verificarea contului')]")));
        public IWebElement CloseWindowButton => _wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("cgp-mdp-close-btn-wrapper")));

        public bool AccountVerificationTitleIsDisplayed()
        {
            return WindowTitle.Displayed; 
        }

        public BasePage CloseTheAccountVerificationWindow()
        {
            CloseWindowButton.Click();

            return new BasePage(_webDriver);
        }

    }
}
