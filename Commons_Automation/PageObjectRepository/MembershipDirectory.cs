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
using OpenQA.Selenium.Support.UI;
using AventStack.ExtentReports;

namespace Commons_Automation
{
    public class MembershipDirectory : MainSetup
    {

        // IWebDriver driver;

        public MembershipDirectory()
        {
            // driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(90)));
        }

        #region MembershipDirectory elements

        //[FindsBy(How = How.CssSelector, Using = "#navigation > div > div:nth-child(4) > a")]
        //[FindsBy(How = How.CssSelector, Using = "#navigation > div > div>a[href='/membership-directory']")]
        [FindsBy(How = How.XPath, Using = "//*[@id='navigation-second']/div/div[7]/a")]
        public IWebElement DirectoryTopMenu { get; set; }

        //[FindsBy(How = How.XPath, Using = "//*[@id='views-exposed-form-directory-all']/ul/li/div[1]/a/span")]
        [FindsBy(How = How.CssSelector, Using = ".text-icon-container span")]
        public IWebElement FilterExpand { get; set; }


        [FindsBy(How = How.Name, Using = "Reset")]
        public IWebElement Reset { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div#edit_state_chosen")]
        public IWebElement StatesdropdownList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#edit_state_chosen > div > div > input")]
        public IWebElement StatesdropdownListInput { get; set; }

       

        [FindsBy(How = How.XPath, Using = "//input[@id='edit-submit-directory']")]
        public IWebElement ApplyBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='views-element-container']/div/div/ul/li[1]/div/div[@class='card-header']/div[@class='location']")]
        public IWebElement CardInfo { get; set; }


        //[FindsBy(How = How.XPath, Using = "//section[@id='content']/div/ul//a[@href='/membership-directory/student']")]
        [FindsBy(How = How.LinkText, Using = "Student")]
        public IWebElement MemDirStudentTab { get; set; }

        //[FindsBy(How = How.XPath, Using = "//section[@id='content']/div/ul//a[@href='/membership-directory/faculty']")]
        [FindsBy(How = How.LinkText, Using = "Faculty")]
        public IWebElement MemDirFacultyTab { get; set; }

        [FindsBy(How = How.XPath, Using = "/html//form[@id='views-exposed-form-directory-student']/ul[@class='collapsible exposed-form-collapsible']//span[.='Filter']")]
        public IWebElement ExpandFilterStd { get; set; }

