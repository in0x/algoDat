using System;
using System.Text.RegularExpressions;

class regularMagic
{

	static void Main()
	{
		string toShrink = "AaaaddddDDDEfffxxyZZZZZ";
		string shrunk = Regex.Replace(toShrink, @"(.)\1{3,}", Match => "$1#" + Match.Value.Length + "#");
		Console.WriteLine(shrunk + " " + toShrink.Length + " " + shrunk.Length);
	}
	/*
	*	Regex Explenation
	*	() -> Capture the pattern within as a group
	*	. -> Math any character excpet line feed (move one line forward, new line)
	*	\1 -> Match the same character as captured before
	*	* -> Now repeat that match 0 or more times again
	*
	*	Basically im fetching every character, but grouping runs of them into groups
	*
	*/
}
