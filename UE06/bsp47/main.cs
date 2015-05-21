using System;
using System.Collections.Generic;
using System.Diagnostics;

class MainClass {
	static void Main() {
		
		SortArray test_x = new SortArray('x');
		SortArray test_y = new SortArray('y');

		TimeSpan start = Process.GetCurrentProcess().TotalProcessorTime;
		for (int i = 0; i < 1000000; i++) {
			GameObject go = new GameObject();
			test_x.Add(go);
			test_y.Add(go);
		}
		test_x.Sort();
		test_y.Sort();
		TimeSpan end = Process.GetCurrentProcess().TotalProcessorTime;
		double passed = (end-start).TotalMilliseconds;
		Console.WriteLine("\nFinished inserting and sorting in " + passed + " ms\n");
		
		test_x = test_x.GetViewBetween(new GameObject(40,0), new GameObject(60,0));
		test_y = test_y.GetViewBetween(new GameObject(0,40), new GameObject(0,50));

		start = Process.GetCurrentProcess().TotalProcessorTime;
		test_x.IntersectWith(test_y);
		end = Process.GetCurrentProcess().TotalProcessorTime;
		passed = (end-start).TotalMilliseconds;
		Console.WriteLine("\nFinished intersecting in " + passed + " ms\n");

		test_x.Print();

	}
}

class SortArray {
	private List<GameObject> elements {get; set;}
	private char SortEl;

	public SortArray(char s) {
		elements = new List<GameObject>();
		SortEl = s;
	}

	public SortArray(char s, List<GameObject> li) {
		SortEl = s;
		elements = li;
	}

	public void Add(GameObject data) {
		elements.Add(data);
	}

	public SortArray GetViewBetween(GameObject lower, GameObject upper){
		return new SortArray(SortEl, elements.FindAll(delegate(GameObject current){
				if (SortEl == 'x')
					return (current.x > lower.x && current.x < upper.x);
				else 	
					return (current.y > lower.y && current.y < upper.y);
		}));
	}

	public void IntersectWith(SortArray other) {
		List<GameObject> smaller;
		List<GameObject> larger;
		List<GameObject> temp = new List<GameObject>();
		if (elements.Count < other.elements.Count) {
			smaller = elements;
			larger = other.elements;
		} else {
			smaller = other.elements;
			larger = elements;
		}

		smaller.ForEach(delegate(GameObject go) {
			if (larger.BinarySearch(go) > 0)
				temp.Add(go);
		});
		
		elements = temp;
		Console.WriteLine(temp.Count);
	}

	public void Sort() {
		if (SortEl == 'x')
			elements.Sort(new xComparer());
		else
			elements.Sort(new yComparer());
	}

	public void Print() {
		foreach (GameObject go in elements)
			Console.WriteLine("x: " +  go.x + "\ty: " + go.y); 
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