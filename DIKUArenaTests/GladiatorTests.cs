using NUnit.Framework;
using DIKUArena;

namespace DIKUArenaTests;

public class GladiatorClassTest{
    [Test]
    public void CanCreateGladiator(){
        var g = new Gladiator("Maximus");
        Assert.AreEqual("Maximus", g.Name);
    }
}