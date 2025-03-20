using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using SeleniumExtras.PageObjects;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using AventStack.ExtentReports;
using System.Xml.Linq;

namespace Commons_Automation
{
    public class UserInfo:MainSetup
    {
       // Idriver driver;
        public UserInfo()
        {
           // driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(90)));
            
        }


        #region User Menu elements

        public string accountSubMenu = "Account";
        public string inboxSubMenu = "Inbox";
        public string logoutSubMenu = "Log Out";
        public string ProfileSubMenu = "Profile";
        public string unMasqSubMenu = "Unmasquerade";
        public string MyContentSubMenu = "My Content";
        public string MyFollowingSubMenu = "Following";
        string likeTitle = "Like";
        string commentTitle = "Add a comment";

        string myGroupsHeader = "My Groups"; // "MY GROUPS";
        string allMyGroupsText = "All my groups";
        string discoverGroupText = "Discover Groups";
        string discoverGroupHeader = "Discover Groups"; // "DISCOVER GROUPS";
        string followingContentHeader = "Followed Content"; // "FOLLOWED CONTENT";
        string myContentHeader = "My Content";    //"MY CONTENT";
        string privateMessagesHeader = "Chats"; //"CHATS";

        string follow = "Follow";
        string unFollow = "Unfollow";
        string following = "Following";
        string followMsg = "Follow/Unfollow buttons not displayed";
        string actvyTime = "Time of Activity: ";
        string viewCnt = "Number of Views: ";
        string mainHeader = "NCU COMMONS";
        public string notificationSettingsMenu = "Notifications settings";
        public string membershipDirSettingsMenu = "Membership Directory settings";


        [FindsBy(How = How.XPath, Using = "//div[@class='nav__item nav__user-groups']/a/span")]
        public IWebElement myGroupTopMenu { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".entity__intro--title.truncate")]
        public IWebElement LoggedUsrPrfName { get; set; }        

        //[FindsBy(How = How.CssSelector, Using = "#navigation > div > div.nav__item.nav__logo > a")]
        //[FindsBy(How = How.CssSelector, Using = "a[title='home'] > .menu-icon")]
        [FindsBy(How = How.XPath, Using = "//*[@id='navigation-second']//a[@class='button home-icon']")]
        public IWebElement personalCommonsHome { get; set; }

        //[FindsBy(How = How.CssSelector, Using = "#navigation > div > div.nav__item.nav__user-groups > a")]

        //[FindsBy(How = How.CssSelector, Using = "[data-activates='dropdown--user-groups'] .drop-down-menu")]
        [FindsBy(How = How.XPath, Using = "//*[@id='navigation-second']/div//a[@data-activates='dropdown--user-groups']")]

        public IWebElement myGroupText { get; set; }

        [FindsBy(How = How.CssSelector, Using = "ul#dropdown--user-groups > li.dropdown-content--users-groups > a")]
        public IWebElement allMyGroups { get; set; }

