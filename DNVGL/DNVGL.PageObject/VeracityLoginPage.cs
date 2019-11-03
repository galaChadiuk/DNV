using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace DNVGL.PageObject
{
	public class VeracityLoginPage
	{
		private IWebDriver _driver;
		public VeracityLoginPage(IWebDriver driver)
		{
			PageFactory.InitElements(driver, this);
			_driver = driver;
		}

		[FindsBy(How = How.Id, Using = "loginMessage")]
		public IWebElement WelcomeMasage;
	}
}
