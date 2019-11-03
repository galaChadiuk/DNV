using DNVGL.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace DNVGL.PageObject
{
	public class ContactPage
	{
		private IWebDriver _driver;
		public ContactPage(IWebDriver driver)
		{
			PageFactory.InitElements(driver, this);
			_driver = driver;
		}

		[FindsBy(How = How.XPath, Using = "//h1[text()='Contact DNV GL']")]
		private IWebElement Header;

		public bool IsOpened()
		{
			return Waiter.WaitUntil(() => Header.Displayed);
		}
	}
}
