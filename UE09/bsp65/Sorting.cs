/* 141061024, fhs37246
   * Philipp Welsch
   * ue08 bsp57    */

using System;
using System.Collections.Generic;
using System.Diagnostics;

class SortingAlgos<T> where T : IComparable {

	public static void Print(List<T> arr) {
		Console.Write("[ ");
		foreach (T elem in arr)
			Console.Write(elem + " ");
		Console.WriteLine("]");
	}
	
	//swaps the elements at arr[i] and arr[j]
	private static void Swap(int i, int j, List<T> arr) {
		T cpy = arr[j];
		arr[j] = arr[i];
		arr[i] = cpy;
	}
	
	public static void SelectionSort(List<T> arr) {
		// Put i-th smallest element to position i  (0-th smallest means: the overall smallest)
		for (int i = 0; i < arr.Count-1; i++) {
			// Find i-th smallest element:
			int  idxMin = i;
			for (int j = i+1; j < arr.Count; j++)
				if (arr[j].CompareTo(arr[idxMin]) < 0)
					idxMin = j;
			//now idxMin is the index of the i-th smallest element, swap it with arr[i]
			Swap(idxMin, i, arr);
			//Print(arr);
		}
	}	
	
	public static void InsertionSort(List<T> arr) {
		// Insert i-th element at right postion
		for (int i = 1; i < arr.Count; i++) {
			// Put i-th element step by step to the front
			for (int k = i; (k > 0) && (arr[k-1].CompareTo(arr[k]) > 0); k--) {
 				Swap(k-1, k, arr);
				//Print(arr);
			}
		}
	}
	
	public static void InsertionSort2(List<T> arr) {
		// Insert i-th element at right postion (to the front)
		for (int i = 1; i < arr.Count; i++) {
			T elem = arr[i]; //current element
			int k; //look at all elements before index i
			for (k = i; k > 0 && arr[k-1].CompareTo(elem) > 0; k--)
				arr[k] = arr[k-1];  // move elements one slot backward if they are smaller than elem
			arr[k] = elem ; //insert elem into the now free slot
		}
	}
	
	public static void ShellSort(List<T> arr) {
		int h = 1;
		while (h < arr.Count) h = 3*h + 1; //find max. distance
		do {	
			h = h / 3; // distances ... 364, 121, 40, 13, 4, 1.
			Console.WriteLine("h: " + h);
			for (int i = h; i < arr.Count; i++) {
				T elem = arr[i]; //current element
				int k; //look at all elements before index i (distance h)
				for (k = i; (k-h) >= 0 && arr[k-h].CompareTo(elem) > 0; k = k-h)
					arr[k] = arr[k-h];  // move elements h slots backward
				arr[k] = elem ; //insert elem into the now free slot
			}
		} while (h > 1);
	}

	public static void HibbardShellSort(List<T> arr) {
		//Use 2^exponent for sorting, not exponent itself
		// at the beginning calculate first power of 2 bigger than lenght, then -1 and cont. halve it (15 -> 7 -> 3 -> etc.)
		int h = 1;
		int exp = 1;
		while (Math.Pow(2,h) - 1 < arr.Count) h++; //find max. distance
		do {	
			exp--;
			h = Math.Pow(2, exp);
			Console.WriteLine("h: " + h + ", Distance: " + (Math.Pow(2, h) - 1));
			for (int i = (int)Math.Pow(2, h) - 1; i < arr.Count; i++) {
				T elem = arr[i]; //current element
				int k; //look at all elements before index i (distance h)
				for (k = i; (k-h) >= 0 && arr[k-h].CompareTo(elem) > 0; k = k-h)
					arr[k] = arr[k-h];  // move elements h slots backward
				arr[k] = elem ; //insert elem into the now free slot
			}
		} while (h > 1);
	}
	
	public static void BubbleSortNaive(List<T> arr) {
		for (int n = arr.Count; n > 1; n--) {
			for (int i = 0; i < n-1; i++) {
				if (arr[i].CompareTo(arr[i+1]) > 0) {
					Swap(i, i+1, arr);
				}
			}
		}
	}
	
	public static void BubbleSort(List<T> arr) {
		bool swapped;  // stores, whether a swap was necessary
		int n = arr.Count;
		do {
			swapped = false;
			for (int i = 0; i < n-1; i++)
				if (arr[i].CompareTo(arr[i+1]) > 0) {
					Swap(i, i+1, arr); // swap if next if necessary
					swapped = true; // remember, that some swap was necessary!
				}
			n--;
		} while (swapped); // stops if no swap was necessary at all ==> array is sorted!
	}
	
	public static void MergeSort(List<T> arr, int left, int right) {
		if (left < right) {
			int mid = (left + right)/2;
			MergeSort(arr, left, mid);  //sort left half
			MergeSort(arr, mid+1, right); // sort right half
			Merge(arr, left, mid+1, right); // merge both halves
		}
	}
	
