using OpenQA.Selenium;
using System;
using SeleniumExtras.PageObjects;
using NUnit.Framework;
using System.Threading;
using System.Diagnostics;

namespace Commons_Automation
{
    public class LoginPage:MainSetup
    {

       //IWebDriver driver;
       public string expectedGroupText = "Groups";

        //IWebDriver driver;
        public string expectedHomeText = "Activity in My Communities"; // "My groups";


        public LoginPage()
        {
           // driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(90))); 
        }

        #region SSO Login Page Objects

        [FindsBy(How = How.XPath, Using = "//*[@id='views-exposed-form-streams-block-4']/ul/li/div[1]/h3")]
        public IWebElement communityactivityText { get; set; }

        public string EnvInd = TestContext.Parameters.Get("Environment").ToString();

        [FindsBy(How = How.CssSelector, Using = "input#edit-input")]
        public IWebElement userNameField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button#edit-next")]
        public IWebElement nextButton { get; set; }

        //This element will be removed after Commons Sprint 2020 Sprint 12 deployement in All the Environment
        [FindsBy(How = How.Id, Using = "edit-sso-login")]
        public IWebElement ssoLoginButton { get; set; }

        [FindsBy(How = How.Id, Using = "userNameInput")]
        public IWebElement inputUsername { get; set; }

        [FindsBy(How = How.Id, Using = "passwordInput")]
        public IWebElement inputPassword { get; set; }

        [FindsBy(How = How.Id, Using = "submitButton")]
        public IWebElement signInButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div#loginArea > form#loginForm > div#error")]
        public IWebElement invalidUserError { get; set; }

        [FindsBy(How = How.ClassName, Using = "desktop-menu")]
        public IWebElement menu_bgcolor { get; set; }

        [FindsBy(How = How.LinkText, Using = "Service Desk")]
        public IWebElement serviceDeskLink { get; set; }

        
        #endregion SSO Login Page Objects

        #region Direct Login
        //[FindsBy(How = How.Id, Using = "edit-name")]
        //public IWebElement directInputUsername { get; set; }

        //[FindsBy(How = How.Id, Using = "edit-pass")]
        //public IWebElement directInputPassword { get; set; }

        //[FindsBy(How = How.Id, Using = "edit-submit")]


