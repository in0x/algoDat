/* 141061024, fhs37246
   * Philipp Welsch
   * ue09 bsp67    */
using System;
using System.Collections.Generic;
using System.Diagnostics;

//Sorting: O(n*log(n))
//Get Elements between: O(n)
//Intersecting: O(n*log(n))

class MainClass {
	static void Main() {
		List<Schedule> timesAr = new List<Schedule>();
		List<Schedule> timesDep = new List<Schedule>();
		
		Schedule test1 = new Schedule(new Time(8, 24), new Time(8, 33));
		Schedule test2 = new Schedule(new Time(13, 42), new Time(14, 31));
		Schedule test3 = new Schedule(new Time(8, 20), new Time(9, 0));

		timesAr.Add(test1);
		timesAr.Add(new Schedule(new Time(8, 32), new Time(8, 37)));
		timesAr.Add(test3);
		timesAr.Add(new Schedule(new Time(12, 18), new Time(12, 32)));
		timesAr.Add(new Schedule(new Time(8, 32), new Time(8, 37)));
		timesAr.Add(new Schedule(new Time(9, 0), new Time(9, 15)));	
		timesAr.Add(new Schedule(new Time(7, 0), new Time(7, 23)));
		timesAr.Add(new Schedule(new Time(8, 30), new Time(9, 10)));

		timesDep.Add(test1);
		timesDep.Add(new Schedule(new Time(8, 32), new Time(8, 37)));
		timesDep.Add(test3);
		timesDep.Add(new Schedule(new Time(12, 18), new Time(12, 32)));
		timesDep.Add(new Schedule(new Time(8, 32), new Time(8, 37)));
		timesDep.Add(new Schedule(new Time(9, 0), new Time(9, 15)));	
		timesDep.Add(new Schedule(new Time(7, 0), new Time(7, 23)));
		timesDep.Add(new Schedule(new Time(8, 30), new Time(9, 10)));

		SortArray testAr = new SortArray(timesAr, new arriveComparer());
		SortArray testDep = new SortArray(timesDep, new departComparer());
		testAr.Sort();
		testDep.Sort();
		Debug.Assert(testAr.GetIndex(test1) == 2);
		Debug.Assert(testAr.GetIndex(test2) == -1);
		Debug.Assert(testDep.GetIndex(test3) == 4);

		Console.WriteLine("Schedules sorted by Arrival");
		testAr.Print();
		Schedule searchSpan = new Schedule(new Time(8, 22), new Time(9, 5));
		testAr = testAr.GetViewBetween(searchSpan);
		Console.WriteLine("\n");

		Console.WriteLine("Schedules sorted by Departure");
		testDep.Print();
		testDep = testDep.GetViewBetween(searchSpan);
		Console.WriteLine("\n");
		Console.WriteLine("All arrivals between " + searchSpan.ToString());
		testAr.Print();
		Console.WriteLine("\n");
		Console.WriteLine("All departures between " + searchSpan.ToString());
		testDep.Print();

		Console.WriteLine("\nBuses arriving and leaving between" + searchSpan.ToString() + ": ");
		List<Schedule> inters = testDep.IntersectWith(testAr);
		foreach(Schedule sd in inters)
			Console.WriteLine(sd.ToString());
	}
}

class Schedule : IComparable{
	public Time arrival;
	public Time departure;

	public Schedule(Time _arrival, Time _departure) {
		arrival = _arrival;
		departure = _departure;
	}

	override public string ToString() {
		return "[" + arrival.ToString() + ", " + departure.ToString() + "]";
	}

	public int CompareTo(Object o) {
		if (o.GetType() != typeof(Schedule))
			throw new InvalidOperationException("Cannot compare Schedule to Object of type" + o.GetType());
		Schedule other = (Schedule) o;	
		if (this.arrival.CompareTo(other.arrival) == 0)
			return (this.departure.CompareTo(other.departure));
		else 	
			return this.arrival.CompareTo(other.arrival);
	}
}

class Time : IComparable{
	public uint hours;
	public uint minutes;

	public Time(uint h, uint m) {
		if (h > 23 || m > 59)
			throw new ArgumentException("Invalid time");
		hours = h;
		minutes = m;
	}

	public int CompareTo(Object o) {
		if (o.GetType() != typeof(Time))
			throw new InvalidOperationException("Cannot compare Time to Object of type" + o.GetType());
		Time other = (Time) o;	
		if (this.hours.CompareTo(other.hours) == 0)
			return (this.minutes.CompareTo(other.minutes));
		else 	
			return this.hours.CompareTo(other.hours);
	}

	override public string ToString() {
		return hours + " : " + minutes;
	}
}

class SortArray {
	private List<Schedule> elements {get; set;}
	private IComparer<Schedule> comparer;

	public SortArray(IComparer<Schedule> c) {
		elements = new List<Schedule>();
		c = comparer;
	}

	public SortArray(List<Schedule> li, IComparer<Schedule> c) {
		elements = li;
		comparer = c;
	}

	public void Add(Schedule data) {
		elements.Add(data);
	}

	public int GetIndex(Schedule sd) {
		return elements.IndexOf(sd);
	}

	public SortArray GetViewBetween(Schedule span){
		return new SortArray(elements.FindAll(delegate(Schedule current){
				if (comparer.GetType() == typeof(arriveComparer))
					return (current.arrival.CompareTo(span.arrival) > 0 && current.arrival.CompareTo(span.departure) < 0);
				else 	
					return (current.departure.CompareTo(span.arrival) > 0 && current.departure.CompareTo(span.departure) < 0);
		}), comparer);
	} 

	public List<Schedule> IntersectWith(SortArray other) {
		List<Schedule> smaller;
		List<Schedule> larger;
		List<Schedule> temp = new List<Schedule>();
		if (elements.Count < other.elements.Count) {
			smaller = elements;
			larger = other.elements;
		} else {
			smaller = other.elements;
			larger = elements;
		}

		smaller.ForEach(delegate(Schedule sd) {
			int index = larger.BinarySearch(sd);
			if ( index >= 0 && index < larger.Capacity - 1)
				temp.Add(sd);
		});	
		return temp;
	}

	public void Sort() {
		elements.Sort(comparer);
	}

	public void Print() {
		foreach (Schedule sd in elements) 
			Console.WriteLine("Arriving: " + sd.arrival.ToString() + " Departing: " + sd.departure.ToString());
	}
}

class arriveComparer : IComparer<Schedule> {
	public int Compare(Schedule sd1, Schedule sd2) {
		return sd1.arrival.CompareTo(sd2.arrival);
	}
}

class departComparer : IComparer<Schedule> {
	public int Compare(Schedule sd1, Schedule sd2) {
		return sd1.departure.CompareTo(sd2.departure);
	}
}