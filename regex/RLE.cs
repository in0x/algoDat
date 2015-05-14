using System;
using System.Text.RegularExpressions;

class regularMagic
{
	static void Main()
	{
		string toShrink = "AaaaddddDDDEfffxxyZZZZZ";
		string shrunk = Regex.Replace(toShrink, @"(.)\1{3,}", Match => Match.Groups[1].Value + "#" + Match.Value.Length + "#");
		Console.WriteLine(shrunk);
	}
	/*
	*	Regex Explenation
	*	() -> Capture the pattern within as a group
	*	. -> Math any character excpet line feed (move one line forward, new line)
	*	\1 -> Match the same character as captured before
	*	{3,} -> Now find that match for length of 3 or more
	*
	*	Basically im fetching every character, but grouping runs of them into groups of length 3 or more
	*
	*/
}
