/* 1410601024, fhs37246
   * Philipp Welsch
   * ue02 bsp07    */
using System;
using System.Diagnostics;

class MainClass 
{
	static void Main() 
	{
		Console.WriteLine(rec.sum(4));
		Console.WriteLine(rec.pow(3, 0));
		Debug.Assert(rec.sum(4) == ((4 * 4 + 4)/2));
		rec.cd(4);
	}

	static class rec 
	{
		public static int sum(int n) 
		{	
			return (n > 0) ? n + sum(n - 1) : 0;
		}

		public static double pow(double x, uint n) 
		{
			return n == 0 ? 1 : x * pow(x, n - 1); 
		}

		public static void cd(int n) 
		{
			if (n == 0) Console.WriteLine(n);
			else {
				Console.WriteLine(n);
				cd(n - 1);
			}
		}
	}
}