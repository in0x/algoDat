using System;

class Task : IComparable{

	public DateTime Deadline {get; private set;}
	public string Description {get; private set;}

	public Task(DateTime time, string text) {
		Deadline = time;
		Description = text;
	}

	public int CompareTo(Object obj) {
		Task other = obj as Task; 
		return this.Deadline.CompareTo(other.Deadline);
	}
}


