using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Commons_Automation
{
  public class PageServices
    {
        static string errorPath;
        static string reportPath;
        //private static string SQLconnString = ConfigurationManager.ConnectionStrings["ncuqadb"].ConnectionString;      
        private static string SQLconnString = TestContext.Parameters.Get("ncuqadb").ToString();
        #region SQL Gets

        public static string GetProjectLearnerIDFromSQLUsingApplicantID(string applicantID)
        {
            string sqlStatement = string.Format("select  [learner_id] from applicant_info where  applicant_id='{0}'", applicantID);
            Console.WriteLine(sqlStatement);
            Thread.Sleep(3000);
            return CreateSQLConnection_ReturnString(sqlStatement);
        }  


        private static string CreateSQLConnection_ReturnString(string sqlStatement)
        {
            using (var conn = new SqlConnection(SQLconnString))
            using (var cmd = new SqlCommand(sqlStatement, conn))
            {
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        // return dr.GetInt32(0).ToString();
                        return dr.GetString(0);

                    }
                    else
                    {
                        return "Test failed. The string was not found in the database.";
                    }
                }

            }
        }

        private static string CreateSQLConnection_ReturnGuid(string sqlStatement)
        {
            using (var conn = new SqlConnection(SQLconnString))
            using (var cmd = new SqlCommand(sqlStatement, conn))
            {
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        return dr.GetGuid(0).ToString();
                    }
                    else
                    {
                        return "Test failed. The string was not found in the database.";
                    }
                }

            }
        }

        private static int CreateSQLConnection_ReturnInt(string sqlStatement)
        {
            using (var conn = new SqlConnection(SQLconnString))
            using (var cmd = new SqlCommand(sqlStatement, conn))
            {
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        //return dr.GetString(0);
                        return dr.GetInt32(0);
                    }
                    else
                    {
                        return 0;
                    }
                }

            }

        }

        #endregion

        #region SQL Update

        public static void UpdateStartDateInLearner_coursesTable(string learnerID,string startDate)
        {
                     
            string updateString = @"BEGIN TRAN UPDATE [dbo].[learner_courses] set start_date ='" + startDate + "' where learner_id='" + learnerID + "' COMMIT TRAN;";
            using (var conn = new SqlConnection(SQLconnString))
            using (var cmd = new SqlCommand(updateString, conn))
            {

                try
                {
                    conn.Open();

                    cmd.CommandText = updateString;
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    // Close the connection
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }

            }
        }

        #endregion    
        

        public static void WaitForPageToCompletelyLoaded(IWebDriver driver,int timeOutSeconds)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutSeconds)).Until(
              d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public static void ScrollPageUptoBottom(IWebDriver driver)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
        }

        public static void ScrollPageUptoTop(IWebDriver driver)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, -document.body.scrollHeight)");
        }

        public static IWebElement ExpandRootElement(IWebElement element,IWebDriver driver)
        {
            IWebElement ele = (IWebElement)((IJavaScriptExecutor)driver)
                .ExecuteScript("return arguments[0].shadowRoot", element);
            return ele;
        }

        public static void ScrollIntoElement(IWebDriver driver, IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", element);
        }


        public static void ClickButtonByJavaScript(IWebDriver driver, IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);

                 
        }
        public static string GetProjectPath()
        {
            string projectPath = TestContext.CurrentContext.TestDirectory;
            String[] extract = Regex.Split(projectPath, "bin");  //split it in bin
            String main = extract[0].TrimEnd('\\');
            string TestProjectPath = main.ToString();
            Console.WriteLine(TestProjectPath);
            return TestProjectPath;
        }

        public static Tuple<string, string> SetReportAndLogPath()
        {
            bool generateLocal = Boolean.Parse(TestContext.Parameters.Get("GenerateLocal").Trim());
            if (generateLocal)
            {
                errorPath = GetProjectPath() + TestContext.Parameters.Get("ErrorLog").Trim();
                reportPath = GetProjectPath() + TestContext.Parameters.Get("ReportPath").Trim();
            }
            else
            {
                errorPath = TestContext.Parameters.Get("SharedErrorLog").Trim();
                reportPath = TestContext.Parameters.Get("SharedReportPath").Trim();
            }

            return new Tuple<string, string>(errorPath, reportPath);
        }

        #region Random String Generator
        public static class Randomizr
        {
            //*Note that there is a nested class here in Randomizr and also member methods.
            private static Random _random = new Random();

            public static string RandomString(int size)
            {
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < size; i++)
                {
                    //26 letters in the alphabet, ascii + 65 for the capital letters
                    builder.Append(Convert.ToChar(Convert.ToInt32(Math.Floor(26 * _random.NextDouble() + 65))));
                }
                return builder.ToString();
            }


            // End Number should be upper limit + 1
            public static string RangeString(int startnumber, int endnumber)
            {
                System.Random randNum = new System.Random();
                int myRandomNumber = randNum.Next(startnumber, endnumber);
                return myRandomNumber.ToString();
            }
        }
        #endregion Random String Generator
    }
}
