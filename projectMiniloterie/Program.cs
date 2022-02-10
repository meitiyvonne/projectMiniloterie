using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace projectMiniloterie
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.startPlay();
        }

        private void afficherMenu()
        {
            Console.WriteLine("*******************************************************");
            Console.WriteLine("******** Bienvenue dans le jeu Lotterie Cookie ********");
            Console.WriteLine("*******************************************************");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("*** Veuillez saisir vos 5 nombres en 1 et 200 ***");
        }

        private void startPlay()
        {
            afficherMenu();
            ArrayList  a = totalObtenu();

            Console.WriteLine();
            Console.WriteLine("****************Résultat*****************");
            Console.WriteLine("Vous avez obtenu les {0} numéros suivants:", a.Count);

            for (int i=0; i<a.Count; i++)
            {
                Console.WriteLine(a[i]);
            }


            Console.WriteLine();
            Console.WriteLine("Voulez-vous encore jouer (O/N) ?");
            string repond = Console.ReadLine();

            while (repond != "o" & repond != "O" & repond != "n" & repond != "N")
            {
                Console.WriteLine();
                Console.WriteLine("Voulez-vous encore jouer (O/N) ?");
                repond = Console.ReadLine();
            }

            if (repond == "o" || repond == "O")
            {
                startPlay();
            }
        }

        private int[] machineChoix(int j)
        {
            
            var random = new Random();
         
            int[] systemNumbers = new int[j];
            for(int i=0; i<j; i++)
            {
                int number = random.Next(1, 200);
                systemNumbers[i]=number;
            }
            return systemNumbers;

        }

        private int[] userChoix(int i)
        {
            int[] userNumbers = new int[i];
            string inputNumber = null;

            for (int j=0; j<i; j++)
            {
                Console.WriteLine("Entrer un nombre et appuyer sur enter: ");
                inputNumber = Console.ReadLine();
                while (isNumeral(inputNumber) != true)
                {
                    Console.WriteLine("Veuillez entrer un nombre compris entre 1 et 200 seulement");
                    Console.WriteLine("Entrer un nombre et appuyer sur enter: ");
                    inputNumber = Console.ReadLine();
                }
               
                int a = Convert.ToInt32(inputNumber);
                
                if(a<1 || a > 200)
                {
                    Console.WriteLine("Veuillez entrer un nombre compris entre 1 et 200 seulement");
                    Console.WriteLine("Entrer un nombre et appuyer sur enter: ");
                    inputNumber = Console.ReadLine();
                }
                else
                {
                    userNumbers[j] = a;
                }
            }
            return userNumbers;

        }


        private ArrayList totalObtenu()
        {
            int a = 100;
            int[] mc = machineChoix(a);
            int b = 5;
            int[] uc = userChoix(b);
            ArrayList numObtenu = new ArrayList();
   
            int total = 0;
            for (int i = 0; i < b; i++)
            {
                for (int j = 0; j < a; j++)
                {
                    if (mc[j] == uc[i])
                    {
                        numObtenu.Add(mc[j]);
                        total++;
                        break;

                    }

                }
            }
            return numObtenu;
        }

        private static bool isNumeral(string input)
        {

            foreach (char ch in input)
            {
                if (ch < '0' || ch > '9')
                {
                    return false;
                }
            }
            return true;

        }

    }

}
