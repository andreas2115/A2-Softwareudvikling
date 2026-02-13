using System;

namespace DIKUArena;
public class Retiarii : Gladiator {
    public Retiarii(string name) : base(name){
        Dodge = 15;
        MaxHealth = 15;
        Health = 15;

    }
    public override void GetExperience(){
        Level += 1;
        Strength += 2;
        MaxHealth += 5; 
        Dodge += 8;
        DoubleStrike += 5;
        Health = MaxHealth;
    }    
}
