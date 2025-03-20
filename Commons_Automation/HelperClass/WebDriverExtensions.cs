using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using SeleniumExtras.PageObjects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Commons_Automation
{

    static class WebDriverExtensions
    {

        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));

            }
            return driver.FindElement(by);
        }

        public static IWebElement WaitUntilFindElementClickable(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
            }
            return driver.FindElement(by);
        }

        public static void WaitForReady(this IWebDriver driver, int timeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(dr => (bool)((IJavaScriptExecutor)driver).
                    ExecuteScript("return jQuery.active == 0"));
        }

        public static IWebElement WaitUntilElementVisible(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                try
                {
                    return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                }

                catch (Exception e)
                {
                    Console.WriteLine("Element is not found.");
                    throw (e);
                }

            }
            return driver.FindElement(by);
        }

        public static bool WaitUntilElementInVisible(this IWebDriver driver,By element, int timeoutInSeconds)
        {
           // bool status;
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                try
                {
                    return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(element));
                }

                catch (Exception e)
                {
                    Console.WriteLine("Element is not found.");
                    throw (e);
                }

            }
            return true;
        }

        public static IWebElement WaitUntilElementClickable(this IWebDriver driver, IWebElement element, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                try
                {
                    return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
                }             
                catch (Exception e)
                {

                   Console.WriteLine("Element is not found.");
                   throw (e);
               
            }

            }
            return element;
        }

       

        public static ReadOnlyCollection<IWebElement> FindElements(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => (drv.FindElements(by).Count > 0) ? drv.FindElements(by) : null);
            }
            return driver.FindElements(by);
        }

        public static string GetTextFromTextBox(this IWebElement element)
        {
            return element.GetAttribute("value");
        }
        public static string GetSelectedValueFromDropDown(this IWebElement element)
        {
            return new SelectElement(element).AllSelectedOptions.SingleOrDefault().Text;

        }
        public static void EnterText(this IWebElement element, string value)
        {
            element.Clear();
            element.SendKeys(value);
        }

        public static void ClickButton(this IWebElement element)
        {
            element.Click();
        }

        public static void SubmitButton(this IWebElement element)
        {
            element.Submit();
        }
        public static void SelectFromDropdown_ByIndex(this IWebElement element, int index)
        {
            new SelectElement(element).SelectByIndex(index);
        }

        public static void SelectFromDropdown_ByValue(this IWebElement element, string value)
        {
            new SelectElement(element).SelectByValue(value);
        }

        public static void SelectFromDropdown_ByText(this IWebElement element, string value)
        {
            new SelectElement(element).SelectByText(value);
        }
    }
}
