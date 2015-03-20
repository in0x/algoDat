using System;
using Pgm;
using System.Diagnostics;

namespace PgmEdit {
//Oh despair, ye who shall abstract this, for if you gaze into PgmEdit.crop(), PgmEdit.crop() also gazes into you  
	static class MainClass {
		static void Main() {
			try {
				/*byte[,] imgData = PgmCreator.ReadPgmFile("lena.pgm");
				imgData = Edit.binarize(imgData);
				PgmCreator.WritePgmFile("testBin.pgm", imgData, PgmType.P5);*/
				
				byte[,] test = PgmCreator.ReadPgmFile("Test1.pgm");
				test = Edit.binarize(test);
				test = Edit.crop(test);
				PgmCreator.WritePgmFile("cropped1.pgm", test, PgmType.P5);

				test = PgmCreator.ReadPgmFile("Test2.pgm");
				test = Edit.binarize(test);
				test = Edit.crop(test);
				PgmCreator.WritePgmFile("cropped2.pgm", test, PgmType.P5);

				test = PgmCreator.ReadPgmFile("Test3.pgm");
				test = Edit.binarize(test);
				test = Edit.crop(test);
				PgmCreator.WritePgmFile("cropped3.pgm", test, PgmType.P5); 

				test = PgmCreator.ReadPgmFile("Test4.pgm");
				test = Edit.binarize(test);
				test = Edit.crop(test);
				PgmCreator.WritePgmFile("cropped4.pgm", test, PgmType.P5);

			} catch(Exception e) { 
				Console.WriteLine(e.Message);
			} finally {
				Console.WriteLine("Finished execution");
			}
		}
	}

	static class Edit {
		
		//Takes a grey-scale PGM File and returns it as a black and white(binarized) version
		public static byte[,] binarize(byte[,] baseImage) {
			
			byte[,] output = new byte[baseImage.GetLength(0), baseImage.GetLength(1)];
			for (int y = 0; y < baseImage.GetLength(1); y++) 
				for (int x = 0; x < baseImage.GetLength(0); x++) {
					if (baseImage[x, y] >= 128) 
						output [x, y] = 255;
					else
						output [x, y] = 0;
				}
			return output;
		}

		//Takes a binarized PGM File and removes entirely black or white edges
		public static byte[,] crop(byte[,] baseImage) {

			int[] solidEdges = testEdges(baseImage);
			int baseX = baseImage.GetLength(0);
			int baseY = baseImage.GetLength(1);
			//byte[,] output = new byte[baseImage.GetLength(0), baseImage.GetLength(1)];

			int sum = 0;
			foreach(byte b in solidEdges) sum += b;
			foreach(byte b in solidEdges) Console.WriteLine(b);
			Console.WriteLine("-------");
			if (sum == 0) 
				return baseImage;
			if (solidEdges[0] == baseImage.GetLength(1) - 1) {
				return baseImage;	
			}
			
			byte[,] temp = new byte[baseX, baseY - solidEdges[0] - solidEdges[1]];
			if (solidEdges[0] != 0) {
				//top & bottom
				for	(int y = 0; y < temp.GetLength(1); y++) {
					for	(int x = 0; x < temp.GetLength(0); x++) {
						temp[x, y] += baseImage[x, y + solidEdges[0]]; 
					} 
				}
			}

			temp = new byte[temp.GetLength(0) - solidEdges[2] - solidEdges[3], temp.GetLength(1)];
			//left & right
			//no bugs woopdedoo
			for	(int x = 0; x < temp.GetLength(0); x++) {
				for	(int y = 0; y < temp.GetLength(1); y++) {
					temp[x, y] += baseImage[x + solidEdges[2], y + solidEdges[0]]; 
				} 
			}
			return temp;			
		}

		//Edge detection
		public static int[] testEdges(byte[,] baseImage) {

			int[] solidEdges = new int[4];
			int baseX = baseImage.GetLength(0);
			int baseY = baseImage.GetLength(1);

			bool uneven = false;
			//top
			for (int y = 0; y < baseY; y++) {
				if (uneven) break;
				if(y > 0) solidEdges[0] += 1;
				for (int x = 0; x < baseX; x++) {
					if (baseImage[x, y] != 255) uneven = true;
				}
			}

			uneven = false;
			//bottom
			for (int y = baseY - 1; y > 0; y--) {
				if (uneven) break;
				if(y < baseY - 1) solidEdges[1] += 1;	
				for (int x = 0; x < baseX; x++) {
					if (baseImage[x, y] != 255) uneven = true;
				}
			}

			uneven = false;
			//left 
			for (int x = 0; x < baseX; x++) {
				if (uneven) break;
				if (x > 0) solidEdges[2] += 1;
				for (int y = 0; y < baseY; y++) {
					if (baseImage[x, y] != 255) uneven = true;
				}
			}

			uneven = false;
			//right
			for (int x = baseX - 1; x > 0; x--) {
				if (uneven) break;
				if(x < baseX- 1) solidEdges[3] += 1;
				for (int y = 0; y < baseY; y++) {
					if (baseImage[x, y] != 255) uneven = true;
				}
			}
			return solidEdges;
		}
	}
}