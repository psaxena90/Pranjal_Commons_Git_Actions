using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons_Automation
{
   public class MainSetup:BrowserType
    {
        #region variables

        public static string invalidUser = "Test";
        public static string   inValidPassword = "Test";
        public static string IIndSOSUser;// = "vsinhaadmin";
        public static string IIndSSOPassword;// = "vsinhaadmin";
        public static string recipientName = string.Empty;
        public static string recepeintName2;// = string.Empty; ;          
        public static string MentorBetaFolder = "MentorBeta@ncu.edu/";
        public static string LearnerBetaFolder = "LearnerBeta@ncu.edu/";
        public static string expectedReported = "Has been reported";
        //string alumniOptinURL = "https://commons.qa1.ncu.edu/alumni/optin";
        public static string  expectedError;
        public static  ExtentReports extent;
        public static  ExtentHtmlReporter htmlReporter;
        public static  ExtentTest test;
        public TestContext TestContext { get; set; }
        public static string commonsAppURL;
        public static string alumniOptInUrl;
        public static string environmentSetup;
        public static string errorPath;
        public static string reportPath;
        public static string uploadFile;
        public static string M4PUloadFile;
        public static string uploadProfileImage;
        public static string browser;
        public static string ssoUserName; //"A.Abiodun9916@o365.qa.ncu.edu";
        public static string ssoPassword; // "Guest2011";
        public static string nonSSOUserName; //"A.Abiodun9916@o365.qa.ncu.edu";
        public static string nonSSOPassword; // "Guest2011";
        public static string jfkssoUserName; //"A.Abiodun9916@o365.qa.ncu.edu";
        public static string jfkssoPassword; // "Guest2011";
        public static string outlookURL;
        public static string o365UserName;
        public static string SysUserName;
        public static string o365UserPassword;
        public static Actions action;
        public static Screenshot ss;
        public static string path;
        public static string DescriptionText;
        public static string TitleText;
        public static string directLinkUrl;
        public static string LearnerFistNameASCPaymentscreen;
        public static string LearnerIdASCPaymentscreen;
        public static string LearnerLastNameASCPaymentscreen;
        public static string ArchivedAlumniStudent;
        public static string select;
        public static string ans1;
        public static string ans2;
        public static string ans3;
        public static string ans4;
        public static string ans5;

        #endregion variables

        #region Class Instances
        public static CommonsGroups cmGrps;
        public static IWebDriver driver;
        public static LoginPage loginPage;
        public static PersonalCommons personalCommons;
        public static GroupsActivity grpActivity;
        public static UserInfo userInfo;
        public static UserAccount userAcc;
        public static EditProfile editProf;
        public static NotificationSettings notificationSettings;
        public static PrivateMessage pvtMsg;
        public static SearchPage searchPage;
        public static DiscoverGroup discoverGroup;
        public static UserGroupContent userGrpContent;
        public static ConversationGroup conversationGroup;
        public static MyGroups myGroups;
        public static DirectoryGroupMessage directoryGroupMessage;
        public static MembershipDirectory membershipDirectory;
        public static Outlook outlook;


        #endregion Class Instances
      

        [OneTimeSetUp]
        public static void OneTimeSetup()
        {
            browser = TestContext.Parameters.Get("Browser").ToString();
            environmentSetup = TestContext.Parameters.Get("Environment").ToString();
            errorPath = PageServices.SetReportAndLogPath().Item1;
            reportPath = PageServices.SetReportAndLogPath().Item2;
            Console.WriteLine(errorPath);
            Console.WriteLine(reportPath);
            uploadFile = PageServices.GetProjectPath() + TestContext.Parameters.Get("UploadPath").Trim();
            uploadProfileImage = PageServices.GetProjectPath() + TestContext.Parameters.Get("UploadImagePath").Trim();
            Console.WriteLine(reportPath);
            Console.WriteLine(uploadFile);
            M4PUloadFile = PageServices.GetProjectPath() + TestContext.Parameters.Get("UploadM4PPath").Trim();
            // htmlReporter = new ExtentHtmlReporter(reportPath);
            var htmlReporter = new ExtentV3HtmlReporter(reportPath + "CommonsAutomationReport_" + environmentSetup + ".html");
           //htmlReporter = new ExtentHtmlReporter(reportPath);
           //htmlReporter = new ExtentHtmlReporter(reportPath + "AutomationReport_" + environmentSetup + "_" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + "\\");
            htmlReporter.Config.Theme = Theme.Dark;
            htmlReporter.Config.DocumentTitle = "Commons Automation Report " + environmentSetup;
            htmlReporter.Config.ReportName = "Commons Automation Report " + environmentSetup;

            // htmlReporter.Config.EnableTimeline = true;
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Machine Name", Environment.MachineName.ToString());
            extent.AddSystemInfo("Platform Name", Environment.OSVersion.Platform.ToString());
            extent.AddSystemInfo("User Name", Environment.UserName.ToString());
            extent.AddSystemInfo("Browser", browser.ToString());
            outlookURL = TestContext.Parameters.Get("OutLookMentorBetaWebMail").ToString();
            o365UserName = TestContext.Parameters.Get("OutLookServiceAcnt").ToString();
            SysUserName = TestContext.Parameters.Get("OutLookServiceAcntPassword").ToString();
            o365UserPassword = TestContext.Parameters.Get("OutLookServiceAcntPassword").ToString();
            commonsAppURL = TestContext.Parameters.Get("commonsAppUrl").ToString();
            alumniOptInUrl = TestContext.Parameters.Get("alumniOptInUrl").ToString();
            ssoUserName = TestContext.Parameters.Get("SSOUserName").ToString();
            ssoPassword = TestContext.Parameters.Get("SSOPassword").ToString();
            nonSSOUserName = TestContext.Parameters.Get("NonSSOUserName").ToString();
            nonSSOPassword = TestContext.Parameters.Get("NonSSOPassword").ToString();
            jfkssoUserName = TestContext.Parameters.Get("JFKSchoolUserName").ToString();
            jfkssoPassword = TestContext.Parameters.Get("JFKSchoolPassword").ToString();
            directLinkUrl = TestContext.Parameters.Get("directLinkUrl").ToString();
            LearnerFistNameASCPaymentscreen = TestContext.Parameters.Get("LearnerFistNameASCPaymentscreen").ToString();
            LearnerLastNameASCPaymentscreen = TestContext.Parameters.Get("LearnerLastNameASCPaymentscreen").ToString();
            LearnerIdASCPaymentscreen = TestContext.Parameters.Get("LearnerIdASCPaymentscreen").ToString();
            ArchivedAlumniStudent = TestContext.Parameters.Get("ArchivedAlumniStudent").ToString();
            // driver = BrowserType.SelectBrowser(this.browser);
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {

            test.Log(Status.Info);
            extent.Flush();
        }

        [SetUp]
        public static void Setup()
        {
            Console.WriteLine("********************** Test Cases is Running against **********: "+ environmentSetup);
            Console.WriteLine("********************** URL Accessed is ************** :  "+ commonsAppURL);
            Console.WriteLine("********************** You Can check Error from this Path *********** :   "+ errorPath);
            Console.WriteLine("********************** You Can check Report from this Path *********** "+ reportPath);
            driver = BrowserType.SelectBrowser(browser);
            driver.Manage().Window.Maximize();
            loginPage = new LoginPage();
            cmGrps = new CommonsGroups();
            personalCommons = new PersonalCommons();
            grpActivity = new GroupsActivity();
            userInfo = new UserInfo();
            pvtMsg = new PrivateMessage();
            notificationSettings = new NotificationSettings();
            userAcc = new UserAccount();
            searchPage = new SearchPage();
            discoverGroup = new DiscoverGroup();
            editProf = new EditProfile();
            userGrpContent = new UserGroupContent();
            conversationGroup = new ConversationGroup();
            action = new Actions(driver);
            myGroups = new MyGroups();
            directoryGroupMessage = new DirectoryGroupMessage();
            membershipDirectory = new MembershipDirectory();
            outlook = new Outlook();
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);

        }

        [TearDown]

        public void ShutDown()
        {

            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
               
                ss = ((ITakesScreenshot)driver).GetScreenshot();

                var scr = CaptureScreenShot(TestContext.CurrentContext.Test.MethodName.Trim());// + "_" + environmentSetup + "_" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss"));
                path = errorPath + TestContext.CurrentContext.Test.MethodName + "_" + environmentSetup + "_" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".png";
                ss.SaveAsFile(path);
                TestContext.AddTestAttachment(path);                
                test.Fail(TestContext.CurrentContext.Result.StackTrace);
                test.Info("Screenshot : ", scr);               
                Exception e = new Exception(TestContext.CurrentContext.Result.StackTrace + TestContext.CurrentContext.Result.Message);
                ErrorLog.SaveExeptionToLog(e, TestContext.CurrentContext.Test.MethodName + "_" + environmentSetup, errorPath + TestContext.CurrentContext.Test.MethodName + "_" + environmentSetup + "_" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".xml");
                driver.Close();
                driver.Quit();

            }
            else
            {
                 //htmlReporter = new ExtentHtmlReporter(reportPath + "CommonsAutomationReport_P" + environmentSetup + ".html");

                driver.Close();
                driver.Quit();

            }

        }
        public MediaEntityModelProvider CaptureScreenShot(string Name)
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, Name).Build();
        }

        
    }

}

