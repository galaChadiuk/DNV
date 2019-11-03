using System;
using System.Linq;
using DNVGL.Common;
using DNVGL.PageObject;
using NUnit.Framework;
using Random = DNVGL.Common.Random;

namespace DNVGL.UITests
{
	[TestFixture]
	public class UITests : BaseTest
	{
		private const string HOME_PAGE_URL = "https://www.dnvgl.com";

		[Test]
		[TestCase(BrowserType.Chrome)]
		[TestCase(BrowserType.FireFox)]
		public void VerifyRedirectToVeracitySignInPage(BrowserType type)
		{
			driver = DriverFactory.Create(type);
			driver.Navigate().GoToUrl(HOME_PAGE_URL);
			var mainPage = new MainPage(driver);
			mainPage.AcceptCookies();
			Waiter.WaitUntil(() => mainPage.SingIn.Enabled);
			mainPage.SingIn.Click();
			var veracityLoginPage = new VeracityLoginPage(driver);
			Assert.IsTrue(Waiter.WaitUntil(() => veracityLoginPage.WelcomeMasage.Displayed));
		}

		[Test]
		[TestCase(BrowserType.Chrome)]
		[TestCase(BrowserType.FireFox)]
		public void VerifySuccessfulRegionChange(BrowserType type)
		{
			driver = DriverFactory.Create(type);
			driver.Navigate().GoToUrl(HOME_PAGE_URL);
			var mainPage = new MainPage(driver);
			mainPage.AcceptCookies();
			Waiter.WaitUntil(() => mainPage.RegionSelection.Enabled);
			mainPage.RegionSelection.Click();
			var randomRegion = mainPage.GetRegionsWithAddress().ElementAt(Random.GenerateRandomInt(mainPage.Regions.Count));
			mainPage.SelectRegion(randomRegion.Key);
			Assert.AreEqual(new Uri(randomRegion.Value).Host, new Uri(driver.Url).Host);
		}

		[Test]
		[TestCase(BrowserType.Chrome)]
		[TestCase(BrowserType.FireFox)]
		public void VerufySuccessfulSearch(BrowserType type)
		{
			driver = DriverFactory.Create(type);
			driver.Navigate().GoToUrl(HOME_PAGE_URL);
			var mainPage = new MainPage(driver);
			mainPage.AcceptCookies();
			mainPage.Search("Health");
			var searchResult = new SearchResultsPage(driver);
			Assert.IsTrue(Waiter.WaitUntil(() => searchResult.SuccessfulSearchMessage.Displayed));
		}

		[Test]
		[TestCase(BrowserType.Chrome)]
		[TestCase(BrowserType.FireFox)]
		public void VerifyUnsuccessfulSearch(BrowserType type)
		{
			driver = DriverFactory.Create(type);
			driver.Navigate().GoToUrl(HOME_PAGE_URL);
			var mainPage = new MainPage(driver);
			mainPage.AcceptCookies();
			mainPage.Search("qwerty");
			var searchResult = new SearchResultsPage(driver);
			Assert.IsTrue(Waiter.WaitUntil(() => searchResult.NoResultsMessage.Displayed));
		}

		[Test]
		[TestCase(BrowserType.Chrome)]
		[TestCase(BrowserType.FireFox)]
		public void VerifyRedirectToContactUsPage(BrowserType type)
		{
			driver = DriverFactory.Create(type);
			driver.Navigate().GoToUrl(HOME_PAGE_URL);
			var mainPage = new MainPage(driver);
			mainPage.AcceptCookies();
			mainPage.ContactUs.Click();
			var contactPage = new ContactPage(driver);
			Assert.IsTrue(contactPage.IsOpened());
		}
	}
}
