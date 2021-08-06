using System;
using TechTalk.SpecFlow;
using Test_Framework_Casino.PageObjects;
using NUnit.Framework;
using Test_Framework_Casino.PageObjects.ModalPages;
using Test_Framework_Casino.PageObjects.GamesPages;

namespace Test_Framework_Casino.Steps
{
    [Binding, Scope(Feature = "PlayAGame")]
    public sealed class PlayAGameSteps
    {
        private readonly Navigator _navigator;
        private LogInModalPage _logInPage;
        private AccountVerificationModalPage _accountVerificationModalPage;
        private BasePage _mainPage;
        private TrailOfTreatsGamePage _trailOfTreatsGamePage;
        private CashAmountNotificationModalPage _cashAmountNotificationModalPage;

        public PlayAGameSteps(Navigator navigator)
        {
            _navigator = navigator;
        }
        
        [Given(@"I am on (.*)casino page")]
        public void GivenIAmOnCasinoPage(int p0)
        {
            _logInPage = _navigator.GoTo<LogInModalPage>(new Uri("https://www.888casino.ro/"));

        }

        [Given(@"I login using personal credentials")]
        public void GivenILoginUsingPersonalCredentials()
        {
            _logInPage.ClickOnLogInButton();
            _logInPage.FillTheUsername(Configuration.UserName);
            _logInPage.FillThePassword(Configuration.Password);
            _accountVerificationModalPage = _logInPage.LogIn();
        }

        [Then(@"I should be logged in")]
        public void ThenIShouldBeLoggedIn()
        {
            Assert.IsTrue(_accountVerificationModalPage.AccountVerificationTitleIsDisplayed());
        }

        [When(@"I search for game with name '(.*)' using the search function")]
        public void WhenISearchForGameWithNameUsingTheSearchFunction(string p0)
        {
            _mainPage = _accountVerificationModalPage.CloseTheAccountVerificationWindow();
            _mainPage.CloseCookiesNotification();
            
            _mainPage.ClickOnSearchButton();
            _mainPage.SearchForAGame(p0);
        }

        [When(@"I open the searched game")]
        public void WhenIOpenTheSearchedGame()
        {
            _trailOfTreatsGamePage = _mainPage.OpenTheSearchedGame();
        }

        [When(@"I click on the spin button")]
        public void WhenIClickOnTheSpinButton()
        {
            _trailOfTreatsGamePage.MoveToIFrame();
            _trailOfTreatsGamePage.ConfirmThECanvas();
            _cashAmountNotificationModalPage = _trailOfTreatsGamePage.ClickTheSpinButton();
        }

        [Then(@"I should see a modal with the message: '(.*)'")]
        public void ThenIShouldSeeAModalWithTheMessage(string p0)
        {
            Assert.IsTrue(_cashAmountNotificationModalPage.CashAmountNotificationMessageIsDisplayed());
        }


    }
}
