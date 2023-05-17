using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Tests
{
    [TestClass]
    public class BowlingGameFixture : GameFixtureBase
    {
        [TestInitialize]
        public void Init()
        {
            game = new BowlingGame();
        }

        [TestMethod]
        public void TestGameClass()
        {
            Assert.IsInstanceOfType<BowlingGame>(game);
        }
    }
}
