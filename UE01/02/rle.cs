using System;
using System.Globalization;

static class RLE {
	public static string escapeChar = "#";

	//Returns a RLE-encoded string
	public static string encode(string input) {
		string output = "";
		string buffer = "";
		uint counter = 1;
		for (int i = 0; i < input.Length - 1; i++) {
			buffer += input[i];
			if (input[i] == input[i + 1]) {
				counter++;
			} 	
			if (input[i] != input[i + 1] || i == input.Length - 2) { 
				if (counter >= 4) {
					output += input[i] + escapeChar + counter.ToString() + escapeChar;
				} else {
					output += buffer;
				}
				if (i == input.Length - 2 && counter < 4) {
					output += input[i + 1];
				}
				counter = 1;
				buffer = ""; 
			}
		}
		return output;
	}

	//Returns a RLE-decoded string
	public static string decode(string input) {
		string output = "";
		for (int i = 0; i < input.Length; i++) {
			if(input[i] == escapeChar[0]) {
				int indexOffset = input.IndexOf('#', i + 1);
				string rl = input.Substring(i + 1, indexOffset - i - 1);
				int runLength = Int32.Parse(rl);
				for (int run = 0; run <= runLength - 2; run++) 
					output += input[i - 1];
				i += indexOffset - i;
			} else 
				output += input[i];
		}
		return output;
	}
}

