using System;
using System.Collections.Generic;
using System.Linq;
using DNVGL.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace DNVGL.PageObject
{
	public class MainPage
	{
		private IWebDriver _driver;
		public MainPage(IWebDriver driver)
		{
			PageFactory.InitElements(driver, this);
			_driver = driver;
		}

		[FindsBy(How = How.XPath, Using = "//a[@title='Sign in to Veracity']")]
		public IWebElement SingIn;

		[FindsBy(How = How.CssSelector, Using = "a.cookie-consent__close")]
		private IWebElement CloseCookiesMessage;

		[FindsBy(How = How.LinkText, Using = "Contact DNV GL")]
		public IWebElement ContactUs;

		[FindsBy(How = How.CssSelector, Using = "a.region-selection__btn")]
		public IWebElement RegionSelection;

		[FindsBy(How = How.CssSelector, Using = "input.search-ribbon__search-input")]
		public IWebElement SearchField;

		[FindsBy(How = How.CssSelector, Using = "span.search-ribbon__search-submit")]
		public IWebElement SearchButton;

		[FindsBy(How = How.CssSelector, Using = "li.region-selection__nav-list-item>a")]
		public IList<IWebElement> Regions;

		public void AcceptCookies()
		{
			Waiter.WaitUntil(() => CloseCookiesMessage.Displayed);
			if (CloseCookiesMessage.Enabled)
			{
				CloseCookiesMessage.Click();
			}
		}

		public void SelectRegion(string region)
		{
			var element = Regions.FirstOrDefault(link => link.GetAttribute("title").Equals(region));
			((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView();", element);
			if (element != null)
			{
				element.Click();
			}
			else
			{
				throw new Exception(string.Format("Cannot find region with title {0}", region));
			}
		}

		public Dictionary<string, string> GetRegionsWithAddress()
		{
			var addresses = new Dictionary<string, string>();
			foreach (var region in Regions)
			{
				addresses.Add(region.GetAttribute("Title"), region.GetAttribute("href"));
			}

			return addresses;
		}

		public void Search(string text)
		{
			SearchField.SendKeys(text);
			System.Threading.Thread.Sleep(1000);
			SearchButton.Click();
		}
	}
}
