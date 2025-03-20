using NUnit.Framework;
using OpenQA.Selenium;
using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using System.Threading;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;
using SeleniumExtras;
using System.Collections.Generic;
using OpenQA.Selenium.Remote;
using NUnit.Framework.Interfaces;

namespace Commons_Automation
{

    //TestFixture("chrome")]
    public class CommonsTest:MainSetup
    {
                       

        [Test, Category("LoginTest")]
      //  [Ignore("SSO is not setup")]
        public void SSO_Login()
        {
            //string expectedGroupText = "My groups";
            loginPage.Login(commonsAppURL, true);

           // Assert.AreEqual(expectedGroupText, loginPage.MyGroupText());

           // Assert.IsTrue(loginPage.MyGroupText().Contains(expectedGroupText));
            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");


        }

        [Test, Category("LoginTest")]
        public void Direct_Login()
        {

            loginPage.Login(commonsAppURL, false);
            // test.Log(test.Status, "User has been logged In");
            userInfo.GetUserName();
            string uName = userInfo.GetUserName();
            Console.WriteLine(uName);
            PageServices.WaitForPageToCompletelyLoaded(driver, 90);
            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");


        }


        [Test, Category("LoginTest")]
        public void DirectLink_Login()
        {

           // string expectedGroupText = "My groups\r\narrow_drop_down";        

           // string expectedGroupText = "My groups";        

                      
            driver.Navigate().GoToUrl(directLinkUrl);
            loginPage.DirectLinkLogin(ssoUserName, ssoPassword);
           // Assert.AreEqual(expectedGroupText, loginPage.MyGroupText());
            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");
        }

        [Test, Category("LoginTest")]
       //[Ignore("Its only used to verify outlook login, so no need with Commons")]
        public void OutLook_Login()
        {

            driver.Navigate().GoToUrl(outlookURL + MentorBetaFolder);
            outlook.LoginToO365WebMail(o365UserName, o365UserPassword);
            Thread.Sleep(2000);
           
        }

        [Test, Category("LoginTest")]
       // [Ignore("SSO Not Setup")]
        public void SSO_InvalidLogin()
        {

            expectedError = "Incorrect user ID or password. Type the correct user ID and password, and try again.";
            //expectedError = "Enter your user ID in the format \"domain\\user\" or \"user@domain\".";


          
            Console.WriteLine(invalidUser);
            driver.Navigate().GoToUrl(commonsAppURL);
            loginPage.EnteruserName(ssoUserName);
            loginPage.ClicknextButton();
            loginPage.ADFS_SSO_Login(invalidUser, inValidPassword);
            Console.WriteLine(expectedError);
            Console.WriteLine(loginPage.invalidUserError.Text);
            test.Log(Status.Info,loginPage.invalidUserError.Text);
            Assert.AreEqual(expectedError, loginPage.invalidUserError.Text);
            test.Log(Status.Pass, "Test case has been completed");



        }

        [Test, Category("LoginTest")]
        public void Direct_InvalidLogin()
        {
            expectedError = "Unrecognized username or password. Forgot your password?";
            string expectedErrorUsrNm = "Username or email not recognized, please reenter or contact the Service Desk.";
            string expectedErrorUsrPsw = "Password incorrect, please reenter password or click on Reset Password.";
            string ServiceDeskLink = "Service Desk";


            Console.WriteLine(invalidUser);
            driver.Navigate().GoToUrl(commonsAppURL);
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);

            //Invalid UserName Test
            loginPage.EnteruserName(invalidUser);
            loginPage.ClicknextButton();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            Console.WriteLine(loginPage.invalidDirectLoginError.Text);
            Assert.AreEqual(expectedErrorUsrNm, loginPage.invalidDirectLoginError.Text);
            Assert.AreEqual(ServiceDeskLink, loginPage.serviceDeskLink.Text);
            Console.WriteLine("Service Desk Link is available");
            loginPage.userNameField.Clear();
            Thread.Sleep(1000);
            //Invalid Password Test
            loginPage.Direct_Login(nonSSOUserName, inValidPassword, commonsAppURL);
            Console.WriteLine(loginPage.invalidDirectLoginError.Text);
            test.Log(Status.Info,loginPage.invalidDirectLoginError.Text);
            Assert.AreEqual(expectedErrorUsrPsw, loginPage.invalidDirectLoginError.Text);
            test.Log(Status.Pass, "Test case has been completed");





        }
        //Phase 1 Additional Feature.
        [Test, Category("ChangePassword_NonSSOUser")]
        public void ChangePassword_NonSSOUser()
        {

            string user = "qatestuser";
            string existedPassword = "Password0!";
            string newPassword = "Password1!";

            //Login with Old Password
            Console.WriteLine("Login with Old Password");
            // driver.Navigate().GoToUrl(commonsAppURL);
            loginPage.Direct_Login(user, existedPassword, commonsAppURL);
         
            Console.WriteLine(user + " logged in");

            Console.WriteLine("Change Password");
            //Change Password
            userAcc.ChangePassword(existedPassword, newPassword);
            userInfo.Logout();



            //Re-Login with updated new Password.
            Console.WriteLine("Re-Login with updated Password.");
          
            loginPage.Direct_Login(user, newPassword, commonsAppURL);

            //Revert back to Old Password, so existed user can use the old one.
            Console.WriteLine("Revert back to Old Password, so existed user can use the old one");


            userAcc.ChangePassword(newPassword, existedPassword);
            userInfo.Logout();

            // Again Re-Login with Old Password to make sure password reverted back. 
            Console.WriteLine("Again Re-Login with Old Password to make sure password reverted back.");
            loginPage.Direct_Login(user, existedPassword, commonsAppURL);
            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");


        }


        [Test, Category("HelpMenu")]
        public void VerifyHelpMenu()
        {

            // driver.Navigate().GoToUrl(commonsAppURL);
            //loginPage.SSO_Login(ssoUserName, ssoPassword);
            //Console.WriteLine(ssoUserName + " logged in");
            loginPage.Login(commonsAppURL, false);

            personalCommons.VerifyHelpSubMenus();
            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");


        }


        [Test, Category("AlumniVerification")]
        public void AlumniOptIn()
        {

            //driver.Navigate().GoToUrl(commonsAppURL);
            loginPage.Login(commonsAppURL, false);
            

            //notificationSettings.AssignAlumniRole();
            notificationSettings.MasqueradeAlumni();
            userInfo.AccessAccountMenu();
            userInfo.AccessUserAccountMenu(userInfo.membershipDirSettingsMenu);
            //personalCommons.VerifyAlumniTour(); //Alumni Tour logic would work at Masquerading. In Future we will update the logic.

            //driver.Navigate().GoToUrl(alumniOptInUrl);
            //personalCommons.VerifyAlumniOptin(); 
            Thread.Sleep(1000);
            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");

        }

        [Test, Category("AlumniVerification")]
        public void AlumniPlacards()
        {

            //driver.Navigate().GoToUrl(commonsAppURL);
            //loginPage.SSO_Login(ssoUserName, ssoPassword);
            //Console.WriteLine(ssoUserName + " logged in");

            loginPage.Login(commonsAppURL, false);
           // 

            notificationSettings.MasqueradeAlumni();
            userInfo.AccessAccountMenu();
            userInfo.AccessUserAccountMenu(userInfo.membershipDirSettingsMenu);
            notificationSettings.AssignAlumniDirSetting();

            personalCommons.VerifyAlumniCardSelected(); //Alumni Card selected
            notificationSettings.MembershipDir();
            //personalCommons.OpenDir("ALL");
            personalCommons.SearchAlumni("best");
            personalCommons.VerifyPlacardInfo();
            Thread.Sleep(1000);
            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");
        }

        [Test, Category("AlumniVerification")]
        public void AlumniWelcometour()
        {
            try
            {
               
                loginPage.Login(commonsAppURL, false);
                Console.WriteLine(nonSSOUserName + " logged in");               
                notificationSettings.MasqueradeAlumnidata();
                userInfo.AccessAccountMenu();               
                personalCommons.VerifyAlumniWelTour();              
                Thread.Sleep(1000);
                userInfo.Logout();


            }
            catch (Exception ex)
            {
                ss = ((ITakesScreenshot)driver).GetScreenshot();
                path = errorPath + TestContext.CurrentContext.Test.MethodName + "_" + environmentSetup + "_" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".png";
                ss.SaveAsFile(path);
                TestContext.AddTestAttachment(path);
                test.Fail(ex.StackTrace);
                ErrorLog.SaveExeptionToLog(ex, TestContext.CurrentContext.Test.MethodName + "_" + environmentSetup, errorPath + TestContext.CurrentContext.Test.MethodName + "_" + environmentSetup + "_" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".xml");

            }

        }
        [Test, Category("AlumniVerification")]
        public void AlumniSSOLoginAccess()
        {
            try
            {
                
                loginPage.Login(commonsAppURL, false);
                Console.WriteLine(nonSSOUserName + " logged in");                             
                notificationSettings.MasqueradeAlumnidata();
                userInfo.AccessAccountMenu();
                Thread.Sleep(1000);
                userInfo.Logout();


            }
            catch (Exception ex)
            {
                ss = ((ITakesScreenshot)driver).GetScreenshot();
                path = errorPath + TestContext.CurrentContext.Test.MethodName + "_" + environmentSetup + "_" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".png";
                ss.SaveAsFile(path);
                TestContext.AddTestAttachment(path);
                test.Fail(ex.StackTrace);
                ErrorLog.SaveExeptionToLog(ex, TestContext.CurrentContext.Test.MethodName + "_" + environmentSetup, errorPath + TestContext.CurrentContext.Test.MethodName + "_" + environmentSetup + "_" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".xml");

            }

        }



        [Test, Category("AccountSettings")]
        public void VerifyNotificationsSettings()
        {



            // driver.Navigate().GoToUrl(commonsAppURL);
            //loginPage.SSO_Login(ssoUserName, ssoPassword);
            //Console.WriteLine(ssoUserName + " logged in");
            loginPage.Login(commonsAppURL, false);
            
            userInfo.AccessAccountMenu();
            //userInfo.AccessUserAccountMenu(userInfo.accountSubMenu);
            Console.WriteLine("********* Verify Notification Settings *******************");
            userInfo.AccessUserAccountMenu(userInfo.notificationSettingsMenu);
            Console.WriteLine("********* Verify Email Notification Settings *******************");
            notificationSettings.SetEmailFrequencyAndVerify(notificationSettings.immediateFrequency);

            Console.WriteLine("********* Verify Activity Notification Settings *******************");
            notificationSettings.VerifyActivityNotificationSetting();
            Console.WriteLine("********* Verify Prvate Message Notification Settings *******************");
            notificationSettings.VerifyPrivateFrequencySettings(notificationSettings.weeklyFrequency);
            Console.WriteLine("********* Verify Tagging Notification Settings *******************");
            notificationSettings.VerifyTagsFrequencySettings(notificationSettings.immediateFrequency);
            notificationSettings.VerifySaveNotificationMessage();
            userInfo.ClickOnUserMenu();
            userInfo.ClickOnSubMenu(userInfo.logoutSubMenu);


        }

