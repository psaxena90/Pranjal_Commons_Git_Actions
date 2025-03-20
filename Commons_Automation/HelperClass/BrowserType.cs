using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Commons_Automation
{
    public class BrowserType
    {
        public static IWebDriver SelectBrowser(string browser)
        {
            IWebDriver driver;
            string binPath = System.AppDomain.CurrentDomain.BaseDirectory;
            switch (browser)
            {
                case "chrome":
                    // Set up WebDriverManager for Chrome
                    new DriverManager().SetUpDriver(new ChromeConfig());

                    // Configure Chrome options for headless mode
                    ChromeOptions options = new ChromeOptions();
                    options.AddArgument("--headless"); // Enable headless mode
                    options.AddArgument("--no-sandbox");
                    options.AddArgument("--disable-gpu"); // Recommended for headless
                    options.AddArgument("--window-size=1920,1080"); // Set window size

                    // Initialize ChromeDriver with WebDriverManager (no need to specify path)
                    driver = new ChromeDriver(options);
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