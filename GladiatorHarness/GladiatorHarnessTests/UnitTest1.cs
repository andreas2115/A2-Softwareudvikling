using System;
using NUnit.Framework;
using DIKUArena;

namespace GladiatorHarnessTests;

public class GladiatorClassTest{
    // Source, ChatGPT to help with how to specifically setup a variable g that can be used 
    // in multiple tests.
    private Gladiator g;
    [SetUp]
    public void Setup(){
        g  = new Gladiator("Maximus");
    }

    [Test]
    public void CanCreateGladiator_test(){
        Assert.AreEqual("Maximus", g.Name);
        Assert.AreEqual(1, g.Level);
        Assert.AreEqual(20, g.MaxHealth);
        Assert.AreEqual(4, g.Strength);
        Assert.AreEqual(10, g.Dodge);
        Assert.AreEqual(10, g.DoubleStrike);
        Console.WriteLine("Created Gladiator with correct specifications succesfully");
    }
    [Test]
    public void ToStringOverride_test(){
        Assert.AreEqual($"Name: {g.Name}, Level: {g.Level}, Health: {g.Health}", g.ToString());
        Console.WriteLine("ToString was overritten succesfully and returns name, level and health");
    }

    [Test]
    public void HasLost_test(){
        Assert.IsFalse(g.HasLost());
        Console.WriteLine("HasLost() correctly returns false for a gladiator who has positive health");        
    }

    [Test]
    public void LoseHealth_test(){
        int initialHealth = g.Health;
        bool tookDamage = g.LoseHealth(5);

        if (tookDamage){
            Assert.AreEqual(initialHealth - 5, g.Health);
        }
        else{
            Assert.AreEqual(initialHealth, g.Health);
        }
        Console.WriteLine("The gladiator did not take damage if he was able to dodge, and took damage if he was unable to dodge ");
    }

    [Test]
    public void Attack_test(){
        var g2 = new Gladiator("Spartacus");
        Console.WriteLine($"{g.Name} has attacked {g2.Name}");
        int initialHealth = g2.Health;
        g.Attack(g2);
        Assert.That(g2.Health, Is.AnyOf(
            initialHealth,
            initialHealth - g.Strength,
            initialHealth - (2*g.Strength)
        ));
        Console.WriteLine($"The health of {g2.Name} was reduced correctly");
    }

    [Test]
    public void GetExperience_test(){
        int initalLevel = g.Level;
        g.GetExperience();
        Assert.AreEqual(g.Level,initalLevel+1);
        Console.WriteLine("Glatiators level was increased by one succesfully");
    }


}


// Setting up a dummy galdiator class that enables me to "try" to set 
// Health, Dodge and DoubleStrike to any input. 
public class TestGladiator : Gladiator{
    public TestGladiator(string name) : base(name) 
    { }
    public void SetHealth(int v){
        Health = v;
    }  
    public void SetDodge(int v){
        Dodge = v;
    } 
    public void SetDoubleStrike(int v){
        DoubleStrike = v;    
    } 
}


public class GladiatorTypesTest{
    [Test]
    public void CorrectTypeSpecs_test(){
        var samnite = new Samnite("Samnite");
        Assert.AreEqual(6, samnite.Strength);
        Assert.AreEqual(5, samnite.Dodge);

        var retiarii = new Retiarii("Retiarii");
        Assert.AreEqual(15,retiarii.Dodge);
        Assert.AreEqual(15,retiarii.Health);
        Assert.AreEqual(15,retiarii.MaxHealth);

        var traex = new Traex("Traex");
        Assert.AreEqual(30,traex.Health);
        Assert.AreEqual(30,traex.MaxHealth);
        Assert.AreEqual(15,traex.DoubleStrike);
        Console.WriteLine("All glatiators types were initialized correctly");
    }

    [Test]
    public void GetExpOverride_test(){
        var samnite = new Samnite("Samnite");
        int initLevel = samnite.Level;
        int initStrength = samnite.Strength;
        int initMaxHealth = samnite.MaxHealth;
        int initDodge = samnite.Dodge;
        int initDoubleStrike = samnite.DoubleStrike;

        samnite.GetExperience();

        Assert.AreEqual(initLevel + 1, samnite.Level);
        Assert.AreEqual(initStrength + 3, samnite.Strength);
        Assert.AreEqual(initMaxHealth + 15, samnite.MaxHealth);
        Assert.AreEqual(initDodge + 2, samnite.Dodge);
        Assert.AreEqual(initDoubleStrike + 5, samnite.DoubleStrike);
        Assert.AreEqual(samnite.Health, samnite.MaxHealth);
        Console.WriteLine("The overridden GetExp worked correctly for subclass Samnite");
    }

    // Using the dummy class to "try" to set Health, Dodge and DoubleStrike to 
    // Values that should not be allowed.
    [Test]
    public void WrongSet_test(){
        var dummy = new TestGladiator("dummy");
        dummy.SetDodge(70);
        dummy.SetDoubleStrike(-1);
        dummy.SetHealth(dummy.MaxHealth+1);
        Assert.AreEqual(60, dummy.Dodge);
        Assert.AreEqual(0, dummy.DoubleStrike);
        Assert.AreEqual(dummy.MaxHealth, dummy.Health);
        Console.WriteLine("The dummy test was succesfull and disallowed values where not set");
    }
}

public class ArenaTest{
    [Test]
    public void Arena_test(){
        var sam = new Samnite("Samnite");
        var ret = new Retiarii("Retiarii");
        var arena = new Arena();

        int samLevelBefore = sam.Level;
        int retLevelBefore = ret.Level;

        var winner = arena.Battle(sam, ret);

        //The winner has not lost
        Assert.That(winner.HasLost(), Is.False);

        //one of the gladiators has leveled up
        bool samUp = sam.Level > samLevelBefore;
        bool retUp = ret.Level > retLevelBefore;
        // both cannot be true (source for how to setup the assert function call ChatGPT)
        Assert.That(samUp ^ retUp, Is.True);

        //The one that won, needs to have had an increase in level
        if (samUp){
            Assert.AreEqual(winner.Level, samLevelBefore + 1);
        }
        else{
            Assert.AreEqual(winner.Level, retLevelBefore + 1);
        }
    }
}




