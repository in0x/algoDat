using System;

class DListPriorityQueue {
	private DLinkedList list;

	public DListPriorityQueue() {
		list = new DLinkedList();
	}

	private void Swap(Node i, Node j) {

	}

	public bool isEmpty() {
		return list.isEmpty();
	}

	private static int ParentIdx(int idx) {
		return (idx-1)/2; 
	}

	private static int RightChildIdx(int idx) {
		return (2*idx + 1);
	}

	private static int LeftChildIdx(int idx) {
		return (2*idx + 2);
	}

	public Node Front() {
		if (isEmpty()) throw new InvalidOperationException("Empty!");
		return list.head;
	}

	public void Enqueue(Node Data) {
		list.Add(Node);
		Upheap(GetLastIdx());
	}

	private void Upheap(int idx) {
		while (idx > 0)
	}

	private void Downheap(int idx) {

	}

	public void Dequeue() {

	}

	public void Print() {

	}

	private int GetLastIdx() {
		return list.Count() - 1;
	}
}