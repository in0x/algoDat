using System;
using System.Collections.Generic;

class MyHeapPriorityQueue<T> where T : IComparable {
		private List<T> arr; //array-based implementation!!! No tree structure needed!

		private void Swap(int i, int j) {
			T cpy = arr[j];
			arr[j] = arr[i];
			arr[i] = cpy;
		}

		public MyHeapPriorityQueue(int capacity = 32) {
			arr = new List<T>(capacity);
		}

		public bool IsEmpty() {
			return arr.Count == 0;
		}
		
		//returns the index of the parent node
		private static int ParentIdx(int idx) {
			return (idx-1)/2;  
		}
		
		//returns the index of the left child 
		private int LeftChildIdx(int idx) {
			return (2*idx + 1);
			//What happens if no left child exists?
		}

		//returns the index of the right child
		private static int RightChildIdx(int idx) {
			return (2*idx + 2);
			//What happens if no right child exists?
		}
		
		//get the largest element 
		public T Front() {
			if (IsEmpty()) throw new InvalidOperationException("Empty!");
			return arr[0];
		}

		//adds an element to the heap
		public void Enqueue(T data) {
			arr.Add(data);
			//restore the heap, so that the 
			//heap-condition is satisfied
			Upheap(GetLastIdx());
		}
		
		//used for Enqueue() to restore the heap, 
		//so that the heap-condition is satisfied
		private void Upheap(int idx) {
			//swap if the parent is smaller
			while (idx >0 && 
				(arr[ParentIdx(idx)].CompareTo(arr[idx]) == 1)) {
				Swap(ParentIdx(idx), idx );
				idx = ParentIdx(idx);
			}
		}

		//remove the largest element
		public void Dequeue() {
			if (IsEmpty()) throw new InvalidOperationException("Empty!");
			//put the last element in the beginning (root)
			arr[0] = arr[GetLastIdx()];
			//remove the old last element (which is now the root)
			arr.RemoveAt(GetLastIdx());
			if (!IsEmpty()) Downheap(0); //restore heap
		}
		private void Downheap(int idx) {
			// while not already at bottom level
			while (LeftChildIdx(idx) <= GetLastIdx()) {
				//find larger child
				int childIdx = LeftChildIdx(idx);
				if (RightChildIdx(idx) <= GetLastIdx() &&
					arr[RightChildIdx(idx)].CompareTo(
							arr[LeftChildIdx(idx)]) == -1)
					childIdx = RightChildIdx(idx);
				// if the child is greater, do the swap, otherwise break
				if (arr[childIdx].CompareTo(arr[idx]) == -1) {
					Swap(childIdx, idx);
					idx = childIdx;
				} else break;
			}
		}
		
		public void Print() {
			Console.Write("[ ");
			for (int i = 0; i < arr.Count-1; i++) {
				Console.Write(arr[i] + ", ");
			}
			if (arr.Count > 0) 
				Console.WriteLine(arr[arr.Count-1] + " ]");
			else
				Console.WriteLine(" ]");		
		}
		
		//returns the index of the last element 
		//warning: must not be called when empty (what happens?)
		private int GetLastIdx() {
			return arr.Count-1;
		}

}

