using System;
using System.Text.RegularExpressions;

class More_ex 
{
	static void Main()
	{
		string numbers = "069910479604\n06641314597\n0699123456789\n+4369910479604\n+436641314597\n+43699123456789\n004369910479604\n00436641314597\n0043699123456789";
		// Matches most possible austrian phone numbers
		// Starts with either "06", "+436" (note that we have to escape the greedy operator here,
		// to turn it into a regular +) OR "00436", followed by 9 to 10 digits
		MatchCollection matched = Regex.Matches(numbers, @"((06)|(\+436)|(00436))\d{9,10}\D");
		foreach (Match m in matched) 
			Console.WriteLine(m);
	}
}