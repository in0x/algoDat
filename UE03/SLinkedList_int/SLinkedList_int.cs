using System;
using System.Diagnostics;

public class SLinkedList {

	public Node Head {get; private set; }
	
	public SLinkedList() {
		Head = null;
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
		n.Next = Head;  //let n point to old head
		//empty list: n.Next == null, which is ok.
		Head = n; //reset head ref. to the new node
	}
	
	public void AddAfter(Node pre, int data) {
		if (pre == null) 
			throw new ArgumentNullException("pre is null!");
		Node n = new Node(data);
		n.Next = pre.Next; //works even if pre == tail
		pre.Next = n;	 
	}
	//This code does NOT check if pre exists in the list at all!	
	//(Would require a linear search!)

	
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
		
		//at first, we have to find the last but one node, by iterating from the beginning:
		Node act = Head; 
		Node pre = null; //points to the node one before act.
		while (act.Next != null) {
			pre = act; //actualize
			act = act.Next;  //no NullReferenceException bc. act != null.
		}
		if (pre != null) //if there were at least two nodes
			//simply set the Next-Reference to null, so the last element is not connected anymore!
			pre.Next = null; 
		else //if there was only one node...
			Head = null; // ... the list must now be empty.
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













