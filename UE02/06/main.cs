using System;
using System.Console;
using System.Diagnostics;
using System.Collections.Generic;
using MyStringArray;
using System.IO;

class MainClass() 
{
	static void Main()
	{
		string[] lines = File.ReadAllLines(@"data.txt");

		TimeSpan start = Process.GetCurrentProcess().TotalProcessorTime;
		StringArray phil = new StringArray(1);
		
		foreach (string s in lines)
			phil.Add(s);

		TimeSpan end = Process.GetCurrentProcess().TotalProcessorTime;
		double p = (end-start).TotalMilliseconds;
		WriteLine(p);


		start = Process.GetCurrentProcess().TotalProcessorTime;
		List<string> microsoft = new List<string>(1);

		foreach (string s in lines)
			microsoft.Add(s);

		end = Process.GetCurrentProcess().TotalProcessorTime;
		double ms = (end-start).TotalMilliseconds;
		WriteLine(ms);
		
	}
}