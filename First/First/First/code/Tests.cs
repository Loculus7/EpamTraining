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
    [TestClass]
    public class Tests
    {
        IWebDriver driver;

        [TestInitialize]
        public void Initialize()
        {
            //создание драйвера для Chrome
            driver = First.Tools.CreateChromeDriver();

            //создание драйвераа для FireFox
            //driver = First.Tools.CreateFireFoxDriver();
        }
                
        [TestCleanup]
        public void TearDown()
        {
            First.Tools.DriverQuit(driver);
        }

        [TestMethod]
        public void Test_00001()
        {
            //Test name - Google Mail Check
            //Scenario:
            //1.	Log into your account; 
            //2.	Verify that login was successful; 
            //3.	Start creating a new email;
            //4.	Fill in the fields of addressee, topic and contents of the email;
            //5.	Save the email in Drafts folder
            //6.	Navigate to Drafts folder and verify that the email is displayed there;
            //7.	View the contents of the email and verify that they correspond to the information, provided during its creation;
            //8.	Send the email;
            //9.	Navigate to Drafts folder and verify that the email is not displayed any more;
            //10.	Navigate to Sent folder and verify that the email is displayed there;
            //11.	Log out of your account.

            //driver.Manage().Window.Maximize();
            
            //выставляю максимальное ожидание загрузки страницы
            First.Tools.SetCooldown(driver, 30);

            //заходим на gmail.com
            First.Tools.NavigateToBaseURL(driver);

            //ввожу логин-данные
            First.LoginScreen.EnterLoginData(driver);

            //Верефицирую логин
            First.LoginScreen.VerifyLogin(driver);

            //Создаю новое письмо, заполняю его поля и закрываю, 
            //тем самым оставляя в черновиках
            First.MailBox.CreateTestEmailInDrafts(driver);
            First.MailBox.VerifyTestEmailMissing(driver);

            //перехожу в черновики
            First.MailBox.GoInToDrafts(driver);
            //Thread.Sleep(500);

            //нахожу созданный черновик и проверяю содержимое, отправляю черновик адресату (себе)
            //и проверяю, удалился ли черновик
            First.MailBox.VerifyAndSendDraftOfATestEmail(driver);

            //перехожу в "отправленные" и проверяю наличие экземпляра отосланного письма
            First.MailBox.GoToSent(driver);
            First.MailBox.VerifyTestEmail(driver);

            //Захожу в "Входящие"
            First.MailBox.GoToInbox(driver);

            //Удаляю тестовое письмо
            //First.MailBox.DeleteTestEmail(driver);

            //Возвращаюсь во Входящие
            //First.MailBox.GoToInbox(driver);

            //Разлогиниваюсь
            First.MailBox.LogOut(driver);

            //Закрываем браузер
            First.Tools.DriverQuit(driver);
        }
        
        [TestMethod]
        public void Test_00002() 
        {
            //Test name - Google Mail Starred Check
            //Scenario:
            //1.	Log into your account; 
            //2.	Verify that login was successful; 
            //3.	Start creating a new email;
            //4.	Fill in the fields of addressee, topic and contents of the email;
            //5.	Send the email to yourself;
            //6.    Mark the email as Starred;
            //7.   	Navigate to Starred folder and verify that the email is displayed there;
            //8.    Unmark the email as starred;
            //9.    Verify that the email is not displayed in the Starred folfder;
            //10.   Log out of your account.

            //выставляю максимальное ожидание загрузки страницы
            First.Tools.SetCooldown(driver, 30);

            //1.заходим на gmail.com
            First.Tools.NavigateToBaseURL(driver);

            //ввожу логин-данные
            First.LoginScreen.EnterLoginData(driver);

            //Верефицирую логин
            First.LoginScreen.VerifyLogin(driver);

            //Перехожу во "Входящие"
            First.MailBox.GoToInbox(driver);

            //Создаю тестовое письмо, если его нету и отправляю его себе
            try 
            {
                Assert.AreEqual(true, driver.FindElement(By.XPath("*//div[@class='y6']//span[contains(text(),'test email')]")).Enabled);
            }
            catch (NoSuchElementException)
            {
                First.MailBox.CreateTestEmailInInbox(driver);
            }

            //Нахожу тестовое письмо и помечаю его
            First.MailBox.FindTestEmailInInbox(driver);
            First.MailBox.MarkTestEmailAsStarred(driver);

            //Перехожу в Помеченные
            First.MailBox.GoToStarred(driver);
            Thread.Sleep(1000);

            //Верефицирую тестовое письмо в Помеченные
            First.MailBox.VerifyTestEmail(driver);

            //Снимаю пометку
            First.MailBox.UnmarkTestEmailAsStarred(driver);

            //Проверяю отсутствие письма в Помеченные
            First.MailBox.VerifyTestEmailMissing(driver);

            //Разлогиниваюсь
            Thread.Sleep(1000);
            First.MailBox.LogOut(driver);
        }
    }
}
