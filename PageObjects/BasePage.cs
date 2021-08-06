using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using Test_Framework_Casino.PageObjects.GamesPages;
namespace Test_Framework_Casino.PageObjects
{
    internal class BasePage
    {
        protected IWebDriver _webDriver;
        protected WebDriverWait _wait;

        public BasePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(30));
        }

        private IWebElement LogInButton => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("cgp-login-btn")));
        private IWebElement SearchField => _wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("cy-game-search-input")));
        private IList<IWebElement> SearchedResults => _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.ClassName("cy-found-games-list-box")));
        private IWebElement SearchedGameResult => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//img[@alt='Trail of Treats - slots']")));
        private IWebElement CloseCookiesNotificationAreaButton => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='CookieMessageDiv']//div/img")));
        public LogInModalPage ClickOnLogInButton()
        {
            LogInButton.Click();

            return new LogInModalPage(_webDriver);
        }

        public void ClickOnSearchButton()
        {
            SearchField.Click();
        }

        public void SearchForAGame(string gameName)
        {
            SearchField.SendKeys(gameName);
        }

        public TrailOfTreatsGamePage OpenTheSearchedGame()
        {
            SearchedGameResult.Click();

            return new TrailOfTreatsGamePage(_webDriver); 
        }

        public void CloseCookiesNotification()
        {
            CloseCookiesNotificationAreaButton.Click();
        }
    }
}
