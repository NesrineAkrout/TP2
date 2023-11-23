using System;

namespace TP3
{
    class Program
    {
        static void Main(string[] args)
        {

            Stock stock = new Stock();
            string choix, reference;
            double prixMin, prixMax;
            do {
                Console.WriteLine(
                "************** Menu *******************\n" +
                "1. Rechercher un article par référence\n" +
                "2. Ajouter un article\n" +
                "3. Supprimer un article\n" +
                "4. Modifier un article\n" +
                "5. Rechercher par nom\n" +
                "6. Rechercher par marge de prix\n" +
                "7. Afficher tous les articles\n" +
                "8. Quitter\n" +
                "***************************************"
             );
                choix = Console.ReadLine();
                switch (choix)
                {
                    case "1":
                        Console.WriteLine("[Recherche par référence]");
                        Console.Write("Référence de l'article : ");
                        reference = Console.ReadLine();
                        int p = stock.ChercherParRef(reference);
                        if (p == -1)
                        {
                            Console.WriteLine("L'article dont la référence est {0} n'existe pas", reference);
                        }
                        else
                        {
                            Console.WriteLine(stock.Articles[p]);
                        }
                        break;
                    case "2":
                        Console.WriteLine("[Ajouter un article]");
                        stock.Ajouter();
                        break;
                    case "3":
                        Console.WriteLine("[Supprimer un article]");
                        Console.Write("Référence de l'article : ");
                        stock.Supprimer(Console.ReadLine());
                        break;
                    case "4":
                        Console.WriteLine("[Modifier un article]");
                        Console.Write("Référence de l'article : ");
                        stock.Modifier(Console.ReadLine());
                        break;
                    case "5":
                        Console.WriteLine("[Recherche par nom]");
                        Console.Write("Référence de l'article : ");
                        stock.ChercherParNom(Console.ReadLine());
                        break;
                    case "7":
                        Console.WriteLine("[Liste des articles]");
                        stock.Afficher();
                        break;
                    case "6":
                        Console.WriteLine("[Recherche par marge de prix]");
                        do
                        {
                            Console.Write("Prix min : ");
                        }
                        while (!double.TryParse(Console.ReadLine(), out prixMin));
                        do
                        {
                            Console.Write("Prix max : ");
                        }
                        while (!double.TryParse(Console.ReadLine(), out prixMax));
                        stock.ChercherParMargePrix(prixMin, prixMax);
                        break;
                }
            }
            while (choix != "8");
        }

    }
}
