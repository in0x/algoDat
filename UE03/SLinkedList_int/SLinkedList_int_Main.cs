using System;
using System.Diagnostics;


class SLinkedList_int_Main {
	
	public static void testAddFirst() {
		SLinkedList l = new SLinkedList();
		l.AddFirst(3);
		Node head = l.Head;
		Debug.Assert(head.Data == 3);
		l.AddFirst(2);
		head = l.Head;
		Debug.Assert(head.Data == 2);
		l.AddFirst(1);
		head = l.Head;
		Debug.Assert(head.Data == 1);
		//l.Print(); //expected: 1, 2, 3
	}
	
	public static void testAddAfter() {
		//test ArgumentNullException:
		SLinkedList l = new SLinkedList();
		try {
			l.AddAfter(null, 2);
			Debug.Assert(false); //must not be called			
		}
		catch (ArgumentNullException) {
			//must be called!
		}
		catch {
			Debug.Assert(false); //must not be called
		}
		
		l.AddFirst(1);
		Node head = l.Head;
		l.AddAfter(head, 2);
		Node headNext = head.Next;
		Node two = l.Find(2);
		Debug.Assert(headNext == two); //must be references to the same node
		l.AddAfter(two, 4); //test insertion at end
		l.AddAfter(two, 3); //test insertion in between
		//l.Print(); //expected: 1, 2, 3, 4
	}
	
	public static void testRemoveFirst() {
		SLinkedList l = new SLinkedList();
		l.AddFirst(3);
		l.AddFirst(2);
		l.AddFirst(1);
		l.RemoveFirst();
		Debug.Assert(l.Count() == 2);
		Debug.Assert(l.Head.Data == 2);
		Debug.Assert(l.Head.Next.Data == 3);
		Debug.Assert(l.Head.Next.Next == null);
		l.RemoveFirst();
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
	
	public static void testRemoveAfter() {
		SLinkedList l = new SLinkedList();
		l.AddFirst(4);
		l.AddFirst(3);
		l.AddFirst(2);
		l.AddFirst(1);
		l.AddFirst(0);
		
		//test InvalidOperationException:
		Node last = l.Find(4);
		try {
			l.RemoveAfter(last);
			Debug.Assert(false);
		}
		catch (InvalidOperationException) {
			//must be called
		}
		catch {
			Debug.Assert(false); //must not be called
		}
		//test removal of Node three:
		Node two = l.Find(2);
		l.RemoveAfter(two); //remove three
		Debug.Assert(two.Next.Data == 4);
		Debug.Assert(l.Count() == 4);
		l.RemoveAfter(two); //remove four
		Debug.Assert(two.Next == null);
		l.RemoveAfter(l.Head);
		Debug.Assert(l.Head.Data == 0);
		Debug.Assert(l.Head.Next == two);
		Debug.Assert(l.Count() == 2);
	}
	
	public static void testRemove() {
		SLinkedList l = new SLinkedList();
		l.AddFirst(3);
		l.AddFirst(2);
		l.AddFirst(1);
		Node two = l.Find(2);
		l.Remove(two);
		Debug.Assert(l.Head.Next.Data == 3);
		Debug.Assert(l.Count() == 2);
		l.Remove(l.Head.Next);
		l.Remove(l.Head);
		Debug.Assert(l.Count() == 0);
		Debug.Assert(l.IsEmpty());
		//test ArgumentNullException:
		try {
			l.Remove(l.Head);
			Debug.Assert(false); //must not be called
		}
		catch (ArgumentNullException) {
			//must be called!
		}
		catch {
			Debug.Assert(false);
		}
		//test InvalidOperationException
		try {
			l.AddFirst(13);
			Node n = new Node(17); //dummy node, not in list
			l.Remove(n); //is already removed, cannot be found
			Debug.Assert(false); //must not be called
		}
		catch (InvalidOperationException) {
			//must be called!
		}
		catch {
			Debug.Assert(false); //must not be called
		}
	}
		
	public static void testRemoveLast() {
		SLinkedList l = new SLinkedList();
		l.AddFirst(3);
		l.AddFirst(2);
		l.AddFirst(1);
		l.RemoveLast();
		Debug.Assert(l.Count() == 2);
		Debug.Assert(l.Head.Next.Next == null);
		Debug.Assert(l.Head.Next.Data == 2);
		l.RemoveLast();
		Debug.Assert(l.Head.Next == null);
		Debug.Assert(l.Head.Data == 1);
		l.RemoveLast();
		Debug.Assert(l.IsEmpty());
		//test InvalidOperationException:
		try {
			l.RemoveLast();
			Debug.Assert(false); //must not be called
		}
		catch (InvalidOperationException) {
			//must be called!
		}
		catch {
			Debug.Assert(false); //must not be called
		}	
	}
	
	public static void Main() {
		testAddFirst();
		testAddAfter();
		testRemoveFirst();
		testRemoveAfter();
		testRemove();
		testRemoveLast();
	}
}