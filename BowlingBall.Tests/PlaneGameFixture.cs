using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Tests
{
    [TestClass]
    public class PlaneGameFixture : GameFixtureBase
    {
        [TestInitialize]
        public void Init()
        {
            game = new PlaneGame();
        }
        [TestMethod]
        public void TestGameClass()
        {
            Assert.IsInstanceOfType<PlaneGame>(game);
        }
    }
}
