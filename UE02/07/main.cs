using System;
using System.Console;

class MainClass 
{
	//Jede Ziffer in jeder Spalte und Zeile 1x
	static void Main()
	{
		byte[,] sudoku = new byte[9,9] {
			{3, 8, 5, 9, 4, 2, 1, 6, 7},
			{4, 2, 1, 7, 6, 3, 8, 5, 9},
			{7, 6, 9, 1, 5, 8, 3, 4, 2},
			{8, 7, 6, 5, 2, 1, 9, 3, 4},
			{1, 5, 4, 3, 7, 9, 6, 2, 8},
			{9, 3, 2, 6, 8, 4, 5, 7, 1},
			{5, 4, 7, 8, 1, 6, 2, 9, 3},
			{2, 9, 8, 4, 3, 5, 7, 1, 6},
			{6, 1, 3, 2, 9, 7, 4, 8, 5}
			};

		WriteLine(isSolved(sudoku));
		WriteLine(isCollisionMove(2, 4, 0, sudoku));
	}

	static bool isSolved(byte[,] board)
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
				WriteLine("Wrongs square");
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

	static bool isCollisionMove(byte row, byte col, byte move, byte[,] board)
	{
		byte[] compare_row = new byte[9];
		byte[] compare_col = new byte[9];

		for (int index = 0; index < 9; index++)
		{
			compare_col[index] = board[index, col - 1];
			compare_row[index] = board[row - 1, index];
		}

		compare_row[col - 1] = move;
		compare_col[row - 1] = move;

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
