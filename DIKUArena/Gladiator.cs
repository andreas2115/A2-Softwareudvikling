using System;

namespace DIKUArena;

public class Gladiator{
    /*
    First we define what properties a galdiator has:
    you can "get" the name, but you cannot change it ("private set"), only the class itself can.
    */
    public string Name {get; private set; } 

    /*
    Fields and properties: Fields are the actual data within the object, setting it to private makes in inaccesible.
    The property acts like a door to the field, and can adjust who can acces and change the value. 
    protected means that subclasses have acces to change the data (source: TA), which in this setup is nessesary.
    Now every class and method can acces the "get" but only subclasses can acces the "set" 
    fields = data, properties = accesrules 
    */

    // levels can only stay the same or increase
    private int level;
    public int Level {
        get {return level;} 
        protected set {if (value >= level) {level = value;}}
    }

    // Maxhealth needs to be positive 
    private int maxHealth; 
    public int MaxHealth {
        get {return maxHealth;} 
        protected set{
            if (value >= 0) {maxHealth = value;} 
            else {maxHealth = 0;}
            // adjust health if maxhealth i now smaller than health 
            if (maxHealth < health){
                health = maxHealth;
            } 
        }           
    }
    // Health is set to maxhealth if tried to set to a value larger than maxhealth. 
    private int health;
    public int Health {
        get {return health;} 
        // health is allowed to be negative
        protected set{
            if (value <= maxHealth) {health = value;} 
            else {health = maxHealth;}    
        }
        
    } 

    // Strength needs to be positive 
    private int strength;
    public int Strength {
        get {return strength;} 
        protected set {if (value >= 0) {strength = value;}} 
    } 
    // Dodge and DoubleStrike has to be positive and cannot be larger than 60 
    private int dodge;
    public int Dodge {
        get {return dodge;} 
        protected set{
            if (value <= 60 && value >= 0) {dodge = value;} 
            else if (value < 0) {dodge = 0;} 
            else {dodge = 60;}
        } 
    }
    private int doubleStrike;
    public int DoubleStrike {
        get {return doubleStrike;} 
        protected set{
            if (value <= 60 && value >= 0) {doubleStrike = value;}
            else if (value < 0) {doubleStrike = 0;} 
            else {doubleStrike = 60;}
        } 
    } 
    /*
    Now the constructor enitialises the properties of a gladiator when it is created 
    The constructor has to take a name as an argument because the name is individual for each gladiator
    But the rest is the same for all of the gladiators.
    */
    public Gladiator(string name){
        Name = name;
        Level = 1;
        MaxHealth = 20;
        Health = 20;
        Strength = 4;
        Dodge = 10;
        DoubleStrike = 10;
    }
    /*
    The object class has a method called ToString() (source ChatGPT) Which we need to override (2.3)
    This is becasue if we write Console.WriteLine(gladiator);, then C# will read this as Console.WriteLine(gladiator.ToString());
    We want to define what is written out explicitly.
    I use the build in "override" to change the ToString method. 
    */
    public override string ToString(){
        return $"Name: {Name}, Level: {Level}, Health: {Health}"; 
    }

    public bool HasLost(){
        return (Health <= 0);
    }
    private Random rand = new Random();

    public bool LoseHealth(int amount){
        int randValue = rand.Next(101);
        if (Dodge > randValue){
            Console.WriteLine($"{Name} managed to dodge");
            return false;
        }
        else{
            Health -= amount;
            return true;
        }
    }

    public void Attack(Gladiator opponent){
        int randValue = rand.Next(101);
        int damage;
        if (DoubleStrike > randValue){
            damage = 2*Strength;
            Console.WriteLine($"{Name} performs a doublestrike!");
        }
        else{
            damage = Strength;
        }
        Console.WriteLine($"{Name} strikes an attack at {opponent.Name} for {damage} points of draining.");
        opponent.LoseHealth(damage);
        
    }
    // To override GetExperience in the subclasses, the original method should contain "virtual" (source ChatGPT)
    public virtual void GetExperience(){
        Level += 1;
    } 
}

/*
class Gladiator
{
     Property: Hvad gladiatoren HAR af felter 

     constructor: Hvordan en gladiator BLIVER OPRETTET men specifikke værdier

     Method1: Hvilke informationer der bliver vist når man kalder klassen (ToString)

     Method2: Om gladiatoren har noget health tilbage(HasLost)

     Method3: Om gladiatoren mister health eller om han er heldig at "dodge" et angreb med størrelsen (amount)

     Method4: Attack er en method der giver gladiatoren mulighed for at lave angreb på andre gladiatorer

     Method5: incements level by one when called.
}
*/


// En klasse er en "skabelon" som beskriver hvilke data en (gladiator i dette tilfælde) har og hvordan den bliver oprettet
// En klasse er en "type" som samler data, og evt adfærd gennem metoder(funktioner) 
// En klasse er en slags opskift på noget (eks. en kage) og et objekt er så den kage opskriften giver
// class: gladiator = generel opskrift
// object: new gladiator("maximus") = en konkret gladiator

/*
En klasse har altså en masse felter/properties. (navn, level, maxHealth ect.) som altså er "tilstande" og ikke handling
Disse properties oprettes med deres respektive typer: string navn = ""
- Man kan begrænse adgangen til en property med at bruge ex. private. 
    ex. health må ikke bare kunne blive ændret, den skal være "låst" af klassen. 
En klasse kan også have Constructors. 
    en constrructor sætter     
*/


// 1. Jeg skal gøre følgende: definere tilstand (felter/properties)
// 2. Jeg skal initialisere tilstanden korrekt. (constructor)