        [Test, Category("PersonalCommons")]
        public void PersonalCommons()
        {

            // driver.Navigate().GoToUrl(commonsAppURL);
            //loginPage.SSO_Login(ssoUserName, ssoPassword);
            //Console.WriteLine(ssoUserName + " logged in");
            loginPage.Login(commonsAppURL, false);           

            grpActivity.VerifyFollowUnfollowGroupActivity();
            grpActivity.VerifyCommentCounts();
            personalCommons.VerifyUserNameonPersonalCommons();            
            personalCommons.VerifyPrivateInbox();            
            personalCommons.VerifyMyInvitationOption();           
            //personalCommons.VerifyPostContentForGroupFromSideBar(1); //Sidebar has been removed from Pesonal Commons
            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");




        }
        [Test, Category("PersonalCommons")]
        public void LandingPageActivityFeeds()
        {

            //driver.Navigate().GoToUrl(commonsAppURL);
            //loginPage.SSO_Login(ssoUserName, ssoPassword);
            //Console.WriteLine(ssoUserName + " logged in");
            loginPage.Login(commonsAppURL, true);


            grpActivity.ActivityStream();//.LandingPage_ActivityFeeds_FilterOption();
            grpActivity.VerifyFollowUnfollowGroupActivity();//.LandingPage_ActivityFeeds_FollowLink();
            grpActivity.VerifyCommentCounts();//.LandingPage_ActivityFeeds_CommentCountLink();
            //personalCommons.LandingPageLeftPane();  // This section has been removed now.
            grpActivity.Tag_Feature_at_ActivityFeeds(cmGrps.ConversationGroupName, action, "Test", uploadFile);
            grpActivity.LandingPage_School_PlaCard(uploadFile, DescriptionText, TitleText);
            Console.WriteLine("Completed execution");
            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");



        }



        //Phase 8
        [Test, Category("PrivateMessage")]

        public void PrivateMessage()
        {

            // driver.Navigate().GoToUrl(commonsAppURL);
            // loginPage.Direct_Login(nonSSOUserName, nonSSOPassword);
            //loginPage.SSO_Login(ssoUserName, ssoPassword);
            //Console.WriteLine(ssoUserName + " logged in");
            loginPage.Login(commonsAppURL, true);            
            userInfo.GetUserName();
            string uName = userInfo.GetUserName();
            //string uName = userInfo.loggedusrName.Text;
            Console.WriteLine(uName);
            pvtMsg.chatMenu.Click();            
            pvtMsg.VerifyPrivateMessageTab();
            personalCommons.ClickOnPersonalCommons();

            //Get User name from top most activity
            string userNameOnActivity = grpActivity.ClickOnUserNameOnGroupActivityAndGetName(uName);
            // Verify User name is same in To Field with  
            Console.WriteLine("From User profile click on Private message, message shall auto assign to user: " + userNameOnActivity);
            pvtMsg.ValidateEmailRecipientWithSelectedRecipientName(userNameOnActivity.ToLower());
            pvtMsg.ValidateMessageRequired();
            pvtMsg.AddRecepient_ByName_ByJs("Psaxena Admin");
            // pvtMsg.AddRecepient_ByName("Priya Narahari");
            pvtMsg.VerifyMailAttachmentFunctionality(uploadFile);
            //pvtMsg.TypeMessageAndSend();
            pvtMsg.TypeMessageAndSend(pvtMsg.testMessage);
            Console.WriteLine("Delete and archive a thread");
            pvtMsg.ValidateArchivesAndDeleteOptionAndArchiveMessage();
            pvtMsg.AccessArchivedMessageAndUnarchive();
            pvtMsg.AccessInboxAndDeleteMessage();
            //userInfo.ClickOnUserMenu();
            //userInfo.ClickOnSubMenu(userInfo.logoutSubMenu);
            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");
        }

        //Phase 8 Additional Functionality 
        [Test, Category("PrivateMessage")]
        public void PrivateMessage__SendAndRecieve()
        {
            string recipientName = string.Empty;// = "mdrew admin";


            if (environmentSetup == "QA1" )
            {
                // recipientName = "Matt Drew";
                recipientName = "vsinha admin"; //"Anitha Malathkar (Admin)";
            }

            if (environmentSetup == "AWS")
            {
                // recipientName = "Matt Drew";
                recipientName = "vsinhaadmin";    //"Anitha Admin";
            }

            if (environmentSetup == "QA2")
            {
                //recipientName = "Matt admin";
                recipientName = "vsinhaadmin";  //"Anitha Admin";
            }
            else if (environmentSetup == "UAT")
            {
                recipientName = "vsinhaadmin";      // "Anitha Admin"; //"Matthew Drew Admin";
            }


            //Login with One user  and send a private Message.

            Console.WriteLine("Login with One user  and send a private Message.");
            // driver.Navigate().GoToUrl(commonsAppURL);
            //loginPage.SSO_Login(ssoUserName, ssoPassword);
            //Console.WriteLine(ssoUserName + " logged in");
            loginPage.Login(commonsAppURL, true);
            //userInfo.GetUserName();
            string uName = userInfo.GetUserName();
            Console.WriteLine(uName);
            pvtMsg.chatMenu.Click();
            pvtMsg.VerifyPrivateMessageTab();
            pvtMsg.pvtMsgSubMenu[2].Click();
            pvtMsg.AddRecepient_ByName(recipientName);
            pvtMsg.TypeMessageAndSend(pvtMsg.testMessage);
            userInfo.Logout();

            // Now Login as Recipient  User and Verify the Message.

            Console.WriteLine("Now Login as Recipient User and Very the Message");
            loginPage.Login(commonsAppURL, false);
           // 
            Console.WriteLine(uName);
            pvtMsg.chatMenu.Click();
            pvtMsg.VerifyPrivateMessageTab();
            pvtMsg.ClickToMarkAsReadMessage();
            pvtMsg.AccessInboxAndDeleteMessage();
            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");
        }



        [Test, Category("PrivateMessage")]

        public void Report_Messages()
        {
            string txtMessage = string.Concat(pvtMsg.testMessage, "Testing");
            //string recipientName = string.Empty;

            if (environmentSetup == "QA1" )
            {
                recipientName = "Mcurtis Admin"; //"Anitha Malathkar (Admin)";
                recepeintName2 = "vsinhaadmin";
                IIndSOSUser = "vsinhaadmin";
                IIndSSOPassword = "vsinhaadmin";

            }

            if (environmentSetup == "AWS")
            {
                recipientName = "Mary Curtis Admin";        // "Anitha Admin";
                recepeintName2 = "Vsinha Admin";
                IIndSOSUser = "vsinhaadmin";
                IIndSSOPassword = "vsinhaadmin";

            }

            if (environmentSetup == "QA2")
            {
                recipientName = "Mary Curtis Admin";         // "Anitha Admin";
                recepeintName2 = "Vsinha Admin";
                IIndSOSUser = "vsinhaadmin";
                IIndSSOPassword = "vsinhaadmin";


            }
            else if (environmentSetup == "UAT")
            {
                recipientName = "mdrewadmin"; // "Matthew Drew Admin";
                recepeintName2 = "Vsinha Admin";           // "amalathkaradmin";
                IIndSOSUser = "vsinhaadmin";            // "amalathkaradmin";
                IIndSSOPassword = "vsinhaadmin";           // "amalathkaradmin";

            }

            //Login with SSO user  and send a private Message to users.

            Console.WriteLine("********************** Login with SSO user  and send a private Message to users. *******************");
            // driver.Navigate().GoToUrl(commonsAppURL);
            //loginPage.SSO_Login(ssoUserName, ssoPassword);
            //Console.WriteLine(ssoUserName + " logged in");
            loginPage.Login(commonsAppURL, true);
            userInfo.GetUserName();
            string uName = userInfo.GetUserName();
            Console.WriteLine(uName);
            pvtMsg.chatMenu.Click();
            pvtMsg.VerifyPrivateMessageTab();
            pvtMsg.pvtMsgSubMenu[2].Click();
            pvtMsg.AddRecepient_ByName(recipientName);
            pvtMsg.AddRecepient_ByName(recepeintName2);
            pvtMsg.UploadAttachment(uploadFile);
            userInfo.Logout();

            // Now Login as Recipient  User and And Report the Message.

            Console.WriteLine("**************** Now Login as Recipient User and Very the Message ********************");
            loginPage.Login(commonsAppURL, false);
            userInfo.GetUserName();
            string user = userInfo.GetUserName();
            Console.WriteLine(user);            

            PageServices.WaitForPageToCompletelyLoaded(driver, 90);
            pvtMsg.chatMenu.Click();

            PageServices.WaitForPageToCompletelyLoaded(driver, 90);
            pvtMsg.VerifyPrivateMessageTab();

            PageServices.WaitForPageToCompletelyLoaded(driver, 90);
            Console.WriteLine("**************** Report A Message ********************");
            pvtMsg.ReportMessage(expectedReported);
            userInfo.Logout();

            //Login with 2nd User and Report the Message
            Console.WriteLine("**************** Login with 2nd User and Report the Message ********************");
            loginPage.Direct_Login(IIndSOSUser, IIndSSOPassword, commonsAppURL);
            userInfo.GetUserName();
            string user2 = userInfo.GetUserName();
            Console.WriteLine(user2);

            PageServices.WaitForPageToCompletelyLoaded(driver, 90);
            pvtMsg.chatMenu.Click();
            // Thread.Sleep(2000);
            PageServices.WaitForPageToCompletelyLoaded(driver, 90);
            pvtMsg.VerifyPrivateMessageTab();
            //  Thread.Sleep(2000);
            PageServices.WaitForPageToCompletelyLoaded(driver, 90);
            Console.WriteLine("**************** Report A Message ********************");
            pvtMsg.ReportMessage(expectedReported);

            Console.WriteLine("**************** Now Access Outlook and Verify Reported Message ********************");

            driver.Navigate().GoToUrl(outlookURL + MentorBetaFolder);
            outlook.LoginToO365WebMail(o365UserName, o365UserPassword);            
            Thread.Sleep(2000);
            outlook.OpenReportedMessageEmail(user,"reported a Chat.");           

            Console.WriteLine("**************** Now Again Access Commons Application and Re-verify Reported Message ********************");
            driver.Navigate().GoToUrl(commonsAppURL);
            pvtMsg.chatMenu.Click();
            pvtMsg.ReVerifiedReportedMsg();
            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");


        }

