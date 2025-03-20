using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Commons_Automation
{
    public class PersonalCommons:MainSetup
    {
       // IWebDriver driver;
       


        public PersonalCommons()
        {

           // driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(90)));
            // grpActivity = new GroupsActivity(driver);
            userInfo = new UserInfo();
        }

        #region Expected Texts
        public string expectedGroupText = "My Groups";
        public string expectedPostLinkText = "Posts"; //"POSTS";
        public string expectedPrsnalText = "Personal Commons";
        public string expectedUserNameOnPersonal;
        public string expectedUserNameOnProfilePage;
        public string expectedPvtMsgHeaderText = "Chats"; //"CHATS";
        public string expectedMyInvitationHeaderText = "My Invitations"; //"MY INVITATIONS";
        public string expectedTrainingAndfSupportHeaderText = "Welcome to The Commons Learning Resources"; // "COMMONS RESOURCES AND SUPPORT";
        public string expectedCodeOfConductHeaderText = "CODE OF CONDUCT POLICY";
        public string expectedCodeOfConductLink = "https://www.ncu.edu/consumer-info/code-of-conduct-policy#gref";
        public string expectedTourHeaderText = "Tour NU Commons"; // "TOUR THE COMMONS";
        public string expectedEngagementText = "engagement guidelines";
        public string expectedServiceDeskEmail = "servicedesk@ncu.edu";
        public string expectedFeedbckEmail = "commons@ncu.edu";
        public string expectedAlumniText = "alumni";
        public string expectedAlumniTourText = "Welcome";
        public string expectedAlumnititle = "Welcome Alumnus to the Commons!";
        public string expectedAlumnigroupstitle = "GROUPS";
        public string expectedAlumniactivitytitle = "ACTIVITY FEED";
        public string expectedTopNavigationtitle = "TOP NAVIGATION";
        public string expectedAlumniPersonalCommonstitle = "RETURNING TO YOUR PERSONAL COMMONS";
        public string expectedAlumniSupportNextSteptitle = "ADDITIONAL SUPPORT AND NEXT STEPS";

        #endregion Expected Texts

        #region Dashboard Page Objects

        [FindsBy(How = How.XPath, Using = "/html/body/div[7]/div/header/button/span")]
        public IWebElement closeWelcomeTour { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div/ul/li[3]/a")]
        public IWebElement personalCommonsWelcomeTour { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='navigation']/div/div[3]/a/img")]
        public IWebElement helpTopMenu { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#navigation > div > div.nav__item.nav__user-groups > a")]
        public IWebElement myGroupText { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.nav__item:nth-child(1) > a:nth-child(1)")]
        public IWebElement lnkPersonalCommons { get; set; }


        //[FindsBy(How = How.CssSelector, Using = "#navigation > div > div.nav__item.nav__logo > a")]
        //public IWebElement lnkPersonalCommons { get; set; }

        //[FindsBy(How = How.CssSelector, Using = "#block-views-block-user-s-groups-block-1 > div:nth-child(2) > div > header > div > div > div > div > span:nth-child(2) > a")]
        //[FindsBy(How = How.XPath, Using = "//ul[@id='slide-out']//div[@class='user-view']/a[2]/span")]
        [FindsBy(How = How.XPath, Using = "//*[@class='drop-down-menu user-me']")]
        public IWebElement lblUserNameOnPersonalCommons { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#block-views-block-user-s-groups-block-1 > div > div > header > div > div > div > div > span[class*='user-picture__default'] a")]
        //[FindsBy(How = How.CssSelector, Using = "#block-views-block-user-s-groups-block-1 > div:nth-child(2) > div > header > div > div > div > div > span.circle.user-picture__default > a")]
        public IWebElement pCommonsProfilePict { get; set; }

       // [FindsBy(How = How.CssSelector, Using = "div.card-panel.alt.indent.entity__intro > ul > li:nth-child(1) > a")]
        [FindsBy(How = How.XPath, Using = "//*[@id='tab-posts']/a")]
        public IWebElement lnkPosts { get; set; }

       // [FindsBy(How = How.CssSelector, Using = "div.card-panel.alt.indent.entity__intro > ul > li:nth-child(2) > a")]
        [FindsBy(How = How.XPath, Using = "//li[@id='tab-posts']//following-sibling::li[1]/a")]
        public IWebElement lnkComments { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul[@id='dropdown--user-personal']/li[1]/a")]
        public IWebElement lnkProfile { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#block-views-block-profile-block-1 > div:nth-child(2) > div > div.views-row > div > div > h2")]
        public IWebElement lblUserNameOnProfilePage { get; set; }

        //[FindsBy(How = How.XPath, Using = "//ul/li[2]/a[contains(@href,'inbox')]")]
        //public IWebElement lnkInbox { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#block-pagetitle-2 > h3")]
        public IWebElement lblPrivateMsgHeader { get; set; }

        //[FindsBy(How = How.XPath, Using = "//nav[@id='navigation']//a[contains(@href,'invitations')]")]
        [FindsBy(How = How.XPath, Using = "//*[@id='navigation-second']//a[contains(@href,'invitations')]")]
        public IWebElement lnkInvites { get; set; }

        //[FindsBy(How = How.CssSelector, Using = "#content > div > div > div > header > div > h2")]
        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div/div/div/header/div/h3")]
        public IWebElement lblMyInvitationHeaderText { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#block-views-block-user-s-groups-block-1 > div:nth-child(2) > div > div:nth-child(3) > ul > li")]
        public IList<IWebElement> lstGroups { get; set; }

        public string lblGrpNameCSS = "div > div > span > a";

        public string plusIconPostInGrpCSS = "div > div.allowed-content__container";

        [FindsBy(How = How.CssSelector, Using = "#group-header > div > div > a > h2")]
        public IWebElement lblGroupNameOnGrpHeader { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='block-views-block-user-s-groups-block-1']/div[2]/div/div[2]/ul/li[4]/div/div[1]/span/a")]
        public IWebElement lbllibraryGroupNameOnGrpHeader { get; set; }


        [FindsBy(How = How.LinkText, Using = "NCU Community Forum")]
        public IWebElement lblNCUCommunityGroupNameOnGrpHeader { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='block-views-block-user-s-groups-block-1']/div[2]/div/div[2]/ul/li[1]/div/div[1]/span/a")]
        public IWebElement Groupacademiccenter { get; set; }

        [FindsBy(How = How.XPath, Using = "//form[@id='alumni-optin']/p")]
        public IWebElement aluniOptin { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='edit-confirmation-1']")]
        public IWebElement aluniOptinYes { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul[@class='browser-default']/li[3]/a")]
        public IWebElement alumniTour { get; set; }

        [FindsBy(How = How.XPath, Using = "//h2[@id='tour-tip-welcome-commons-label']")]
        public IWebElement alumniTourText { get; set; }

    
        [FindsBy(How = How.CssSelector, Using = "div[role = 'dialog'] > h2#tour-tip-welcome-alumnus-to-the-commons-label")]
        public IWebElement alumniTourTitle { get; set; }


        [FindsBy(How = How.XPath, Using = "/html/body/div[11]/div/a[1]")]
        public IWebElement alumniTourNextbtn { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[12]/div/a[1]")]
        public IWebElement alumniTourgrpbtn { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[13]/div/a[1]")]
        public IWebElement alumniTouractivitybtn { get; set; }


        [FindsBy(How = How.XPath, Using = "/html/body/div[14]/div/a[1]")]
        public IWebElement alumniTourTopnavigationbtn { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[15]/div/a[1]")]
        public IWebElement alumniTourpersonalcommonbtn { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[16]/div/a[1]")]
        public IWebElement alumniTouradditionalsupportbtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[role = 'dialog'] > h2#tour-tip-groups-label")]
        public IWebElement alumniTourgroupstitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[role = 'dialog'] > h2#tour-tip-activity-feed-label")]
        public IWebElement alumniTouractivitytitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[role = 'dialog'] > h2#tour-tip-top-navigation-label")]
        public IWebElement alumniTourTopNavigationtitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-index] #tour-tip-returning-to-your-personal-commons-label")]
        public IWebElement alumniTourPersonalCommonstitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-index] #tour-tip-additional-support-and-next-steps-label")]
        public IWebElement alumniTourSupportNextSteptitle { get; set; }

        #endregion Dashboard Page Objects

        #region Footer Section Page Objects

        [FindsBy(How = How.CssSelector, Using = "#navigation > div > div > a[data-activates='dropdown--user-help']")]
        public IWebElement HelpMenu { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#navigation > div > div > a[data-activates='dropdown--user-help']+ul>li>a")]
        public IList<IWebElement> lnkHelpSubMenu { get; set; }

        public string lnkTrainingAndSupport = "Training and support";
        public string lnkServiceDesk = "Service desk";
        public string lnkReportAnIssue = "Report an Issue";
        public string lnkCodeOfConduct = "Code of conduct";
        public string lnkEngagementGuidelines = "Engagement guidelines";
        public string lnkTours = "Tours Of Commons";

        //[FindsBy(How = How.CssSelector, Using = "#content > div > section > h1 > span")]
        [FindsBy(How = How.XPath, Using = "(//div/h2[@class='s-lib-box-title'])[4]")]
        public IWebElement lblTrainingAndSupportHeader { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#page-title")]
        public IWebElement lblCodeOfConduct { get; set; }


        [FindsBy(How = How.CssSelector, Using = "#content > div")]
        public IWebElement lblEngagementGuideContent { get; set; }

        [FindsBy(How = How.XPath, Using = "//header[@class='shepherd-header']/h3")]
        public IWebElement WelcomeToursHeader { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#block-pagetitle-2 > h3")]
        public IWebElement lblToursContent { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[@for='edit-preference-alumni-1']")]
        public IWebElement alumniDirOptin { get; set; }

        [FindsBy(How = How.Id, Using = "edit-membership-submit")]
        public IWebElement btnSave { get; set; }


        [FindsBy(How = How.XPath, Using = "//ul[@class='tabs light nub center-align processed']/li/a")]
        public IList<IWebElement> dirTabName { get; set; }

        [FindsBy(How = How.XPath, Using = "//form[@id='views-exposed-form-directory-all']/ul/li/div/a/i")]
        //[FindsBy(How = How.XPath, Using = "(//form[@id='views-exposed-form-directory-all']/ul/li/div/a/i)[2]")]
        public IWebElement filterBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//form[@id='views-exposed-form-directory-alumni']/ul[@class='collapsible exposed-form-collapsible']//span[.='Filter']")]
            //"//form[@id='views-exposed-form-directory-alumni']/ul/li/div/a/i")]
        public IWebElement filterBtnAlumni { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div#directory-views-container>div>div>form>ul > li > div[class*='collapsible-body']> div > div[class*='form-item-school']>div")]
        public IWebElement SchoolDropDown { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#edit_school_chosen > div > div > input")]
        public IWebElement SchoolDropDownInput { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@id='edit-submit-directory']")]
        public IWebElement ApplyBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div#directory-views-container>div>div>form>ul > li > div[class*='collapsible-body']> div > div[class*='form-item-school']>div>div>ul>li")]
        IList<IWebElement> schollList { get; set; }

        [FindsBy(How = How.Id, Using = "edit-name")]
        public IWebElement nameEnter { get; set; }

        [FindsBy(How = How.Id, Using = "edit-specialization")]
        public IWebElement specializationEnter { get; set; }

        [FindsBy(How = How.Id, Using = "edit-email")]
        public IWebElement eMailEnter { get; set; }

        [FindsBy(How = How.Id, Using = "edit-city")]
        public IWebElement cityEnter { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='directory-views-container']/div/div/form/ul/li/div[2]/div/div[2]/div/div")]
        public IWebElement schoolDropdown { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div#directory-views-container>div>div>form>ul > li > div[class*='collapsible-body']> div > div[class*='form-item-program']>div")]
        public IWebElement programDropdown { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div#directory-views-container>div>div>form>ul > li > div[class*='collapsible-body']> div > div[class*='form-item-state']>div")]
        public IWebElement stateDropdown { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div#directory-views-container>div>div>form>ul > li > div[class*='collapsible-body']> div > div[class*='form-item-country']>div")]
        public IWebElement countryDropdown { get; set; }

        //[FindsBy(How = How.CssSelector, Using = "div#directory-views-container>div>div>form>ul > li > div[class*='collapsible-body']> div > div[class*='form-item-military-']>div")]
        [FindsBy(How = How.XPath, Using = "//*[@id='edit_military_branch_chosen']/a")]
        public IWebElement millitaryDropdown { get; set; }

        //[FindsBy(How = How.XPath, Using = "//div[@id='directory-views-container']/div/div/form/ul/li/div[2]/div/div[2]/div/div/ul/li[33]")]
        //public IWebElement programMBA { get; set; }

       //[FindsBy(How = How.XPath, Using = "//div[@id='directory-views-container']/div/div/form/ul/li/div[2]/div/div[3]/div/div/ul/li/span")]
        [FindsBy(How = How.XPath, Using = "//*[@id='edit_program_chosen']/div/ul/li")]
        public IList<IWebElement> programList { get; set; }

        //[FindsBy(How = How.XPath, Using = "//div[@id='directory-views-container']/div/div/form/ul/li/div[2]/div/div[8]/div/div/ul/li/span")]
        [FindsBy(How = How.XPath, Using = "//*[@id='edit_state_chosen']/div/ul/li")]
        public IList<IWebElement> stateList { get; set; }

        //[FindsBy(How = How.XPath, Using = "//div[@id='directory-views-container']/div/div/form/ul/li/div[2]/div/div[9]/div/div/ul/li/span")]
        [FindsBy(How = How.XPath, Using = "//*[@id='edit_country_chosen']/div/ul/li")]
        public IList<IWebElement> countryList { get; set; }

        //[FindsBy(How = How.XPath, Using = "//div[@id='directory-views-container']/div/div/form/ul/li/div[2]/div/div[10]/div/div/ul/li/span")]
        [FindsBy(How = How.XPath, Using = "//*[@id='edit_military_branch_chosen']/div/ul/li")]
        public IList<IWebElement> millitaryList { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='directory-views-container']/div/div/form/ul/li/div[2]/div/div[2]/div/div/ul/li[3]")]
        public IWebElement schoolofBusiness { get; set; }

        

        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        public IWebElement applyBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@value='Reset']")]
        public IWebElement resetBtn { get; set; }

        [FindsBy(How = How.Id, Using = "navigation")]
        public IWebElement navigation { get; set; }
      

        [FindsBy(How = How.XPath, Using = "//div[@class='views-element-container']/div/div/ul/li[1]/div/div[@class='card-content']/div[@class='school']")]
        public IWebElement MemCardSchool { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[@class='views-element-container']/div/div/ul/li[1]/div/div[@class='card-content']/div[@class='start-date']")]
        public IList<IWebElement> MemCardDate { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='views-element-container']/div/div/ul/li[1]/div/div[@class='card-content']")]
        public IWebElement MemCard { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='directory-views-container']/div/div/div/ul/li/div/div/div[@class='name']/a")]
        public IList<IWebElement> searchList { get; set; }

       
        
        #endregion Footer Section Page Objects

        #region Page Object Methods

        public void ClickOnProfilePicFromPersnlComns()
        {
            pCommonsProfilePict.Click();

            test.Log(test.Status, "Acces User Profile from Profile Picture");
        }

        public void ClickOnPersonalCommons()
        {
            lnkPersonalCommons.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 90);
            Thread.Sleep(2000);
            test.Log(test.Status, "Personal Commons Accessed");
        }

        public void VerifyPersonalCommonsLink()
        {
            //  Console.WriteLine("Personal Commons link  " +lnkPersonalCommons.GetAttribute("innertext"));
            Assert.IsTrue(lnkPersonalCommons.Displayed);
        }

        public void LandingPageLeftPane()
        {

            VerifyUserNameonPersonalCommons();
            VerifyPrivateInbox();
            test.Log(test.Status, "Private Inbox Accessed");
            VerifyMyInvitationOption();
           // VerifyPostContentForGroupFromSideBar(0);
            VerifyPostContentForGroupFromSideBar(1);
            GroupNameLibraryGroupHeader();
            // GroupNameNCUcommunityGroupHeader();
            GroupNameASUGroupHeader();
            test.Log(test.Status, "Verify Group Name Header");
            userInfo.ClickOnUserMenu();
            //userInfo.ClickOnSubMenu(userInfo.logoutSubMenu);


        }



        public void ClickOnPlusSignToPostInGroupOnSideBar(int index)
        {
            IWebElement group = lstGroups[index].FindElement(By.CssSelector(plusIconPostInGrpCSS));
            group.Click();

        }

        public void VerifyUserNameonPersonalCommons()
        {
            expectedUserNameOnPersonal = UserNameOnPersonalCommons();
            //ClickOnProfilePicFromPersnlComns();
            userInfo.ClickOnUserMenu();
            lnkProfile.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            Thread.Sleep(3000);
            Assert.AreEqual(expectedPostLinkText, PostLinkText());
            //Assert.IsTrue(PersonalLinkText().Contains(expectedPrsnalText)); //Personal Commons Link Name has been removed.
            ClickOnPersonalCommons();
            userInfo.ClickOnUserMenu();
            lnkProfile.Click();
            expectedUserNameOnProfilePage = UserNameOnProfilePage();
            Console.WriteLine(expectedUserNameOnPersonal);
            Console.WriteLine(expectedUserNameOnProfilePage);
            Assert.AreEqual(expectedUserNameOnPersonal, expectedUserNameOnProfilePage);
            test.Log(test.Status, "User Name on Personal Commons Matching");
        }

        public void VerifyPrivateInbox()
        {
            ClickOnPersonalCommons();
            pvtMsg.chatMenu.Click();
            Assert.AreEqual(expectedPvtMsgHeaderText, PrivateMsgHeaderText());
        }


        public void VerifyMyInvitationOption()
        {
            ClickOnPersonalCommons();
            PageServices.WaitForPageToCompletelyLoaded(driver, 90);
            lnkInvites.Click();
           
            Thread.Sleep(5000);
            Assert.AreEqual(expectedMyInvitationHeaderText, MyInvitationHeaderText());
            test.Log(test.Status, "Access My Invites");
        }

        public void VerifyPostContentForGroupFromSideBar(int groupIndex)
        {
            ClickOnPersonalCommons();
            Thread.Sleep(2000);
            Assert.AreEqual(GetGroupNameSideBarAndClick(groupIndex, true), GroupNameOnGroupHeader());
            ClickOnPersonalCommons();
            ClickOnPlusSignToPostInGroupOnSideBar(groupIndex);
            test.Log(test.Status, "Access Group content from Left Side Menu");

        }

        #region Text Getter Methods

        public string UserNameOnPersonalCommons()
        {
            string userName = lblUserNameOnPersonalCommons.GetAttribute("innerText").ToString().ToLower();
            Console.WriteLine(userName);
            test.Log(test.Status, "Get user name from personal Commons");
            return userName;
        }

        public string UserNameOnProfilePage()
        {
            string userName = lblUserNameOnProfilePage.GetAttribute("innerText").ToString().ToLower();
            Console.WriteLine(userName);
            return userName;
        }

        public string MyGroupText()
        {
            string myGroup = myGroupText.GetAttribute("innerText").ToString();
            Console.WriteLine(myGroup);
            return myGroup;
        }

        public string CommentLinkText()
        {
            string txtComment = lnkComments.GetAttribute("innerText").ToString();
            Console.WriteLine(txtComment);
            return txtComment;
        }
        public string PostLinkText()
        {
            string txtPost = lnkPosts.GetAttribute("innerText").ToString();
            Console.WriteLine(txtPost);
            return txtPost;
        }

        public string PersonalLinkText()
        {
            string txtPersonalCommns = lnkPersonalCommons.GetAttribute("innerText").ToString();
            Console.WriteLine(txtPersonalCommns);
            return txtPersonalCommns;
        }

        public string AlumnioptInText()
        {
            string txtAlumniOptIn = aluniOptin.GetAttribute("innerText").ToString();
            Console.WriteLine(txtAlumniOptIn);
            return txtAlumniOptIn;
        }

        public string AlumniTourText()
        {
            string txtAlumniTour = alumniTourText.GetAttribute("innerText").ToString();
            Console.WriteLine(txtAlumniTour);
            return txtAlumniTour;
        }

        public string AlumnioptInYesText()
        {
            string txtAlumniOptInYes = aluniOptinYes.GetAttribute("checked").ToString();
            Console.WriteLine(txtAlumniOptInYes);
            return txtAlumniOptInYes;
        }



        public string PrivateMsgHeaderText()
        {
            string txtPvtMsgText = lblPrivateMsgHeader.GetAttribute("innerText").ToString();
            Console.WriteLine(txtPvtMsgText);
            return txtPvtMsgText;
        }

        public string MyInvitationHeaderText()
        {
            string txtMyInvitation = lblMyInvitationHeaderText.GetAttribute("innerText").ToString();
            Console.WriteLine(txtMyInvitation);
            return txtMyInvitation;
        }

        public string GetGroupNameSideBarAndClick(int index, bool wantToAccessGroup)
        {
            IWebElement group = lstGroups[index].FindElement(By.CssSelector(lblGrpNameCSS));
            string groupName = group.GetAttribute("innerText").ToString();
            Console.WriteLine(groupName);
            if (wantToAccessGroup)
            {
                group.Click();
            }
            return groupName;
        }


        public string GroupNameOnGroupHeader()
        {
            string groupName = lblGroupNameOnGrpHeader.GetAttribute("innerText").ToString();
            Console.WriteLine(groupName);
            return groupName;
        }

        public string GroupNameLibraryGroupHeader()
        {
            string groupName = lbllibraryGroupNameOnGrpHeader.GetAttribute("innerText").ToString();
            Console.WriteLine(groupName);
            return groupName;
        }

        public string GroupNameNCUcommunityGroupHeader()
        {
            string groupName = lblNCUCommunityGroupNameOnGrpHeader.GetAttribute("innerText").ToString();
            Console.WriteLine(groupName);
            return groupName;
        }

        public string GroupNameASUGroupHeader()
        {
            string groupName = Groupacademiccenter.GetAttribute("innerText").ToString();
            Console.WriteLine(groupName);
            return groupName;
        }


        public string AlumniTouTitle()
        {
            string txtAlumnititle = alumniTourTitle.GetAttribute("innerText").ToString();
            Console.WriteLine(txtAlumnititle);
            return txtAlumnititle;
        }

        public string Alumnitourgrouptitle()
        {
            string txtAlumnigroupstitle = alumniTourgroupstitle.GetAttribute("innerText").ToString();
            Console.WriteLine(txtAlumnigroupstitle);
            return txtAlumnigroupstitle;
        }

        public string alumniactivitytitle()
        {
            string txtAlumniactivitytitle = alumniTouractivitytitle.GetAttribute("innerText").ToString();
            Console.WriteLine(txtAlumniactivitytitle);
            return txtAlumniactivitytitle;
        }

        public string alumnitopNavigationtitle()
        {
            string txtAlumniTopNavigationtitle = alumniTourTopNavigationtitle.GetAttribute("innerText").ToString();
            Console.WriteLine(txtAlumniTopNavigationtitle);
            return txtAlumniTopNavigationtitle;
        }

        public string alumniPersonalCommmonstitle()
        {
            string txtAlumniPersonalCommonstitle = alumniTourPersonalCommonstitle.GetAttribute("innerText").ToString();
            Console.WriteLine(txtAlumniPersonalCommonstitle);
            return txtAlumniPersonalCommonstitle;
        }

        public string alumniSupportNextSteptitle()
        {
            string txtAlumniSupportNextSteptitle = alumniTourSupportNextSteptitle.GetAttribute("innerText").ToString();
            Console.WriteLine(txtAlumniSupportNextSteptitle);
            return txtAlumniSupportNextSteptitle;
        }

        #endregion Text Getter Methods

        //#region Footer Section Method   


        //        public void ClickOnPlusSignToPostInGroupOnSideBar(int index)
        //        {
        //            IWebElement group = lstGroups[index].FindElement(By.CssSelector(plusIconPostInGrpCSS));
        //            group.Click();

        //        }

        //        public void VerifyUserNameonPersonalCommons()
        //        {
        //            expectedUserNameOnPersonal = UserNameOnPersonalCommons();
        //            ClickOnProfilePicFromPersnlComns();
        //            Assert.AreEqual(expectedPostLinkText, PostLinkText());
        //            Assert.IsTrue(PersonalLinkText().Contains(expectedPrsnalText));
        //            ClickOnPersonalCommons();
        //            lnkProfile.Click();
        //            expectedUserNameOnProfilePage = UserNameOnProfilePage();
        //            Assert.AreEqual(expectedUserNameOnPersonal, expectedUserNameOnProfilePage);
        //        }

        //        public void VerifyPrivateInbox()
        //        {
        //            ClickOnPersonalCommons();
        //            lnkInbox.Click();
        //            Assert.AreEqual(expectedPvtMsgHeaderText, PrivateMsgHeaderText());
        //        }


        //        public void VerifyMyInvitationOption()
        //        {
        //            ClickOnPersonalCommons();
        //            lnkInvites.Click();
        //            Assert.AreEqual(expectedMyInvitationHeaderText, MyInvitationHeaderText());
        //        }

        //        public void VerifyPostContentForGroupFromSideBar(int groupIndex)
        //        {
        //            ClickOnPersonalCommons();
        //            Thread.Sleep(2000);
        //            Assert.AreEqual(GetGroupNameSideBarAndClick(groupIndex, true), GroupNameOnGroupHeader());
        //            ClickOnPersonalCommons();
        //            ClickOnPlusSignToPostInGroupOnSideBar(groupIndex);

        //        }

        //#region Text Getter Methods

        //public string UserNameOnPersonalCommons()
        //{
        //    string userName = lblUserNameOnPersonalCommons.GetAttribute("innerText").ToString();
        //    Console.WriteLine(userName);
        //    return userName;
        //}

        //public string UserNameOnProfilePage()
        //{
        //    string userName = lblUserNameOnProfilePage.GetAttribute("innerText").ToString();
        //    Console.WriteLine(userName);
        //    return userName;
        //}

        //public string MyGroupText()
        //{
        //    string myGroup = myGroupText.GetAttribute("innerText").ToString();
        //    Console.WriteLine(myGroup);
        //    return myGroup;
        //}

        //public string CommentLinkText()
        //{
        //    string txtComment = lnkComments.GetAttribute("innerText").ToString();
        //    Console.WriteLine(txtComment);
        //    return txtComment;
        //}
        //public string PostLinkText()
        //{
        //    string txtPost = lnkPosts.GetAttribute("innerText").ToString();
        //    Console.WriteLine(txtPost);
        //    return txtPost;
        //}

        //public string PersonalLinkText()
        //{
        //    string txtPersonalCommns = lnkPersonalCommons.GetAttribute("innerText").ToString();
        //    Console.WriteLine(txtPersonalCommns);
        //    return txtPersonalCommns;
        //}

        //public string AlumnioptInText()
        //{
        //    string txtAlumniOptIn = aluniOptin.GetAttribute("innerText").ToString();
        //    Console.WriteLine(txtAlumniOptIn);
        //    return txtAlumniOptIn;
        //}

        //public string AlumniTourText()
        //{
        //    string txtAlumniTour = alumniTourText.GetAttribute("innerText").ToString();
        //    Console.WriteLine(txtAlumniTour);
        //    return txtAlumniTour;
        //}

        //public string AlumnioptInYesText()
        //{
        //    string txtAlumniOptInYes = aluniOptinYes.GetAttribute("checked").ToString();
        //    Console.WriteLine(txtAlumniOptInYes);
        //    return txtAlumniOptInYes;
        //}



        //public string PrivateMsgHeaderText()
        //{
        //    string txtPvtMsgText = lblPrivateMsgHeader.GetAttribute("innerText").ToString();
        //    Console.WriteLine(txtPvtMsgText);
        //    return txtPvtMsgText;
        //}

        //public string MyInvitationHeaderText()
        //{
        //    string txtMyInvitation = lblMyInvitationHeaderText.GetAttribute("innerText").ToString();
        //    Console.WriteLine(txtMyInvitation);
        //    return txtMyInvitation;
        //}

        //public string GetGroupNameSideBarAndClick(int index, bool wantToAccessGroup)
        //{
        //    IWebElement group = lstGroups[index].FindElement(By.CssSelector(lblGrpNameCSS));
        //    string groupName = group.GetAttribute("innerText").ToString();
        //    Console.WriteLine(groupName);
        //    if (wantToAccessGroup)
        //    {
        //        group.Click();
        //    }
        //    return groupName;
        //}


        //public string GroupNameOnGroupHeader()
        //{
        //    string groupName = lblGroupNameOnGrpHeader.GetAttribute("innerText").ToString();
        //    Console.WriteLine(groupName);
        //    return groupName;
        //}
        //#endregion Text Getter Methods

        #region Help Menu Section Method    
        public void VerifyHelpSubMenus()
        {
            PageServices.WaitForPageToCompletelyLoaded(driver, 60);
            HelpMenu.Click();
            test.Log(Status.Info, "Help Menu Accessed");
            Thread.Sleep(2000);
            int linkCounts = lnkHelpSubMenu.Count;
            Console.WriteLine(linkCounts);
            for (int i = 0; i < linkCounts; i++)
            {

                
                if (lnkHelpSubMenu[i].GetAttribute("innerText") == lnkTrainingAndSupport)
                {
                    string url = driver.Url;
                    lnkHelpSubMenu[i].Click();
                    string title = driver.Title;

                    //Madan : This Condistion will be removed once we have common page on each env.
                    if (title == "The Commons Home - The Commons - LibGuides at Northcentral University")
                    {
                       
                        driver.Navigate().GoToUrl(url);
                        HelpMenu.Click();
                      
                    }
                    else
                    {
                        string actualText = lblTrainingAndSupportHeader.GetAttribute("innerText");
                        Console.WriteLine(actualText);
                        Assert.IsTrue(actualText.Contains(expectedTrainingAndfSupportHeaderText));
                        test.Log(Status.Info, $"{lnkTrainingAndSupport} is accessed and verified");
                        driver.Navigate().Back();
                        PageServices.WaitForPageToCompletelyLoaded(driver, 60);
                        HelpMenu.Click();
                        Thread.Sleep(2000);
                      

                    }
                    continue;
                }

                if (lnkHelpSubMenu[i].GetAttribute("innerText") == lnkServiceDesk)
                {
                    Console.WriteLine(lnkHelpSubMenu[i].GetAttribute("href"));
                    Assert.IsTrue(lnkHelpSubMenu[i].GetAttribute("href").Contains(expectedServiceDeskEmail));
                    test.Log(Status.Info, $"{lnkServiceDesk} is accessed and verified");
                    continue;
                }

                if (lnkHelpSubMenu[i].GetAttribute("innerText") == lnkReportAnIssue)
                {
                    Console.WriteLine(lnkHelpSubMenu[i].GetAttribute("href"));
                    Assert.IsTrue(lnkHelpSubMenu[i].GetAttribute("href").Contains(expectedFeedbckEmail));
                    test.Log(Status.Info, $"{lnkReportAnIssue} is accessed and verified");

                    continue;
                }

                if (lnkHelpSubMenu[i].GetAttribute("innerText") == lnkCodeOfConduct)
                {


                    Console.WriteLine(lnkHelpSubMenu[i].GetAttribute("href"));
                    Assert.IsTrue(lnkHelpSubMenu[i].GetAttribute("href").Contains(expectedCodeOfConductLink));
                    test.Log(Status.Info, $"{lnkReportAnIssue} is accessed and verified");
                    /*
                    lnkHelpSubMenu[i].Click();
                    driver.SwitchTo().Window(driver.WindowHandles.Last());
                    string actualText = lblCodeOfConduct.GetAttribute("innerText");
                    Console.WriteLine(actualText);
                    Assert.IsTrue(actualText.Contains(expectedCodeOfConductHeaderText));
                    test.Log(Status.Info, $"{lnkCodeOfConduct} is accessed and verified");
                    driver.SwitchTo().Window(driver.WindowHandles.Last()).Close();
                    driver.SwitchTo().Window(driver.WindowHandles.First());
                    HelpMenu.Click();
                    Thread.Sleep(2000);
                    */
                    continue;
                }

                if (lnkHelpSubMenu[i].GetAttribute("innerText") == lnkEngagementGuidelines)
                {
                    lnkHelpSubMenu[i].Click();
                    string actualText = lblEngagementGuideContent.GetAttribute("innerText");
                    Console.WriteLine(actualText);
                    Assert.IsTrue(actualText.Contains(expectedEngagementText));
                    test.Log(Status.Info, $"{lnkEngagementGuidelines} is accessed and verified");
                    HelpMenu.Click();
                    Thread.Sleep(2000);

                    continue;
                }

                if (lnkHelpSubMenu[i].GetAttribute("innerText") == lnkTours)
                {
                    lnkHelpSubMenu[i].Click();
                    string actualText = lblToursContent.GetAttribute("innerText");
                    Console.WriteLine(actualText);
                    Assert.IsTrue(actualText.Contains(expectedTourHeaderText));
                    test.Log(Status.Info, $"{lnkTours} is accessed and verified");
                    HelpMenu.Click();
                    Thread.Sleep(2000);

                    continue;
                }
            }
        }
        #endregion Help Menu Section Method 

        public void VerifyAlumniTour()
                {
                    ClickOnPersonalCommons();
                    PageServices.WaitForPageToCompletelyLoaded(driver, 60);
                    // ClickOnPersonalCommons();
                    PageServices.ScrollPageUptoBottom(driver);
                    int linkCounts = lnkHelpSubMenu.Count;
                    Console.WriteLine(linkCounts);
                    for (int i = 0; i < linkCounts; i++)
                    {
                        Console.WriteLine(lnkHelpSubMenu[i].GetAttribute("innerText"));
                        if (lnkHelpSubMenu[i].GetAttribute("innerText") == lnkTours)
                        {
                            lnkHelpSubMenu[i].Click();
                            string actualText = lblToursContent.GetAttribute("innerText");
                            Console.WriteLine(actualText);
                            Assert.IsTrue(actualText.Contains(expectedTourHeaderText));
                        }

                    }

                    alumniTour.Click();
                    test.Log(test.Status, "Clicked and Verify alumni Tour");
                    Assert.IsTrue(AlumniTourText().Contains(expectedAlumniTourText));
                    ClickOnPersonalCommons();
                }

        public void VerifyAlumniWelTour()
        {
            ClickOnPersonalCommons();
            PageServices.WaitForPageToCompletelyLoaded(driver, 60);
            // ClickOnPersonalCommons();
            //PageServices.ScrollPageUptoBottom(driver);
            helpTopMenu.Click();
            int linkCounts = lnkHelpSubMenu.Count;
            Console.WriteLine(linkCounts);
            for (int i = 0; i < linkCounts; i++)
            {
                Console.WriteLine(lnkHelpSubMenu[i].GetAttribute("innerText"));
                if (lnkHelpSubMenu[i].GetAttribute("innerText") == lnkTours)
                {
                    lnkHelpSubMenu[i].Click();
                    personalCommonsWelcomeTour.Click();
                    PageServices.WaitForPageToCompletelyLoaded(driver, 60);                    
                    string actualText = WelcomeToursHeader.GetAttribute("innerText");
                    Thread.Sleep(1000);
                    Console.WriteLine(actualText);
                    Assert.IsTrue(actualText.Contains(expectedAlumnititle));
                    closeWelcomeTour.Click();

                }

            }

            /*
            alumniTour.Click();
            //  Assert.IsTrue(AlumniTouTitle().Contains(expectedAlumniTourText));
            Assert.IsTrue(AlumniTouTitle().Contains(expectedAlumnititle));
            alumniTourNextbtn.Click();
            Console.WriteLine(expectedAlumnititle);
            Assert.IsTrue(Alumnitourgrouptitle().Contains(expectedAlumnigroupstitle));
            alumniTourgrpbtn.Click();
            Console.WriteLine(expectedAlumnigroupstitle);
            Assert.IsTrue(alumniactivitytitle().Contains(expectedAlumniactivitytitle));
            alumniTouractivitybtn.Click();
            Console.WriteLine(expectedAlumniactivitytitle);
            Thread.Sleep(5000);
            PageServices.WaitForPageToCompletelyLoaded(driver, 60);
            Assert.IsTrue(alumnitopNavigationtitle().Contains(expectedTopNavigationtitle));
            alumniTourTopnavigationbtn.Click();
            Console.WriteLine(expectedTopNavigationtitle);
            Assert.IsTrue(alumniPersonalCommmonstitle().Contains(expectedAlumniPersonalCommonstitle));
            alumniTourpersonalcommonbtn.Click();
            Console.WriteLine(expectedAlumniPersonalCommonstitle);
            Thread.Sleep(3000);
            Assert.IsTrue(alumniSupportNextSteptitle().Contains(expectedAlumniSupportNextSteptitle));
            alumniTouradditionalsupportbtn.Click();
            Console.WriteLine(expectedAlumniSupportNextSteptitle);
            Console.WriteLine("The End");  */
        }

        public void VerifyAlumniOptin()
                {
                    Assert.IsTrue(AlumnioptInText().Contains(expectedAlumniText));
                    Assert.IsTrue(AlumnioptInYesText().Contains("true"));

                }

        
                public void VerifyAlumniCardSelected()
                {
                    if (alumniDirOptin.Selected)
                    {
                         Console.WriteLine("Already selected");
                    }
                    else
                    {
                        alumniDirOptin.Click();
                        btnSave.Click();
                    }

            test.Log(test.Status, "Select Alumni Directory Option");

        }

        public void SearchAlumni(string alumniName)
        {
            filterBtn.Click();
            nameEnter.SendKeys(alumniName);
            applyBtn.Click();
            test.Log(test.Status, "Search Alumni");
        }

        public void VerifyAlumniFilters()
        {
            NameFilter();
            SchoolFilter();
            ProgramFilter("MBA");

            specialisationFilter();

            eMailFilter();

            test.Log(test.Status, "Filter Alumnui");


        }

        public void VerifyAlumniStateFilters()
        {
                    
            cityFilter();            
            StateFilter("CA");
            Console.WriteLine("State filter verified");
            CountryFilter("US");
            Console.WriteLine("Country Filter verified");
            MillitaryFilter("US Navy");
            test.Log(test.Status, "Verify Alumni State Filter ");
            Console.WriteLine("Last Line");
        }

        public void StateFilter(String state)
        {
            filterBtnAlumni.Click();
            Thread.Sleep(3000);
            stateDropdown.Click();
            Thread.Sleep(2000);
            int count = stateList.Count;
            Thread.Sleep(3000);
            for (int i = 0; i < count; i++)
            {
                if (stateList[i].Text.Equals(state))
                {
                    PageServices.ClickButtonByJavaScript(driver, stateList[i]);
                    //stateList[i].Click();
                }
            }
            Thread.Sleep(2000);
            applyBtn.Click();
            Thread.Sleep(3000);
            VerifySearchResult();
            Console.WriteLine("aba");
            test.Log(test.Status," StateFilter completed");

        }

        public void CountryFilter(String program)
        {
            filterBtnAlumni.Click();
            Thread.Sleep(3000);
            countryDropdown.Click();
            Thread.Sleep(2000);
            int count = countryList.Count;
            Thread.Sleep(3000);
            for (int i = 0; i < count; i++)
            {
                if (countryList[i].Text.Equals(program))
                {
                    PageServices.ClickButtonByJavaScript(driver, countryList[i]);
                    //countryList[i].Click();
                }
            }
            Thread.Sleep(3000);
            //applyBtn.Click();
            PageServices.ClickButtonByJavaScript(driver, applyBtn);
            Thread.Sleep(3000);
            VerifySearchResult();
            test.Log(test.Status," Alumni CountryFilter completed");
        }

        public void MillitaryFilter(String program)
        {
            filterBtnAlumni.Click();
            Thread.Sleep(3000);
            //millitaryDropdown.Click();
            PageServices.ClickButtonByJavaScript(driver, millitaryDropdown);
            Thread.Sleep(1000);
            int count = millitaryList.Count;
            for (int i = 0; i < count; i++)
            {
                if (millitaryList[i].Text.Equals(program))
                {
                    millitaryList[i].Click();
                }
            }
            Thread.Sleep(2000);
            applyBtn.Click();
            Thread.Sleep(3000);
            VerifySearchResult();
            test.Log(test.Status,"Alumni Millitary Filter completed");
        }

        public void cityFilter()
        {
            filterBtnAlumni.Click();
            Thread.Sleep(3000);
            cityEnter.SendKeys("Orange");
            Thread.Sleep(2000);
            cityEnter.SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            VerifySearchResult();
            test.Log(test.Status,"Alumni cityFilter completed");
        }

        public void eMailFilter()
        {
            filterBtnAlumni.Click();
            Thread.Sleep(3000);
            eMailEnter.SendKeys("@o365");
            Thread.Sleep(1000);
            eMailEnter.SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            VerifySearchResult();
            test.Log(test.Status," Alumni  eMailFilter completed");

        }

        public void specialisationFilter()
        {
            filterBtnAlumni.Click();
            Thread.Sleep(3000);
            specializationEnter.SendKeys("Psychology");
            Thread.Sleep(1000);
            specializationEnter.SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            VerifySearchResult();
            test.Log(test.Status,"Alumni specialisationFilter completed");
        }

        public void ProgramFilter(String program)
        {
            filterBtnAlumni.Click();
            Thread.Sleep(3000);
            programDropdown.Click();
            Thread.Sleep(1000);
            int count = programList.Count;
            for (int i=0;i< count;i++) {
                if (programList[i].Text.Equals(program)) {
                    programList[i].Click();
                }
            }
            Thread.Sleep(1000);
            applyBtn.Click();
            Thread.Sleep(3000);
            VerifySearchResult();
            test.Log(test.Status,"Alumni ProgramFilter completed");
        }

        public void SchoolFilter()
        {
            filterBtnAlumni.Click();
            Thread.Sleep(3000);           
            Console.WriteLine("School options are listed");

            Thread.Sleep(2000);

            SchoolDropDown.Click();
            Thread.Sleep(3000);

            //Madan if we required we can uncomment the below line as per UI Change if we have input box for dropdown
            SchoolDropDownInput.SendKeys("School of Business" + Keys.Tab);
            ApplyBtn.Click();



            //PageServices.WaitForPageToCompletelyLoaded(driver, 160);
           // ApplyBtn.Click();
            //Thread.Sleep(3000);
            //Console.WriteLine(MemCardSchoolName.Text);
            //Assert.IsTrue(MemCardSchoolName.Text.Contains("School of Law"));
            //Thread.Sleep(1000);
            //Console.WriteLine("School of Law is displayed for the JFK User");

            //test.Log(Status.Info, "Verify School in Membership Directory");
            //FilterExpand.Click();
            //Thread.Sleep(2000);
            //Console.WriteLine("School drop down field is clicked.");
            //Console.WriteLine("School options are listed");


            //Thread.Sleep(2000);


            //int schoolListCount = schollList.Count;

            //for (int i = 0; i < schoolListCount; i++)
            //{
            //    if (schollList[i].Text.Contains("School of Business"))
            //    {

            //        Console.WriteLine(schollList[i].Text + " Implemented");
            //        schollList[i].Click();
            //        Thread.Sleep(2000);
            //        test.Log(Status.Pass, schollList[i].Text + "'School of Business' Implemented");
            //        break;
            //    }

            //}



           
            //schoolDropdown.Click();

            //Thread.Sleep(3000);
            //schoolofBusiness.Click();
            //Thread.Sleep(2000);
            //applyBtn.Click();
            //Thread.Sleep(3000);
            VerifySearchResult();
            test.Log(test.Status,"Alumni SchoolFilter completed");
        }

        public void NameFilter() {
            filterBtnAlumni.Click();
            Thread.Sleep(3000);
            nameEnter.SendKeys("Dr.");
            Thread.Sleep(1000);
            nameEnter.SendKeys(Keys.Enter);
            //navigation.Click();
            //applyBtn.Click();

            Thread.Sleep(3000);
            int count = searchList.Count();
            Thread.Sleep(3000);
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    if (searchList[i].Text.Contains("Dr."))
                    {
                        test.Log(Status.Info,"Name Verified and the name is " + searchList[i].Text);
                    }

                }
            }
            else
            {
                test.Log(Status.Info,"Search did not yeild any result");
            }
            Thread.Sleep(1000);
            filterBtnAlumni.Click();
            Thread.Sleep(3000);
            resetBtn.Click();
            Thread.Sleep(1000);

            test.Log(test.Status, "Alumni Name Filter Applied");
        }

        public void VerifySearchResult()
        {
            Thread.Sleep(5000);
            
                int count = searchList.Count();
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        test.Log(Status.Info,"Verified and the name is " + searchList[i].Text);
                        
                    }
                }
                else
                {
                    test.Log(Status.Info,"Search did not yeild any result");
                }


            Thread.Sleep(4000);
            PageServices.ScrollPageUptoTop(driver);
            filterBtnAlumni.Click();
            Thread.Sleep(3000);
            resetBtn.Click();
            Thread.Sleep(4000);
            PageServices.WaitForPageToCompletelyLoaded(driver, 90);

            test.Log(test.Status, "Alumni Search Verified");
        }

        public void VerifyPlacardInfo()
        {
            //Assert.IsTrue(MemCardSchool.Text.Contains("School"));
            Assert.IsTrue(MemCardSchool.Displayed);
            test.Log(Status.Info,"School Verified On Alumni Placard");
            for(int i=0;i<MemCardDate.Count;i++)
            {
                if (MemCardDate[i].Displayed)
                {
                    Assert.IsTrue(true);
                    break;
                }
            }
           
            //Assert.IsTrue(MemCardDate.Text.Contains("Started"));
            Console.WriteLine("Date Verified");
            Assert.IsTrue(MemCard.Displayed);

            test.Log(Status.Info, "Verified On Alumni Placard");
        }

       

        public void OpenDir(string dirName)
        {
            int count = dirTabName.Count;
            
            for (int i=0;i<= count; i++)
            {
                if (dirTabName[i].Text == dirName)
                    dirTabName[i].Click();
                }
                
            }
        }




        #endregion Page Object Methods




    }
        
    