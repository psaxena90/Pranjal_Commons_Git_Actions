using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace Commons_Automation
{
    public class Outlook:MainSetup
    {
        public string enrollmentSubject = "You Are Almost Enrolled at NCU! ";
        public string txtRemovePIN = "Permanent PIN number: ";
        public string txtRemoveTempUser = "Temporary Username: ";
        public string txtRemoveTempPassword = "Temporary Password: ";

        #region login

        
        [FindsBy(How = How.CssSelector, Using = "input[name=loginfmt]")]
        public IWebElement userID { set; get; }        
        [FindsBy(How = How.Name, Using = "passwd")]
        public IWebElement txtPassword { set; get; }

        [FindsBy(How = How.CssSelector, Using = "input[value=Next]")]
        public IWebElement btnNext { get; set; }


        [FindsBy(How = How.CssSelector, Using = "#okta-signin-username")]
        public IWebElement OktaInputUserName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#okta-signin-password")]
        public IWebElement OktaInputPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#okta-signin-submit")]
        public IWebElement OktaSignIn { get; set; }    
       

        [FindsBy(How = How.CssSelector, Using = "input[type='Submit']")]
        public IWebElement signInOld { get; set; }
        
        [FindsBy(How = How.CssSelector, Using = "input[value='Sign in']")]
        public IWebElement signIn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[value='No']")]
        public IWebElement rememberMeNo { get; set; }
        
        [FindsBy(How = How.CssSelector, Using = "#app > div > div> div > div > div> div > div > div>div>div>div>div[role='tree']")]      
        public IList<IWebElement> folderList { get; set; }
        
        [FindsBy(How = How.CssSelector, Using = "div[draggable='true']>div>div>div:nth-child(2)>div:nth-child(2)>div>span")]
        public IList<IWebElement> mailRow { get; set; }        
        [FindsBy(How = How.CssSelector, Using = "#app > div > div > div > div > div > div > div > div > div > div > div > div > div > div > div > div > div > div > div > table > tbody > tr > td> table > tbody > tr > td > table > tbody > tr ")]
        public IList<IWebElement> txtReportedtMsgBody { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#x_templateBody div")]
        public IWebElement EmailBodayContent;


        #endregion

        #region Specific Element

        By CSSBtnExpandEmailFolder = By.CssSelector("div>div>button");
        By CSSInboxFolder = By.CssSelector("div[title='Inbox']");
        // By EmailContentRows = By.CssSelector("table>tbody>tr");
        By EmailContent = By.XPath("tbody/tr[1]/td[3]");
        By EmailContentRows = By.XPath("tbody/tr[1]/td[3]/table/tbody/tr/td/table/tbody/tr");
        #endregion Specific Element

        #region old elements
        [FindsBy(How = How.CssSelector, Using = "#MailFolderPane\\.FavoritesFolders >div")]
        public IList<IWebElement> emailFavoritesFolders { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#MailFolderPane\\.FavoritesHeader")]
        public IWebElement favoritesHeader { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[class^=contextMenuDropShadow] > div > div > div > div > div > button > div > span:nth-child(2)")]
        public IWebElement btnAddToFavorite { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.popupPanel.panelPopupShadow > div > div._pfp_a > div > div > div > div > div._pfp_d > div > div > div:nth-child(2) > div > div > div > span > div > span > span")]
        public IWebElement xpandFolderArrow { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.subfolders > div>div>div>span>div>span:nth-child(4)")]
        public IList<IWebElement> folders { get; set; }




        [FindsBy(How = How.CssSelector, Using = "body > div.popupPanel.panelPopupShadow > div >div:nth-child(1)>button[title='Add to Favorites']")]
        public IWebElement btnAddFolder { get; set; }


        [FindsBy(How = How.CssSelector, Using = "body > div.popupPanel.panelPopupShadow > div >div:nth-child(1)>button[title='Close']")]
        public IWebElement btnCloseAddfavoriteWindow { get; set; }
        [FindsBy(How = How.CssSelector, Using = "#divSubject")]
        public IList<IWebElement> outLookSubject { get; set; }
        [FindsBy(How = How.Id, Using = "ifBdy")]
        public IWebElement msgBody { get; set; }

        [FindsBy(How = How.Id, Using = "divLV")]
        public IWebElement emailList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > center > table > tbody > tr:nth-child(7) > td")]
        public IWebElement txtTempUser { get; set; }
        [FindsBy(How = How.CssSelector, Using = "body > center > table > tbody > tr:nth-child(8) > td")]
        public IWebElement tempPassword { get; set; }
        [FindsBy(How = How.CssSelector, Using = "body > center > table > tbody > tr:nth-child(10) > td")]

        [FindsBy(How = How.CssSelector, Using = "center>table>tbody>tr")]
        public IList<IWebElement> emailRows { get; set; }

        public IWebElement permanentPIN { get; set; }
        [FindsBy(How = How.Id, Using = "divScrollbar")]
        public IWebElement mailScroller { get; set; }
        #endregion  


        public Outlook()
        {
          

            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(120)));
        }

        public void LoginToO365WebMail(string userId, string password)
        {
            userID.SendKeys(userId);
           
            PageServices.ClickButtonByJavaScript(driver, btnNext);
            Thread.Sleep(8000);
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
          
            OktaInputUserName.SendKeys(userId);
            Thread.Sleep(2000);
            OktaInputPassword.SendKeys(password);
            OktaSignIn.Submit();            
            //PageServices.ClickButtonByJavaScript(driver, rememberMeNo);
            Thread.Sleep(6000);

        }

        public void AccessPublicFolder(string folderName)
        {
            //This sleep is required to populate all folders
            int count = folderList.Count;
            Console.WriteLine(count);
            for (int i = 0; i < count; i++)
            {
                string text = folderList[i].Text;
                Console.WriteLine(text);// ;
                if (text.Contains(folderName))
                {
                    folderList[i].FindElement(CSSBtnExpandEmailFolder).Click();
                    Thread.Sleep(4000);
                    folderList[i].FindElement(CSSInboxFolder).Click();
                    Thread.Sleep(5000);
                    break;
                }

            }
        }

        public void OpenReportedMessageEmail_N(string userId, string emailsubject)
        {
            string sebJect;
            Console.WriteLine(mailRow.Count);
            for (int j = 0; j < mailRow.Count; j++)
            {
                Console.WriteLine(mailRow[j].Text);
                sebJect = string.Concat(userId, " ", emailsubject);
                if (mailRow[j].Text.Contains(sebJect))
                {
                    Console.WriteLine(mailRow[j].Text);
                    mailRow[j].Click();
                    Thread.Sleep(2000);
                    Console.WriteLine(txtReportedtMsgBody.Count);
                    int i = txtReportedtMsgBody.Count - 1;

                    txtReportedtMsgBody[i].Click();
                    IWebElement msgContent = txtReportedtMsgBody[i].FindElement(EmailContent);
                    Console.WriteLine(msgContent.Text);

                    IList<IWebElement> msgRow = txtReportedtMsgBody[i].FindElements(EmailContentRows);
                    Console.WriteLine(msgRow.Count());
                    int k = msgRow.Count();

                    if (msgRow[k - 1].Text.Contains("This message includes 1 attachment(s)."))
                    {
                        Console.WriteLine(msgRow[k - 1].Text);
                        Assert.IsTrue(msgRow[k - 1].Text.Contains("This message includes 1 attachment(s)."));
                        Console.WriteLine(msgRow[k - 3].Text);
                        Assert.IsTrue(msgRow[k - 3].Text.Contains("This is for testing! Please Ignore."));
                    }

                }
                break;
            }

        }

        public void OpenReportedMessageEmail(string userId, string emailsubject)
        {
            string sebJect;           
            Console.WriteLine(mailRow.Count);
            for (int j = 0; j < mailRow.Count; j++)
            {
                Console.WriteLine(mailRow[j].Text);
                sebJect = string.Concat(userId, " ", emailsubject);
                if (mailRow[j].Text.Contains(sebJect))
                {
                    Console.WriteLine(mailRow[j].Text);
                    mailRow[j].Click();
                    Thread.Sleep(2000);                   
                    Console.WriteLine(txtReportedtMsgBody.Count);
                    for (int i = txtReportedtMsgBody.Count - 1; i > 1; i--)
                    {
                        if (txtReportedtMsgBody[i].Text.Contains("This message includes 1 attachment(s)."))
                        {
                            Console.WriteLine(i);
                            Console.WriteLine(txtReportedtMsgBody[i].Text);
                            Assert.IsTrue(txtReportedtMsgBody[i].Text.Contains("This message includes 1 attachment(s)."));
                            Console.WriteLine(txtReportedtMsgBody[i - 2].Text);
                            Assert.IsTrue(txtReportedtMsgBody[i - 2].Text.Contains("This is for testing! Please Ignore."));
                            break;

                        }

                    }
                    break;


                }


            }

        }

        public void VerifyingEmailForPayment(string LearnerIdASCPaymentscreen, string LearnerFistNameASCPaymentscreen, string LearnerLastNameASCPaymentscreen)
        {

            Console.WriteLine(mailRow.Count);
            for (int j = 0; j < mailRow.Count; j++)
            {
                Console.WriteLine(mailRow[j].Text);
                if (mailRow[j].Text.Contains("Proofreader Service Payment Receipt"))
                {
                    string emailSubject = mailRow[j].Text;
                    Console.WriteLine("Subject text from Mail" + emailSubject);
                    string LearnerName = LearnerFistNameASCPaymentscreen + " " + LearnerLastNameASCPaymentscreen;

                    Assert.IsTrue(emailSubject.Contains(LearnerIdASCPaymentscreen));
                    Assert.IsTrue(emailSubject.Contains(LearnerName));
                    mailRow[j].Click();
                    Thread.Sleep(2000);
                    // User = emailRows[6].Text;

                    Console.WriteLine("User Name From email  ");
                    break;

                }


            }


        }

        public void VerifyingEmailBodyForFacultySubtitution(string LearnerIdASCPaymentscreen, string LearnerFistNameASCPaymentscreen, string LearnerLastNameASCPaymentscreen)
        {


            string EmailBoday = EmailBodayContent.GetAttribute("innerText");
            Console.WriteLine(EmailBoday);
            string LearnerName = LearnerFistNameASCPaymentscreen + " " + LearnerLastNameASCPaymentscreen;

            // Assert.IsTrue(EmailBoday.Contains(LearnerName));
            Assert.IsTrue(EmailBoday.Contains("INSTRUCTIONS:"));
            Assert.IsTrue(EmailBoday.Contains("Please follow the link below to reserve the session that aligns with this purchase."));
            Assert.IsTrue(EmailBoday.Contains("Please follow the link below to reserve the session that aligns with this purchase."));


        }
    }
}

#region Old Code
//not in use
//public void LoginToOutlook(string userId,string password)
//{

//    userID.SendKeys(userId);
//    txtPassword.SendKeys(password);
//    signIn.Click();
//    //WebDriverExtensions.FindElement(driver, By.CssSelector("#lgnDiv > div.signInEnter > div > img"), 120).Click();
//}

//public int EnrollmentMailCount()
//{
//    int count = outLookSubject.Count;
//    return count;
//}

//not in use
//public void AccessOrAddFavoriteFolder(string folderName)
//{
//    //This sleep is required to populate all folders
//    Thread.Sleep(5000);
//    int i = 0;
//    foreach (var item in emailFavoritesFolders)
//    {
//        if (item.Text == folderName)
//        {
//            break;
//        }
//        i++;
//    }
//    if (i == emailFavoritesFolders.Count)
//    {              
//        Actions actions = new Actions(driver);
//        actions.ContextClick(favoritesHeader).Perform();
//        driver.SwitchTo().ActiveElement();               
//        btnAddToFavorite.Click();
//        Thread.Sleep(2000);
//        driver.SwitchTo().DefaultContent();              
//        xpandFolderArrow.Click();
//        Thread.Sleep(2000);          
//        Console.WriteLine(folders.Count);
//        for (int j = 0; j < folders.Count; j++)
//        {
//            Console.WriteLine(folders[j].Text);
//            if (folders[j].Text == folderName)
//            {
//                folders[j].Click();                       
//                btnAddFolder.Click();
//                Thread.Sleep(1000);
//                btnCloseAddfavoriteWindow.Click();

//                break;

//            }

//        }
//    }
//    else
//    {
//        emailFavoritesFolders[i].Click();
//        Thread.Sleep(5000);
//        //item found
//    }
//}


//public void OpenReportedMessageEmail(string userId, string emailsubject)
//{
//    string sebJect;
//    string msgText;
//    Console.WriteLine(mailRow.Count);
//    for (int j = 0; j < mailRow.Count; j++)
//    {
//        Console.WriteLine(mailRow[j].Text);
//        sebJect = string.Concat(userId, " ", emailsubject);
//        if (mailRow[j].Text.Contains(sebJect))
//        {
//            Console.WriteLine(mailRow[j].Text);
//            mailRow[j].Click();
//            Thread.Sleep(2000);
//           // IList<IWebElement> msgText = driver.FindElements(By.CssSelector("div[id*=MessageNormalizedBody] > div > div > div > table>tbody>tr>td>table>tbody>tr>td>table>tbody>tr"));
//            Console.WriteLine(txtReportedtMsgBody.Count);
//            for (int i = txtReportedtMsgBody.Count - 1; i > 1; i--)
//            {
//                if (txtReportedtMsgBody[i].Text.Contains("This message includes 1 attachment(s)."))
//                {
//                    Console.WriteLine(i);
//                    Console.WriteLine(txtReportedtMsgBody[i].Text);
//                    Assert.IsTrue(txtReportedtMsgBody[i].Text.Contains("This message includes 1 attachment(s)."));
//                    Console.WriteLine(txtReportedtMsgBody[i - 2].Text);
//                    Assert.IsTrue(txtReportedtMsgBody[i - 2].Text.Contains("This is for testing! Please Ignore."));
//                    break;
//                    break;
//                }

//            }
//            break;


//        }


//    }


//}

//public void SwitchToEmailBody()
//{
//    driver.SwitchTo().Frame(msgBody);
//}
#endregion





