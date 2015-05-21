using System;
using System.Diagnostics;
using System.Collections.Generic;

class MyHashtableDH<T, S> {

	private List<KeyValuePair<T,S>> table; //the array of key-value pairs
	private List<bool> occupied; //the occupied-array
	private List<bool> wasOccupied; //needed for removal
	private int capacity; // the number of slots of the hashtable

	public MyHashtableDH(int c = 17) { //prime number as default capacity
		capacity = c;
		table = new List< KeyValuePair<T,S> >(capacity);
		occupied = new List<bool>(capacity);
		wasOccupied = new List<bool>(capacity);
		//initialize the two arrays:
		for (int i = 0; i < capacity; i++) {
			occupied.Add(false);
			wasOccupied.Add(false);
			table.Add(null);
		}
	}
	
	//warning: returns -1 if no hash function for type T is available!
	public int Hash(T key, int capacity)  {
		// Divisionsmethode:		
		if (key.GetType() == typeof(int)) {
			int keyInt = Int32.Parse(key.ToString());
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

	// Second hash function used when first hash function yields a collision.
	public int Hash2(T key, int capacity) {
		if (key.GetType() == typeof(int)) {
			int keyInt = Int32.Parse(key.ToString());
			return Math.Abs(1 + (keyInt % (capacity-2)));
		}
		else if (key.GetType() == typeof(string)) {
			string keyString = key.ToString();
			return Math.Abs(1 + ((keyString[0]) % (capacity-2)));
		}
		else if (key.GetType() == typeof(double)) {
			double keyDouble = Double.Parse(key.ToString());
			return Math.Abs(1 + (((int) keyDouble*211)%(capacity-2)));
		}
		return -1;
	}
	
	// Inserts a element with key-value pair. 
	// If key is already stored, the old element gets overwritten.
	public void Insert(T key, S value) {
		int idx = GetFinalIndex(key);
		occupied[idx] = true;  // if already occupied, the old element gets overwritten!
		wasOccupied[idx] = true;
		table[idx] = new KeyValuePair<T, S>(key, value); 
		//TODO: resizing of the hashtable if load factor is too high
		//i.e.: if there are too much true wasOccupied-Slots!
	}
	
	// Returns whether an element with key as key is already stored
	public bool Contains(T key) {
		int idx = GetFinalIndex(key); //get the index
		if (occupied[idx]) // if occupied, the element at this slot must have the same key
			Debug.Assert( table[idx].Key.Equals(key) );
		
		// if occupied, the element at idx has the same key, so return true;
		// if not occupied, we have a free slot, so return false.
		return occupied[idx]; 
	}
	
	// Returns the value at given key. 
	// Throws an exception if the key is not stored.
	public S Get(T key) {
		int idx = GetFinalIndex(key);
		
		if ((!occupied[idx]) || (!table[idx].Key.Equals(key))) 
			throw new Exception("Key not stored!");

		return table[idx].Value;
	}
	
	// Removes the element with given key. If not contained ==> Exception.
	public void Remove(T key) {
		int idx = GetFinalIndex(key);

		if (!occupied[idx]) throw new Exception("Key not stored!");
		Debug.Assert(table[idx].Key.Equals(key)); 

		occupied[idx] = false;
	}
	
	public void Print() {
		Console.Write("[");
		for (int i = 0; i < capacity-1; i++) {
			if (occupied[i]) 
				Console.Write("(" +  table[i].Key  + "," + table[i].Value + "),");
			else if (wasOccupied[i]) 
				Console.Write(" * ,");
			else Console.Write("  ,");
		}
		if (occupied[capacity-1]) 
			Console.Write("(" +  table[capacity-1].Key  + "," + table[capacity-1].Value + ") ");
		else if (wasOccupied[capacity-1]) 
			Console.Write("* ");
		else Console.Write(" ");
		
		Console.WriteLine("]");
	}
	
	// Get the table index where given key resides.
    // If key does not exist, return the 
	// first non-occupied slot where key
    // could be placed to. 
	private int GetFinalIndex(T key) {
		int startidx = Hash(key, capacity);
		int incr = Hash2(key, capacity);
	    
		// Run through table until we find the key we searched for or until
		// we find a slot that was never occupied.
		int freeidx = -1; //stores the first index that was occupied, but is not occupied now.
		bool foundFree = false; //if we found a freeidx
		int idx = startidx; //loop index
		while (wasOccupied[idx]) {
			//Console.WriteLine("Collision! idx: " + idx + ", Hash1: " + startidx + ", Hash2: " + incr);
			Debug.Assert((0 <= idx) && (idx < capacity));
			
			//return idx immediately if key already exists
			if (occupied[idx] && table[idx].Key.Equals(key))
				return idx;
			
			//remember first free slot that was occupied:
			if (!foundFree && !occupied[idx]){
				freeidx = idx;
				foundFree = true;
				//We do NOT return here, 
				//because key could still exist further behind,
				//if it was inserted when collisions occured.
			}
			
			idx = (idx + incr)%capacity;
			
			if (idx == startidx) {  //every slot has true wasoccupied
				if (!foundFree) throw new Exception("Double hashing did not yield a result." + 
					" We are going in a loop. Hash2: " + 
					incr + " , idx: " + idx);
				else return freeidx; //at least one slot had occupied == false.
			}
		}
		
		//return the first slot that was occupied but is free now (if exists):
		if (foundFree) 
			return freeidx;
		//else return an index that was not occupied (and is free now):
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