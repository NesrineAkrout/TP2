using System;
using System.Collections.Generic;
using System.Text;

namespace TP3
{
    class Stock
    {

        private List<Article> articles;
        public List<Article> Articles
        {
            get { return articles; }
            set { articles = value; }
        }

        // Constructeur
        public Stock() {
            this.articles = new List<Article>();
        }

        // Afficher la liste des articles
        public void Afficher() {
            if (this.articles.Count == 0) {
                Console.WriteLine("Attention! Aucun résultat trouvé.");
            }
            foreach (Article article in this.articles) {
                Console.WriteLine(article);
            }
        }

        // Chercher un article par référence
        public int ChercherParRef(string reference) {
            for (int i=0;i<this.articles.Count;i++) {
                if (this.articles[i].Reference == reference) {
                    return i;
                }
            }
            return -1;
        }

        // Supprimer un article
        public void Supprimer(string reference) {
            int position = this.ChercherParRef(reference);
            if (position == -1)
            {
                Console.WriteLine("L'article dont la référence est {0} n'existe pas", reference);
            }
            else {
                this.articles.RemoveAt(position);
                Console.WriteLine("Bravo! L'article a bien été supprimé.");
            }
        }

        // Chercher par nom
        public void ChercherParNom(string nom) {
            int nb = 0;
            foreach (Article article in this.articles) {
                if (article.Nom.ToLower() == nom.ToLower()) {
                    Console.WriteLine(article);
                    nb++;
                }
            }
            if (nb == 0) {
                Console.WriteLine("Attention! Aucun article trouvé.");
            }
        }

        // Chercher par marge de prix
        public void ChercherParMargePrix(double prixMin, double prixMax) {
            int nb = 0;
            foreach (Article article in this.articles)
            {
                if (article.Prix >= prixMin && article.Prix <= prixMax)
                {
                    Console.WriteLine(article);
                    nb++;
                }
            }
            if (nb == 0)
            {
                Console.WriteLine("Attention! Aucun article trouvé.");
            }
        }

        // Ajouter un article
        public void Ajouter() {
            string reference, nom;
            double prix;
            int qte;
            bool is_converted;
            // Saisi de la référence
            do
            {
                Console.Write("Référence : ");
                reference = Console.ReadLine();
            }
            while (this.ChercherParRef(reference) != -1);
            // Saisi du nom
            Console.Write("Nom : ");
            nom = Console.ReadLine();
            // Saisi du prix de vente
            do {
                Console.Write("Prix de vente : ");
                is_converted = double.TryParse(Console.ReadLine(), out prix);
            }
            while(!is_converted || prix < 0);
            // quantité en stock
            do
            {
                Console.Write("Quantité en stock : ");
                is_converted = int.TryParse(Console.ReadLine(), out qte);
            }
            while (!is_converted || qte <= 0);
            Article article = new Article(reference, nom, prix, qte);
            this.articles.Add(article);
            Console.WriteLine("Bravo! Ce produit a bien été ajouté.");
        }

        // Modifier un article
        public void Modifier(string reference) {
            int position = this.ChercherParRef(reference), qte;
            bool is_converted;
            double prix;
            if (position == -1)
            {
                Console.WriteLine("L'article dont la référence est {0} n'existe pas", reference);
            }
            else
            {
                // Saisi du nom
                Console.Write("Nouveau nom [{0}] : ", this.articles[position].Nom);
                this.articles[position].Nom = Console.ReadLine();
                // Saisi du prix de vente
                do
                {
                    Console.Write("Nouveau prix de vente [{0}] : ", this.articles[position].Prix);
                    is_converted = double.TryParse(Console.ReadLine(), out prix);
                    this.articles[position].Prix = prix;
                }
                while (!is_converted || prix < 0);
                // quantité en stock
                do
                {
                    Console.Write("Nouvelle Quantité en stock [{0}] : ", this.articles[position].Qte);
                    is_converted = int.TryParse(Console.ReadLine(), out qte);
                    this.articles[position].Qte = qte;
                }
                while (!is_converted || qte <= 0);
                Console.WriteLine("Bravo! L'article a bien été modifié.");
            }
        }
    }
}
