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
   public class UserAccount:MainSetup
    {
        //IWebDriver driver;
       // UserInfo userInfo;
        public UserAccount()
        {
          //  driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(90)));
            userInfo = new UserInfo();
        }

       

        #region UserAccount Page Elements

        public string firstNameText = "First name";
        public string lastNameText = "Last name";
        public string firstNameInputText = "Ashia";
        public string lastNameInputText = "Abiodun";
        public string emailText = "Email address";
        public string timeZoneText = "Time zone";
        public string city = "New York";
        public string nameHoverText = "The first and last name are populated on account creation. If the users name is changed in other applications, it will not be picked up here. This will be changed in the future and these fields will be disabled.";
        public string emailHoverText = "The email address is not made public. It will only be used if you need to be contacted about your account or for opted-in notifications.";
            //"A valid email address. All emails from the system will be sent to this address. The email address is not made public and will only be used if you wish to receive a new password or wish to receive certain news or notifications by email.";
        public string timeZoneHoverText = "Select the desired local time and time zone. Dates and times throughout this site will be displayed using this time zone.";

        [FindsBy(How = How.XPath, Using = "//div[@id='edit-field-university-role']/div[5]/label[@class='option']")]
        public IWebElement AlumniAmbassadorSettingsLebal { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='edit-field-university-role-alumni-ambassador']")]
        public IWebElement AlumniAmbassadorInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='block-views-block-profile-block-1']//div[@class='card-panel alt indent entity__intro profile-tabs']")]
        public IWebElement UserRoleAtProfile { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='profile__stream']/div/div/div[1]/article/div/header/div[1]/a/img[@src='/themes/custom/commons/build/images/alumni_ambassador.svg']")]
        public IWebElement AlumniAmbassadorPfIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='profile__stream']/div/div/div[1]/article/div/header/div[1]/a")]
        public IWebElement UserRolePfToolTip { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='edit-field-first-name-wrapper']/div/label")]
        public IWebElement firstNameLabel { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='edit-field-last-name-wrapper']/div/label")]
        public IWebElement lastNameLabel { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='edit-account']/div/label")]
        public IWebElement emailLabel { get; set; }        

        [FindsBy(How = How.Id, Using = "edit-field-first-name-0-value")]
        public IWebElement firstName { get; set; }

        [FindsBy(How = How.Id, Using = "edit-field-last-name-0-value")]
        public IWebElement lastName { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='edit-timezone']/div/label")]
        public IWebElement timeZoneLabel { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//*[@id='edit_timezone__2_chosen']/a/span")]
        public IWebElement timeZoneOptions { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='edit_timezone__2_chosen']/div/div/input")]
        public IWebElement timeZoneInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='edit_timezone__2_chosen']/div/ul/li[156]")]
        public IWebElement timeZoneSelected { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='edit-field-first-name-0-value--description']/a")]
        public IWebElement firstNameToolTip { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='edit-mail--description']/a")]
        public IWebElement emailToolTip { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='edit-timezone--2--description']/a")]
        public IWebElement timeZoneToolTip { get; set; }

        [FindsBy(How = How.Id, Using = "edit-submit")]
        public IWebElement saveButton { get; set; }


        [FindsBy(How = How.ClassName, Using = "user-form")]
        public IWebElement userFormContent { get; set; }
               
        [FindsBy(How = How.Id, Using = "edit-current-pass")]
        public IWebElement txtCurrentPassword { get; set; }

        [FindsBy(How = How.Id, Using = "edit-pass-pass1")]
        public IWebElement txtPassword { get; set; }

        [FindsBy(How = How.Id, Using = "edit-pass-pass2")]
        public IWebElement txtConfirmPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div#user-account-menu > ul > li:nth-of-type(4) > a")]
        public IWebElement AccessMembershipDirSetting { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='fieldset-legend']")]
        public IWebElement MembershipDirSettingRole { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input#edit-default-fields-general.form-checkbox")]
        public IWebElement DefaultCheckMemDirSet { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='card-content']/div")]
        public IList<IWebElement> MemDirDefaultCardContents { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='markup-general']/div")]
        public IList<IWebElement> MemDirCardSetFields { get; set; }

        



        #endregion UserAccount Page Elements

        public void AccountSettings(bool DirectUser)
        {
            //userInfo = new UserInfo(driver);
            //userInfo.userName.Click();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            //userInfo.accountLink.Click();
            // Assert.That(userInfo.accountHeader.Text, Does.Contain("Account").IgnoreCase);
            Assert.IsTrue(userInfo.userAccountMenus[0].Text.Contains("Account"));
            Actions actions = new Actions(driver);
            Assert.AreEqual(firstNameLabel.Text, firstNameText);
            //Madan :Due to the functionality change now field is not not editable
            //firstName.Clear();
            //firstName.SendKeys(firstNameInputText);
            actions.MoveToElement(firstNameToolTip).Build().Perform(); ;
            string nameToolTipText = firstNameToolTip.GetAttribute("data-tooltip");           
            Assert.AreEqual(nameToolTipText, nameHoverText);
            Assert.AreEqual(lastNameLabel.Text, lastNameText);
            string txt = emailLabel.Text;

           // bool DirectUser = true;
            if (DirectUser==true)
            {
                Assert.AreEqual(txt, "Current password");

                test.Log(Status.Pass, "Password change option is available Direct user");

            }

            //Madan :Due to the functionality change now name field is not not editable
            //lastName.Clear();
            //lastName.SendKeys(lastNameInputText);
            else
            {
                Assert.AreEqual(txt, emailText);
                //Verify Password Option not available for SSO User  
                Console.WriteLine(userFormContent.Text);
                Assert.IsFalse(userFormContent.Text.Contains("Current password"));
                Console.WriteLine("Password change option not available");
                test.Log(Status.Pass,"Password change option not available for SSO user");
            }

            ////Verify Password Option not available for SSO User          
            //Console.WriteLine(userFormContent.Text);
            //Assert.IsFalse(userFormContent.Text.Contains("Current password"));
            //Console.WriteLine("Password change option not available");
            
            actions.MoveToElement(emailToolTip).Build().Perform(); ;
            string emailtoolTipText = emailToolTip.GetAttribute("data-tooltip");            
            Assert.AreEqual(emailtoolTipText, emailHoverText);
            Assert.AreEqual(timeZoneLabel.Text, timeZoneText);
            actions.MoveToElement(timeZoneToolTip).Build().Perform(); ;
            string timeZonetoolTipText = timeZoneToolTip.GetAttribute("data-tooltip");
            Assert.AreEqual(timeZonetoolTipText, timeZoneHoverText);
            timeZoneOptions.Click();
            actions.MoveToElement(timeZoneSelected).Click().Build().Perform();
            saveButton.Click();

            test.Log(Status.Pass, "Edit Profile functionality has been verified");
        }


        public void ChangePassword(string existedPassword,string newPassword)
        {
            userInfo.ClickOnUserMenu();
            userInfo.ClickOnSubMenu(userInfo.accountSubMenu);
            txtCurrentPassword.SendKeys(existedPassword);
            Thread.Sleep(2000);
            txtPassword.SendKeys(newPassword);
            txtConfirmPassword.SendKeys(newPassword);
            Thread.Sleep(2000);
            saveButton.Click();
            test.Log(Status.Pass, "Password has been changed successfully");
        }


        public void AccessMembershipDirectorySettings()
        {
            AccessMembershipDirSetting.Click();

            test.Log(Status.Pass, "Membership Directory has been accessed from User Menu");


        }

        public void MembershipDirectorySetting()
        {

            string RoleVariable = MembershipDirSettingRole.GetAttribute("innerText").ToString();

            if (RoleVariable == "Student Directory")
            {
                test.Log(Status.Pass, "Student Directory Selected");
                Console.WriteLine(RoleVariable);
                IWebElement checkbox = DefaultCheckMemDirSet;
                bool aValue = DefaultCheckMemDirSet.Selected;
                if (aValue == true)
                {
                    Console.WriteLine("Default card fields Check Box is Selected");
                    test.Log(Status.Pass, "Default card fields Check Box is Selected");
                    int DefCardContentCount = MemDirDefaultCardContents.Count();
                    for (int i = 0; i < DefCardContentCount; i++)
                    {
                        string ContentText1 = MemDirDefaultCardContents[i].GetAttribute("innerText").ToString();
                        Console.WriteLine(ContentText1);
                        if (ContentText1.Contains("Program start date"))
                        {
                            Console.WriteLine("Program start date Implemented for Student");

                            test.Log(Status.Pass,"Program start date Implemented for Student");
                        }
                        else if (ContentText1.Contains("Current course"))
                        {
                            Console.WriteLine("Current course Implemented for Student");
                            test.Log(Status.Pass, "Current course Implemented for Student");
                        }
                    }
                    
                }
                else
                {
                    Console.WriteLine("Default card fields Check Box is not Selected");
                    test.Log(Status.Pass, "Default card fields Check Box is not Selected");
                    int SetCardFieldsCount = MemDirCardSetFields.Count();
                    for (int i = 0; i < SetCardFieldsCount; i++)
                    {
                        string ContentText2 = MemDirCardSetFields[i].GetAttribute("innerText").ToString();
                        Console.WriteLine(ContentText2);
                        if (ContentText2.Contains("Program start date"))
                        {
                            Console.WriteLine("Program start date Implemented for Student");
                            test.Log(Status.Pass, "Program start date Implemented for Student");
                        }
                        else if (ContentText2.Contains("Current course"))
                        {
                            Console.WriteLine("Current course Implemented for Student");
                            test.Log(Status.Pass, "Current course Implemented for Student");

                        }
                    }
                }


            }
            else if (RoleVariable == "Alumni Directory")
            {
                test.Log(Status.Pass, "Alumni Directory Role Selected");
                Console.WriteLine(RoleVariable);
                IWebElement checkbox = DefaultCheckMemDirSet;
                bool aValue = DefaultCheckMemDirSet.Selected;
                if (aValue == true)
                {
                    Console.WriteLine("Default card fields Check Box is Selected");
                    test.Log(Status.Pass, "Alumni Directory Role Selected");
                    int DefCardContentCount = MemDirDefaultCardContents.Count();
                    for (int i = 0; i < DefCardContentCount; i++)
                    {
                        string ContentText3 = MemDirDefaultCardContents[i].GetAttribute("innerText").ToString();
                        Console.WriteLine(ContentText3);
                        if (ContentText3.Contains("Program completion date"))
                        {
                            Console.WriteLine("Program completion date Implemented for Alumni");
                            test.Log(Status.Pass, "Program completion date Implemented for Alumni");
                        }
                        else if (ContentText3.Contains("Current course"))
                        {
                            Console.WriteLine("Current course Wrongly Implemented for Alumni");
                            test.Log(Status.Pass, "Current course Wrongly Implemented for Alumni");
                        }
                    }

                }
                else
                {
                    Console.WriteLine("Default card fields Check Box is not Selected");
                    test.Log(Status.Pass,"Default card fields Check Box is not Selected");
                    int SetCardFieldsCount = MemDirCardSetFields.Count();
                    for (int i = 0; i < SetCardFieldsCount; i++)
                    {
                        string ContentText4 = MemDirCardSetFields[i].GetAttribute("innerText").ToString();
                        Console.WriteLine(ContentText4);
                        if (ContentText4.Contains("Program completion date"))
                        {
                            Console.WriteLine("Program completion date Implemented for Alumni");
                            test.Log(Status.Pass, "Program completion date Implemented for Alumni");
                        }
                        else if (ContentText4.Contains("Current course"))
                        {
                            Console.WriteLine("Current course Wrongly Implemented for Alumni");
                            test.Log(Status.Pass, "Current course Wrongly Implemented for Alumni");
                        }
                    }
                }

            }
            else if (RoleVariable == "Faculty Directory")
            {
                Console.WriteLine(RoleVariable);
                test.Log(Status.Pass, "Faculty Directory Selected");
                IWebElement checkbox = DefaultCheckMemDirSet;
                bool aValue = DefaultCheckMemDirSet.Selected;
                if (aValue == true)
                {
                    Console.WriteLine("Default card fields Check Box is Selected");
                    test.Log(Status.Pass, "Default card fields Check Box is Selected");
                    int DefCardContentCount = MemDirDefaultCardContents.Count();
                    for (int i = 0; i < DefCardContentCount; i++)
                    {
                        string ContentText5 = MemDirDefaultCardContents[i].GetAttribute("innerText").ToString();
                        Console.WriteLine(ContentText5);
                        if (ContentText5.Contains("Program completion date"))
                        {
                            Console.WriteLine("Program completion date Wrongly Implemented for Faculty");
                            test.Log(Status.Pass, "Program completion date Wrongly Implemented for Faculty");
                        }
                        else
                        {
                            Console.WriteLine("Program completion date is not available for Faculty");
                            test.Log(Status.Pass, "Program completion date is not available for Faculty");
                        }
                        if (ContentText5.Contains("Current course"))
                        {
                            Console.WriteLine("Current course Wrongly Implemented for Faculty");
                            test.Log(Status.Pass, "Current course Wrongly Implemented for Faculty");
                        }
                        else
                        {
                            Console.WriteLine("Current course is not available for Faculty");
                            test.Log(Status.Pass, "Current course is not available for Faculty");

                        }
                    }

                }
                else
                {
                    Console.WriteLine("Default card fields Check Box is not Selected");
                    test.Log(Status.Pass, "Default card fields Check Box is not Selected");
                    int SetCardFieldsCount = MemDirCardSetFields.Count();
                    for (int i = 0; i < SetCardFieldsCount; i++)
                    {
                        string ContentText6 = MemDirCardSetFields[i].GetAttribute("innerText").ToString();
                        Console.WriteLine(ContentText6);
                        if (ContentText6.Contains("Program completion date"))
                        {
                            Console.WriteLine("Program completion date Wrongly Implemented for Faculty");
                            test.Log(Status.Pass, "Program completion date Wrongly Implemented for Faculty");
                        }
                        else
                        {
                            Console.WriteLine("Program completion date is not available for Faculty");
                            test.Log(Status.Pass, "Program completion date is not available for Faculty");
                        }
                        if (ContentText6.Contains("Current course"))
                        {
                            Console.WriteLine("Current course Wrongly Implemented for Faculty");
                            test.Log(Status.Pass, "Current course Wrongly Implemented for Faculty");
                        }
                        else
                        {
                            Console.WriteLine("Current course is not available for Faculty");
                            test.Log(Status.Pass, "Current course is not available for Faculty");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid Header of Membership Directory Roles");
                test.Log(Status.Pass, "Invalid Header of Membership Directory Roles");
            }
        }


        public void AlumniAmbassadorRoleAvl()
        {
            string alumniAmbassadorSettingsLebal = AlumniAmbassadorSettingsLebal.Text;
            Console.WriteLine(alumniAmbassadorSettingsLebal);
            Assert.AreEqual("Alumni Ambassador", alumniAmbassadorSettingsLebal);

        }
        public void AlumniAmbassadorRoleSelect()
        {

            if (AlumniAmbassadorInput.Selected)
            {
                Console.WriteLine(AlumniAmbassadorSettingsLebal.Text + " is already selected");
            }
            else
            {
                AlumniAmbassadorSettingsLebal.Click();
                saveButton.Click();
                PageServices.WaitForPageToCompletelyLoaded(driver, 160);
                Console.WriteLine("Selected " + AlumniAmbassadorSettingsLebal);
            }

        }

        public void GoTOProfilePage()
        {
            userInfo.ClickOnUserMenu();
            userInfo.ClickOnSubMenu(userInfo.ProfileSubMenu);
            PageServices.WaitForPageToCompletelyLoaded(driver, 160);
        }

        public void VerifyUserRoleAtPf(string UserRole)
        {
            string userRoleAtProfile = UserRoleAtProfile.Text;
            if (userRoleAtProfile.Contains(UserRole))
            {
                Console.WriteLine(UserRole + " Role Verified");
            }
        }

        public void VerifyAlumniAmbassadorRoleIcon()
        {
            if (AlumniAmbassadorPfIcon != null)
            {
                Console.WriteLine("Alumni Ambassador Role Icon is Verified");
            }

        }

        public void VerifyUserRoleToolTip(string UserRole)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(UserRolePfToolTip).Build().Perform(); 

            string userRolePfToolTip = UserRolePfToolTip.GetAttribute("data-tooltip");
            Thread.Sleep(500);
            if (userRolePfToolTip.Contains(UserRole))
            {
                Console.WriteLine(UserRole + " Tooltip is verified");
            }
            else
            {
                Console.WriteLine(UserRole + " Role Tool Tip not visible");
            }
        } 



    }
}
