using System;

namespace ArticleStore {

	public class Article {
		public int artNr { get; private set; }
		public string name { get; private set; }
		public decimal preis { get; private set; }
		
		public Article(int nr, string n, decimal p) {
			artNr = nr;
			name = n;
			preis = p;
		}
		
		public virtual void print() {
			Console.WriteLine("=====================================");
			Console.WriteLine("Art.Nr: " + artNr);
			Console.WriteLine("Name: " + name);
			Console.WriteLine("Preis: {0:0.00} .-", preis);
		}

		public void addTax(float p) {
			preis = preis*((decimal) (1 + p/100));
		}
		
		protected virtual void printMenu() {
			Console.WriteLine("=========EDIT-MENÜ für Artikel \"" + name + "\"=========");
			Console.WriteLine("Press \"n\" um den Namen neu einzugeben:");
			Console.WriteLine("Press \"p\" um den Preis neu einzugeben:");
		}
		
		protected virtual void reactToKeyboard(ConsoleKeyInfo cki) {
			if (cki.KeyChar == 'n') {
				Console.WriteLine("\nNeuer Name: ");
				string newname = Console.ReadLine();
				//TODO: validate input!
				name = newname;
				Console.WriteLine("Neuer Name wurde gespeichert.");
			}
			if (cki.KeyChar == 'p') {
				Console.WriteLine("\nNeuer Preis: ");
				decimal newprice = decimal.Parse(Console.ReadLine());
				//TODO: validate input!
				preis = newprice;
				Console.WriteLine("Neuer Preis wurde gespeichert.");
			}
		}
		
		public void edit() {
			printMenu();
			ConsoleKeyInfo cki = Console.ReadKey();
			reactToKeyboard(cki);
			Console.WriteLine("Informationen zum Artikel: ");
			print();
		}
	}
}