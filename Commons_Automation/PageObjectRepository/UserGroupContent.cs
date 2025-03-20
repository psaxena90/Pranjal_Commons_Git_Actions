using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Commons_Automation
{
    public class UserGroupContent:MainSetup
    {
      //  Idriver driver;
       // UserInfo userInfo;
        public UserGroupContent()
        {
           // driver = driver;
           // userInfo = new UserInfo(driver);
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(90)));
        }

        #region UserGroupContent Page Elements



        string myContentHeader = "My Content"; // "MY CONTENT";
        string createdAfterTimeText = "09:00AM";
        string createdBeforeTimeText = "09:00PM";
        string createdAfterDateText = "01/01/2019";
        string createdBeforeDateText = "09/01/2019";
        string content_Any = "- Any -";
        string content_Conv = "Conversation";
        string content_Evt = "Event";
        string content_Upd = "Upload";
        string content_Vid = "Video";
        string tagText = "#test";
        string searchtext = "test";
        string updateText = "has been updated";
        string deleteText = "has been deleted";
        string noContentText = "There is no content to display.";
        string followingContentHeader = "Followed Content"; //"FOLLOWED CONTENT";
        By myContentHeadCSS = By.CssSelector("main[role='main']>section#content > div > div > div > header > div > h2");
        By verificationMsgCSS = By.CssSelector("main[role='main']>section#content > div > div > div > header > div > h2");
        By filterContentCSS = By.CssSelector("form.views-exposed-form > ul > li > div.collapsible-header > a");

        [FindsBy(How = How.CssSelector, Using = "main[role='main']>section#content > div > div > div > header > div > h2")]
        public IWebElement MyContentHeader { get; set; }

        [FindsBy(How = How.CssSelector, Using = "form.views-exposed-form > ul > li > div.collapsible-header > a")]
        public IWebElement filterMyContent { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='views-exposed-form-users-s-content-page-1']/ul/li/div[2]/div/div[1]/div/div/input")]
        public IWebElement publishedStatus { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.collapsible-body > div > div:nth-child(1) > div > div > ul > li:nth-child(2) > span ")]
        public IWebElement publishedStatusOption { get; set; }

        [FindsBy(How = How.Id, Using = "edit-created-after-time")]
        public IWebElement createdAfterTime { get; set; }

        [FindsBy(How = How.Id, Using = "edit-created-before-time")]
        public IWebElement createdBeforeTime { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='views-exposed-form-users-s-content-page-1']/ul/li/div[2]/div/div[4]/div/div/input")]
        public IWebElement contentType { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.collapsible-body > div > div:nth-child(4) > div > div > ul > li:nth-child(1) > span ")]
        public IWebElement contentType_Any { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.collapsible-body > div > div:nth-child(4) > div > div > ul > li:nth-child(2) > span ")]
        public IWebElement contentType_Conv { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.collapsible-body > div > div:nth-child(4) > div > div > ul > li:nth-child(3) > span ")]
        public IWebElement contentType_Evt { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.collapsible-body > div > div:nth-child(4) > div > div > ul > li:nth-child(4) > span ")]
        public IWebElement contentType_Upd { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.collapsible-body > div > div:nth-child(4) > div > div > ul > li:nth-child(5) > span ")]
        public IWebElement contentType_Vid { get; set; }

        [FindsBy(How = How.Id, Using = "edit-field-tags-target-id")]
        public IWebElement tags { get; set; }

        [FindsBy(How = How.Id, Using = "edit-body-value")]
        public IWebElement searchtextBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='views-exposed-form-users-s-content-page-1']/ul/li/div[1]/div/div")]
        public IList<IWebElement> filteredOptions { get; set; }

        [FindsBy(How = How.Id, Using = "edit-submit-users-s-content")]
        public IWebElement applyFilter { get; set; }

        [FindsBy(How = How.Id, Using = "edit-created-after-date")]
        public IWebElement createdAfterDate { get; set; }

        [FindsBy(How = How.Id, Using = "edit-created-before-date")]
        public IWebElement createdBeforeDate { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#content > div > div > div > table > tbody > tr:nth-child(1) > td > div > div > ul > li:nth-child(1) > a")]
        public IWebElement editContent { get; set; }

        [FindsBy(How = How.Id, Using = "edit-submit")]
        public IWebElement save { get; set; }
        //[FindsBy(How = How.XPath, Using = "//*[@id='edit - submit']")]
        //public IWebElement save { get; set; }


        [FindsBy(How = How.CssSelector, Using = "#content > div > div > div > table > tbody > tr:nth-child(1) > td.views-field.views-field-operations > div > div > ul > li.dropbutton-toggle > button")]
        public IWebElement EditContent { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#content > div > div > div > table > tbody > tr:nth-child(1) > td> div > div > ul > li>a[href*='delete']")]
        public IWebElement deleteContent { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='edit_gid_chosen']/a")]
        public IWebElement groupFilter { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#messages > div > div > div.status-messages > div ")]
        public IWebElement verificationMsg { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='edit_gid_chosen']/div/ul/li[2]")]
        public IWebElement groupSelect { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div/div/div/p")]
        public IWebElement noContent { get; set; }

        [FindsBy(How = How.XPath, Using ="//*[@id='content']/div/div/div/nav/ul/li[14]/a/span[2]")]
        public IWebElement lastpage { get; set; }

        [FindsBy(How = How.XPath, Using ="//*[@id='content'/div/div/div/nav/ul/li[1]/a/span[2]")]
        public IWebElement Firstpage { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div/div/div/nav/ul/li[11]/a/span[2]")]
        public IWebElement nextpage { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div/div/div/nav/ul/li[2]/a/span[2]")]
        public IWebElement Previouspage { get; set; }

        #endregion  UserGroupContent Page ElementsF:\Automation\Commons_Automation\Commons_Automation\PageObjectRepository\UserGroupContent.cs

        public void myContent()
        {
            //  userInfo = new UserInfo(driver);
            test.Log(Status.Info, "Accessed My Content form User Menu ");
            userInfo.userName.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            userInfo.myContentLink.Click();
            Assert.AreEqual(userInfo.myContentText.Text, myContentHeader);
            editContent.Click();
            Thread.Sleep(1000);
            save.Click();
            Assert.That(verificationMsg.GetAttribute("textContent"), Does.Contain(updateText).IgnoreCase);
            userInfo.userName.Click();
            userInfo.myContentLink.Click();
            EditContent.Click();
            Thread.Sleep(1000);
            deleteContent.Click();
            save.Click();
            Assert.That(verificationMsg.GetAttribute("textContent"), Does.Contain(deleteText).IgnoreCase);
            userInfo.userName.Click();
            userInfo.myContentLink.Click();
            filterMyContent.Click();
            publishedStatus.Click();
            publishedStatusOption.Click();
            createdAfterDate.SendKeys(createdAfterDateText);
            createdAfterTime.SendKeys(createdAfterTimeText);
            createdBeforeDate.SendKeys(createdBeforeDateText);
            createdBeforeTime.SendKeys(createdBeforeTimeText);
            contentType.Click();
            Thread.Sleep(2000);
            Assert.AreEqual(content_Any, contentType_Any.Text);
            Assert.AreEqual(content_Conv, contentType_Conv.GetAttribute("innerText"));
            Assert.AreEqual(content_Evt, contentType_Evt.GetAttribute("innerText"));
            Assert.AreEqual(content_Upd, contentType_Upd.GetAttribute("innerText"));
            Assert.AreEqual(content_Vid, contentType_Vid.GetAttribute("innerText"));
            contentType_Conv.Click();
            tags.SendKeys(tagText);
            searchtextBox.SendKeys(searchtext);
            applyFilter.Click();
           // Console.WriteLine("apply button click");
            foreach (IWebElement group in filteredOptions)
            {
                string verifyFilter = group.GetAttribute("innerText");

                if (verifyFilter.Equals("Tags: " + tagText))
                {
                    Console.WriteLine(verifyFilter);
                }
                if (verifyFilter.Equals("Search: " + searchtext))
                {
                    Console.WriteLine(verifyFilter);
                }

            }
            //This sleep is required for the options to load
            Thread.Sleep(1000);
            filterMyContent.Click();
            groupFilter.Click();            
            groupSelect.Click();
            applyFilter.Click();
            Assert.AreEqual(noContent.Text, noContentText);

            test.Log(Status.Info, "My Content Page verification complete ");
        }
        public void MyContent()
        {
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            test.Log(Status.Info, "Accessed My Content form User Menu ");
            userInfo.MyContentMenu();
            Console.WriteLine("Content Page Loaded");
           // PageServices.WaitForPageToCompletelyLoaded(driver, 200);
            driver.WaitUntilElementVisible(myContentHeadCSS,120);
            Thread.Sleep(2000);
            Console.WriteLine(MyContentHeader.Text);
           // driver.WaitForReady(driver, 180);            
            Thread.Sleep(5000);
            driver.WaitUntilElementVisible(filterContentCSS, 120);          
            driver.WaitUntilElementClickable(filterMyContent, 120);
            filterMyContent.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            Thread.Sleep(3000);
            driver.WaitUntilElementClickable(publishedStatus, 120);
            publishedStatus.Click();
            Thread.Sleep(2000);
            publishedStatusOption.Click();
            Thread.Sleep(2000);
            createdAfterDate.SendKeys(createdAfterDateText);
            createdAfterTime.SendKeys(createdAfterTimeText);
            createdBeforeDate.SendKeys(createdBeforeDateText);
            createdBeforeTime.SendKeys(createdBeforeTimeText);
            contentType.Click();
            Thread.Sleep(3000);
            Assert.AreEqual(content_Any, contentType_Any.Text);
            Assert.AreEqual(content_Conv, contentType_Conv.GetAttribute("innerText"));
            Assert.AreEqual(content_Evt, contentType_Evt.GetAttribute("innerText"));
            Assert.AreEqual(content_Upd, contentType_Upd.GetAttribute("innerText"));
            Assert.AreEqual(content_Vid, contentType_Vid.GetAttribute("innerText"));
            contentType_Conv.Click();
            Thread.Sleep(5000);
            tags.SendKeys(tagText);
            searchtextBox.SendKeys(searchtext);
            applyFilter.Click();
            test.Log(Status.Info, "Filter Content by Conversation verified ");
            Thread.Sleep(2000);
            foreach (IWebElement group in filteredOptions)
            {
                string verifyFilter = group.GetAttribute("innerText");

                if (verifyFilter.Equals("Tags: " + tagText))
                {
                    Console.WriteLine(verifyFilter);
                }
                if (verifyFilter.Equals("Search: " + searchtext))
                {
                    Console.WriteLine(verifyFilter);
                }

            }
            //This sleep is required for the options to load
            Thread.Sleep(3000);
            driver.WaitUntilElementClickable(filterMyContent, 120);
            filterMyContent.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 300);
            Thread.Sleep(5000);
            driver.WaitUntilElementClickable(groupFilter, 120);
            Actions a = new Actions(driver);
            a.MoveToElement(groupFilter).Build().Perform();
            //PageServices.ClickButtonByJavaScript(driver, groupFilter);
            PageServices.ScrollIntoElement(driver, groupFilter);
            groupFilter.Click();
            Thread.Sleep(3000);
            groupSelect.Click();
            Thread.Sleep(2000);
            applyFilter.Click();
            Thread.Sleep(2000);
            Assert.AreEqual(noContent.Text, noContentText);
            Console.WriteLine("verified no content:" + noContentText);
            test.Log(Status.Info, "Filter Content by Group Type verified ");
            userInfo.MyContentMenu();
            PageServices.WaitForPageToCompletelyLoaded(driver, 200);
            driver.WaitUntilElementVisible(myContentHeadCSS, 120);
            Console.WriteLine(MyContentHeader.Text);
            driver.WaitForReady(180);
            //driver.WaitForReady(driver, 120);
            //Thread.Sleep(5000);
            //PageServices.WaitForPageToCompletelyLoaded(driver, 300);
            Assert.AreEqual(MyContentHeader.Text, myContentHeader);

            driver.WaitUntilElementClickable(editContent, 120);
            editContent.Click();
            Thread.Sleep(5000);
           // driver.WaitForReady(driver, 120);
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            Console.WriteLine(" Edit content");

            //Thread.Sleep(1000);
           // PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            driver.WaitUntilElementClickable(save, 120);
            PageServices.ScrollPageUptoBottom(driver);
            save.Submit();

            test.Log(Status.Info, "Edit Content Verified ");
            // save.Click();
            //driver.WaitForReady(driver, 120);

            //PageServices.WaitForPageToCompletelyLoaded(driver, 600);
            // Thread.Sleep(6000);
            PageServices.ScrollPageUptoBottom(driver);
           Thread.Sleep(6000);
            driver.WaitUntilElementVisible(verificationMsgCSS, 120);
            Assert.That(verificationMsg.GetAttribute("textContent"), Does.Contain(updateText).IgnoreCase);
            Console.WriteLine("Content Saved");
          
            PageServices.WaitForPageToCompletelyLoaded(driver, 500);
            userInfo.MyContentMenu();
            PageServices.WaitForPageToCompletelyLoaded(driver, 200);
            driver.WaitUntilElementVisible(myContentHeadCSS, 120);
            Console.WriteLine(MyContentHeader.Text);
            driver.WaitForReady( 180);
            //driver.WaitForReady(driver, 120);
            //Thread.Sleep(5000);
            //PageServices.WaitForPageToCompletelyLoaded(driver, 300);
            Assert.AreEqual(MyContentHeader.Text, myContentHeader);
            //userInfo.MyContentMenu();

            //Thread.Sleep(5000);
            //driver.WaitForReady(driver, 120);
            //PageServices.WaitForPageToCompletelyLoaded(driver, 500);
            driver.WaitUntilElementClickable(EditContent, 120);
            EditContent.Click();
            Thread.Sleep(5000);
            driver.WaitForReady(120);
            PageServices.WaitForPageToCompletelyLoaded(driver,300);
            deleteContent.Click();
            driver.WaitForReady(120);
            Thread.Sleep(5000);
            Console.WriteLine("Delete Content");
            save.Click();
            driver.WaitForReady(120);
            test.Log(Status.Info, "Delete Content verified ");
            Thread.Sleep(5000);
            Assert.That(verificationMsg.GetAttribute("textContent"), Does.Contain(deleteText).IgnoreCase);
           
        }
        public void FollowingPage()
        {
            userInfo.MyFollowingMenu();
          //  userInfo.userName.Click();
          ////  userGroupContentDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
          //  userInfo.followingLink.Click();
            Thread.Sleep(2000);
            Assert.AreEqual(userInfo.followingContentText.Text, followingContentHeader);
            Console.WriteLine("Compeleted execution");
            test.Log(Status.Info, "My Following Content verified ");
        }
}
}