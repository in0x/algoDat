using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class PaperReader {
	static void Main(string[] args) {
		if (args.Length == 0 || args.Length > 1) {
			Console.WriteLine("Please provide a path to the file to read");
			return;
		}

		MyHashtableLP<string, int> wordCount = new MyHashtableLP<string, int>();
		try {
			using (StreamReader read = new StreamReader(args[0].Trim())) { //automatically closes IO-Stream
				string line;
	      while ((line = read.ReadLine()) != null) {
	      	line = Regex.Replace(line, @"(\p{P})", "").Trim().ToLower();
	      	string[] words = line.Split(' ');
	      	foreach(string s in words) {
	      		if (wordCount.Contains(s)) {
	      			wordCount.Insert(s, wordCount.Get(s) + 1);
	      		} else
	      			wordCount.Insert(s, 1);
	      	}		
	      }
			}
		} catch (FileNotFoundException) {
			Console.WriteLine("File not found");
		}
		wordCount.Print();
	}
}
