using System;
using System.Collections.Generic;

class TaskManager {
	public DateTime Today {get; private set;} 
	public MyHeapPriorityQueue<Task> Tasks {get; private set;}
	
	public TaskManager() {
		Tasks = new MyHeapPriorityQueue<Task>();
		Today = DateTime.Today;
	}

	public void AddTask(Task t) {
		if (t == null)
			throw new ArgumentNullException("Task to add is null");
		Tasks.Enqueue(t);
	}

	public Task GetNextTask() {
		return Tasks.Front();
	}

	public void Print() {
		Tasks.Print();
	}

	public void Process() {
		while (!Tasks.IsEmpty()) {
			Tasks.Dequeue();
			if(new Random().Next(0,2) == 0) 
				Tasks.Enqueue(new Task(DateTime.Now, "things (evil)"));
		}
	} 
}	
