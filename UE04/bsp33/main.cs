using System;
using System.Collections.Generic;
using System.Diagnostics;

class Post2Infix {
	static void Main(string[] args) {
		try { 
			if (args.Length == 0)
				throw new ArgumentException("Usage:\n\tmain.exe [postfix expression]");
			runTests();
			Console.WriteLine(PostFix2Infix(args[0]));
		} catch (InvalidOperationException) {
			Console.WriteLine("You did not enter a valid postfix expression");
		} catch (Exception e) {
			Console.WriteLine(e.Message);
		}
	}

	static string PostFix2Infix(string postfix) {
		Stack<string> expressions = new Stack<string>();
		char[] operators = {'+', '-', '*', '/', '^', '%'};
		foreach (char current in postfix){
			
			if (Char.IsNumber(current))
				expressions.Push("" + current);
				
			else if (Array.IndexOf(operators, current) != -1) {
				string exp = current + " " + expressions.Pop() + ")";
				exp = "(" + expressions.Pop() + " " + exp;
				expressions.Push(exp);
			}
		}

		string finalExp = "";

		while (expressions.Count != 0) {
			finalExp += expressions.Pop();
		}

		expressions.Push(finalExp);

		return expressions.Pop();
	}	

	static void runTests() {
		Debug.Assert(PostFix2Infix("34+") == "(3 + 4)", "1");
		Debug.Assert(PostFix2Infix("12/") == "(1 / 2)", "2");
		Debug.Assert(PostFix2Infix("46+91-/12+") == "(1 + 2)((4 + 6) / (9 - 1))", "3");
		Debug.Assert(PostFix2Infix("43+6*7/34+*") == "((((4 + 3) * 6) / 7) * (3 + 4))", "4");
		Debug.Assert(PostFix2Infix("436+*7/34+*") == "(((4 * (3 + 6)) / 7) * (3 + 4))", "5");
	}
}
