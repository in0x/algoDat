/* 141061024, fhs37246
   * Philipp Welsch
   * ue08 bsp53    */

using System;
using System.Diagnostics;

class MyHashtableLP_Main {

	public static void Main() {

		MyHashtableLP<int, string> plzhashtable = new MyHashtableLP<int, string>(3);
	
		Console.WriteLine("======================================");
		Console.WriteLine("Using a hashtable where PLZs are the keys, citynames are the values: ");
		Console.WriteLine("======================================");
	
		Console.WriteLine("Add (5020, \"Salzburg\") and (4010, \"Linz\").");
		plzhashtable.Insert(5020, "Salzburg");
		plzhashtable.Insert(4010, "Linz");

		Console.WriteLine("contains 4010: " + plzhashtable.Contains(4010));
		Console.WriteLine("contains 5020: " + plzhashtable.Contains(5020));
		Console.WriteLine("Stadt von 5020: \"" +  plzhashtable.Get(5020) + "\"");
		try {
			plzhashtable.Get(1000); // not stored
			Debug.Assert(false); // must not be reached
		} 
		catch (Exception e) {
			Console.WriteLine("Getting value of key 1000 caused an exception: " + e.Message);
		}
		
		plzhashtable.Print();
		
		Console.WriteLine("Removing 5020: ");
		plzhashtable.Remove(5020);
		plzhashtable.Print();
		try {
			plzhashtable.Remove(1000); // not stored
			Debug.Assert(false); // must not be reached
		} 
		catch (Exception e) {
			Console.WriteLine("Removing Key 1000 caused an exception: " + e.Message);
		}
		
		
		Console.WriteLine();
		Console.WriteLine();
		
		Console.WriteLine("======================================");
		Console.WriteLine("Using a hashtable where citynames are the keys, and PLZs are the values: ");
		Console.WriteLine("======================================");
		
		MyHashtableLP<string, int> cityhashtable = new MyHashtableLP<string, int>(3);
		Console.WriteLine("Add (\"Salzburg\", 5020) and (\"Linz\", 4010).");
		cityhashtable.Insert("Salzburg", 5020);
		cityhashtable.Insert("Linz", 4010);

		Console.WriteLine("contains \"Linz\": " + cityhashtable.Contains("Linz"));
		Console.WriteLine("contains \"Salzburg\": " + cityhashtable.Contains("Salzburg"));
		Console.WriteLine("PLZ von \"Salzburg\": " +  cityhashtable.Get("Salzburg"));
		
		cityhashtable.Print();
		
	
	
		Console.WriteLine();
		Console.WriteLine();
		
		
		Console.WriteLine("======================================");
		Console.WriteLine("Using another hashtable: ");
		Console.WriteLine("======================================");
		
		
	
		MyHashtableLP<int, char> demohashtable = new MyHashtableLP<int, char>(12);
		demohashtable.Insert(7, 'A');
		demohashtable.Insert(14, 'B');
		demohashtable.Insert(71, 'A');
		demohashtable.Insert(22, 'C');
		demohashtable.Insert(58, 'D');
		demohashtable.Insert(34, 'R');
		demohashtable.Insert(122, 'C');
		demohashtable.Insert(238, 'D');
		demohashtable.Insert(602,  'A');
		demohashtable.Insert(1202, 'B');
		demohashtable.Insert(312, 'F');
		demohashtable.Print();
		Console.WriteLine("Now removing (22, \'C\'): ");
		demohashtable.Remove(22);
		Console.WriteLine("Rehashing caused the following hashtable: ");
		demohashtable.Print();
		Debug.Assert(demohashtable.Count == 10, "demohashtable count wrong");
		Debug.Assert(demohashtable.Capacity == 24, "demohashtable capacity wrong");
		Debug.Assert(demohashtable.Contains(22) == false, "22 removed, availible again after rehash");
		
		Console.WriteLine();
		Console.WriteLine();
		Console.WriteLine("======================================");
		Console.WriteLine("Multiplication method: ");
		Console.WriteLine("======================================");
		
		MyHashtableLP<double, string> multHT = new MyHashtableLP<double, string>(7);
		multHT.Insert(3.14159265, "PI");
		multHT.Insert(42, "solution to everything");
		multHT.Insert(-2.718281828459045, "-Euler");
		multHT.Insert(1.41421356, "Sqrt(2)");
		multHT.Remove(1.41421356);
		multHT.Insert(2.718281828459045, "Euler");
		Console.WriteLine("\nHashtable before rehashing\n");
		multHT.Print();
		multHT.Insert(10E8, "BigNum");
		multHT.Insert(6.283, "Tau");
		multHT.Print();
		Debug.Assert(multHT.Contains(1.41421356) == false, "removed el availible again");
		Debug.Assert(multHT.Count == 6, "multHT count wrong");
		Debug.Assert(multHT.Capacity == 14, "multHT capacity wrong");
		Debug.Assert(multHT.Contains(10E8), "cannot find BigNum");;
		multHT.Insert(1.618, "golden");
		multHT.Print();
		Console.WriteLine(multHT.Capacity);
		Debug.Assert((double)multHT.Count / (double)multHT.Capacity == 0.5, "wrong load factor");
	
		MyHashtableLP<int, string> findTest = new MyHashtableLP<int, string>(7);
		findTest.Insert(1,"A");
		findTest.Insert(2,"B");
		findTest.Insert(3,"C");
		findTest.Insert(4,"D");
		findTest.Insert(5,"E");
		findTest.Insert(6,"F");
		Debug.Assert(findTest.Contains(1) == true &&
					 findTest.Contains(2) == true &&
					 findTest.Contains(3) == true &&
					 findTest.Contains(4) == true &&
					 findTest.Contains(5) == true &&
					 findTest.Contains(6) == true);
	}

}