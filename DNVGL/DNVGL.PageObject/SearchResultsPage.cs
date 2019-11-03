using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace DNVGL.PageObject
{
	public class SearchResultsPage
	{
		private IWebDriver _driver;
		public SearchResultsPage(IWebDriver driver)
		{
			PageFactory.InitElements(driver, this);
			_driver = driver;
		}

		[FindsBy(How = How.CssSelector, Using = "span.the-search__empty")]
		public IWebElement NoResultsMessage;

		[FindsBy(How = How.CssSelector, Using = "section.the-search__result")]
		public IWebElement SuccessfulSearchMessage;
	}
}
