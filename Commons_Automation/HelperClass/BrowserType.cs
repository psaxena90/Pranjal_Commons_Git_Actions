using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;

namespace Commons_Automation
{
    public  class BrowserType
    {
        public static IWebDriver SelectBrowser(string browser)
        {
            IWebDriver driver;
            string binPath = System.AppDomain.CurrentDomain.BaseDirectory;            
            switch (browser)
            {
                case "chrome":
                    ChromeOptions options = new ChromeOptions();
                    options.AddArgument("no-sandbox");
                    driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(3));
                    // driver = new ChromeDriver(options);
                    driver.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(90));
                    break;

                case "iexplorer":
                    driver = new InternetExplorerDriver();
                    break;                
                default:
                    driver = new FirefoxDriver();
                    break;
            }
            return driver;
        }
    }
}
