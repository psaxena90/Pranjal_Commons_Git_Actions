using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;
using System.Data;
using AventStack.ExtentReports;

namespace Commons_Automation
{
    public class DirectoryGroupMessage:MainSetup
    {

       // IWebDriver driver;

        public DirectoryGroupMessage()
        {
           // driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(90)));
        }

        #region driver elements        
      

        string GroupMessagePopupInnerText = "Check the box on any user's card to include them in a group message.";
        string userdisplaynameatTolist1;

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div/div[1]/a[2]")]
        public IWebElement StudentTab { get; set; }

        //[FindsBy(How = How.PartialLinkText, Using = "Directory")]


        [FindsBy(How = How.XPath, Using = "//nav[@id='navigation-second']//a[@href='/membership-directory']")]

        public IWebElement DirectoryTopMenu { get; set; }


        [FindsBy(How = How.CssSelector, Using = "#group-private-message > div.display > button > i")]
        public IWebElement GroupMessageButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#directory-views-container > div > div > div > ul > li:nth-child(1) > div > input[type=checkbox]")]
        public IWebElement UserSelectionCheckBox { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".card-title")]
        public IWebElement CardTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='views-exposed-form-directory-all']/ul/li/div[1]/a/span")]
        //[FindsBy(How = How.XPath, Using = "//*[@id='views-exposed-form-directory-all']/ul/li/div[2]/a")]
        public IWebElement FilterExpand { get; set; }

        //[FindsBy(How = How.ClassName, Using = "Filter")]// "//*[@id='views-exposed-form-directory-all']/ul/li/div[1]/a/span")]
        //public IWebElement FilterExpand { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[@id='edit_school_chosen']//input[@class='chosen-search-input']")]
        public IWebElement SchoolSelectDropdown { get; set; }
        

        [FindsBy(How = How.CssSelector, Using = "#edit-submit-directory")]
        public IWebElement ApplyFilterButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#group-private-message>div.display>button>i")]
        public IWebElement GroupMeesageButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body>div.ui-dialog.ui-corner-all.ui-widget.ui-widget-content.ui-front.no-title.report-alert.ui-dialog-buttons.ui-draggable")]
        public IWebElement GroupMessagePopup { get; set; }


        [FindsBy(How = How.CssSelector, Using = "#report-alert > div > h6")]
        public IWebElement GroupMessagePopupText { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.ui-dialog-buttonset> button")]
        public IWebElement GroupMessagePopupOk { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='directory-views-container']/div/div/div/ul/li[1]/div/input")]
        public IWebElement UserCheckBox1 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='directory-views-container']/div/div/div/ul/li[2]/div/input")]
        public IWebElement UserCheckBox2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='directory-views-container']/div/div/div/ul/li[3]/div/input")]
        public IWebElement UserCheckBox3 { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='directory-views-container']/div/div/div/ul/li[4]/div/input")]
        public IWebElement UserCheckBox4 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='directory-views-container']/div/div/div/ul/li[5]/div/input")]
        public IWebElement UserCheckBox5 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='directory-views-container']/div/div/div/ul/li[6]/div/input")]
        public IWebElement UserCheckBox6 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='directory-views-container']/div/div/div/ul/li[7]/div/input")]
        public IWebElement UserCheckBox7 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='directory-views-container']/div/div/div/ul/li[8]/div/input")]
        public IWebElement UserCheckBox8 { get; set; }

        [FindsBy(How = How.CssSelector, Using = "li:nth-of-type(n) > .card.card-constrained.contextual-region.directory-entry > input")]
        public IList<IWebElement> UserCheckBox { get; set; }




        [FindsBy(How = How.XPath, Using = "//*[@id='group-private-message']/div[2]/button[1]")]
        public IWebElement GroupMessageBoxCreatebutton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='edit-message-wrapper']/div/div[1]/body")]
        public IWebElement MeesgaeBoxGroup { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//*[@id='edit-submit']")]
        public IWebElement MeesgaeGroupSubmitButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='cke_1_contents']/iframe")]

        public IWebElement eventFrameEvent { get; set; }

        
        [FindsBy(How = How.CssSelector, Using = "html > body[class*='cke_editable']")]

        public IWebElement inputMessage { get; set; }
        

        [FindsBy(How = How.CssSelector, Using = "button[value='Send']")]

        public IWebElement SendMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='directory-views-container']/div/div/div/ul/li[1]/div/div[1]/div[1]/a")]

        public IWebElement MembersCards1 { get; set; }

        [FindsBy(How = How.XPath, Using = " //*[@id='select_members_list_chosen']/ul/li[1]/span")]
        public IWebElement UseratTolist1 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='directory-views-container']/div/div/div/ul/li[2]/div/div[1]/div[1]/a")]

        public IWebElement MembersCards2 { get; set; }

        [FindsBy(How = How.XPath, Using = " //*[@id='select_members_list_chosen']/ul/li[2]/span")]
        public IWebElement UseratTolist2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='directory-views-container']/div/div/div/ul/li[3]/div/div[1]/div[1]/a")]

        public IWebElement MembersCards3 { get; set; }

        [FindsBy(How = How.XPath, Using = " //*[@id='select_members_list_chosen']/ul/li[3]/span")]
        public IWebElement UseratTolist3 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='directory-views-container']/div/div/div/ul/li[4]/div/div[1]/div[1]/a")]

        public IWebElement MembersCards4 { get; set; }

        [FindsBy(How = How.XPath, Using = " //*[@id='select_members_list_chosen']/ul/li[4]/span")]
        public IWebElement UseratTolist4 { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='directory-views-container']/div/div/div/ul/li[5]/div/div[1]/div[1]/a")]

        public IWebElement MembersCards5 { get; set; }

        [FindsBy(How = How.XPath, Using = " //*[@id='select_members_list_chosen']/ul/li[5]/span")]
        public IWebElement UseratTolist5 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='directory-views-container']/div/div/div/ul/li[6]/div/div[1]/div[1]/a")]

        public IWebElement MembersCards6 { get; set; }

        [FindsBy(How = How.XPath, Using = " //*[@id='select_members_list_chosen']/ul/li[6]/span")]
        public IWebElement UseratTolist6 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='directory-views-container']/div/div/div/ul/li[2]/div/div[1]/div[1]/a")]

        public IWebElement MembersCards7 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='select_members_list_chosen']/ul/li[2]/span")]
        public IWebElement UseratTolist7 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='directory-views-container']/div/div/div/ul/li[2]/div/div[1]/div[1]/a")]

        public IWebElement MembersCards8 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='select_members_list_chosen']/ul/li[2]/span")]
        public IWebElement UseratTolist8 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='private-message-menu']/ul/li[3]/a")]
        public IWebElement PvtMsgCreateNew { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='select_members_list_chosen']/ul/li/input")]
        public IWebElement PvtMsgCreateNewChosen { get; set; }

        //[FindsBy(How = How.XPath, Using = "//*[@id='select_members_list_chosen']/div/ul")]
        [FindsBy(How = How.XPath, Using = "//*[@id='select_members_list_chosen']/div/ul/li")]
        public IList <IWebElement> PvtMsgCreateNewuserlist { get; set; }

        [FindsBy(How = How.ClassName, Using = "active-result")]
        public IWebElement PvtMsgCreateNewuserClass { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#select_members_list_chosen > div > ul > li")]
        public IList<IWebElement> PvtMsgCreateNewuserlist1 { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#select_members_list_chosen > ul > li")]
        public IWebElement mailToBox { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#select_members_list_chosen > ul > li > input")]
        public IWebElement inputMailToBox { get; set; }

        [FindsBy(How = How.CssSelector, Using = "li:nth-of-type(1) > button[title='Remove user from the list'] > .material-icons ")]
        public IWebElement RemoveIconOnPopup { get; set; }





        #endregion driver elements


        #region VerifyDirectoryGroupMessage

        public void VerifyMembershipDirectorylink()
        {
            Assert.IsTrue(DirectoryTopMenu.Displayed);
        }
            

        public void VerifyDirectoryGroupMessage()
        {
           
            Assert.IsTrue(DirectoryTopMenu.Displayed);
            test.Log(Status.Pass,"Directory link available on the Top Menu Bar");
            Thread.Sleep(2000); //pause for onsite runs
            DirectoryTopMenu.Click();
            //Console.WriteLine("MEMBERSHIP DIRECTORY page is displayed");
            FilterExpand.Click();
          
            Console.WriteLine("MEMBERSHIP DIRECTORY page is displayed");
            test.Log(Status.Pass,"MEMBERSHIP DIRECTORY page is displayed");
            Thread.Sleep(1000);
            ApplyFilterButton.Click();
            Thread.Sleep(1000);
            bool GroupMeesageButtonDisplayed = GroupMeesageButton.Displayed;
            test.Log(Status.Pass,"GroupMeesageButton is displayed   " + GroupMeesageButtonDisplayed);
            Assert.IsTrue(GroupMeesageButtonDisplayed);
            //GroupMeesageButton.Click();
            //PageServices.WaitForPageToCompletelyLoaded(driver, 60);
            //Console.WriteLine("Group Private Message options are enabled");
            //test.Log(Status.Info,"Group Private Message options are enabled");
            //string groupMessagePopupText = GroupMessagePopupText.GetAttribute("innerText").ToString();
            //Console.WriteLine(groupMessagePopupText);
            //Assert.AreEqual(GroupMessagePopupInnerText, groupMessagePopupText);
            //Thread.Sleep(1000);
           // WebDriverExtensions.FindElement(driver, By.CssSelector("#content > div > ul > li > a[href*='student']"), 120).Click();
           // WebDriverExtensions.FindElement(driver, By.XPath("//*[@id='views-exposed-form-directory-all']/ul/li/div[1]/a[2]"), 120).Click();
            //WebDriverExtensions.FindElement(driver, By.XPath("//*[@id='content']/div/div[1]/a[2]"), 120).Click();

            PageServices.ClickButtonByJavaScript(driver, StudentTab);

            Thread.Sleep(1000);
            // WebDriverExtensions.FindElement(driver, By.CssSelector("#content > div > ul > li > a[href*='#']"), 120).Click();
           // WebDriverExtensions.FindElement(driver, By.XPath("//form[@id='views-exposed-form-directory-all']/ul/li/div[1]/a[1]"), 120).Click();
            Console.WriteLine("Group Private Message Pop-up open and message veified");
            test.Log(Status.Pass,"Group Private Message Pop-up open and message veified");
            GroupMeesageButton.Click();
            Console.WriteLine("Group Private Message options are enabled");
            test.Log(Status.Info, "Group Private Message options are enabled");
            string groupMessagePopupText = GroupMessagePopupText.GetAttribute("innerText").ToString();
            Console.WriteLine(groupMessagePopupText);
            Assert.AreEqual(GroupMessagePopupInnerText, groupMessagePopupText);
            Thread.Sleep(1000);
            PageServices.WaitForPageToCompletelyLoaded(driver, 60);
            GroupMessagePopupOk.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 60);
            //UserCheckBox1.Click();
            string memberdisplayname1 = MembersCards1.GetAttribute("innerText").ToString();
            Console.WriteLine(memberdisplayname1);
            //UserCheckBox2.Click();
            string memberdisplayname2 = MembersCards2.GetAttribute("innerText").ToString();
            Console.WriteLine(memberdisplayname2);
            //UserCheckBox3.Click();
            //UserCheckBox4.Click();
            //UserCheckBox5.Click();
            //UserCheckBox6.Click();
            //UserCheckBox7.Click();
            //UserCheckBox8.Click();


            for (int i=0; i<8; i++ )
            {
                UserCheckBox[i].Click();
            }

          
            Thread.Sleep(1000);
      
            Console.WriteLine("Users' names are selected for Group Private Message.");
            test.Log(Status.Pass,"Users' names are selected for Group Private Message.");


            GroupMeesageButton.Click();
            //RemoveIconOnPopup.Click();
            //UserCheckBox1.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 60); 
            Actions ac=new Actions(driver);
            ac.MoveToElement(GroupMessageBoxCreatebutton).Build().Perform();

            GroupMessageBoxCreatebutton.Click();
            Thread.Sleep(1000);
            Console.WriteLine("Group Private Message form displayed with user lists.");
            test.Log(Status.Pass,"Group Private Message form displayed with user lists.");
            userdisplaynameatTolist1 = UseratTolist1.GetAttribute("innerText").ToString();
            Console.WriteLine(userdisplaynameatTolist1);
            Assert.AreEqual(memberdisplayname1, userdisplaynameatTolist1);
            string userdisplaynameatTolist2 = UseratTolist2.GetAttribute("innerText").ToString();
            Console.WriteLine(userdisplaynameatTolist2);
            Assert.AreEqual(memberdisplayname2, userdisplaynameatTolist2);
            test.Log(Status.Pass,"Selected User list's name is verified with Display Name");
            Actions a = new Actions(driver);  
            driver.SwitchTo().Frame(eventFrameEvent);
            a.Click(inputMessage).SendKeys("QA Test for Group Private Message.").Build().Perform();
            driver.SwitchTo().DefaultContent();                      
            Thread.Sleep(1000);            
            MeesgaeGroupSubmitButton.Click();
            Thread.Sleep(1000);
            Console.WriteLine("Message text Typed and Group Private Message Sent");
            test.Log(Status.Pass,"Message text Typed and Group Private Message Sent");
            PageServices.ScrollPageUptoTop(driver); 
            PvtMsgCreateNew.Click();
            Thread.Sleep(3000);
            Console.WriteLine("New Private Message Form page opened.");
            PvtMsgCreateNewChosen.Click();
            Thread.Sleep(2000);
            PvtMsgCreateNewChosen.SendKeys("Katia Nyysti");
            PvtMsgCreateNewuserlist[0].Click();
            Console.WriteLine("New Private Message Form page working.");
            test.Log(Status.Pass,"Verified Private Message Normal page also has display name at To Field.");
                            

        }

        #endregion VerifyDefaultGroupAtMyGroups


#region Delete user from pop-up list 

        public void DeleteUsrfromPopupList()
        {
            string UserNameOnPopup=RemoveIconOnPopup.GetAttribute("innerText");
            Console.WriteLine(UserNameOnPopup);
           RemoveIconOnPopup.Click();
            Assert.AreEqual(UserNameOnPopup, userdisplaynameatTolist1);

        }



#endregion End of Delete user from pop-up lis

    }
}
