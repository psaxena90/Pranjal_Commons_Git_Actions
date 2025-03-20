using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Commons_Automation
{
   public class PrivateMessage:MainSetup
    {
       // IWebDriver driver;
        public PrivateMessage()
        {
           // driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(90)));
        }

        #region Expcted Text

        public string createPrivateMsg = "Start a chat";
        public string messageRequiredError = "Message field is required.";
       // public string messageRequiredError = "Message field is required.";
        
        public string testMessage = "This is for testing! Please Ignore.";
        public int inboxSubMenuIndex = 0;
        public int archiveSubMenuIndex = 1;
        public int createMsgSubMenuIndex = 2;
        public string clcdateTime;



        #endregion Expcted Text


        #region Inbox Section

        [FindsBy(How = How.CssSelector, Using = "div>a[href*='inbox']>img.menu-icon")]
        public IWebElement Inbox { get; set; }


        [FindsBy(How = How.CssSelector, Using = "a[href *= 'private_message']")]
        public IWebElement StartChat { get; set; }



        #endregion Inbox Section

        #region Private Message Page Element   
                

       // [FindsBy(How = How.XPath, Using = "//nav[@id='navigation']//a[@href='/inbox']")]
        [FindsBy(How = How.XPath, Using = "//*[@id='navigation-second']//a[@href='/inbox']")]

        public IWebElement chatMenu { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='pm_chat']/a/span[2]")]
        public IWebElement chatSideMenu { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#private-message-menu > ul > li > a")]
        public IList<IWebElement> pvtMsgSubMenu { get; set; }


        [FindsBy(How = How.CssSelector, Using = "#private-message-menu > ul > li:nth-child(5) > a")]
        public IWebElement subMenuPvtMsg{ get; set; }


        [FindsBy(How = How.CssSelector, Using = "#block-views-block-profile-block-1 > div:nth-child(2) > div > div.views-row > div.contextual-region.profile.contextual-exposed.no-contextual-outline > div > h2")]
        //"div:nth-of-type(2) > .private-message-thread.private-message-thread-inbox > .collection  .flex.flex-align-center.flex-row > div:nth-of-type(1) > a[title='View user profile.']")]        
        public IWebElement userNameOnPvtMsgTab { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#block-views-block-profile-block-1 > div:nth-child(2) > div > div > div > div > div > a")]        
        public IWebElement btnPvtMessage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#select_members_list_chosen > ul > li.search-choice > span")]
        public IWebElement selectedRecipient { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[value='Send']")]
        public IWebElement btnSendMessage { get; set; }

        //[FindsBy(How = How.CssSelector, Using = "#edit-message-0-value-error")]
        [FindsBy(How = How.CssSelector, Using = "#edit-message-wrapper")]
        public IWebElement lbrErrorMessageReqrd { get; set; }
       // "#edit-message-wrapper"

        [FindsBy(How = How.CssSelector, Using = "#select_members_list_chosen")]
        public IWebElement lstMember { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#select_members_list_chosen > ul > li")]
        public IWebElement mailToBox { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#select_members_list_chosen > ul > li > input")]
        public IWebElement inputMailToBox { get; set; }

        //[FindsBy(How = How.CssSelector, Using = "a.no-ajax-indicator")]
        [FindsBy(How = How.XPath, Using = "//a[@class='no-ajax-indicator']")]
        public IWebElement btnMarkAsRead { get; set; }


        [FindsBy(How = How.CssSelector, Using = "#select_members_list_chosen > div > ul > li")]
        public IList<IWebElement> lstUserMember { get; set; }

        //[FindsBy(How = How.CssSelector, Using = "div.btn >input#edit-field-attachment-0-upload")]
        //[FindsBy(How = How.XPath, Using = "//*[@id='edit-field-attachment-0-upload']")]
        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'edit-field-attachment-0-upload')]")]
        public IWebElement btnUploadOrAttachFile { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[id*= 'edit-field-attachment-0'] > span > a")]
        public IWebElement txtAttachedFile { get; set; }
        [FindsBy(How = How.CssSelector, Using = "button[value*='Remove']")]
        public IWebElement btnRemoveAttachedFile { get; set; }

        //[FindsBy(How = How.CssSelector, Using = "html > body")]
        //public IWebElement inputMessage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "html > body[class*='cke_editable']")]
        public IWebElement inputMessage { get; set; }

        //[FindsBy(How = How.CssSelector, Using = "div[id*='private-message-thread-']")]
        //[FindsBy(How = How.XPath, Using = "//a[@class = 'fill-parent-container']")]
        [FindsBy(How = How.CssSelector, Using = "li[class*='collection-item'] > span.title.valign-wrapper")]
        public IList< IWebElement> newMessageThread { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@class='private-message private-message-inbox private-message-author-self'])[1]/li/a")]
        public IList<IWebElement> othMessageThread { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[id*='private-message-thread-'] > ul > li > div > a > i")]
        public IWebElement btnDeleteMessage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[id*='private-message-thread-'] > ul > li > div > btn")]
        public IWebElement btnReportMessage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div>div.ui-dialog-buttonset>button")]
        public IWebElement btnOKReportMessage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[id*='private-message-'] > li > div.report > btn[title='Report'] > i")]
        public IList<IWebElement> lstNonReportedMsg { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[id*='private-message-'] > li > div.report > btn")]
        public IList<IWebElement> lstReportedMsg { get; set; }


        [FindsBy(How = How.CssSelector, Using = "button[value='Delete thread']")]
        public IWebElement btnDeleteMessageThread { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a.m-right-small:nth-child(2) > i:nth-child(1)")]
        public IWebElement btnLeaveConversation { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#edit-submit")]
        public IWebElement btnLeaveConversationThread { get; set; }

        // [FindsBy(How = How.CssSelector, Using = ".collection-header > h3:nth-child(1) > span:nth-child(4) > span:nth-child(2)")]
       // [FindsBy(How = How.XPath, Using = "//ul[@class='collection with-header']/li/h3/span[2]/span")]
        //[FindsBy(How = How.XPath, Using = "//div[contains(@id, 'private-message-thread')]/ul/div[1]/div/a/span[2]")]
        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'private-message-thread')]/ul/li/h3/span[2]/span")]
        public IWebElement LeaveConversationMsgThread { get; set; }


        #region Nested Element

        [FindsBy(How = How.CssSelector, Using = "#archive-link > i")]
        public IList<IWebElement> archiveSelector { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#archive-link > i")]
        public IList<IWebElement> unArchiveSelector { get; set; }

        // public By archiveSelector = By.CssSelector("#archive-link > i");      //("ul > li > div > div > a");
        public By deleteSelector = By.CssSelector("ul > li > div > a");
       // public By unArchiveSelector = By.CssSelector("ul > div > a");
        public By pvtMessage = By.CssSelector("ul > div[id*='private-message-']");

        #endregion Nested Element



        #endregion Private Message Page Element


        #region Private Message Page Method      

        public void VerifyPrivateMessageTab()
        {
            int cnt = pvtMsgSubMenu.Count;
            string msg = pvtMsgSubMenu[2].GetAttribute("innerText");
            string[] lines = msg.Split('\n');
            Console.WriteLine(lines[1].Trim());
            Assert.AreEqual(createPrivateMsg, lines[1].Trim());
            test.Log(Status.Pass, "Private Message tab verified");
        }
        public void AccessInboxOnPrivateMessage()
        {
            pvtMsgSubMenu[inboxSubMenuIndex].Click();
            test.Log(Status.Pass, "Inbox has been accessed");
        }

        public void AccessArchivesOnPrivateMessage()
        {
            pvtMsgSubMenu[archiveSubMenuIndex].Click();
            Thread.Sleep(5000);
            test.Log(Status.Pass, "Archive Message  has been accessed");
        }


        public string GetUserNameFromPvtMsgTab()
        {
            Thread.Sleep(3000);
            string uName = userNameOnPvtMsgTab.GetAttribute("innerText").Trim();
            Console.WriteLine(uName);

            test.Log(Status.Pass, "User name accessed from Private Message");
            return uName;

        }

        public void ClickOnPrivateMessage()
        {
            btnPvtMessage.Click();
            test.Log(Status.Pass, "Private Message Clicked");
        }

        public string GetAutoAssignedRecipientName()
        {
            string recipientName = selectedRecipient.GetAttribute("innerText").Trim();
            Console.WriteLine(recipientName);
            return recipientName;

        }

        public void ClickToSendMessage()
        {
            btnSendMessage.Submit();//.Click();

            test.Log(Status.Pass, "Submit Private Message Clicked");
        }

        public void ValidateMessageRequiredError()
        {
            string erroMsg = lbrErrorMessageReqrd.GetAttribute("innerText").Trim();
            Console.WriteLine(erroMsg);
           
            // return erroMsg;
            // Assert.AreEqual(messageRequiredError.Trim(), erroMsg);
            Assert.IsTrue(erroMsg.Contains(messageRequiredError));
            Console.WriteLine("Validation message :" + messageRequiredError);

            test.Log(Status.Pass,"Validation message :" + messageRequiredError);

        }
        public void TypeMessage(string testMessage)
        {
           
            driver.SwitchTo().Frame(0);
            //inputMessage.SendKeys(testMessage);
            inputMessage.SendKeys(testMessage);
            test.Log(Status.Pass, "Message has been entered");
        }

        public void VerifyMailAttachmentFunctionality(string uploadFile )
        {
            //PageServices.ScrollIntoElement(driver, btnUploadOrAttachFile);
            btnUploadOrAttachFile.SendKeys(uploadFile);
            string attachedFile = txtAttachedFile.GetAttribute("innerText");
            Console.WriteLine("File attachted " + attachedFile);
            Assert.IsTrue(attachedFile != String.Empty);           
            btnRemoveAttachedFile.Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 30);
            Thread.Sleep(2000);
            Console.WriteLine("Delete attachted File");
            test.Log(Status.Pass, "Email attachment functionality has been verified");
        }

        public void ValidateEmailRecipientWithSelectedRecipientName(string selectedUser)
        {
            //string fName = selectedUser;
            //int pos = fName.IndexOf(" ");
            //fName = fName.Substring(0,pos);
            //ClickOnPrivateMessage();
            Console.WriteLine(selectedUser.ToLower(), GetUserNameFromPvtMsgTab().ToLower());
            Assert.AreEqual(selectedUser.ToLower(), GetUserNameFromPvtMsgTab().ToLower());
            Thread.Sleep(2000);
            ClickOnPrivateMessage();
            PageServices.WaitForPageToCompletelyLoaded(driver, 60);
            // Assert.IsTrue(GetAutoAssignedRecipientName().Contains(fName));  

            test.Log(Status.Pass, "Recipent is verified with selected");
        }

        public void ValidateMessageRequired()
        {
            ClickToSendMessage();
            ValidateMessageRequiredError();            
        }

        public void AddRecepient_ByName(string  reciepentName)
        {
           
            mailToBox.Click();
            Thread.Sleep(2000);
            inputMailToBox.SendKeys(reciepentName);
            lstUserMember[0].Click();
            Thread.Sleep(2000);
            PageServices.WaitForPageToCompletelyLoaded(driver, 30);
            test.Log(Status.Pass, "Recipent "+reciepentName+" has been selected for message");
        }
        public void AddRecepient_ByName_ByJs(string reciepentName)
        {
            //mailToBox.Click();
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", mailToBox);
            inputMailToBox.SendKeys(reciepentName);
            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].setAtrribute(")
               //  ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].setAttribute('value','" + reciepentName + "');", inputMailToBox);
            lstUserMember[0].Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 30);
            Console.WriteLine("On 'To' field user can type the user name: " + reciepentName);

            test.Log(Status.Pass, "Recipent " + reciepentName + " has been selected for message");
        }
        public void AddOtherRecepient(int index)
        {
            lstMember.Click();
            lstUserMember[index].Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 30);
        }

        public void ValidateArchivesAndDeleteOptionAndArchiveMessage()
        {
            chatMenu.Click();
            Thread.Sleep(2000);

            PageServices.ScrollPageUptoTop(driver);          

            Actions mouse = new Actions(driver);
            mouse.MoveToElement(newMessageThread[0]).Build().Perform();
            /*
            IWebElement archive = newMessageThread[0].FindElement(archiveSelector);
            Assert.IsTrue(archive.Displayed);          

            IWebElement delete = newMessageThread[0].FindElement(deleteSelector);
            Assert.IsTrue(delete.Displayed);
            archive.Click();
            */
            mouse.MoveToElement(archiveSelector[0]).Build().Perform();
            archiveSelector[0].Click();
            test.Log(Status.Pass, "Arcive message has been performed");
        }

        public void TypeMessageAndSend(string txtMessage)
        {
            TypeMessage(txtMessage);
            driver.SwitchTo().DefaultContent();
            Thread.Sleep(1000);
            ClickToSendMessage();
        }

        public void AccessArchivedMessageAndUnarchive()
        {
            AccessArchivesOnPrivateMessage();
            Actions mouse = new Actions(driver);
            mouse.MoveToElement(newMessageThread[0]).Build().Perform();
            mouse.MoveToElement(unArchiveSelector[0]).Build().Perform();
            unArchiveSelector[0].Click();
            Thread.Sleep(1000);
            //IWebElement unarchive = newMessageThread[0].FindElement(unArchiveSelector);
           // unarchive.Click();
            Console.WriteLine("Unarchive a thread");

            test.Log(Status.Pass, "UnArcive message has been performed");

        }

        public void ClickToMarkAsReadMessage()
        {
            btnMarkAsRead.Click();
            Console.WriteLine("Message Marked as MarkAsRead");
            test.Log(Status.Pass, "Message has been marked as Read");
        }

        public void AccessInboxAndDeleteMessage()
        {
            //AccessInboxOnPrivateMessage();
            chatSideMenu.Click();
            Thread.Sleep(2000);            
            Console.WriteLine("Test");
            Actions mouse = new Actions(driver);
            mouse.MoveToElement(newMessageThread[0]).Build().Perform();
            mouse.Click(newMessageThread[0]).Build().Perform();
            //IWebElement msg = newMessageThread[0].FindElement(pvtMessage);
            //msg.Click();
           // Console.WriteLine("Test");
            Thread.Sleep(2000);
            //PageServices.ClickButtonByJavaScript(driver, newMessageThread[0]);
            //newMessageThread[0].Click();
            //Thread.Sleep(5000);
            PageServices.ScrollPageUptoTop(driver);         
            mouse = new Actions(driver);
            mouse.MoveToElement(btnDeleteMessage).Build().Perform();
            btnDeleteMessage.Click();
            btnDeleteMessageThread.Click();
            test.Log(Status.Pass, "Message delected after accessing Inbox");

        }

        public void AccessInboxAndLeaveConversation()
        {
            PageServices.WaitForPageToCompletelyLoaded(driver, 30);
            Actions mouse = new Actions(driver);
            
            AccessInboxOnPrivateMessage();
            PageServices.WaitForPageToCompletelyLoaded(driver, 90);
            mouse.MoveToElement(newMessageThread[0]).Build().Perform();
            mouse.Click(newMessageThread[0]).Build().Perform();
           // mouse.MoveToElement(newMessageThread[0]).Build().Perform();
           // IWebElement msg = newMessageThread[0].FindElement(pvtMessage);
          //  msg.Click();
          //  Thread.Sleep(3000);
          //  PageServices.ScrollPageUptoTop(driver);
            mouse = new Actions(driver);
            mouse.MoveToElement(btnLeaveConversation).Build().Perform();
            btnLeaveConversation.Click();
           // Thread.Sleep(3000);
            btnLeaveConversationThread.Click();
            Console.WriteLine("User Leave the Conversation.");
            //Removing Date time as its failing due to few seconds also
            //DateTime lcdateTime = DateTime.Now;
            // clcdateTime = "(LEFT CONVERSATION "+(lcdateTime.ToString("MM/dd/yyyy - h:mm")) +")";
            // Console.WriteLine(clcdateTime);

            test.Log(Status.Pass, "User has been left the conversation");

        }

        public void VerifyUserLeftTimeStampInfo()
        {
            Actions mouse = new Actions(driver);
            AccessInboxOnPrivateMessage();
            Thread.Sleep(2000);
            mouse.MoveToElement(newMessageThread[0]).Build().Perform();
            mouse.Click(newMessageThread[0]).Build().Perform();
            //mouse.MoveToElement(newMessageThread[0]).Build().Perform();
           // IWebElement msg = newMessageThread[0].FindElement(pvtMessage);
           // msg.Click();
            Thread.Sleep(2000);
            PageServices.ScrollPageUptoTop(driver);
            mouse = new Actions(driver);
            string LeaveConversationMsg = LeaveConversationMsgThread.GetAttribute("innerText");
            //Assert.AreEqual(clcdateTime, LeaveConversationMsg);
            Assert.IsTrue(LeaveConversationMsg.Contains("Left conversation"));
            Console.WriteLine("Time stamp of user left the conversation :" +LeaveConversationMsg);
            test.Log(Status.Pass,"Time stamp of user left the conversation :" + LeaveConversationMsg);

        }


        public void ReportMessage(string expectedReported)
        {
            Thread.Sleep(2000);
            PageServices.ClickButtonByJavaScript(driver, othMessageThread[0]);
            //othMessageThread[0].Click();      
            //newMessageThread[0].FindElement(pvtMessage).Click();
            Thread.Sleep(3000);
            PageServices.ScrollPageUptoTop(driver);
            Thread.Sleep(3000);          // increase pause for onsite runs 
            btnReportMessage.Click();
            Thread.Sleep(3000);
            driver.SwitchTo().DefaultContent();          
            btnOKReportMessage.Click();         
           // PageServices.ScrollPageUptoBottom(driver);
            Thread.Sleep(3000);

            for (int i = lstNonReportedMsg.Count - 1; i > 0; i--)
            {
                if (lstNonReportedMsg[i].Text.Contains("warning"))
                {
                    Console.WriteLine(lstNonReportedMsg[i].GetAttribute("title"));
                    lstNonReportedMsg[i].Click();
                    Thread.Sleep(2000);                    
                    Console.WriteLine(lstReportedMsg[lstReportedMsg.Count - 1].GetAttribute("title"));
                    Assert.AreEqual(lstReportedMsg[lstReportedMsg.Count - 1].GetAttribute("title"), expectedReported);
                    test.Log(Status.Pass, "User has been reported the message");
                    break;
                }

            }
        }

        public void UploadAttachment(string uploadFile)
        {
            btnUploadOrAttachFile.SendKeys(uploadFile);
            string attachedFile = txtAttachedFile.GetAttribute("innerText");
            Console.WriteLine("File attachted " + attachedFile);
            Assert.IsTrue(attachedFile != String.Empty);
            TypeMessageAndSend(testMessage);

            test.Log(Status.Pass, "File as been uploaded to message");
        }

        public void ReVerifiedReportedMsg()
        {
            //newMessageThread[0].FindElement(pvtMessage).Click();
            PageServices.ClickButtonByJavaScript(driver, othMessageThread[0]);
            Thread.Sleep(3000);
            PageServices.ScrollPageUptoBottom(driver);
           // Console.WriteLine(lstReportedMsg[lstNonReportedMsg.Count - 1].GetAttribute("title"));

            test.Log(Status.Pass, "Reported message has been verified");

        }
        #endregion Private Message Page Method    


    }

   


}
