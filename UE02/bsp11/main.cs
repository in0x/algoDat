/* 1410601024, fhs37246
   * Philipp Welsch
   * ue02 bsp11    */
using System;
using System.Console;
using System.Diagnostics;
using MyStringArray;

class MainClass 
{
	static void Main(string[] args) 
	{
			StringArray test = new StringArray();
			
			Debug.Assert(test.Count == 0, "test.Count not 0");
			Debug.Assert(test.Capacity == 0, "test.Capacity not 0");

			test.Add("Would you kindly");

			Debug.Assert(test.Count == 1, "test.Count after add not 0");
			Debug.Assert(test.Capacity == 4, "test.Capacity after add not 4");

			test.Add("Oh boy.");
			test.Add("Hello Ground!");
			test.Add("Brap Brap");
			test.Add("Hello Internet.");

			Debug.Assert(test.Count == 5 ,"test.Count not 5 after adding");
			Debug.Assert(test.Capacity == 8, "test.Capacity did not double");

			test.RemoveAt(3);
			Debug.Assert(test.Content[3] == "Hello Internet.", "RemoveAt not working at 3");
			
			test.Insert("Finish him", 2);
			Debug.Assert(test.Content[2] == "Finish him", "Insert not working at 2");
	}
}