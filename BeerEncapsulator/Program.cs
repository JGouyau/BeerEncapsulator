using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerEncapsulator
{
    class Program
    {
        static void Main(string[] args)
        {
            BeerEncapsulator maMachine = new BeerEncapsulator();

            int nombreDeBouteille  = maMachine.NombreDeBouteilleAFabrique();
            maMachine.Initialisation(nombreDeBouteille);
            int NombreDeBouteille = maMachine.ProduceEncapsulatedBeerBottles(nombreDeBouteille);
            Console.WriteLine("Nous avons fabriqué " + NombreDeBouteille + " bouteilles !!!");
            Console.ReadKey();

        }
    }


    class BeerEncapsulator
    {
        double _avalaibleBeerVolume;
        int _avalaibleBottles;
        int _avalaibleCapsules;

        public int NombreDeBouteilleAFabrique()
        {
            Console.Write("Combien de bouteille voulez-vous fabriquer aujourdh'hui : ");
            int.TryParse(Console.ReadLine(), out int nombreBootle);
            return nombreBootle;
        }
        public void Initialisation(int a)
        {
            AddBeer(a);
            AddBootle(a);
            AddCapsule(a);
        }

        public int ProduceEncapsulatedBeerBottles(int nombreDeBoutteilleAFabrique)
        {

            int nombreDeBoutteilleFini = 0;
            //Console.WriteLine(_avalaibleBeerVolume+ " +" + _avalaibleBottles + " +" + _avalaibleCapsules);
            if (CanFabricateBeer())
            {
                while (nombreDeBoutteilleFini < nombreDeBoutteilleAFabrique && CanFabricateBeer())
                {
                    ProductOneBootle();
                    nombreDeBoutteilleFini += 1;
                }
            return nombreDeBoutteilleFini;

            }
            else return nombreDeBoutteilleFini;
        }

        private bool CanFabricateBeer()
        {
            
            if (_avalaibleCapsules <= 0)
                return false;
            else if (_avalaibleBottles <= 0)
                return false;
            else if (_avalaibleBeerVolume < 33)
                return false;
            else
                return true;
        }
        public void ProductOneBootle()
        {
            _avalaibleBeerVolume -= 33;
            _avalaibleBottles -= 1;
            _avalaibleCapsules -= 1;
        }

        private void AddCapsule(int nombreDeBoutteilleAFabrique)
        {
            Console.Write("Combien de capsule voulez-vous ajouter : ");
            int.TryParse(Console.ReadLine(), out int nombreDeCapsule);
            if (nombreDeCapsule < nombreDeBoutteilleAFabrique)
            {
                Console.WriteLine("Il faut ajouter " + (nombreDeBoutteilleAFabrique - nombreDeCapsule) + " capsules");
                Console.Write("Voulez-vous les ajouter ? (yes or no) ");
                if (Console.ReadLine() == "yes")
                    _avalaibleCapsules = nombreDeBoutteilleAFabrique;
                else _avalaibleCapsules = nombreDeCapsule;
            }
            else _avalaibleCapsules = nombreDeCapsule;

        }
        private void AddBootle(int nombreDeBoutteilleAFabrique)
        {
            Console.Write("Combien de bouteille voulez-vous ajouter : ");
            int.TryParse(Console.ReadLine(), out int nombreBootle);
            if (nombreBootle < nombreDeBoutteilleAFabrique)
            {
                Console.WriteLine("Il faut ajouter " + (nombreDeBoutteilleAFabrique - nombreBootle) + " bouteilles");
                Console.Write("Voulez-vous les ajouter ? (yes or no) ");
                if (Console.ReadLine() == "yes")
                    _avalaibleBottles = nombreDeBoutteilleAFabrique;
                else _avalaibleBottles = nombreBootle;
            }
            else _avalaibleBottles = nombreBootle;
        }

        private void AddBeer(int nombreDeBoutteilleAFabrique)
        {
            bool quantiteDeBiereVerif = false;
            double quantiteDeBiere = 0;

            while (!quantiteDeBiereVerif || quantiteDeBiere < 0)
            {
                Console.Write("Combien de cl de bière voulez-vous ajouter : ");
                quantiteDeBiereVerif = double.TryParse(Console.ReadLine(), out quantiteDeBiere);
            }
            if (quantiteDeBiere < nombreDeBoutteilleAFabrique*33)
            {
                Console.WriteLine("Il faut ajouter " + (nombreDeBoutteilleAFabrique*33 - quantiteDeBiere) + " cl de bière");
                Console.Write("Voulez-vous les ajouter ? (yes or no) ");
                if (Console.ReadLine() == "yes")
                    _avalaibleBeerVolume = nombreDeBoutteilleAFabrique*33;
                else _avalaibleBeerVolume = quantiteDeBiere;
            }
            else _avalaibleBeerVolume = quantiteDeBiere;

        }


        public int GetCapsule()
        {
            return _avalaibleCapsules;
        }

        public int GetBottle()
        {
            return _avalaibleBottles;
        }

        public double GetBeer()
        {
            return _avalaibleBeerVolume;
        }



    }
}



//Le nombre de capsules dont la machine dispose doit être accessible en modification, ainsi que son nombre de bouteilles. En revanche, la quantité de bière disponible ne peut pas diminuer à l'extérieur de la machine, uniquement augmenter :

//Chaque bouteille est remplie de 33 centilitres de bière, nécessite une capsule et une bouteille. Lorsqu'une bouteille est réalisée, le nombre de composants diminue.

//Dès qu'un composant manque, un message est affiché spécifiant la quantité d'un composant à ajouter nécessaire à la fabrication du nombre de bouteilles.
