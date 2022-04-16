using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using OpenQA.Selenium;

using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver;
        //IWebDriver driver = new ChromeDriver(@"C:\Users\parij\Documents\QA-Automationtest");

        [TestMethod]
        public void demoqaautomationpracticebooks()
        {
            IWebDriver driver = new ChromeDriver(@"C:\Users\parij\Documents\QA-Automationtest");
            driver.Url = "https://demoqa.com/login";
            Thread.Sleep(1000);
            driver.Manage().Window.Maximize();
            IWebElement com1 = driver.FindElement(By.Id("userName"));
            Boolean a = com1.Displayed;
            IWebElement com2 = driver.FindElement(By.Id("password"));
            Boolean b = com1.Selected;
            Console.WriteLine(b);
            String title = driver.Title;
            Console.WriteLine(title);
            // driver.FindElements(By.LinkText("google"));


        }

        [TestMethod]
        public void demoqaautomationpracticeform1()
        {
            IWebDriver driver = new ChromeDriver(@"C:\Users\parij\Documents\QA-Automationtest");
            driver.Url = "https://demoqa.com/books";
            Thread.Sleep(1000);
            driver.Manage().Window.Maximize();
            //IWebElement element = driver.FindElement(By.Id("sample"));
            //Console.WriteLine(element);

            //ReadOnlyCollection<IWebElement> elements = driver.FindElements(By.Id("sample"));
            //Console.WriteLine(elements.Count);

            ReadOnlyCollection<IWebElement> elements = driver.FindElements(By.TagName("a"));
            Console.WriteLine(elements.Count);

            foreach (var item in elements)
            {
                Console.WriteLine(item.Text);
            }
        }

        
            [TestMethod]
        public void demoqaautomationpracticeform()
        {
            IWebDriver driver = new ChromeDriver(@"C:\Users\parij\Documents\QA-Automationtest");
            driver.Url = "https://google.ca";
            Thread.Sleep(1000);
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Name("q")).SendKeys("institute of IT Training" + Keys.Enter);
            //Thread.Sleep(1000);
            //driver.Navigate().Refresh();
           String title = driver.Title;
           Console.WriteLine(title);
           Console.Read();
           // string pagesource = driver.PageSource;
               //driver.Close();
            //driver.Quit();
        }

        [TestMethod]
        public void demoqaautomationpractice()
        {

            IWebDriver driver = new ChromeDriver(@"C:\Users\parij\Documents\QA-Automationtest");
            driver.Url = "https://demoqa.com/automation-practice-form";

            Thread.Sleep(1000);

            driver.Manage().Window.Maximize();

            driver.FindElement(By.Id("firstName")).SendKeys("pooja");

            driver.FindElement(By.Id("lastName")).SendKeys("ajh");

            driver.FindElement(By.Id("userEmail")).SendKeys("QA123@abc.com");

            driver.FindElement(By.XPath("//*[@id='genterWrapper']/div[2]/div[2]/label")).Click();

            driver.FindElement(By.Id("dateOfBirthInput")).Clear();

            driver.FindElement(By.XPath("//*[@id='dateOfBirthInput']")).SendKeys("3 dec 1986");
            
            driver.FindElement(By.Id("subjectsInput")).SendKeys("akjhdskfjsgdj");

            driver.FindElement(By.XPath("//*[@id='hobbiesWrapper']/div[2]/div[1]/label")).Click();

            driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div[2]/div[1]/form/div[9]/div[2]/textarea")).SendKeys("1-2-3-ksjdfhkj");
            
            driver.FindElement(By.Id("submit")).Click();
        }

        [TestMethod]

        public void practiceformelements()
        {
            IWebDriver driver = new ChromeDriver(@"C:\Users\parij\Documents\QA-Automationtest");
            
            driver.Url = "https://demoqa.com/automation-practice-form";

            Thread.Sleep(1000);

            driver.Manage().Window.Maximize();

            Thread.Sleep(-10000);
            
            driver.FindElement(By.XPath("//*[@id='app']/div/div/div[2]/div[1]/div/div/div[1]/span/div/div[1]")).Click();
            
            driver.FindElement(By.Id("firstName")).SendKeys("vidya");
            
            driver.FindElement(By.Id("lastName")).SendKeys("sri");
            
            //enter email
            driver.FindElement(By.Id("userEmail")).SendKeys("sri");

            //enter subject 
            driver.FindElement(By.Id("//*[@id='subjectsContainer']/div/div[1]")).SendKeys("sri");

            //submit the form
            driver.FindElement(By.Id("submit")).Click();
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\C:\\Users\\parij\\Documents\\QA-Automationtest\\Inputdata_Automation.csv", "Inputdata_Automation#csv", DataAccessMethod.Sequential)]

        public void Travelagileway()
        {
            try
            { 
            driver = new ChromeDriver(@"C:\Users\parij\Documents\QA-Automationtest");
           
            driver.Url = TestContext.DataRow["url"].ToString();
            
            driver.Manage().Window.Maximize();
            
            string UsernameText = TestContext.DataRow["username"].ToString();
            string PasswordText = TestContext.DataRow["pass"].ToString();
            
            driver.FindElement(By.Id("username")).SendKeys(UsernameText);
            
            driver.FindElement(By.Id("password")).SendKeys(PasswordText);
            
            driver.FindElement(By.Id("remember_me")).Click();
            
            driver.FindElement(By.Name("commit")).Click();
            

                if (driver.FindElement(By.LinkText("Sign off")).Displayed)
                {
                    Console.WriteLine("Sign in succesfull: Login-PASS");
                }
                else
                {
                    Console.WriteLine("Sign in unsuccesfull: Login-FAIL");
                    Assert.Fail("Sign in unsuccesfull: Login-FAIL");
                }
            }
            catch (Exception errorMessage)
            {
                Console.WriteLine("Found an Error" + errorMessage);
                Assert.Fail("Error on code" + errorMessage);

            }


        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\C:\\Users\\parij\\Documents\\QA-Automationtest\\Inputdata_Automation.csv", "Inputdata_Automation#csv", DataAccessMethod.Sequential)]

        //RETURN scenario
        public void ReturnScenario()
        {

            this.Travelagileway();

            //Return radio button
            driver.FindElement(By.XPath("//*[@id='container']/form/table[1]/tbody/tr[1]/td[2]/input[1]")).Click();

            string fromport = TestContext.DataRow["from"].ToString();
            string toport = TestContext.DataRow["to"].ToString();
            string departdate = TestContext.DataRow["departdate"].ToString();
            string departmonth = TestContext.DataRow["departmonth"].ToString();
            string returndate = TestContext.DataRow["returndate"].ToString();
            string returnmonth = TestContext.DataRow["returnmonth"].ToString();

            //Origin
            driver.FindElement(By.Name("fromPort")).SendKeys(fromport);

            // Desitination
            driver.FindElement(By.Name("toPort")).SendKeys(toport);

            // departing date
            driver.FindElement(By.Id("departDay")).SendKeys(departdate);

            // departing month
            driver.FindElement(By.Id("departMonth")).SendKeys(departmonth);

            //Returning date
            driver.FindElement(By.Id("returnDay")).SendKeys(returndate);

            //Returning month
            driver.FindElement(By.Id("returnMonth")).SendKeys(returnmonth);

            //Time
            driver.FindElement(By.XPath("//*[@id='flights']/tbody/tr[2]/th/input")).Click();

            //Continue button
            driver.FindElement(By.XPath("/html/body/div/form/input")).Click();

            string firstname = TestContext.DataRow["firstname"].ToString();
            string lastname = TestContext.DataRow["lastname"].ToString();

            //passenger firstname
            driver.FindElement(By.Name("passengerFirstName")).SendKeys(firstname);

            //passenger lastname
            driver.FindElement(By.Name("passengerLastName")).SendKeys(lastname);

            //Next button
            driver.FindElement(By.XPath("//*[@id='container']/form/input[3]")).Click();

            //Card type radio button
            driver.FindElement(By.XPath("/html/body/div/form/table/tbody/tr[1]/td[2]/input[1]")).Click();

            string cardnumber = TestContext.DataRow["cardnumber"].ToString();
            string cardexpirymonth = TestContext.DataRow["expirymonth"].ToString();
            string cardexpiryyear = TestContext.DataRow["expiryyear"].ToString();

            //Card number
            driver.FindElement(By.Name("card_number")).SendKeys(cardnumber);

            //card expiry month
            driver.FindElement(By.Name("expiry_month")).SendKeys(cardexpirymonth);

            //card expiry year
            driver.FindElement(By.Name("expiry_year")).SendKeys(cardexpiryyear);

            //paynow button
            driver.FindElement(By.XPath("/html/body/div/form/p/input")).Click();


        }


        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\C:\\Users\\parij\\Documents\\QA-Automationtest\\Inputdata_Automation.csv", "Inputdata_Automation#csv", DataAccessMethod.Sequential)]

        //one way scenario
        public void OneWayScenario()
        {

           this.Travelagileway();

            //one way radio button
            driver.FindElement(By.XPath("//*[@id='container']/form/table[1]/tbody/tr[1]/td[2]/input[2]")).Click();

            string fromport = TestContext.DataRow["from"].ToString();
            string toport = TestContext.DataRow["to"].ToString();
            string departdate = TestContext.DataRow["departdate"].ToString();
            string departmonth = TestContext.DataRow["departmonth"].ToString();

            //Origin
            driver.FindElement(By.Name("fromPort")).SendKeys(fromport);

            // Desitination
            driver.FindElement(By.Name("toPort")).SendKeys(toport);

            // departing date
            driver.FindElement(By.Id("departDay")).SendKeys(departdate);

            // departing month
            driver.FindElement(By.Id("departMonth")).SendKeys(departmonth);

           //Time
            driver.FindElement(By.XPath("//*[@id='flights']/tbody/tr[2]/th/input")).Click();


            //Continue button
            driver.FindElement(By.XPath("/html/body/div/form/input")).Click();

            string firstname = TestContext.DataRow["firstname"].ToString();
            string lastname = TestContext.DataRow["lastname"].ToString();

            //passenger firstname
            driver.FindElement(By.Name("passengerFirstName")).SendKeys(firstname);

            //passenger lastname
            driver.FindElement(By.Name("passengerLastName")).SendKeys(lastname);

            //Next button
            driver.FindElement(By.XPath("//*[@id='container']/form/input[3]")).Click();

            //Card type radio button
            driver.FindElement(By.XPath("/html/body/div/form/table/tbody/tr[1]/td[2]/input[2]")).Click();

            string cardnumber = TestContext.DataRow["cardnumber"].ToString();
            string cardexpirymonth = TestContext.DataRow["expirymonth"].ToString();
            string cardexpiryyear = TestContext.DataRow["expiryyear"].ToString();

            //Card number
            driver.FindElement(By.Name("card_number")).SendKeys("123456787658765");

            //card expiry month
            driver.FindElement(By.Name("expiry_month")).SendKeys("05");

            //card expiry year
            driver.FindElement(By.Name("expiry_year")).SendKeys("2015");

            //paynow button
            driver.FindElement(By.XPath("/html/body/div/form/p/input")).Click();
            
        }



        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\C:\\Users\\parij\\Documents\\QA-Automationtest\\inputdata_pandell project.csv", "inputdata_pandell project#csv", DataAccessMethod.Sequential)]
        public void pandellproject()
        {
            driver = new ChromeDriver(@"C:\Users\parij\Documents\QA-Automationtest\Newchromedriver\chromedriver_win32 (1)");


            driver.Url = "https://qatest.pandell.com/"; //TestContext.DataRow["url"].ToString();

            driver.Manage().Window.Maximize();

            string firstNameText = TestContext.DataRow["firstname"].ToString();
            driver.FindElement(By.Id("firstName")).SendKeys(firstNameText);


            string lastNameText = TestContext.DataRow["lastname"].ToString();
            driver.FindElement(By.Id("lastName")).SendKeys(lastNameText);

            string emailText = TestContext.DataRow["email"].ToString();
            driver.FindElement(By.Id("email")).SendKeys(emailText);

            string phone1Text = TestContext.DataRow["phone1"].ToString();
            driver.FindElement(By.Id("phone1")).SendKeys(phone1Text);

            string phone2Text = TestContext.DataRow["phone2"].ToString();
            driver.FindElement(By.Id("phone2")).SendKeys(phone2Text);

            string addressline1Text = TestContext.DataRow["address1"].ToString();
            driver.FindElement(By.Id("addressLine1")).SendKeys(addressline1Text);

            string addressline2Text = TestContext.DataRow["address2"].ToString();
            driver.FindElement(By.Id("addressLine2")).SendKeys(addressline2Text);

            string cityText = TestContext.DataRow["city"].ToString();
            driver.FindElement(By.Id("city")).SendKeys(cityText);

            string provinceText = TestContext.DataRow["province"].ToString();
            driver.FindElement(By.Id("province")).SendKeys(provinceText);

            string postalcodeText = TestContext.DataRow["postalcode"].ToString();
            driver.FindElement(By.Id("postalCode")).SendKeys(postalcodeText);

            driver.FindElement(By.XPath("/html/body/div[1]/article/section/form/p/button")).Click();


        }



        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }
        //before last two curley brackets

    }
}






