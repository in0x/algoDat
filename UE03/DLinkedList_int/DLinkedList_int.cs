using System;
using System.Diagnostics;

public class DLinkedList {

	public Node Head {get; private set; }
	public Node Tail {get; private set; }
	
	public DLinkedList() {
		Head = null;
		Tail = null;
	}
	
	public void AddFirst(int data) {
		Node n = new Node(data); //create new node
		n.Next = Head;  //n.Next refers to old head (or null)
		n.Prev = null;
		if (Head != null) 
			Head.Prev = n;
		Head = n; //reset head to new node
		if (Tail == null)
			Tail = Head; //if list was empty
	}
	
	public void RemoveFirst() {
		if (Head == null)    //empty
			throw new InvalidOperationException("List is empty!");
		if (Head == Tail) {  //only one element
			Head = null;
			Tail = null;
			return;
		} 
		//Debug.Assert(Count() >= 2);
		Head = Head.Next;  
		Head.Prev = null;
	}

	public int Count()  {
		int cnt = 0;
		Node act = Head;
		while (act != null) {
			cnt++;
			act = act.Next;
		}
		return cnt;
	}
	
	public bool IsEmpty() {
		return (Head == null);
	}

	public void Print() {
		Node act = Head;
		Console.WriteLine("Current list: ");
		if (Head == null) Console.WriteLine("<empty list>");
		//iterate from start to end:
		while (act != null) {
			Console.Write(act.Data + " ");
			act = act.Next;
		}
		Console.WriteLine();
	}	
}

public class Node {
	public int Data { get; set; }
	public Node Next { get; set; }
	public Node Prev { get; set; }
	
	public Node(int data) {
		this.Data = data;
		Next = null;
		Prev = null;
	}
}













