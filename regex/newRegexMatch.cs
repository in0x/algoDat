using System;
using System.Text.RegularExpressions;

class regularMagic
{
	delegate string test(Match match);
	static string replace(Match match)
	{	
		return match.Groups[1].Value + "#" + match.Value.Length + "#";
	}
	static void Main()
	{
		string toShrink = "AaaaddddDDDEfffxxyZZZZZ";
		//string shrunk = Regex.Replace(toShrink, @"(.)\1*", match => match.Groups[1].Value + match.Value.Length);
		//match.Groups[0].Value is the match itself, [1] is the matched character
		test lambda = new test(replace);
		string shrunk = Regex.Replace(toShrink, @"(.)\1{3,}", match => lambda(match));
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
