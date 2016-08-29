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
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace First
{
    class MailBox
    {
        public static void CreateTestEmailInDrafts(IWebDriver driver) {
            driver.FindElement(By.CssSelector("div[class='T-I J-J5-Ji T-I-KE L3'][role='button'][tabindex='0'][gh='cm']")).Click();
            driver.FindElement(By.CssSelector("[rows='1'][class='vO'][name='to']")).Clear();
            driver.FindElement(By.CssSelector("[rows='1'][class='vO'][name='to']")).SendKeys("primarelegione@gmail.com");
            driver.FindElement(By.CssSelector("input[name='subjectbox'][class='aoT']")).Clear();
            driver.FindElement(By.CssSelector("input[name='subjectbox'][class='aoT']")).SendKeys("test email");
            driver.FindElement(By.CssSelector("div[class='Am Al editable LW-avf'][hidefocus='true'][aria-label='Тело письма']")).Clear();
            driver.FindElement(By.CssSelector("div[class='Am Al editable LW-avf'][hidefocus='true'][aria-label='Тело письма']")).SendKeys("It's a test email.");
            driver.FindElement(By.CssSelector("img[class='Ha'][alt='Закрыть'][aria-label='Сохранить и закрыть']")).Click();
            return;
        }

        public static void GoInToDrafts(IWebDriver driver) {
            driver.FindElement(By.CssSelector("a[href='https://mail.google.com/mail/u/0/#drafts']")).Click();
            Assert.AreEqual(true, driver.FindElement(By.XPath("*//div[@class='nH nn']")).Enabled);
            return;
        }

        public static void VerifyAndSendDraftOfATestEmail(IWebDriver driver)
        {
            Assert.AreEqual(true, driver.FindElement(By.XPath("*//div[@class='y6']//span[contains(text(),'test email')]")).Enabled);
            driver.FindElement(By.XPath("*//div[@class='y6']//span[contains(text(),'test email')]")).Click();
            //Thread.Sleep(1000);
            Assert.AreEqual(true, driver.FindElement(By.Name("from")).GetAttribute("Value") == "primarelegione@gmail.com");
            Assert.AreEqual(true, driver.FindElement(By.Name("subject")).GetAttribute("Value") == "test email");
            Assert.IsTrue(driver.FindElement(By.XPath("*//div[@class='Am Al editable LW-avf'][@hidefocus='true'][@aria-label='Тело письма']")).Text.Contains("It's a test email."));
            driver.FindElement(By.XPath("*//div[contains(text(),'Отправить')]")).Click();
            driver.FindElement(By.CssSelector("a[href='https://mail.google.com/mail/u/0/#drafts']")).Click();
            Assert.AreEqual(true, driver.FindElement(By.XPath("*//div[@class='nH nn']")).Enabled);            
        }

        public static void GoToSent(IWebDriver driver) {
            driver.FindElement(By.CssSelector("a[href='https://mail.google.com/mail/u/0/#sent']")).Click();
            Assert.AreEqual(true, driver.FindElement(By.XPath("*//div[@class='Tm aeJ']")).Enabled);
            return;
        }

        public static void VerifyTestEmail(IWebDriver driver) {
            Assert.AreEqual(true, driver.FindElement(By.XPath("*//div[@class='y6']//span[contains(text(),'test email')]")).Enabled);
            return;
        }

        public static bool VerifyTestEmailMissing(IWebDriver driver)
        {
            try
            {
                driver.FindElement(By.XPath("*//div[@class='y6']//span[contains(text(),'test email')]"));
                return false;
            }
            catch (NoSuchElementException)
            {
                return true;
            }
        }

        public static void LogOut(IWebDriver driver) {
            driver.FindElement(By.CssSelector("a[href='https://accounts.google.com/SignOutOptions?hl=ru&continue=https://mail.google.com/mail&service=mail']")).Click();
            Assert.AreEqual(true, driver.FindElement(By.XPath("*//div[@class='gb_gb gb_ga gb_g']//div[@class='gb_sb']//a[@class='gb_Fa gb_Ce gb_Ke gb_rb']")).Enabled);
            Thread.Sleep(500);
            driver.FindElement(By.XPath("*//div[@class='gb_gb gb_ga gb_g']//div[@class='gb_sb']//a[@class='gb_Fa gb_Ce gb_Ke gb_rb']")).Click();
            return;
        }

        public static void GoToInbox(IWebDriver driver)
        {
            driver.FindElement(By.CssSelector("a[href='https://mail.google.com/mail/u/0/#inbox']")).Click();
            Assert.AreEqual(true, driver.FindElement(By.XPath("*//div[@class='Tm aeJ']")).Enabled);
            return;
        }

        public static void CreateTestEmailInInbox(IWebDriver driver)
        {
            driver.FindElement(By.CssSelector("div[class='T-I J-J5-Ji T-I-KE L3'][role='button'][tabindex='0'][gh='cm']")).Click();
            driver.FindElement(By.CssSelector("[rows='1'][class='vO'][name='to']")).Clear();
            driver.FindElement(By.CssSelector("[rows='1'][class='vO'][name='to']")).SendKeys("primarelegione@gmail.com");
            driver.FindElement(By.CssSelector("input[name='subjectbox'][class='aoT']")).Clear();
            driver.FindElement(By.CssSelector("input[name='subjectbox'][class='aoT']")).SendKeys("test email");
            driver.FindElement(By.CssSelector("div[class='Am Al editable LW-avf'][hidefocus='true'][aria-label='Тело письма']")).Clear();
            driver.FindElement(By.CssSelector("div[class='Am Al editable LW-avf'][hidefocus='true'][aria-label='Тело письма']")).SendKeys("It's a test email.");
            driver.FindElement(By.XPath("*//div[contains(text(),'Отправить')]")).Click();
            return;
        }

        public static void FindTestEmailInInbox(IWebDriver driver) 
        {
            //driver.FindElement(By.XPath("*//input[contains(aria-label(), 'Поиск')]")).SendKeys("test email");
            driver.FindElement(By.Id("gbqfq")).SendKeys("test email");
            driver.FindElement(By.Id("gbqfb")).Click();
        }

        public static void MarkTestEmailAsStarred(IWebDriver driver) 
        {
            driver.FindElement(By.XPath("//span[@title='Не помечено']")).Click();
            return;
        }

        public static void UnmarkTestEmailAsStarred(IWebDriver driver)
        {
            driver.FindElement(By.XPath("//span[@aria-label='Помеченные']")).Click();
            return;
        }

        public static void GoToStarred(IWebDriver driver)
        {
            driver.FindElement(By.CssSelector("a[href='https://mail.google.com/mail/u/0/#starred']")).Click();
            driver.Navigate().Refresh();
            return;
        }

        public static void DeleteTestEmail(IWebDriver driver)
        {
            //new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementExists((By.XPath("*//tr[@class='aAA J-KU-Jg J-KU-Jg-K9']"))));
            driver.Navigate().Refresh();
            driver.FindElement(By.XPath("*//div[@class='y6']//span[contains(text(),'test email')]")).Click();
            //driver.Navigate().Refresh();
            //driver.FindElement(By.XPath("//div[@aria-label='Удалить']")).Click();
            driver.SwitchTo().Frame("canvas_frame");
            driver.FindElements(By.XPath("//div[contains(aria-label(),'Удалить')"))[1].Click();
            return;
        }
    }
}
