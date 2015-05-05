using System;

class Board {

	public byte[,] board;

	public Board(byte[,] b) {
		if (b.GetLength(0) != 9 || b.GetLength(1) != 9)
			throw new ArgumentException("Board is not 9x9");
		board = b;
	}

	public bool isFree(Position p) {
		if (board[p.Y, p.X] == 0)
			return true;
		return false;
	}

	public byte getAt(Position p) {
		return board[p.Y, p.X];
	}

	public void clearPosition(Position p) {
		board[p.Y, p.X] = 0;
	}

	public void makeMove(Position p, byte move) {
		board[p.Y, p.X] = move;
	}

	public void print() {
		for (int row_idx = 0; row_idx < 9; row_idx++) {
			for (int col_idx = 0; col_idx < 9; col_idx++)	
				Console.Write(board[row_idx, col_idx] + " ");
			Console.Write("\n");
		}
	}

	public bool isSolved()
	{	
		byte[] comps = new byte[9];

		for (int y = 0; y < 3; y++)
		{
			for (int x = 0; x < 3; x++)
			{
				comps[0] += board[x, y];
				comps[1] += board[x + 3, y];
				comps[2] += board[x + 6, y];
				comps[3] += board[x, y + 3];
				comps[4] += board[x + 3, y + 3];
				comps[5] += board[x + 6, y + 3];
				comps[6] += board[x, y + 6];
				comps[7] += board[x + 3, y + 6];
				comps[8] += board[x + 6, y + 6];
			}
		}

		foreach (byte b in comps)
			if (b != 45)
			{
				return false;
			}

		for (int y = 0; y < 3; y++)
			for (int x = 0; x < 3; x++)
				for (int compare = 0; compare < 3; compare++)
				{
					if (compare == x)
						continue;
					if (board[x, y] == board[compare, y] 
					|| board[x + 3, y] == board[compare + 3, y] 
					|| board[x + 6, y] == board[compare + 6, y]) 
						return false;

					if (board[y, x] == board[y, compare] 
					|| board[y, x + 3] == board[y, compare + 3] 
					|| board[y, x + 6] == board[y, compare + 6])
						return false;
				}
	
		return true;
	}

	public bool isCollisionMove(Position p, byte move)
	{
		byte[] compare_row = new byte[9];
		byte[] compare_col = new byte[9];

		for (int index = 0; index < 9; index++)
		{
			compare_col[index] = board[index, p.X];
			compare_row[index] = board[p.Y, index];
		}

		compare_row[p.X] = move;
		compare_col[p.Y] = move;

		for (int index = 0; index < 9; index++) 
			for (int compare = 0; compare < 9; compare++)
			{
				if (compare == index)
					continue;
				if (compare_row[index] == compare_row[compare])
					return false;
				if (compare_col[index] == compare_col[compare])
					return false; 
			}
	
		return true;
	}
}

class Position {
	public uint X;
	public uint Y;

	public Position(uint x, uint y) {
		if (x > 8 || y > 8)
			throw new ArgumentException("Invalid Board Position (more than 8)");
		this.X = x;
		this.Y = y;
	}

	public Position() {

	} 

	public bool hasNext() {
		if (this.X == 8 && this.Y == 8)
			return false;
		return true;
	}

	public Position Next() {
		Position next = new Position();
		if (this.X == 8)
			next.X = 0;
		else
			next.X = this.X + 1;
		
		next.Y = this.Y + 1; 
		//Console.WriteLine("X: " + next.X + "\tY: " + next.Y);
		return next; 
	}
}