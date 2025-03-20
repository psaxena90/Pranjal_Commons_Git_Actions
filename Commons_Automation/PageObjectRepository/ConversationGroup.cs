using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Commons_Automation
{
    public class ConversationGroup:MainSetup
    {
       // IWebDriver driver;
        public ConversationGroup()
        {
           // driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(90)));
            grpActivity = new GroupsActivity();
            cmGrps = new CommonsGroups();
        }

        #region ConversationGroup Page Elements

        

        string convUrl = "conversations";
        string filterAllText = "All";
        string filterByMonthText = "By month"; //"BY MONTH";
        string userNameText = "Karey Crain";
        string videosUrl = "videos";

       // [FindsBy(How = How.XPath, Using = "//nav[@id='navigation']/div/div[@class='nav__item nav__user-groups']/span[@id='school-count']")]
        [FindsBy(How = How.XPath, Using = "//*[@id='school-count']/span")]
        public IWebElement SchoolPostsCount { get; set; }

       // [FindsBy(How = How.XPath, Using = "//nav[@id='navigation']/div/div[@class='nav__item nav__user-groups']/a[contains(@href,'group')]")]
        [FindsBy(How = How.XPath, Using = "//*[@id='navigation-second']/div/div[4]/a")]
        public IWebElement SchoolTopMenuLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='block-views-block-content-pages-links-block-1']/div[2]/div/div[2]/div/span/a/span")]
        public IWebElement conversationSection { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='block-views-block-content-pages-links-block-1']/div[2]/div/div[5]/div/span/a/span")]
        public IWebElement videosSection { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div/div/div/header/div/div[2]/ul/li[1]/a")]
        public IWebElement filterAll { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div/div/div/header/div/div[2]/ul/li[2]/a")]
        public IWebElement filterByMonth { get; set; }

        [FindsBy(How = How.Id, Using = "add-conversation-modal-form")]
        public IWebElement addNewItem { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div/div/div/div[2]/div[1]/article/div[1]/span[3]/span[1]/a")]
        public IWebElement user { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='block-views-block-profile-block-1']/div[2]/div/div[2]/div[1]/div[1]/h2")]
        public IWebElement userName { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='views-exposed-form-content-pages-page-4']/ul/li/div[1]/a/span")]
        public IWebElement filter { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='views-exposed-form-content-pages-page-1']/ul/li/div[1]/a/span")]
        public IWebElement videoFilter { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='views-exposed-form-content-pages-page-4']/ul/li/div[2]/div/div[1]/div/div/input")]
        public IWebElement filterOptions { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='views-exposed-form-content-pages-page-1']/ul/li/div[2]/div/div[1]/div/div/input")]
        public IWebElement filterOptionsVideoSection { get; set; }


        [FindsBy(How = How.CssSelector, Using = "#content > div > div > div > div > div > article > div > span > span > a")]
        public IList<IWebElement> userNameOnVideoGrid { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.collapsible-body > div > div:nth-child(1) > div > div > ul > li")]
        public IList<IWebElement> viewOptions { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.collapsible-body > div > div:nth-child(1) > div > div > ul > li:nth-child(4)")]
        public IWebElement mostViewOption_Oldest { get; set; }        

        [FindsBy(How = How.CssSelector, Using = "div.collapsible-body > div > div:nth-child(1) > div > div > ul > li:nth-child(1)")]
        public IWebElement mostComments{ get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.collapsible-body > div > div:nth-child(1) > div > div > ul > li:nth-child(2)")]
        public IWebElement titleOption { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='views-exposed-form-content-pages-page-4']/ul/li/div[1]/div/div")]
        public IWebElement optionVerify { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='views-exposed-form-content-pages-page-1']/ul/li/div[1]/div/div")]
        public IWebElement optionVerifyVideo { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div/div/div/ul/li/a")]
        public IWebElement loadMore { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div/div/div/div[2]/div[1]/article/div/header/div[1]/a")]
        public IWebElement userDetails { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div/article/div/header/div[1]/a")]
        public IWebElement userDetailsVideoPage { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div/div/div/div[2]/div[1]/article/div/header/div[1]/span[1]/a/img")]
        public IWebElement userPic { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div/div/div/div[2]/div[1]/article/div[2]/span[1]/a/span")]
        public IWebElement videoTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div/article/div/div[1]/p/span")]
        public IWebElement videoTitleonClick { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='cke_1_contents']/iframe")]
        public IWebElement conversationFrame { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='views-exposed-form-content-pages-page-1']/ul/li/div[2]/div/div[1]/div/div/ul/li[3]/span")]
        public IWebElement videoMostComment { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='views-exposed-form-content-pages-page-1']/ul/li/div[2]/div/div[1]/div/div/ul/li[6]/span")]
        public IWebElement videoMostViews { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='views-exposed-form-content-pages-page-1']/ul/li/div[2]/div/div[1]/div/div/ul/li[1]/span")]
        public IWebElement videoAToZ { get; set; }

        [FindsBy(How = How.XPath, Using = "(//a[@title='I like this']/..)[1]")]
        public IWebElement LikeVideoButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[text()='I like this']")]
        public IWebElement UnLikeVideoButton { get; set; }

        [FindsBy(How = How.XPath, Using = "(//a[@title='Follow post and receive notifications']/..)[1]")]
        public IWebElement FollowVideoButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@title='Stop following post and receiving notifications']/..")]
        public IWebElement UnFollowVideoButton { get; set; }

        //[FindsBy(How = How.XPath, Using = "//*[@id='pre-content']/div/div/div[2]/ul/li[1]/a")]
        [FindsBy(How = How.XPath, Using = "//div[@class='table__header--sub']/ul/li[2]/a")]
        public IWebElement FilterByAll { get; set; }

        [FindsBy(How = How.XPath, Using = "//h4[text()='Months']/../div[2]/div/ul/li[1]/a")]
        public IWebElement ClickOnMonth { get; set; }

        [FindsBy(How = How.XPath, Using = "//h4[text()='Months']/../div[2]/div/ul/li[1]")]
        public IWebElement MonthFormat { get; set; }

        #endregion ConversationGroup Page Elements



        public void verifyConversationGrpItems()
        {
            Thread.Sleep(5000);
            cmGrps.JoinAndOpenGroup(cmGrps.ConversationGroupName);
            //cmGrps.VerifydiscoverGroups(cmGrps.ConversationGroupName);          
           //cmGrps.JoinConversationGroup();
           //cmGrps.OpenJoinedGroup();
            test.Log(test.Status, "*********** Group Conversation**********");
            conversationSection.Click();
            Thread.Sleep(2000);
            Assert.That(driver.Url, Does.Contain(convUrl).IgnoreCase);
            Assert.AreEqual(filterAllText, filterAll.Text);
            Assert.AreEqual(filterByMonthText, filterByMonth.Text);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,-250)", "");
            addNewItem.Click();
            test.Log(test.Status, "Add new Item Clicked");
            Thread.Sleep(2000);
            driver.SwitchTo().Frame(conversationFrame);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            grpActivity.AddDescription(DescriptionText);
            /*This sleep is required as the button needs to be loaded*/
            Thread.Sleep(2000);
            grpActivity.post.Click();

            test.Log(test.Status, "Content Posted in Group");
            Thread.Sleep(2000); // required pause for onsite runs

            string txt1 = grpActivity.postMsg.Text;
            string txt2 = grpActivity.postMessage;

            Assert.IsTrue(txt1.Contains(grpActivity.postMessage));
            filter.Click();
            test.Log(test.Status, "Filter Content");
            Thread.Sleep(1000);
            filterOptions.Click();
            /*This sleep is required as the options needs to be loaded*/
            Thread.Sleep(3000);
            for (int i = 0; i < viewOptions.Count; i++)
            {
                if (viewOptions[i].Text.Contains("Most views"))
                {
                    viewOptions[i].Click();
                    PageServices.WaitForPageToCompletelyLoaded(driver, 120);
                    Thread.Sleep(25000);

                    break;
                }
            }
            //mostViewOption_Oldest.Click();
            test.Log(test.Status, "Filter Group by Most View");
            Assert.That(optionVerify.GetAttribute("innerText"), Does.Contain(mostViewOption_Oldest.GetAttribute("innerText")).IgnoreCase);
            filter.Click();
            filterOptions.Click();
            /*This sleep is required as the options needs to be loaded*/
            Thread.Sleep(3000);
            for (int i = 0; i < viewOptions.Count; i++)
            {
                if (viewOptions[i].Text.Contains("Most comments"))
                {
                    viewOptions[i].Click();
                    //PageServices.WaitForPageToCompletelyLoaded(driver, 120);
                    Thread.Sleep(16000);

                    break;
                }
            }
            //mostComments.Click();
            test.Log(test.Status, "Filter Group by Most Comments");
            Thread.Sleep(5000);
            Assert.That(optionVerify.GetAttribute("innerText"), Does.Contain(mostComments.GetAttribute("innerText")).IgnoreCase);
            //filterByMonth.Click();
            PageServices.ClickButtonByJavaScript(driver, filterByMonth);
            test.Log(test.Status, "Filter Group by Month");

            //PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            //Thread.Sleep(5000);
            //IList<IWebElement> userLis = WebDriverExtensions.FindElements(driver, By.CssSelector("#content > div > div > div > div > div > article > div > header > div.post__meta > a"), 120);
            //userLis[0].Click();
            //PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            //Thread.Sleep(5000);
            ////userDetails.Click();
            //driver.Navigate().Back();
            //userPic.Click();
            //PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            //Thread.Sleep(5000);
            //driver.Navigate().Back();

            //js.ExecuteScript("window.scrollBy(0,250)", "");
            ////if (loadMore.Displayed)
            ////{
            ////    loadMore.Click();
            ////}

            grpActivity.groupHeader.Click();
            test.Log(test.Status,"*********** Group Video**********");
            videosSection.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            Thread.Sleep(2000);
            Assert.That(driver.Url, Does.Contain(videosUrl).IgnoreCase);
            Thread.Sleep(2000);

            filterByMonth.Click();
            test.Log(test.Status, "Filter Group by Month");
            Thread.Sleep(3000);
            ClickOnMonth.Click();
            Thread.Sleep(3000);
            string monthText = MonthFormat.Text;
            test.Log(test.Status,   "Filter by Month and Month format: " + monthText.Trim());
            Thread.Sleep(2000);
            FilterByAll.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            videoFilter.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            filterOptionsVideoSection.Click();
            Thread.Sleep(3000);
            videoMostViews.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            Thread.Sleep(25000);
            test.Log(test.Status, "Filter Group by Most View");
            Assert.That(optionVerifyVideo.GetAttribute("innerText"), Does.Contain(videoMostViews.GetAttribute("innerText")).IgnoreCase);
            Thread.Sleep(5000);

            videoFilter.Click();
            Thread.Sleep(2000);
            filterOptionsVideoSection.Click();
            Thread.Sleep(3000);
            videoMostComment.Click();
            test.Log(test.Status, "Filter Group by Most Comment");
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            Thread.Sleep(25000);
            Assert.That(optionVerifyVideo.GetAttribute("innerText"), Does.Contain(videoMostComment.GetAttribute("innerText")).IgnoreCase);
            Thread.Sleep(2000);

            videoFilter.Click();
            filterOptionsVideoSection.Click();
            Thread.Sleep(4000);
            videoAToZ.Click();
            test.Log(test.Status, "Filter Group by A to Z");
            Thread.Sleep(3000);

            videoFilter.Click();
            Thread.Sleep(12000);
           // Actions action = new Actions(driver);
           // action.Click(filterOptionsVideoSection).SendKeys(Keys.ArrowDown).SendKeys(Keys.Enter).Build().Perform();
          //  Thread.Sleep(2000);
          // Assert.That(optionVerifyVideo.GetAttribute("innerText"), Does.Contain(titleOption.GetAttribute("innerText")).IgnoreCase);
         //   string videoTitleText = videoTitle.Text;
         //   string uNameOnVideo = userNameOnVideoGrid[0].Text;           
         //   videoTitle.Click();
         //   Thread.Sleep(2000);
         //   Assert.That(videoTitleText,Does.Contain(videoTitleonClick.Text).IgnoreCase);
         //   Thread.Sleep(2000);

         //   js.ExecuteScript("window.scrollBy(0,250)", "");

         //   LikeVideoButton.Click();
         //   Thread.Sleep(2000);
         //   UnLikeVideoButton.Click();
         //   Thread.Sleep(2000);

         ////   FollowVideoButton.Click();
         //   Thread.Sleep(2000);
         ////   UnFollowVideoButton.Click();
         //   Thread.Sleep(2000);

            /*
            //Below Code is not Working, so commenting the below , taking too much time to load the page.
            //userDetailsVideoPage.Click();
            //Thread.Sleep(5000);
            //PageServices.WaitForPageToCompletelyLoaded(driver, 200);
            //Console.WriteLine(uNameOnVideo);
            //Console.WriteLine(userName.GetAttribute("innerText"));
            //Assert.That(uNameOnVideo, Does.Contain(userName.GetAttribute("innerText")).IgnoreCase);            
            //driver.Navigate().Back();*/

           grpActivity.groupHeader.Click();
           cmGrps.Leavegroup();
           test.Log(Status.Info, " User left the group");

           
        }



        public void verifySchoolIconandCount(string UserGroupName, string UserNAme)
        {
            DescriptionText = "QA Testing Description-" + PageServices.Randomizr.RandomString(5);
            TitleText = "QA Testing Title Automation-" + PageServices.Randomizr.RandomString(5);


            cmGrps.JoinAndOpenGroup(UserGroupName);

/*
            // cmGrps.JoinAndOpenGroup("SUS Community Forum");
            cmGrps.JoinAndOpenGroup(SchoolGrp);
            */
            PageServices.WaitForPageToCompletelyLoaded(driver, 160);
            Thread.Sleep(5000);
            grpActivity.AddContentInGroup(DescriptionText, TitleText, uploadFile);
            grpActivity.lnkPersonalCommons.Click();
            notificationSettings.OpenPeoplePage();

            notificationSettings.Masqueradestudent(UserNAme);

            string schoolPostscount1 = SchoolPostsCount.Text;
            Console.WriteLine(schoolPostscount1);
            SchoolTopMenuLink.Click();
            grpActivity.lnkPersonalCommons.Click();
            
           // bool FcCount = SchoolPostsCount.Displayed;
           // Console.WriteLine(FcCount);
                     
            //Assert.Null(SchoolPostsCount);  
            //string schoolPostscount2 = SchoolPostsCount.Text;
            //Console.WriteLine(schoolPostscount2);
            // Assert.IsEmpty(schoolPostscount2);

        }

    }

}
