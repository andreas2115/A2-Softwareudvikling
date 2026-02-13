using System;
using System.Collections.Generic;

namespace DIKUArena;

class Program
{
    static void Main(string[] args){
        Gladiator samnite = new Samnite("Boris");
        Gladiator traex = new Traex("Oleks");
        Gladiator retiarii = new Retiarii("Professor Boss");
        Gladiator traex2 = new Traex("Oleks jr.");
        List<Gladiator> competitors = new List<Gladiator>();
        competitors.Add(samnite);
        competitors.Add(traex);
        competitors.Add(retiarii);
        competitors.Add(traex2);

        Arena tournament = new Arena();
        Gladiator winner = tournament.RunTournament(competitors);
        Console.WriteLine($"The winner of the tournament is {winner.Name}!");
    }
}