        [Test, Category("PrivateMessage")]
        public void PrivateMessage_LeaveConversation()
        {
            string recipientName1 = string.Empty;
            string recipientName2 = "Prashanthi Vatsavai";
            string recipientName3 = "Carl Phillips";
            //recipientName2 = "Katia Nyysti";
            //recipientName3 = "Priya Narahari";


            if (environmentSetup == "QA1")
            {

                // recipientName1 = "Matt admin"; //nonSSOUser
                recipientName1 = "vsinha admin";      //"Anitha Malathkar (Admin)";
                //recipientName2 = "Katia Nyysti";
                //recipientName3 = "Priya Narahari";
            }
            if (environmentSetup == "AWS")
            {
                // recipientName = "Matt Drew";
                recipientName1 = "vsinha admin"; // "Anitha Admin";
            }

            if (environmentSetup == "QA2")
            {
                recipientName1 = "vsinha admin";    //"Anitha Admin"; //nonSSOUser
                                                 //recipientName1 = "Matt Drew";
                                                 //recipientName2 = "Katia Nyysti";
                                                 //recipientName3 = "Priya Narahari";
            }
            if (environmentSetup == "UAT")
            {
                recipientName1 = "vsinha admin";      //"Anitha Admin"; //nonSSOUser
                                                 //recipientName2 = "Katia Nyysti";
                                                 //recipientName3 = "Priya Narahari";
            }


            //Login with One SSO user and send a private Message to multiple users.

           // Console.WriteLine("Login with One user  and send a private Message.");
            // driver.Navigate().GoToUrl(commonsAppURL);
            //loginPage.SSO_Login(ssoUserName, ssoPassword);
            //Console.WriteLine(ssoUserName + " logged in");
            loginPage.Login(commonsAppURL, true);
            userInfo.GetUserName();
            string uName = userInfo.GetUserName();
            Console.WriteLine(uName);
            pvtMsg.chatMenu.Click();
            pvtMsg.VerifyPrivateMessageTab();
            pvtMsg.pvtMsgSubMenu[2].Click();
            PageServices.WaitForPageToCompletelyLoaded(driver, 60);
            Thread.Sleep(5000);
            Console.WriteLine("Add 3 recipient Name in 'To' Field");
            pvtMsg.AddRecepient_ByName(recipientName1);
            pvtMsg.AddRecepient_ByName(recipientName2);
            pvtMsg.AddRecepient_ByName(recipientName3);
            pvtMsg.TypeMessageAndSend(pvtMsg.testMessage);
            userInfo.Logout();

            // Now Login with Recipient1 User and Leave the Conversation.

            Console.WriteLine("Now Login with Recipient1 User and Leave the Conversation");
            loginPage.Login(commonsAppURL, false);
            userInfo.GetUserName();
            string uName1 = userInfo.GetUserName();
            Console.WriteLine(uName1);
            pvtMsg.chatMenu.Click();
            Thread.Sleep(5000);
            pvtMsg.VerifyPrivateMessageTab();
            pvtMsg.ClickToMarkAsReadMessage();
            pvtMsg.AccessInboxAndLeaveConversation();
            userInfo.Logout();

            //Login with First SSO user again and Verify the Time stamp of user left the conversation.

            Console.WriteLine("Login with First SSO user again and Verify the Time stamp of user left the conversation.");
            //driver.Navigate().GoToUrl(commonsAppURL);
            loginPage.Login(commonsAppURL, true);//.SSO_Login(ssoUserName, ssoPassword, commonsAppURL);
            Console.WriteLine(ssoUserName + " logged in");
            PageServices.WaitForPageToCompletelyLoaded(driver, 90);
            userInfo.GetUserName();
            string uName2 = userInfo.GetUserName();
            Console.WriteLine(uName2);
            pvtMsg.chatMenu.Click();
            // Thread.Sleep(2000);
            PageServices.WaitForPageToCompletelyLoaded(driver, 60);
            pvtMsg.VerifyPrivateMessageTab();
            pvtMsg.VerifyUserLeftTimeStampInfo();
            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");


        }

        // Phase 8
        [Test, Category("Search")]
        public void VerifySearchFunctionality()
        {

            // driver.Navigate().GoToUrl(commonsAppURL);
            // loginPage.Direct_Login(nonSSOUserName, nonSSOPassword);
            //loginPage.SSO_Login(ssoUserName, ssoPassword);
            //Console.WriteLine(ssoUserName + " logged in");    
            loginPage.Login(commonsAppURL, false);           
            //Validate with No Result.
            searchPage.NoResultSearch();
            //Validate with Result and Verify Page Navigation.
            searchPage.ExpectedResultSearch(searchPage.expectSearchValue);
            searchPage.ValidatePageNavigationOnSearchPage();
            //Verify Poll Activity on the Search.
            searchPage.PollActSearch();
            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");

        }
        #region ArchiveAlumni
        [Test, Category("Archive_Content")]
        public void Viewing_ArchivedContent()
        {
            loginPage.Login(commonsAppURL, false);
            Thread.Sleep(5000);
            //-------------------------
            userInfo.userName.Click();
            userInfo.userProfile.Click();
            //Post Tab
            Thread.Sleep(5000);
            grpActivity.SelectArchiveFromFilter("Archived");
            Thread.Sleep(2000);           
            grpActivity.PosttabButtonsVerification();
            grpActivity.VerifyBanner();
            //CommentsTab
            userInfo.userName.Click();
            userInfo.userProfile.Click();
            grpActivity.Commentstab();
            userInfo.Logout();

            //---------------------------
        }
        [Test, Category("Archive_Content")]
        public void Viewing_ArchivedCheckbox()
        {

            loginPage.Login(commonsAppURL, false);
            //Edit tab for Archive Checkbox
            Thread.Sleep(5000);
            userInfo.userName.Click();
            userInfo.userProfile.Click();
            //Post Tab
            Thread.Sleep(5000);
            grpActivity.SelectArchiveFromFilter("Archived");
            cmGrps.EditLastPostBtn.Click();
            cmGrps.EditPostLink.Click();
            Thread.Sleep(3000);
            PageServices.ScrollPageUptoBottom(driver);
            Thread.Sleep(3000);
            grpActivity.ArchiveCheckfieldVerifying();

            //Change Archive / Unar hive

            userInfo.userName.Click();
            Thread.Sleep(1000);
            userInfo.userProfile.Click();
            grpActivity.SelectArchiveFromFilter("Archived");
            Thread.Sleep(1000);

            grpActivity.VerifyCommonetAndFollowingOnArchived();

           
            userInfo.Logout();


        }

        [Test, Category("Archive_Content")]
        public void Viewing_ArchivedAlumni()
        {
            //Alumni
            loginPage.Login(commonsAppURL, false);
           
            Thread.Sleep(5000);
            //***Post Tab
            Thread.Sleep(2000);
            notificationSettings.Masqueradestudent(ArchivedAlumniStudent);
            userInfo.userName.Click();
            userInfo.userProfile.Click();
            grpActivity.VerifyCommentsAndFollowingButtons();
            grpActivity.tabCommnets.Click();
            grpActivity.rplbuttonOnCommentsTab();     

            

            
            userInfo.ClickOnUserMenu(); 

            userInfo.ClickOnSubMenu(userInfo.unMasqSubMenu);
            Thread.Sleep(2000);         
           

            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");

        }
        #endregion ArchiveAlumni

        #region Archive Test
        [Test, Category("ProfilePage_Archive_Post")]
        public void ProfilePage_ArchivePost_VerifyArchived()
        {

            loginPage.Login(commonsAppURL, false);
            userInfo.userName.Click();
            Thread.Sleep(5000);
            userInfo.userProfile.Click();
            Thread.Sleep(5000);
            string ActivityName = grpActivity.EditPostAndArchiveInGroup("Conversation", "Unarchived");
            Console.WriteLine(ActivityName);
            test.Log(Status.Info, ActivityName + " has been archived");
            Thread.Sleep(2000);
            grpActivity.VerifyArchived("Conversation", "Archived only", ActivityName);
            grpActivity.VerifyCommonetAndFollowingOnArchived();
            test.Log(Status.Info, " Comments and Following Disabled for " + ActivityName);
            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");

        }

        [Test, Category("ProfilePage_Archive_Post")]
        public void ProfilePage_ArchiveEvent_VerifyArchived()
        {

            loginPage.Login(commonsAppURL, false);
            userInfo.userName.Click();
            Thread.Sleep(5000);
            userInfo.userProfile.Click();
            Thread.Sleep(5000);
            string ActivityName = grpActivity.EditPostAndArchiveInGroup("Event", "Unarchived");
            Console.WriteLine(ActivityName);
            test.Log(Status.Info, ActivityName + " has been archived");
            Thread.Sleep(2000);
            grpActivity.VerifyArchived("Event", "Archived only", ActivityName);
            grpActivity.VerifyCommonetAndFollowingOnArchived();
            test.Log(Status.Info, " Comments and Following Disabled for "+ ActivityName);
            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");

        }
        [Test, Category("ProfilePage_Archive_Post")]
        public void ProfilePage_ArchiveUpload_VerifyArchived()
        {

            loginPage.Login(commonsAppURL, false);
            userInfo.userName.Click();
            Thread.Sleep(5000);
            userInfo.userProfile.Click();
            Thread.Sleep(5000);
            string ActivityName = grpActivity.EditPostAndArchiveInGroup("Upload", "Unarchived");
            Console.WriteLine(ActivityName);
            test.Log(Status.Info, ActivityName + " has been archived");
            Thread.Sleep(2000);
            grpActivity.VerifyArchived("Upload", "Archived only", ActivityName);
            grpActivity.VerifyCommonetAndFollowingOnArchived();
            test.Log(Status.Info, "Comments and Following Disabled for " + ActivityName);
            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");

        }

        [Test, Category("ProfilePage_Archive_Post")]
        public void ProfilePage_ArchiveVideo_VerifyArchived()
        {

            loginPage.Login(commonsAppURL, false);
            userInfo.userName.Click();
            Thread.Sleep(5000);
            userInfo.userProfile.Click();
            Thread.Sleep(5000);
            string ActivityName = grpActivity.EditPostAndArchiveInGroup("Video", "Unarchived");
            Console.WriteLine(ActivityName);
            test.Log(Status.Info, ActivityName + " has been archived");
            Thread.Sleep(2000);
            grpActivity.VerifyArchived("Video", "Archived only", ActivityName);
            grpActivity.VerifyCommonetAndFollowingOnArchived();
            test.Log(Status.Info, " Comments and Following Disabled for " + ActivityName);
            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");

        }

        [Test, Category("Search_Archive_Post")]
        public void Search_ArchiveUpload_VerifyArchived()
        {

            loginPage.Login(commonsAppURL, false);
            userInfo.userName.Click();
            Thread.Sleep(5000);
            userInfo.userProfile.Click();
            Thread.Sleep(5000);
            string ActivityName = grpActivity.EditPostAndArchiveInGroup("Upload", "Unarchived");
            test.Log(Status.Info, ActivityName + " has been archived");
            searchPage.SearchArchivedContent(ActivityName);

            test.Log(Status.Info, " Comments and Following Disabled for " + ActivityName);
            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");

        }

        [Test, Category("Search_Archive_Post")]
        public void Search_ArchiveConversation_VerifyArchived()
        {

            loginPage.Login(commonsAppURL, false);
            userInfo.userName.Click();
            Thread.Sleep(5000);
            userInfo.userProfile.Click();
            Thread.Sleep(5000);
            string ActivityName = grpActivity.EditPostAndArchiveInGroup("Conversation", "Unarchived");
            test.Log(Status.Info, ActivityName + " has been archived");
            searchPage.SearchArchivedContent(ActivityName);
            test.Log(Status.Info, " Comments and Following Disabled for " + ActivityName);
            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");

        }


