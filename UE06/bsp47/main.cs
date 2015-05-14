using System;
using System.Collections.Generic;
using System.Diagnostics;

class MainClass {
	static void Main() {
		
	}
}

class QuickSortArray {
	
	List<T> elements;

	public QuickSortArray(data T) {
		elements = new List<T>();
	}

	/* private void partition() {

	}

	private void Shuffle() {

	}

	private void Sort() {

	} */
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