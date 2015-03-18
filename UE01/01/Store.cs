using System;
using System.Collections.Generic;

namespace ArticleStore {
	class Store {
		
		//private Article[] articles;
		private List<Article> articles;
		public int artCnt { get; private set; }

		public Store(){
			articles = new List<Article>();
		}

		public Store(int capacity) {
			articles = new List<Article>(capacity);
		}
		
		public void printCapacity() {
			Console.WriteLine("Store capacity: {0}", articles.Capacity);
		}

		public void printAll() {
			foreach (Article a in articles) {
				a.print();
			}
		}
		
		public void addTaxes(float percent) {
			foreach (Article a in articles) {
				a.addTax(percent);
			}
		}
		
		public decimal computeTotalPrice() {
			decimal price = 0m;
			foreach (Article a in articles) {
				price += a.preis;
			}
			return price;
		}

		public bool addArticle(Article a) {
			if (artCnt <= articles.Capacity) {
				articles.Add(a);
				artCnt++;
				return true;
			}
			else {
				return false;
			}
		}
		
		public Article findArticle(int artNr) {
			foreach (Article a in articles) {
				if (a.artNr == artNr) return a;
			}
			return null;
		}
		
		public int countBooks() {
			int cnt = 0;
			foreach (Article a in articles) {
				if (a.GetType() == typeof(Book)) cnt++;
			}
			return cnt;
		}
		
		public int countDVDs() {
			int cnt = 0;
			foreach (Article a in articles) {
				if (a.GetType() == typeof(DVD)) cnt++;
			}
			return cnt;
		}
		
		public int countPCs() {
			int cnt = 0;
			foreach (Article a in articles) {
				if (a.GetType() == typeof(PC)) cnt++;
			}
			return cnt;
		}
		
		public void printStatistics() {
			int n = articles.Capacity;
			int books = countBooks();
			int DVDs = countDVDs();
			int PCs = countPCs();
			float b = ((float) countBooks())/n;
			float d = ((float) countDVDs())/n;
			float p = ((float) countPCs())/n;
			
			Console.WriteLine("{0:0.00}% Bücher, {1:0.00}% DVDs, {2:0.00}% DVDs, {3:0.00}% restl.Artikel.", b*100, d*100, p*100, (1-b-d-p)*100);
		}
	}
}