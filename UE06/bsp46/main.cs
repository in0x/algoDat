using System;
using System.Collections.Generic;
using System.Diagnostics;

class MainClass {
	static void Main() {
		SortedSet<GameObject> x_sort = new SortedSet<GameObject>(new xComparer());
		SortedSet<GameObject> y_sort = new SortedSet<GameObject>(new yComparer());

		TimeSpan start = Process.GetCurrentProcess().TotalProcessorTime;

		Console.WriteLine("Testing with random input data of three million elements\n");
		for (int i = 0; i < 3000000; i++) {
			GameObject go = new GameObject();
			x_sort.Add(go);
			y_sort.Add(go);
		}

		TimeSpan end = Process.GetCurrentProcess().TotalProcessorTime;
		double passed = (end-start).TotalMilliseconds;
		Console.WriteLine("\nFinished inserting in " + passed + " ms\n");

		SortedSet<GameObject> x_select = x_sort.GetViewBetween(new GameObject(0,0), new GameObject(50,0));
		SortedSet<GameObject> y_select = y_sort.GetViewBetween(new GameObject(0,0), new GameObject(0,50));
		
		/*foreach (GameObject go in x_select) 
			Console.WriteLine("x: " + go.x + "\ty: "  + go.y);

		Console.WriteLine();

		foreach (GameObject go in y_select) 
			Console.WriteLine("x: " + go.x + "\ty: "  + go.y); */

		start = Process.GetCurrentProcess().TotalProcessorTime;

		x_select.IntersectWith(y_select);

		end = Process.GetCurrentProcess().TotalProcessorTime;
		passed = (end-start).TotalMilliseconds;
		Console.WriteLine("\nFinished intersecting in " + passed + " ms\n");

		Console.WriteLine();
		foreach (GameObject go in x_select) 
			Console.WriteLine("x: " + go.x + "\ty: "  + go.y);
		
	}
}

class GameObject : IComparable {
	public double x;
	public double y;
	public int ID;
	static int ID_Counter = 0;
	static Random rand = new Random();

	public GameObject() {
		x = rand.Next(0, 101);
		y = rand.Next(0, 101);
		ID = ID_Counter;
		ID_Counter++;
	}

	public GameObject(double _x, double _y) {
		x = _x;
		y = _y;
		ID = ID_Counter;
		ID_Counter++;
	}

	public int CompareTo(Object o) {
		GameObject other = o as GameObject;
		if (other == null)
			throw new ArgumentException("Comparing to non-GameObject");

		if (x.CompareTo(other.x) == 0) {
			if (y.CompareTo(other.y) == 0) 
				return ID.CompareTo(other.ID);
			else return y.CompareTo(other.y);
		} else 
			return x.CompareTo(other.x);
	}
}

class xComparer : IComparer<GameObject> {
	public int Compare(GameObject go1, GameObject go2) {
		return go1.x.CompareTo(go2.x);
	}
}

class yComparer : IComparer<GameObject> {
	public int Compare(GameObject go1, GameObject go2) {
		return go1.y.CompareTo(go2.y);
	}
}