        [FindsBy(How = How.CssSelector, Using = "#user-login-form > div>input#edit-name")]
        public IWebElement directInputUsername { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#user-login-form > div>input#edit-pass")]
        public IWebElement directInputPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#user-login-form > div>button#edit-submit")]
        public IWebElement directLogInButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#user-login-form > div > div.form-item--error-message")]
        public IWebElement invalidDirectLoginError { get; set; }

        #endregion Direct Login

        #region Dashboard Page Objects

        //[FindsBy(How = How.CssSelector, Using = "#navigation > div > div.nav__item.nav__user-groups > a")]


        //[FindsBy(How = How.CssSelector, Using = "[data-activates='dropdown--user-groups'] .drop-down-menu")]


        //[FindsBy(How = How.CssSelector, Using = "#navigation > div > div.nav__item.nav__user-groups > a[data-activates='dropdown--user-groups']>span")]
        [FindsBy(How = How.XPath, Using = "//*[@id='navigation-second']/div//a[@data-activates='dropdown--user-groups']")]
        public IWebElement myGroupText { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#navigation-second > div > div.nav__item.nav__search > a > span")]
        public IWebElement pCommonsProfilePict { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.card-panel.alt.indent.entity__intro > ul > li:nth-child(1) > a")]
        public IWebElement lnkPosts { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.card-panel.alt.indent.entity__intro > ul > li:nth-child(2) > a")]
        public IWebElement lnkComments { get; set; }

        #endregion Dashboard Page Objects

        //Enter UserName or O365Email Id on the first form
        public void EnteruserName(string userName)
        {
            userNameField.SendKeys(userName);
        }

        public void ClicknextButton()
        {
            nextButton.Click();
        }

        //This Method will be removed after Commons Sprint 2020 Sprint 12 deployement in All the Environment
        public void ClickSSLoginButton()
        {
            ssoLoginButton.Click();
        }

        //public void VerifyMyGroupLink()
        //{
        //    Assert.IsTrue(myGroupText.Displayed);
        //    myGroupText.Click();


        //}

        public void Direct_Login(string userName, string password,string URL)
        {
            driver.Navigate().GoToUrl(URL);
            test.Log(test.Status, "URL has been accessed");
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);          

            EnteruserName(userName);
            ClicknextButton();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            Thread.Sleep(1000);
            directInputPassword.SendKeys(password);

            test.Log(test.Status, "User Id and Password has been Entered");
            directLogInButton.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            Console.WriteLine(userName + " logged in");

            test.Log(test.Status, userName + " has been  logged in");

        }

        public void ADFS_SSO_Login(string userName, string password)
        {
            inputUsername.SendKeys(userName);
            inputPassword.SendKeys(password);
            signInButton.Click();

            test.Log(test.Status, userName + " has been  logged in");

        }

        public string MyGroupText()
        {
            string myGroup = myGroupText.GetAttribute("innerText").ToString();
            Console.WriteLine(myGroup);
            return myGroup;
        }


        public void VerifyMyGroupLink()
        {
            Assert.IsTrue(myGroupText.Displayed);
            myGroupText.Click();
            test.Log(test.Status, "My Group has been  accessed");



        }

        public void SSO_Login(string userName, string password,string URL)
        {
            driver.Navigate().GoToUrl(URL);
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            EnteruserName(userName);
            ClicknextButton();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            inputUsername.SendKeys(userName);
            inputPassword.SendKeys(password);
            signInButton.Click();
           PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            Console.WriteLine(userName + " logged in");

        }



        public void Login(string URL,bool SsoUser)
        {
            string userName = string.Empty;
            string password = string.Empty;
            driver.Navigate().GoToUrl(URL);
            test.Log(test.Status, URL +" has been  accessed");

            PageServices.WaitForPageToCompletelyLoaded(driver, 120);

            if (SsoUser)
            {
                userName = TestContext.Parameters.Get("SSOUserName").ToString(); 
                password = TestContext.Parameters.Get("SSOPassword").ToString();                
                PageServices.WaitForPageToCompletelyLoaded(driver, 120);
                EnteruserName(userName);
                ClicknextButton();
                PageServices.WaitForPageToCompletelyLoaded(driver, 120);
                inputUsername.SendKeys(userName);
                inputPassword.SendKeys(password);
                signInButton.Click();

                test.Log(test.Status, "User Id and Password has been entered and Sign in Clicked");
                PageServices.WaitForPageToCompletelyLoaded(driver, 120);
               


            }
            else
            {
                userName = TestContext.Parameters.Get("NonSSOUserName").ToString();
                password = TestContext.Parameters.Get("NonSSOPassword").ToString();             
                EnteruserName(userName);
                ClicknextButton();
                PageServices.WaitForPageToCompletelyLoaded(driver, 120);
                Thread.Sleep(1000);
                directInputPassword.SendKeys(password);
                directLogInButton.Click();
                test.Log(test.Status, "User Id and Password has been entered and Sign in Clicked");
                PageServices.WaitForPageToCompletelyLoaded(driver, 120);
               // Console.WriteLine(userName + " logged in");
            }



           

           //Assert.IsTrue(loginPage.MyGroupText().Contains(expectedGroupText));
           //test.Log(test.Status, userName + " user has been  logged in");

            Assert.IsTrue(loginPage.CommunityActivityText().Contains(expectedHomeText));
            test.Log(test.Status, userName + " user has been  logged in");

        }

        public void DirectLinkLogin(string userName, string password)
        {     
                inputUsername.SendKeys(userName);
                inputPassword.SendKeys(password);
                signInButton.Click();
                 test.Log(test.Status, "User Id and Password has been entered and Sign in Clicked");
                 Thread.Sleep(3000);
        }


        public void EnvIndicator()
        {
            string color1 = menu_bgcolor.GetCssValue("background-color").ToString();
            test.Log(test.Status,"Verifying Top Menu Background Color1  " + color1);
            if (EnvInd == "QA")
            {
                Assert.AreEqual("rgba(177, 207, 64, 1)", color1);
            }
            else if (EnvInd == "UAT")
            {
                Assert.AreEqual("rgba(218, 165, 32, 1)", color1);
            }
            else if (EnvInd == "DEV")
            {
                Assert.AreEqual("rgba(132, 165, 248, 1)", color1);
            }
            else if (EnvInd == "Prod")
            {
                Assert.AreEqual("rgba(178, 34, 34, 1)", color1);
            }

            else test.Log(test.Status,"Please Recheck the Menu BGColor used for Environment Indicator");

        }

        public string CommunityActivityText()
        {
            string communityActivityText = communityactivityText.GetAttribute("innerText").ToString();
            Console.WriteLine(communityActivityText);
            return communityActivityText;
        }

    }
}