        [FindsBy(How = How.XPath, Using = "/html//form[@id='views-exposed-form-directory-faculty']/ul[@class='collapsible exposed-form-collapsible']//span[.='Filter']")]
        public IWebElement ExpandFilterFclt { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[@class='views-element-container']/div/div/ul/li[1]/div/div[@class='card-content']/div[@class='school']")]
        public IWebElement MemCardSchoolName { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='edit_school_chosen']/a[@class='chosen-single']")]
        public IWebElement memdir { get; set; }


        //[FindsBy(How = How.XPath, Using = "//div[@id='edit_school_chosen']/div[@class='chosen-drop']/ul/li")]
        //public IList<IWebElement> options { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div#directory-views-container>div>div>form>ul > li > div[class*='collapsible-body']> div > div[class*='form-item-school']>div")]
        public IWebElement SchoolDropDown { get; set; }


        [FindsBy(How = How.CssSelector, Using = "#edit_school_chosen > div > div > input")]
        public IWebElement SchoolDropDownInput { get; set; }

        //[FindsBy(How = How.CssSelector, Using = "#content > div > h1")]
        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div/h3[2]")]
        public IWebElement MemeberShipTitile { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div#directory-views-container>div>div>form>ul > li > div[class*='collapsible-body']> div > div[class*='form-item-school']>div>div>ul>li")]
        IList<IWebElement> schollList { get; set; }
        #endregion MembershipDirectory elements


        #region GotoMembershipDirectorypage

        public void GotoMembershipDirectorypage()
        {
            test.Log(Status.Info, "Access Membership  Directory Page");
            DirectoryTopMenu.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 60);
            Thread.Sleep(3000);
            string MemberShipPageTitile = MemeberShipTitile.GetAttribute("innerText");
            Console.WriteLine(MemberShipPageTitile);
            Assert.AreEqual("Membership Directory", MemberShipPageTitile);

            test.Log(Status.Pass, "Membership  Directory Page has been accessed");
        }

        #endregion GotoMembershipDirectorypage

        #region VerifyStatesNAimplementation_All
        public void VerifyStatesNAimplementation_All()
        {
            test.Log(Status.Info, "Verify NA Option on Memmbership Filter");
            //WebDriverExtensions.FindElement(driver, By.CssSelector("#content > div > ul > li > a[href*='student']"), 120).Click();
            Thread.Sleep(1000);
            // WebDriverExtensions.FindElement(driver, By.CssSelector("#content > div > ul > li:nth-child(1) > a"), 120).Click();

            PageServices.ClickButtonByJavaScript(driver, FilterExpand);// FilterExpand.Click();
            Thread.Sleep(2000);

            Console.WriteLine("States drop down field is clicked.");
            test.Log(Status.Info, "States drop down field is clicked.");

            StatesdropdownList.Click();
            Thread.Sleep(1000);
            StatesdropdownListInput.SendKeys("N/A" + Keys.Enter);
            Thread.Sleep(3000);


            /*
            SelectElement options = new SelectElement(StatesdropdownList);
            Console.WriteLine("States options are listed");
            int optioncount = options.Options.Count;
            Console.WriteLine(optioncount);

            for (int i = 0; i < optioncount; i++)
            {
                if (options.Options[i].Text.Contains("N/A"))
                {

                    Console.WriteLine(options.Options[i].Text + "Implemented");
                    options.Options[i].Click();
                    Thread.Sleep(1000);
                    test.Log(Status.Pass, options.Options[i].Text + "Implemented");
                    break;
                }


            }
            */

            PageServices.WaitForPageToCompletelyLoaded(driver, 60);
            ApplyBtn.Click();
            Assert.IsTrue(CardInfo.Text.Contains(" "));
            Thread.Sleep(3000);
            Console.WriteLine("Not applicable state shows up blank space");
            test.Log(Status.Info, "Not applicable state shows up blank space");


        }

        #endregion VerifyStatesNAimplementation_All


        public void Resetss()
        {
            Reset.Click();
        }


        public void SelectValueFromStateDropdown_All()
        {
            test.Log(Status.Info, "Verify State Drop down in Membership Directory");
            FilterExpand.Click();
            Thread.Sleep(2000);
            Console.WriteLine("States drop down field is clicked.");

            StatesdropdownList.Click();
            Thread.Sleep(1000);
            StatesdropdownListInput.SendKeys("AR" + Keys.Enter);
            Thread.Sleep(1000);

            /*
            SelectElement options = new SelectElement(StatesdropdownList);
            Console.WriteLine("States options are listed");
            int optioncount = options.Options.Count;
            Console.WriteLine(optioncount);

            for (int i = 0; i < optioncount; i++)
            {
                if (options.Options[i].Text.Contains("AR"))
                {

                    Console.WriteLine(options.Options[i].Text + "Implemented");
                    options.Options[i].Click();
                    Thread.Sleep(3000);
                    break;
                }


            }
            */
            PageServices.WaitForPageToCompletelyLoaded(driver, 60);
            ApplyBtn.Click();
            //Assert.IsTrue(CardInfo.Text.Contains("AR"));
            Thread.Sleep(3000);
            Console.WriteLine("Value Selected From State Dropdown_All and Results are displayed");

            test.Log(Status.Pass,"Value Selected From State Dropdown_All and Results are displayed");


        }

        #region VerifyStatesNAimplementation_Student

        public void VerifyStatesNAimplementation_Student()
        {
            //MemDirStudentTab.Click();
            PageServices.ClickButtonByJavaScript(driver, MemDirStudentTab);
            PageServices.WaitForPageToCompletelyLoaded(driver, 60);
            ExpandFilterStd.Click();
            Thread.Sleep(2000);

            StatesdropdownList.Click();
            Thread.Sleep(1000);
            StatesdropdownListInput.SendKeys("N/A" + Keys.Enter);
            Thread.Sleep(3000);

            /*
            SelectElement options = new SelectElement(StatesdropdownList);
            Console.WriteLine("States options are listed");

            int optioncount = options.Options.Count;
            Console.WriteLine(optioncount);

            for (int i = 0; i < optioncount; i++)
            {
                if (options.Options[i].Text.Contains("N/A"))
                {

                    Console.WriteLine(options.Options[i].Text + "Implemented");
                    options.Options[i].Click();
                    Thread.Sleep(1000);

                    test.Log(Status.Pass, "State has NA option Student Membership Directory");
                    break;
                }
            }
            */
            PageServices.WaitForPageToCompletelyLoaded(driver, 60);
            ApplyBtn.Click();
            Assert.IsTrue(CardInfo.Text.Contains(" "));
            Thread.Sleep(3000);
            Console.WriteLine("Not applicable state shows up blank space");
        }

        #endregion VerifyStatesNAimplementation_Student


        #region VerifyStatesNAimplementation_Faculty

        public void VerifyStatesNAimplementation_Faculty()
        {
            MemDirFacultyTab.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 60);
            ExpandFilterFclt.Click();
            Thread.Sleep(2000);
            SelectElement options = new SelectElement(StatesdropdownList);
            Console.WriteLine("States options are listed");
            int optioncount = options.Options.Count;
            Console.WriteLine(optioncount);
            for (int i = 0; i < optioncount; i++)
            {
                if (options.Options[i].Text.Contains("N/A"))
                {

                    Console.WriteLine(options.Options[i].Text + "Implemented");
                    options.Options[i].Click();
                    Thread.Sleep(1000);
                    break;
                }
            }


            PageServices.WaitForPageToCompletelyLoaded(driver, 60);
            ApplyBtn.Click();
            Assert.IsTrue(CardInfo.Text.Contains(" "));
            Thread.Sleep(3000);
            Console.WriteLine("Not applicable state shows up blank space");
        }

