using System;
using System.Collections.Generic;
using System.Diagnostics;

class MainClass {
	static void Main() {
		try {
			//Testing

			//Test if Queue is actually Min-Heap (smallest DateTime is element of Peak())
			TaskManager test = new TaskManager();

			//test.GetNextTask(); //This would throw an exception

			Task firstTask = new Task(new DateTime(2015, 4, 10), "First");
			Task secondTask = new Task(new DateTime(2015, 4, 20), "Second");
			Task thirdTask = new Task(new DateTime(2014, 1, 13), "Third");
			Task fourth = new Task(new DateTime(2015, 6, 12), "Fourth");
			Task fifth = new Task(new DateTime(2011, 3, 30), "Fifth");
			Task sixth = new Task(new DateTime(2016, 9, 11), "Sixth");
			Task seventh = new Task(new DateTime(2013, 3, 14), "Seventh");

			test.AddTask(firstTask);
			test.AddTask(secondTask);
			test.AddTask(thirdTask);
			test.AddTask(fourth);
			test.AddTask(fifth);
			test.AddTask(sixth);
			test.AddTask(seventh);
			Debug.Assert(test.GetNextTask() == fifth, "Peaking first task did not deliver smallest item");

			//Now test min sorting
			test.Tasks.Dequeue();
			Debug.Assert(test.GetNextTask() == seventh, "Heap was not correctly sorted after removing");

			test.Process();
			Console.WriteLine("\n/// All tests passed ///  ╰( ⁰ ਊ ⁰ )━☆ﾟ.*･｡ﾟ");

		} catch (Exception e) {
			Console.WriteLine("\nException thrown:\n" + e.Message + "\t(ﾉಠдಠ)ﾉ︵┻━┻");
		}
	}	
}





