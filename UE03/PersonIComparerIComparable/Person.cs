using System;
using System.Collections.Generic;

class Person : IComparable {   // IComparable needed for LinkedList<T>.Sort() !
	public string FName {get; set;  }
	public string LName {get; set; }
	public DateTime BDay {get; set; }  //birthday
	
	public Person(string fn, string ln, DateTime bday) {
		this.BDay = bday;
		this.FName = fn;
		this.LName = ln;
	}
	
	// IComparable requires this method to be implemented. Otherwise,
	// Sort() would not know how to sort! This is the default sorting
	// order, which can be changed by either re-writing CompareTo,
	// or using an IComparer additionally.
	public int CompareTo(Object o) {
		Person other = (Person) o; 
		//Might cause an exception if "o" is not a Person!
		//Alternative: Person other = o as Person; //keyword "as"!
		//With that, "other" gets null if "o" is not a Person!
		
		
		//Here, LName is used for sorting, but:
		//if LNames are the same, FName is used.
		//if FName are the same, BDay is used.
		if (LName.CompareTo(other.LName) == 0) { //same last names
			if (FName.CompareTo(other.LName) == 0) { //same first names
				return BDay.CompareTo(other.BDay);
			}
			else return FName.CompareTo(other.FName); //same last names, but different first names
		}
		else return LName.CompareTo(other.LName); //different last names
	}
	
	public override string ToString() {
		return FName + " " + LName + " " + BDay.Day + "." + BDay.Month + "." + BDay.Year;
	}
}

// An IComparer class can be used to change the attributes
// according to which we want to sort. (Here: according to birthday.)
// An object of this class must be passed to Sort(), 
// then not the default "CompareTo"-Method is used!
// This allows for great flexibility in sorting orders.
class BirthdayComparer : IComparer<Person> {

	public int Compare(Person p1, Person p2) {
		return p1.BDay.CompareTo(p2.BDay);	
	}
}

class Program {

	public static void Main() {
		Person p1 = new Person("Anton", "Aschauer", new DateTime(1995, 12, 31));
		Person p2 = new Person("Berta", "Berger", new DateTime(1994, 12, 31));
		Person p3 = new Person("Caesar", "Cipuvic", new DateTime(1993, 12, 31));
		Person p4 = new Person("Dora", "Dollinger", new DateTime(1993, 12, 30));
		Person p5 = new Person("Bernhard", "Berger", new DateTime(1996, 1, 1));
		List<Person> list = new List<Person>(4);
		list.Add(p5);
		list.Add(p4); 	 //only references are stored in the array!
		list.Add(p3); 
		list.Add(p2); 
		list.Add(p1); 
		list.Sort(); //uses Person.CompareTo!
		Console.WriteLine("According to last names: ");
		foreach (Person p in list) {
			Console.WriteLine(p);
		}
		
		list.Sort(new BirthdayComparer()); //uses BirthdayComparer
		Console.WriteLine("\nAccording to birthdays: ");
		foreach (Person p in list) {
			Console.WriteLine(p);
		}
	}
}