using System;
using System.Collections.Generic;

class MainClass {
	
	static void Main() {
		string[,] matrix = {
			{"0","0","0","x","0","x"},
			{"0","x","0","x","0","x"},
			{"0","*","x","0","x","0"},
			{"0","x","0","0","0","0"},
			{"0","0","0","x","x","0"},
			{"0","0","0","x","0","x"}
		};
		
		BFS labPath = new BFS(matrix);
		labPath.mapLabyrinth(new Node(2,1,0));
		labPath.print();
		Console.WriteLine(labPath.buildPath(new Node(2, 5, 0)));
		
		test(labPath);
		test(labPath);

	}
	
	static void test(BFS labPath) {
		Console.WriteLine("\nGenerating Test Lab");
		Tuple<Node, Node> targets = labPath.genLab();
		labPath.print();
		
		Console.WriteLine("\nSolving");
		labPath.mapLabyrinth(targets.Item1);
		labPath.print();
		labPath.checkTarget(ref targets);
		Console.WriteLine("Target y: " + targets.Item2.y + " x: " + targets.Item2.x);
		Console.WriteLine(labPath.buildPath(targets.Item2));
	}
}

class BFS {
	
	private Queue<Node> path;
	private string[,] lab;
	private Random rand;

	public BFS(string[,] _lab) {
		lab = _lab;
		path = new Queue<Node>();
		rand = new Random();
	}

	//Helper function to check if the next node is traversable, if yes, enqueues it
	private void traverseNeighbour(Node current, Node walk) {
		Node next = current.Add(walk);
		if (next.x == -1 || next.y == -1 || next.x > lab.GetLength(1) - 1 || next.y > lab.GetLength(0) - 1)
			return;
		if (lab[next.y, next.x] == "0") {
			lab[next.y, next.x] = next.cost.ToString();
			path.Enqueue(next);
			return;
		} else if (lab[next.y, next.x] == "x")
			return;
		return;
	}
	
	//Traverses the labyrinth
	public void mapLabyrinth(Node start) {	
		path.Enqueue(start);
		
		while(true) {
			if (path.Count == 0)	
				break;
			
			Node current = path.Dequeue();
			traverseNeighbour(current, new Node(1, 0, 0));
			traverseNeighbour(current, new Node(-1, 0, 0));
			traverseNeighbour(current, new Node(0, + 1, 0));
			traverseNeighbour(current, new Node(0,- 1, 0));	
		}
		
		for (int y = 0; y < lab.GetLength(0); y++) 
			for (int x = 0; x < lab.GetLength(1); x++) 
				if (lab[y, x] == "0")
					lab[y, x] = "u";
					 
		lab[start.y, start.x] = "0";		
	}
	
	public void print() {		
		for (int y = 0; y < lab.GetLength(0); y++) {
			for (int x = 0; x < lab.GetLength(1); x++) {
				Console.Write(lab[y, x] + " ");		
			}
			Console.WriteLine();
		}
	}

	private bool findNext(ref Node current, Node next) {
		if (current.x + next.x == -1 || current.y + next.y == -1 || current.x + next.x > lab.GetLength(1) - 1 || current.y + next.y > lab.GetLength(0) - 1)
			return false;
		if (lab[current.y + next.y, current.x + next.x] == "x" || lab[current.y + next.y, current.x + next.x] == "u")
			return false;
		if (Convert.ToInt32(lab[current.y + next.y, current.x + next.x]) == Convert.ToInt32(lab[current.y, current.x]) - 1) {
			current = current.Add(next);
			return true;
		}
		else 
			return false;
	}

	public string buildPath(Node target) {
		string path = "";

		while (Convert.ToInt32(lab[target.y, target.x]) != 0) {
			if (findNext(ref target, new Node(1, 0, 0))) 
				path += "u";
			else if (findNext(ref target, new Node(-1, 0, 0)))
				path += "d";
			else if (findNext(ref target, new Node(0, 1, 0)))
				path += "l";
			else if (findNext(ref target, new Node(0, -1, 0)))
				path += "r";
			else {
				path += "Target unreachable";
				break;
			}
		}
		return ReverseString(path);
	}

	private string ReverseString(string s) {
		char[] arr = s.ToCharArray();
		Array.Reverse(arr);
		return new string(arr);
    }
	
	public Tuple<Node, Node> genLab() {	
		for (int y = 0; y < lab.GetLength(0); y++) {
			for (int x = 0; x < lab.GetLength(1); x++) {
				if (rand.Next(11) > 2) 
					lab[y, x] = "0";
				else 
					lab[y, x] = "x";
			}
		}

		Node start = new Node(rand.Next(6), rand.Next(6), 0);
		lab[start.y, start.x] = "*";
		
		Node target = new Node(rand.Next(6), rand.Next(6), 0);
		while(lab[target.y, target.x] == "x" || (target.x == start.x && target.y == start.y))
			target = new Node(rand.Next(6), rand.Next(6), 0);
		
		return new Tuple<Node, Node>(start, target);
	}
	
	public void checkTarget(ref Tuple<Node, Node> targets) {
		while (lab[targets.Item2.y, targets.Item2.x] == "u" || lab[targets.Item2.y, targets.Item2.x] == "x" || (targets.Item2.x == targets.Item1.x && targets.Item2.y == targets.Item1.y))
			targets = new Tuple<Node,Node>(targets.Item1, new Node(rand.Next(6), rand.Next(6), 0));
		return;
	}
}

struct Node {
	public int y;
	public int x;
	public int cost;
	
	public Node(int _y, int _x, int _cost) {
		y = _y;
		x = _x;
		cost = _cost;
	}
	
	public Node Add(Node summand) {
		return new Node(this.y + summand.y, this.x + summand.x, this.cost + 1);
	}
}