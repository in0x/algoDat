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
	}
}

class BFS {
	
	private  Queue<Node> path;
	private  string[,] lab;
	
	public BFS(string[,] _lab) {
		lab = _lab;
		path = new Queue<Node>();
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
		bool mapped = false;
		
		while(!mapped) {
			if (path.Count == 0)	
				break;
			
			Node current = path.Dequeue();
			traverseNeighbour(current, new Node(1, 0, 0));
			traverseNeighbour(current, new Node(-1, 0, 0));
			traverseNeighbour(current, new Node(0, + 1, 0));
			traverseNeighbour(current, new Node(0,- 1, 0));	
		}
	}
	
	public void print() {
		for (int y = 0; y < lab.GetLength(0); y++) {
			for (int x = 0; x < lab.GetLength(1); x++) {
				Console.Write(lab[y, x] + " ");		
			}
			Console.WriteLine();
		}
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