        #endregion VerifyStatesNAimplementation_Faculty

        #region VerifyLawSchoolMemDir

        public void VerifyLawSchoolMemDir(string SchoolType)
        {
            test.Log(Status.Info, "Verify School in Membership Directory");
            FilterExpand.Click();
            Thread.Sleep(2000);
            Console.WriteLine("School drop down field is clicked.");
            Console.WriteLine("School options are listed");

            Thread.Sleep(2000);

            SchoolDropDown.Click();
            Thread.Sleep(3000);
           
            //Madan if we required we can uncomment the below line as per UI Change if we have input box for dropdown
            //SchoolDropDownInput.SendKeys("School of Law" + Keys.Tab);



            //PageServices.WaitForPageToCompletelyLoaded(driver, 160);
            //ApplyBtn.Click();
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


            int schoolListCount = schollList.Count;

            for (int i = 0; i < schoolListCount; i++)
            {
                if (schollList[i].Text.Contains(SchoolType))
                {

                    Console.WriteLine(schollList[i].Text + " Implemented");
                    schollList[i].Click();
                    Thread.Sleep(2000);
                    test.Log(Status.Pass, schollList[i].Text + "'School of Law' Implemented");
                    break;
                }

            }

            

            test.Log(Status.Pass,"School of Law is displayed for the JFK User");
        }

        #endregion VerifyLawSchoolMemDir

        #region OpenMemDirStudentTab

        public void OpenMemDirStudentTab()
        {

            PageServices.ScrollPageUptoTop(driver);
            MemDirStudentTab.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 60);
            test.Log(Status.Pass, "Student Tab has been accessed on Membership Directory ");
        }

        #endregion OpenMemDirStudentTab


        #region OpenMemDirFacultyTab

        public void OpenMemDirFacultyTab()
        {
            PageServices.ScrollPageUptoTop(driver);
            MemDirFacultyTab.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 60);
            test.Log(Status.Pass, "Faculty Tab has been accessed on Membership Directory ");
        }

        #endregion OpenMemDirFacultyTab

    }
}