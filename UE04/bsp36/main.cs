using System;
using System.Diagnostics;

class MainClass {

	static void Main() {

		byte[,] b = {
			{0, 0, 9, 0, 5, 0, 0, 0, 4},
			{0, 3, 0, 0, 8, 0, 0, 0, 5},
			{0, 4, 0, 0, 9, 6, 0, 1, 0},
			{0, 7, 1, 0, 0, 3, 0, 4, 8},
			{9, 0, 0, 7, 0, 1, 0, 0, 6},
			{4, 6, 0, 8, 0, 0, 5, 7, 0},
			{0, 5, 0, 4, 7, 0, 0, 6, 0},
			{6, 0, 0, 0, 1, 0, 0, 8, 0},
			{1, 0, 0, 0, 3, 0, 7, 0, 0}
		};

		//Position P = new Position(3, 4);

		//Board test = new Board(b);

		//test.print();

		Test.test();

		//solve(new Board(b), new Position(0, 0));
	}
	// (Position is pair (x, y) or (row, col))
	// next() gives next position on board
	// makeMove() fills a field (has to be backtracked under certain circumstances)
	// isFree() has to check if a field contains 0
	// hasNext() gets next position, if it is 8 in a dimension set it to 0
	// 


	public static void solve(Board b, Position p) {
		if (!b.isFree(p) && p.hasNext()) solve(b, p.Next());
		else if (b.isFree(p)) {
			for (byte move = 1; move <= 9; move++) {
				if (!b.isCollisionMove(p, move)) {
					b.makeMove(p, move);
					if (b.isSolved()) b.print();
					if (p.hasNext()) solve(b, p.Next()); //try to solve next position
					b.clearPosition(p); //undo move (backtrack)
				}
			}
		}
	} 
}

/*

			{5, 3, 4, 6, 7, 8, 9, 1, 2},
			{0, 3, 0, 0, 9, 0, 0, 0, 5},
			{0, 4, 0, 0, 4, 6, 0, 1, 0},
			{8, 5, 9, 0, 6, 3, 0, 4, 8},
			{4, 2, 6, 7, 5, 1, 0, 0, 6},
			{7, 1, 3, 8, 2, 0, 5, 7, 0},
			{0, 5, 0, 4, 3, 0, 0, 6, 0},
			{6, 0, 0, 0, 1, 0, 0, 8, 0},
			{1, 0, 0, 0, 8, 0, 7, 0, 0}

*/

