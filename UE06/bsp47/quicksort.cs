class QuickSortArray {
	
	private List<GameObject> elements;
	private Random rand;
	private char sortEl;

	public void Add(GameObject data) {
		elements.Add(data);
	}

	public QuickSortArray(char s) {
		if (s != 'x' && s != 'y')
			throw new ArgumentException("Can only sort with x or y");

		elements = new List<GameObject>();
		rand = new Random();
		sortEl = s;
	}

	public void QuickSort() {
		this.Shuffle();
		sort(0, elements.Count);
	}

	private bool smaller(GameObject one, GameObject two) {
		if (sortEl == 'x')
			return one.x.CompareTo(two.x) < 0;
		else
			return one.y.CompareTo(two.y) < 0;
	}

	 private int partition(int left, int right) {  

	     int i = left, 
	     	 j = right;    

	    GameObject temp = elements[left];          
	    while (true) {  
	        while (smaller(elements[i++], temp)) 
	        	if (i == right) break;

	        while (smaller(temp, elements[j--])) 
	        	if (j == left) break;

	        if (i >= j) break;
	        swap(i, j);
	    }
	    swap(left, j);
		return j;
	}

	private void swap(int i, int j) {
        GameObject temp = elements[i];
        elements[i] = elements[j];
        elements[j] = temp;
    }

	private void sort(int left, int right) {
        if (right <= left) return;
        int split = partition(left, right);  
        sort(left, split - 1);              
        sort(split + 1, right);             
	} 

	// Implementation of Knuth-Shuffle	
	public void Shuffle() {
	    int n = elements.Count;  
	    while (n > 1) {  
	        n--;  
	        int k = rand.Next(n + 1);  
	        GameObject value = elements[k];  
	        elements[k] = elements[n];  
	        elements[n] = value;  
	    }  
	}

	public void Print() {
		foreach (GameObject data in elements) 
			Console.WriteLine("x: " + data.x + "\ty: " + data.y);
	}
}