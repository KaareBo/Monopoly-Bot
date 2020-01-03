using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyBot
{
    class Program
    {
        static void Main(string[] args)
        {
            //Define variables and starting position
            Random rand = new Random();
            int Posisjon = 40;
            bool Fengsel = false;
            int Terningkast;
            int Terning1;
            int Terning2;

            //Define how many dice throws you want the bot to run for
            int DiceThrows = 99;

            for (int i = 1; DiceThrows >= i; i ++) {
                //Reset Chance- and community-chest cards
                int Sjansekort = 0;
                int PrøvLykken = 0;


                //Throw 2 dice
                Terning1 = rand.Next(1, 7);
                Terning2 = rand.Next(1, 7);
                Terningkast = Terning1 + Terning2;

                //Move if you're not in jail
                if (Fengsel == false)
                {
                    Posisjon = Posisjon + Terningkast;
                }

                //If you roll two identical dice, you get out of jail
                if (Fengsel == true && Terning1 == Terning2)
                {
                    Fengsel = false;
                }

                //Reset position when you pass start
                if (Posisjon > 40)
                {
                    Posisjon = Posisjon - 40;
                }

                //Go to jail spot
                if (Posisjon == 30)
                {
                    Posisjon = 10;
                    Fengsel = true;
                }

                //Draw chance card
                if (Posisjon == 7 || Posisjon == 22 || Posisjon == 36)
                {
                    Sjansekort = rand.Next(1, 17);
                }
                //Draw community chest
                if (Posisjon == 2 || Posisjon == 17 || Posisjon == 33)
                {
                    PrøvLykken = rand.Next(1, 18);
                }

                //Execute the card. The only cards present are the ones that move you or put you in jail
                if (Sjansekort == 1)
                {
                    Posisjon = 40;
                }
                if (Sjansekort == 2)
                {
                    Posisjon = 24;
                }
                if (Sjansekort == 3)
                {
                    Posisjon = 11;
                }
                if (Sjansekort == 4)
                {
                    if (Posisjon > 28)
                    {
                        Posisjon = 12;
                    }
                    if (Posisjon > 12)
                    {
                        Posisjon = 28;
                    }
                }
                if (Sjansekort == 5)
                {
                    if (Posisjon > 5)
                    {
                        Posisjon = 15;
                    }
                    if (Posisjon > 15)
                    {
                        Posisjon = 25;
                    }
                    if (Posisjon > 25)
                    {
                        Posisjon = 35;
                    }
                    if (Posisjon > 35)
                    {
                        Posisjon = 5;
                    }
                }
                if (Sjansekort == 6)
                {
                    Posisjon = Posisjon - 3;
                }
                if (Sjansekort == 7)
                {
                    Posisjon = 10;
                    Fengsel = true;
                }
                if (Sjansekort == 8)
                {
                    Posisjon = 5;
                }
                if (Sjansekort == 9)
                {
                    Posisjon = 39;
                }
                //Community chest
                if (PrøvLykken == 1)
                {
                    Posisjon = 40;
                }
                if (PrøvLykken == 2)
                {
                    Posisjon = 10;
                    Fengsel = true;
                }

                //Print the bots position and if it's in jail
                //Then manually run code again to prevent the prison bool from resetting to false
                Console.WriteLine(Posisjon);
                Console.WriteLine(Fengsel);
            }
            //Stops the program from ending so it won't close if ran through Visual Studio
            Console.WriteLine("To exit the program, press enter");
            Console.ReadLine();
        }
    }
}
