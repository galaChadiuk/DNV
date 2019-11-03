namespace DNVGL.Common
{
	public static class Random
	{
		public static int GenerateRandomInt(int boundary)
		{
			var rd = new System.Random();
			return rd.Next(boundary);
		}
	}
}
