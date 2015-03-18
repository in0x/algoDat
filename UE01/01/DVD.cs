using System;

namespace ArticleStore {
	public class DVD : Article {
		public string studio { get; private set; }
		public string protagonist {get ; private set; }
		
		public DVD(int nr, string n, decimal pr, string s, string p) : base(nr, n, pr) {
			studio = s;
			protagonist = p;
		}
		
		public override void print() {
			base.print();
			Console.WriteLine("Studio: " + studio);
			Console.WriteLine("Hauptdarsteller: " + protagonist);
		}
		
		protected override void printMenu() {
			base.printMenu();
			Console.WriteLine("Press \"s\" um das Studio neu einzugeben: ");
			Console.WriteLine("Press \"h\" um den Hauptdarsteller neu einzugeben: ");
		}
		
		protected override void reactToKeyboard(ConsoleKeyInfo cki) {
			base.reactToKeyboard(cki);
			if (cki.KeyChar == 's') {
				Console.WriteLine("\nNeues Studio: ");
				string newstudio = Console.ReadLine();
				//TODO: validate input!
				studio = newstudio;
				Console.WriteLine("Neues Studio wurde gespeichert.");
			}
			if (cki.KeyChar == 'h') {
				Console.WriteLine("\nNeuer Hauptdarsteller: ");
				string newprotagonist = Console.ReadLine();
				//TODO: validate input!
				protagonist = newprotagonist;
				Console.WriteLine("Neuer Hauptdarsteller wurde gespeichert.");
			}
		}
	}
}