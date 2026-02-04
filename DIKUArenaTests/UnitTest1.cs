using NUnit.Framework;
using DIKUArena;

namespace DIKUArenaTests
{
    public class UnitTest1 {
        private Arena arena;
        private Traex traex;
        private Samnite samnite;
        private Retiarii retiarii;
        private Gladiator glad;

        [SetUp]
        public void Setup() {
            arena = new Arena();
            traex = new Traex("Trata");
            samnite = new Samnite("Samna");
            retiarii = new Retiarii("Retata");
            glad = new Gladiator("glad");
        }

        [Test]
        public void TestArenaInitialization() {
            Assert.IsNotNull(arena);
        }
        
        [Test] 
        public void TestBattle(){
            Gladiator res = arena.Battle(traex, samnite);
            Assert.IsNotNull(res);
        }
        
        [Test] 
        public void onlyOneLost(){
            arena.Battle(traex, samnite);
            Assert.Multiple(() =>{
                Assert.IsFalse(traex.HasLost() && samnite.HasLost());  // Both can not lose
                Assert.IsTrue(!traex.HasLost() || !samnite.HasLost()); // One must win
            });
        }
        
        [Test]
        public void TestRunTournament() {
            Gladiator[] instances = {traex, samnite, retiarii, glad};
            List<Gladiator> players = new List<Gladiator>(instances);

            Gladiator res = arena.RunTournament(players);

            Assert.IsNotNull(res);
        }

        // Due to non-specificality in protection level of fields/properties, there are no 
        // Further explicit tests
    }
}
