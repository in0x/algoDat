using System;

namespace ArticleStore {

	public class Book : Article {
		public string author { get; private set; }
		public string publisher {get ; private set; }
		
		public Book(int nr, string n, decimal pr, string a, string p) : base(nr, n, pr) {
			author = a;
			publisher = p;
		}
		
		public override void print() {
			base.print();
			Console.WriteLine("Autor: " + author);
			Console.WriteLine("Verlag: " + publisher);
		}
		
		protected override void printMenu() {
			base.printMenu();
			Console.WriteLine("Press \"a\" um den Autor neu einzugeben: ");
			Console.WriteLine("Press \"v\" um den Verlag neu einzugeben: ");
		}
		
		protected override void reactToKeyboard(ConsoleKeyInfo cki) {
			base.reactToKeyboard(cki);
			if (cki.KeyChar == 'a') {
				Console.WriteLine("\nNeuer Autor: ");
				string newauthor = Console.ReadLine();
				//TODO: validate input!
				author = newauthor;
				Console.WriteLine("Neuer Autor wurde gespeichert.");
			}
			if (cki.KeyChar == 'v') {
				Console.WriteLine("\nNeuer Verlag: ");
				string newpublisher = Console.ReadLine();
				//TODO: validate input!
				publisher = newpublisher;
				Console.WriteLine("Neuer Verlag wurde gespeichert.");
			}
		}
	}
}