        //[FindsBy(How = How.CssSelector, Using = "#navigation > div > div.nav__item.nav__user-personal > a > span")]
        //[FindsBy(How = How.CssSelector, Using = "[data-activates='dropdown--user-personal'] .drop-down-menu")]
        [FindsBy(How = How.XPath, Using = "//div[@class='nav__item nav__user-users'][2]/a/span[@class='drop-down-menu user-me']")]
        public IWebElement userName { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//ul[@id='slide-out']/li/div[@class='user-view']/a[2]/span[@class='white-text name']")]
        public IWebElement loggedusrName { get; set; }        

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/nav[1]/div/div[2]/div/form/div[1]/input")]
        public IWebElement SearchField1 { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/main/section/div/div[1]/form/div[2]/div/div/input")]
        public IWebElement TypeDropDown { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/main/section/div/div[1]/form/div[2]/div/div/ul/li[1]")]
        public IWebElement FilterAny { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/main/section/div/div[1]/form/div[2]/div/div/ul/li[2]")]
        public IWebElement FilterComment { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/main/section/div/div[1]/form/div[2]/div/div/ul/li[3]")]
        public IWebElement FilterContent { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/main/section/div/div[1]/form/div[2]/div/div/ul/li[4]")]
        public IWebElement FilterGroup { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/main/section/div/div[1]/form/div[2]/div/div/ul/li[5]")]
        public IWebElement FilterPerson { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/main/section/div/div[1]/form/div[2]/div/div/ul/li[6]")]
        public IWebElement FilterResourceCenter { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/main/section/div/div[1]/form/div[2]/div/div/ul/li[7]")]
        public IWebElement FilterTag { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/main/section/div/div[1]/form/div[3]/div/div/input")]
        public IWebElement SortDropDown { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/main/section/div/div[1]/form/div[3]/div/div/ul/li[1]")]
        public IWebElement SortByRelevance { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/main/section/div/div[1]/form/div[3]/div/div/ul/li[2]")]
        public IWebElement SortByDate { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/main/section/div/div[1]/form/div[3]/div/div/ul/li[3]")]
        public IWebElement SortByAuthor { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/main/section/div/div[1]/form/div[4]/div/div/input")]
        public IWebElement OrderDropDown { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/main/section/div/div[1]/form/div[4]/div/div/ul/li[1]")]
        public IWebElement OrderAsc { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/main/section/div/div[1]/form/div[4]/div/div/ul/li[2]")]
        public IWebElement OrderDesc { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/main/section/div/div[1]/form/div[5]")]
        public IWebElement SearchButtonOnResultsPg { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/nav[1]/div/div[1]/a")]
        public IWebElement HomePersonalCommons { get; set; }

       // [FindsBy(How = How.XPath, Using = "/html/body/div[1]/main/aside/div/div/div/div[2]/div/header/div/div/div/ul/li[2]/a")]
        [FindsBy(How = How.XPath, Using = "//div[@class='nav__item nav__user-groups']/a[@href='/inbox']")]
        public IWebElement Inbox { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/main/aside/div/div/div/div[2]/div/header/div/div/div/ul/li[1]/a")]
        public IWebElement ProfileTab { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/section[2]/div/div/div[2]/div/div[2]/div[1]/div[2]/a/button")]
        public IWebElement EditProfileForSearch { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/nav[1]/div/div[6]/ul/li[5]/a")]
        public IWebElement AccountTab { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/nav[1]/div/div[6]/ul/li[2]/a")]
        public IWebElement FollowedContent { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/nav[1]/div/div[6]/ul/li[3]/a")]
        public IWebElement MyContent { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/main/aside/div/div/div/div[2]/ul/li[3]/a")]
        public IWebElement NotificationSettings { get; set; }

        [FindsBy(How =How.CssSelector,Using = "#user-account-menu > ul > li")]
        IList<IWebElement> UserAccountMenus { get; set; }
         

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/main/aside/div/div/div/div[2]/ul/li[5]/a")]
        public IWebElement GroupMemberships { get; set; }

        //[FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/nav[1]/div/div[5]/a")]

       // [FindsBy(How = How.CssSelector, Using = "[data-activates='dropdown--user-groups'] .drop-down-menu")]
        [FindsBy(How = How.XPath, Using = "//*[@id='navigation-second']//a[@data-activates='dropdown--user-groups']")]

        public IWebElement MyGroupsMenu { get; set; }

       // [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/nav[1]/div/div[5]/ul/li[2]/a")]
        [FindsBy(How = How.XPath, Using = "//ul[@id='dropdown--user-groups']//a[@href='/my-groups']")]
        public IWebElement AllMyGroups { get; set; }

       // [FindsBy(How = How.XPath, Using = "//div[@class='nav__item nav__user-groups']/ul[@id='dropdown--user-groups']/li[4]/a[@href='/groups']")] // "//*[@id='dropdown--user-groups']/li[4]/a")]
        [FindsBy(How = How.XPath, Using = "//ul[@id='dropdown--user-groups']//a[@href='/groups']")]
        public IWebElement discoverGroupsLink { get; set; }
        

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/nav[1]/div/div[5]/ul/li[4]/a")]
        public IWebElement DiscoverGroups { get; set; }

        [FindsBy(How = How.XPath, Using = "(//*[@class='card card-constrained card-scale'])[1]/a")]
        public IWebElement ViewFirstGroup { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/section[1]/div/div[1]/div[3]/a/i")]
        public IWebElement FirstGroupMenu { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/section[1]/div/div[1]/div[3]/ul/li[3]/a")]
        public IWebElement FirstGrpContent { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/section[1]/div/div[1]/div[3]/ul/li[5]/a")]
        public IWebElement FirstGroupMembers { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/main/section/div/div[1]/input")]
        public IWebElement FilterGroups { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='dropdown--user-personal']/li[1]/a")]
        public IWebElement userProfile { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='content']/h1[2]")]
        public IWebElement myGroupsText { get; set; }

        //[FindsBy(How = How.XPath, Using = "//*[@id='dropdown--user-personal']/li[2]/a")]
        //public IWebElement followingLink { get; set; }
        [FindsBy(How = How.PartialLinkText, Using = "Following")]
        public IWebElement followingLink { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='dropdown--user-personal']/li[2]/a")]
        public IWebElement userFollowing { get; set; }



        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div/div/div/header/h3")]
        public IWebElement followingContentText { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@class='post__actions'])[1]/div[3]/a")]
        public IWebElement unfollowFollow { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='dropdown--user-personal']/li[3]/a")]
        public IWebElement myContentLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.table__header> h2")]
        public IWebElement myContentText { get; set; }

        //[FindsBy(How = How.XPath, Using = "//*[@id='dropdown--user-personal']/li[4]/a")] //Inbox link under User Menu has been removed and Chat link has been created.
        //public IWebElement inboxLink { get; set; }        
            
        [FindsBy(How = How.CssSelector, Using = "div#block-pagetitle-2> h3")]
        public IWebElement privateMessagesText { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='dropdown--user-personal']/li[4]/a/i")]
        public IWebElement accountLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#dropdown--user-personal > li > a")]
        public IList<IWebElement> subMenus{ get; set; }



        [FindsBy(How = How.CssSelector, Using = "#user-account-menu > ul > li > a")]

        [FindsBy(How = How.CssSelector, Using = "ul#dropdown--user-personal > li > a")]
        public IList<IWebElement> userAccountMenus { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='user-account-menu']/ul/li[1]/a")]
        public IWebElement accountHeader { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='dropdown--user-personal']/preceding-sibling::a")]
        public IWebElement userPicture { get; set; }

        [FindsBy(How = How.XPath, Using = "(//*[@class='post__meta'])[1]/a")]
        public IWebElement userNameInActivity { get; set; }

        [FindsBy(How = How.XPath, Using = "(//*[@class='collection-item avatar'])[1]")]
        public IWebElement activityPost { get; set; }

        [FindsBy(How = How.XPath, Using = "(//*[@class='post__meta'])[1]/p[contains(@class,'time')]")]
        public IWebElement timeOfActivity { get; set; }

        [FindsBy(How = How.XPath, Using = "(//*[@class='post__meta'])[1]/p[contains(@class,'view')]")]
        public IWebElement numberOfViews { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@class='post__actions'][1]/div/div/a/span)[1]")]
        public IWebElement grpActivityLike { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.post__actions> div.action-wrapper > a")]
        public IWebElement grpActivityComment { get; set; }        

        [FindsBy(How = How.XPath, Using = "(//*[@class='disabled border action-wrapper'])[1]")]
            //"//*[@id='block-views-block-streams-block-4']/div[2]/div/div[2]/div[1]/article/div/div[2]/div[2]/following-sibling::*")]
        public IWebElement grpActivityFollowUnfollow { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='dropdown--user-personal']/li[7]/a")]
        public IWebElement logout { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='user-login']/h1")]
        public IWebElement verifyLogout { get; set; }

      


        #endregion User Menu elements

        #region User Menu Functionalties 
        public void ClickOnUserMenu()
        {
            userName.Click();
            Thread.Sleep(1500);
            //Used below wait to get populate Sub Menu
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
            test.Log(test.Status, "User Menu Accessed");
        }

        public void ClickOnSearchField1()
        {
            SearchField1.Click();
            //Used below wait to get populate Sub Menu
           /* userInfoDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);*/
        }

        public void ClickProfileTab()
        {
            //ProfileTab.Click();
            userName.Click();
            userProfile.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickPersonalCommons()
        {
            HomePersonalCommons.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickInbox()
        {
            Inbox.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickOnEditProfileTab()
        {
            EditProfileForSearch.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickAccountTab()
        {
           // AccountTab.Click();
            userName.Click();
            PageServices.ClickButtonByJavaScript(driver, accountLink);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickTypeDropDown()
        {
            TypeDropDown.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }
        public void ClickOnTypeAnyFilter()
        {
            FilterAny.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickOnTypeCommentFilter()
        {
            FilterComment.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickOnTypeContentFilter()
        {
            FilterContent.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickOnTypeGroupFilter()
        {
            FilterGroup.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickOnTypePersonFilter()
        {
            FilterPerson.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickOnTypeResourceCenterFilter()
        {
            FilterResourceCenter.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickOnTypeTag()
        {
            FilterTag.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickSortDropDown()
        {
            SortDropDown.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }
        public void ClickOnSortyByRelevance()
        {
            SortByRelevance.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickOnSortyByDate()
        {
            SortByDate.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickOnSortyByAuthor()
        {
            SortByAuthor.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickOrderDropDown()
        {
            OrderDropDown.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickOrderAsc()
        {
            OrderAsc.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickOrderDesc()
        {
            OrderDesc.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickSearchResultsPgSearchButton()
        {
            SearchButtonOnResultsPg.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickFollowedContent()
        {
            // FollowedContent.Click();
            userName.Click();
            //userFollowing.Click();
            PageServices.ClickButtonByJavaScript(driver, userFollowing);
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickMyContent()
        {
            // MyContent.Click();
            userName.Click();
            //myContentLink.Click();
            PageServices.ClickButtonByJavaScript(driver, myContentLink);
            Thread.Sleep(5000);
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            //userInfoDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickNotificationSettings()
        {
            NotificationSettings.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickGroupMemberships()
        {
            AccessUserAccountMenu("Group Memberships");

           // GroupMemberships.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickMyGroupsMenu()
        {
            MyGroupsMenu.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickMyGroups()
        {
            AllMyGroups.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickDiscoverGroups()
        {
           
            // DiscoverGroups.Click();
            //myGroupTopMenu.Click();
            PageServices.ClickButtonByJavaScript(driver, myGroupTopMenu);
            Thread.Sleep(2000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(2000);
            Actions actions = new Actions(driver);
            actions.MoveToElement(discoverGroupsLink);
            PageServices.ClickButtonByJavaScript(driver, discoverGroupsLink);
            //discoverGroupsLink.Click();
            Thread.Sleep(2000);
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);

        }

        public void ClickViewFirstGroup()
        {
            ViewFirstGroup.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickFirstGroupMenu()
        {
            FirstGroupMenu.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickFirstGrpContent()
        {
            FirstGrpContent.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickFirstGrpMembers()
        {
            FirstGroupMembers.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickFilterGroups()
        {
            FilterGroups.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
        }

        public void ClickOnSubMenu(string subMenu)
        {
            Console.WriteLine(subMenus.Count);
            int count = subMenus.Count;
            for (int i = 0; i <count; i++)
            {
                Thread.Sleep(500);
                //Console.WriteLine(subMenus[i].GetAttribute("innerText"));
                string menu = subMenus[i].GetAttribute("innerText");
                if (menu.Contains(subMenu))
                {
                    subMenus[i].Click();
                    test.Log(Status.Info, subMenu+" Is Accessed ");
                    Thread.Sleep(3000);

                    break;
                }
            }
        }

        public void AccessUserAccountMenu(string menuName)
        {
            Console.WriteLine(userAccountMenus.Count);
            for (int i = 0; i <= userAccountMenus.Count; i++)
            {
                Console.WriteLine(userAccountMenus[i].GetAttribute("innerText"));

                if (userAccountMenus[i].GetAttribute("innerText").Contains(menuName))
                {
                    userAccountMenus[i].Click();
                    test.Log(Status.Pass, menuName + " is accessed");
                    break;
                }
            }
        }
        public void AccessAccountMenu()
        {
            ClickOnUserMenu();
            ClickOnSubMenu(accountSubMenu);
            test.Log(Status.Pass, accountSubMenu + " is accessed");
        }


        public void UserMenu()
        {
            /*My Groups */
            personalCommonsHome.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            PageServices.WaitForPageToCompletelyLoaded(driver, 60);  
            PageServices.ClickButtonByJavaScript(driver, myGroupText);
            Assert.That(allMyGroups.Text, Does.Contain(allMyGroupsText).IgnoreCase);
            allMyGroups.Click();
            Assert.AreEqual(myGroupsText.Text, myGroupsHeader);
            personalCommonsHome.Click();
            PageServices.ClickButtonByJavaScript(driver, myGroupText);
            Thread.Sleep(2000);
            Assert.That(discoverGroupsLink.Text, Does.Contain(discoverGroupText).IgnoreCase);
            discoverGroupsLink.Click();
            Assert.AreEqual(myGroupsText.Text, discoverGroupHeader);
            personalCommonsHome.Click();
            /*User Menu */
            userName.Click();
            userProfile.Click();
            string url = driver.Url;
            Assert.That(url, Does.Contain("user").IgnoreCase);
            personalCommonsHome.Click();
            userName.Click();
            Thread.Sleep(2000);
            followingLink.Click();
            Thread.Sleep(2000);
            Assert.AreEqual(followingContentText.Text, followingContentHeader);
            unfollowFollow.Click();
           // Actions actions = new Actions(driver);
            //actions.MoveToElement(unfollowFollow).Click().Build().Perform();
            //PageServices.ClickButtonByJavaScript(driver, unfollowFollow);
            Thread.Sleep(2000);
            Console.WriteLine(unfollowFollow.Text);
            /*This sleep is required as the button needs to be loaded*/
            Thread.Sleep(2000);
            unfollowFollow.Click();
            //PageServices.ClickButtonByJavaScript(driver, unfollowFollow);
            Console.WriteLine(unfollowFollow.Text);
            personalCommonsHome.Click();
            Thread.Sleep(2000);
            userName.Click();
            Thread.Sleep(2000);
            myContentLink.Click();
            Assert.AreEqual(myContentText.Text, myContentHeader);
            personalCommonsHome.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            pvtMsg.chatMenu.Click();
            Assert.AreEqual(privateMessagesText.Text, privateMessagesHeader);
            personalCommonsHome.Click();
            userName.Click();
            Thread.Sleep(2000);
           // Console.WriteLine(unfollowFollow.Text);
            /*This sleep is required as the button needs to be loaded*/
           // Thread.Sleep(2000);
           // unfollowFollow.Click();
          //  Console.WriteLine(unfollowFollow.Text);
            personalCommonsHome.Click();
            Thread.Sleep(2000);
            userName.Click();
            Thread.Sleep(2000);
            myContentLink.Click();
            Assert.AreEqual(myContentText.Text, myContentHeader);
            personalCommonsHome.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            pvtMsg.chatMenu.Click();
            Assert.AreEqual(privateMessagesText.Text, privateMessagesHeader);
            personalCommonsHome.Click();
            userName.Click();
            accountLink.Click();
            // Assert.That(accountHeader.Text, Does.Contain("Account").IgnoreCase);
            Assert.IsTrue(userAccountMenus[0].Text.Contains("Account"));
            personalCommonsHome.Click();
            /*User Activity Links */           
            userPicture.Click();
            personalCommonsHome.Click();
            Thread.Sleep(5000);
            Assert.IsNotNull(userNameInActivity);
            Assert.IsNotNull(activityPost);
            Console.WriteLine(userNameInActivity.Text + " " + activityPost.Text);
            Assert.IsNotNull(timeOfActivity);
            Assert.IsNotNull(numberOfViews);
            Console.WriteLine(actvyTime+ timeOfActivity.Text);
            Console.WriteLine(viewCnt + numberOfViews.Text);
            Assert.AreEqual(grpActivityLike.Text, likeTitle);
            Assert.AreEqual(grpActivityComment.GetAttribute("title"), commentTitle);
            Console.WriteLine(grpActivityFollowUnfollow.Text);
            if(grpActivityFollowUnfollow.Text.Contains(follow) 
                || grpActivityFollowUnfollow.Text.Contains(unFollow) 
                    || grpActivityFollowUnfollow.Text.Contains(following))
            {
                Console.WriteLine("Post "+grpActivityFollowUnfollow.Text);
            }
            else
            {
                Console.WriteLine(followMsg);
            }
           
            test.Log(Status.Info, "User Menu verified ");
        }


        //public void LoggedinUserMenu()
        //{

        //    /*User Menu */
        //    userName.Click();
        //    userProfile.Click();
        //    string url = driver.Url;
        //    Assert.That(url, Does.Contain("user").IgnoreCase);
        //    personalCommonsHome.Click();
        //    userName.Click();
        //    Thread.Sleep(2000);
        //    followingLink.Click();
        //    Thread.Sleep(2000);
        //    Assert.AreEqual(followingContentText.Text, followingContentHeader);
        //    personalCommonsHome.Click();
        //    Thread.Sleep(2000);
        //    userName.Click();
        //    Thread.Sleep(2000);
        //    myContentLink.Click();
        //    Assert.AreEqual(myContentText.Text, myContentHeader);
        //    personalCommonsHome.Click();
        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        //    userName.Click();
        //    inboxLink.Click();
        //    Assert.AreEqual(privateMessagesText.Text, privateMessagesHeader);
        //    personalCommonsHome.Click();
        //    userName.Click();
        //    accountLink.Click();
        //    // Assert.That(accountHeader.Text, Does.Contain("Account").IgnoreCase);
        //    Assert.IsTrue(userAccountMenus[0].Text.Contains("Account"));
        //    personalCommonsHome.Click();
        //    Thread.Sleep(2000);
           
        //}


        public void Logout()
        {
            ClickOnUserMenu();
            Thread.Sleep(2000);
            ClickOnSubMenu(logoutSubMenu);
            Thread.Sleep(1000);
            string homeURL = driver.Url;
            Assert.IsTrue(homeURL.Contains("login"));
            test.Log(Status.Pass,"********* User has been Logout ************");
        }
        public void MyFollowingMenu()
        {
            ClickOnUserMenu();
            ClickOnSubMenu(MyFollowingSubMenu);
            Thread.Sleep(3000);
          
        }

        public void MyContentMenu()
        {
            ClickOnUserMenu();
            
            ClickOnSubMenu(MyContentSubMenu);
            Thread.Sleep(5000);

        }
        #endregion User Menu Functionalties 

        #region Get User Name
        public string GetUserName()
        {
            userInfo.ClickOnUserMenu();
            userInfo.ClickOnSubMenu(userInfo.ProfileSubMenu);
            PageServices.WaitForPageToCompletelyLoaded(driver, 60);
            string loggedUsrPrfName = LoggedUsrPrfName.Text;
            Console.WriteLine(loggedUsrPrfName);
            grpActivity.lnkPersonalCommons.Click();  
            return loggedUsrPrfName;
            
        }
        #endregion Get User Name
    }
}
