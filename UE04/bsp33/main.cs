using System;
using System.Collections.Generic;

namespace conversion {

class Post2Infix {
	static void Main(string[] args) {
		Console.WriteLine(PostFix2Infix(args[0]));
	}

	static string PostFix2Infix(string postfix) {
		Stack<string> expressions = new Stack<string>();
		char[] operators = {'+', '-', '*', '/', '^', '%'};
		foreach (char current in postfix){
			
			if (Char.IsNumber(current))
				expressions.Push("" + current);
				
			else if (Array.IndexOf(operators, current) != -1) {
				string expression = "(" + expressions.Pop() + " " + current + " " + expressions.Pop() + ")";
				expressions.Push(expression);
			}
		}
		return expressions.Pop();
	}	
}
}