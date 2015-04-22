using System;
using System.Diagnostics;
using conversion;


static class Tests() {
	static void Main() {
		Debug.Assert(PostFix2Infix("34+") == "4 + 3");
		Debug.Assert(PostFix2Infix("12/") == "2 / 1");
	}
}
