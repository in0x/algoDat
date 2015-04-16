using System;
using System.Diagnostics;


class DLinkedList_int_Main {
	
	public static void testAddFirst() {
		DLinkedList l = new DLinkedList();
		l.AddFirst(3);
		Node head = l.Head;
		Debug.Assert(head.Data == 3);
		Debug.Assert(l.Tail.Data == 3);
		l.AddFirst(2);
		head = l.Head;
		Debug.Assert(head.Data == 2);
		Debug.Assert(l.Tail.Data == 3);
		Debug.Assert(l.Tail.Prev == head);
		l.AddFirst(1);
		head = l.Head;
		Debug.Assert(head.Data == 1);
		//l.Print(); //expected: 1, 2, 3
	}
	
	public static void testRemoveFirst() {
		DLinkedList l = new DLinkedList();
		l.AddFirst(3);
		l.AddFirst(2);
		l.AddFirst(1);
		l.RemoveFirst();
		Debug.Assert(l.Count() == 2);
		Debug.Assert(l.Head.Data == 2);
		Debug.Assert(l.Tail.Data == 3);
		Debug.Assert(l.Head.Next.Prev.Data == 2);
		Debug.Assert(l.Head.Next.Data == 3);
		Debug.Assert(l.Head.Next.Prev == l.Head);
		Debug.Assert(l.Head.Next.Next == null);
		l.RemoveFirst();
		Debug.Assert(l.Tail.Data == 3);
		l.RemoveFirst();
		Debug.Assert(l.IsEmpty());
		//test InvalidOperationException:
		try {
			l.RemoveFirst();
			Debug.Assert(false); //must not be called
		}
		catch (InvalidOperationException) {
			//must be called
		}
		catch {
			Debug.Assert(false); //must not be called
		}	
	}

	public static void testRemove() {
		DLinkedList l = new DLinkedList();
		//Created overload method to add Nodes directly to list;
		Node one = new Node(1);
		Node two = new Node(2);
		Node three = new Node(3);
		l.AddFirst(three);
		l.AddFirst(two);
		l.AddFirst(one);
		Debug.Assert(l.Head.Data == 1);
		Debug.Assert(l.Tail.Data == 3);
		l.Remove(three);
		Debug.Assert(l.Tail.Data == 2);
		Debug.Assert(l.Tail.Prev.Data == 1);
		Debug.Assert(l.Head.Next.Data == 2);
		l.Remove(two);
		Debug.Assert(l.Tail.Data == l.Head.Data);
	}

	public static void testAddBefore() {
		DLinkedList l = new DLinkedList();
		Node one = new Node(1);
		Node two = new Node(2);
		Node three = new Node(3);
		l.AddFirst(three);
		l.AddFirst(two);
		l.AddFirst(one);
		l.AddBefore(two, 4);
		Debug.Assert(l.Head.Next.Data == 4);
		Debug.Assert(l.Head.Next.Next.Data == 2);
		l.AddBefore(three, 42);
		Debug.Assert(l.Tail.Prev.Data == 42);
		Debug.Assert(l.Tail.Prev.Prev.Data == 2);
	}

	public static void testExchange() {
		DLinkedList l = new DLinkedList();
		Node one = new Node(1);
		Node two = new Node(2);
		Node three = new Node(3);
		Node four = new Node(4);
		Node five = new Node(5);
		l.AddFirst(five);
		l.AddFirst(four);
		l.AddFirst(three);
		l.AddFirst(two);
		l.AddFirst(one);
		l.Print();
		l.Exchange(two, four);
		l.Print();
	}
	
	public static void Main() {
		testAddFirst();
		testRemoveFirst();
		testRemove();	
		testAddBefore();
		testExchange();
		Console.WriteLine("// All tests passed //");
	}
}