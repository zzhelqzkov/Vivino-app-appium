using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;
using System;
using System.Globalization;

namespace AppiumExercises
{
    [TestFixture]
    class vivinoApp
    {
        private const string VivinoLoginEmail = "pesho@abv.bg";
        private const string VivinoLoginPassword = "parola1parola1";
        private const string VivinoAppPackage = "vivino.web.app";
        private const string VivinoAppStartupActivity = "com.sphinx_solution.activities.SplashActivity";
        private AndroidDriver<AndroidElement> driver;
        private TouchAction action;

        [OneTimeSetUp]
        public void SetUp()
        {
            var appiumOptions = new AppiumOptions() { PlatformName = "Android" };
            appiumOptions.AddAdditionalCapability("appPackage", VivinoAppPackage);
            appiumOptions.AddAdditionalCapability("appActivity", VivinoAppStartupActivity);

            driver = new AndroidDriver<AndroidElement>(
                new Uri("http://[::1]:4723/wd/hub"), appiumOptions);
            action = new TouchAction(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        }

        [Test]
        public void vivinoApp_Test()
        {
            var linkLogin = driver.FindElementById("vivino.web.app:id/txthaveaccount");
            linkLogin.Click();

            var textBoxEmailLogin = driver.FindElementById("vivino.web.app:id/edtEmail");
            textBoxEmailLogin.SendKeys(VivinoLoginEmail);

            var textBoxPwdLogin = driver.FindElementById("vivino.web.app:id/edtPassword");
            textBoxPwdLogin.SendKeys(VivinoLoginPassword);

            var buttonLogin = driver.FindElementById("vivino.web.app:id/action_signin");
            buttonLogin.Click();

            var tabExplorer = driver.FindElementById("vivino.web.app:id/wine_explorer_tab");
            tabExplorer.Click();

            var buttonSearch = driver.FindElementById("vivino.web.app:id/search_vivino");
            buttonSearch.Click();

            var textBoxSearch = driver.FindElementById("vivino.web.app:id/editText_input");
            textBoxSearch.SendKeys("Katarzyna Reserve Red 2006");

            var listSearchResults = driver.FindElementById("vivino.web.app:id/listviewWineListActivity");
            var firstResult = listSearchResults.FindElementByClassName("android.widget.FrameLayout");
            firstResult.Click();

            var elementWineName = driver.FindElementById("vivino.web.app:id/wine_name");
            Assert.AreEqual("Reserve Red 2006", elementWineName.Text);

            var elementRating = driver.FindElementById("vivino.web.app:id/rating");
            var somestrange = elementRating.Text;
            double rating = double.Parse(elementRating.Text, CultureInfo.InvariantCulture);
            Assert.IsTrue(rating >= 1.00 && rating <= 5.00);

            var tabsSummary = driver.FindElementById("vivino.web.app:id/tabs");
            var tabHighlights = tabsSummary.FindElementByXPath("//android.widget.TextView[1]");
            var tabFacts = tabsSummary.FindElementByXPath("//android.widget.TextView[2]");

            tabHighlights.Click();
            var highlight = driver.FindElementById("vivino.web.app:id/highlight_description");

            Assert.AreEqual("Among top 1% of all wines in the world", highlight.Text);

            tabFacts.Click();
            var factsTitle = driver.FindElementById("vivino.web.app:id/wine_fact_title");
            var factsText = driver.FindElementById("vivino.web.app:id/wine_fact_text");

            Assert.AreEqual("Grapes", factsTitle.Text);
            Assert.AreEqual("Cabernet Sauvignon,Merlot", factsText.Text);

        }

        [OneTimeTearDown]
        public void ShutDown()
        {
            driver.Quit();
        }
    }
}
