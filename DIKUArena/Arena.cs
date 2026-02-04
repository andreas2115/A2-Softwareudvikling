using System;
using System.Collections.Generic;

namespace DIKUArena;
class Arena{
    public Arena(){}
    public Gladiator Battle(Gladiator g1, Gladiator g2) {
        Console.WriteLine("Fight til death!");
        int round = 1;
        Gladiator current = g1; 
        Gladiator inactive = g2;
        //Attack until one gladiator has lost
        while (!g1.HasLost() && !g2.HasLost()) {
            Console.WriteLine("ROUND: {0}", round);
            //Write your code here! 
            //Make the active gladiator attack
            //against the inactive!
            //...
            //Switching them, such that the
            //inactiva gladiator is current and can attack back! 
            Gladiator temp = current;
            current = inactive;
            inactive = temp;
            round++;
        }
    Console.WriteLine("The winner is: {0}", winner);
    //Make the winning gladiator Level Up
    //Then return the winning gladiator.
    } 
    public Gladiator RunTournament(List<Gladiator> Competitors) {
            // Your code here
    }
}

