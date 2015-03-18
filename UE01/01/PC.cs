using System;

namespace ArticleStore {
	public class PC : Article {
		public int RAM { get; private set; }
		public int HD {get ; private set; }
		
		public PC(int nr, string n, decimal pr, int r, int h) : base(nr, n, pr) {
			RAM = r;
			HD = h;
		}
		
		public override void print() {
			base.print();
			Console.WriteLine("RAM: " + RAM + " GB");
			Console.WriteLine("Festplatte: " + HD + " GB");
		}
		
		protected override void printMenu() {
			base.printMenu();
			Console.WriteLine("Press \"r\" um neuen RAM einzugeben: ");
			Console.WriteLine("Press \"h\" um die Festplatte neu einzugeben: ");
		}
		
		protected override void reactToKeyboard(ConsoleKeyInfo cki) {
			base.reactToKeyboard(cki);
			if (cki.KeyChar == 'r') {
				Console.WriteLine("\nNeues RAM: ");
				int newram = int.Parse(Console.ReadLine());
				//TODO: validate input!
				RAM = newram;
				Console.WriteLine("Neuer RAM wurde gespeichert.");
			}
			if (cki.KeyChar == 'h') {
				Console.WriteLine("\nNeue Festplattengröße: ");
				int newhd = int.Parse(Console.ReadLine());
				//TODO: validate input!
				HD = newhd;
				Console.WriteLine("Neue Festplatte wurde gespeichert.");
			}
		}
	}
}