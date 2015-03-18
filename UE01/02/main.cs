using System;
using RLE;

class MainClass {	
	static void Main(string[] args) {
		
		if (args.Length == 0) { 
			Console.WriteLine("Usage:");
			Console.WriteLine("\t-c ... RLE encode a string");
			Console.WriteLine("\t-d ... RLE decode a string");
			Console.WriteLine("\t-e ... Provide escape character for encoding");
			return;
		} 
		else if (args[0] == "-c") {
			if(args.Length == 4 && args[2] == "-e") RLE.escapeChar = args[3];
			Console.WriteLine(RLE.encode(args[1]));
		} 
		else if (args[0] == "-d"){
			Console.WriteLine(RLE.decode(args[1]));
		}
	}
}