using System;

class calcTime {
	static void Main(string[] args) {
		if (args.Length != 3) {
			Console.WriteLine("Usage: calc.exe [x*2] [x] [x*2_el]");
			return;
		}
		calcRunLength(Convert.ToDouble(args[0]), Convert.ToDouble(args[1]), Convert.ToInt32(args[2]));
	}

	static void calcRunLength(double x1, double x2, int numEl) {
		double x = (x1/ x2);
		double c = Math.Log(x) / Math.Log(2);
		double a = x1 / Math.Pow(numEl, c);
		Console.WriteLine("T(n) = " + a + " * n ^ " + c);
	}
}