using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Keys = OpenQA.Selenium.Keys;

namespace Commons_Automation
{
    public class GroupsActivity:MainSetup
    {
        //IWebDriver driver;
        CommonsGroups commonsGroups;
        IJavaScriptExecutor js;
      //  SearchPage searchPage;
      //  DiscoverGroup discoverGroup;
      //  UserInfo userInfo;
      //  NotificationSettings notificationSettings;
       // string M4PUloadFile = PageServices.GetProjectPath() + TestContext.Parameters.Get("UploadM4PPath").Trim();
        public GroupsActivity()
        {
            //  driver = driver;
            js = (IJavaScriptExecutor)driver;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(90)));
            personalCommons = new PersonalCommons();
            commonsGroups = new CommonsGroups();
            searchPage = new SearchPage();
            discoverGroup = new DiscoverGroup();
            userInfo = new UserInfo();
            notificationSettings = new NotificationSettings();
        }
        //  PersonalCommons personalCommons;

        #region ArchiveAlumniElements
        [FindsBy(How = How.CssSelector, Using = "#views-exposed-form-comments-index-view-default .js-form-item-field-archived .dropdown-content li")]
        public IList<IWebElement> FilterStatusOptionsOnCommentsTab { get; set; }
        [FindsBy(How = How.CssSelector, Using = "#views-exposed-form-comments-index-view-default .chip")]
        public IWebElement ArchiveTextAfterFilter { get; set; }
        [FindsBy(How = How.CssSelector, Using = "#edit-field-archived-wrapper > div >input[data-drupal-selector='edit-field-archived-value']+label")]
        public IWebElement chkArchive { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#profile__stream > div > div > div> article > div > div.post__actions > span:nth-child(2)")]
        public IWebElement DiabledCommentsButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#profile__stream > div > div > div> article > div > div.post__actions > span:nth-child(3)")]
        public IWebElement DiabledFollowingButton { get; set; }
        [FindsBy(How = How.CssSelector, Using = "#views-exposed-form-comments-index-view-default > ul > li > div.collapsible-header > a > span")]
        public IWebElement linkFilter { get; set; }
        [FindsBy(How = How.CssSelector, Using = "#views-exposed-form-comments-index-view-default .js-form-item-field-archived [readonly]")]
        public IWebElement DropdownArchived { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[text()='Archived: Unarchived']/parent::div")]
        public IWebElement archivedUnarchived { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#profile__stream > div > div > div:nth-child(1) > article > div > div.post__actions > span")]
        public IWebElement btnFollowingUnArchive { get; set; }

        //[FindsBy(How = How.CssSelector, Using = "div:nth-child(2) > article > div > div.post__content.clearfix > p > a>span")]
        [FindsBy(How = How.XPath, Using = "(//div[@class='post__content clearfix'])[1]/p/a")]
        public IWebElement linkPostTitielOfArchivedContent { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".archived.banner")]
        public IWebElement Archivedbanner { get; set; }

        //[FindsBy(How = How.CssSelector, Using = "#content > div > article > div > div.post__actions > span:nth-child(2)")]
        [FindsBy(How = How.XPath, Using = "(//div/span[@data-tooltip='Comments are disabled, this post is archived.'])[1]")]
        public IWebElement btnCommentsDisableOnContentPage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div:nth-of-type(n) > article[role='article'] a[title='Add a comment']")]
        public IWebElement btnAddCommentsOnContentPage { get; set; }
       // [FindsBy(How = How.CssSelector, Using = "#content > div > article > div > div.post__actions > span:nth-child(3)")]
        [FindsBy(How = How.XPath, Using = "(//div/span[@data-tooltip='Following is disabled, this post is archived.'])[1]")]
        public IWebElement btnFollowDisableOnContentPage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[href='#profile__comment_stream']")]
        public IWebElement tabCommnets { get; set; }
        [FindsBy(How = How.CssSelector, Using = "(//div[@class='chip'])[2]")]

        public IWebElement btnCommnetsOnPost { get; set; }
        //[FindsBy(How = How.CssSelector, Using = "#profile__stream > div > div > div:nth-child(1) > article > div > div.post__actions > div.action-wrapper > a")]
        [FindsBy(How = How.XPath, Using = "//div[@class='post__actions']/span[@title='You automatically follow your own post.']")]

        public IWebElement btnFollowingOnPost { get; set; }
        [FindsBy(How = How.CssSelector, Using = "(div:nth-of-type(1) > article[role='article'] span")]
        public IWebElement txtUnarchivedCommnets { get; set; }

        [FindsBy(How = How.CssSelector, Using = "(.collection .comment__actions--reply)")]
        public IWebElement btnReplyOnComments { get; set; }
        [FindsBy(How = How.CssSelector, Using = "ul > li > div.post__actions > div.action-wrapper >a")]
        public IWebElement btnReplyOnCommentsForAlumini { get; set; }
        [FindsBy(How = How.XPath, Using = "(//div/input[@value='Apply'])[2]")]
        public IWebElement btnApplyFilterOnCommentsTab { get; set; }
        #endregion ArchiveAlumniElements

        #region ArchiveAlumni
        #region Static Text To Verify
        string DisabledCommentText = "Comments are disabled, this post is archived.";
        string DisabledFollowingText = "Following is disabled, this post is archived.";
        string ArchiveTextAfterFilterText = "Archived: Archived only";
        string FollowingButton = "You automatically follow your own post.";
        string BannerText = "This is an archived post, older than two years and the information included in this post may no longer be valid. Comments are disabled.";
        #endregion Static Text To Verify
        public void SelectArchiveFromFilter(string PostStatus)
        {

            PageServices.ScrollPageUptoTop(driver);

            FilterContentOnProfile.Click();
            Thread.Sleep(2000);           
            FilterByStatusOnProfilePage(PostStatus);


            PageServices.ClickButtonByJavaScript(driver, ApplyFilter);
           // PageServices.ClickButtonByJavaScript(driver, ApplyFilter);
        }

        public void PosttabButtonsVerification()
        {
            string txtDisabledCommentsToolTip = DiabledCommentsButton.GetAttribute("data-tooltip");
            Console.WriteLine(txtDisabledCommentsToolTip);
            Assert.AreEqual(DisabledCommentText, txtDisabledCommentsToolTip);
            string txtFollowingCommentsToolTip = DiabledFollowingButton.GetAttribute("data-tooltip");
            Assert.AreEqual(DisabledFollowingText, txtFollowingCommentsToolTip);
        }
        public void VerifyBanner()
        {
            linkPostTitielOfArchivedContent.Click();
            Thread.Sleep(2000);
           
            Boolean commentsbtnDisble = btnCommentsDisableOnContentPage.Displayed;

            Boolean FollowbtnDisble = btnFollowDisableOnContentPage.Displayed;

           
            string BannerTxtfrompage = Archivedbanner.GetAttribute("innerText");
            Console.WriteLine(BannerTxtfrompage);
            Assert.AreEqual(BannerTxtfrompage, BannerText);

        }
        public void Commentstab()
        {
            tabCommnets.Click();
            Boolean Rplybtn = btnReplyOnCommentsForAlumini.Displayed;
            Assert.True(Rplybtn);
            Thread.Sleep(1000);
            SearchArchivedContentOnCommentsTab("Archived only");
            Thread.Sleep(5000);
            string ArchivetextInCommonsTab = ArchiveTextAfterFilter.GetAttribute("innerText");
            Console.WriteLine(ArchivetextInCommonsTab);
            Assert.AreEqual(ArchiveTextAfterFilterText, ArchivetextInCommonsTab);

        }
        public void SearchArchivedContentOnCommentsTab(string ExpectedValue)
        {
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);

            linkFilter.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            Thread.Sleep(3000);
            //PageServices.ClickButtonByJavaScript(driver, archivedUnarchived);
            //archivedUnarchived.Click();
            DropdownArchived.Click();
            driver.SwitchTo().ActiveElement();

            Actions ac = new Actions(driver);
            Thread.Sleep(2000);


            for (int i = 0; i < FilterStatusOptionsOnCommentsTab.Count; i++)
            {
                string txt = FilterStatusOptionsOnCommentsTab[i].GetAttribute("innerText");

                if (txt.Contains("Archived only"))
                {
                    ac.MoveToElement(FilterStatusOptionsOnCommentsTab[i]);
                    ac.Click(FilterStatusOptionsOnCommentsTab[i]).Perform();
                    Thread.Sleep(1000);
                    btnApplyFilterOnCommentsTab.Click();
                    break;

                }

            }

        }
        public void ArchiveCheckfieldVerifying()
        {
            Boolean Chkbtn = chkArchive.Displayed;
            Assert.True(Chkbtn);
        }
        public void ArchiveUnarchiveVerifying()
        {

            Boolean AddCommentsBtnIsDislayed = btnAddCommentsOnContentPage.Displayed;
            Assert.True(AddCommentsBtnIsDislayed);
             string txtFollowingCommentsToolTip = btnFollowingUnArchive.GetAttribute("title");
            Assert.AreEqual(FollowingButton, txtFollowingCommentsToolTip);

        }
        public void VerifyCommentsAndFollowingButtons()
        {

            Boolean FollowingBtton = btnFollowingOnPost.Displayed;
            Assert.True(FollowingBtton);
        }

        public void rplbuttonOnCommentsTab()
        {
            Boolean rplbutton = btnReplyOnCommentsForAlumini.Displayed;
            Assert.True(rplbutton);
        }
        #endregion ArchiveAlumni

        #region Group Activity Texts
        public string eventDate = "08/08/2024";
        public string eventTime = "01:00PM";
        public string videoURL = "https://youtu.be/K-Yy5wT_KKU";
        public string kalturaVideoURL1 = "https://cdnapisec.kaltura.com/p/2318331/sp/231833100/embedIframeJs/uiconf_id/40358881/partner_id/2318331?iframeembed=true&playerId=kaltura_player&entry_id=1_6o1sxdc4";
        public string kalturaVideoURL2 = "https://cdnapisec.kaltura.com/html5/html5lib/v2.50/mwEmbedFrame.php/p/2318331/uiconf_id/40358881/entry_id/0_j2c214q6?wid=_2318331&iframeembed=true&playerId=kaltura_player&entry_id=0_j2c214q6&";
        public string zoomvideoURL = "https://zoom.us/rec/share/9IWnb03atOB2VV0O2kOaYeDkTiRuEOaiI5qRwnpPY0XdQGNxH5ADaf97ZkBxodxk.77wO81rKTfPwxDJV"; 
        public string postMessage = "has been created";
        public string likeTitle = "I like this";
        public string commentTitle = "Add a comment";
       // public string groupJoined = "QA Conversation Testing";
        public string followMessage = "You automatically follow your own post.";
        public string confirmPost = "Conversation";
        public string startConv = "started a conversation";
        public string addEvt = "added an event";
        public string upldFile = "uploaded a file";
        public string postVideo = "posted a video";
        public string activityStreamMsg = "Activity in My Communities"; //"ACTIVITY IN MY COMMUNITIES";
        public string xpathValueFilterOptions = "//*[@id='views-exposed-form-streams-block-4']/ul/li/div[2]/div/div[1]/div/div/ul/li";
        //"#views-exposed-form-streams-block-4 > ul > li > div.collapsible-body > div > div.js-form-item.form-item.js-form-type-select.form-item-type.js-form-item-type.input-field > div > div >ul>li"
        public string testTag = "#test";
        public string deletePost = "has been deleted";

        #endregion Group Activity Texts

        #region Group Activity Elements
        [FindsBy(How = How.Id, Using = "conversation-tab")]
        public IWebElement addConversation { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='cke_1_contents']/iframe")]
        public IWebElement conversationFrame { get; set; }

        [FindsBy(How = How.XPath, Using = "//html/body/p")]
        public IWebElement description { get; set; }

        //[FindsBy(How = How.XPath, Using = "//*[@id='cke_1_contents']/iframe")]
        //public IWebElement addPostIFrame { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button#edit-submit")]
        public IWebElement post { get; set; }

        [FindsBy(How = How.XPath, Using = "/html//form[@id='node-text-form']//div[@class='layout-region-node-footer__content']/div/button[@id='edit-submit']")]
        public IWebElement post1 { get; set; }

        [FindsBy(How = How.XPath, Using = "/html//form[@id='node-event-form']//div[@class='layout-region-node-footer__content']/div/button[@id='edit-submit--4']")]
        public IWebElement eventPost { get; set; }

        [FindsBy(How = How.Id, Using = "edit-submit--2")]
        public IWebElement uploadPost { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[href*='add_content__event']")]
        public IWebElement addEvent { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[href*='add_content__upload']")]
        public IWebElement upload { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[href*='add_content__video']")]
        public IWebElement video { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#node-event-form [data-drupal-selector='edit-title-0-value']")]
        public IWebElement enterEventTitle { get; set; }

        [FindsBy(How = How.Id, Using = "edit-title-0-value")]
        public IWebElement enterUploadTitle { get; set; }

        [FindsBy(How = How.Id, Using = "edit-field-date-0-value-date")]
        public IWebElement enterdate { get; set; }

        [FindsBy(How = How.Id, Using = "edit-title-0-value--2")]
        public IWebElement enterVideoTitle { get; set; }

        [FindsBy(How = How.Id, Using = "edit-field-date-0-value-time")]
        public IWebElement enterTime { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='cke_4_contents']/iframe")]
        public IWebElement eventFrame { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='cke_2_contents']/iframe")]
        public IWebElement eventFrameEvent { get; set; }        

        [FindsBy(How = How.XPath, Using = "//*[@id='cke_2_contents']/iframe")]
        public IWebElement uploadFrame { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='cke_3_contents']/iframe")]
        public IWebElement uploadFrameUpload { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='cke_3_contents']/iframe")]
        public IWebElement videoFrame { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='cke_4_contents']/iframe")]
        public IWebElement videoFrameVideo { get; set; }

        //[FindsBy(How = How.XPath, Using = "//*[@id='edit-field-notify-wrapper--3']/div/label")]
        //public IWebElement notification { get; set; }

        [FindsBy(How = How.Id, Using = "edit-submit--3")]
        public IWebElement videoPost { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='add-video-modal-form']/div/div/div/form/div/div/div/div/button[@id='edit-submit']")]
        public IWebElement videoPostbtn { get; set; }
        
        [FindsBy(How = How.Id, Using = "edit-field-video-0-value")]
        public IWebElement uploadVideo { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='messages']/div/div/div[2]/div")]
        public IWebElement postMsg { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input#edit-field-file-0-upload[type='file']")]
        //[FindsBy(How = How.Id, Using = "edit-field-file-0-upload")]               
        public IWebElement uploadButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='group-header']/div/div/a")]
        public IWebElement groupHeader { get; set; }

        //[FindsBy(How = How.ClassName, Using = "views-element-container")]
        //public IWebElement activityContainer { get; set; }

        //[FindsBy(How = How.CssSelector, Using = "div.views-element-container> div > div >  div:nth-child(1) > article > div > header > div.post__meta")]
        [FindsBy(How = How.XPath, Using = "//div[@role='contentinfo']/em")]
        public IWebElement verifyPost { get; set; }

        //[FindsBy(How = How.XPath, Using = "(//*[@class='post__meta--author title text-icon-container tooltipped'])[2]")]
        [FindsBy(How = How.XPath, Using = "(//*[@class='collection-item avatar'])[1]//a[@class='post__meta--author title text-icon-container tooltipped']")]
        public IWebElement userNamePost { get; set; }

        //[FindsBy(How = How.XPath, Using = "(//*[@class='post__meta--type'])[2]")]
        [FindsBy(How = How.XPath, Using = "(//*[@class='collection-item avatar'])[1]//a[@class='post__meta--author title text-icon-container tooltipped']/following-sibling::span")]
        public IWebElement startedPost { get; set; }

       //[FindsBy(How = How.XPath, Using = "(//*[@class='post__meta--type'])[3]")]
        [FindsBy(How = How.XPath, Using = "(//*[@class='collection-item avatar'])[1]//a[@class='post__meta--author title text-icon-container tooltipped']/following-sibling::span")]
        public IWebElement addedEvent { get; set; }

        //[FindsBy(How = How.XPath, Using = "//*[@id='navigation']/div/div[@class='nav__item nav__user-personal']/a/span")]
        //[FindsBy(How = How.XPath, Using = "//ul[@id='slide-out']//div[@class='user-view']/a[2]/span")]



        [FindsBy(How = How.XPath, Using = "(//div[@class='collection-item avatar'])[1]/header/div[1]/a")]

        public IWebElement userName { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='drop-down-menu user-me']")]
        public IWebElement userNameConv { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.views-element-container> div > div >  div:nth-child(1) > article > div > div.post__actions > div.like-container > div > a")]
        public IWebElement likePost { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.views-element-container> div > div > div:nth-child(1) > article > div > div.post__actions > div.action-wrapper > a")]
        public IWebElement commentOnPost { get; set; }

        //[FindsBy(How = How.XPath, Using = "//*[@id='block-breadcrumbs']/div[2]/a[1]")]
        //public IWebElement communityHome { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='group-header']/div/div/a")]
        public IWebElement groupName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.views-element-container> div > div >  div:nth-child(1) > article > div > div.post__actions > span")]
        public IWebElement followGroup { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.post__actions > div:nth-child(3) > a[rel='nofollow']")]
        public IWebElement followUnfollowGroup { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.post__actions > div:nth-child(2) > a")]

        public IWebElement commentsOnActivity { get; set; }

        [FindsBy(How =How.CssSelector,Using = "header > div.post__meta > p[class^='post__meta--views sub']")]
        public IList<IWebElement> ViewIconOnPost { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='views-exposed-form-streams-block-4']/ul/li/div[1]/h3")]
        public IWebElement activityStreamHeader { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='exposed-form-chips']/following-sibling::a")]
        public IWebElement filterActivity { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='views-exposed-form-streams-block-4']/ul/li/div[2]/div/div[1]/div/div/ul/li")]

        public IList<IWebElement> filterTypeOptions { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='views-exposed-form-streams-block-4']/ul/li/div[2]/div/div[1]/div/div/input")]
        public IWebElement filterType { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[value='Apply'][type='submit']")]
        public IWebElement applyFilter { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='views-exposed-form-streams-block-4']/ul/li/div[1]/div/div")]
   
        public IWebElement verifyFilterType { get; set; }
        
        [FindsBy(How = How.XPath, Using = "(//button[text()='Open  configuration options'])[1]")]
        public IWebElement editDeleteOption { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='block-views-block-streams-block-4']/div[2]/div/div[2]/div[1]/article/div/header/div[2]/ul/li[1]")]
        public IWebElement editOption { get; set; }

        [FindsBy(How = How.XPath, Using = "(//*[@class='contextual-links'])[1]//a[text()='Delete']")]
        public IWebElement deleteOption { get; set; }
        //[FindsBy(How = How.XPath, Using = "//*[@id="content"]/div/div[3]/div/div/div[1]/article/div/header/div[2]/button")]
        //public IWebElement deleteOption { get; set; }

        [FindsBy(How = How.Id, Using = "edit-field-tags-target-id")]
        public IWebElement addTags { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//*[@id='block-views-block-streams-block-4']/div[2]/div/div/div[1]/article/div/div[1]/span/span/a")]
        public IWebElement verifyTag { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='messages']/div/div/div[2]/div")]
        public IWebElement postDeleteMsg { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='post__meta']/a")]
        IList<IWebElement> userNameOnGroupActivity { get; set; }

        //[FindsBy(How = How.CssSelector, Using = "#block-views-block-profile-block-1 > div:nth-child(2) > div > div.views-row > div.contextual-region.profile.contextual-exposed.no-contextual-outline > div > h2")]
        //public IWebElement userNameOnPvtMsgTab { get; set; }

        //[FindsBy(How = How.CssSelector, Using = "#dropdown--user-groups > div > div > div > ul > li > a > span")]
        //[FindsBy(How = How.CssSelector, Using = "ul#dropdown--user-groups > .views-element-container .list > li")]
        [FindsBy(How = How.XPath, Using = "//*[@id='dropdown--user-groups']/li[1]/div/div/div/ul/li/a/span[@class='name']")]
        public IList<IWebElement> myGroupName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.atwho-container")]
        public  IList<IWebElement> atWhoContainer { get; set; }


        [FindsBy(How = How.CssSelector, Using = "#content > div > div.views-element-container > div > div > div:nth-child(1) > article > div > div.post__content.clearfix > div > div > p > span > span > a")]
        public IWebElement userTagNameOnPost { get; set; }


        [FindsBy(How = How.CssSelector, Using = "article[id^='comment'] > ul > li > div.post__content > div > p > span > span > a")]
        public IWebElement userTagNameOnCommentsReply { get; set; }

       // [FindsBy(How = How.CssSelector, Using = "article[id^='comment'] > ul > li > div.post__actions > div.action-wrapper > a")]
        [FindsBy(How = How.XPath, Using = "//div/a[@class='comment__actions--reply']")]
        public IWebElement btnReply { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#content > div > div.views-element-container > div > div > div:nth-child(1) > article > div > div.post__content.clearfix > div.post__content--body > div > p:nth-child(1) > span > span > a")]
        public IWebElement userTagNameEvent { get; set; }


        [FindsBy(How = How.XPath, Using = "//i[@class='large material-icons']")]
        public IWebElement plusIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@data-tooltip='Conversation']")]
        public IWebElement postConversationIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//em[@class='placeholder']/a")]
        public IWebElement msgLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//i[@data-tooltip='Group Steward']")]
        public IWebElement stewardIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='placard']")]
        public IWebElement Placard { get; set; }

        [FindsBy(How = How.XPath, Using = "//h2[@class='m-0']")]
        public IWebElement groupCommunityIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@data-tooltip='Event']")]
        public IWebElement postEventIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='add-event-modal-form']/div/div/div/form/div/div/div[1]/div/input")]
        public IWebElement eventTitleXpath { get; set; }


        //[FindsBy(How = How.XPath, Using = "//div[@id='add-event-modal-form']/div/div/div/form/div/div/div[1]/div/button[@id='edit-submit--3']")]
        //public IWebElement postBtnEvent { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@data-tooltip='Upload']")]
        public IWebElement postuploadIcon { get; set; }

        //[FindsBy(How = How.XPath, Using = "//div[@id='add-upload-modal-form']/div/div/div/form/div/div/div/div/input[@id='edit-title-0-value--2']")]
        //public IWebElement uploadTitleXpath { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div>div>#edit-field-video-0-value")]
        public IWebElement uploadTitle { get; set; }

        
        [FindsBy(How = How.XPath, Using = "//a[@data-tooltip='Video']")]
        public IWebElement postVideoIcon { get; set; }

        //[FindsBy(How = How.XPath, Using = "//div[@id='add-video-modal-form']/div/div/div/form/div/div/div/div/input[@id='edit-title-0-value']")]
        //public IWebElement videoTitleXpath { get; set; }

        //[FindsBy(How = How.CssSelector, Using = "div>div>#edit-title-0-value--3")]
        //public IWebElement videoTitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div>div>input[id^=edit-title-0-value]")]
        public IList<IWebElement> InputTitlePost { get; set; }


        //[FindsBy(How = How.XPath, Using = "//div[@id='add-video-modal-form']/div/div/div/form/div/div/div/div/input[@id='edit-field-video-0-value']")]
        //public IWebElement uploadVideoXpath { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div>div>#edit-field-video-0-value")]
        public IWebElement uploadVideoXpath { get; set; }

       

        [FindsBy(How = How.XPath, Using = "//*[@class='nav__item']//a[@title='Home']")]
        public IWebElement lnkPersonalCommons { get; set; }

        //[FindsBy(How = How.XPath, Using = "//i[contains(text(),'local_activity')]")]
        //public IWebElement stewardIconList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#steward-trigger-container > a > i")]
        public IWebElement stewardIconList { get; set; }
        

        [FindsBy(How = How.XPath, Using = "//div[@id='stewards-modal']/div/div/div/div/div/span/li/a")]
        public IList<IWebElement> stewardPicNnameLink { get; set; }

        //[FindsBy(How = How.XPath, Using = "//section[@id='content']/div/article/div/div[@class='post__actions']/div[@class='action-wrapper']/a")]
        //public IWebElement commentPost { get; set; }


        [FindsBy(How = How.CssSelector, Using = "div>div>div>button[id^=edit-submit]")]
        public IList<IWebElement> postActivity { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button#edit-submit")]
        public IWebElement btnSaveReply { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#views-exposed-form-posts-index-view-default > ul > li > div.collapsible-header > a > span")]
        public IWebElement FilterContentOnProfile { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#views-exposed-form-posts-index-view-default > ul > li > div.collapsible-body > div  div> div > div > input[value='Unarchived']")]
        public IWebElement ArchiveStatuFilter { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#views-exposed-form-posts-index-view-default > ul > li > div.collapsible-body > div  div> div > div > input[value='Unarchived'] + ul > li")]
        public IList<IWebElement> ArchiveStatuFilterOptn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[id*='edit-submit-posts-index-view']")]
        public IWebElement ApplyFilter { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#views-exposed-form-posts-index-view-default > ul > li > div.collapsible-body > div > div>div>div input[value='- Any -']")]
        public IWebElement TypeFilter { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#views-exposed-form-posts-index-view-default > ul > li > div.collapsible-body > div > div>div>div input[value='- Any -'] + ul > li")]
        public IList<IWebElement> TypeFilterOptn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#profile__stream > div > div > div> article > div > div[class^='post__content'] > p > a")]
        public IList<IWebElement> ActivityList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#profile__stream > div > div > div> article > div > div[class^='post__content']>div>div>p")]
        public IList<IWebElement> ActivityListDescrOnProfile { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#profile__stream > div > div > div> article > div > div[class^='post__content']>p")]
        public IList<IWebElement> ActivityListTitleOnProfile { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#profile__stream > div > div > div> article > div > div.post__actions > span:nth-child(2)")]
        public IList<IWebElement> CommentDisabled { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#profile__stream > div > div > div > article > div > header > div:nth-child(2)")]
        public IList<IWebElement> EditActvtyIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul[@id='tabs-swipe-demo']//a[@href='#add_content__poll']/i[@class='material-icons']")]
        public IWebElement addPollIconConv { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#node-poll-form [data-drupal-selector='edit-title-0-value']")]
        public IWebElement addPollTitleConv { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[name='field_answers[0][value]']")]
        public IWebElement addPollAns0Conv { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[name='field_answers[1][value]']")]
        public IWebElement addPollAns1Conv { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[name='field_answers[2][value]']")]
        public IWebElement addPollAns2Conv { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[name='field_answers[3][value]']")]
        public IWebElement addPollAns3Conv { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[name='field_answers[4][value]']")]
        public IWebElement addPollAns4Conv { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[name='field_answers[5][value]']")]
        public IWebElement addPollAns5Conv { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[name='field_answers[6][value]']")]
        public IWebElement addPollAns6Conv { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[name='field_answers_add_more']")]
        public IWebElement addPollAnsOptionBtnConv { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#node-poll-form .button--primary")]
        public IWebElement postPollBtnConv { get; set; }

        
        [FindsBy(How = How.XPath, Using = "/html//input[@id='edit-field-end-date-0-value-date']")]
        public IWebElement polldftCloseDt { get; set; }


        [FindsBy(How = How.CssSelector, Using = ".fixed-action-btn li:nth-of-type(5) .material-icons")]
        public IWebElement addPollIconComut { get; set; }

        [FindsBy(How = How.XPath, Using = "(//*[@class='post__content--title'])[1]/span")]
        public IWebElement lastPostonLandPg { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[@class='modal-content light-add-content']/div/div/form[@id='node-poll-form']//div[@class='layout-region layout-region-node-main']/div[1]//input[@name='title[0][value]']")]
        public IWebElement addPollTitleComut { get; set; }

        [FindsBy(How = How.XPath, Using = "/html//div[@id='edit-field-option-type-wrapper']//input")]
        public IWebElement pollType { get; set; }

        [FindsBy(How = How.XPath, Using = "/html//div[@id='edit-field-option-type-wrapper']//div/div/div/select[@id='edit-field-option-type']/option")]
        public IList<IWebElement> pollTypeOpts { get; set; }

        [FindsBy(How = How.XPath, Using = "/html//div[@id='edit-field-option-type-wrapper']//select")]
        public IWebElement pollTypeSelect { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[@id='edit-field-is-featured-wrapper']//label[@class='option']")]
        public IWebElement featureselectConv { get; set; }
        [FindsBy(How =How.CssSelector,Using = "div> article[role='article'] > a[target='_blank']  .post__content > .post__content--body p")]
        IList<IWebElement> featurePosts { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#node-event-form [data-drupal-selector='edit-field-is-featured-wrapper'] .option")]
        public IWebElement featureselectEvnt { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#node-file-form [data-drupal-selector='edit-field-is-featured-wrapper'] .option")]
        public IWebElement featureselectUpld { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#node-video-form [data-drupal-selector='edit-field-is-featured-wrapper'] .option")]
        public IWebElement featureselectVideo { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#node-poll-form [data-drupal-selector='edit-field-is-featured-wrapper'] .option")]
        public IWebElement featureselectPoll { get; set; }

        [FindsBy(How = How.XPath, Using = "/html//section[@id='content']//div[@class='feature-post-panel']/div/div/div/div/div[1]/article[@role='article']")]
        public IWebElement lastFeaturedPost { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".contextual > .trigger")]
        public IWebElement contextualLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".contextual-links > li:nth-of-type(2) > a")]
        public IWebElement deleteContextualLink { get; set; }

        [FindsBy(How = How.XPath, Using = "/html//section[@id='content']/div/div[@class='views-element-container']/div/div/div[1]/article[@role='article']//div[@class='contextual']/button[@type='button']")]
        public IWebElement contextualLink2 { get; set; }

        [FindsBy(How = How.XPath, Using = "/html//section[@id='content']/div/div[@class='views-element-container']/div/div/div[1]/article[@role='article']//header/div[2]/ul[@class='contextual-links']/li[2]/a")]
        public IWebElement deleteContextualLink2 { get; set; }
        
        [FindsBy(How = How.CssSelector, Using = "button#edit-submit")]
        public IWebElement confirmDelete { get; set; }        




        [FindsBy(How = How.CssSelector, Using = "#profile__stream > div > div > div> article > div > div.post__actions > span:nth-child(3)")]
        public IList<IWebElement> FollowingDisabled { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[href *= 'add_content__poll']")]
        public IWebElement poll { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#edit-title-0-value--4")]
        public IWebElement enterpollTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "/html//div[@id='edit-field-option-type-wrapper']//input[@value='Single choice']")]
        public IWebElement PollfilterCarettype { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".select-wrapper.required li:nth-of-type(1) span")]
        public IWebElement pollfiltersingle { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".select-wrapper.required li:nth-of-type(2) span")]
        public IWebElement pollfiltermultiple { get; set; }


        [FindsBy(How = How.XPath, Using = "//select[@id='edit-field-option-type']/option")]
        public IList<IWebElement> pollfilteroption { get; set; }


        [FindsBy(How = How.CssSelector, Using = "input[name='field_answers[0][value]']")]
        public IWebElement pollAnswer1 { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[name = 'field_answers[1][value]']")]
        public IWebElement pollAnswer2 { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[name='field_answers_add_more']")]
        public IWebElement addAnotherItems { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[name = 'field_answers[2][value]']")]
        public IWebElement pollAnswer3 { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[name = 'field_answers[3][value]']")]
        public IWebElement pollAnswer4 { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[name = 'field_answers[4][value]']")]
        public IWebElement pollAnswer5 { get; set; }


        [FindsBy(How = How.XPath, Using = "/html//form[@id='node-poll-form']//div[@class='layout-region-node-footer__content']/div/button[1]")]
        public IWebElement pollpost { get; set; }


        [FindsBy(How = How.XPath, Using = "//a[@pathname='/node/119416']/span[@innertext='TAKE POLL']")]
        public IWebElement Takepolltxt { get; set; }




        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div/div[4]/div/div/div[1]/article/div/div/div[2]/a")]
        public IWebElement TakepollBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "div:nth-child(2) > div:nth-of-type(1) .btn-flat--blue")]
        public IWebElement TakepollBtn2 { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[@id='edit-answer']/div[1]/label[@class='option']")]
        public IWebElement Takepollcheckbox { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='edit-answer']/div[2]/label[@class='option']")]
        public IWebElement TakepollMultiplecheckbox { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='edit-answer']/div[4]/label[@class='option']")]
        public IWebElement TakepollMultiplecheckbox4 { get; set; }


        [FindsBy(How = How.XPath, Using = "/html//button[@id='edit-submit']")]
        public IWebElement TakepollSubmit { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@pathname='/node/119423']/span[@innertext='TAKE POLL']")]
        public IWebElement AlreadyTakenpoll { get; set; }


        [FindsBy(How = How.CssSelector, Using = ".highcharts-title")]
        public IWebElement Pollcompleted { get; set; }


        [FindsBy(How = How.CssSelector, Using = ".status-messages__item")]
        public IWebElement Pollanswersavetxtd { get; set; }



        By buttonCSS = By.CssSelector("button");
        By EditXPath = By.XPath("*//a[contains(text(),'Edit')]");


        // IWebElement eventPostButton = WebDriverExtensions.FindElement(driver, By.CssSelector("div>div>div>#edit-submit--2"), 90);

        #region String Element Selector

        public By userListCSS = By.CssSelector("ul > li:nth-child(2)");

        #endregion String Element Selector

        #endregion Group Activity Elements


        #region AddContentInGroup
        public void PostConeversation_ConversationGroup(string DescriptionText)
        {
            /* Post a conversation */
            Console.WriteLine("********* Post Conversation to Group *********");
            test.Log(Status.Info,"********* Post Conversation to Group *********");
            addConversation.Click();
            driver.SwitchTo().Frame(conversationFrame);
            AddDescription(DescriptionText);
            /*This sleep is required as the button needs to be loaded*/
            Thread.Sleep(3000);
            post.Click();
            Thread.Sleep(3000);
            Assert.That(postMsg.Text, Does.Contain(postMessage).IgnoreCase);
            confirmPost = userNameConv.Text + startConv;
            VerifyActivityInGroup(confirmPost);
            Console.WriteLine("********* Posted Conversation Exist on Group *********");
            test.Log(Status.Pass,"*********Verify Posted Conversation Exist on Group *********");

        }

        public void PostEvent_ConversationGroup(string DescriptionText,string TitleText)
        {
            Console.WriteLine("*********  Add Event to Group *********");
            test.Log(Status.Info,"*********  Add Event to Group *********");
            /* Post an Event */
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            Thread.Sleep(2000);
            PageServices.ClickButtonByJavaScript(driver, addEvent);
            //addEvent.Click();
            enterEventTitle.SendKeys(TitleText);
            driver.SwitchTo().Frame(eventFrame);
            AddDescription(DescriptionText);
            driver.SwitchTo().DefaultContent(); 
            enterdate.SendKeys(eventDate);
            enterTime.SendKeys(eventTime);
            Thread.Sleep(2000);
            eventPost.Click();

            PageServices.WaitForPageToCompletelyLoaded(driver, 120);

            Assert.That(postMsg.Text, Does.Contain(postMessage).IgnoreCase);            
            confirmPost = userNameConv.Text + addEvt;
            Console.WriteLine(confirmPost);
            VerifyActivityInGroup(confirmPost);
            Console.WriteLine("********* Event Added to Group *********");
            test.Log(Status.Pass,"********* Event Added to Group *********");

        }

        public void PostFile_ConversationGroup(string DescriptionText, string TitleText,string FileName)
        {
            Console.WriteLine("********* Upload file to Group *********");
            test.Log(Status.Info,"********* Upload file to Group *********");

            /* Upload content */
            upload.Click();
            Thread.Sleep(4000);
            uploadButton.SendKeys(FileName);
            Thread.Sleep(9000);
            enterUploadTitle.SendKeys(TitleText);
            Thread.Sleep(4000);
            driver.SwitchTo().Frame(uploadFrame);
            AddDescription(DescriptionText);
            Thread.Sleep(4000);
            uploadPost.Click();
            Thread.Sleep(5000);
            Assert.That(postMsg.Text, Does.Contain(postMessage).IgnoreCase);
            confirmPost = userName.Text + upldFile;            
            Console.WriteLine("*********  File Uploaded to Group *********");
            test.Log(Status.Pass,"*********  File Uploaded to Group *********");

        }

        public void PostVideo_ConversationGroup(string DescriptionText, string TitleText, string VideoURL)
        {
            Console.WriteLine("*********  Add Video to Group *********");
            test.Log(Status.Info,"*********  Add Video to Group *********");

            /* Post a Video */
            video.Click();
            enterVideoTitle.SendKeys(TitleText);
            Thread.Sleep(4000);
            uploadVideo.SendKeys(VideoURL);
            Thread.Sleep(2000);
            driver.SwitchTo().Frame(videoFrame);
            AddDescription(DescriptionText);
            videoPost.Click();
            Thread.Sleep(4000);
            // Thread.Sleep(3000);
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            Assert.That(postMsg.Text, Does.Contain(postMessage).IgnoreCase);
            confirmPost = userName.Text + postVideo;
            VerifyActivityInGroup(confirmPost);
            test.Log(Status.Pass,"********* Video added to Group *********");

        }

        public void AddContentInGroup(string DescriptionText, string TitleText,string FileName)
        {
            PostConeversation_ConversationGroup(DescriptionText);
            Console.WriteLine("****** Conversation Posted *********************");
           

            /* Post an Event */
            PostEvent_ConversationGroup(DescriptionText, TitleText);

            Console.WriteLine("****** Event Posted *********************");

            /* Upload content */
            PostFile_ConversationGroup(DescriptionText, TitleText, FileName);

            Console.WriteLine("****** PDF File Posted *********************");

            /* Upload M4P Video File */

            PostFile_ConversationGroup(DescriptionText, TitleText,M4PUloadFile);

            Console.WriteLine("****** M4P File Posted *********************");
            /* Post a Video */
            PostVideo_ConversationGroup(DescriptionText, TitleText, videoURL);

            Console.WriteLine("****** Video File Posted *********************");
            Thread.Sleep(2000);
            PostActions(DescriptionText);
            groupName.Click();
            Thread.Sleep(2000);
            test.Log(Status.Info, "Group accessed ");
           

        }


        #endregion AddContentInGroup

        #region AddDescription
        public void AddDescription(string DescriptionText)
        {
            test.Log(Status.Info, "Add Description");
            //description.Click();
            //Actions a = new Actions(driver);
            //a.Click(description).SendKeys(DescriptionText).Build().Perform();
            description.SendKeys(DescriptionText);
            driver.SwitchTo().DefaultContent();
            test.Log(Status.Info, "Added Description");

        }

        public void AddDescriptionTest(string DescriptionText)
        {
            description.Click();
            Actions a = new Actions(driver);
            a.Click(description).SendKeys(DescriptionText).Build().Perform();
            a.Click(description).SendKeys("\n").Build().Perform();
            a.Click(description).SendKeys(DescriptionText).Build().Perform();
            driver.SwitchTo().DefaultContent();

        }
        #endregion AddDescription

        #region VerifyActivityInGroup
        public void VerifyActivityInGroup(string confirmPost)
        {
            string verify = "";
            if (confirmPost.Contains("conversation"))
            {
                 verify = userNamePost.Text.Replace("\n", "").Replace("\r", "") + startedPost.Text.Replace("\n", "").Replace("\r", "");
            }
            else {
                 verify = userNamePost.Text.Replace("\n", "").Replace("\r", "") + addedEvent.Text.Replace("\n", "").Replace("\r", "");

            }
            Console.WriteLine(verify);
            Assert.IsTrue(verify.Contains(confirmPost));
            test.Log(Status.Pass, "Activity has been verified in Post");
        }

        public void VerifyStewardIconInPost()
        {
            Console.WriteLine("************* Verify Steward Icon in Post **********");
            test.Log(Status.Info,"************* Verify Steward Icon in Post **********");
            msgLink.Click();
            Assert.That(stewardIcon.Text, Does.Contain("star").IgnoreCase);
            groupCommunityIcon.Click();
            test.Log(Status.Info, "************* Steward Icon verified in Post **********");
        }

        public void VerifyStewardOnSearch()
        {
            searchPage.SearchContentStewardIcon(TitleText);
        }

        public void VerifyPlacardInfoInPost()
        {
            test.Log(Status.Pass, "Placrad Info verified in post");
            msgLink.Click();
            Assert.IsTrue(Placard.Displayed);
            groupCommunityIcon.Click();
            test.Log(Status.Pass, "Placrad Info verified in post");
        }


        public void VerifyFollowUnfollowGroupActivity()
        {
            
          

            PageServices.WaitForPageToCompletelyLoaded(driver, 100);
            try
            {
                if (followUnfollowGroup.GetAttribute("innerText").Contains("Follow"))
                {
                    js.ExecuteScript("arguments[0].click();", followUnfollowGroup);
                    //followUnfollowGroup.Click();                
                    //Madan : This sleep is required as button text need to get refreshed.
                    Thread.Sleep(2000);
                    Console.WriteLine(followUnfollowGroup.GetAttribute("innerText"));
                    Assert.IsTrue(followUnfollowGroup.GetAttribute("innerText").Contains("Unfollow"));

                    test.Log(Status.Pass, "Unfollow option verified ");
                }
                else if (followUnfollowGroup.GetAttribute("innerText").Contains("Unfollow"))
                {
                    js.ExecuteScript("arguments[0].click();", followUnfollowGroup);
                    //followUnfollowGroup.Click();
                    //Madan : This sleep is required as button text need to get refreshed.
                    Thread.Sleep(2000);
                    Console.WriteLine(followUnfollowGroup.GetAttribute("innerText"));
                    Assert.IsTrue(followUnfollowGroup.GetAttribute("innerText").Contains("Follow"));
                    test.Log(Status.Pass, "Follow option verified ");
                }
                Console.WriteLine("Follow - Unfollow option verified ");
                test.Log(Status.Pass, "Follow - Unfollow option verified ");
            }
            catch
            
            {
                Console.WriteLine(WebDriverExtensions.FindElement(driver, By.CssSelector("div.post__actions > span"), 90).Text);
                Console.WriteLine("******** Self Posted Content Auto followed ********");
                test.Log(Status.Pass,"******** Self Posted Content Auto followed ********");
            }
            test.Log(Status.Pass, "Follow - Unfollow option verified ");
        }

        ////  copied method-VerifyFollowUnfollowGroupActivity
        //public void LandingPage_ActivityFeeds_FollowLink()
        //{
        //    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

        //    PageServices.WaitForPageToCompletelyLoaded(driver, 100);

        //    if (followUnfollowGroup.GetAttribute("innerText").Contains("Follow"))
        //    {
        //        js.ExecuteScript("arguments[0].click();", followUnfollowGroup);
        //        //followUnfollowGroup.Click();                
        //        //Madan : This sleep is required as button text need to get refreshed.
        //        Thread.Sleep(2000);
        //        Console.WriteLine(followUnfollowGroup.GetAttribute("innerText"));
        //        Assert.IsTrue(followUnfollowGroup.GetAttribute("innerText").Contains("Unfollow"));
        //    }
        //    else if (followUnfollowGroup.GetAttribute("innerText").Contains("Unfollow"))
        //    {
        //        js.ExecuteScript("arguments[0].click();", followUnfollowGroup);
        //        //followUnfollowGroup.Click();
        //        //Madan : This sleep is required as button text need to get refreshed.
        //        Thread.Sleep(2000);
        //        Console.WriteLine(followUnfollowGroup.GetAttribute("innerText"));
        //        Assert.IsTrue(followUnfollowGroup.GetAttribute("innerText").Contains("Follow"));
        //    }
           

        //}


        public int VerifyCommentCounts()
        {
           // test.Log(Status.Pass, "Verify Comments Counts");
            string comment = commentsOnActivity.GetAttribute("innerText").ToString();
            string[] lines = comment.Split('\n');
            Console.WriteLine(lines[2]);
            //  Console.WriteLine(lines[2].Trim('(', ')'));
            int cnt = int.Parse(lines[2].Trim('(', ')'));
            Console.WriteLine(cnt);
            Assert.IsTrue(cnt >= 0);
            test.Log(Status.Pass, "Get Comments Counts");
            return cnt;
        }

        //copied verifyCommnetCounts

        //public int LandingPage_ActivityFeeds_CommentCountLink()
        //{
        //    string comment = commentsOnActivity.GetAttribute("innerText").ToString();
        //    string[] lines = comment.Split('\n');
        //    Console.WriteLine(lines[2]);
        //    //  Console.WriteLine(lines[2].Trim('(', ')'));
        //    int cnt = int.Parse(lines[2].Trim('(', ')'));
        //    Console.WriteLine(cnt);
        //    Assert.IsTrue(cnt >= 0);
        //    return cnt;
        //}

        #endregion VerifyActivityInGroup

        #region PostActions
        public void PostActions(string CommentText)            
        {
            
            if (ViewIconOnPost[0].Text.Contains("views"))
            {
                
                Console.WriteLine("View Option Available");
                test.Log(Status.Info, "Verified views option");
            }
            



            if (likePost.GetAttribute("title").Contains(likeTitle))
            {
                likePost.Click();
                Console.WriteLine(likeTitle);
                test.Log(Status.Info, "Like Post Clicked");
            }
            if (followGroup.GetAttribute("title").Contains(followMessage))
            {
                Console.WriteLine(followMessage);
                test.Log(Status.Info, "Verified Following option");
            }
            if (commentOnPost.GetAttribute("title").Contains(commentTitle))
            {
                commentOnPost.Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                driver.SwitchTo().Frame(conversationFrame);
                AddDescription(CommentText);
                /*This sleep is required as the button needs to be loaded*/
                Thread.Sleep(3000);
                post.Click();

                test.Log(Status.Info, "Comments Posted");
            }
        }
        #endregion PostActions

        #region ActivityStream
        public void ActivityStream()
        {
           // personalCommons = new PersonalCommons(driver);
            personalCommons.ClickOnPersonalCommons();
            //Thread.Sleep(2000);
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            Assert.AreEqual(activityStreamMsg, activityStreamHeader.Text);           
            int typeCount = filterTypeOptions.Count;
            for (int i = 1; i <typeCount; i++)
            {
                Thread.Sleep(2000);
                PageServices.WaitForPageToCompletelyLoaded(driver, 120);
                //filterActivity.Click();
                PageServices.ClickButtonByJavaScript(driver, filterActivity);
                PageServices.WaitForPageToCompletelyLoaded(driver, 10);
                //Thread.Sleep(6000);
                //filterType.Click();
                PageServices.ClickButtonByJavaScript(driver, filterType);
                //PageServices.WaitForPageToCompletelyLoaded(driver, 10);

                /*This sleep is required as the options needs to be loaded*/
                //Thread.Sleep(1000);
                PageServices.WaitForPageToCompletelyLoaded(driver, 120);
                Thread.Sleep(2000);
                string verifyString = filterTypeOptions[i].Text;
                //filterTypeOptions[i].Click();
                PageServices.ClickButtonByJavaScript(driver, filterTypeOptions[i]);
                Thread.Sleep(2000);
                //driver.SwitchTo().DefaultContent();
               // applyFilter.Click();
                PageServices.ClickButtonByJavaScript(driver, applyFilter);
                PageServices.WaitForPageToCompletelyLoaded(driver, 120);
                Thread.Sleep(6000);
                test.Log(Status.Info, "Filter activity verified");
            }
        }
        public string VerifyFilterTypeText()
        {
            string filterText = verifyFilterType.GetAttribute("innerText").ToString();
            Console.WriteLine(filterText);
            return filterText;
        }
        //copy of activityStream

        //public void LandingPage_ActivityFeeds_FilterOption()
        //{
        //  //  personalCommons = new PersonalCommons();
        //    personalCommons.ClickOnPersonalCommons();
        //    PageServices.WaitForPageToCompletelyLoaded(driver, 120);
        //    Thread.Sleep(2000);
        //    Assert.AreEqual(activityStreamMsg, activityStreamHeader.Text);
        //    int typeCount = filterTypeOptions.Count;
        //    for (int i = 0; i < typeCount; i++)
        //    {
        //        IList<IWebElement> options = driver.FindElements(By.XPath(xpathValueFilterOptions));
        //        filterActivity.Click();
        //        Thread.Sleep(2000);
        //        filterType.Click();
        //        /*This sleep is required as the options needs to be loaded*/
        //        Thread.Sleep(2000);
        //        options[i].Click();
        //        string verifyString = options[i].Text;
        //        /*This sleep is required as the button needs to be visible*/
        //        Thread.Sleep(2000);
        //        applyFilter.Click();
        //        Thread.Sleep(2000);
        //        if (!verifyString.Contains("Any"))
        //        {
        //            Assert.That(VerifyFilterTypeText(), Does.Contain(verifyString).IgnoreCase);
        //        }
        //        else if (verifyString.Contains("Any"))
        //        {
        //            Console.WriteLine("Type: " + verifyString);
        //        }
        //    }
        //}
        
        #endregion ActivityStream

        #region EditDeleteActivityInGroup
        public void EditDeleteActivityInGroup()
        {       
            personalCommons.ClickOnPersonalCommons();
            test.Log(Status.Info, "Click to Expand Delete or Edit Sub Menu");
            editDeleteOption.Click();
            Thread.Sleep(1000);
            editOption.Click();
            test.Log(Status.Info, "Edit Activity Clcked");
            Thread.Sleep(2000);
            addTags.SendKeys(testTag);
            post.Click();            
            Assert.AreEqual(verifyTag.Text, testTag);
            test.Log(Status.Pass, "Verified updated Activity");
            editDeleteOption.Click();
            deleteOption.Click();          
            post.Click();
            Assert.That(postDeleteMsg.Text, Does.Contain(deletePost));
            test.Log(Status.Info, "Activity Has been deleted");
        }


        

        public void DeleteRecentActivity()
        {
            personalCommons.ClickOnPersonalCommons();
            editDeleteOption.Click();
            deleteOption.Click();
            post.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 160);
            Assert.That(postDeleteMsg.Text, Does.Contain(deletePost));
            test.Log(Status.Info, "Recent Activity Has been deleted");
        }

        #endregion EditDeleteActivityInGroup

        #region UserOnActivity        

        public string ClickOnUserNameOnGroupActivityAndGetName(string userName)
        {
            test.Log(Status.Info, "Click Expected User Name to Open Activity");



            Thread.Sleep(2000);
            int count = userNameOnGroupActivity.Count;
            string uName=string.Empty;
           for(; ;)
            {
                if ((userNameOnGroupActivity[0].GetAttribute("innerText").Trim()==userName))
                {
                    DeleteRecentActivity();
                    personalCommons.ClickOnPersonalCommons();
                }
                else
                {
                    uName = userNameOnGroupActivity[0].GetAttribute("innerText").Trim();
                    Console.WriteLine(uName);
                    PageServices.ClickButtonByJavaScript(driver, userNameOnGroupActivity[0]);                   
                    break;
                }
                

            }

            test.Log(Status.Info, "User name has been return from Opened Activity");
            //string uName = userNameOnGroupActivity[index].GetAttribute("innerText").Trim();
            //Console.WriteLine("User name:" +uName);
            //userNameOnGroupActivity[index].Click();
            return uName;



        }

        public string ClickOnUserNameOnGroupActivityAndGetName_old(string userName)
        {
            test.Log(Status.Info, "Click Expected User Name to Open Activity");



            Thread.Sleep(2000);
            int count = userNameOnGroupActivity.Count;
            string uName = string.Empty;


            Console.Write(count);
            for (int i = 0; i < count; i++)
            {
                if (userNameOnGroupActivity[i].GetAttribute("innerText").Trim().Contains(userName))
                {
                    continue;

                }
                else
                {
                    uName = userNameOnGroupActivity[i].GetAttribute("innerText").Trim();
                    Console.WriteLine(uName);
                    PageServices.ClickButtonByJavaScript(driver, userNameOnGroupActivity[i]);
                    // userNameOnGroupActivity[i].Click();
                    break;
                }
            }
            test.Log(Status.Info, "User name has been return from Opened Activity");
            //string uName = userNameOnGroupActivity[index].GetAttribute("innerText").Trim();
            //Console.WriteLine("User name:" +uName);
            //userNameOnGroupActivity[index].Click();
            return uName;



        }


        //public string ClickOnUserNameOnGroupActivityAndGetName_Old2(int index)
        //{
        //    Thread.Sleep(2000);
        //    int count = userNameOnGroupActivity.Count;
        //    Console.Write(count);
        //    string uName = userNameOnGroupActivity[index].GetAttribute("innerText").Trim();
        //    Console.WriteLine(uName);
        //    userNameOnGroupActivity[index].Click();
        //    return uName;

        //}
        //public string ClickOnUserNameOnGroupActivityAndGetName_Old(int index)
        //{
        //    string uName = userNameOnGroupActivity[index].GetAttribute("innerText").Trim();
        //    Console.WriteLine(uName);
        //    userNameOnGroupActivity[index].Click();
        //    return uName;

        //}


        public string GetMyGroup(LoginPage loginPage, int index)
        {
            loginPage.myGroupText.Click();
            //  Thread.Sleep(5000);
          //  string myGroup = grpActivity.GetMyGroup(0);

            string myGroup = myGroupName[index].GetAttribute("innerText");
            Console.WriteLine(myGroup);

            test.Log(Status.Pass, "Open my Group and Access Group");
            return myGroup;

            
        }
        #endregion UserOnActivity

        public void Tag_Feature_at_ActivityFeeds(string GroupName, Actions action, string Test,string uploadFile)
        {
           
            commonsGroups.JoinAndOpenGroup(GroupName);
            Thread.Sleep(2000);
            VerifyTaggingFunctionalityOnPost(action, "Test");
            VerifyTaggingFunctionalityOnEvent(action, "Test");
            VerifyTaggingFunctionalityOnUpload(action, uploadFile, "Test");
            VerifyTaggingFunctionalityForVideo(action);
        }
        public void LandingPage_School_PlaCard( string uploadFile, string DescriptionText, string TitleText)
        {
            DescriptionText = "QA Testing Description-" + PageServices.Randomizr.RandomString(5);
            TitleText = "QA Testing Title Automation-" + PageServices.Randomizr.RandomString(5);
            Thread.Sleep(3000);
            personalCommons.lnkPersonalCommons.Click();
            //discoverGroup.DiscoverAndJoinGroup(commonsGroups.ConversationGroupName);
            //commonsGroups.OpenJoinedGroup();

            commonsGroups.JoinAndOpenGroup(commonsGroups.ConversationGroupName);
            commonsGroups.GroupIcon.Click();
            AddContent_VerifyPlacardInfo(uploadFile, DescriptionText, TitleText);
            commonsGroups.Leavegroup();

            userInfo.ClickOnUserMenu();
            userInfo.ClickOnSubMenu(userInfo.ProfileSubMenu);
            PageServices.WaitForPageToCompletelyLoaded(driver, 90);
            Thread.Sleep(3000);
            notificationSettings.PlaycardInfo();
            

        }


        #region Tagging Functionality

        //Method for Verify Tagging functionality for Post, Comments and Reply
        public void VerifyTaggingFunctionalityOnPost(Actions action,string text="")
        {
            Console.WriteLine("Verify Tagging Functionality for Posts, Comments and Replies");
            test.Log(Status.Info,"Verify Tagging Functionality for Posts, Comments and Replies");
            addConversation.Click();
            driver.SwitchTo().Frame(conversationFrame);
            description.Click();         
            action.MoveToElement(description).SendKeys("@").Build().Perform();          
            driver.SwitchTo().DefaultContent();        
            Console.WriteLine(atWhoContainer.Count);
            Thread.Sleep(2000);
            IWebElement userList = atWhoContainer[0].FindElement(userListCSS);          
            userList = WebDriverExtensions.WaitUntilElementClickable(driver, userList, 90);          
            Console.WriteLine(userList.Text);
            userList.Click();
            PostConeversation_ConversationGroup(text);
            test.Log(Status.Pass, "Tagging has been verified on Conversation Post");
            Thread.Sleep(2000); 
           // post.Click();          
           // Console.WriteLine(userTagNameOnPost.Text);          

            // Click to Comment on Post
            commentOnPost.Click();          
            driver.SwitchTo().Frame(conversationFrame);          
            action.Click(description).SendKeys("@").Build().Perform();
            driver.SwitchTo().DefaultContent();         
          
            Console.WriteLine(atWhoContainer.Count);          
            userList = atWhoContainer[0].FindElement(userListCSS);
            userList = WebDriverExtensions.WaitUntilElementClickable(driver, userList, 90);
            Console.WriteLine(userList.Text);
            userList.Click();          
            post.Click();
            post.Click();
            Thread.Sleep(5000);
            // Console.WriteLine(userTagNameOnCommentsReply.Text);
            test.Log(Status.Pass, "Tagging has been verified on Comments");
            //Click on Reply
            PageServices.ClickButtonByJavaScript(driver, btnReply);
            //btnReply.Click();          
            driver.SwitchTo().Frame(conversationFrame);            
            action.Click(description).SendKeys("@").Build().Perform();
            Console.WriteLine(description.Text);
            int count = description.Text.Length;
            int i = 1;
            while (i < count)
            {
                description.SendKeys(Keys.Backspace);
                count--;
            }           
            driver.SwitchTo().DefaultContent();           
            Console.WriteLine(atWhoContainer.Count);            
            userList = atWhoContainer[0].FindElement(userListCSS);
            userList = WebDriverExtensions.WaitUntilElementClickable(driver, userList, 90);
            Console.WriteLine(userList.Text);
            userList.Click();           
            post.Click();           
           // Console.WriteLine(userTagNameOnCommentsReply.Text);

            test.Log(Status.Pass, "Tagging has been verified on Reply Post");

            //Delete the recently created activity
            DeleteRecentActivity();
            //personalCommons.ClickOnPersonalCommons();
            //editDeleteOption.Click();
            //deleteOption.Click();           
            //post.SendKeys(Keys.Enter);
           
          

        }


        public void replyToCoomentsposted(Actions action, string text ="")
        {

            // Click to Comment on Post
            Thread.Sleep(10000);

            test.Log(Status.Pass, "Open Comments to Reply");
            commentOnPost.Click();
            //btnReply.Click();
            Thread.Sleep(3000);
            driver.SwitchTo().Frame(conversationFrame);
            action.Click(description).SendKeys("@ReplyPost").Build().Perform();
            driver.SwitchTo().DefaultContent();
            btnSaveReply.Click();
            test.Log(Status.Pass, "Reply has been posted to Comments");


        }


        public void VerifyTaggingFunctionalityOnEvent(Actions action,string text="")
        {
            TitleText = "QA Testing Title Automation-" + PageServices.Randomizr.RandomString(5);
            test.Log(Status.Info, "Verify Tagging on Events");
            addEvent.Click();
            Thread.Sleep(3000);
            enterEventTitle.SendKeys(TitleText);
            driver.SwitchTo().Frame(eventFrame);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,250)", "");         
            action.Click(description).SendKeys("@").Build().Perform();              
            Console.WriteLine(description.Text);
            int count = description.Text.Length;
            int i = 1;
            while(i<count)
            {
                description.SendKeys(Keys.Backspace);
                count--;
            }
            action.Click(description).SendKeys("@").Build().Perform();
            driver.SwitchTo().DefaultContent();
            Console.WriteLine(atWhoContainer.Count);
            IWebElement userList = atWhoContainer[3].FindElement(userListCSS);
            userList = WebDriverExtensions.WaitUntilElementClickable(driver, userList, 90);
            Console.WriteLine(userList.Text);            
            userList.Click();
           //  Console.WriteLine(userTagNameEvent.Text);
            PostEvent_ConversationGroup(text, "Test Events");

            test.Log(Status.Info, "Tagging Has been verified for Events");
            //enterdate.SendKeys(eventDate);
            //enterTime.SendKeys(eventTime);
            // eventPost.Click();          



            //Delete the recently created activity
            DeleteRecentActivity();
            //personalCommons.ClickOnPersonalCommons();
            //editDeleteOption.Click();
            //deleteOption.Click();
            //post.Click();

        }


        public void VerifyTaggingFunctionalityOnUpload(Actions action, string uploadFile,string text="")
        {
            /* Upload content */
            TitleText = "QA Testing Title Automation-" + PageServices.Randomizr.RandomString(5);
            test.Log(Status.Info, "Verify Tagging on File Upload");
            PageServices.WaitForPageToCompletelyLoaded(driver, 160);
            upload.Click();
            Thread.Sleep(4000);
            uploadButton.SendKeys(uploadFile);
            Thread.Sleep(9000);//driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            enterUploadTitle.SendKeys(TitleText);
            Thread.Sleep(4000);
            driver.SwitchTo().DefaultContent();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,200)", "");
            driver.SwitchTo().Frame(uploadFrame);
            Thread.Sleep(2000);
            //PageServices.ClickButtonByJavaScript(driver, description);
            action.Click(description).Build().Perform();
            //action.SendKeys("@").Build().Perform();
            description.Click();
            description.SendKeys("@");
            int count = description.Text.Length;
            int i = 1;
            while (i < count)
            {
                description.SendKeys(OpenQA.Selenium.Keys.Backspace);
                count--;
            }
            description.SendKeys(" @");
            driver.SwitchTo().DefaultContent();
            Console.WriteLine(atWhoContainer.Count);
            IWebElement userList = atWhoContainer[1].FindElement(userListCSS);
            userList = WebDriverExtensions.WaitUntilElementClickable(driver, userList, 90);
            Console.WriteLine(userList.Text);
            userList.Click();

            driver.SwitchTo().Frame(uploadFrame);
            action.Click(description).SendKeys(text).Build().Perform();
            driver.SwitchTo().DefaultContent();

            uploadPost.Click();

            test.Log(Status.Info, "Tagging has been verified on Upload Files");

            //Delete the recently created activity
            //personalCommons.ClickOnPersonalCommons();
            //editDeleteOption.Click();
            //deleteOption.Click();
            //post.Click();
            DeleteRecentActivity();
            Thread.Sleep(7000);

        }


        public void VerifyTaggingFunctionalityForVideo(Actions action)
        {

            /* Post a Video */
            TitleText = "QA Testing Title Automation-" + PageServices.Randomizr.RandomString(5);
            test.Log(Status.Info, "Verify Tagging on Video Posting");
            video.Click();
            enterVideoTitle.SendKeys(TitleText);
            uploadVideo.SendKeys(videoURL);
            driver.SwitchTo().Frame(videoFrame);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,250)", "");
            action.Click(description).SendKeys("@").Build().Perform();
            int count = description.Text.Length;
            int i = 1;
            while (i < count)
            {
                
                description.SendKeys(Keys.Backspace);
                count--;
               
            }
            description.SendKeys(" @");
            driver.SwitchTo().DefaultContent();
            Console.WriteLine(atWhoContainer.Count);
            IWebElement userList = atWhoContainer[2].FindElement(userListCSS);
            userList = WebDriverExtensions.WaitUntilElementClickable(driver, userList, 90);
            Console.WriteLine(userList.Text);
            userList.Click();        
            videoPost.Click();

            test.Log(Status.Info, "Tagging has been verified on Video Posting");

            //Delete the recently created activity
            DeleteRecentActivity();
            //personalCommons.ClickOnPersonalCommons();

            //editDeleteOption.Click();
            //deleteOption.Click();
            //post.Click();

        }
        #endregion Tagging Functionality


        #region Post to Community Group
        //Used in Phase
        public void PostConversationInCommunityGroup(ITargetLocator TargetLocator,string DescriptionText)
        {
            test.Log(Status.Info, "Post Conversation on Community Group");
            Thread.Sleep(1000);
            plusIcon.Click();
            /* Post a conversation */
            Thread.Sleep(1000);
            postConversationIcon.Click();
            Thread.Sleep(1000);
            //CurrentFrame = driver.SwitchTo();
            TargetLocator.Frame(conversationFrame);            
            AddDescription(DescriptionText);
            /*This sleep is required as the button needs to be loaded*/
            Thread.Sleep(2000);
            TargetLocator.ActiveElement().SendKeys(Keys.Tab);
            TargetLocator.ActiveElement().SendKeys(Keys.PageDown);
            postActivity[0].Click();
            Console.WriteLine("Clicked on Post Conversation");
            Assert.That(postMsg.Text, Does.Contain(postMessage).IgnoreCase);
            Thread.Sleep(1000);

            test.Log(Status.Pass, "Conversation has been posted on Community Group");


        }
       public void PostEventInCommunityGroup(ITargetLocator TargetLocator,string DescriptionText,string TitleText)
        {
            test.Log(Status.Info, "Post Event on Community Group");
            plusIcon.Click();
            Thread.Sleep(1000);
            postEventIcon.Click();
            Thread.Sleep(2000); //Mandatory Sleep
            // eventTitleXpath.SendKeys(titleName);
            InputTitlePost[0].SendKeys(TitleText);
            // TargetLocator = driver.SwitchTo();           
            TargetLocator.Frame(eventFrameEvent);
            AddDescription(DescriptionText);
            enterdate.SendKeys(eventDate);
            Thread.Sleep(1000);
            enterTime.SendKeys(eventTime);
            Thread.Sleep(1000);
            TargetLocator.ActiveElement().SendKeys(Keys.Tab);
            TargetLocator.ActiveElement().SendKeys(Keys.PageDown);          
            postActivity[1].Click();
            Thread.Sleep(2000);
            Console.WriteLine("Clicked on Post Event");

            test.Log(Status.Pass, "Event has been posted on Community Group");
        }
        public void PostFileInCommunityGroup(ITargetLocator TargetLocator,string fileName,string DescriptionText,string TitleText)
        {
            test.Log(Status.Pass, "Upload file to Community Group");
            plusIcon.Click();
           Thread.Sleep(1000);
            postuploadIcon.Click();
            Thread.Sleep(3000);
            uploadButton.SendKeys(fileName);
            Thread.Sleep(5000);
            InputTitlePost[1].SendKeys(TitleText);
            Thread.Sleep(3000);         
            TargetLocator.Frame(uploadFrameUpload);
            AddDescription(DescriptionText);
            TargetLocator.ActiveElement().SendKeys(Keys.Tab);
            TargetLocator.ActiveElement().SendKeys(Keys.PageDown);
            postActivity[2].Click();
            Console.WriteLine("Clicked on Post File Upload");

            test.Log(Status.Pass, "File has been posted on Community Group");

        }

        public void PostVideoInCommunityGroup(ITargetLocator TargetLocator,string DescriptionText,string TitleText)
        {
            test.Log(Status.Pass, "Post Video in Community Group");
            plusIcon.Click();
            Thread.Sleep(1000);
            postVideoIcon.Click();
            Thread.Sleep(2000);
            //videoTitleXpath = driver.FindElement(By.CssSelector("div>div>#edit-title-0-value--3"));
            InputTitlePost[2].SendKeys(TitleText);
           // uploadTitle = driver.FindElement(By.CssSelector("div>div>#edit-field-video-0-value"));
            uploadVideoXpath.SendKeys(videoURL);
            //  TargetLocator = driver.SwitchTo();

            TargetLocator.Frame(videoFrameVideo);
            //driver.SwitchTo().Frame(videoFrameVideo);
            AddDescription(DescriptionText);

            //videoPostbtn = driver.FindElement(By.CssSelector("div>div>div>#edit-submit--4"));

            TargetLocator.ActiveElement().SendKeys(Keys.Tab);
            TargetLocator.ActiveElement().SendKeys(Keys.PageDown);
            postActivity[3].Click();
            Console.WriteLine("Clicked on Post Video");

            test.Log(Status.Pass, "Video has been posted on Community Group");
        }


        public void AddContentCommunityGroup_VerifySteward(string uploadFile,string DescriptionText,string TitleText)
        {
            test.Log(Status.Info, "Verify Steward option in Community Group");
            ITargetLocator TargetLocator;
            TargetLocator = driver.SwitchTo();
            PostConversationInCommunityGroup(TargetLocator,DescriptionText);
            VerifyStewardIconInPost();

            PostEventInCommunityGroup(TargetLocator, DescriptionText,TitleText);
            VerifyStewardIconInPost();

            PostFileInCommunityGroup(TargetLocator, uploadFile, DescriptionText,TitleText);
            VerifyStewardIconInPost();

            PostVideoInCommunityGroup(TargetLocator, DescriptionText,TitleText);
            VerifyStewardIconInPost();

            test.Log(Status.Pass, "Steward option verified in Community Group");

        }

        public void AddContentCommunityGroup(string uploadFile, string DescriptionText, string TitleText,bool VerifySteward)
        {
            test.Log(Status.Info, "Verify Steward option in Community Group");
            ITargetLocator TargetLocator;
            TargetLocator = driver.SwitchTo();
            PostConversationInCommunityGroup(TargetLocator, DescriptionText);
            VerifyStewardIconInPost();

            PostEventInCommunityGroup(TargetLocator, DescriptionText, TitleText);
            VerifyStewardIconInPost();

            PostFileInCommunityGroup(TargetLocator, uploadFile, DescriptionText, TitleText);
            VerifyStewardIconInPost();

            PostVideoInCommunityGroup(TargetLocator, DescriptionText, TitleText);
            VerifyStewardIconInPost();

            test.Log(Status.Pass, "Steward option verified in Community Group");

        }
        #endregion Post to Community Group


        public void AddContentConversationGroup_VerifySteward(string FileName,string DescriptionText,string TitleText)
        {
            test.Log(Status.Pass, "Verify Steward option in Conversation Group");

            //Post Conversation

            PostConeversation_ConversationGroup(DescriptionText);
            VerifyStewardIconInPost();

            /* Post an Event */
            PostEvent_ConversationGroup(DescriptionText, TitleText);
            VerifyStewardIconInPost();
            /* Upload content */
            PostFile_ConversationGroup(DescriptionText, TitleText, FileName);
            VerifyStewardIconInPost();
            /* Post a Video */
            PostVideo_ConversationGroup(DescriptionText, TitleText, videoURL);
            VerifyStewardIconInPost();

            test.Log(Status.Pass, "Steward option verified  in Conversion Group");

        }


        //public void PostPoll_ConversationGroup(string GroupName, string Question)
        //{
        //    commonsGroups.JoinAndOpenGroup(GroupName);
        //    PageServices.WaitForPageToCompletelyLoaded(driver, 120);
        //    addPollIconConv.Click();
        //    PageServices.WaitForPageToCompletelyLoaded(driver, 120);
        //    Console.WriteLine("Poll Activity form is open on the Conversation Group");
        //    addPollTitleConv.SendKeys(Question);
        //    string PollTitlePosted = Question;
        //    addPollAns0Conv.SendKeys("Option1");
        //    addPollAns1Conv.SendKeys("Option2");
        //    addPollAnsOptionBtnConv.Click();
        //    PageServices.WaitForPageToCompletelyLoaded(driver, 120);
        //    Console.WriteLine("Survey Answer Option is added");
        //    addPollAns2Conv.SendKeys("Option3");
        //    addPollAnsOptionBtnConv.Click();
        //    PageServices.WaitForPageToCompletelyLoaded(driver, 120);
        //    addPollAns3Conv.SendKeys("Option4");
        //    addPollAnsOptionBtnConv.Click();
        //    PageServices.WaitForPageToCompletelyLoaded(driver, 120);
        //    addPollAns4Conv.SendKeys("Option5");
        //    addPollAnsOptionBtnConv.Click();
        //    PageServices.WaitForPageToCompletelyLoaded(driver, 120);
        //    addPollAns5Conv.SendKeys("Option6");
        //    addPollAnsOptionBtnConv.Click();
        //    PageServices.WaitForPageToCompletelyLoaded(driver, 120);
        //    addPollAns6Conv.SendKeys("Option7");
        //    string PolldftCloseDt = polldftCloseDt.GetAttribute("value");
        //    Console.WriteLine(PolldftCloseDt);
        //    string today = DateTime.Today.ToString("yyyy-MM-dd");
        //    Console.WriteLine(today);
        //    DateTime pDate1 = DateTime.Parse(PolldftCloseDt);
        //    DateTime pDate2 = DateTime.Parse(today);
        //    TimeSpan pvalue = pDate1.Subtract(pDate2);
        //    string clsdtdiff = pvalue.ToString(@"dd");           
        //    Console.WriteLine(clsdtdiff);
        //    Assert.AreEqual("07",clsdtdiff);
        //    postPollBtnConv.Click();
        //    PageServices.WaitForPageToCompletelyLoaded(driver, 120);
        //    Console.WriteLine("Poll is posted on - " + GroupName);
        //    lnkPersonalCommons.Click();
        //    string LastPostTitleonLandPg = lastPostonLandPg.GetAttribute("innerText");
        //    Console.WriteLine(LastPostTitleonLandPg);
        //    Assert.AreEqual(PollTitlePosted, LastPostTitleonLandPg);
        //    Console.WriteLine("Poll Posted Verified on the Personal Commons");

        //}

        //public void PostPoll_CommunityGroup(string GroupName, string Question)
        //{
        //    PageServices.WaitForPageToCompletelyLoaded(driver, 120);
        //    commonsGroups.JoinAndOpenGroup(GroupName);
        //    PageServices.WaitForPageToCompletelyLoaded(driver, 120);
        //    plusIcon.Click();
        //    addPollIconComut.Click();
        //    PageServices.WaitForPageToCompletelyLoaded(driver, 120);
        //    driver.SwitchTo().Window(driver.WindowHandles.Last());           
        //    Console.WriteLine("Poll Activity Form is open on the Community Group.");
        //    Thread.Sleep(2000);
        //    addPollTitleComut.SendKeys(Question);
        //    Console.WriteLine("Poll Question is typed");
        //    pollType.Click();
        //    int PollTypeOptsCount = pollTypeOpts.Count();
        //    Console.WriteLine(PollTypeOptsCount);
        //    SelectElement polltypedropdown = new SelectElement(pollTypeSelect);
        //    for (int i = 0; i < PollTypeOptsCount; i++)
        //    {
        //        string Option = pollTypeOpts[i].GetAttribute("innerText");
        //        Console.WriteLine(Option + "- Got" + i.ToString());
        //        if (Option.Contains("Multiple"))
        //        {
                                                       
        //            Console.WriteLine(polltypedropdown.Options[i].Text);
        //            polltypedropdown.Options[i].Click();                                       
        //            break;
        //        }
                
        //    }
            
        //    PageServices.WaitForPageToCompletelyLoaded(driver, 60);
        //    addPollAns0Conv.SendKeys("Answer1");
        //    addPollAns1Conv.SendKeys("Answer2");
        //    addPollAnsOptionBtnConv.Click();
        //    PageServices.WaitForPageToCompletelyLoaded(driver, 120);
        //    addPollAns2Conv.SendKeys("Answer3");
        //    addPollAnsOptionBtnConv.Click();
        //    PageServices.WaitForPageToCompletelyLoaded(driver, 120);
        //    addPollAns3Conv.SendKeys("Answer4");
        //    addPollAnsOptionBtnConv.Click();
        //    PageServices.WaitForPageToCompletelyLoaded(driver, 120);
        //    addPollAns4Conv.SendKeys("Answer5");
        //    addPollAnsOptionBtnConv.Click();
        //    PageServices.WaitForPageToCompletelyLoaded(driver, 120);
        //    addPollAns5Conv.SendKeys("Answer6");
        //    addPollAnsOptionBtnConv.Click();
        //    PageServices.WaitForPageToCompletelyLoaded(driver, 120);
        //    addPollAns6Conv.SendKeys("Answer7");
        //    postPollBtnConv.Click();
        //    PageServices.WaitForPageToCompletelyLoaded(driver, 120);
        //    driver.SwitchTo().Window(driver.WindowHandles.First());
        //    Console.WriteLine("Poll is posted on - " + GroupName);



        //}

        public void startFeaturedPost(string GroupName)
        {
            lnkPersonalCommons.Click();
            commonsGroups.JoinAndOpenGroup(GroupName);
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            /* Posting, Verifying and Deleting Fetured Posts... */
            Console.WriteLine("********* Posting, Verifying and Deleting Fetured Posts... *********");
            test.Log(Status.Info, "********* Posting, Verifying and Deleting Fetured Posts... *********");                          

        }

        public void verifyFeatureConversation(string DescriptionText)
        {
            addConversation.Click();
            driver.SwitchTo().Frame(conversationFrame);
            AddDescription(DescriptionText);
            driver.SwitchTo().DefaultContent();
            Thread.Sleep(3000);
            featureselectConv.Click();
            post1.SendKeys(Keys.Enter);
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            for (int i = 0; i < featurePosts.Count; i++)
            {
                string PostTitleC=featurePosts[i].GetAttribute("innerText").ToString();
                if (PostTitleC.Contains(DescriptionText))
                {
                    Assert.IsTrue(true);
                    Console.WriteLine("Featured Post list verified for " + PostTitleC);
                    break;
                }
            }
           // string PostTitleC = driver.FindElement(By.CssSelector("div:nth-of-type(1) > article[role='article'] > a[target='_blank']  .post__content > .post__content--body p")).GetAttribute("innerText").ToString();
           // Assert.AreEqual(DescriptionText, PostTitleC);
          
            lastFeaturedPost.Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            PageServices.WaitForPageToCompletelyLoaded(driver, 160);
            contextualLink.Click();
            deleteContextualLink.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            confirmDelete.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            driver.SwitchTo().Window(driver.WindowHandles.Last()).Close();
            driver.SwitchTo().Window(driver.WindowHandles.First());

        }

        public void verifyFeatureEvent(string DescriptionText)
        {
            addEvent.Click();
            Thread.Sleep(3000);
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            string EventFeatureTitle = "QA Test Event Featured Post";
            enterEventTitle.SendKeys(EventFeatureTitle);
            driver.SwitchTo().Frame(eventFrame);
            AddDescription(DescriptionText);
            driver.SwitchTo().DefaultContent();
            enterdate.SendKeys(eventDate);
            enterTime.SendKeys(eventTime);
            Thread.Sleep(3000);
            featureselectEvnt.Click();
            eventPost.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            lastFeaturedPost.Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            PageServices.WaitForPageToCompletelyLoaded(driver, 160);
            string PostTitleE = driver.FindElement(By.CssSelector(".post__content--title > span")).GetAttribute("innerText").ToString();
            Assert.AreEqual(EventFeatureTitle, PostTitleE);
            Console.WriteLine("Featured Post list verified for " + PostTitleE);
            contextualLink.Click();
            deleteContextualLink.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            confirmDelete.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            driver.SwitchTo().Window(driver.WindowHandles.Last()).Close();
            driver.SwitchTo().Window(driver.WindowHandles.First());

        }

        public void verifyFeatureUpload(string DescriptionText, string FileName)
        {
            upload.Click();
            Thread.Sleep(4000);
            uploadButton.SendKeys(FileName);
            Thread.Sleep(9000);
            string UploadFeatureTitle = "QA Test Upload Featured Post";
            enterUploadTitle.SendKeys(UploadFeatureTitle);
            Thread.Sleep(3000);
            driver.SwitchTo().Frame(uploadFrame);
            AddDescription(DescriptionText);
            Thread.Sleep(2000);
            featureselectUpld.Click();
            uploadPost.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            lastFeaturedPost.Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            PageServices.WaitForPageToCompletelyLoaded(driver, 160);
            string PostTitleU = driver.FindElement(By.CssSelector(".post__content--title > span")).GetAttribute("innerText").ToString();
            Assert.AreEqual(UploadFeatureTitle, PostTitleU);
            Console.WriteLine("Featured Post list verified for " + PostTitleU);
            contextualLink.Click();
            deleteContextualLink.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            confirmDelete.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            driver.SwitchTo().Window(driver.WindowHandles.Last()).Close();
            driver.SwitchTo().Window(driver.WindowHandles.First());

        }

        public void verifyFeatureVideo(string DescriptionText, string VideoURL)
        {
            video.Click();
            string VideoFeatureTitle = "QA Test Video Featured Post";
            enterVideoTitle.SendKeys(VideoFeatureTitle);
            Thread.Sleep(4000);
            uploadVideo.SendKeys(VideoURL);
            Thread.Sleep(2000);
            driver.SwitchTo().Frame(videoFrame);
            AddDescription(DescriptionText);
            featureselectVideo.Click();
            videoPost.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            lastFeaturedPost.Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            PageServices.WaitForPageToCompletelyLoaded(driver, 160);
            string PostTitleV = driver.FindElement(By.CssSelector(".post__content--title > span")).GetAttribute("innerText").ToString();
            Assert.AreEqual(VideoFeatureTitle, PostTitleV);
            Console.WriteLine("Featured Post list verified for " + PostTitleV);
            contextualLink.Click();
            deleteContextualLink.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            confirmDelete.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            driver.SwitchTo().Window(driver.WindowHandles.Last()).Close();
            driver.SwitchTo().Window(driver.WindowHandles.First());

        }

        public void verifyFeaturePoll(string GroupName, string Question)
        {
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            addPollIconConv.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            Console.WriteLine("Poll Activity form is open on the Conversation Group");
            addPollTitleConv.SendKeys(Question);
            string PollTitlePosted = Question;
            addPollAns0Conv.SendKeys("Option1");
            addPollAns1Conv.SendKeys("Option2");
            featureselectPoll.Click();
            postPollBtnConv.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            Console.WriteLine("Poll is posted on - " + GroupName);
            PageServices.WaitForPageToCompletelyLoaded(driver, 160);
            string PostTitleP = driver.FindElement(By.XPath("/html//section[@id='content']//div[@class='feature-post-panel']//div[@class='views-element-container']//p[@class='featured-post-title']/span")).GetAttribute("innerText").ToString();
            Assert.AreEqual(PollTitlePosted, PostTitleP);
            Console.WriteLine("Featured Post list verified for " + PostTitleP);
            contextualLink2.Click();
            deleteContextualLink2.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            confirmDelete.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);

        }

          
        public void verifyStewardFn()

        {
            Console.WriteLine("******* Verify Steward for Group ********");

            String tooltipText = stewardIconList.GetAttribute("data-tooltip");
            Assert.That(tooltipText, Does.Contain("View your group's Stewards").IgnoreCase);
            Console.WriteLine("Verified tool tip");

            PageServices.ClickButtonByJavaScript(driver, stewardIconList);

            if (stewardPicNnameLink.Count >= 2)
            {
                Console.WriteLine("name and pic is hyperlinked");
            }

        }
        #region Poll Activity
        public void PostPoll_ConversationGroup(string GroupName, string Question)
        {
            commonsGroups.JoinAndOpenGroup(GroupName);
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            addPollIconConv.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            Console.WriteLine("Poll Activity form is open on the Conversation Group");
            addPollTitleConv.SendKeys(Question);
            string PollTitlePosted = Question;
            addPollAns0Conv.SendKeys("Option1");
            addPollAns1Conv.SendKeys("Option2");
            addPollAnsOptionBtnConv.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            Console.WriteLine("Survey Answer Option is added");
            addPollAns2Conv.SendKeys("Option3");
            addPollAnsOptionBtnConv.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            addPollAns3Conv.SendKeys("Option4");
            addPollAnsOptionBtnConv.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            addPollAns4Conv.SendKeys("Option5");
            addPollAnsOptionBtnConv.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            addPollAns5Conv.SendKeys("Option6");
            addPollAnsOptionBtnConv.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            addPollAns6Conv.SendKeys("Option7");
            string PolldftCloseDt = polldftCloseDt.GetAttribute("value");
            Console.WriteLine(PolldftCloseDt);
            string today = DateTime.Today.ToString("yyyy-MM-dd");
            Console.WriteLine(today);
            DateTime pDate1 = DateTime.Parse(PolldftCloseDt);
            DateTime pDate2 = DateTime.Parse(today);
            TimeSpan pvalue = pDate1.Subtract(pDate2);
            string clsdtdiff = pvalue.ToString(@"dd");           
            Console.WriteLine(clsdtdiff);
            if ("07" == clsdtdiff || "08" == clsdtdiff)
            {
                Assert.IsTrue(true);
            }
           // Assert.AreEqual("07",clsdtdiff);
            postPollBtnConv.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            Console.WriteLine("Poll is posted on - " + GroupName);
            lnkPersonalCommons.Click();
            string LastPostTitleonLandPg = lastPostonLandPg.GetAttribute("innerText");
            Console.WriteLine(LastPostTitleonLandPg);
            Assert.AreEqual(PollTitlePosted, LastPostTitleonLandPg);
            Console.WriteLine("Poll Posted Verified on the Personal Commons");

        }

        public void PostPoll_CommunityGroup(string GroupName, string Question)
        {
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            commonsGroups.JoinAndOpenGroup(GroupName);
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            plusIcon.Click();
            addPollIconComut.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            driver.SwitchTo().Window(driver.WindowHandles.Last());           
            Console.WriteLine("Poll Activity Form is open on the Community Group.");
            Thread.Sleep(2000);
            addPollTitleComut.SendKeys(Question);
            Console.WriteLine("Poll Question is typed");
            pollType.Click();
            int PollTypeOptsCount = pollTypeOpts.Count();
            Console.WriteLine(PollTypeOptsCount);
            SelectElement polltypedropdown = new SelectElement(pollTypeSelect);
            for (int i = 0; i < PollTypeOptsCount; i++)
            {
                string Option = pollTypeOpts[i].GetAttribute("innerText");
                Console.WriteLine(Option + "- Got" + i.ToString());
                if (Option.Contains("Multiple"))
                {
                                                       
                    Console.WriteLine(polltypedropdown.Options[i].Text);
                    polltypedropdown.Options[i].Click();                                       
                    break;
                }
                
            }
            
            PageServices.WaitForPageToCompletelyLoaded(driver, 60);
            addPollAns0Conv.SendKeys("Answer1");
            addPollAns1Conv.SendKeys("Answer2");
            addPollAnsOptionBtnConv.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            addPollAns2Conv.SendKeys("Answer3");
            addPollAnsOptionBtnConv.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            addPollAns3Conv.SendKeys("Answer4");
            addPollAnsOptionBtnConv.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            addPollAns4Conv.SendKeys("Answer5");
            addPollAnsOptionBtnConv.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            addPollAns5Conv.SendKeys("Answer6");
            addPollAnsOptionBtnConv.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            addPollAns6Conv.SendKeys("Answer7");
            postPollBtnConv.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            driver.SwitchTo().Window(driver.WindowHandles.First());
            Console.WriteLine("Poll is posted on - " + GroupName);



        }

        public void AddContentInGroupsingleChoicePoll(string select, string ans1, string ans2)
        {

            //Console.WriteLine("****** Poll File Posted *********************");

            SingleChiocePostPoll_ConversationGroup(select, ans1, ans2);
            Console.WriteLine("****** Single Chioce Poll File Posted *********************");
            Thread.Sleep(5000);
            PollActions();
            // groupName.Click();
            test.Log(Status.Info, "Group accessed ");


        }

        public void AddContentInGroupMuiltiChoicePoll(string select, string ans1, string ans2, string ans3, string ans4, string ans5)
        {

            //Console.WriteLine("****** Poll File Posted *********************");

            MultiChoicePostPoll_ConversationGroup(select, ans1, ans2, ans3, ans4, ans5);
            Console.WriteLine("****** Multiple choice Poll File Posted *********************");
            Thread.Sleep(5000);
            MultiplePollActions();
            // groupName.Click();
            test.Log(Status.Info, "Group accessed ");


        }

        public void SingleChiocePostPoll_ConversationGroup(string select, string ans1, string ans2)
        {
            poll.Click();
            enterpollTitle.SendKeys(select);
            Thread.Sleep(4000);
            Console.WriteLine("titlePassed");
            // int polltypeCount = pollfilteroption.Count;
            // for (int i = 0; i < polltypeCount; i++)
            // {
            // filterActivity.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 10);
            Thread.Sleep(2000);
            PollfilterCarettype.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 10);

            /*This sleep is required as the options needs to be loaded*/
            Thread.Sleep(1000);
            PageServices.WaitForPageToCompletelyLoaded(driver, 10);
            //Thread.Sleep(1000);
            pollfiltersingle.Click();
            //string verifyString = pollfilteroption[i].Text;
            //pollfilteroption[i].Click();
            Thread.Sleep(1500);
            pollAnswer1.Clear();
            pollAnswer1.SendKeys(ans1);
            Console.WriteLine("enter the value");
            pollAnswer2.Clear();
            pollAnswer2.SendKeys(ans2);
            PageServices.WaitForPageToCompletelyLoaded(driver, 30);
            pollpost.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 30);
            Thread.Sleep(5000);

            test.Log(Status.Info, "Single poll completed");
            //}
        }

        public void MultiChoicePostPoll_ConversationGroup(string select, string ans1, string ans2, string ans3, string ans4, string ans5)
        {
            poll.Click();
            enterpollTitle.SendKeys(select);
            Thread.Sleep(4000);
            Console.WriteLine("titlePassed");
            // int polltypeCount = pollfilteroption.Count;
            // for (int i = 0; i < polltypeCount; i++)
            // {
            // filterActivity.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 10);
            Thread.Sleep(2000);
            PollfilterCarettype.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 10);

            /*This sleep is required as the options needs to be loaded*/
            Thread.Sleep(1000);
            PageServices.WaitForPageToCompletelyLoaded(driver, 10);
            //Thread.Sleep(1000);
            pollfiltermultiple.Click();
            //string verifyString = pollfilteroption[i].Text;
            //pollfilteroption[i].Click();
            Thread.Sleep(1500);
            pollAnswer1.Clear();
            pollAnswer1.SendKeys(ans1);
            Console.WriteLine("enter the value");
            pollAnswer2.Clear();
            pollAnswer2.SendKeys(ans2);
            PageServices.WaitForPageToCompletelyLoaded(driver, 30);
            addAnotherItems.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 30);
            Thread.Sleep(5000);
            pollAnswer3.Clear();
            pollAnswer3.SendKeys(ans3);
            PageServices.WaitForPageToCompletelyLoaded(driver, 30);
            addAnotherItems.Click();
            pollAnswer4.SendKeys(ans4);
            PageServices.WaitForPageToCompletelyLoaded(driver, 30);
            PageServices.WaitForPageToCompletelyLoaded(driver, 30);
            addAnotherItems.Click();
            pollAnswer5.SendKeys(ans5);
            PageServices.WaitForPageToCompletelyLoaded(driver, 30);
            pollpost.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 30);
            Thread.Sleep(5000);

            test.Log(Status.Info, "Multiple poll completed");
            //}
        }
        public void MultiplePollActions()
        {
            //string expectedpollvalue = "STATUS MESSAGE\r\nYour answer has been saved successfully.\r\nclose";

            string expectedpollvalue = "Status message\r\nYour answer has been saved successfully.\r\nclose";

            if (TakepollBtn.GetAttribute("innerText").Contains("TAKE POLL"))
            {
                //TakepollBtn.Click();
                PageServices.ClickButtonByJavaScript(driver, TakepollBtn);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(35);
                Takepollcheckbox.Click();
                TakepollMultiplecheckbox.Click();
                TakepollMultiplecheckbox4.Click();
                TakepollSubmit.Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(35);
                Thread.Sleep(5000);
                // TakepollBtn2.Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(35);
                string PollMgs = Pollcompleted.Text;
                Console.WriteLine(PollMgs);
                Assert.AreEqual(expectedpollvalue, Pollanswersavetxtd.GetAttribute("innerText").ToString());
                Console.WriteLine(expectedpollvalue);
                groupHeader.Click();

                test.Log(Status.Info, "Multiple Poll Posted");
            }
            if (TakepollBtn.GetAttribute("innerText").Contains("TAKE POLL"))
            {
                TakepollBtn.Click();
                Thread.Sleep(5000);
                // TakepollBtn2.Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(35);
                string PollMgs = Pollcompleted.Text;
                Console.WriteLine(PollMgs);
                Console.WriteLine("Member can poll only once in Multiple Chocie");
                groupHeader.Click();

                test.Log(Status.Info, "Member can poll only once");
            }
        }

        public void PollActions()
        {
            //string expectedpollvalue = "STATUS MESSAGE\r\nYour answer has been saved successfully.\r\nclose";

            string expectedpollvalue = "Status message\r\nYour answer has been saved successfully.\r\nclose";

            if (TakepollBtn.GetAttribute("innerText").Contains("TAKE POLL"))
            {
                TakepollBtn.Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(35);
                Takepollcheckbox.Click();
                TakepollSubmit.Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(35);
                Thread.Sleep(5000);
                // TakepollBtn2.Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(35);
                string PollMgs = Pollcompleted.Text;
                Console.WriteLine(PollMgs);
                Assert.AreEqual(expectedpollvalue, Pollanswersavetxtd.GetAttribute("innerText").ToString());
                Console.WriteLine(expectedpollvalue);
                groupHeader.Click();
                test.Log(Status.Info, "Single Poll Posted");
            }
            if (TakepollBtn.GetAttribute("innerText").Contains("TAKE POLL"))
            {
                TakepollBtn.Click();
                Thread.Sleep(5000);
                // TakepollBtn2.Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(35);
                string PollMgs = Pollcompleted.Text;
                Console.WriteLine(PollMgs);
                Console.WriteLine("Member can poll only once");
                groupHeader.Click();

                test.Log(Status.Info, "Member can poll only once");
            }
        }

        #endregion Poll Activity


        public void AddContent_VerifyPlacardInfo(string FileName, string DescriptionText, string TitleText)
        {

            PostConeversation_ConversationGroup(DescriptionText);
            VerifyPlacardInfoInPost();

            /* Post an Event */
            PostEvent_ConversationGroup(DescriptionText, TitleText);
            VerifyPlacardInfoInPost();

            /* Upload content */
            PostFile_ConversationGroup(DescriptionText, TitleText, FileName);
            VerifyPlacardInfoInPost();

            /* Post a Video */
            PostVideo_ConversationGroup(DescriptionText, TitleText, videoURL);
            VerifyPlacardInfoInPost();

        }

        public string EditPostAndArchiveInGroup(string postType, string PostStatus)
        {

            PageServices.ScrollPageUptoTop(driver);

            FilterContentOnProfile.Click();

            FilterByTypeOnProfilePage(postType);
            FilterByStatusOnProfilePage(PostStatus);
            string ActivityName = string.Empty;



            PageServices.ClickButtonByJavaScript(driver, ApplyFilter);
            Thread.Sleep(5000);
            if (postType == "Conversation")
            {
                ActivityName = ActivityListDescrOnProfile[0].Text;
            }
            else
            {
                ActivityName = ActivityListTitleOnProfile[0].Text;
            }

            test.Log(Status.Info, "Click to Expand Delete or Edit Sub Menu");

            EditActvtyIcon[0].FindElement(buttonCSS).Click();

            EditActvtyIcon[0].FindElement(EditXPath).Click();
            chkArchive.Click();

            post.Click();

            test.Log(Status.Info, "Edit Activity Clcked");
            Thread.Sleep(2000);
            return ActivityName;
        }


        public void FilterByTypeOnProfilePage(string postType)
        {
            Thread.Sleep(2000);

            TypeFilter.Click();
            Thread.Sleep(2000);
            PageServices.ScrollPageUptoTop(driver);//, 50);

            for (int i = 0; i < TypeFilterOptn.Count; i++)
            {
                string txt = TypeFilterOptn[i].GetAttribute("innerHTML");

                if (txt.Contains(postType))
                {

                    Thread.Sleep(2000);
                    TypeFilterOptn[i].Click();
                    Thread.Sleep(5000);
                    break;
                }
            }

            Thread.Sleep(2000);

        }


        public void FilterByStatusOnProfilePage(string PostStatus)
        {
            Thread.Sleep(2000);

            ArchiveStatuFilter.Click();
            Thread.Sleep(2000);


            for (int i = 0; i < ArchiveStatuFilterOptn.Count; i++)
            {

                if (ArchiveStatuFilterOptn[i].GetAttribute("innerHTML").Contains(PostStatus))
                {

                    ArchiveStatuFilterOptn[i].Click();
                    Thread.Sleep(5000);
                    break;
                }
            }
        }
        public void VerifyArchived(string postType, string PostStatus, string postTitle)
        {
            PageServices.ScrollPageUptoTop(driver);

            FilterContentOnProfile.Click();
            Thread.Sleep(2000);
            FilterByTypeOnProfilePage(postType);
            FilterByStatusOnProfilePage(PostStatus);


            PageServices.ClickButtonByJavaScript(driver, ApplyFilter);
            PageServices.ClickButtonByJavaScript(driver, ApplyFilter);


            for (int i = 0; i < ActivityList.Count; i++)
            {
                string txt = ActivityList[i].Text;
                if (txt.Contains(postTitle))
                {
                    Assert.IsTrue(true);
                    Thread.Sleep(5000);
                    break;
                }
            }
            test.Log(Status.Pass, "Archived Post Verified");
        }
        public void VerifyCommonetAndFollowingOnArchived()
        {
            Thread.Sleep(1000);
            string txt = CommentDisabled[0].GetAttribute("data-tooltip");
            Assert.AreEqual("Comments are disabled, this post is archived.", txt);
            string txt1 = FollowingDisabled[0].GetAttribute("data-tooltip");
            Thread.Sleep(1000);
            Assert.AreEqual("Following is disabled, this post is archived.", txt1);
        }
    }
    }
