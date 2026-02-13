using System;

namespace DIKUArena;
public class Samnite : Gladiator {
    public Samnite(string name) : base(name){
        Strength = 6;
        Dodge = 5;
    }
    public override void GetExperience(){
        Level += 1;
        Strength += 3;
        MaxHealth += 15; 
        Dodge += 2;
        DoubleStrike += 5;
        Health = MaxHealth;
    }
}