        [Test, Category("Search_Archive_Post")]
        public void Search_ArchiveEvent_VerifyArchived()
        {

            loginPage.Login(commonsAppURL, false);
            userInfo.userName.Click();
            Thread.Sleep(5000);
            userInfo.userProfile.Click();
            Thread.Sleep(5000);
            string ActivityName = grpActivity.EditPostAndArchiveInGroup("Event", "Unarchived");
            test.Log(Status.Info, ActivityName + " has been archived");
            searchPage.SearchArchivedContent(ActivityName);
            test.Log(Status.Info, " Comments and Following Disabled for " + ActivityName);
            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");

        }

        [Test, Category("Search_Archive_Post")]
        public void Search_ArchiveVideo_VerifyArchived()
        {

            loginPage.Login(commonsAppURL, false);
            userInfo.userName.Click();
            Thread.Sleep(5000);
            userInfo.userProfile.Click();
            Thread.Sleep(5000);
            string ActivityName = grpActivity.EditPostAndArchiveInGroup("Video", "Unarchived");
            test.Log(Status.Info, ActivityName + " has been archived");
            searchPage.SearchArchivedContent(ActivityName);
            test.Log(Status.Info, " Comments and Following Disabled for " + ActivityName);
            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");

        }

        #endregion Archive Test

        #region Group Activity Test
        //Re-orgTest -Madan Joining and Opening Group

        //Phase 2 and Phase 5
        [Test, Category("GroupActivities")]
        public void JoinAndOpenConversationGroup()
        {
            DescriptionText = "QA Testing Description-" + PageServices.Randomizr.RandomString(5);
            TitleText = "QA Testing Title Automation-" + PageServices.Randomizr.RandomString(5);

            //driver.Navigate().GoToUrl(commonsAppURL);
            //  loginPage.SSO_Login(ssoUserName, ssoPassword);
            //Console.WriteLine(ssoUserName + " logged in");
            // loginPage.Direct_Login(nonSSOUserName, nonSSOPassword, commonsAppURL);
            loginPage.Login(commonsAppURL, false);
            cmGrps.JoinAndOpenGroup(cmGrps.ConversationGroupName);
            cmGrps.Leavegroup();
            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");

        }

        [Test, Category("GroupActivities")]
        public void GroupActivities_ConversationGroup()
        {
            DescriptionText = "QA Testing Description-" + PageServices.Randomizr.RandomString(5);
            TitleText = "QA Testing Title Automation-" + PageServices.Randomizr.RandomString(5);

            //driver.Navigate().GoToUrl(commonsAppURL);
            // loginPage.SSO_Login(ssoUserName, ssoPassword);
            //loginPage.Direct_Login(nonSSOUserName, nonSSOPassword);
            // Console.WriteLine(ssoUserName + " logged in");
            //loginPage.Direct_Login(nonSSOUserName, nonSSOPassword, commonsAppURL);
            loginPage.Login(commonsAppURL, false);
            test.Log(test.Status, "User has been logged");
            cmGrps.JoinAndOpenGroup(cmGrps.ConversationGroupName);
            test.Log(test.Status, "Group has been joined");
            grpActivity.AddContentInGroup(DescriptionText, TitleText, uploadFile);
            test.Log(test.Status, "Content Has been posted");
            grpActivity.PostVideo_ConversationGroup(DescriptionText, TitleText, grpActivity.zoomvideoURL);
            test.Log(test.Status, "Zomm Video Has been posted");
            cmGrps.Leavegroup();
            test.Log(test.Status, "Group has been leaved");
            //loginPage.
            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");

        }

        [Test, Category("GroupActivities")]
        public void GroupActivities_EditAndArchiveConversationGroup()
        {
            DescriptionText = "QA Testing Description-" + PageServices.Randomizr.RandomString(5);
            TitleText = "QA Testing Title Automation-" + PageServices.Randomizr.RandomString(5);

            loginPage.Login(commonsAppURL, false);
            userInfo.userName.Click();
            userInfo.userProfile.Click();            
            string ActivityName = grpActivity.EditPostAndArchiveInGroup("Conversation", "Unarchived");
            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");

        }


        [Test, Category("GroupActivities")]
        public void NavigateActivityFeed()
        {
            DescriptionText = "QA Testing Description-" + PageServices.Randomizr.RandomString(5);
            TitleText = "QA Testing Title Automation-" + PageServices.Randomizr.RandomString(5);

            // driver.Navigate().GoToUrl(commonsAppURL);
            // loginPage.SSO_Login(ssoUserName, ssoPassword);
            //loginPage.Direct_Login(nonSSOUserName, nonSSOPassword);
            //Console.WriteLine(ssoUserName + " logged in");

            loginPage.Login(commonsAppURL, true);

            cmGrps.commenton2ndPost();
            myGroups.CommonsHome.Click();
            cmGrps.VerifyNavigate();
            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");

        }

        //Phase 5 Additional Feature 
        //Verify Tagging Feature 
        [Test, Category("GroupActivities")]
        public void VerifyUserTagging()
        {



            //driver.Navigate().GoToUrl(commonsAppURL);
            //loginPage.SSO_Login(ssoUserName, ssoPassword);
            //Console.WriteLine(ssoUserName + " logged in");
            loginPage.Login(commonsAppURL, false);
            cmGrps.JoinAndOpenGroup(cmGrps.ConversationGroupName);

            Console.WriteLine("********** Verify Tagging Functionality for Posts, Comments and Replies  ***********");

            grpActivity.VerifyTaggingFunctionalityOnPost(action, "Test");

            Console.WriteLine("********** Verify Tagging for Events  ***********");

            grpActivity.VerifyTaggingFunctionalityOnEvent(action, "Test");


            Console.WriteLine("********** Verify Tagging for Upload  ***********");
            grpActivity.VerifyTaggingFunctionalityOnUpload(action, uploadFile, "Test");


            Console.WriteLine("********** Verify Tagging for Video  ***********");

            grpActivity.VerifyTaggingFunctionalityForVideo(action);

            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");


        }

        [Test, Category("GroupActivities")]
        public void VerifyUserTagging_WithSpecialCharacters()
        {
            DescriptionText = "QA Testing Description- " + PageServices.Randomizr.RandomString(5) + "\n # ~!#$%^&*()_+{}: ;' < > ? / ] [";
            TitleText = "QA Testing Title Automation-" + PageServices.Randomizr.RandomString(5);


            //driver.Navigate().GoToUrl(commonsAppURL);
            // loginPage.SSO_Login(ssoUserName, ssoPassword,commonsAppURL);
            //Console.WriteLine(ssoUserName + " logged in");
            // loginPage.Direct_Login(nonSSOUserName, nonSSOPassword, commonsAppURL);
            loginPage.Login(commonsAppURL, false);
            cmGrps.JoinAndOpenGroup(cmGrps.ConversationGroupName);

            //Verify Tagging Functionality for Posts, Comments and Replies.
            grpActivity.VerifyTaggingFunctionalityOnPost(action, DescriptionText);

            //Verify Tagging for Events


            grpActivity.VerifyTaggingFunctionalityOnEvent(action, DescriptionText);

            //Verify Tagging for Upload

            grpActivity.VerifyTaggingFunctionalityOnUpload(action, uploadFile, DescriptionText);

            //Verify Tagging for Video.

            grpActivity.VerifyTaggingFunctionalityForVideo(action);

            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");


        }


        [Test, Category("GroupActivities")]
        public void PostLongLentghDesription()
        {
            DescriptionText = "QA Testing Description-" + PageServices.Randomizr.RandomString(250);
            TitleText = "QA Testing Title Automation-" + PageServices.Randomizr.RandomString(7);


            // driver.Navigate().GoToUrl(commonsAppURL);
            loginPage.Login(commonsAppURL, false);
            
            // Click on dots menu
            cmGrps.VerifydiscoverGroups(cmGrps.ConversationGroupName);
            cmGrps.VerifyPrivateGroup(cmGrps.PrivateGroupName);
            cmGrps.JoinConversationGroup(cmGrps.ConversationGroupName);
            cmGrps.OpenJoinedGroup(cmGrps.ConversationGroupName);
            grpActivity.AddContentInGroup(DescriptionText, TitleText, uploadFile);
            cmGrps.Leavegroup();
            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");

        }

        [Test, Category("PollActivity")]
        public void GroupPoll_ConversationGroup()
        {
            //DescriptionText = "QA Testing Poll" + PageServices.Randomizr.RandomString(5);
            select = "Poll test by QA" + PageServices.Randomizr.RandomString(5);
            ans1 = "Blue" + PageServices.Randomizr.RandomString(5);
            ans2 = "Red" + PageServices.Randomizr.RandomString(5);
            ans3 = "Green" + PageServices.Randomizr.RandomString(5);
            ans4 = "Purple" + PageServices.Randomizr.RandomString(5);
            ans5 = "White" + PageServices.Randomizr.RandomString(5);

            loginPage.Login(commonsAppURL, false);
            test.Log(test.Status, "User has been logged");
            cmGrps.JoinAndOpenGroup1(cmGrps.ConversationGroupName);
            test.Log(test.Status, "Group has been joined");
            grpActivity.AddContentInGroupsingleChoicePoll(select, ans1, ans2);
            grpActivity.AddContentInGroupMuiltiChoicePoll(select, ans1, ans2, ans3, ans4, ans5);
            test.Log(test.Status, "Content Has been posted");
            userInfo.Logout();           
            test.Log(Status.Pass, "Test case has been completed");
            Console.WriteLine("Sucessfully Completed");

        }

        #endregion Group Activity Test



        //Phase 3
        [Test, Category("ActivityStream")]
        public void ActivityStream()
        {

            //  test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            // driver.Navigate().GoToUrl(commonsAppURL);
            //loginPage.SSO_Login(ssoUserName, ssoPassword);
           // PageServices.WaitForPageToCompletelyLoaded(driver, 30);
            //Console.WriteLine(ssoUserName + " logged in");
            loginPage.Login(commonsAppURL, true);
            
            grpActivity.ActivityStream();
            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");

        }

        //Phase 5
        [Test, Category("AccountSettings")]
        public void AccountSettings()
        {
           

            // loginPage.SSO_Login(ssoUserName, ssoPassword,commonsAppURL);
            // Console.WriteLine(ssoUserName + " logged in");
            // loginPage.Login(commonsAppURL, false);
            //
            loginPage.Login(commonsAppURL, true);
            userInfo.AccessAccountMenu();
            // userInfo.AccessUserAccountMenu(userInfo.accountSubMenu);
            userAcc.AccountSettings(false);
            userAcc.AccessMembershipDirectorySettings();
            userAcc.MembershipDirectorySetting();
            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");

        }

        //Phase 5
        [Test, Category("User_Information")]
        public void User_Information()
        {

            // driver.Navigate().GoToUrl(commonsAppURL);
            //loginPage.SSO_Login(ssoUserName, ssoPassword);
            //Console.WriteLine(ssoUserName + " logged in");
            loginPage.Login(commonsAppURL, false);
            
            userInfo.UserMenu();
            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");
        }



        //Phase 7

        [Test, Category("EditProfile")]
        public void EditProfile()
        {

            // driver.Navigate().GoToUrl(commonsAppURL);
            //loginPage.SSO_Login(ssoUserName, ssoPassword);
            //Console.WriteLine(ssoUserName + " logged in");
            loginPage.Login(commonsAppURL, true);
            
            Console.WriteLine("********* Verify User Profile Modification *********");
            editProf.UserProfileSettings(uploadProfileImage);
            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");

        }

