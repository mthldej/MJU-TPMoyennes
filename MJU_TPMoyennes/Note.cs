using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TPMoyennes
{
    // Classes fournies par HNI Institut
    class Note
    {
        public int matiere { get; private set; }
        public float note { get; private set; }
        public Note(int m, float n)
        {
            matiere = m;
            note = n;
        }
    }
    class Classe
    {
        public string nomClasse;
        public Eleve[] eleves;
        public string[] matieres;
        public int nbEleves;
        public int nbMatieres;
        public Classe(string nomC, int nbMaxEleves, int nbMaxMatieres)
        {
            nomClasse = nomC;
            nbEleves = 0;
            nbMatieres = 0;
            eleves = new Eleve[nbMaxEleves];
            matieres = new string[nbMaxMatieres];
        }
        public void ajouterEleve(string firstName, string lastName)
        {
            if (nbEleves <= 30)
            {
                eleves[nbEleves] = new Eleve(firstName, lastName);
                nbEleves++;
            }
            else
            {
                Console.WriteLine("Le nombre maximum d'élèves dans une classe a été atteint");
            }
        }
        public void ajouterMatiere(string nomMatiere)
        {
            if (nbMatieres < 10)
            {
                matieres[nbMatieres] = nomMatiere;
                nbMatieres++;
            }
            else
            {
                Console.WriteLine("Le nombre maximum de matières enseignées à une classe a été atteint");
            }
            
        }
        public float moyenneMatiere(int matiere)
        {
            float somme = 0;
            int count = 0;

            for (int i = 0; i < nbEleves; i++)
            {
                somme += eleves[i].moyenneMatiere(matiere);
                count++;
            }

            return count > 0 ? somme / count : 0;
        }

        public float moyenneGeneral()
        {
            float somme = 0;
            int count = 0;

            for (int i = 0; i < nbEleves; i++)
            {
                somme += eleves[i].moyenneGeneral();
                count++;
            }

            return count > 0 ? somme / count : 0;
        }
    }
    class Eleve
    {
        public string prenom;
        public string nom;
        public Note[] Notes;
        public int nbNotes;
        public float[] moyennesMatieres;
        public Eleve(string firstName, string lastName)
        {
            prenom = firstName;
            nom = lastName;
            int nbMaxNotes = 200;
            Notes = new Note[nbMaxNotes];
            nbNotes = 0;
            moyennesMatieres = new float[nbNotes];
        }
        public void ajouterNote(int matiere, float note)
        {
            if (nbNotes < Notes.Length)
            {
                Notes[nbNotes] = new Note(matiere, note);
                nbNotes++;
            }
            else
            {
                Console.WriteLine($"Le nombre maximum de notes pour {prenom} {nom} a été atteint");
            }

        }
        public float moyenneMatiere(int matiere)
        {
            float somme = 0;
            int count = 0;
            for (int i = 0; i < nbNotes; i++)
            {
                if (Notes[i].matiere == matiere)
                {
                    somme += Notes[i].note;
                    count++;
                }               
            }
            return count > 0 ? somme / count : 0;
        }
        public float moyenneGeneral()
        {
            float somme = 0;
            for (int i = 0; i < nbNotes; i++)
            {
                somme += Notes[i].note;
            }
            return nbNotes > 0 ? somme / nbNotes : 0;
        }

    }

}
