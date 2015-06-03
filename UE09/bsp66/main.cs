/* 141061024, fhs37246
   * Philipp Welsch
   * ue09 bsp65    */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

enum TestType {Random, Ascending, Descending};

class MainClass {
	static void Main() {
		Test();
		testRunTime(TestType.Random);
		testRunTime(TestType.Ascending);
		testRunTime(TestType.Descending);
	}

	static void Test() {
		//Algorithm returns if left = right, so case of one Element is covered
		//if two Elements are provided the left is going to be selected since avg{int}(a, b) = Floor((a+b)/2) 
		Debug.Assert(SortingAlgos<int>.GetMedian(1,2,3) == 2, "#1");
		Debug.Assert(SortingAlgos<int>.GetMedian(3,2,1) == 2, "#2");
		Debug.Assert(SortingAlgos<int>.GetMedian(4,4,4) == 4, "#3");
		Debug.Assert(SortingAlgos<int>.GetMedian(2,2,3) == 2, "#4");

	}

	static void testRunTime(TestType type) {
		const int steps = 20;
		Random rand = new Random();

		List<double> medTimes = new List<double>();
		List<double> randTimes = new List<double>();

		StreamWriter sw = new StreamWriter("out.txt");
		
		switch(type) {
			case TestType.Random:
				sw.WriteLine("Testing random inputs - Start");
				sw = new StreamWriter("rand.txt");
				break;
			case TestType.Ascending:
				sw.WriteLine("Testing ascending inputs - Start");
				sw = new StreamWriter("asc.txt");
				break;
			case TestType.Descending:
				sw.WriteLine("Testing descending inputs - Start");
				sw = new StreamWriter("desc.txt");
				break;
		}
		sw.WriteLine("for 0 -> " + Math.Pow(2,steps) + " elements");

		TimeSpan start;
		TimeSpan end;
		double passed;

		for (int i = 0; i < steps; i++) {
			List<double> sortMed = new List<double>((int)Math.Pow(2,i));
			List<double> sortRand = new List<double>((int)Math.Pow(2,i));

			switch (type) {
				case TestType.Random:
					for(int el = 0; el < Math.Pow(2,i); el++) {
						double r = rand.Next(0, (int)Math.Pow(2,i));
						sortMed.Add(r);
						sortRand.Add(r);
					}
					break;
				case TestType.Ascending:
					for(int el = 0; el < Math.Pow(2,i); el++) {
						double r = el;
						sortMed.Add(r);
						sortRand.Add(r);
					}
					break;
				case TestType.Descending:
					for(int el = (int)Math.Pow(2,i); el > 0; el--) {
						double r = el;
						sortMed.Add(r);
						sortRand.Add(r);
					}
					break;
			}

			//Test sorting with random pivot
			start = Process.GetCurrentProcess().TotalProcessorTime;
			SortingAlgos<double>.QuickSortRand(sortRand, 0, sortRand.Capacity - 1);
			end = Process.GetCurrentProcess().TotalProcessorTime;
			passed = (end-start).TotalMilliseconds;
			randTimes.Add(passed);

			//Test sorting with median-of-three pivot
			start = Process.GetCurrentProcess().TotalProcessorTime;
			SortingAlgos<double>.QuickSortMed(sortMed, 0, sortMed.Capacity - 1);
			end = Process.GetCurrentProcess().TotalProcessorTime;
			passed = (end-start).TotalMilliseconds;	
			medTimes.Add(passed);		

		}
		sw.WriteLine("\nTimes with random pivot\n");
		printTable(randTimes, sw, steps);
		sw.WriteLine("\nTimes with median pivot\n");
		printTable(medTimes, sw, steps);
		sw.Close();
	}

	static void printTable(List<double> arr, StreamWriter sw, int length) {
		for (int i = 0; i < length; i++) {
			sw.WriteLine("Elements: " + Math.Pow(2, i) + " \tTime: " + arr[i]);
		}
	}
}