        //Phase 8
        [Test, Category("DiscoverGroups")]
        public void DiscoverGroups()
        {

            // driver.Navigate().GoToUrl(commonsAppURL);
            // loginPage.Direct_Login(nonSSOUserName, nonSSOPassword);
            // loginPage.SSO_Login(ssoUserName, ssoPassword);
            loginPage.Login(commonsAppURL, false);
            PageServices.WaitForPageToCompletelyLoaded(driver, 160);
            // Console.WriteLine(ssoUserName + " logged in");
            string myGroup = grpActivity.GetMyGroup(loginPage, 0);
            Console.WriteLine(myGroup);
            Console.WriteLine("********* Verify Discover Group Functionality ****************");
            cmGrps.VerifydiscoverGroups(cmGrps.ConversationGroupName);
            discoverGroup.DiscoverGroup_VerifyViewAndJoinAndPrivate_Sorting(discoverGroup.pubicGroup, false);
            discoverGroup.DiscoverGroup_VerifyViewAndJoinAndPrivate_Sorting(discoverGroup.openGroup, false);
            discoverGroup.DiscoverGroup_VerifyViewAndJoinAndPrivate_Sorting(discoverGroup.privateGroup, false);
            driver.Navigate().Refresh();
            Thread.Sleep(5000);
            discoverGroup.DiscoverGroup_VerifyViewAndJoinAndPrivate_Sorting(myGroup, true);
            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");

        }


        //Phase 9
        [Test, Category("MyContentfollowing")]
        public void MyContentAndfollowing()
        {


            // driver.Navigate().GoToUrl(commonsAppURL);
            // loginPage.Direct_Login(nonSSOUserName, nonSSOPassword);
            //loginPage.SSO_Login(ssoUserName, ssoPassword);
            //Console.WriteLine(ssoUserName + " logged in");
            loginPage.Login(commonsAppURL, false);
            
            userGrpContent.MyContent();
            //following method
            userGrpContent.FollowingPage();
            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");


        }

        //Phase 10
        [Test, Category("ConversationGroup")]
        public void ConversationGroup()
        {
            DescriptionText = "QA Testing Description-" + PageServices.Randomizr.RandomString(5);
            TitleText = "QA Testing Title Automation-" + PageServices.Randomizr.RandomString(5);
            // driver.Navigate().GoToUrl(commonsAppURL);
            //loginPage.SSO_Login(ssoUserName, ssoPassword);
            //Console.WriteLine(ssoUserName + " logged in");
            loginPage.Login(commonsAppURL, false);
            
            Console.WriteLine("*********** Verify Coneversation Group Contents ***************");
            conversationGroup.verifyConversationGrpItems();
            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");

        }

        [Test, Category("VerifyMyGroups")]
        public void VerifyMyGroups()
        {

           
            loginPage.Login(commonsAppURL, true);
            
            myGroups.VerifyAlumniGroupAthome();
            myGroups.GotoAllMyGroupspage();
            myGroups.VerifyDefaultGroupAtMyGroups();          
            myGroups.VerifyDefaultGroupAtMyGroups();
            userInfo.AccessAccountMenu();
            myGroups.GotoGroupMembershipPage();
            myGroups.VerifyGroupMemberships();
            myGroups.VerifyGroupMembershipView();
            userInfo.AccessAccountMenu();
            myGroups.GotoGroupMembershipPage();
            myGroups.VerifyGroupMembershipLeaveJoinagain();
            userInfo.AccessAccountMenu();
            myGroups.GotoGroupMembershipPage();
            myGroups.VerifyGroupTerminatedMembershipsList();
            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");



        }
        //Phase 12 Steward Functionality  

        [Test, Category("StewardFunctionality")]
        // [Repeat(2)]
        public void StewardFunctionality()
        {
            DescriptionText = "QA Testing Description-" + PageServices.Randomizr.RandomString(5);// DateTime.Now.ToLongTimeString() ;
            TitleText = "QA Testing Title Automation-" + PageServices.Randomizr.RandomString(5);// DateTime.Now.ToLongTimeString(); ;


            //  driver.Navigate().GoToUrl(commonsAppURL);
            loginPage.Login(commonsAppURL, false);
            string uName = userInfo.GetUserName();
           

            Console.WriteLine("****** Verify Steward Functionality in Community Group **************");

          //  cmGrps.JoinAndOpenGroup(cmGrps.CommunityGroup);

            discoverGroup.DiscoverAndJoinGroup(cmGrps.CommunityGroup);
            cmGrps.OpenJoinedGroup_SetStewardRole(cmGrps.CommunityGroup, uName);
            cmGrps.GroupIcon.Click();
            Thread.Sleep(3000);
            grpActivity.AddContentCommunityGroup_VerifySteward(uploadFile, DescriptionText, TitleText);

            Console.WriteLine("****** Verify Steward Functionality in Conversation Group **************");

            Thread.Sleep(2000);
            personalCommons.ClickOnPersonalCommons();
            discoverGroup.DiscoverAndJoinGroup(cmGrps.ConversationGroupName);
            cmGrps.OpenJoinedGroup_SetStewardRole(cmGrps.ConversationGroupName, uName);
            cmGrps.GroupIcon.Click();
            grpActivity.AddContentConversationGroup_VerifySteward(uploadFile, DescriptionText, TitleText);
            grpActivity.verifyStewardFn();
            driver.Navigate().Refresh();
            searchPage.SearchContentStewardIcon(DescriptionText); //Verify Steward icon and tooltip in search
            userInfo.Logout();                                                   //grpActivity.VerifyStewardOnSearch();
            test.Log(Status.Pass, "Steward Test has been completed");
            Console.WriteLine("Steward Test has been completed");


        }

        //Phase 6 Alumni Icon 
        [Test, Category("AlumniVerification")]

        public void AlumniIcon_WithDifferentRole()
        {

            // driver.Navigate().GoToUrl(commonsAppURL);
            loginPage.Login(commonsAppURL, false);
            
            // Click on dots menu
            Console.WriteLine("********** Assign & Verify Alumni with Student Role***************");
            notificationSettings.AssignAlumni_WithRole("Student");

            userInfo.ClickOnUserMenu();
            userInfo.ClickOnSubMenu(userInfo.unMasqSubMenu);
            Console.WriteLine("********** Assign & Verify Alumni with Faculty Role***************");
            notificationSettings.AssignAlumni_WithRole("Faculty");

            userInfo.ClickOnUserMenu();
            userInfo.ClickOnSubMenu(userInfo.unMasqSubMenu);
            Console.WriteLine("********** Assign & Verify Alumni with Team Member Role***************");
            notificationSettings.AssignAlumni_WithRole("Team");

            userInfo.Logout();          

            test.Log(Status.Pass, "Test case has been completed");
        }


        [Test, Category("GroupActivities")]
        public void GroupInviteFilter()
        {

            //driver.Navigate().GoToUrl(commonsAppURL);
            //loginPage.Direct_Login(nonSSOUserName, nonSSOPassword);                
            //Console.WriteLine(ssoUserName + " logged in");
            loginPage.Login(commonsAppURL, false);
            
            cmGrps.JoinAndOpenGroup(cmGrps.ConversationGroupName);
            personalCommons.ClickOnPersonalCommons();
            cmGrps.OpenJoinedGroup_SetStewardRole(cmGrps.ConversationGroupName, "vsinha admin");
            cmGrps.GroupIcon.Click();
            cmGrps.filterGroupInvite();
            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");

        }

        [Test, Category("GroupActivities")]
        public void PlaycardInfo()
        {
            DescriptionText = "QA Testing Description-" + PageServices.Randomizr.RandomString(5);
            TitleText = "QA Testing Title Automation-" + PageServices.Randomizr.RandomString(5);


            //GroupActivities();

            //driver.Navigate().GoToUrl(commonsAppURL);
            //loginPage.SSO_Login(ssoUserName, ssoPassword);
            //Console.WriteLine(ssoUserName + " logged in");
            loginPage.Login(commonsAppURL, true);


            cmGrps.JoinAndOpenGroup(cmGrps.ConversationGroupName);// ;.DiscoverAndJoinGroup(cmGrps.ConversationGroupName);
           // cmGrps.OpenJoinedGroup(cmGrps.ConversationGroupName);
            cmGrps.GroupIcon.Click();
            grpActivity.AddContent_VerifyPlacardInfo(uploadFile, DescriptionText, TitleText);
            cmGrps.Leavegroup();

            userInfo.ClickOnUserMenu();
            userInfo.ClickOnSubMenu(userInfo.ProfileSubMenu);
            Thread.Sleep(3000);
            notificationSettings.PlaycardInfo();
            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");

        }


        [Test, Category("GroupActivities")]
        public void Verify_WYSIWYG_EmbededImagePost()
        {

            DescriptionText = "QA Testing Description-" + PageServices.Randomizr.RandomString(5) + "\n #Testing<abc \n #QA>bnm \n #TestTest\\asd \n #TestTestTest/fghh \n #Testing.qwe \n #QA,rty \n #Testtest;yui \n #TestTestTest:poi";
            TitleText = "QA Testing Title Automation-" + PageServices.Randomizr.RandomString(5);



            // driver.Navigate().GoToUrl(commonsAppURL);
            // loginPage.SSO_Login(ssoUserName, ssoPassword);
            //loginPage.Direct_Login(nonSSOUserName, nonSSOPassword);
            // Console.WriteLine(ssoUserName + " logged in");
            //
            loginPage.Login(commonsAppURL, false);
            
            loginPage.EnvIndicator();
            Thread.Sleep(1000);
            cmGrps.JoinAndOpenGroup(cmGrps.ConversationGroupName);
            myGroups.CommonsHome.Click();
            cmGrps.WYSIWYGPost(uploadProfileImage, "Graduate Studies Support Center");
            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");

        }

        [Test, Category("GroupActivities")]
        public void VerifyContentTagging_SplChar()
        {

            DescriptionText = "QA Testing Description-" + PageServices.Randomizr.RandomString(5) + "\n #Testing<abc \n #QA>bnm \n #TestTest\\asd \n #TestTestTest/fghh \n #Testing.qwe \n #QA,rty \n #Testtest;yui \n #TestTestTest:poi";
            TitleText = "QA Testing Title Automation-" + PageServices.Randomizr.RandomString(5);



            // driver.Navigate().GoToUrl(commonsAppURL);
            //loginPage.SSO_Login(ssoUserName, ssoPassword);
            //loginPage.Direct_Login(nonSSOUserName, nonSSOPassword);
            //Console.WriteLine(ssoUserName + " logged in");
            //
            loginPage.Login(commonsAppURL, false);
            
            cmGrps.JoinAndOpenGroup(cmGrps.ConversationGroupName);
            grpActivity.AddContentInGroup(DescriptionText, TitleText, uploadFile);
            cmGrps.EditAddTagLastPost();
            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");


        }



        [Test, Category("GroupPrivateMessage")]
        public void GroupPrivateMessage()
        {

            // driver.Navigate().GoToUrl(commonsAppURL);
            // loginPage.Direct_Login(nonSSOUserName, nonSSOPassword);
            //loginPage.SSO_Login(ssoUserName, ssoPassword);
            //Console.WriteLine(ssoUserName + " logged in");
            loginPage.Login(commonsAppURL, false);
            userInfo.GetUserName();
            string uName = userInfo.GetUserName();
            Console.WriteLine(uName);
            directoryGroupMessage.VerifyDirectoryGroupMessage();
        }


