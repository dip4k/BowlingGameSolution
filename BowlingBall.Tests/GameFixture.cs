using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Tests
{
    [TestClass]
    public class GameFixture : GameFixtureBase
    {
        [TestInitialize]
        public void Init()
        {
            game = new Game();
        }

        [TestMethod]
        public void TestGameClass()
        {
            Assert.IsInstanceOfType<Game>(game);
        }
    }
}
