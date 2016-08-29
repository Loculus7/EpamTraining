using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Threading;
using System.Diagnostics;

namespace First
{
    class Tools
    {
        public static IWebDriver CreateChromeDriver() {
            IWebDriver driver = new ChromeDriver();
            return(driver);
        }

        public static IWebDriver CreateFireFoxDriver()
        {
            IWebDriver driver = new FirefoxDriver();
            return (driver);
        }

        public static void SetCooldown(IWebDriver driver, int seconds) {
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(seconds));
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(seconds));
            driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(seconds));
            return;
        }

        public static void NavigateToBaseURL(IWebDriver driver) {
            driver.Navigate().GoToUrl("http://mail.google.com/");
            return;
        }

        public static void DriverQuit(IWebDriver driver) {
            if (driver != null)
                driver.Quit();
            return;
        }
                
    }
}