        [Test, Category("MembershipDirectory")]
       // [Repeat(5)]
        public void MembershipDirectoryTest()
        {
            // driver.Navigate().GoToUrl(commonsAppURL);
            // loginPage.Direct_Login(nonSSOUserName, nonSSOPassword);
            //loginPage.SSO_Login(ssoUserName, ssoPassword);
            //Console.WriteLine(ssoUserName + " logged in");
            loginPage.Login(commonsAppURL, false);
            userInfo.GetUserName();
            string uName = userInfo.GetUserName();
            Console.WriteLine(uName);
            Console.WriteLine("********* Access Membership directory page*********");
            membershipDirectory.GotoMembershipDirectorypage();
            directoryGroupMessage.VerifyDirectoryGroupMessage();
            membershipDirectory.GotoMembershipDirectorypage();
            membershipDirectory.SelectValueFromStateDropdown_All();
            driver.Navigate().Refresh();
            Thread.Sleep(2000);
            PageServices.ScrollPageUptoTop(driver);
            membershipDirectory.VerifyStatesNAimplementation_All();
            membershipDirectory.VerifyStatesNAimplementation_Student();
            Console.WriteLine("Test Complete");
            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");


        }


        [Test, Category("GroupInvite")]
        public void GroupInvite()
        {

            // driver.Navigate().GoToUrl(commonsAppURL);
            //loginPage.SSO_Login(ssoUserName, ssoPassword);
            //loginPage.Direct_Login(nonSSOUserName, nonSSOPassword);
            //Console.WriteLine(ssoUserName + " logged in");
            loginPage.Login(commonsAppURL, false);
            
            cmGrps.JoinAndOpenGroup(cmGrps.ConversationGroupName);
            cmGrps.SendGroupInvite(cmGrps.inviteeemail1, cmGrps.inviteeemail2); //Successful Group Invite to User
            cmGrps.OpenJoinedGroup(cmGrps.ConversationGroupName); // This method is added till the time Bug #71211 is not fixed. After the fix of this defect this method can be removed.
            cmGrps.SendGroupInvite(cmGrps.invalidemail1, cmGrps.invalidemail2);  // Error message verified on invalid user invite
            Console.WriteLine("Test Complete");
            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");


        }

        [Test, Category("AlumniVerification")]
        public void AlumniDirectory()
        {
            DescriptionText = "QA Testing Description-" + PageServices.Randomizr.RandomString(250);// DateTime.Now.ToLongTimeString() ;
            TitleText = "QA Testing Title Automation-" + PageServices.Randomizr.RandomString(7);// DateTime.Now.ToLongTimeString(); ;


            // driver.Navigate().GoToUrl(commonsAppURL);
            loginPage.Login(commonsAppURL, false);
            //  
            Console.WriteLine("********** Assign & Verify Alumni with Student Role***************");
            notificationSettings.AssignAlumni_WithRole("Student");
            notificationSettings.MembershipDir();
            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");


        }

        [Test, Category("AlumniVerification")]
        public void AlumniDirectorySearch()
        {
            DescriptionText = "QA Testing Description-" + PageServices.Randomizr.RandomString(250);// DateTime.Now.ToLongTimeString() ;
            TitleText = "QA Testing Title Automation-" + PageServices.Randomizr.RandomString(7);// DateTime.Now.ToLongTimeString(); ;


            // driver.Navigate().GoToUrl(commonsAppURL);
            loginPage.Login(commonsAppURL, false);
            // 
            Console.WriteLine("***** Verify different alumni filters on membership page *********");
            // notificationSettings.MembershipDir();
            membershipDirectory.GotoMembershipDirectorypage();
            notificationSettings.AlumniMembershipDir();

            personalCommons.VerifyAlumniFilters();
            personalCommons.VerifyAlumniStateFilters();

            userInfo.Logout();


        }




        [Test, Category("TopNavigation")]
        public void TopNavigation()
        {

            // driver.Navigate().GoToUrl(commonsAppURL);
            //loginPage.SSO_Login(ssoUserName, ssoPassword);
            //Console.WriteLine(ssoUserName + " logged in");
            loginPage.Login(commonsAppURL, true);
            // 
            personalCommons.VerifyPersonalCommonsLink();
            directoryGroupMessage.VerifyMembershipDirectorylink();
            loginPage.VerifyMyGroupLink();
            myGroups.VerifyGrouplinksAtMyGroups();
            myGroups.VerifyFilterIsAvailableAndClickOnAnyGroup();
            loginPage.VerifyMyGroupLink();
            myGroups.VerifyingScrollbarOnMyGroupMenu();
            Thread.Sleep(2000);
            myGroups.VerifyingSortingOrder();
            personalCommons.ClickOnPersonalCommons();
            Thread.Sleep(1000);
            cmGrps.VerifydiscoverGroups(cmGrps.CommunityGroup);
            personalCommons.ClickOnPersonalCommons();
            Thread.Sleep(1000);
            myGroups.GotoAllMyGroupspage();
            userInfo.Logout();


        }


        [Test, Category("PollActivity_FeaturePosts")]
        public void PollActivity_FeaturePosts()
/*
        [Test, Category("PollActivity")]
        public void PollActivity()
*/
        {

            // driver.Navigate().GoToUrl(commonsAppURL);
            //loginPage.SSO_Login(ssoUserName, ssoPassword);
            //Console.WriteLine(ssoUserName + " logged in");
            loginPage.Login(commonsAppURL, false);
            DateTime dy = DateTime.Now;

            grpActivity.PostPoll_ConversationGroup("University Community Forum", "QA Automation Poll Testing - " + dy);
            grpActivity.PostPoll_CommunityGroup("Academic Success Center", "QA Automation Poll Testing - " + dy);
            grpActivity.startFeaturedPost("University Community Forum");
            grpActivity.verifyFeatureConversation("QA Automation Conversation Post with Featured True");
            grpActivity.verifyFeatureEvent("QA Automation Event Post with Featured True");
            grpActivity.verifyFeatureUpload("QA Automation Upload Post with Featured True", uploadFile);
            grpActivity.verifyFeatureVideo("QA Automation Video Post with Featured True", grpActivity.zoomvideoURL);
            grpActivity.verifyFeaturePoll("University Community Forum", "QA Automation Poll Testing - " + dy);
            userInfo.Logout();
            test.Log
                
                (Status.Pass, "PollActivity_FeaturePosts Test case has been completed");
/*
            grpActivity.PostPoll_ConversationGroup("NCU Community Forum", "QA Automation Testing - " + dy);
            grpActivity.PostPoll_CommunityGroup("Center for Teaching and Learning", "QA Automation Testing - " + dy);

            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");


*/


        }

        [Test, Category("JFKLawSchool")]
        public void JFKLawSchool()
        {
            DescriptionText = "QA Testing Description-" + PageServices.Randomizr.RandomString(5);
            TitleText = "QA Testing Title Automation-" + PageServices.Randomizr.RandomString(5);



            // driver.Navigate().GoToUrl(commonsAppURL);
            //loginPage.SSO_Login(jfkssoUserName, jfkssoPassword);
            //Console.WriteLine(ssoUserName + " logged in");
            loginPage.Login(commonsAppURL, false);
            cmGrps.JoinAndOpenGroup(myGroups.DefJFKSchoolName);
            //personalCommons.ClickOnPersonalCommons();
            //myGroups.VerifyAndOpenGropFromHome(myGroups.DefJFKSchoolName);

            grpActivity.AddContentInGroup(DescriptionText, TitleText, uploadFile);
            Thread.Sleep(3000);

            grpActivity.replyToCoomentsposted(action, "Test");

            personalCommons.ClickOnPersonalCommons();
            Thread.Sleep(1000);
            membershipDirectory.GotoMembershipDirectorypage();
            membershipDirectory.VerifyLawSchoolMemDir("School of Law");
            membershipDirectory.OpenMemDirStudentTab();
            Thread.Sleep(3000);
            membershipDirectory.VerifyLawSchoolMemDir("School of Law");
            membershipDirectory.OpenMemDirFacultyTab();
            membershipDirectory.VerifyLawSchoolMemDir("School of Law");
            personalCommons.ClickOnPersonalCommons();
            Thread.Sleep(1000);
            cmGrps.OpenJoinedGroup_ByGroupName(myGroups.DefJFKSchoolName);
            cmGrps.Leavegroup();
            personalCommons.ClickOnPersonalCommons();
            Thread.Sleep(1000);
            conversationGroup.verifySchoolIconandCount("SUS Community Forum", "Ashli Blueford");
            userInfo.Logout();

        }

        [Test, Category("Search")]

