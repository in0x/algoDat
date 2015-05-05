using System;
using System.Diagnostics;

class Test {

	public static void test() {
		byte[,] b = {
			{0, 0, 9, 0, 5, 0, 0, 0, 4},
			{0, 3, 0, 0, 8, 0, 0, 0, 5},
			{0, 4, 0, 0, 9, 6, 0, 1, 0},
			{0, 7, 1, 0, 0, 3, 0, 4, 8},
			{9, 0, 0, 7, 0, 1, 0, 0, 6},
			{4, 6, 0, 8, 0, 0, 5, 7, 0},
			{0, 5, 0, 4, 7, 0, 0, 6, 0}, //6
			{6, 0, 0, 0, 1, 0, 0, 8, 0},
			{1, 0, 0, 0, 3, 0, 7, 0, 0}
		};

		Board board = new Board(b);
		Position p = new Position(5, 7);
		Debug.Assert(p.hasNext(), "21");
		Debug.Assert(p.Next().X == 6, "22");
		Debug.Assert(board.getAt(p) == 0, "23");
		Debug.Assert(board.isFree(p), "24");
		p = new Position(8, 0);
		Debug.Assert(board.getAt(p) == 4, "26");
		Debug.Assert(!board.isSolved(), "27");
		p = new Position(8, 3);
		Debug.Assert(p.hasNext(), "29");
		Debug.Assert(p.Next().Y == 4, "30");
		//Debug.Assert(board.isSolved(), "31");
		
		p = new Position(0, 0);
		while (p.hasNext()) {
			Console.WriteLine(p.X + " " + p.Y);
			p = p.Next(); 
		}

		
		byte[,] b2 =  {
			{5, 3, 4, 6, 7, 8, 9, 1, 2},
			{0, 3, 0, 0, 9, 0, 0, 0, 5},
			{0, 4, 0, 0, 4, 6, 0, 1, 0},
			{8, 5, 9, 0, 6, 3, 0, 4, 8},
			{4, 2, 6, 7, 5, 1, 0, 0, 6},
			{7, 1, 3, 8, 2, 0, 5, 7, 0},
			{0, 5, 0, 4, 3, 0, 0, 6, 0},
			{6, 0, 0, 0, 1, 0, 0, 8, 0},
			{1, 0, 0, 0, 8, 0, 7, 0, 0}
		};
		
		Board board2 = new Board(b2);
		MainClass.solve(board2, new Position(1,0));
		/*Debug.Assert(board2.isRowSolved(new Position(0, 0)));
		Debug.Assert(!board2.isRowSolved(new Position(0, 1)));
		Debug.Assert(board2.isColSolved(new Position(4, 0)));
		Debug.Assert(!board2.isColSolved(new Position(5, 0)));
		Debug.Assert(board2.isSubSquareSolved(new Position(0, 3)));
		Debug.Assert(!board2.isSubSquareSolved(new Position(3, 3))); */
		Debug.Assert(board2.isSolved(), "58");
		Console.WriteLine(board2.isSolved());
		board2.print();
		
		byte[,] b3 =  {
			{5, 3, 4, 6, 7, 8, 9, 1, 2},
			{6, 7, 2, 1, 9, 5, 3, 4, 8},
			{1, 9, 8, 3, 4, 2, 5, 6, 7},
			{8, 5, 9, 7, 6, 1, 4, 2, 3},
			{4, 2, 6, 8, 5, 3, 7, 9, 1},
			{7, 1, 3, 9, 2, 4, 8, 5, 6},
			{9, 6, 1, 5, 3, 7, 2, 8, 4},
			{2, 8, 7, 4, 1, 9, 6, 3, 5},
			{3, 4, 5, 2, 8, 6, 1, 7, 9}
		};
		
		Board board3 = new Board(b3);
		Debug.Assert(board3.isSolved(), "73"); 
		
	}
}


