/* 141061024, fhs37246
   * Philipp Welsch
   * ue09 bsp65    */
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;

class MainClass {
	static void Main() {
		testRunTime();
		TestSort.runTest();
	}

	static void testRunTime() {
		Random rand = new Random();
		const int tests = 11;

		List<double> qs_times = new List<double>(tests);
		List<double> shs_times = new List<double>(tests);

		//test.ForEach(delegate(double x) {
		//	Console.WriteLine(x);
		//});

		for (int i = 0; i < tests; i++) {
			List<double> test = new List<double>(10000 * i);
			List<double> forShell = new List<double>(test.Capacity);

			for (int num = 0; num < test.Capacity; num++) {
				double r = rand.Next(0, 10000 * i);
				test.Add(r);
				forShell.Add(r);
			}

			Console.WriteLine("\n" + 10000 * i + "\n");	
			TimeSpan start = Process.GetCurrentProcess().TotalProcessorTime;
			SortingAlgos<double>.HibbardShellSort(forShell);
			TimeSpan end = Process.GetCurrentProcess().TotalProcessorTime;
			double passed = (end-start).TotalMilliseconds;
			shs_times.Add(passed); 

			start = Process.GetCurrentProcess().TotalProcessorTime;
			SortingAlgos<double>.QuickSort(test, 0, test.Count - 1);
			end = Process.GetCurrentProcess().TotalProcessorTime;
			passed = (end-start).TotalMilliseconds;
			qs_times.Add(passed);
			Console.WriteLine("Pass done:" + i);
		}
		StreamWriter sw = new StreamWriter(@"out.txt");
		printTable(qs_times, tests, sw);
		sw.WriteLine();
		printTable(shs_times, tests, sw);
		sw.Close();
	}

	static void printFancyTable(List<double> arr) {
		int maxLength = 0;
		foreach(double d in arr) 
			if (d.ToString().Length > maxLength)
				maxLength = d.ToString().Length + 1;

		foreach (double d in arr) {
			string line = "";
			line += '+';
			for (int i = 0; i <= maxLength+1; i++)
				line += '-';
			Console.Write(line + "+\n");
			line = "";
			line += "| " + d;
			for (int space = 0; space <= maxLength+1 - line.Length; space++)
				line += " ";
			Console.Write(line + " |\n");
		}		
	}

	static void printTable(List<double> arr, int length, StreamWriter sw) {
		for (int i = 0; i < length; i++) {
			sw.WriteLine((10000 * i) / 1000 + " \t" + arr[i] / 1000);
		}
	}
}

static class TestSort {
	public static void runTest() {
		List<double> testCase = new List<double>(100);
		Random rand = new Random();
		for (int i = 0; i < testCase.Capacity; i++) 
			testCase.Add(rand.Next(0,101));
		HibbardShellSortTesting(testCase);
		//SortingAlgos<double>.Print(testCase);
	}

	public static void HibbardShellSortTesting(List<double> arr) {
		int h = 1;
		while (Math.Pow(2,h) - 1 < arr.Count) h++; //find max. distance
		do {	
			h--;
			Console.WriteLine("h: " + h + ", Distance: " + (Math.Pow(2, h) - 1));
			for (int i = (int)Math.Pow(2, h) - 1; i < arr.Count; i++) {
				double elem = arr[i]; //current element
				int k; //look at all elements before index i (distance h)
				for (k = i; (k-h) >= 0 && arr[k-h].CompareTo(elem) > 0; k = k-h)
					arr[k] = arr[k-h];  // move elements h slots backward
				arr[k] = elem ; //insert elem into the now free slot
				//Debug
			}
			Debug.Assert(isSorted(arr, (int)Math.Pow(2, h) - 1), "Not sorted");
		} while (h > 1);
	}

	public static bool isSorted(List<double> arr, int stride) {
		//Check if h- subsequence is sorted
		// i.e 1 2 5 4 3 8 9 6 would be 3-sorted
		// from 0 until index + stride is larger than count check if index + stride, then index++ subsquence is sorted 
		for (int i = 0; i + stride > arr.Count; i++) {
			for (int span = i; span + stride < arr.Count; i += stride) {
				if (arr[span] < arr[span + stride])
					continue;
				else 
					return false;
			}
		}
		return true;
	}
}