        public void VerifySearchOnVariousPages()
        {
            //  First login as student to Commons
            // driver.Navigate().GoToUrl(commonsAppURL);
            //  loginPage.SSO_Login(ssoUserName, ssoPassword);
            //loginPage.Direct_Login(nonSSOUserName, nonSSOPassword);
            // Console.WriteLine(ssoUserName + " logged in");
            loginPage.Login(commonsAppURL, false);
            
            Console.WriteLine("****** Perform Search and Validation from Personal Commons Page *******");
            searchPage.ExpectedResultSearch(searchPage.expectSearchProfileSearch);
            Console.WriteLine("Search on Personal Commons Page");
            searchPage.ValidatePageNavigationOnSearchPage();


            // Return to Personal Commons Home Page

            userInfo.ClickPersonalCommons();
            Console.WriteLine("Home Tab Clicked");
            Thread.Sleep(1000);

            // Perform Search and Validation from Profile Page
            userInfo.ClickProfileTab();
            Console.WriteLine("Profile Tab Clicked");
            Thread.Sleep(1000);
            searchPage.ExpectedResultSearch(searchPage.expectSearchProfileSearch);
            searchPage.ValidatePageNavigationOnSearchPage();


            // Return to Personal Commons Home Page
            userInfo.ClickPersonalCommons();
            Console.WriteLine("Home Tab Clicked");

            // Perform Search and Validation from Profile Edit Page
            userInfo.ClickProfileTab();
            Console.WriteLine("Profile Tab Clicked");
            Thread.Sleep(1000);
            userInfo.ClickOnEditProfileTab();
            Console.WriteLine("Profile Edit Button Clicked");
            searchPage.ExpectedResultSearch(searchPage.expectSearchProfileSearch);
            searchPage.ValidatePageNavigationOnSearchPage();


            // Return to Personal Commons Home Page
            userInfo.ClickPersonalCommons();
            Console.WriteLine("Home Tab Clicked");

            // Search from Account Page
            userInfo.ClickOnUserMenu();
            Console.WriteLine("User Menu Clicked");
            userInfo.ClickAccountTab();
            Console.WriteLine("Account Link Clicked");
            Thread.Sleep(1000);
            searchPage.ExpectedResultSearch(searchPage.expectSearchProfileSearch);
            searchPage.ValidatePageNavigationOnSearchPage();


            // Return to Personal Commons Home Page
            userInfo.ClickPersonalCommons();
            Console.WriteLine("Home Tab Clicked");

            // Search from Followed Content Page
            userInfo.ClickOnUserMenu();
            Thread.Sleep(2000);
            Console.WriteLine("User Menu Clicked");
            userInfo.ClickFollowedContent();
            Console.WriteLine("Followed Content Tab Clicked");
            Thread.Sleep(1000);
            searchPage.ExpectedResultSearch(searchPage.expectSearchProfileSearch);
            searchPage.ValidatePageNavigationOnSearchPage();


            // Return to Personal Commons Home Page
            userInfo.ClickPersonalCommons();
            Console.WriteLine("Home Tab Clicked");
            Thread.Sleep(1000);

            // Search from My Content Page
            userInfo.ClickOnUserMenu();
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            Console.WriteLine("User Menu Clicked");
            Thread.Sleep(1000);
            userInfo.ClickMyContent();
            Console.WriteLine("My Content Tab Clicked");
            Thread.Sleep(2000);

            searchPage.ExpectedResultSearch(searchPage.expectSearchProfileSearch);
            searchPage.ValidatePageNavigationOnSearchPage();

            // Return to Personal Commons Home Page
            userInfo.ClickPersonalCommons();
            Console.WriteLine("Home Tab Clicked");
            Thread.Sleep(1000);

            // Search from Private Message page
            userInfo.ClickInbox();
            Console.WriteLine("User Inbox for Private Messages page Clicked");
            Thread.Sleep(2000);

            searchPage.ExpectedResultSearch(searchPage.expectSearchProfileSearch);
            searchPage.ValidatePageNavigationOnSearchPage();


            // Return to Personal Commons Home Page
            userInfo.ClickPersonalCommons();
            Console.WriteLine("Home Tab Clicked");
            Thread.Sleep(1000);

            // Search from Notifications Settings Page
            userInfo.ClickOnUserMenu();
            Console.WriteLine("User Menu Clicked");
            Thread.Sleep(1000);
            userInfo.ClickAccountTab();
            Console.WriteLine("Account Link Clicked");
            Thread.Sleep(1000);
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            userInfo.ClickGroupMemberships();
            Console.WriteLine("Notifications Settings Clicked");
            Thread.Sleep(1000);

            searchPage.ExpectedResultSearch(searchPage.expectSearchProfileSearch);
            searchPage.ValidatePageNavigationOnSearchPage();


            // Return to Personal Commons Home Page
            userInfo.ClickPersonalCommons();
            Console.WriteLine("Home Tab Clicked");
            Thread.Sleep(1000);

            // Search from Group Memberships Page
            userInfo.ClickOnUserMenu();
            Console.WriteLine("User Menu Clicked");
            userInfo.ClickAccountTab();
            Console.WriteLine("Account Link Clicked");
            Thread.Sleep(3000);
            userInfo.ClickGroupMemberships();
            Console.WriteLine("Group Memberships Clicked");
            Thread.Sleep(3000);

            searchPage.ExpectedResultSearch(searchPage.expectSearchProfileSearch);
            searchPage.ValidatePageNavigationOnSearchPage();


            // Return to Personal Commons Home Page
            userInfo.ClickPersonalCommons();
            Console.WriteLine("Home Tab Clicked");
            Thread.Sleep(1000);
            PageServices.WaitForPageToCompletelyLoaded(driver, 120);
            // Search from Group Home Page
            userInfo.ClickMyGroupsMenu();
            Console.WriteLine("My Groups Menu Clicked");
            userInfo.ClickMyGroups();
            Console.WriteLine("My Groups Option Clicked");
            userInfo.ClickViewFirstGroup();
            Console.WriteLine("First Group In My Groups Selected");

            searchPage.ExpectedResultSearch(searchPage.expectSearchProfileSearch);
            searchPage.ValidatePageNavigationOnSearchPage();


            // Return to Personal Commons Home Page
            userInfo.ClickPersonalCommons();
            Console.WriteLine("Home Tab Clicked");
            Thread.Sleep(1000);

            // Search from My Group Content Page
            userInfo.ClickMyGroupsMenu();
            Console.WriteLine("My Groups Menu Clicked");
            userInfo.ClickMyGroups();
            Console.WriteLine("My Groups Option Clicked");
            userInfo.ClickViewFirstGroup();
            Console.WriteLine("First Group in My Groups Selected");
            userInfo.ClickFirstGroupMenu();
            Console.WriteLine("First Group's Menu Selected");
            userInfo.ClickFirstGrpContent();
            Console.WriteLine("First Group's Content in Menu Selected");
            Thread.Sleep(1000);

            searchPage.ExpectedResultSearch(searchPage.expectSearchProfileSearch);
            searchPage.ValidatePageNavigationOnSearchPage();


            // Return to Personal Commons Home Page
            userInfo.ClickPersonalCommons();
            Console.WriteLine("Home Tab Clicked");
            Thread.Sleep(1000);

            // Search from My Group Member's Page
            userInfo.ClickMyGroupsMenu();
            Console.WriteLine("My Groups Menu Clicked");
            userInfo.ClickMyGroups();
            Console.WriteLine("My Groups Option Clicked");
            userInfo.ClickViewFirstGroup();
            Console.WriteLine("First Group in My Groups Selected");
            userInfo.ClickFirstGroupMenu();
            Console.WriteLine("First Group's Menu Selected");
            userInfo.ClickFirstGrpMembers();
            Console.WriteLine("First Group's Members in Menu Selected");
            Thread.Sleep(1000);

            searchPage.ExpectedResultSearch(searchPage.expectSearchProfileSearch);
            searchPage.ValidatePageNavigationOnSearchPage();


            // Return to Personal Commons Home Page
            userInfo.ClickPersonalCommons();
            Console.WriteLine("Home Tab Clicked");
            Thread.Sleep(1000);

            // Search from Discover Groups Page
            userInfo.ClickMyGroupsMenu();
            Console.WriteLine("My Groups Menu Clicked");
            Thread.Sleep(3000);
            userInfo.ClickDiscoverGroups();
            Console.WriteLine("Discover Groups Option Clicked");
            Thread.Sleep(3000);

            searchPage.ExpectedResultSearch(searchPage.expectSearchProfileSearch);
            searchPage.ValidatePageNavigationOnSearchPage();


            // Return to Personal Commons Home Page
            userInfo.ClickPersonalCommons();
            Console.WriteLine("Home Tab Clicked");
            Thread.Sleep(1000);

            // Search from My Group Page
            userInfo.ClickMyGroupsMenu();
            Console.WriteLine("My Groups Menu Clicked");
            userInfo.ClickMyGroups();
            Console.WriteLine("My Groups Option Clicked");

            searchPage.ExpectedResultSearch(searchPage.expectSearchProfileSearch);
            searchPage.ValidatePageNavigationOnSearchPage();
            Thread.Sleep(1000);
            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");


        }


        [Test, Category("Search")]

