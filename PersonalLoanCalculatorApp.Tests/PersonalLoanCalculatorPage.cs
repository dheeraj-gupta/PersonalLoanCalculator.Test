using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWebApp.Tests
{
   public class PersonalLoanCalculatorPage
    {
        private readonly IWebDriver _driver;
        private const string PageUri = @"https://www.anz.com.au/personal/home-loans/calculators-tools/much-borrow/";
        
        [FindsBy(How = How.CssSelector, Using = "div.borrow__question > ul li:nth-of-type(1)")]
        private IWebElement _applicationType;

        [FindsBy(How = How.CssSelector, Using = "div.borrow__question__answer  > select > option:nth-child(1)")]
        private IWebElement _numberOfDependent; 

        [FindsBy(How = How.CssSelector, Using = "div.borrow__question.borrow__question--tall > ul li:nth-of-type(1)")]
        private IWebElement _propertyYouWouldLikeToBuy;

        [FindsBy(How = How.CssSelector, Using = "input[aria-labelledby='q2q1']")]
        private IWebElement _incomeBeforeTax;

        [FindsBy(How = How.CssSelector, Using = "input[aria-labelledby='q2q2']")]
        private IWebElement _otherIncome;

        [FindsBy(How = How.CssSelector, Using = "input[aria-labelledby='q3q1']")]
        private IWebElement _livingExpenses;

        [FindsBy(How = How.CssSelector, Using = "input[aria-labelledby='q3q2']")]
        private IWebElement _otherLoanRepayments;

        [FindsBy(How = How.CssSelector, Using = "input[aria-labelledby='q3q3']")]
        private IWebElement _otherCommitments;

        [FindsBy(How = How.CssSelector, Using = "input[aria-labelledby='q3q4']")]
        private IWebElement _creditCardLimit;

        [FindsBy(How = How.CssSelector, Using = ".btn--borrow__calculate")]
        private IWebElement _howMuchICouldBorrowButton;

        [FindsBy(How = How.CssSelector, Using = ".borrow__error .box--right .start-over")]
        private IWebElement _startOverButton;

        [FindsBy(How = How.CssSelector, Using = ".borrow__result__text .borrow__result__text__amount")]
        private IWebElement _estimatedBorrowAmount;

        [FindsBy(How = How.CssSelector, Using = ".borrow__error__text")]
        private IWebElement _errorText;



        public PersonalLoanCalculatorPage(IWebDriver driver)
        {
            _driver = driver;

            PageFactory.InitElements(_driver, this);
        }

        public static PersonalLoanCalculatorPage NavigateTo(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(PageUri);

            return new PersonalLoanCalculatorPage(driver);
        }

        public void ApplicationType()
        {
            
            _applicationType.Click();
        }
        

        public void NumberOfDependent()
        {

            _numberOfDependent.Click();
        }

        public void PropertyYouWouldLikeToBuy()
        {

            _propertyYouWouldLikeToBuy.Click();
        }

        public string IncomeBeforeTax
        {
            get
            {
                return _incomeBeforeTax.Text;
            }
            set
            {
                _incomeBeforeTax.SendKeys(value);
            }
        }

        public string OtherIncome
        {
            set
            {
                _otherIncome.SendKeys(value);
            }
        }

        public string LivingExpenses
        {
            set
            {
                _livingExpenses.SendKeys(value);
            }
        }

        public string OtherLoanRepayments
        {
            set
            {
                _otherLoanRepayments.SendKeys(value);
            }
        }

        public string OtherCommitments
        {
            set
            {
                _otherCommitments.SendKeys(value);
            }
        }

        public string CreditCardLimit
        {
            set
            {
                _creditCardLimit.SendKeys(value);
            }
        }

        
        public void HowMuchICouldBorrow()
        {
            _howMuchICouldBorrowButton.Click();
        }

        public void StartOver()
        {
            _startOverButton.Click();
        }


        
        public string ErrorText => _errorText.Text;

        public string EstimatedBorrowAmount
        {
            get
            {
                return _estimatedBorrowAmount.Text;
            }

        }

        public static void InitDriver( out ChromeOptions options)
        {
           
            DesiredCapabilities capabilities = DesiredCapabilities.Chrome();
            options = new ChromeOptions();
            options.AddArgument("--test-type");
            options.AddArgument("--disable-extensions");
            capabilities.SetCapability(ChromeOptions.Capability, options);
        }

    }
}
