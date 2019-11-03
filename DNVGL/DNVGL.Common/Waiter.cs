using System;
using System.Diagnostics;

namespace DNVGL.Common
{
	public static class Waiter
	{
		public delegate bool Condition();

		public static bool WaitUntil(Condition condition, int timeout = 10000)
		{
			var result = false;
			var stopWatch = new Stopwatch();
			while (!result && stopWatch.ElapsedMilliseconds < timeout)
			{
				try
				{
					result = condition();
					if (result)
					{
						return result;
					}

					System.Threading.Thread.Sleep(1000);
				}
				catch (Exception)
				{
				}
			}

			throw new TimeoutException("Condition was not meet during timeout ");
		}
	}

}
