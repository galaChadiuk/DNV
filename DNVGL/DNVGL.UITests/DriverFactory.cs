using System;
using DNVGL.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace DNVGL.UITests
{
	public static class DriverFactory
	{
		public static IWebDriver Create(BrowserType type)
		{
			IWebDriver driver;
			switch (type)
			{
				case BrowserType.Chrome:
					{
						driver = new ChromeDriver();
						break;
					}
				case BrowserType.FireFox:
					{
						driver = new FirefoxDriver();
						break;
					}
				default:
					{
						throw new Exception("Incorrect browser type");
					}

			}

			return driver;
		}
	}
}
