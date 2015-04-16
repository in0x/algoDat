using System;
using System.Diagnostics;

public class SLinkedList {

	public Node Head {get; private set; }
	public Node Tail {get; private set; }
	
	public SLinkedList() {
		Head = null;
		Tail = null;
	}
	
	public Node Find(int data) {
		Node act = Head;
		while (act != null) {
			if (act.Data == data) return act;
			act = act.Next;
		}
		return null;
	}
		
	public void AddFirst(int data) {
		Node n = new Node(data); //create new node
		if (Head == null) {
			Head = n;
			Tail = n;
			return;
		}
		n.Next = Head;  //let n point to old head
		//empty list: n.Next == null, which is ok.
		Head = n; //reset head ref. to the new node
	}

	public void AddFirst(Node n) {
		if (Head == null) {
			Head = n;
			Tail = n;
			return;
		}
		n.Next = Head;
		Head = n; 
	}
	
	public void AddAfter(Node pre, int data) {
		if (pre == null) 
			throw new ArgumentNullException("pre is null!");
		Node n = new Node(data);
		if (Head == Tail) {
			Tail = n;
			Head.Next = n;
			return;	
		}
		n.Next = pre.Next; //works even if pre == tail
		pre.Next = n;	 
	}
	//This code does NOT check if pre exists in the list at all!	
	//(Would require a linear search!)

	public void AddLastWithoutTail(int data) { 
		Node n = new Node(data);
		if (Head == null)
			Head = n;
		Node last = Head;
		while (last.Next != null) 
			last = last.Next;
		last.Next = n;
		return;
	} 

	public void AddLast(int data) {
		if (Head == null) {
			AddFirst(data);
		}
		Node n = new Node(data);
		Tail.Next = n;
		Tail = n;
	}

	public void RemoveFirst() {
		if (Head == null)
			throw new InvalidOperationException(	
				"Cannot remove from an empty list!");
		Head = Head.Next;
	}
	
	public void RemoveAfter(Node pre) {
		if (pre == null)
			throw new ArgumentNullException("pre was null!");
		Node n = pre.Next;  //n gets deleted
		if (n == null) 
			throw new InvalidOperationException("pre was tail!");
		pre.Next = n.Next; 
		//if pre's successor is tail, pre.Next == null.
	} 

	public void Remove(Node n) {
		if (n == null)  //empty list
			throw new ArgumentNullException("n is null!");		
		if (Head == n) {  //first element to remove
			RemoveFirst();
			return;
		} else if (Tail == n) {
			RemoveLast();
			return;
		}
		Node pre = Head;
		while (pre.Next != n) { //find node BEFORE n
			pre = pre.Next;
			if (pre == null)
				throw new InvalidOperationException("n not found!");
		}
		Debug.Assert(pre.Next != null); //ensures loop was correct
		RemoveAfter(pre); 
	}
		
	public void RemoveLast() {
		if (Head == null)
			throw new InvalidOperationException("Cannot remove from an empty list!");

		Node pre = null;
		Node cur = Head;
		while (cur.Next != null) {
			pre = cur;
			cur = cur.Next; 
		}
		if (pre != null) {
			pre.Next = null;
			Tail = pre;
		} else {
			Head = null;
			Tail = null;
		}

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
	
	public Node(int data) {
		this.Data = data;
		Next = null;
	}
}













