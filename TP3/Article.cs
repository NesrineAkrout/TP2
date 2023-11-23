using System;
using System.Collections.Generic;
using System.Text;

namespace TP3
{
    class Article
    {

        private string reference;
        private string nom;
        private double prix;
        private int qte;

        public string Reference { get => reference; set => reference = value; }
        public string Nom { get => nom; set => nom = value; }
        public double Prix { get => prix; set => prix = value; }
        public int Qte { get => qte; set => qte = value; }

        // Constructeur d'initialisation
        public Article(string reference, string nom, double prix, int qte) {
            this.reference = reference;
            this.nom = nom;
            this.prix = prix;
            this.qte = qte;
        }

        public override string ToString()
        {
            return "Référence : "+this.reference+"\nNom : "+this.nom+"\nPrix de vente : "+
                this.prix+" dinars\nQuantité en stock : "+this.qte;
        }
    }
}
