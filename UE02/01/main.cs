//comment
using System;
using System.Diagnostics;

class MainClass {
	static void Main() {
		Console.WriteLine(rec.sum(4));
		Console.WriteLine(rec.pow(3, 4));
		Debug.Assert(rec.sum(4) == ((4 * 4 + 4)/2));
		rec.cd(4);
	}

	static class rec {
		public static int sum(int n) {
			if (n > 0) return n + sum(n - 1);
			else return 0;
		}

		public static double pow(double x, uint n) {
			if (n == 0) return 1;
			else return x * pow(x, n - 1); 
		}

		public static void cd(int n) {
			if (n == 0) Console.WriteLine(n);
			else {
				Console.WriteLine(n);
				cd(n - 1);
			}
		}
	}
}