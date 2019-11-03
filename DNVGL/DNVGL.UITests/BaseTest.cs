using NUnit.Framework;
using OpenQA.Selenium;

namespace DNVGL.UITests
{
	public class BaseTest
	{
		protected IWebDriver driver;

		[TearDown]
		public void TearDown()
		{
			driver.Quit();
		}
	}
}
