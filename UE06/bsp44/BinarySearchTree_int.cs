using System;
using System.Diagnostics;
using System.Collections.Generic;

class BinarySearchTree{
	public TreeNode Root { get; private set; }
	
	public BinarySearchTree() {
		Root = null;
	}

	public bool IsEmpty() {
		return (Root == null);
	}
	
	//returns if the given data is stored in the tree
	public bool Contains(int data) {
		TreeNode act = Root;
		while (act != null ) {
			if (data == act.Data)
				return true;
			if (data < act.Data) 
				act = act.Left;
			else // key > act.Data
				act = act.Right;
		}
		return false;
	}
	
	//Inserts a node with given data
	public void Add(int data) {
		TreeNode newNode = new TreeNode(data);
		if (IsEmpty()) {
			Root = newNode;
			return;
		}
		TreeNode act = Root; //start with root
		while (true) {
			if (data == act.Data) {  
				return; // do nothing if data is already stored
			}
			// need to go left in the tree
			if (data < act.Data) {  
				if( act.Left == null ) {
					// there is no further left ==> insert newNode
					act.Left = newNode;
					return;
				}
				act = act.Left; // go to the left
			}
			else { // need to go right in the tree <==>  key > act.Data
				if( act.Right == null ) {  
					// there is no further right --> insert newNode
					act.Right = newNode;
					return;
				}
				act = act.Right;  // go to the right
			}
		}
	}
	
	//Recursive version of insertion of a new node with given data.
	//If the data is already stored, it does NOT insert it a second time.
	public void AddRecursive(int data, TreeNode actRoot) {
		if (IsEmpty()) {  // if empty, root has to be set
			TreeNode newNode = new TreeNode(data);
			Root = newNode;
			return;
		}
		
		if (data == actRoot.Data) return; //do noth. if data already stored
		if (data < actRoot.Data) {   
			if (actRoot.Left == null) {  //no left child ==> insert!
				TreeNode newNode = new TreeNode(data);
				actRoot.Left = newNode;
				return;
			} else AddRecursive(data, actRoot.Left);  //go left
		}
		else {  //data > actRoot.Data
			if (actRoot.Right == null) {  //no right child ==> insert!
				TreeNode newNode = new TreeNode(data);
				actRoot.Right = newNode;
				return;
			} else AddRecursive(data, actRoot.Right);  //go right
		}
	}
	
	//Removes the node with given data according to the lecture.
	//Returns false if data is not contained.
	public bool Remove(int data) {
		TreeNode parent = null;
		TreeNode act = Root;
		
		// Search the node to be removed:
		while (act != null) {
			if (act.Data == data)
				break;
				
			parent = act; //not equal

			if (data < act.Data)
				act = act.Left;
			else if (data > act.Data )
				act = act.Right;
		}
		
		// Nothing to remove, tree was empty or data not present
		if (act == null) return false;

		//We will remove act; parent is its parent.
		
		// There is no right child of act (node to be deleted)
		if (act.Right == null) {
			// We remove the root of our tree
			if (parent == null) {
				Debug.Assert(Root == act);
				// Also works if act.Left is null (act is the node to delete)
				Root = act.Left; //might be null
			}
			// Otherwise: we remove left or right subtree of the parent
			else if (parent.Left == act) //Is act a left child...
					parent.Left = act.Left;
			else if (parent.Right == act) //...or a right child?
					parent.Right = act.Left;
			else Debug.Assert(false);
		}		
		else { // There is a right child of act
			Debug.Assert(act.Right != null);
			//leftest is the node with smallest data in the right subtree of act:
			TreeNode leftest = act.Right; 
			//parentOfLeftest is the parent of leftest
			TreeNode parentOfLeftest = act;
			
			// Find the leftest node of the node to be 
			// deleted (act), and the parent node of leftest:
			while (leftest.Left != null) {
				parentOfLeftest = leftest;
				leftest = leftest.Left;
			}
			Debug.Assert(leftest != null);
			Debug.Assert(leftest.Left == null); //otherwise it couldn't be the leftest

			// Move data from below upwards
			act.Data = leftest.Data;

			// Update parentOfLeftest reference to leftest (as leftest moves up)
			// Note:
			//   - also works if leftest.Right === null
			//   - also works if parentOfLeftest == act (node to be deleted)
			if (parentOfLeftest.Left == leftest ) //Is leftest a left child of its parent...
				parentOfLeftest.Left = leftest.Right; //might be null
			if (parentOfLeftest.Right == leftest ) { //...or a right child of its parent.
				//In this case, parentOfLeftest must be act, 
				//because otherwise leftest would have a greater key than parentOfLeftest.
				Debug.Assert(parentOfLeftest == act); 
				parentOfLeftest.Right = leftest.Right;
			}
		}
		return true;
	}
	
	
	//Returns the node with given key. If not existent, it returns null.
	public TreeNode Find(int data) {
		TreeNode act = Root;
		while (act != null) {
			if (data == act.Data)
				return act;
			if (data < act.Data)
				act = act.Left;
			else // data > act.Data
				act = act.Right;
		}
		return act;
	}
	
