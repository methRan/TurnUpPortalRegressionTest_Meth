using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class Program
{
    public static void Main(string[] args)
    {
        //open the browser
        IWebDriver driver = new ChromeDriver();

        // Open Chrome Browser
        ChromeOptions options = new ChromeOptions();
        options.AddUserProfilePreference("profile.password_manager_leak_detection", false);
        driver = new ChromeDriver(options);

        //Launch turnup portal
        driver.Navigate().GoToUrl("http://horse.industryconnect.io");
        driver.Manage().Window.Maximize();
        Thread.Sleep(1000);

        //identify username textbox and enter valid username
        IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
        usernameTextbox.SendKeys("hari");

        //identify password textbox and enter valid password
        IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
        passwordTextbox.SendKeys("123123");

        //identify login button and click on
        IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
        loginButton.Click();
        Thread.Sleep(2000);

        //check if user has logged in successfully
        IWebElement hellometh = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));

        if (hellometh.Text == "Hello hari!")
        {
            Console.WriteLine("User logged successfully. Test Passed !!");
        }
        else
        {
            Console.WriteLine("User has not logged in. Test Failed !!");
        }

        //crete a time record

        //navigate to Administration Page to select the time and Material from the drop down
        IWebElement adminPage = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
        adminPage.Click();
        Thread.Sleep(3000);

        //select the time and Material from the drop down
        IWebElement timeMaterial = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
        timeMaterial.Click();

        //click on create new button
        IWebElement createNew = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
        createNew.Click();
        Thread.Sleep(1000);

        //select time from the dropdown
        IWebElement typeCodedropDown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
        typeCodedropDown.Click();

        IWebElement timeButton = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
        timeButton.Click();

        //type the code into Code textbox
        IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
        codeTextbox.SendKeys("TA Program");

        //type the description into Description textbox
        IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
        descriptionTextbox.SendKeys("This is fun");

        //type the price per unit into Price textbox
        IWebElement priceTagOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
        priceTagOverlap.Click();

        IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
        priceTextbox.SendKeys("23");

        //select files

        //click on save button
        IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
        saveButton.Click();
        Thread.Sleep(3000);

        //check if time material created successfully
        IWebElement goToLastpageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        goToLastpageButton.Click();

        IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

        if (newCode.Text == "TA Program")
        {
            Console.WriteLine("Time record created successfully");
        }
        else
        {
            Console.WriteLine("New time has not been created");
        }
    }
}