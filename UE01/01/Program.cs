using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using ArticleStore;

class Program {
	public static void Main() {
		//create some Articles:
		
		Article a1 = new Article(1, "ErsterArtikel", 100);
		//Console.WriteLine("Created:");
		//a1.print();
		a1.addTax(20);
		//Console.WriteLine("New tax:");
		//a1.print();
		Book b1 = new Book(2, "Der Schatz im Silbersee", 5.9m, "Karl May", "Western-Verlag");
		//Console.WriteLine("Created:");
		//b1.print();
		DVD d1 = new DVD(3, "Mission Impossible", 15.0m, "Paramount", "Tom Cruise");
		//Console.WriteLine("Created:");
		//d1.print();
		PC p1 = new PC(4, "Acer", 800m, 8, 500);
		//Console.WriteLine("Created:");
		//p1.print();
		
		Console.WriteLine();
		
		/* Old Main: begin
		//create a store and fill it with articles:
		Store store = new Store(4); //allow only four articles (for test purposes)
		Debug.Assert(store.addArticle(a1));  //Expected: "True"
		Debug.Assert(store.addArticle(b1)); //Expected: "True"
		Debug.Assert(store.addArticle(d1)); //Expected: "True"
		Debug.Assert(store.addArticle(p1)); //Expected: "True"
		Debug.Assert(!store.addArticle(new Article(5, "Too much", 100))); 
		//Expected: "False": should not work because of full capacity
		
		Console.WriteLine();
		
		int aNr = 2; //also try aNr = 3;
		Article a = store.findArticle(aNr);
		if (a != null) a.print();
		else Console.WriteLine("Artikel mit Nr. " + aNr + " konnte nicht gefunden werden.");

		//try to edit one article of each type:
		//a1.edit();
		//b1.edit();
		//d1.edit();
		//p1.edit();
		
		//try taxation of all articles:
		Console.WriteLine();
		Console.WriteLine("Gesamtpreis aller gespeicherten Artikel: " + store.computeTotalPrice() + ".-");
		store.addTaxes(20);
		Console.WriteLine("Gesamtpreis aller gespeicherten Artikel nach Steueraufschlag: " + store.computeTotalPrice() + ".-");
		
		Console.WriteLine();
		Console.WriteLine("Anzahl Bücher: " + store.countBooks());
		
		Console.WriteLine();
		Console.WriteLine("Statistik:");
		store.printStatistics();	

		Old Main: end*/

		Store myStore = new Store();
		Console.WriteLine("Initializing store without parameters:");
		myStore.printCapacity();
		Console.WriteLine("\nAdding 1 article to store. Capacity changes:");
		myStore.addArticle(b1);
		myStore.printCapacity();
		Console.WriteLine("Delta: 4");
		Console.WriteLine("\nIntializing store with size = 5:");
		Store largerStore = new Store(5);
		largerStore.printCapacity();
	}
}