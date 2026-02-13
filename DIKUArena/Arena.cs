using System;
using System.Collections.Generic;

namespace DIKUArena;
public class Arena{
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
            current.Attack(inactive);

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
    // The winner is the one who has not lost
    Gladiator winner = g1.HasLost() ? g2 : g1;
    Console.WriteLine("The winner is: {0}", winner);
    //Make the winning gladiator Level Up
    winner.GetExperience();
    //Then return the winning gladiator.
    return winner;
    } 
    public Gladiator RunTournament(List<Gladiator> Competitors) {
        // Make shure there is gladiators in the input list
        if (Competitors == null || Competitors.Count == 0){
            throw new ArgumentException("The turnament must have a least one competitor");
        }
        // If there are any gladiators in the list.
        List<Gladiator> remaining = new List<Gladiator>(Competitors);
        while (remaining.Count > 1){
            List<Gladiator> advances = new List<Gladiator>();
            int i = 0;
            // while there is still competitors remaining
            while(i < remaining.Count){
                // if there is only one left, he advances without a battle
                if (i == remaining.Count - 1){
                    advances.Add(remaining[i]);
                    i++;
                }
                // The rest battle!
                else{
                    Gladiator winner = Battle(remaining[i], remaining[i+1]);
                    advances.Add(winner);
                    i += 2;
                }
            }
            // update remaining to run the next round of the tournament. 
            remaining = advances; 
        }
        return remaining[0];
    }
}

