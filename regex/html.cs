using System;
using System.Text.RegularExpressions;

class MainClass {
	static void Main() {
		string tags = "<p>abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ\n0123456789 +-.,!@#$%^&*();|<>\n12345 -98.7 3.141 .6180 9,000 +42</p>";

string more = "<p>Welcome to RegExr v2.0 by gskinner.com!</p>\n<p>AaaaddddDDDEfffxxyZZZZZ</p>\nEdit the Expression & Text to see matches. Roll over matches or the expression for details. Undo mistakes with ctrl-z. Save & Share expressions with friends or the Community. A full Reference & Help is available in the Library, or watch the video Tutorial.\n. DDDSample text for testing:\nabcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 +-.,!@#$%^&*();/|<p>\n12345 -98.7 3.141 .6180 9,000 +42555.123.4567\n	+1-(800)-555-2468foo@demo.net	bar.ba@test.co.ukwww.demo.com	http://foo.co.uk/</p>\nhttp://regexr.com/foo.html?q=bar";
		RegexOptions my_opt = RegexOptions.Singleline;
		Match my = Regex.Match(more, @"(?![<p>])(.*)(?=</p>)", my_opt);
		Console.WriteLine(my.Groups[0].Value);
	}
}