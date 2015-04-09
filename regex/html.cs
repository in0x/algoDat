using System;
using System.Text.RegularExpressions;

class MainClass {
	static void Main() {
		string tags = "<p>abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ\n0123456789 +-.,!@#$%^&*();|<>\n12345 -98.7 3.141 .6180 9,000 +42</p>";
		RegexOptions my_opt = RegexOptions.Singleline;
		Match my = Regex.Match(tags, @"(?![<p>])(.*)(?=</p>)", my_opt);
		Console.WriteLine(my.Groups[1].Value);
	}
}