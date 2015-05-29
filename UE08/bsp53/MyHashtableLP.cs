/* 141061024, fhs37246
   * Philipp Welsch
   * ue08 bsp53    */

using System;
using System.Diagnostics;
using System.Collections.Generic;

class MyHashtableLP<T, S> {

	private List<KeyValuePair<T,S>> table;   //the array of key-value pairs
	private List<bool> occupied; // the occupied-array
	private int capacity; // the number of slots of the hashtable
	private uint count;
	public int Capacity {get {return this.capacity;} private set {this.capacity = value;}}
	public uint Count {get {return this.count;} private set {this.count = value;}}

	public MyHashtableLP(int c = 17) { //prime number as default capacity
		capacity = c;
		table = new List<KeyValuePair<T,S>>(capacity);
		occupied = new List<bool>(capacity);
		//initialize the two arrays:
		for (int i = 0; i < capacity; i++) {
			occupied.Add(false);
			table.Add(null);
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
	
	private void Rehash() {
		Console.WriteLine("\nRehashing, load factor: {0}\n", (double)count/(double)capacity);
		List<KeyValuePair<T, S>> temp = table;
		List<bool> temp_oc = occupied;

		capacity *= 2;
		count = 0;
		table = new List<KeyValuePair<T, S>>(capacity);
		occupied = new List<bool>(capacity);
		
		for (int i = 0; i < capacity; i++) {
			table.Add(null);
			occupied.Add(false);
		}
		for (int i = 0; i < temp.Capacity; i++) {
			if (temp_oc[i]) {
				Insert(temp[i].Key, temp[i].Value);
			}
		}
	}

	// inserts a element with key-value pair. 
	// If key is already stored, the old element gets overwritten.
	public void Insert(T key, S value) {
		int idx = GetFinalIndex(key);
		if (!occupied[idx]) {
			count++;
		}
		occupied[idx] = true;  // if already occupied, the old element gets overwritten!
		table[idx] = new KeyValuePair<T, S>(key, value); 
		

		//Rebuild hashtable if load factor is bigger than 75% (0.6-0.8)
		if (((double)count / (double) capacity) >= 0.75)
			Rehash(); 
	}
	
	// returns whether an element with key as key is already stored
	public bool Contains(T key) {
		int idx = GetFinalIndex(key); //get the index
		if (occupied[idx]) // if occupied, the element at this slot must have the same key
			Debug.Assert( table[idx].Key.Equals(key) );
		
		// if occupied, the element at idx has the same key, so return true;
		// if not occupied, we have a free slot, so return false.
		return occupied[idx]; 
	}
	
	// returns the value at given key. 
	// throws an exception if the key is not stored.
	public S Get(T key) {
		int idx = GetFinalIndex(key);
		
		if ((!occupied[idx]) || (!table[idx].Key.Equals(key))) throw new Exception("Key not stored!");

		return table[idx].Value;
	}
	
	
	// Removes the element with given key. If not contained ==> Exception.
	public void Remove(T key) {
		int idx = GetFinalIndex(key);

		if (!occupied[idx]) throw new Exception("Key not stored!");
		Debug.Assert(table[idx].Key.Equals(key)); 

		occupied[idx] = false;
		count--;
		//rehash all of the following elements of the cluster:
		idx = (idx + 1) % capacity;
		while (occupied[idx]) {
			occupied[idx] = false;
			count--;
			Insert(table[idx].Key, table[idx].Value);
			idx = (idx + 1) % capacity;
		}
	}
	
	public void Print() {
		Console.Write("[");
		for (int i = 0; i < capacity-1; i++) {
			if (occupied[i]) 
				Console.Write("(" +  table[i].Key  + "," + table[i].Value + "),");
			else Console.Write("  ,");
		}
		if (occupied[capacity-1]) 
			Console.Write("(" +  table[capacity-1].Key  + "," + table[capacity-1].Value + ") ");
		else Console.Write(" ");
		
		Console.WriteLine("]");
	}
	
	// returns the final index where the key gets hashed 
	// using linear probing (if full ==> exception)
	// the index is either the index of the first free slot
	// or the index of an element with the same key!
	private int GetFinalIndex(T key) {
		int startidx = Hash(key, capacity);
		int idx = startidx;
		Debug.Assert(0 <= idx && idx < capacity);
		
		//linear probing:
		while(occupied[idx] && (!table[idx].Key.Equals(key)) ) {
			idx = (idx+1)%capacity;
			if (idx == startidx) 
				throw new Exception("linear probing did not yield a result. Hashtable is full.");
		}
		
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