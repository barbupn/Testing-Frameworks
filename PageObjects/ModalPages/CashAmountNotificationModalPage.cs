using OpenQA.Selenium;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Test_Framework_Casino.PageObjects.ModalPages
{
    internal class CashAmountNotificationModalPage : BasePage
    {
        public CashAmountNotificationModalPage(IWebDriver webDriver) : base(webDriver)
        {

        }

        private IWebElement NotificationMessage => _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[contains(text(), 'Miza vă depăşeşte soldul actual. Pentru a continua ajustaţi miza sau depuneţi mai mulţi bani.')]")));

        public bool CashAmountNotificationMessageIsDisplayed()
        {
            return NotificationMessage.Displayed;
        }
    }
}
