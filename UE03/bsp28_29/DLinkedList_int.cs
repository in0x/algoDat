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

	public void AddFirst(Node n) {
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

	public void Remove(Node n) {
		if (n == null) 
			throw new ArgumentNullException("n is null!");
		if (n == Head) 
			RemoveFirst();
		else if (n == Tail) {
			Tail = Tail.Prev;
			Tail.Next = null;
		}
		else {
			Node current = Head;
			while (current != n) {
				current = current.Next;
				if (current == null)
					throw new InvalidOperationException("node not found!");
			}
			current.Prev.Next = current.Next;
			current.Next.Prev = current.Prev;
		}
	}

	public void AddBefore(Node n, int data) {
		if (n == null) 
			throw new ArgumentNullException("previous node is null!");
		Node current = Head;
		while (current != n) {
			current = current.Next;
			if (current == null)
				throw new InvalidOperationException("node not found!");
		}
		Node add = new Node(data);
		add.Next = current;
		add.Prev = current.Prev;
		current.Prev.Next = add;
		current.Prev = add;
	}

	public void Exchange(Node n1, Node n2) {
		if (n1 == n2)
			throw new ArgumentException("n1 is n2");
		if (n1 == null || n2 == null)
			throw new ArgumentNullException("one of the nodes is null");
		//Unlink elements from the list
		//if (n1.Next == n2 || n1.Prev == n2) {
			Node temp = new Node(0);
			temp.Next = n2.Prev;
			temp.Prev = n1.Prev;

			n2.Prev = temp.Prev;
			n1.Prev = n1.Next;
			n1.Next = n2.Next;

			
			n2.Next = temp.Next;
			//n2.Prev = temp.Prev;

			n2.Prev.Prev = n2;
			n1.Next.Prev = n1; 
			
		//}
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













