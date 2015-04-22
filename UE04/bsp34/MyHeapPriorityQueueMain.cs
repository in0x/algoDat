using System;

class MyHeapPriorityQueueMain {
	static void NotMain() {
		MyHeapPriorityQueue<int> heap = new MyHeapPriorityQueue<int>();
		
		for (int i = 0; i <= 5; i++) {
			heap.Enqueue(i);
			heap.Print();
		}
		for (int i = 0; i <= 5; i++) {
			heap.Dequeue();
			heap.Print();
		}
	}
}