        public void VerifySearchResultsPgType_Sort_OrderSearch()
        {

            //driver.Navigate().GoToUrl(commonsAppURL);
            // loginPage.SSO_Login(ssoUserName, ssoPassword);
            //loginPage.Direct_Login(nonSSOUserName, nonSSOPassword);
            //Console.WriteLine(ssoUserName + " logged in");
            loginPage.Login(commonsAppURL, false);
            

            //  Perform primary search to get to Search Results Page
            userInfo.ClickProfileTab();
            Console.WriteLine("Profile Tab Clicked");
             userInfo.ClickOnSearchField1();
            searchPage.ExpectedResultSearch2();
           searchPage.ExpectedResultSearch(searchPage.expectSearchProfileSearch);
            Console.WriteLine("Search for 'Profile' in Search box is Clicked");

            // Search from Search Results Page Using Defaults
            searchPage.ExpectedResultFromSearchMenuSearch();
            searchPage.ExpectedResultSearch(searchPage.expectSearchMenu);
            Console.WriteLine("New Search for 'Linked' in Search on Search Results Section Clicked");
            searchPage.ValidatePageNavigationOnSearchPage();

           // Filter Option Any Selected and Perform Search
            userInfo.ClickTypeDropDown();
            Thread.Sleep(1000);
            userInfo.ClickOnTypeAnyFilter();
            Console.WriteLine("Filter Options Drop Down Selected");
            // While on the search results page, search from the search menu filtering by Any
            Thread.Sleep(1000);
            //searchPage.ExpectedResultFromSearchMenuSearch();
            searchPage.ExpectedResultSearch3(searchPage.expectSearchMenu);
            Console.WriteLine("New Search for 'Linked' in Search on Search Results Section Clicked 'Any' Filter");
            searchPage.ValidatePageNavigationOnSearchPage();

            // Filter Option Comment and Perform Search
            userInfo.ClickTypeDropDown();
            Thread.Sleep(1000);
            userInfo.ClickOnTypeCommentFilter();
            Console.WriteLine("Filter Options Drop Down Selected");
            // While on the search results page, search from the search menu filtering by Comment
            Thread.Sleep(1000);
            //searchPage.ExpectedResultFromSearchMenuSearch();
            searchPage.ExpectedResultSearch3(searchPage.expectSearchMenu);
            Console.WriteLine("New Search for 'Linked' in Search on Search Results Section Clicked 'Comment' Filter");
            searchPage.ValidatePageNavigationOnSearchPage();

            // Filter Option Content and Peform Search
            userInfo.ClickTypeDropDown();
            Thread.Sleep(1000);
            userInfo.ClickOnTypeContentFilter();
            Console.WriteLine("Filter Options Drop Down Selected");
            // While on the search results page, search from the search menu filtering by Content
            Thread.Sleep(1000);
            //searchPage.ExpectedResultFromSearchMenuSearch();
            searchPage.ExpectedResultSearch3(searchPage.expectSearchMenu);
            Console.WriteLine("New Search for 'Linked' in Search on Search Results Section Clicked 'Content' Filter");
            searchPage.VerifyContentTitleText();
            searchPage.VerifyContentDescriptionText();
            searchPage.ValidatePageNavigationOnSearchPage();

            // Filter Option Group and Perform Search
            userInfo.ClickTypeDropDown();
            Thread.Sleep(1000);
            userInfo.ClickOnTypeGroupFilter();
            searchPage.FilterSearchButton.Click();
            Console.WriteLine("Filter Options Drop Down Selected");
            // While on the search results page, search from the search menu filtering by Group
            Thread.Sleep(1000);
           // searchPage.ExpectedResultSearch(searchPage.expectSearchMenuPSY);
            //userInfo.ClickTypeDropDown();
            Thread.Sleep(1000);

            Console.WriteLine("New Search for 'PSY' in Search on Search Results Section Clicked 'Group' Filter");
            searchPage.VerifyGroupTitleText();
            searchPage.VerifyGroupDescriptionText();

            Console.WriteLine("Filter Options Drop Down Selected");
            // While on the search results page, search from the search menu filtering by Person
            Thread.Sleep(1000);
            searchPage.ExpectedResultSearch(searchPage.expectSearchMenuPSY);
            userInfo.ClickTypeDropDown();
            Thread.Sleep(1000);
            userInfo.ClickOnTypePersonFilter();
            searchPage.FilterSearchButton.Click();

            Console.WriteLine("New Search for 'PSY' in Search on Search Results Section Clicked 'Person' Filter");
            test.Log(Status.Info,"New Search for 'PSY' in Search on Search Results Section Clicked 'Person' Filter");
            searchPage.VerifyPersonTitleText();
            searchPage.ValidatePageNavigationOnSearchPage();

            // Filter Option Resource Center Content and Perform Search
            userInfo.ClickTypeDropDown();
            Thread.Sleep(1000);
            userInfo.ClickOnTypeResourceCenterFilter();
            Console.WriteLine("Filter Options Drop Down Selected");
            // While on the search results page, search from the search menu filtering by Resource Center Content
            Thread.Sleep(1000);
            //searchPage.ExpectedResultFromSearchMenuSearch();
            searchPage.ExpectedResultSearch(searchPage.expectSearchMenuPSY);
            Console.WriteLine("New Search for 'Linked' in Search on Search Results Section Clicked 'Resource Center Content' Filter");
            test.Log(Status.Info,"New Search for 'Linked' in Search on Search Results Section Clicked 'Resource Center Content' Filter");
            searchPage.ValidatePageNavigationOnSearchPage();

            // Filter Option Tag and Perform Search
            userInfo.ClickTypeDropDown();
            Thread.Sleep(1000);
            userInfo.ClickOnTypeTag();
            Console.WriteLine("Tag Options Drop Down Selected");
            // While on the search results page, search from the search menu filtering by Resource Center Content
            Thread.Sleep(1000);
            //searchPage.ExpectedResultFromSearchMenuSearch();
            searchPage.ExpectedResultSearch(searchPage.expectSearchMenu);
            Console.WriteLine("New Search for 'Linked' in Search on Search Results Section Clicked 'Tag' Filter");
            test.Log(Status.Info,"New Search for 'Linked' in Search on Search Results Section Clicked 'Tag' Filter");
            searchPage.ValidatePageNavigationOnSearchPage();

            // Now testing the Sort Drop Down

            // Sort Option Relevance and Perform Search
            // First go back to the Results page with Type "Any" as the Type drop down then to the Sort functions
            userInfo.ClickTypeDropDown();
            userInfo.ClickOnTypeAnyFilter();
            // Now Select Sort Options
            userInfo.ClickSortDropDown();
            Console.WriteLine("Sort By Options Drop Down Selected");
            Thread.Sleep(1000);
            userInfo.ClickOnSortyByRelevance();
            Thread.Sleep(1000);
            // While on the search results page, Sort by Relevance
            //searchPage.ExpectedResultFromSearchMenuSearch2();
            searchPage.ExpectedResultSearch(searchPage.expectSearchMenuPSY);
            Console.WriteLine("New Search for 'PSY' in Search on Search Results Section Clicked Sorted By 'Relevance'");
            test.Log(Status.Info,"New Search for 'PSY' in Search on Search Results Section Clicked Sorted By 'Relevance'");
            searchPage.ValidatePageNavigationOnSearchPage();

            // Sort Option Date and Perform Search
            userInfo.ClickSortDropDown();
            Console.WriteLine("Sort By Options Drop Down Selected");
            Thread.Sleep(1000);
            userInfo.ClickOnSortyByDate();
            Thread.Sleep(1000);
            // While on the search results page, Sort by Date

            searchPage.ExpectedResultSearch(searchPage.expectSearchMenuPSY);
            Console.WriteLine("New Search for 'PSY' in Search on Search Results Section Clicked Sorted By 'Date'");
            test.Log(Status.Info,"New Search for 'PSY' in Search on Search Results Section Clicked Sorted By 'Date'");
            searchPage.ValidatePageNavigationOnSearchPage();

            // Sort Option Author and Perform Search
            userInfo.ClickSortDropDown();
            Console.WriteLine("Sort By Options Drop Down Selected");
            Thread.Sleep(1000);
            userInfo.ClickOnSortyByAuthor();
            Thread.Sleep(1000);
            // While on the search results page, Sort by Author
            //searchPage.ExpectedResultFromSearchMenuSearch2();
            searchPage.ExpectedResultSearch(searchPage.expectSearchMenuPSY);
            Console.WriteLine("New Search for 'PSY' in Search on Search Results Section Clicked Sorted By 'Author'");
            test.Log(Status.Info,"New Search for 'PSY' in Search on Search Results Section Clicked Sorted By 'Author'");
            searchPage.ValidatePageNavigationOnSearchPage();

            // Now Testing the Order By Options

            // Order Option ASC and Perform Search
            userInfo.ClickOrderDropDown();
            Console.WriteLine("Order By Options Drop Down Selected");
            Thread.Sleep(1000);
            userInfo.ClickOrderAsc();
            userInfo.ClickSearchResultsPgSearchButton();
            Thread.Sleep(1000);
            // While on the search results page, search from the search menu Order by ASC
            Thread.Sleep(1000);

            searchPage.ExpectedResultSearch(searchPage.expectSearchMenu);
            Console.WriteLine("New Search for 'Linked' in Search on Search Results Section Order By 'ASC' or Ascending");
            test.Log(Status.Info,"New Search for 'Linked' in Search on Search Results Section Order By 'ASC' or Ascending");
            searchPage.ValidatePageNavigationOnSearchPage();

            // Order Option DESC and Perform Search
            userInfo.ClickOrderDropDown();
            Console.WriteLine("Order By Options Drop Down Selected");
            test.Log(Status.Info,"Order By Options Drop Down Selected");
            Thread.Sleep(1000);
            userInfo.ClickOrderDesc();
            userInfo.ClickSearchResultsPgSearchButton();
            Thread.Sleep(1000);
            // While on the search results page, search from the search menu Order by DESC
            Thread.Sleep(1000);
            //searchPage.ExpectedResultFromSearchMenuSearch();
            searchPage.ExpectedResultSearch(searchPage.expectSearchMenu);
            Console.WriteLine("New Search for 'LinkedIn' in Search on Search Results Section Order By 'Desc' or Descending");
            test.Log(Status.Info,"New Search for 'LinkedIn' in Search on Search Results Section Order By 'Desc' or Descending");
            searchPage.ValidatePageNavigationOnSearchPage();
            Thread.Sleep(1000);
            userInfo.Logout();
            test.Log(Status.Pass, "Test case has been completed");

        }

        [Test, Category("ASC Proofreader")]
        public void VerifyPaymentValidationForStudent()
        {
               
                loginPage.Login(commonsAppURL, false);               
                Console.WriteLine(nonSSOUserName + " logged in");        

               // userInfo.ClickOnUserMenu();

                //userInfo.ClickOnSubMenu(userInfo.unMasqSubMenu);
                Thread.Sleep(2000);
                notificationSettings.Masqueradestudent("Ashli Blueford");
                Thread.Sleep(2000);
                cmGrps.JoinAndOpenGroup("Academic Success Center");
                cmGrps.VerifyASCPaymentFieldsPaymentPage();
            //cmGrps.VerifyASCPaymentFields();

            
        }

        [Test, Category("ASC Proofreader")]
        public void VerifyASCAccessibleForAdmin()
        {
          
                loginPage.Login(commonsAppURL, false);
                Console.WriteLine(nonSSOUserName + " logged in");
                notificationSettings.NineIcon.Click();
                cmGrps.VerifyASCProofreaderLink();
                notificationSettings.ASCaddPage();
                cmGrps.EditCostAndDuration();

                cmGrps.CancelCostAndDurationFromDelete();

                cmGrps.DeleteCostAndDurationFromDelete();


           
        }

        [Test, Category("ASC Proofreader")]
        public void VerifyASCAccessibleForFaculty()
        {           
                loginPage.Login(commonsAppURL, false);
                Console.WriteLine(nonSSOUserName + " logged in");

                Console.WriteLine("********** Assign & Verify Alumni with Faculty Role***************");
                notificationSettings.AlumniRoleASCProofReader("Faculty");

                Thread.Sleep(3000);
                cmGrps.ClickOnGroupFromLeftMenu("Academic Success Center");
                cmGrps.VerifyASCHeaderIsExist(false);

                Thread.Sleep(3000);
                userInfo.ClickOnUserMenu();
                userInfo.ClickOnSubMenu(userInfo.unMasqSubMenu);
                Console.WriteLine("********** Assign & Verify Alumni with Team Member Role***************");
                notificationSettings.AlumniRoleASCProofReader("Team");
                Thread.Sleep(3000);
                cmGrps.ClickOnGroupFromLeftMenu("Academic Success Center");
                cmGrps.VerifyASCHeaderIsExist(false);
                userInfo.Logout();

        }

        [Test, Category("ASC Proofreader")]
        public void ASCStdPayment()
        {

            driver.Navigate().GoToUrl(commonsAppURL);
            loginPage.Login(commonsAppURL, true);           
            Console.WriteLine(ssoUserName + " logged in");
            cmGrps.JoinAndOpenGroup("Academic Success Center");

            cmGrps.VerifyASCPaymentFieldsPaymentPage();
            Thread.Sleep(5000);
            cmGrps.VerifyCommentsAreableToEnter();
            //Console.WriteLine("**************** Now Access Outlook and Verify Reported Message ********************");

            //driver.Navigate().GoToUrl(outlookURL+ LearnerBetaFolder);
            //outlook.LoginToO365WebMail(o365UserName, o365UserPassword);
            
           

            //Thread.Sleep(2000);

           // outlook.VerifyingEmailForPayment(LearnerIdASCPaymentscreen, LearnerFistNameASCPaymentscreen, LearnerLastNameASCPaymentscreen);
           // outlook.VerifyingEmailBodyForFacultySubtitution(LearnerIdASCPaymentscreen, LearnerFistNameASCPaymentscreen, LearnerLastNameASCPaymentscreen);




        }

        [Test, Category("ASC Proofreader")]
        public void ASCadminPage()
        {
            
                loginPage.Login(commonsAppURL, false);
                Console.WriteLine(nonSSOUserName + " logged in");
                Console.WriteLine("***** Verify ASC admin Page different features *********");
                notificationSettings.OpenASCadminPage(); 
                notificationSettings.ASCcostNdurationPage();
                notificationSettings.ASCaddPage();
                notificationSettings.ASCeditNDeletePage(); 
                notificationSettings.ASCDeleteEntryCreated(); 

                userInfo.Logout();
                Console.WriteLine("test");

           
        }

        [Test, Category("VerifyAlumniAmbassadorRole")]
        public void VerifyAlumniAmbassadorRole()
        {
            loginPage.Login(commonsAppURL, false);
            Console.WriteLine(nonSSOUserName + " logged in");
            Console.WriteLine("***** Verify Alumni Ambassador Roles *********");
            userInfo.AccessAccountMenu();
            userAcc.AlumniAmbassadorRoleAvl();
            userAcc.AlumniAmbassadorRoleSelect();
            userAcc.GoTOProfilePage();
            userAcc.VerifyUserRoleAtPf("Alumni Ambassador"); 
            userAcc.VerifyAlumniAmbassadorRoleIcon();
            userAcc.VerifyUserRoleToolTip("Alumni ambassador"); //Different string is used. That’s Why parametrization has not been one here. We may fix in the future open defect then we will change it.

            userInfo.Logout();
            Console.WriteLine("VerifyAlumniAmbassadorRole - test Pass");
        }


    }


}
