using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Tests
{
    [TestClass]
    public class PGameFixture : GameFixtureBase
    {
        [TestInitialize]
        public void Init()
        {
            game = new PGame();
        }
        [TestMethod]
        public void TestGameClass()
        {
            Assert.IsInstanceOfType<PGame>(game);
        }
    }
}
