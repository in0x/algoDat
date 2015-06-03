using System;
using System.Collections.Generic;

class SortingAlgos<T> where T : IComparable {
	private static Random rand = new Random();

	public static void QuickSortMed(List<T> arr, int leftIdx, int rightIdx) {
		if (leftIdx >= rightIdx) return;
		//Partition array such that the element at pivotIdx has its correct position,
		// and all elements from leftIdx to pivotIdx-1 are smaller than the pivot element,
		// all elements from pivotIdx+1 to rightIdx are greater than the pivot element.
		int pivotIdx = PartitionMedian(arr, leftIdx, rightIdx);
		//Print(arr);
		QuickSortMed(arr, leftIdx, pivotIdx-1); // sort left "half"
		QuickSortMed(arr, pivotIdx+1, rightIdx); // sort right "half"
	}

	public static void QuickSortRand(List<T> arr, int leftIdx, int rightIdx) {
		if (leftIdx >= rightIdx) return;
		//Partition array such that the element at pivotIdx has its correct position,
		// and all elements from leftIdx to pivotIdx-1 are smaller than the pivot element,
		// all elements from pivotIdx+1 to rightIdx are greater than the pivot element.
		int pivotIdx = PartitionRandom(arr, leftIdx, rightIdx);
		//Print(arr);
		QuickSortRand(arr, leftIdx, pivotIdx-1); // sort left "half"
		QuickSortRand(arr, pivotIdx+1, rightIdx); // sort right "half"
	}

	private static int PartitionRandom(List<T> arr, int leftIdx, int rightIdx) {
		T pivot = arr[rand.Next(leftIdx, rightIdx)]; // select a random element in range as the pivot
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

	private static int PartitionMedian(List<T> arr, int leftIdx, int rightIdx) {
		T pivot = GetMedian(arr[leftIdx], arr[(leftIdx+rightIdx)/2], arr[rightIdx]);
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

	public static T GetMedian(T a, T b, T c) {
		T[] values = {a, b, c};
		Array.Sort(values);
		return values[1];
	}

	private static void Swap(int i, int j, List<T> arr) {
		T cpy = arr[j];
		arr[j] = arr[i];
		arr[i] = cpy;
	}

	public static void Print(List<T> arr) {
		Console.Write("[ ");
		foreach (T elem in arr)
			Console.Write(elem + " ");
		Console.WriteLine("]");
	}
}