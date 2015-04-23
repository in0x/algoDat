using System;

class MainClass {

	// (Position is pair (x, y) or (row, col))
	// next() gives next position on board
	// makeMove() fills a field (has to be backtracked under certain circumstances)
	
	static void solve(Board b, Position p) {
		if (!b.isFree(p) && p.hasNext()) solve(b, p.Next());
		else if (b.isFree(p)) {
			for (byte move = 1; move <= 9; move++) {
				if (!b.isCollisionMove(p, move)) {
					b.makeMove(p, move);
					if (b.isSolved()) b.print();
					if (p.hasNext()) solve(b, p.next()); //try to solve next position
					b.clearPosition(p); //undo move (backtrack)
				}
			}
		}
	}
}

