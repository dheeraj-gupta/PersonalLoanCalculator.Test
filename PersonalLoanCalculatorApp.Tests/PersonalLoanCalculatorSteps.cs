using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using Xunit;

namespace DemoWebApp.Tests
{
    [Binding]
    public class PersonalLoanCalculatorSteps
    {
        private IWebDriver _driver;
        private PersonalLoanCalculatorPage _personalLoanCalculatorPage;

        [Given(@"I am on loan application screen")]
        public void GivenIAmOnLoanApplicationScreen()
        {
            ChromeOptions options;
            PersonalLoanCalculatorPage.InitDriver(out options);

            _driver = new ChromeDriver(options);
            _driver = new ChromeDriver();
            _personalLoanCalculatorPage = PersonalLoanCalculatorPage.NavigateTo(_driver);
        }
        
        [Given(@"I selected single applicant")]
        public void GivenISelectedSingleApplicant()
        {
            _personalLoanCalculatorPage.ApplicationType();
        }
        
        [Given(@"I selected dependent as (.*)")]
        public void GivenISelectedDependentAs(int p0)
        {
            _personalLoanCalculatorPage.NumberOfDependent();
        }
        
        [Given(@"I am buying house to live in")]
        public void GivenIAmBuyingHouseToLiveIn()
        {
            _personalLoanCalculatorPage.PropertyYouWouldLikeToBuy();
        }
        
        [Given(@"I enter income as \$(.*)")]
        public void GivenIEnterIncomeAs(string incomeBeforeTax)
        {
            _personalLoanCalculatorPage.IncomeBeforeTax = incomeBeforeTax;
        }
        
        [Given(@"I enter other  income as \$(.*)")]
        public void GivenIEnterOtherIncomeAs(string otherIncome)
        {
            _personalLoanCalculatorPage.OtherIncome = otherIncome;
        }
        
        [Given(@"I enter living expense as \$(.*)")]
        public void GivenIEnterLivingExpenseAs(string livingExpenses)
        {
            _personalLoanCalculatorPage.LivingExpenses = livingExpenses;
        }
        
        [Given(@"I enter other loan repayment as \$(.*)")]
        public void GivenIEnterOtherLoanRepaymentAs(string otherLoanRepayments)
        {
            _personalLoanCalculatorPage.OtherLoanRepayments = otherLoanRepayments;
        }
        
        [Given(@"I enter other commitments as (.*)")]
        public void GivenIEnterOtherCommitmentsAs(string otherCommitments)
        {
            _personalLoanCalculatorPage.OtherCommitments = otherCommitments;
        }
        
        [Given(@"I entrer total credit card limits as \$(.*)")]
        public void GivenIEntrerTotalCreditCardLimitsAs(string creditCardLimit)
        {
            _personalLoanCalculatorPage.CreditCardLimit = creditCardLimit;
        }
        
        [Given(@"I enter a living expenses as \$(.*)")]
        public void GivenIEnterALivingExpensesAs(string livingExpenses)
        {
            _personalLoanCalculatorPage.LivingExpenses = livingExpenses;
        }
        
        [Given(@"Leaving all other Fields as \$(.*)")]
        public void GivenLeavingAllOtherFieldsAs(int p0)
        {
            //ScenarioContext.Current.Pending();
        }
        
        [When(@"I press Work out how much I could borrow")]
        public void WhenIPressWorkOutHowMuchICouldBorrow()
        {
            _personalLoanCalculatorPage.HowMuchICouldBorrow();
        }
        
        [When(@"I have clicked start over button")]
        public void WhenIHaveClickedStartOverButton()
        {
           
            _personalLoanCalculatorPage.StartOver();
            //_driver.FindElement(By.CssSelector("start-over")).Click();
        }
        
        [Then(@"the result  should display borrowing estimate of \$(.*)")]
        public void ThenTheResultShouldDisplayBorrowingEstimateOf(Decimal p0)
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
            //var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            //wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("icon_restart")));
            Assert.Equal("$532,000", _personalLoanCalculatorPage.EstimatedBorrowAmount);
        }
        
        [Then(@"Clears the form")]
        public void ThenClearsTheForm()
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
            Assert.Equal("", _personalLoanCalculatorPage.IncomeBeforeTax);
        }

        [Then(@"I should see message telling me Based on the details you'(.*)'re unable to give you an estimate of your borrowing power with this calculator\. For questions, call us on (.*) (.*)")]
        public void ThenIShouldSeeMessageTellingMeBasedOnTheDetailsYouReUnableToGiveYouAnEstimateOfYourBorrowingPowerWithThisCalculator_ForQuestionsCallUsOn(string p0, string p1, int p2)
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
            Assert.Equal("Based on the details you've entered, we're unable to give you an estimate of your borrowing power with this calculator. For questions, call us on 1800 100 641.", _personalLoanCalculatorPage.ErrorText);
        }


        [AfterScenario]
        public void DisposeWebDriver()
        {
            _driver.Dispose();
        }
    }
}
