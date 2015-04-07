using System;
using System.Console;

class MainClass 
{
	static void Main(string[] args)
	{		
		WriteLine(sumCircles(5));
		WriteLine(sumSquares(2));
	}

	static double sumCircles(double depth) 
	{
		if (depth == 0) return 1;
		else return Math.Pow(2, depth) + sumCircles(depth - 1);
	}

	static double sumSquares(int depth) 
	{
		if (depth == 0) return 1;
		else return Math.Pow(4, depth) + sumSquares(depth - 1); 
	} 
}
