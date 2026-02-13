using System;

namespace DIKUArena;
public class Traex : Gladiator {
    public Traex(string name) : base(name){
        MaxHealth = 30;
        Health = 30;
        DoubleStrike = 15;
    }
    public override void GetExperience(){
        Level += 1;
        Strength += 2;
        MaxHealth += 10; 
        Dodge += 5;
        DoubleStrike += 8;
        Health = MaxHealth;
    }        
}
