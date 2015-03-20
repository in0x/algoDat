using System;
using System.Diagnostics;
using RLE;

//For Unix Users: 
//use -d:DEBUG with mcs
//--debug with mono
// and set "export MONO_TRACE_LISTENER=Console.Error"

namespace Tests {
	public static class myTests {
		public static void runTest() {
			Debug.Assert(RLE.encode("AaaaddddDDDEfffxxyZZZZZ") == "Aaaad#4#DDDEfffxxyZ#5#");
			Debug.Assert(RLE.encode("GGGGGGGGGG1111") == "G#10#1#4#");
			Debug.Assert(RLE.decode("G#10#1#4#") == "GGGGGGGGGG1111");
			Debug.Assert(RLE.decode("Aaaad#4#DDDEfffxxyZ#5#") == "AaaaddddDDDEfffxxyZZZZZ");
			Debug.Assert(RLE.encode("001EeEeEr;sp$#3") == "001EeEeEr;sp$#3");
		}
	}
}