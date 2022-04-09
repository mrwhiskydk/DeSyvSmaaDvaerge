using System;
using System.Collections.Generic;
using System.Linq;

namespace DeSyvSmåDværge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dwarf gnavpot = new Dwarf(
                "Gnavpot",
                "Kan i så tie stille!",
                "Jeg orker ikke lige nu, tag fat i {0} i stedet for",
                "Nu orker jeg ikke mere. Farvel og tak");

            Dwarf lystig = new Dwarf(
                "Lystig",
                "Jeg ønsker at vi kunne lege hele natten i stedet for at sove",
                "Vil du spille fodbold med mig {0}?",
                "Hvis i ikke gider at lege, så finder jeg nogle andre der vil");

            Dwarf prosit = new Dwarf(
                "Prosit",
                "Hey! Vent lige påååååååatjuuuuh mig",
                "Hey PROSIT! Unskyld, {0} har du lige tid?",
                "Jeg bliver nødt til at gå, jeg skal tage min allergimedicin"
                );
            Dwarf søvnig = new Dwarf(
                "Søvnig",
                "Er det ikke på tide vi alle falder til ro og får en god nats søvn?",
                "{0} har du en seng jeg må låne i en små 12 timers tid?",
                "Nøj hvor er jeg træt. Jeg hopper i køjen. Godnat"
                );

            List<Dwarf> dwarfs = new List<Dwarf> { gnavpot, lystig, prosit, søvnig };
            Random rnd = new Random();
            List<Dwarf> currentDwarfs = new List<Dwarf>();
            currentDwarfs = dwarfs.OrderBy(x => rnd.Next()).Take(2).ToList();
            dwarfs = dwarfs.Except(currentDwarfs).ToList();
            int dwarfTracker = 0;

            bool completed = false;
            do
            {
                PrintDwarfs();

                List<DwarfAction> possibleActions = new List<DwarfAction> { DwarfAction.Disappear };

                //Calculate possible actions
                if (dwarfs.Count > 0)
                {
                    possibleActions.Add(DwarfAction.SummonDwarf);
                }
                if (dwarfTracker + 1 == dwarfs.Count)
                {
                    possibleActions.Add(DwarfAction.LastOnList);
                }

                DwarfAction action = possibleActions[rnd.Next(0, possibleActions.Count)];
                Dwarf currentDwarf = currentDwarfs[dwarfTracker];

                switch (action)
                {
                    case DwarfAction.LastOnList:
                        Console.WriteLine(currentDwarf.ReactionLastOnList());
                        break;
                    case DwarfAction.SummonDwarf:
                        Dwarf newDwarf = GetNewDwarf();
                        currentDwarfs.Add(newDwarf);
                        Console.WriteLine(currentDwarf.ReactionSummonDwarf(newDwarf.name));
                        dwarfTracker++;
                        break;
                    case DwarfAction.Disappear:
                        Console.WriteLine(currentDwarf.ReactionDisappear());
                        currentDwarfs.Remove(currentDwarf);
                        break;
                    default:
                        break;
                }

                if (dwarfTracker + 1 > currentDwarfs.Count)
                {
                    completed = true;
                }
            } while (!completed);

            Dwarf GetNewDwarf()
            {
                Dwarf temp = dwarfs[0];
                dwarfs.RemoveAt(0);
                return temp;
            }

            void PrintDwarfs()
            {
                Console.Write("[ ");

                foreach (Dwarf dwarf in currentDwarfs)
                {
                    Console.Write($"{dwarf.name} ");
                }

                Console.Write("]\n");
            }

            Console.ReadLine();
        }
    }
}
