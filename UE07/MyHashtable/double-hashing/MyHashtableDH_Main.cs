using System;
using System.Diagnostics;

class MyHashtableLP_Main {

	public static void Main() {

		MyHashtableDH<int, string> plzhashtable = new MyHashtableDH<int, string>(3);
	
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
		
		MyHashtableDH<string, int> cityhashtable = new MyHashtableDH<string, int>(7);
		Console.WriteLine("Insert (\"Salzburg\", 5020):");
		cityhashtable.Insert("Salzburg", 5020);
		Console.WriteLine("Done");
		Console.WriteLine("Insert (\"Linz\", 4010):");
		cityhashtable.Insert("Linz", 4010);
		Console.WriteLine("Done");
		Console.WriteLine("Insert (\"Wien\", 1010):");
		cityhashtable.Insert("Wien", 1010);
		Console.WriteLine("Done");

		cityhashtable.Print();
		
		Console.WriteLine("contains \"Linz\": " + cityhashtable.Contains("Linz"));
		Console.WriteLine("contains \"Salzburg\": " + cityhashtable.Contains("Salzburg"));
		Console.WriteLine("PLZ von \"Salzburg\": " +  cityhashtable.Get("Salzburg"));
		
		Console.WriteLine("Removing Salzburg: ");
		cityhashtable.Remove("Salzburg");
		cityhashtable.Print();
		
		//Wien must still be found:
		Debug.Assert(cityhashtable.Contains("Wien"));
		
		Console.WriteLine();
		Console.WriteLine();
		
		
		Console.WriteLine("======================================");
		Console.WriteLine("Another hashtable (size 12): ");
		Console.WriteLine("======================================");
		
		
	
		MyHashtableDH<int, char> demohashtable = new MyHashtableDH<int, char>(12);
		demohashtable.Insert(7, 'A');
		Console.WriteLine("Added key 7.");
		demohashtable.Insert(14, 'B');
		Console.WriteLine("Added key 14.");
		demohashtable.Insert(22, 'C');
		Console.WriteLine("Added key 22.");
		demohashtable.Insert(58, 'D');
		Console.WriteLine("Added key 58.");
		demohashtable.Insert(71, 'A');
		Console.WriteLine("Added key 71.");
		demohashtable.Insert(122, 'C');
		Console.WriteLine("Added key 122.");
		demohashtable.Insert(238, 'D');
		Console.WriteLine("Added key 238.");
		demohashtable.Print();
		demohashtable.Insert(602, 'A');
		Console.WriteLine("Added key 602.");
		demohashtable.Print();
		
		//Causing an exception bc. going in circles (because 12 is not a prime number):
		//demohashtable.Insert(1202, 'B');
		//Console.WriteLine("Added key 1202.");
		//demohashtable.Print();
		
		Console.WriteLine("Now removing (22, \'C\'): ");  //was inserted without collision
		demohashtable.Remove(22);
		demohashtable.Print();
		
		Console.WriteLine("Now removing (58, \'C\'): "); //was inserted with collisions
		demohashtable.Remove(58);
		demohashtable.Print();
		
		//wouldn't be found without wasoccupied-Array! (As it was inserted with collisions.)
		Debug.Assert(demohashtable.Contains(238)); 
		Console.WriteLine("Now removing (238, \'C\'): ");
		demohashtable.Remove(238);
		demohashtable.Print();
		
		//Trying a hashtable going full and removing all entries:
		MyHashtableDH<string, int> cityhashtable2 = new MyHashtableDH<string, int>(3);
		Console.WriteLine("Created a hashtable of size 3.");
		cityhashtable2.Insert("Salzburg", 5020);
		cityhashtable2.Insert("Wien", 1010);
		cityhashtable2.Insert("Linz", 4010);
		Console.WriteLine("Removing Salzburg, Wien, Linz:");
		cityhashtable2.Remove("Salzburg");
		cityhashtable2.Remove("Wien");
		cityhashtable2.Remove("Linz");
		cityhashtable2.Print();  //wasOccupied is true for all slots!
		Debug.Assert(!cityhashtable2.Contains("Wien"));
		Console.WriteLine("Inserting Hallein:");
		cityhashtable2.Insert("Hallein", 5040);
		cityhashtable2.Print();
		
		
		
		
		Console.WriteLine();
		Console.WriteLine();
		Console.WriteLine("======================================");
		Console.WriteLine("Multiplication method: ");
		Console.WriteLine("======================================");
		
		MyHashtableDH<double, string> multHT = new MyHashtableDH<double, string>(7);
		multHT.Insert(3.14159265, "PI");
		multHT.Insert(42, "solution to everything");
		multHT.Insert(-2.718281828459045, "-Euler");
		multHT.Insert(1.41421356, "Sqrt(2)");
		multHT.Insert(2.718281828459045, "Euler");
		multHT.Insert(10E8, "BigNum");
		multHT.Print();
	}

}