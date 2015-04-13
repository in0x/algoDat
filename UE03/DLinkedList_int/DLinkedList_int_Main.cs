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
	
	public static void Main() {
		testAddFirst();
		testRemoveFirst();
	}
}