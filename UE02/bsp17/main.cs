/* 1410601024, fhs37246
   * Philipp Welsch
   * ue02 bsp17   */
using System;
using System.Text.RegularExpressions;

class MainClass
{
	static void Main(string[] args)
	{
		string pal = Regex.Replace(args[0], @"\W+", "").ToUpper();
		Console.WriteLine(isPal(pal));
	}

	public static bool isPal(string s)
	{
        if (s.Length < 2)
            return true;
        if(s[0] == s[(s.Length - 1)])
            return isPal(s.Substring(1, s.Length-2)); 
       	return false;
	}
}