using System;
using RLE;
using Tests;
using ExceptionHandling;

class MainClass {	
	static void Main(string[] args) {
		
		myTests.runTest();
		
		string usage = "Usage: {-c,-d} string [-d] [escapeChar]\n\t-c ... RLE encode a string\n\t-d ... RLE decode a string\n\t-e ... Provide escape character for encoding";
		
		if (args.Length == 0 || args.Length > 4) { 
			Console.WriteLine(usage);
			return;
		} else {	
			try {
				
				if(args.Length > 3 && args[2] == "-e") 
					RLE.escapeChar = args[3];

				if (args[0] == "-c") {
					Console.WriteLine(RLE.encode(args[1]));
				} 
				else if (args[0] == "-d"){
					Console.WriteLine(RLE.decode(args[1]));
				}
			} catch(Exception e) {
				Console.WriteLine(e.Message);
			}
		}
	}
}