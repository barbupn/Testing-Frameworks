using OpenQA.Selenium;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using Test_Framework_Casino.PageObjects.ModalPages;
using OpenQA.Selenium.Interactions;

namespace Test_Framework_Casino.PageObjects.GamesPages
{
    internal class TrailOfTreatsGamePage : BasePage
    {
        private Actions action;

        public TrailOfTreatsGamePage(IWebDriver webDriver) : base(webDriver)
        {
            action = new Actions(webDriver);  
        }

        public IWebElement SpinButton => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("spin_button")));
        public IWebElement Canvas => _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='canvas']/canvas")));
        public IWebElement IFrame => _wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("cy-game-iframe")));
        public CashAmountNotificationModalPage ClickTheSpinButton()
        {
            SpinButton.Click();

            return new CashAmountNotificationModalPage(_webDriver);
        }

        public void ConfirmThECanvas()
        {
            var canvas_dimensions = Canvas.Size;
            var canvas_center_x = canvas_dimensions.Width / 2;
            var canvas_center_y = canvas_dimensions.Height / 2;
            int button_x = (canvas_center_x / 8) * 1;
            int button_y = (canvas_center_y / 8) * 5;

            action.MoveToElement(Canvas, button_x, button_y).Click().Perform();
        }

        public void MoveToIFrame()
        {
            _webDriver.SwitchTo().Frame(IFrame);
        }
    }
}
