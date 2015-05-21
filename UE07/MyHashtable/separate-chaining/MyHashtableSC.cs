using System;
using System.Diagnostics;
using System.Collections.Generic;

class MyHashtableSC<T, S> {

	private List<LinkedList<KeyValuePair<T,S>>> table;   //the array of linked lists of key-value pairs
	private int capacity; // the number of slots of the hashtable

	public MyHashtableSC(int c = 17) { //prime number as default capacity
		capacity = c;
		table = new List<LinkedList<KeyValuePair<T,S>>>(capacity);
		//initialize the two arrays:
		for (int i = 0; i < capacity; i++) {
			table.Add(new LinkedList<KeyValuePair<T,S>>()); //add empty lists of key-value-pairs
		}
	}
	
	//warning: returns -1 if no hash function for type T is available!
	public int Hash(T key, int capacity)  {
		// Divisionsmethode:		
		if (key.GetType() == typeof(int)) {
			Int32 keyInt = Int32.Parse(key.ToString());
			return Math.Abs(keyInt % capacity);
		}
		//hashing of strings:
		else if (key.GetType() == typeof(string)) {
			string keyString = key.ToString();
			int h = 0;
			for (int i = keyString.Length-1; i >= 0; i--)
				h = (256*h + keyString[i]) % capacity;
			return Math.Abs(h);
		} 
		else if (key.GetType() == typeof(double)) {
			double keyDouble = Double.Parse(key.ToString());
			double A = 0.61803398874989484820;
			return Math.Abs((int) (capacity * (keyDouble*A - (int) (keyDouble*A))));
		}
		return -1; 
	}
	
	// inserts an element with key-value pair. 
	// If key is already stored, the old element gets overwritten.
	public void Insert(T key, S value) {
		int idx = GetFinalIndex(key);
		LinkedList<KeyValuePair<T, S>> list = table[idx];
		LinkedListNode<KeyValuePair<T,S>> listNode = GetNode(key);
		if (listNode == null)  // if key is not yet stored
			list.AddLast(new KeyValuePair<T,S>(key, value));
		else  // key found, so overwrite the value
			listNode.Value = new KeyValuePair<T,S>(key, value);
			
	}
	
	//returns the node with the given key (if exists), otherwise returns null
	private LinkedListNode<KeyValuePair<T,S>> GetNode(T key) {
		int idx = GetFinalIndex(key);
		LinkedListNode<KeyValuePair<T,S>> act = table[idx].First;
		while (act != null) {
			if (act.Value.Key.Equals(key)) return act;
			act = act.Next;
		}
		return null;
	}
	
	// returns whether an element with key as key is already stored
	public bool Contains(T key) {
		return (GetNode(key) != null);
	}
	
	// returns the value at given key. 
	// throws an exception if the key is not stored.
	public S Get(T key) {
		LinkedListNode<KeyValuePair<T,S>> listNode = GetNode(key);
		
		if (listNode == null) throw new Exception("Key not stored!");

		return listNode.Value.Value;
	}
	
	
	// removes the element with given key. If not contained ==> Exception.
	public void Remove(T key) {
		int idx = GetFinalIndex(key);
		LinkedList<KeyValuePair<T,S>> list = table[idx];
		
		if (list.Count == 0) throw new Exception("List does not contain the key.");
		
		LinkedListNode<KeyValuePair<T,S>> act = list.First;
		while (act != null) {
			if (act.Value.Key.Equals(key)) {
				list.Remove(act);
				return;
			}
			else {
				act = act.Next;
			}
		}					
	}
	
	public void Print() {
		Console.WriteLine("[ ");
		for (int i = 0; i < capacity; i++) {
			LinkedList<KeyValuePair<T,S>> list = table[i];
			if (list.Count == 0) Console.Write("<empty slot>");
			else {
				LinkedListNode<KeyValuePair<T,S>> act = list.First;
				while (act != null) {
					Console.Write("(" +  act.Value.Key  + "," + act.Value.Value + ") ");
					act = act.Next;
				}
			}
			Console.WriteLine();
		}
		Console.WriteLine("]");
	}
	
	// returns the index of the slot where the key gets hashed
	private int GetFinalIndex(T key) {
		int idx = Hash(key, capacity);
		Debug.Assert(0 <= idx && idx < capacity);
		return idx;
	}
}

class KeyValuePair<T,S> {
	public T Key { get; internal set; }
	public S Value { get; internal set; }
	
	public KeyValuePair(T key, S value) {
		Key = key;
		Value = value;
	}
}