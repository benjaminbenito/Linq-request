using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_request
{
    class Program
    {
        static void Main(string[] args)
        {
            Data.Singleton.InitialiserDatas();

            //Afficher la liste des prenoms des auteurs dont le nom commence par "G"
            var prenomsG = Data.Singleton.ListeAuteurs.Where(a => a.Nom.ToUpper().StartsWith("G")).Select(a => a.Prenom);
            Console.WriteLine("Afficher la liste des prenoms des auteurs dont le nom commence par \"G\""+Environment.NewLine);
            foreach (var prenom in prenomsG)
            {
                Console.WriteLine(prenom);
            }
            
            //Afficher l’auteur ayant écrit le plus de livres.
            var AuteurP = Data.Singleton.ListeLivres.GroupBy(livre => livre.Auteur).OrderByDescending(g => g.Count()).FirstOrDefault().Key;
            Console.WriteLine(Environment.NewLine+$"L’auteur ayant écrit le plus de livre est : {AuteurP.Prenom} {AuteurP.Nom}"+Environment.NewLine);

            //Afficher le nombre moyen de pages par livre par auteur.
            var AuteurAvgPage = Data.Singleton.ListeLivres.GroupBy(livre => livre.Auteur);
            Console.WriteLine("Quel est le nombre moyen de pages par livre par auteur"+Environment.NewLine);
            foreach (var LivreAuteur in AuteurAvgPage)
            {
                Console.WriteLine($"L’auteur {LivreAuteur.Key.Prenom} {LivreAuteur.Key.Nom} à en moyennes {LivreAuteur.Average(livre => livre.NbPages)} pages par livre.");
            }

            //Afficher le titre du livre avec le plus de pages
            var LivreMax = Data.Singleton.ListeLivres.OrderByDescending(livre => livre.NbPages).FirstOrDefault();
            Console.WriteLine(Environment.NewLine + "Quel est le titre du livre avec le plus de pages"+ Environment.NewLine);
            Console.WriteLine($"Le livre ayant le plus de page est : {LivreMax.Titre}");


            //Afficher combien ont gagné les auteurs en moyenne (moyenne des factures)
            var AuteurAvgSale = Data.Singleton.ListeAuteurs.Average(a => a.Factures.Sum(f => f.Montant));
            Console.WriteLine(Environment.NewLine+$"Les auteurs ont gagne en moyenne {AuteurAvgSale}" + Environment.NewLine);


            //Afficher les auteurs et la liste de leurs livres.
            var AuteurGpLivre = Data.Singleton.ListeLivres.GroupBy(livre => livre.Auteur);
            foreach (var livres in AuteurGpLivre)
            {
                Console.WriteLine($"Liste des livres de l'auteur {livres.Key.Prenom} {livres.Key.Nom} :");
                foreach (var livre in livres)
                {
                    Console.WriteLine($"-->  {livre.Titre}");
                }
                Console.WriteLine(Environment.NewLine);
            }

            //Afficher les titres de tous les livres triés par ordre alphabétique
            var LivreOrds = Data.Singleton.ListeLivres.Select(livre => livre.Titre).OrderBy(titre => titre);
            Console.WriteLine("Titres de chaque les livres triés par ordre alphabétique:");
            foreach (var LivreOrd in LivreOrds)
            {
                Console.WriteLine($"-->  {LivreOrd}");
            }

            //Afficher la liste des livres dont le nombre de pages est supérieur à la moyenne.
            var AvgPage = Data.Singleton.ListeLivres.Average(livre => livre.NbPages);
            var LivreAvgPageSup = Data.Singleton.ListeLivres.Where(livre => livre.NbPages > AvgPage);
            Console.WriteLine(Environment.NewLine + "Afficher la liste des livres dont le nombre de pages est supérieur à la moyenne.");
            foreach (var LivreAvg in LivreAvgPageSup)
            {
                Console.WriteLine($"--> {LivreAvg.Titre}");
            }

            Console.ReadLine();
        }
    }
}