	private static void Merge(List<T> arr, int leftFirstHalf, int leftSecondHalf, int rightSecondHalf) {
		int i = leftFirstHalf;  // index in left half
		int j = leftSecondHalf;  // index in right half
		List<T> sorted = new List<T>(rightSecondHalf+1 - leftFirstHalf); //create helping array of correct size, which gets sorted
		// Always take the smaller element from both halves
		while (i < leftSecondHalf || j <= rightSecondHalf) { 
			// if right half is already finished, or if arr[i] < arr[j] ==> put left element into sorted
			if( j > rightSecondHalf || ( (i < leftSecondHalf) && 
				(arr[i].CompareTo(arr[j]) < 0) )  ) {
				sorted.Add(arr[i]);
				i++;
			}
			else {
				sorted.Add(arr[j]);
				j++;
			}
		}
		for (int k = leftFirstHalf; k <= rightSecondHalf; k++)
			arr[k] = sorted[k-leftFirstHalf]; //copy sorted back to arr at correct position
		//Print(arr);
	}
	
	public static void QuickSort(List<T> arr, int leftIdx, int rightIdx) {
		if (leftIdx >= rightIdx) return;
		//Partition array such that the element at pivotIdx has its correct position,
		// and all elements from leftIdx to pivotIdx-1 are smaller than the pivot element,
		// all elements from pivotIdx+1 to rightIdx are greater than the pivot element.
		int pivotIdx = Partition1(arr, leftIdx, rightIdx);
		//Print(arr);
		QuickSort(arr, leftIdx, pivotIdx-1); // sort left "half"
		QuickSort(arr, pivotIdx+1, rightIdx); // sort right "half"
	}

	//Knuth-Shuffle
	public static void Shuffle(List<T> arr) {
		Random rand = new Random();
	    int n = arr.Count;  
	    while (n > 1) {  
	        n--;  
	        int k = rand.Next(n + 1);  
	        T value = arr[k];  
	        arr[k] = arr[n];  
	        arr[n] = value;  
	    }  
	}
	
	// selects the first element in range from leftIdx to rightIdx as the pivot,
	// moves pivot to its final position i,
	// copies all elements < pivot to a index before storeIdx,
	// copies all elements > pivot to a index after storeIdx.
		private static int Partition1(List<T> arr, int leftIdx, int rightIdx) {
		int pivotIdx = leftIdx; // select the first element in range as the pivot
		T pivot = arr[pivotIdx]; 
		Swap(pivotIdx, rightIdx, arr); //move pivot back
		//indices lower than storeIdx contain elements < pivot:
		int storeIdx = leftIdx; 
		for (int i = leftIdx; i < rightIdx; i++) {
			if (arr[i].CompareTo(pivot) < 0) {  //arr[i] < pivot
				Swap(i, storeIdx, arr);
				storeIdx++;
			}
		}
		Swap(storeIdx, rightIdx, arr); //move pivot to final destination
		//Console.WriteLine("moved " + pivot + " to position " + storeIdx + ":");
		return storeIdx;
	}
	
	
	// selects the first element in range from leftIdx to rightIdx as the pivot,
	// moves pivot to its final position i,
	// copies all elements < pivot to an index before i,
	// copies all elements > pivot to an index after i.
	private static int Partition2(List<T> arr, int leftIdx, int rightIdx) {
		T pivot = arr[leftIdx]; // select the first element in range as the pivot
		int i = leftIdx;
		int	j = rightIdx;
 		while (i < j) {
			// Resolve dead lock if pivot occurs twice
			if (arr[i].Equals(pivot) && arr[j].Equals(pivot))
				i++;
			
			// Move i to the right until it reaches j or it is >= pivot
			while ( (i < j) && (arr[i].CompareTo(pivot) < 0) )
				i++;
				
			// Move j to the left until it reaches i or it is <= pivot
			while ( (j > i) && (arr[j].CompareTo(pivot) > 0) )
				j--;

			//swap the two elements, that are on the "wrong" side each:
			Swap (i, j, arr);
		}
		//Console.WriteLine("moved " + pivot + " to position " + i + ":");
		return i;
	}
	
	public static void HeapSort(List<T> arr) {
		int n = arr.Count;
		//Make an already unsorted filled array a max-heap:
		for(int i = 1; i < n; i++) Upheap(i, arr);
		//Get the current max and push it back:
		for(int i = 0; i < n-1; i++) {
			Swap(0, n-1 - i, arr); //swap max elem back
			Downheap(0, n-1 - i, arr); //restore heap
		}
	}
	
	//returns the index of the parent node
	private static int ParentIdx(int idx) {
		return (idx-1)/2;  
	}
	
	//returns the index of the left child 
	private static int LeftChildIdx(int idx) {
		return (2*idx + 1);
	}

	//returns the index of the right child
	private static int RightChildIdx(int idx) {
		return (2*idx + 2);
	}
	
	private static void Upheap(int idx, List<T> arr) {
		//swap if the parent is smaller
		while (idx > 0 && 
			(arr[ParentIdx(idx)].CompareTo(arr[idx]) == -1)) {
			Swap(ParentIdx(idx), idx, arr);
			idx = ParentIdx(idx);
		}
	}
	
	private static void Downheap(int idx, int howFar, List<T> arr) {
		while (true) { //while not at the back
			//find larger child
			int childIdx = LeftChildIdx(idx);
			if (childIdx >= howFar) break; //break if at the end
			if (RightChildIdx(idx) < howFar &&
				arr[RightChildIdx(idx)].CompareTo(
						arr[LeftChildIdx(idx)]) == 1)
				childIdx = RightChildIdx(idx);
			// if the child is greater, do the swap, otherwise break
			if (arr[childIdx].CompareTo(arr[idx]) == 1) {
				Swap(childIdx, idx, arr);
				idx = childIdx;
			} else break;
		}
	}
}
