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

            // Check if running in GitHub Actions (CI environment)
            bool isRunningInGitHubActions = Environment.GetEnvironmentVariable("GITHUB_ACTIONS")?.ToLower() == "true";

            switch (browser)
            {
                case "chrome":
                    // Set up WebDriverManager for Chrome
                    new DriverManager().SetUpDriver(new ChromeConfig());

                    ChromeOptions options = new ChromeOptions();
                    options.AddArgument("no-sandbox");

                    if (isRunningInGitHubActions)
                    {
                        // GitHub Actions configuration - headless
                        options.AddArgument("--headless");
                        options.AddArgument("--disable-gpu");
                        options.AddArgument("--window-size=1920,1080");
                    }
                    else
                    {
                        // Local development configuration - visible browser
                        // You can add any local-specific options here
                    }

                    driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(3));
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