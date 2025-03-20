using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Commons_Automation
{
  public class SearchPage:MainSetup
    {

       // Idriver driver;

        #region String Section
        public string titleName = "QA Testing Title Automation";
        public string expectSearchValue = "QA";
        public string expectSearchProfileSearch = "Profile";
        public string expectSearchMenu = "LinkedIn";
        public string expectSearchMenuPSY = "PSY";
        public string nonExpectSearchValue = "QAsfjkhdjkfdsfsdfjksdjkfds8230239823";
        public string noResult = "Your search did not yield any results.";
        public string noResultSuggestion = "Make sure all words are spelled correctly and try more general keywords.";
        public string expectSearchContentTitle = "Just for testing";
        public string expectSearchContentDescription = "#Testing$QA#TEST";
        public string DisabledCommentText = "Comments are disabled, this post is archived.";
       public  string DisabledFollowingText = "Following is disabled, this post is archived.";
       public string ArchiveTextAfterFilterText = "Archived: Archived only";
       public string FollowingButton = "You automatically follow your own post.";
       public string BannerText = "This is an archived post, older than two years and the information included in this post may no longer be valid. Comments are disabled.";

        #endregion String Section

        #region Search PageElement
        //[FindsBy(How = How.CssSelector, Using = "input[id^= 'edit-search-api-fulltext']")]
        [FindsBy(How = How.CssSelector, Using = "input[id^= 'edit-search-api-fulltext']")]
        public IWebElement inputSearch { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[id^='edit-submit-search-results']")]
        public IWebElement btnSearch { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#content > div > div > div > div.no-results > p.no-results.text-align-left")]
        public IWebElement noSearchResult { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#content > div > div> div > div.no-results >  p.no-results-sub.text-align-left")]
        public IWebElement noSearchResultSugesstion { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#content > div > div > div > div.search-result-item")]
        public IList<IWebElement> searchResultCount { get; set; }

        [FindsBy(How =How.CssSelector,Using ="#content > div > div.views-element-container.contextual-region > div > header")]
        IWebElement lblTotalResult { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#content > div > div.views-element-container.contextual-region > div > nav > ul > li > a[title='Go to next page']")]
        IWebElement btnNextPage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#content > div > div.views-element-container.contextual-region > div > nav > ul > li > a[title='Go to previous page']")]
        IWebElement btnPreviousPage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#content > div > div.views-element-container.contextual-region > div > nav > ul > li > a[title='Go to last page']")]
        IWebElement btnLastPage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#content > div > div.views-element-container.contextual-region > div > nav > ul > li > a[title='Go to first page']")]
        IWebElement btnFirstPage { get; set; }

        [FindsBy(How = How.XPath, Using = "//i[@data-tooltip='Group Steward'][1]")]
        public IWebElement stewardIcon { get; set; }

        //[FindsBy(How = How.CssSelector, Using = "#edit-search-api-fulltext--3")]
        //[FindsBy(How = How.CssSelector, Using = "input[data-drupal-selector='edit-search-api-fulltext']")]
        [FindsBy(How = How.CssSelector, Using = "input[id^= 'edit-search-api-fulltext']")]
        public IWebElement inputSearchMenuSearch { get; set; }
        [FindsBy(How = How.XPath, Using = "(//input[@value='- Any -']/..)[3]")]
        public IWebElement TypeFilter { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@value='Relevance']/..)[3]")]
        public IWebElement SortByFilter { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@value='Desc']/..)[3]")]
        public IWebElement OrderFilter { get; set; }

        [FindsBy(How = How.XPath, Using = "(//button[@type='submit'])[3]")]
        public IWebElement FilterSearchButton { get; set; }

        /* Search - by Shashi  */
        [FindsBy(How = How.XPath, Using = "(//div[@class='post__content--body']/div/p[1])[1]")]
        public IWebElement verifyContenTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@class='post__content--body']/div/p[1])[1]")]
        public IWebElement verifyContentDescription { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@class='intro-container']/a/h2)[1]")]
        public IWebElement verifyGroupTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@class='entity__intro--description']/p)[1]")]
        public IWebElement verifyGroupDescription { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@class='user-picture__large']/../*[2]/h2)[1]")]
        public IWebElement verifyPersonTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@class='contextual']/button)[1]")]
        public IWebElement clickOnGruopPencilIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div/div[2]/div/div[2]/div[1]/div[1]/div/ul/li")]
        IList<IWebElement> clickOnContent { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='collapsible-header']/a/span")]
        public IWebElement clickOnGroupFilterContent { get; set; }

        [FindsBy(How = How.XPath, Using = "(//label[text()='Type']/../div/div)[3]")]
        public IWebElement clickOnGroupTypeContent { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='edit-actions']/button")]
        public IWebElement ClickOnApplyButton { get; set; }

        [FindsBy(How = How.XPath, Using = "(//label[text()='Type']/../div/div/ul/li[2])[3]")]
        public IWebElement selectConversationTypeContent { get; set; }

        [FindsBy(How = How.XPath, Using = "(//label[text()='Type']/../div/div/ul/li[3])[3]")]
        public IWebElement selectEventTypeContent { get; set; }

        [FindsBy(How = How.XPath, Using = "(//label[text()='Type']/../div/div/ul/li[4])[3]")]
        public IWebElement selectUploadTypeContent { get; set; }

        [FindsBy(How = How.XPath, Using = "(//label[text()='Type']/../div/div/ul/li[5])[3]")]
        public IWebElement selectVideoTypeContent { get; set; }
        [FindsBy(How = How.CssSelector, Using = "div[data-drupal-selector='views-exposed-form-search-results-page-1']>form[novalidate=novalidate]>div>label[for='edit-field-archived-1--3']+div>div>input[value='Unarchived']")]
        public IWebElement FilterStatusOnSearch { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[data-drupal-selector='views-exposed-form-search-results-page-1']>form[novalidate=novalidate]>div>label[for='edit-field-archived-1--3']+div>div>ul>li")]
        public IList<IWebElement> FilterStatusOptions { get; set; }
        //[FindsBy(How = How.CssSelector, Using = "#edit-submit-search-results--3 > i")]
        //[FindsBy(How = How.XPath, Using = "//div[@id='edit-actions--3']/button[@id='edit-submit-search-results--3']")]
        [FindsBy(How = How.XPath, Using = "//button[@id='edit-submit-search-results--3']")]
        public IWebElement btnSearchActivty { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#content > div > div.views-element-container.contextual-region > div > div > article > div")]
        public IList<IWebElement> SearchResultList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#content > div > div.views-element-container.contextual-region > div > div > article > div span[data-tooltip*='Comments are disabled']")]
        public IList<IWebElement> CommentDisabled { get; set; } 

        [FindsBy(How = How.XPath, Using = "/html//div[@id='block-exposedformsearch-resultspage-1']/form[@action='/search']//select[@name='search_api_datasource']/option")]
        public IList<IWebElement> SearchTypeDrpDnOptions { get; set; }

        [FindsBy(How = How.XPath, Using = "/html//div[@id='block-exposedformsearch-resultspage-1']/form[@action='/search']//select[@name='search_api_datasource']")]
        public IWebElement SearchTypeDrpDnSelect { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[@id='block-exposedformsearch-resultspage-1']/form[@action='/search']//button")]
        public IWebElement Re_SearchBtn { get; set; }
        

        [FindsBy(How = How.CssSelector, Using = "#content > div > div.views-element-container.contextual-region > div > div > article > div span[data-tooltip*='Following is disabled']")]
        public IList<IWebElement> FollowingDisabled { get; set; }
                
        [FindsBy(How = How.XPath, Using = "//div[@class='collection-item avatar']//span[@class='post__meta--type']/a")]
        public IList<IWebElement> elem { get; set; }

        #endregion Search PageElement


        public SearchPage()
        {
            //driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(90)));
        }


        #region Page Methods
       
        public void ExpectedResultSearch(string expectSearchValue)
        {
            inputSearch.Clear();
            Thread.Sleep(500);
            inputSearch.SendKeys(expectSearchValue +Keys.Enter);
            Thread.Sleep(3000);
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            //btnSearch.Submit();
            Console.WriteLine("Total number of search outcome: " + searchResultCount.Count);
            Assert.IsTrue(searchResultCount.Count > 0);
            Thread.Sleep(500);
            Console.WriteLine("****** Search with Result Complete *******");
        }

       
        public void ExpectedResultSearch3(string expectSearchValue)
        {
            inputSearch.Clear();
            Thread.Sleep(500);
            inputSearch.SendKeys(expectSearchValue);
            Thread.Sleep(3000);
            btnSearchActivty.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            //btnSearch.Submit();
            Console.WriteLine("Total number of search outcome: " + searchResultCount.Count);
            Assert.IsTrue(searchResultCount.Count > 0);
            Thread.Sleep(500);
            Console.WriteLine("****** Search with Result Complete *******");
        }

        public void ExpectedResultSearch2()
        {
            inputSearch.Clear();
            Thread.Sleep(500);
            inputSearch.SendKeys(expectSearchProfileSearch + Keys.Enter);
            //Thread.Sleep(5000);
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            Console.WriteLine(searchResultCount.Count);
            Assert.IsTrue(searchResultCount.Count > 0);
            Thread.Sleep(500);
        }

        public void ExpectedResultFromSearchMenuSearch()
        {
            inputSearch.Clear();
           // inputSearchMenuSearch.Clear();
            Thread.Sleep(500);
            inputSearch.SendKeys(expectSearchMenu + Keys.Enter);
            //inputSearchMenuSearch.SendKeys(expectSearchValue3 + Keys.Enter);
            // inputSearchMenuSearch.SendKeys(expectSearchValue3 + Keys.Enter);
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            Console.WriteLine(searchResultCount.Count);
            Assert.IsTrue(searchResultCount.Count > 0);
            Thread.Sleep(500);
        }

        public void VerifySearchOptionAvailableOnAlication()
        {
            Console.WriteLine("Searc OPtion  " +inputSearch.GetAttribute("innertext"));
            Assert.AreEqual(inputSearch.GetAttribute("innertext"), "Search");
        }
            
        public void ExpectedResultFromSearchMenuSearch2()
        {
            inputSearch.Clear();
            //inputSearchMenuSearch.Clear();
            Thread.Sleep(500);
            inputSearch.SendKeys(expectSearchMenuPSY + Keys.Enter);
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            Console.WriteLine(searchResultCount.Count);
            Assert.IsTrue(searchResultCount.Count > 0);
            Thread.Sleep(500);
        }
        public void NoResultSearch()
        {
            inputSearch.Clear();
          
            inputSearch.SendKeys(nonExpectSearchValue);
            btnSearch.Submit();
            Console.WriteLine("Alert message: " + noSearchResult.Text);
            inputSearch.SendKeys(nonExpectSearchValue+Keys.Enter);
            // btnSearch.Submit();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            Console.WriteLine(noSearchResult.Text);
            Console.WriteLine(noSearchResultSugesstion.Text);
            Assert.AreEqual(noResult.Trim(), noSearchResult.Text.Trim());
            Assert.AreEqual(noResultSuggestion.Trim(), noSearchResultSugesstion.Text.Trim());
            Thread.Sleep(500);
            Console.WriteLine("****** Search with No Result Complete *******");
        }


        public void ValidatePageNavigationOnSearchPage()
        {
            string resultHeader = lblTotalResult.Text;
            int pos = resultHeader.LastIndexOf(@"of ");
            string countRes = resultHeader.Substring(pos).Replace(@"of ", "");
            int x = int.Parse(countRes);
            if (x > 10)
            {
                btnNextPage.Click();
                Thread.Sleep(500);
                btnPreviousPage.Click();
                Thread.Sleep(500);
                btnLastPage.Click();
                Thread.Sleep(500);
                btnFirstPage.Click();              
            }
        }
        #endregion Page Methods

        public void SearchContentStewardIcon(string searchText)
        {
            test.Log(Status.Info, "Verify Steward option on Search result");
            PageServices.WaitForPageToCompletelyLoaded(driver, 90);
            Thread.Sleep(3000);
            inputSearch.Clear();
            Thread.Sleep(500);
            inputSearch.SendKeys(searchText);
            btnSearch.Submit();
            Thread.Sleep(2000);          
            
            Assert.That(stewardIcon.Text, Does.Contain("star").IgnoreCase);
            String tooltipText = stewardIcon.GetAttribute("data-tooltip");
            Assert.That(tooltipText, Does.Contain("Group Steward").IgnoreCase);
            Console.WriteLine("Verified tool tip");
            test.Log(Status.Pass, "Steward option verified in Search result");
        }

        public void VerifyFiterOptions()
        {
            Assert.IsTrue(inputSearch.Displayed);
            Assert.IsTrue(TypeFilter.Displayed);
            Assert.IsTrue(SortByFilter.Displayed);
            Assert.IsTrue(OrderFilter.Displayed);
            OrderFilter.Click();
            Thread.Sleep(2000);
            Assert.IsTrue(FilterSearchButton.Enabled);
            Console.WriteLine("Search result page has Filter option");
            test.Log(Status.Pass, "Search result page has Filter option");
        }

        public void VerifyContentTitleText()
        {
            String ContenTitletext = verifyContenTitle.Text;            
            Assert.That(ContenTitletext, Does.Contain("LinkedIn").IgnoreCase);
        }

        public void VerifyContentDescriptionText()
        {
            String ContentDescriptiontext = verifyContentDescription.Text;
            Assert.That(ContentDescriptiontext, Does.Contain("LinkedIn").IgnoreCase);
        }

        public void VerifyGroupTitleText()
        {
            String GroupTitletext = verifyGroupTitle.Text;
            Assert.That(GroupTitletext, Does.Contain("PSY").IgnoreCase);
        }

        public void VerifyGroupDescriptionText()
        {
            String ContentDescriptiontext = verifyGroupDescription.Text;
            Assert.That(ContentDescriptiontext, Does.Contain("PSY").IgnoreCase);
        }

        public void VerifyPersonTitleText()
        {
            String personTitletext = verifyPersonTitle.Text;
            Assert.That(personTitletext, Does.Contain("PSY").IgnoreCase);
        }

        public void PollActSearch()
        {
            grpActivity.lnkPersonalCommons.Click();
            DateTime dy = DateTime.Now;
            string PollTitle = "QA Automation Poll Testing - " + dy;
            grpActivity.PostPoll_ConversationGroup("University Community Forum", "QA Automation Poll Testing - " + dy);
            //applying below static wait as the newly created group is taking time to show in search results
            Thread.Sleep(15000);
            inputSearch.Clear();
            inputSearch.SendKeys(PollTitle);
            inputSearch.Click();
            inputSearch.SendKeys(Keys.Enter);
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            pollResultVerify();            
            SelectElement options = new SelectElement(SearchTypeDrpDnSelect);
            Console.WriteLine("Search Type options are listed");
            int optioncount = options.Options.Count;
            Console.WriteLine(optioncount);

            for (int i = 0; i < optioncount; i++)
            {
                if (options.Options[i].Text.Contains("Content"))
                {

                    Console.WriteLine(options.Options[i].Text + " Implemented");
                    options.Options[i].Click();
                    Thread.Sleep(3000);
                    break;
                }


            }
            Thread.Sleep(4000);
            Re_SearchBtn.Click();
            pollResultVerify();

        }

        public void pollResultVerify()
        {
            Console.WriteLine(elem.Count + " - Poll Cards are displayed.");
            for (int i = 0; i < elem.Count - 1; i++)
            {
                Console.WriteLine(elem[i].Text);
                string text = elem[i].Text;                
                Assert.AreEqual(text, "poll");
                test.Log(Status.Pass, "Assert Passed");
            }

        }

        public void ClickOnGroupContent()
        {
            Thread.Sleep(3000);
            clickOnGruopPencilIcon.Click();
            Thread.Sleep(3000);
            int count = clickOnContent.Count;
            for (int i = 0; i < clickOnContent.Count; i++)
            {
                Console.WriteLine(clickOnContent[i].Text);
                if (clickOnContent[i].Text.Contains("Content"))
                {
                    clickOnContent[i].Click();
                    break;
                }
            }
            test.Log(Status.Pass, "Group content page has been accessed");
            Thread.Sleep(2000);
            /*--Select Cnversation*/
            clickOnGroupFilterContent.Click();
            clickOnGroupTypeContent.Click();
            selectConversationTypeContent.Click();
            ClickOnApplyButton.Click();
            Thread.Sleep(2000);
            test.Log(Status.Pass, "Search and Filter on Conersation ");

            /*--Select Event*/
            clickOnGroupFilterContent.Click();
            clickOnGroupTypeContent.Click();
            selectEventTypeContent.Click();
            ClickOnApplyButton.Click();
            Thread.Sleep(2000);
            test.Log(Status.Pass, "Search and Filter on Event Section ");
            /*--Select upload*/
            clickOnGroupFilterContent.Click();
            clickOnGroupTypeContent.Click();
            selectUploadTypeContent.Click();
            ClickOnApplyButton.Click();
            Thread.Sleep(2000);
            test.Log(Status.Pass, "Search and Filter on Upload File Section ");
            /*--Select video*/
            clickOnGroupFilterContent.Click();
            clickOnGroupTypeContent.Click();
            selectVideoTypeContent.Click();
            ClickOnApplyButton.Click();
            Thread.Sleep(2000);
            test.Log(Status.Pass, "Search and Filter on Video Section ");

        }

        public void SearchArchivedContent(string ExpectedValue)
        {
            inputSearch.Clear();
            Thread.Sleep(500);
            inputSearch.SendKeys(ExpectedValue + Keys.Enter);
            Thread.Sleep(5000);
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            Thread.Sleep(5000);
            FilterStatusOnSearch.Click();
            driver.SwitchTo().ActiveElement();

            Actions ac = new Actions(driver);




            for (int i = 0; i < FilterStatusOptions.Count; i++)
            {
                string txt = FilterStatusOptions[i].GetAttribute("innerHTML");

                if (txt.Contains("Archived only"))
                {

                    ac.MoveToElement(FilterStatusOptions[i]);
                    ac.Click(FilterStatusOptions[i]).Perform();                    

                    break;

                }

            }
            //Following wait added to search results to display
            Thread.Sleep(20000);
            /*
            //Confirm
            FilterStatusOnSearch.Click();
            driver.SwitchTo().ActiveElement();

            //Actions ac = new Actions(driver);




            for (int i = 0; i < FilterStatusOptions.Count; i++)
            {
                string txt = FilterStatusOptions[i].GetAttribute("innerHTML");

                if (txt.Contains("Archived only"))
                {

                    ac.MoveToElement(FilterStatusOptions[i]);
                    ac.Click(FilterStatusOptions[i]).Perform();

                    break;

                }

            }
            Thread.Sleep(5000);
            //Confirm   */

            btnSearchActivty.Click();
            

            //PageServices.ClickButtonByJavaScript(driver, btnSearchActivty);

           

            for (int i = 0; i < SearchResultList.Count; i++)
            {
                if (SearchResultList[i].Text.Contains(ExpectedValue))
                {
                    Assert.IsTrue(true);
                    break;
                }
            }

            Assert.AreEqual(DisabledCommentText, CommentDisabled[0].GetAttribute("data-tooltip"));
            Assert.AreEqual(DisabledFollowingText, FollowingDisabled[0].GetAttribute("data-tooltip"));


            Thread.Sleep(500);
        }
    }
}