using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.Diagnostics;

namespace First
{
    class LoginScreen
    {
        public static void EnterLoginData(IWebDriver driver) {
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys("primarelegione@gmail.com");
            driver.FindElement(By.Id("next")).Click();
            driver.FindElement(By.Id("Passwd")).SendKeys("primare7");
            driver.FindElement(By.Id("signIn")).Click();
            return;
        }

        public static void VerifyLogin(IWebDriver driver) {
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("div[class='T-I J-J5-Ji T-I-KE L3'][role='button'][tabindex='0'][gh='cm']")).Displayed);
            return;
        }
    }
}