	//Returns the node with given data from the subtree starting with actRoot.
	//If not existent, it returns null;
	public TreeNode FindRecursive(int data, TreeNode actRoot) {
		if (actRoot == null) return null;
		if (data == actRoot.Data)
			return actRoot;
		else if (data < actRoot.Data)
			return FindRecursive(data, actRoot.Left);
		else // data > actRoot.Data
			return FindRecursive(data, actRoot.Right);
	}
	
	//Recursive inorder (=sorted) treversal of the nodes.
	public void PrintTreeInorder(TreeNode actRoot) {
		if (actRoot == null) return; 
		PrintTreeInorder(actRoot.Left);
		Console.Write(actRoot.Data + " ");
		PrintTreeInorder(actRoot.Right);
	}
	
	//Recursive preorder traversal of the nodes.
	public void PrintTreePreorder(TreeNode actRoot) {
		if (actRoot == null) return; 
		Console.Write(actRoot.Data + " ");
		PrintTreePreorder(actRoot.Left);
		PrintTreePreorder(actRoot.Right);
	}
	
	//Nonrecursive preorder traversal of the nodes using a stack.
	public void PrintTreePreorder() {
		if (Root == null) return;
		//stack of TreeNodes:
		Stack<TreeNode> stack = new Stack<TreeNode>();  
		stack.Push(Root);
		while (!(stack.Count==0)) {
			TreeNode actNode = stack.Pop(); //get the topmost node
			Console.Write(actNode.Data + " ");
			//Push subtrees to the stack in correct order:
			if (actNode.Right != null)  
				stack.Push(actNode.Right);
			if (actNode.Left != null)
				stack.Push(actNode.Left);
		}
	}
	
	//Levelorder traversal of the nodes using a queue.
	public void PrintTreeLevelorder() {
		if (Root == null) return;
		//queue of TreeNodes:
		Queue<TreeNode> queue = new Queue<TreeNode>(); 
		queue.Enqueue(Root);
		while (!(queue.Count==0)) {
			//get the oldest stored node:
			TreeNode actNode = queue.Dequeue(); 
			Console.Write(actNode.Data + " ");
			//enqueue subtrees in correct order:
			if (actNode.Left != null) 
				queue.Enqueue(actNode.Left);
			if (actNode.Right != null)  
				queue.Enqueue(actNode.Right);
		}
		Console.WriteLine();
	}
	
	
	//Graphical preorder-style output with recursion.
	public void DrawTreePreorder(TreeNode actRoot, int actDepth) {
		Console.WriteLine();
		for( int i=0; i < actDepth; i++)
			Console.Write("  |");
		Console.Write("  +---");
		if (actRoot != null) {
			Console.Write(actRoot.Data);
			if (actRoot.Left != null || actRoot.Right != null) {
				DrawTreePreorder(actRoot.Left, actDepth + 1);
				DrawTreePreorder(actRoot.Right, actDepth + 1);
			}
		}
	}
	
	//Nonrecursive preorder traversal of the nodes using a stack.
	public void DrawTree() {  
		// both stacks are modified synchronously
		Stack<TreeNode> nodes = new Stack<TreeNode>();
		Stack<int> depths = new Stack<int>();
		nodes.Push(Root);
		depths.Push(0);
		
		while( !(nodes.Count == 0)) {
			TreeNode act = nodes.Pop();
			int actDepth = depths.Pop();
			// output the branch to this node:
			for( int i = 0; i < actDepth; i++)
				Console.Write("  |");
			Console.Write("  +---");
			// output the node and remember the children:
			if( act != null ) {
				Console.Write(act.Data);
				// do not output two empty children, but both children, if one is empty!
				if( act.Left != null || act.Right != null ) {
					// output left first, therefore push right first
					nodes.Push(act.Right);
					depths.Push(actDepth + 1);
					nodes.Push(act.Left);
					depths.Push(actDepth + 1);
				}
			}
			Console.WriteLine();
		}
		Console.WriteLine();
		Debug.Assert(depths.Count == 0);
	}
}

class TreeNode<T> where T : IComparable<T> {
	public T Data { get; internal set; }
	public TreeNode Left { get; internal set; }
	public TreeNode Right { get; internal set; }
	
	public TreeNode(T data) {
		Data = data;
		Left = null;
		Right = null;
	}

	public int CompareTo
}