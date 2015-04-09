/* 1410601024, fhs37246
   * Philipp Welsch
   * ue02 bsp08 	*/
using System;
using System.Console;
using System.Collections.Generic;

class MainClass {

	static void Main(string[] args) 
	{
		if(args.Length == 0) 
		{
			WriteLine("Usage:\n\tpassword.exe [low] [high] [maxN]\n\tlow ... lowest ASCII-Code\n\thigh ... highest\n\tmaxN ... max pwd length");
			return;
		}
		char one = args[0][0];
		char two = args[1][0];
		List<string> myList = new List<string>();
		printAll("", Convert.ToInt32(args[2]), myList, one, two);
		WriteLine(myList.Count);
	}

	static void printAll(String current, int length, List<string> list, char start, char end) 
	{
    	WriteLine(current);
    	if (current.Length > 2) list.Add(current);
    	if (current.Length < length)
        	for (char c = start; c <= end; c++)
        		//if (!current.Contains(c.ToString()))
            	//	printAll(current + c, length, list, start, end);
            	//Enable the above for unique mode
            	printAll(current + c, length, list, start, end);
	}
}
