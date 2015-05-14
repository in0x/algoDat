using System;
using System.Text.RegularExpressions;

class MainClass {
	static void Main() {
		BrowserRegex();
		LoremIpsum();
		hexEx();
	}

	/*
	* C# Regex:
	* The Regex class has two classes called Match and MatchCollection
	* A Match is any Match found by running a Regex against a string and includes (among others):	
	* [0] = Captures : The Captured text 
	* [2] = Groups : All groups of matched text which add up to the capture
	* [3] = Index : The position in the string of the captured group 
	* [5] = Success: Tells us if there was a successful match (useful in hexEx() example)
	*/

	static void BrowserRegex() {
		string textMoz = "User-Agent: Mozilla/5.0 (Macintosh; Intel Mac OS X 10_10_0)";

		//Explenation of Regex Syntax:
		// The [--characters--] syntax allows us to have variable characters in the string,
		// so: [Mm] -> either 'M' or 'm'
		// and: [4-6] -> either '4', '5' or '6'
		string patternMoz = "[Mm]ozilla/[4-6].0"; //JS Support

		string textIE = "User-Agent: Mozilla/4.0(compatible; MSIE.7.0b, Windows NT 6.0)";

		// () creates a group of characters that needs to be found as is
		// | is a logical or -> either of the groups can appear, but not all in THIS group
		// again [0-9] selects the number 0 through 9 for us without explicitly writing them down
		// with that we could also do ([0-2][0-9]|3[0-1]) for all days of a 31 day month 
		string patternIE = "MSIE.((5.[5-9])|([6-9]|1[0-9]))"; //W3C Dom Support

		//Returns a Match as described above
		Match mozMatch = Regex.Match(textMoz, patternMoz);
		Match IEmatch = Regex.Match(textIE, patternIE);

		Console.WriteLine("Testing on string:\n\tUser-Agent: Mozilla/5.0 (Macintosh; Intel Mac OS X 10_10_0)\n");
		Console.WriteLine("Expecting:\n\tMozilla/5.0\n");
		Console.WriteLine("Got:\n\t" + mozMatch.Groups[0]); 

		Console.WriteLine("\nTesting on string:\n\tUser-Agent: Mozilla/4.0(compatible; MSIE.7.0b, Windows NT 6.0)\n");
		Console.WriteLine("Expecting:\n\tMSIE.7\n");
		Console.WriteLine("Got:\n\t" + IEmatch.Groups[0]);
	}

	static void LoremIpsum() {
		string lorem = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr,\nsed diam nonumy eirmod Dolorat tempor invidunt\nut labore Et dolore magna erat dolores\n"; 
		
		//You can also create an Instance of Regex 
		Regex dolor = new Regex("[dD]olor");

		Console.WriteLine("\nTesting:\n" + lorem + "\nWith regex:\n\t[dD]olor\n");

		//Matches() returns a MatchCollection, a group of Matches (as described above)
		//If there are no Matches the function returns an empty object
		//If there are, you can iterate over them like this

		foreach (Match m in dolor.Matches(lorem)) {
			Console.WriteLine(m.Groups[0]);
			Console.WriteLine("Index of match: " + m.Index);
		}
	}

	//Verifies if the string is a hexadecimal literal
	static void hexEx() {
		// The + operator makes this regex greedy, so it won't stop matching after the first find,
		// IF it can still find matches
		// Without this, it would stop matching after "3C" in string 5
		string hexPattern = "0[xX][0-9a-fA-F]+";

		string[] toMatch = {
			"12345",
			"0xfff",
			"eee",
			"nope",
			"0x3C9ABE"
		 };

		Console.Write("\n\n\n");

		//This is a really simple way to iterate over a string array 
		// and check if they match the Regex
		foreach (string s in toMatch) {
			Match m = Regex.Match(s, hexPattern);
			if (m.Success)
				Console.WriteLine(s + " matched: " + m.Groups[0]);
			else 
				Console.WriteLine(s + ": no match");
		}

	}
}