using System;
using System.Diagnostics;

class BinarySearchTree_Main {

	public static void Main() {
		BinarySearchTree t = new BinarySearchTree();
		Debug.Assert(t.IsEmpty());
		t.AddRecursive(5020, t.Root);
		Debug.Assert(!t.IsEmpty());
		t.Add(1010);
		TreeNode n = t.Find(5020);
		Debug.Assert(n.Data == 5020);
		Debug.Assert(t.Contains(5020));
		
		n = t.Find(1000);
		Debug.Assert(n == null);
		Debug.Assert(!t.Contains(1000));
		t.Add(5400);
		t.Add(5412);
		t.AddRecursive(5600, t.Root);
		t.Add(5440);
		t.AddRecursive(4020, t.Root);
		n = t.FindRecursive(5440, t.Root);
		Debug.Assert(n.Data == 5440);
		
		n = t.FindRecursive(5500,t.Root);
		Debug.Assert(n == null);
		
		Console.WriteLine();
		Console.WriteLine("Graphical output of the tree structure (nonrecursive): ");
		t.DrawTree();
		
		Console.WriteLine("Simple recursive preorder: ");
		t.PrintTreePreorder(t.Root);
		Console.WriteLine();
		
		Console.WriteLine("Nonrecursive preorder: ");
		t.PrintTreePreorder();
		Console.WriteLine();
		
		Console.WriteLine("Levelorder: ");
		t.PrintTreeLevelorder();
		Console.WriteLine();
		
		Console.WriteLine("Recursive graphical output of the tree structure: ");
		t.DrawTreePreorder(t.Root, 0);
		Console.WriteLine();
		Console.WriteLine();
		
		
		Console.WriteLine("Sorted (inorder) output: ");
		t.PrintTreeInorder(t.Root);
		t.Remove(5440);
		Console.WriteLine("Sorted (inorder) output after removal of 5440: ");
		t.PrintTreeInorder(t.Root);
	}
}