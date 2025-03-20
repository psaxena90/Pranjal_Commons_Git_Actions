using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace Commons_Automation
{
    public class CommonsGroups:MainSetup
    {
       // IWebDriver driver;
      //  UserInfo UserInfo;
        public CommonsGroups()
        {
           // driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(90)));
           // UserInfo = new UserInfo();
        }


        #region Group Page Elements


        //public string searchGroupName = "QA";
        //public string groupName = "QA Conversation Testing";
        //public string privateGroupName = "QA Conversation Private Testing";


        public string ConversationGroupName = "University Community Forum"; //"NCU Community Forum";
        public string PrivateGroupName = "GSSC - Faculty Resource Area"; // "NCU Faculty Senate";
        public string CommunityGroup = "Academic Success Center";
        // string conversationGroup = "QA Conversation Testing";


        public string actualMessage = "You have successfully joined this group";


        public string discoverGroupHeader = "Discover Groups"; //"DISCOVER GROUPS";

        public string memberMenu = "people";
        public string inviteeemail1 = "tempM.Farry9827@o365.ncu.edu,";
        public string inviteeemail2 = "tempM.Whitton5774@o365.ncu.edu";
        public string invalidemail1 = "invalidemail1@o365.ncu.edu,";
        public string invalidemail2 = "invalidemail2@o365.ncu.edu";


        [FindsBy(How = How.XPath, Using = "//div[@class='nav__item nav__user-groups']//a[@href='/groups']//span")]
        public IWebElement discoverGroupsLinkText { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='nav-wrapper']/ul/li/a[text()='Proofreading Service']")]
        public IWebElement proofReadingServiceTab { get; set; }



        [FindsBy(How = How.XPath, Using = "//ul[@id='dropdown--user-groups']//a/span")]
        public IList<IWebElement> myGroupsSubMenus { get; set; }
               

        [FindsBy(How = How.XPath, Using = "//section[@id='content']//table/tbody/tr[1]/td[@class='views-field views-field-group-roles']/ul/li")]
        public IWebElement memberGroupRole { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='cke_1_contents']/iframe")]
        public IWebElement conversationFrame { get; set; }

        //[FindsBy(How = How.XPath, Using = "//*[@id='block-views-block-user-s-groups-block-1']/div[2]/div/footer/a")]
        [FindsBy(How = How.XPath, Using = "//ul[@id='dropdown--user-groups']//a[@href='/groups']")]
        public IWebElement discoverGroupsLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/h1[2]")]
        public IWebElement discoverPageTitle { get; set; }

        //[FindsBy(How = How.Id, Using = "group-search")]
        //public IWebElement filterGroupsSearch { get; set; }
        

        [FindsBy(How = How.XPath, Using = "//*[@class='input-field mobile-content-hidden']/input")]
        public IWebElement filterGroupsSearch { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='navigation']/div/div[1]/a")]
        public IWebElement personalCommonsHome { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='edit-submit']")]
        public IWebElement joinleaveGroup { get; set; }

        //[FindsBy(How = How.LinkText, Using = "My groups")]  
        //To Menu Bar in Commons 2022 Sprint #2 Display Items have been changed.

       // [FindsBy(How = How.CssSelector, Using = "[data-activates='dropdown--user-groups'] .drop-down-menu")]
        [FindsBy(How = How.XPath, Using = "//*[@id='navigation-second']/div//a[@data-activates='dropdown--user-groups']")]

        public IWebElement myGroupsText { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='group-header']/div/div/a/h2")]
        public IWebElement selectedGroup { get; set; }

        //[FindsBy(How = How.XPath, Using = "//*[@id='dropdown--user-groups']/div/div/header/input")]
        [FindsBy(How = How.XPath, Using = "//*[@id='dropdown--user-groups']/li[1]/div/div/header/input")]
        public IWebElement newlyJoinedGroup { get; set; }

        [FindsBy(How = How.ClassName, Using = "light-add-content")]
        public IWebElement addContent { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div/div[1]/div[4]/a")]
        public IWebElement member { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='membership']/li/a")]
        public IWebElement leaveGroupLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#group-list > div > div > div > div> ul > li")]
        public IList<IWebElement> groupList { get; set; }

        //[FindsBy(How = How.XPath, Using = "//*[@id='dropdown--user-groups']/div/div/div/ul/li")]
        [FindsBy(How = How.XPath, Using = "//*[@id='dropdown--user-groups']/li[1]/div/div/div/ul/li")]
        public IList<IWebElement> myGroupsList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#messages > div > div > div.status-messages > div")]
        public IWebElement successMessage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#group-header > div > div.flex.flex-align-center.relative.flex-row > div.manage > a > i")]
        public IWebElement groupMenuLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#manage > li > a > i")]
        //[FindsBy(How = How.XPath, Using = "/html//ul[@id='dropdown--user-groups']/li")]
        public IList<IWebElement> groupSubMenus { get; set; }


        //[FindsBy(How = How.XPath, Using = "//i[@class='material-icons left']")]
        //public IWebElement filterMembers { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#views-exposed-form-group-members-page-1 > ul > li > div.collapsible-header > a > i")]
        public IWebElement filterMembers { get; set; }



        [FindsBy(How = How.Id, Using = "edit-field-name-value")]
        public IWebElement filterMembersSearchField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#edit-submit-group-members")]
        public IWebElement filterMembersApplyBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".views-field.views-field-group-roles > ul > li")]
        public IWebElement memberRole { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Edit member')]")]
        public IWebElement editMemberRoleDD { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='edit-group-roles']/div[2]/label[@class='option']")]
        public IWebElement stewardCheckBtnClick { get; set; }

        //[FindsBy(How = How.CssSelector, Using = "#edit-group-roles-community-steward")]
        //public IWebElement stewardCheckBtn { get; set; }
        // [FindsBy(How = How.CssSelector, Using = "#edit-group-roles-community-steward")]
        [FindsBy(How = How.CssSelector, Using = "input[id$=-steward]")]
        //  "edit-group-roles-community-open-steward"
        public IWebElement StewardCheckBtn { get; set; }

        // [FindsBy(How = How.CssSelector, Using = "#edit-group-roles-community-steward + label")]
        [FindsBy(How = How.CssSelector, Using = "input[id$=-steward] + label")]
        public IWebElement StewardCheckLabel { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#edit-group-roles-conversation-steward")]
        public IWebElement StewardConGrpCheckBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#edit-group-roles-conversation-steward +label")]
        public IWebElement StewardConGrpCheckLabel { get; set; }
                       
        [FindsBy(How = How.CssSelector, Using = "#edit-submit")]
        public IWebElement saveBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".badge.ncu-red-color-back.new.no-after")]
        public IWebElement stewardIcon { get; set; }


        [FindsBy(How = How.CssSelector, Using = ".material-icons.processed.tooltipped")]
        public IWebElement stewardListIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='stewards-list']//li ")]
        public IList<IWebElement> stewardList { get; set; }

        [FindsBy(How = How.CssSelector, Using = " .truncate")]
        public IWebElement stewardName { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".m-0")]
        public IWebElement GroupIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//i[@class='large material-icons']")]
        public IWebElement plusIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@data-tooltip='Conversation']")]
        public IWebElement postConversationIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='manage']/a/i")]
        public IWebElement MenuIcon { get; set; }

        //[FindsBy(How = How.XPath, Using = "//div[@class='manage']/ul/li[7]")]
        [FindsBy(How = How.XPath, Using = "//ul[@id='manage']/li[7]/a")]
        public IWebElement InviteDropdown { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".btn:nth-of-type(2) .material-icons")]
        public IWebElement InviteUserBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "textarea#edit-emails")]
        public IWebElement EmailTextArea { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='js-form-item form-item js-form-type-select form-item-group-invite-template js-form-item-group-invite-template input-field']/div/div/input")] // "input.select-dropdown.valid")]
        public IWebElement EmailTemplate { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul[@class='dropdown-content select-dropdown']/li")]
        public IList<IWebElement> EmailTemplateDrpDwnList { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".js-form-item-group-invite-template li:nth-of-type(2) span")]
        public IWebElement EmailTemplateDrpDwnoption2 { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button#edit-submit")]
        public IWebElement InviteSubmitBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".status-messages__item")]
        public IWebElement statusmessage { get; set; }
        

        [FindsBy(How = How.XPath, Using = "//form[@id='views-exposed-form-group-invitations-page-1']/ul/li/div/a")]
        public IWebElement inviteSearchBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//form[@id='views-exposed-form-group-invitations-page-1']/ul/li/div[2]/div/div/input")]
        public IWebElement Invitee { get; set; }

        [FindsBy(How = How.XPath, Using = "//form[@id='views-exposed-form-group-invitations-page-1']/ul/li/div[2]/div/div[2]/button")]
        public IWebElement ApplyBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "/html//div[@id='block-views-block-user-s-groups-block-1']/div[2]/div//ul[@class='list']/li[2]/div//span/a[@href='/group/center-for-teaching-and-learning']")]
        public IWebElement CTLLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='cke_1_contents']/iframe")]

        public IWebElement ConvsFrame { get; set; }

        [FindsBy(How = How.CssSelector, Using = "html > body[class*='cke_editable']")]

        public IWebElement inputMessage { get; set; }


        //[FindsBy(How = How.CssSelector, Using = "[aria-labelledby='cke_34_label'] .cke_button__drupalimage_icon")]
        [FindsBy(How = How.XPath, Using = "(//span[@class='cke_toolgroup']/a/span[@class='cke_button_icon cke_button__drupalimage_icon'])[1]")]

        public IWebElement wysiwygImg { get; set; }

        [FindsBy(How = How.XPath, Using = "/html//input[@name='files[fid]']")]

        public IWebElement wysiwygupload { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".js-form-item-attributes-alt .form-text")]

        public IWebElement wysiwygText { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='editor-image-dialog-form']//button[@name='op']")]

        public IWebElement SaveEmbImg { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='node-text-form node-form']//button[contains(@id,'edit-submit')]")]

        public IWebElement postBtn { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='navigation']/div/div[1]/a")]

        public IWebElement GoToHomePgae { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div:nth-of-type(1) > article[role='article'] .contextual > .trigger.visually-hidden")]

        public IWebElement EditLastPostBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div:nth-of-type(1) > article[role='article'] .contextual > .contextual-links > li:nth-of-type(1) > a")]

        public IWebElement EditPostLink { get; set; }


        [FindsBy(How = How.CssSelector, Using = "input#edit-field-tags-target-id")]

        public IWebElement TagField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button#edit-submit")]

        public IWebElement SaveBttn { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".nav__search #edit-search-api-fulltext")]

        public IWebElement GotoSearch { get; set; }


        [FindsBy(How = How.CssSelector, Using = "#edit-submit-search-results")]

        public IWebElement btnSearch { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body")]

        public IWebElement ResultsBody { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[@id='cke_1_contents']/iframe")]

        public IWebElement editPostFrame { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[@class='views-infinite-scroll-content-wrapper clearfix']/div[3]/article/div/div[2]/div[2]/a")]
        public IWebElement clickComment { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/p")]
        public IWebElement description { get; set; }

        [FindsBy(How = How.Id, Using = "edit-submit")]
        public IWebElement post { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='views-infinite-scroll-content-wrapper clearfix']/div[3]/article/div/header/div/a")]
        public IWebElement verifyName { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".card-title.name.text-shadow")]
        public IWebElement verifyGrpNamePoll { get; set; }

        #region ASC Payment Elements

        [FindsBy(How = How.XPath, Using = "//select[@id='asc_proofreader_cost_options']/option")]
        public IList<IWebElement> selectProofreaderDuration { get; set; }


        [FindsBy(How = How.XPath, Using = "//select[@id='asc_proofreader_cost_options']")]
            //"//select[@id='asc_proofreader_cost_options']/option[2]")]
        public IWebElement GetProofreaderDurationValue { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div > select[name='asc_proofreader_cost_options']")]
        public IWebElement SelectASCCostDurationValue { get; set; }



        [FindsBy(How = How.XPath, Using = "//select[@id='CARD_TYPE']")]
        public IWebElement selectCardTypeDefaultValue { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@id='CARD_TYPE']/option")]
        public IList<IWebElement> selectCardType { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='CREDITCARD_NBR']")]
        public IWebElement inputCreditCardNumber { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@id='ACCOUNT_MONTH']")]
        public IWebElement selectedDefaultMonth { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@id='ACCOUNT_MONTH']/option")]
        public IList<IWebElement> selectExpirationDate { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@id='ACCOUNT_YEAR']")]
        public IWebElement selectedDefaultYear { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@id='ACCOUNT_YEAR']/option")]
        public IList<IWebElement> selectExpirationYear { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='COMMENT']")]
        public IWebElement inputComment { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Amount:']/../div/span")]
        public IWebElement getAmount { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[text()='Receipt: ']/../div[2]/div/span")]
        public IWebElement getReceipt { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='LEARNER_ID']")]
        public IWebElement getLearnerId { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@id='CREDITCARD_NBR-error']")]
        public IWebElement getCreditCardNumberValidation { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='btnPay']")]
        public IWebElement payButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='eCheckRadioInput']")]
        public IWebElement echeckRadioButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@id='CHECKING_ACCOUNT_NBR-error']")]
        public IWebElement getAccountNumberValidationText { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@id='ROUTING_NBR-error']")]
        public IWebElement getABARoutinNumberValidationText { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='nav__item nav__other-links']/ul/li")]
        public IList<IWebElement> ASCProofreaderText { get; set; }

        [FindsBy(How = How.XPath, Using = "//h3[text()='ASC Proofreader Costs and Durations']")]
        public IWebElement ASCProofreaderheaderText { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[@class='responsive-enabled']/tbody/tr")]
        public IList<IWebElement> GetASCCostAndDurationRows { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[@class='responsive-enabled']/tbody/tr[1]/td[1]")]
        public IWebElement getCostValue { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[@class='responsive-enabled']/tbody/tr[1]/td[2]")]
        public IWebElement getdurationValue { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[@class='responsive-enabled']/tbody/tr[1]/td[3]/div/div/ul/li")]
        public IList<IWebElement> EditASCRow { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[@class='responsive-enabled']/tbody/tr[1]/td[3]/div/div/ul/li[@class='dropbutton-toggle']")]
        public IWebElement EditASCtoggle { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@value='Save']")]
        public IWebElement SaveButtonEditASCRow { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@id='edit-submit-cancel']")]
        public IWebElement CancelButtonEditASC { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@id='edit-delete']")]
        public IWebElement DeleteButtonEditASC { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'edit-duration')]")]
        public IWebElement EditASCDuration { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'edit-cost')]")]
        public IWebElement EditASCCost { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='edit-unit-hour']/../label")]
        public IWebElement EditASCUnit { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@id='edit-cancel']")]
        public IWebElement CancelButtonFromDeletePage { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@value='Delete']")]
        public IWebElement DeleteButtonFromDeletePage { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='edit-submit']/following-sibling::a[2]")]
        public IWebElement CancelButtonFromEditPage { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='edit-submit']/following-sibling::a[1]")]
        public IWebElement DeleteButtonFromEditPage { get; set; }

        [FindsBy(How = How.XPath, Using = "//h4[text()='ASC Proofreading Service']")]
        public IWebElement ASCProofReaderHeader { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div#block-views-block-user-s-groups-block-1 .list > li")]
        public IList<IWebElement> LeftmenuGroups { get; set; }


        [FindsBy(How = How.CssSelector, Using = "input#FIRST_NAME")]
        public IWebElement txtFirstName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input#LAST_NAME")]
        public IWebElement txtLastName { get; set; }

        [FindsBy(How = How.Id, Using = "COMMENT")]
        public IWebElement txtComments { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='OperatorId']")]
        public IWebElement LearnerName { get; set; }


        #endregion

        #endregion Group Page Elements

        #region verifydiscoverGroups
        public void VerifydiscoverGroups( string GroupName)

        {
            personalCommonsHome.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            //Assert.IsTrue(discoverGroupsLink.Displayed);
            test.Log(test.Status,"Discover Groups link available and Clicked On it");
            //discoverGroupsLink.Click();
            userInfo.ClickMyGroupsMenu();

            OpenMyGroupMenu("Discover Groups");
            Assert.AreEqual(discoverPageTitle.Text, discoverGroupHeader);
            filterGroupsSearch.Clear();           
            filterGroupsSearch.SendKeys(GroupName);
            Thread.Sleep(5000);
            test.Log(test.Status,"***** Group Searched ****");
        }

        //public void DiscoverAndSearchGroups(string groupName)
        //{
        //    Assert.IsTrue(discoverGroupsLink.Displayed);
        //    Console.WriteLine("Discover Groups link available");
        //    discoverGroupsLink.Click();
        //    Assert.AreEqual(discoverPageTitle.Text, discoverGroupHeader);
        //    filterGroupsSearch.Clear();
        //    filterGroupsSearch.SendKeys(groupName);
        //}

        #endregion verifydiscoverGroups
                  
       #region Join and Open Group

        public void JoinGroup(string groupName = "")
        {
            int i = 1;
            foreach (IWebElement group in groupList)
            {
                string[] stringSeparators = new string[] { "\r\n" };
                string[] cardLines = group.Text.Split(stringSeparators, StringSplitOptions.None);

                if (cardLines.Count() > 0)
                {
                    if (cardLines[0].Equals(groupName) && cardLines[5].Contains("Join"))
                    {
                        Console.WriteLine("Group Name : " + cardLines[0]);
                        IWebElement joinMember = group.FindElement(By.XPath("//*[@id='group-list']/div[2]/div/div/div[2]/ul/li[" + i + "]/div/span/div/div/span/a"));
                        joinMember.Click();
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                        joinleaveGroup.Click();
                        break;
                    }
                    if (cardLines[0].Equals(PrivateGroupName) && cardLines[5].Contains("Private"))
                    {
                        Console.WriteLine("Group Name : " + groupName);
                        IWebElement joinMember = group.FindElement(By.XPath("//*[@id='group-list']/div[2]/div/div/div[2]/ul/li[" + i + "]/div/span/div/div/span/a"));
                        joinMember.Click();
                        Assert.AreEqual(discoverPageTitle.Text, discoverGroupHeader);
                        break;
                    }
                    i++;
                }
            }

        }


        public void JoinConversationGroup(string GroupName)
        {
            int i = 1;
            foreach (IWebElement group in groupList)
            {
                string[] stringSeparators = new string[] { "\r\n" };
                string[] cardLines = group.Text.Split(stringSeparators, StringSplitOptions.None);

                if (cardLines.Count() > 0)
                {
                    if (cardLines[0].ToLower().Equals(GroupName.ToLower()) && cardLines[5].Contains("Join"))
                    {
                        Console.WriteLine("Group Name : " + cardLines[0]);
                       
                        IWebElement joinMember = group.FindElement(By.CssSelector("div > span > div > div >span"));
                        string txt = joinMember.Text;
                        joinMember.Click();
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                        joinleaveGroup.Click();
                        Console.WriteLine("*************** Group Joined **************");
                        break;
                    }
                    if (cardLines[0].ToLower().Equals(GroupName.ToLower()) && cardLines[5].Contains("Private"))
                    {
                        Console.WriteLine("Group Name : " + GroupName);

                        IWebElement joinMember = group.FindElement(By.CssSelector("div > span > div > div >span.text-icon-container"));
                        //IWebElement joinMember = group.FindElement(By.XPath("//*[@id='group-list']/div[2]/div/div/div[2]/ul/li[" + i + "]/div/span/div/div/span/a"));
                        joinMember.Click();
                        Console.WriteLine("*************** Group Joined **************");
                        Assert.AreEqual(discoverPageTitle.Text, discoverGroupHeader);
                        break;
                    }
                    if (cardLines[0].ToLower().Equals(GroupName.ToLower()) && cardLines[5].Contains("You are a member"))
                    {
                        Console.WriteLine("Group Name : " + cardLines[0]);
                        IWebElement viewGoup = group.FindElement(By.CssSelector("div > span > div > div > span"));
                        PageServices.ClickButtonByJavaScript(driver,viewGoup);                       
                        Console.WriteLine("*************** Group View Open **************");
                        break;
                    }

                    i++;
                }

            }
        }

        public void JoinConversationGroup_Old(string GroupName )
        {
            test.Log(test.Status, "Verify Group in Search Result and Join");
            int i = 1;
            foreach (IWebElement group in groupList)
            {
                string[] stringSeparators = new string[] { "\r\n" };
                string[] cardLines = group.Text.Split(stringSeparators, StringSplitOptions.None);

                if (cardLines.Count() > 0)
                {
                    string CLine1 = cardLines[0].ToLower();
                    string CLine6 = cardLines[5];

                    if (CLine1.Equals(GroupName.ToLower()) && CLine6.Contains("Join"))
                    {
                        test.Log(test.Status,"Group Name : " + cardLines[0]);
                        //"#group-list > div> div > div > div> ul > li > div > span > div > div > a.view"
                        
                        //IWebElement joinMember = group.FindElement(By.XPath("//*[@id='group-list']/div[2]/div/div/div/div[2]/ul/li[" + i + "]/div/span/div/div/span/a"));
                        IWebElement joinMember = group.FindElement(By.CssSelector("div > span > div > div >span"));
                        string txt = joinMember.Text;
                        joinMember.Click();
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                        joinleaveGroup.Click();
                        test.Log(test.Status,"*************** Group Joined **************");
                        break;
                    }
                    if (CLine1.Equals(GroupName) && CLine6.Contains("Private"))
                    {
                        test.Log(test.Status,"Group Name : " + GroupName);
                        
                        IWebElement joinMember = group.FindElement(By.CssSelector("div > span > div > div >span.text-icon-container"));
                        //IWebElement joinMember = group.FindElement(By.XPath("//*[@id='group-list']/div[2]/div/div/div[2]/ul/li[" + i + "]/div/span/div/div/span/a"));
                        joinMember.Click();
                        test.Log(test.Status,"*************** Group Joined **************");
                        Assert.AreEqual(discoverPageTitle.Text, discoverGroupHeader);
                        break;
                    }
                    if (CLine1.Equals(GroupName) && CLine6.Contains("You are a member"))
                    {
                        test.Log(test.Status,"Group Name : " + cardLines[0]);
                        IWebElement viewGoup = group.FindElement(By.CssSelector("div > span > div > div > span"));
                        viewGoup.Click();
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                        //joinleaveGroup.Click();
                        test.Log(test.Status,"*************** Group View Open **************");
                        break;
                    }

                    i++;
                }

            }
        }
        public void VerifyPrivateGroup(string GroupName)
        {
            test.Log(test.Status, "Verify Private Group");
            int i = 1;
            foreach (IWebElement group in groupList)
            {
                string[] stringSeparators = new string[] { "\r\n" };
                string[] cardLines = group.Text.Split(stringSeparators, StringSplitOptions.None);

                if (cardLines.Count() > 0)
                {
                    if (cardLines[0].Equals(GroupName) && cardLines[6].Contains("Private"))
                    {
                        test.Log(test.Status,"Group Name : " + cardLines[0]);
                        IWebElement joinMember = group.FindElement(By.XPath("//*[@id='group-list']/div[2]/div/div/div[2]/ul/li[" + i + "]/div/span/div/div/span[1]"));
                        joinMember.Click();
                        Assert.AreEqual(discoverPageTitle.Text, discoverGroupHeader);
                        test.Log(test.Status,GroupName+ " Group Joined");
                        break;
                    }
                    i++;
                }

            }
        }

        public void OpenJoinedGroup_ByGroupName(string groupName)
        {
            test.Log(test.Status, "Accessed My Group Menu to Open Menu");
            myGroupsText.Click();
            newlyJoinedGroup.SendKeys(groupName);

            for (int i = 0; i < myGroupsList.Count; i++)
            {
                if (myGroupsList[i].Text.ToLower().Equals(groupName.ToLower()))
                {
                    myGroupsList[i].Click();
                    break;
                }
            }
            Assert.AreEqual(selectedGroup.Text.ToLower(), groupName.ToLower());
            test.Log(test.Status,"Selected Group : " + selectedGroup.Text);
        }

        public void OpenJoinedGroup(string GroupName)
        {
            test.Log(test.Status, "Accessed My Group Menu");
            myGroupsText.Click();
            newlyJoinedGroup.SendKeys(GroupName);

            for (int i = 0; i < myGroupsList.Count; i++)
            {
                if (myGroupsList[i].Text.ToLower().Equals(GroupName.ToLower()))
                {
                    myGroupsList[i].Click();
                    test.Log(test.Status,"*************** Group Opened **************");
                    break;
                }
            }
            Assert.AreEqual(selectedGroup.Text, GroupName);
            test.Log(test.Status,"Selected Group : " + selectedGroup.Text);
        }

        public void JoinAndOpenGroup(string GroupName)
        {
            VerifydiscoverGroups(GroupName);
            JoinConversationGroup(GroupName);
            OpenJoinedGroup(GroupName);
           
            Thread.Sleep(2000);
            
        }
        public void JoinAndOpenGroup1(string GroupName)
        {
            VerifydiscoverGroups(GroupName);
            JoinConversationGroup(GroupName);
            // OpenJoinedGroup(GroupName);
            verifyGrpNamePoll.Click();

            Thread.Sleep(2000);

        }

        public void commenton2ndPost()
        {
            test.Log(test.Status, "Click on Comment and Added Comment");
            PageServices.ClickButtonByJavaScript(driver, clickComment);// clickComment.Click();
            Thread.Sleep(3000);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.SwitchTo().Frame(conversationFrame);
            description.Click();
            Thread.Sleep(700);
            Actions a = new Actions(driver);
            a.Click(description).SendKeys("Test").Build().Perform();
            driver.SwitchTo().DefaultContent();

            Thread.Sleep(3000);
            post.Click();

            test.Log(test.Status, "Comment Added ");

        }

        public void VerifyNavigate()
        {
            if (verifyName.Displayed)
            {
                Console.WriteLine(verifyName.Text);
                test.Log(test.Status,"User is in focus");
            }
            else {
                test.Log(test.Status,"User not in focus");
            }

        }



        public void OpenJoinedGroup_SetStewardRole(string groupName,string userName)
        {
            OpenJoinedGroup_ByGroupName(groupName);
            groupMenuLink.Click();
            OpenGroupMenu(memberMenu);
            test.Log(test.Status, "Group Member Page Accessed");
            //userInfo.GetUserName();
            //string uName = userInfo.GetUserName();
            //Console.WriteLine(uName);
            //test.Log(test.Status, uName);
            //OpenJoinedGroup_ByGroupName(groupName);
            //groupMenuLink.Click();
            //OpenGroupMenu(memberMenu);
            Thread.Sleep(2000);
            filterMembers.Click();

            filterMembersSearchField.SendKeys(userName);
            
            filterMembersApplyBtn.ClickButton();
            Thread.Sleep(2000);
            test.Log(test.Status, "Member Filtered");
            MakeMemberSteward(true, false);
            //VerifyStewardIcon(true);
            Assert.AreEqual("Steward", memberGroupRole.Text);
            Console.WriteLine("Verified " + memberGroupRole.Text + " Role on Group Members List");
        }


        #endregion Join and Open Group


        #region leavegroup
        public void Leavegroup()
        {
            test.Log(test.Status, "Click on Group member to Leave the Group");
            member.Click();
            Thread.Sleep(1000);
            leaveGroupLink.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            Thread.Sleep(1000);
            joinleaveGroup.Click();
            test.Log(test.Status,"*************** Group Leave **************");

        }
        #endregion leavegroup

        #region Manage Group
        public void OpenGroupMenu(string subGroupMenu)
        {
            test.Log(test.Status, "Open Group Menu");
            Console.WriteLine(groupSubMenus.Count);

            for (int i = 0; i < groupSubMenus.Count; i++)
            {
                if (groupSubMenus[i].Text.Contains(subGroupMenu))
                {
                    groupSubMenus[i].Click();
                    Thread.Sleep(3000);
                    break;
                }
            }
        }

        #endregion Manage Group

        #region Manage Member Role 
        public void MakeMemberSteward(bool isSteward)
        {
            editMemberRoleDD.Click();

            if (isSteward)
            {
                Console.WriteLine("Granting Steward Acess");
                //  bool stewardFlag = stewardCheckBtn.Selected;
                if (StewardCheckBtn.Selected)
                {
                    Console.WriteLine("Already a steward");
                }
                else
                {
                    stewardCheckBtnClick.Click();

                    Console.WriteLine("Steward access granted");
                }
            }
            else
            {
                Console.WriteLine("Revoking steward Access");
                //  bool stewardFlag = stewardCheckBtn.Selected;
                if (StewardCheckBtn.Selected)
                {
                    Thread.Sleep(2000);
                    stewardCheckBtnClick.Click();
                    Console.WriteLine("Steward access Revoked");
                }
                else
                {
                    Console.WriteLine("Not a steward in first place");
                }

            }
            saveBtn.Click();

        }


        public void MakeMemberSteward(bool isSteward, bool isConGrp)
        {
            test.Log(test.Status, "Edit Member Role");
            editMemberRoleDD.Click();
            test.Log(test.Status,"******** Set Steward Role for Group ********");

            if (isSteward)
            {
                test.Log(test.Status,"Granting Steward Acess");             
                if (StewardCheckBtn.Selected)
                {
                    test.Log(test.Status,"Already a steward");
                }
                else
                {
                    StewardCheckLabel.Click();

                    test.Log(test.Status,"Steward access granted");
                }
            }
            else
            {
                test.Log(test.Status,"Revoking steward Access");               
                if (StewardCheckBtn.Selected)
                {
                    Thread.Sleep(2000);
                    StewardCheckLabel.Click();
                    test.Log(test.Status,"Steward access Revoked");
                }
                else
                {
                    test.Log(test.Status,"Not a steward in first place");
                }

            }
            saveBtn.Click();

            test.Log(test.Status, "Steward Option saved");

        }

        #endregion Manage Member Role 

        public void VerifyStewardIcon(bool iconPresent)
        {
            test.Log(test.Status,"******* Verify Steward Icon ******");
            if (iconPresent)
            {
                Assert.IsTrue(stewardIcon.Displayed);
                test.Log(test.Status,"Steward Icon is displayed");
            }
            else
            {
                test.Log(test.Status,"Steward Icon is not displayed");
            }
        }



        public void StewardProfileClick()
        {
            stewardListIcon.Click();
            int stewardCounts = stewardList.Count;
            test.Log(test.Status,"No of stewards are :" + stewardCounts); // Number of stewards

            string stewardNameText = stewardName.Text; // Name of the steward in String

            for (int i = 0; i < stewardList.Count; i++)
            {
                if (stewardList[i].Text.Contains(stewardNameText))
                {
                    test.Log(test.Status,"Found the member : " + stewardList[i].Text);
                    IWebElement profile = stewardList[i];
                    profile.Click();
                    test.Log(test.Status, "Profile has been clicked");// Clicking on the steward profile
                    break;
                }
            }
        }

        public void postConversationtoGroup()
        {
            plusIcon.Click();
            postConversationIcon.Click();
            test.Log(test.Status,"Clicked on Post conversation");
        }

        public void filterGroupInvite()
        {
            test.Log(test.Status,"******** Verify Group Invite Filter  *******");
            MenuIcon.Click();
            Thread.Sleep(500);
            InviteDropdown.Click();
            Thread.Sleep(500);
            inviteSearchBtn.Click();
            Invitee.SendKeys("a");
            ApplyBtn.Click();
            Thread.Sleep(2000);

            inviteSearchBtn.Click();
            Invitee.Clear();
            Invitee.SendKeys("1");
            Thread.Sleep(2000);
            ApplyBtn.Click();
            Thread.Sleep(2000);

            inviteSearchBtn.Click();
            Invitee.Clear();
            Invitee.SendKeys(".");
            ApplyBtn.Click();
            Thread.Sleep(2000);
            test.Log(test.Status, "Apply Filter has been clicked");
        }


        public void SendGroupInvite(String Inviteeemail1, String Inviteeemail2)
        {
            test.Log(test.Status, "Open Grop Menu");
            MenuIcon.Click();
            Thread.Sleep(500);
            InviteDropdown.Click();
            Thread.Sleep(500);
            InviteUserBtn.Click();
            test.Log(test.Status,"Invite Users Form is open.");
            EmailTextArea.SendKeys(Inviteeemail1);
            EmailTextArea.SendKeys(Inviteeemail2);
            EmailTemplate.Click();
            Thread.Sleep(1000);
            EmailTemplateDrpDwnoption2.Click();            
            PageServices.WaitForPageToCompletelyLoaded(driver, 60);
            InviteSubmitBtn.Click();
            string StatusMessage = statusmessage.GetAttribute("innerText");
            if (StatusMessage.Contains("Invitation has been sent"))
            {
                test.Log(test.Status,"Invitation Sent Successfully and Verified");
            }
            else if (StatusMessage.Contains("error has been found"))
            {
                test.Log(test.Status,"Error Message Verified");
            }
            else
            {
                test.Log(test.Status,"Test Case Fail");
            }
                        
            
        }

        #region EditAddTagLastPost
        public void EditAddTagLastPost()
        {
            test.Log(test.Status, "Accessed Home Page");
            GoToHomePgae.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 60);
            EditLastPostBtn.Click();
            EditPostLink.Click();
            Thread.Sleep(3000);
            test.Log(test.Status,"Activity Post is open in Edit Mode.");
            PageServices.ScrollPageUptoBottom(driver);
            string tagcontent = "#AAMFT19";
            Actions a = new Actions(driver);
            driver.SwitchTo().Frame(editPostFrame);
            a.Click(inputMessage).SendKeys(tagcontent).Build().Perform();
            driver.SwitchTo().DefaultContent(); 
            SaveBttn.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 60);
            GotoSearch.Clear();
            GotoSearch.SendKeys(tagcontent);
            Thread.Sleep(2000);
            btnSearch.Submit();
            int resultcount = 0;
            while (ResultsBody.Text.Contains(tagcontent))
            {
                resultcount++;
                if (resultcount == 2)
                {
                    break;
                }
            }
            test.Log(test.Status,"Result Body Contains Result");
           
        }

        #endregion EditAddTagLastPost

        #region WYSIWYGPost
        public void WYSIWYGPost(string uploadProfileImage, string groupName)
        {
            Thread.Sleep(5000);
            test.Log(test.Status, "Access Group");
            //CTLLink.Click();
            OpenJoinedGroup_ByGroupName(groupName);
            plusIcon.Click();
            postConversationIcon.Click();
            Thread.Sleep(2000);
           
            Actions b = new Actions(driver);
            driver.SwitchTo().Frame(ConvsFrame);
            b.Click(inputMessage).SendKeys("Just for Testing WYSIWYG with Image1.").Build().Perform();
            Thread.Sleep(3000);
            driver.SwitchTo().DefaultContent();
            test.Log(test.Status,"Clicked on Post conversation");
            wysiwygImg.Click();
            test.Log(test.Status,"Image Embed option is open");
            Thread.Sleep(3000);
            wysiwygupload.SendKeys(uploadProfileImage);
            test.Log(test.Status,"Image is Selected");
            Thread.Sleep(2000);
            wysiwygText.Click();
            wysiwygText.SendKeys("Just for testing");
            Thread.Sleep(1000);
            SaveEmbImg.Click();
            Thread.Sleep(2000);
            test.Log(test.Status,"Image is embedded");
            Actions a = new Actions(driver);
            driver.SwitchTo().Frame(ConvsFrame);
            a.Click(inputMessage).SendKeys("Testing WYSIWYG Testing 1 Testing 2 Testing 3 ").Build().Perform();
            driver.SwitchTo().DefaultContent();
            Thread.Sleep(2000);
            PageServices.ScrollIntoElement(driver, postBtn);
            Thread.Sleep(1000);
            postBtn.Click();
            test.Log(test.Status,"Embedded Image Message Typed and Posted");

        }

        #endregion WYSIWYGPost     
        #region ASCPayment
        public void ClickOnGroupFromLeftMenu(string LeftMenuGroupName)
        {
            for (int i = 0; 0 < LeftmenuGroups.Count; i++)
            {
                if (LeftmenuGroups[i].GetAttribute("innerText").Contains(LeftMenuGroupName))
                {
                    Console.WriteLine("Left Menu Group Name from Application" + LeftmenuGroups[i]);
                    LeftmenuGroups[i].Click();
                    break;
                }

            }
        }

        public void VerifyASCHeaderIsExist(bool ascHeaderExist)
        {

            if (ascHeaderExist)
            {
                Assert.IsTrue(ASCProofReaderHeader.Displayed);
                Console.WriteLine("ASC Proofreading Service is  available");
            }
            else
            {
                Console.WriteLine("ASC Proofreading Service is not available");
            }
        }



        //public void SelectASCProofDuration(string ascDuration)
        //{
        //    int durationCount = selectProofreaderDuration.Count;

        //    for (int i = 0; i < durationCount; i++)
        //    {
        //        Console.WriteLine(selectProofreaderDuration[i]);
        //        if (selectProofreaderDuration[i].Text.Contains(ascDuration))
        //        {
        //            selectProofreaderDuration[i].Click();
        //            break;
        //        }
        //    }


        //}


        public string SelectASCProofDuration(string ascDuration)
        {
            int durationCount = selectProofreaderDuration.Count;
            string txtVAlue = selectProofreaderDuration[1].Text;
            selectProofreaderDuration[1].Click();
            return txtVAlue;

        }
        public void SelectCreditCard(string creditCard)
        {
            string defaultCreditCardType = selectCardTypeDefaultValue.GetSelectedValueFromDropDown();
            Console.WriteLine("Default Credit Card type: " + defaultCreditCardType);

            int CardTypeCount = selectCardType.Count;

            for (int i = 0; i < CardTypeCount; i++)
            {
                Console.WriteLine(selectCardType[i]);
                if (selectCardType[i].Text.Contains(creditCard))
                {
                    selectCardType[i].Click();
                    break;
                }
            }
        }

        public void ExpirationDate(string month)
        {
            string selectedMonth = selectedDefaultMonth.GetSelectedValueFromDropDown();
            Console.WriteLine("Selected Month " + selectedMonth);

            int expirationMonthCount = selectExpirationDate.Count;

            for (int i = 0; i < expirationMonthCount; i++)
            {
                Console.WriteLine(selectExpirationDate[i]);
                if (selectExpirationDate[i].Text.Contains(month))
                {
                    selectExpirationDate[i].Click();
                    break;
                }
            }
        }

        public void ExpirationYear(string year)
        {
            string selectedYear = selectedDefaultYear.GetSelectedValueFromDropDown();
            Console.WriteLine("Selected Year " + selectedYear);

            int expirationYearCount = selectExpirationYear.Count;

            for (int i = 0; i < expirationYearCount; i++)
            {
                Console.WriteLine(selectExpirationYear[i]);
                if (selectExpirationYear[i].Text.Contains(year))
                {
                    selectExpirationYear[i].Click();
                    break;
                }
            }
        }

        public void ValidationCardNumber()
        {
            payButton.Click();
            string creditCardValidation = "Credit Card Number is required";
            string creditCardValidationText = getCreditCardNumberValidation.Text;
            Console.WriteLine("Credit card  " + creditCardValidationText);
            Assert.AreEqual(creditCardValidation, creditCardValidationText);
        }

        public void ValidationOnECard()
        {
            PageServices.ScrollIntoElement(driver, echeckRadioButton);
            //checkRadioButton.Click();
            PageServices.ClickButtonByJavaScript(driver, echeckRadioButton);
            Thread.Sleep(2000);
            payButton.Click();
            string bankNumberValidationText = "Bank Account Number is required";
            string ABARoutingValidationText = "Routing Number is required";

            string bankAccountNumberValidationText = getAccountNumberValidationText.Text;
            Console.WriteLine("Bank Number Validation text : " + bankAccountNumberValidationText);
            Assert.AreEqual(bankNumberValidationText, bankAccountNumberValidationText);

            string ABARoutingNumberValidationText = getABARoutinNumberValidationText.Text;
            Console.WriteLine("ABA Routing Number Validation text :  " + getABARoutinNumberValidationText);
            Assert.AreEqual(ABARoutingNumberValidationText, ABARoutingValidationText);

        }
        public void VerifyASCPaymentFields()
        {
            string creditCardType = "Discover";
            string creditcardNumber = "4567834567823455";
            string expirationMonth = "October";
            string expirationYear = "2027";

            string ascDuration = selectProofreaderDuration[1].Text;
            selectProofreaderDuration[1].Click();
            Thread.Sleep(5000);

            driver.SwitchTo().Frame("asc_proofreader_iframe");

            ValidationCardNumber();

            SelectCreditCard(creditCardType);

            inputCreditCardNumber.SendKeys(creditcardNumber);
            ExpirationDate(expirationMonth);
            ExpirationYear(expirationYear);

            string[] amount = ascDuration.Split('$');
            Console.WriteLine("Amount: " + amount[1].ToString());
            string paymentAmount = getAmount.Text;
            Assert.AreEqual(amount[1].ToString(), paymentAmount);

            string learnerId = getLearnerId.GetAttribute("value");
            Console.WriteLine("LearnerID: " + learnerId);

            string receipt = getReceipt.Text;
            Console.WriteLine("Receipt: " + receipt);
            Thread.Sleep(2000);
            ValidationOnECard();

        }

        public void VerifyASCProofreaderLink()
        {
            //NineIcon.Click();
            Thread.Sleep(1000);
            int count = ASCProofreaderText.Count;
            for (int i = 0; i < ASCProofreaderText.Count; i++)
            {
                if (ASCProofreaderText[i].Text.Contains("ASC Proofreader"))
                {
                    Console.WriteLine("ASC Proofreader Link is available");
                    ASCProofreaderText[i].Click();
                    Thread.Sleep(2000);
                    string str = ASCProofreaderheaderText.Text;
                    Console.WriteLine("User navigate to ASC Page: " + str);
                    break;
                }
            }

        }

        public void EditCostAndDuration()
        {
            string costBeforeEdit, durationBeforeEdit;
            string costAfterEdit, durationAfterEdit;

            int rowsCount = GetASCCostAndDurationRows.Count;
            costBeforeEdit = getCostValue.Text;
            Console.WriteLine("Cost Before Edit : " + costBeforeEdit);
            durationBeforeEdit = getdurationValue.Text;
            Console.WriteLine("Duration Before Edit : " + durationBeforeEdit);

            int dropdownCount = EditASCRow.Count;
            for (int i = 0; i < EditASCRow.Count; i++)
            {
                if (EditASCRow[i].Text.Contains("Edit"))
                {
                    EditASCRow[i].Click();
                    break;
                }
            }
            Thread.Sleep(2000);
            EditASCCost.Clear();
            EditASCCost.SendKeys("15.00");


            EditASCDuration.Clear();
            EditASCDuration.SendKeys("15.00");

            //EditASCUnit.Click();
            Thread.Sleep(2000);
            SaveButtonEditASCRow.Click();
            Thread.Sleep(2000);


            for (int i = 0; i < rowsCount; i++)
            {
                if (GetASCCostAndDurationRows[i].Text.Contains("4.00"))
                {
                    costAfterEdit = GetASCCostAndDurationRows[i].FindElement(By.XPath("td[1]")).Text;
                    Console.WriteLine("Cost after Edit : " + costAfterEdit);
                    durationAfterEdit = GetASCCostAndDurationRows[i].FindElement(By.XPath("td[2]")).Text;
                    Console.WriteLine("Duration Before Edit : " + durationAfterEdit);
                    break;
                }
            }


        }

        public void CancelCostAndDurationFromEdit()
        {
            int rowsCountBeforeDeletingRow = GetASCCostAndDurationRows.Count;
            Console.WriteLine("Row count before cancelling the row :" + rowsCountBeforeDeletingRow);

            for (int i = 0; i < EditASCRow.Count; i++)
            {
                if (EditASCRow[i].Text.Contains("Edit"))
                {
                    EditASCRow[i].Click();
                    Thread.Sleep(2000);

                    break;
                }
            }
            CancelButtonFromEditPage.Click();
            int rowsCountAfterCancelRow = GetASCCostAndDurationRows.Count;
            Console.WriteLine("Row count afer cancelling the row :" + rowsCountAfterCancelRow);
        }
        public void DeleteCostAndDurationFromEdit()
        {
            int rowsCountBeforeDeletingRow = GetASCCostAndDurationRows.Count;
            Console.WriteLine("Row count before cancelling the row :" + rowsCountBeforeDeletingRow);

            for (int i = 0; i < EditASCRow.Count; i++)
            {
                if (EditASCRow[i].Text.Contains("Edit"))
                {
                    EditASCRow[i].Click();
                    Thread.Sleep(2000);

                    break;
                }
            }
            DeleteButtonFromEditPage.Click();
            Thread.Sleep(2000);
            DeleteButtonFromDeletePage.Click();
            int rowsCountAfterCancelRow = GetASCCostAndDurationRows.Count;
            Console.WriteLine("Row count afer cancelling the row :" + rowsCountAfterCancelRow);
        }

        public void CancelCostAndDurationFromDelete()
        {
            int rowsCountBeforeDeletingRow = GetASCCostAndDurationRows.Count;
            Console.WriteLine("Row count before cancelling the row :" + rowsCountBeforeDeletingRow);
            EditASCtoggle.Click();
            for (int i = 0; i < EditASCRow.Count; i++)
            {
                if (EditASCRow[i].Text.Contains("Delete"))
                {
                    EditASCRow[i].Click();
                    Thread.Sleep(2000);

                    break;
                }
            }
            CancelButtonFromDeletePage.Click();
            int rowsCountAfterCancelRow = GetASCCostAndDurationRows.Count;
            Console.WriteLine("Row count afer cancelling the row :" + rowsCountAfterCancelRow);
        }

        public void DeleteCostAndDurationFromDelete()
        {
            int rowsCountBeforeDeletingRow = GetASCCostAndDurationRows.Count;
            Console.WriteLine("Row count before deleting the row :" + rowsCountBeforeDeletingRow);

            EditASCtoggle.Click();
            for (int i = 0; i < EditASCRow.Count; i++)
            {
                if (EditASCRow[i].Text.Contains("Delete"))
                {
                    EditASCRow[i].Click();
                    Thread.Sleep(2000);

                    break;
                }
            }
            DeleteButtonFromDeletePage.Click();
            Thread.Sleep(2000);
            int rowsCountAfterCancelRow = GetASCCostAndDurationRows.Count;
            Console.WriteLine("Row count afer deleting the row :" + rowsCountAfterCancelRow);
        }


        public void VerifyCommentsAreableToEnter()
        {
            string ascDuration = "2 Hour - $12.00";
            string creditCardType = "Visa";
            string creditcardNumber = "4111111111111111";
            string expirationMonth = "October";
            string expirationYear = "2027";

            SelectASCProofDuration(ascDuration);

            driver.SwitchTo().Frame("asc_proofreader_iframe");
            driver.WaitUntilElementClickable(inputCreditCardNumber, 120);
            Actions actions = new Actions(driver);
            actions.MoveToElement(inputCreditCardNumber);
            Thread.Sleep(10000);
            ValidationCardNumber();

            SelectCreditCard(creditCardType);

            inputCreditCardNumber.SendKeys(creditcardNumber);
            ExpirationDate(expirationMonth);
            ExpirationYear(expirationYear);

            txtFirstName.SendKeys("Ashia");
            txtLastName.SendKeys("McReynolds");
            txtComments.SendKeys("Payement fro ASC reader Comments");

            payButton.Click();
            Thread.Sleep(5000);

        }
        public void VerifyLearnerNameAndId()
        {
            string learnerId = getLearnerId.GetAttribute("value");
            Console.WriteLine("LearnerID: " + learnerId);

            string learnerName = LearnerName.GetAttribute("value");
            Console.WriteLine("LearnerName: " + LearnerName);
        }

        public void VerifyASCPaymentFieldsPaymentPage()
        {
            
            string creditCardType = "Visa";
            string creditcardNumber = "4111111111111111";
            string expirationMonth = "October";
            string expirationYear = "2027";
            proofReadingServiceTab.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            string ascDuration = GetProofreaderDurationValue.GetAttribute("innerText");
            Console.WriteLine(ascDuration);
            SelectASCCostDurationValue.Click();

            SelectASCProofDuration(ascDuration);
            driver.SwitchTo().Frame("asc_proofreader_iframe");
            driver.WaitUntilElementClickable(inputCreditCardNumber, 120);
            Actions actions = new Actions(driver);
            actions.MoveToElement(inputCreditCardNumber);
            Thread.Sleep(10000);
            ValidationCardNumber();

            SelectCreditCard(creditCardType);

            inputCreditCardNumber.SendKeys(creditcardNumber);
            ExpirationDate(expirationMonth);
            ExpirationYear(expirationYear);

            VerifyLearnerNameAndId();

            string[] amount = ascDuration.Split('$');
            Console.WriteLine("Amount: " + amount[1].ToString());
            string paymentAmount = getAmount.Text;
            //Assert.AreEqual(amount[1].ToString(), paymentAmount);

            string learnerId = getLearnerId.GetAttribute("value");
            Console.WriteLine("LearnerID: " + learnerId);

            string receipt = getReceipt.Text;
            Console.WriteLine("Receipt: " + receipt);
            Thread.Sleep(2000);

            payButton.Click();
            Thread.Sleep(5000);

            driver.Navigate().Refresh();
        }
        #endregion

        #region My groups Menu and SubMenu 
        public void OpenMyGroupMenu(string subMyGroupMenu)
        {
            test.Log(test.Status, "Open My Groups Menu");
            Console.WriteLine(myGroupsSubMenus.Count);

            for (int i = 0; i < myGroupsSubMenus.Count; i++)
            {
                if (myGroupsSubMenus[i].Text.Contains(subMyGroupMenu))
                {
                    myGroupsSubMenus[i].Click();
                    Thread.Sleep(3000);
                    break;
                }
            }
        }

        #endregion

    }
}