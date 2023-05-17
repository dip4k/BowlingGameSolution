using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Tests
{
    [TestClass]
    public abstract class GameFixtureBase
    {
        protected IGame game;

        [TestMethod]
        public void Gutter_game_score_should_be_zero_test()
        {
            this.RollMany(20, 0);
            Assert.AreEqual(0, game.GetScore());
        }

        [TestMethod]
        public void TestAllOnes()
        {
            this.RollMany(20, 1);
            Assert.AreEqual(20, game.GetScore());
        }

        [TestMethod]
        public void TestAllThree()
        {
            this.RollMany(20, 3);
            Assert.AreEqual(60, game.GetScore());
        }

        [TestMethod]
        public void TestAllTwos()
        {
            this.RollMany(20, 2);
            Assert.AreEqual(40, game.GetScore());
        }

        [TestMethod]
        public void TestOneSpare()
        {
            this.RollSpare(); // spare
            game.Roll(3);
            this.RollMany(17, 0);
            Assert.AreEqual(16, game.GetScore());
        }

        [TestMethod]
        public void TestOneStrike()
        {
            RollStrike();// strike
            game.Roll(3);
            game.Roll(4);
            this.RollMany(16, 0);
            Assert.AreEqual(24, game.GetScore());
        }

        [TestMethod]
        public void TestOneStrikeThenGutterBallAndSpare()
        {
            RollStrike();
            game.Roll(0);
            game.Roll(10);
            game.Roll(1);
            RollMany(15, 0);
            Assert.AreEqual(32, game.GetScore());
        }

        [TestMethod]
        public void TestPerfectGame()
        {
            this.RollMany(12, 10);
            Assert.AreEqual(300, game.GetScore());
        }

        [TestMethod]
        public void TestRandomGame()
        {
            this.RollSpare();
            game.Roll(3);
            game.Roll(3);
            this.RollStrike();
            this.RollMany(14, 3);
            Assert.AreEqual(77, game.GetScore());
        }

        [TestMethod]
        public void TestRandomGameNoExtraRoll()
        {
            RollMany(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 0 });
            Assert.AreEqual(131, game.GetScore());
        }

        [TestMethod]
        public void TestRandomGameWithSpareThenStrikeAtEnd()
        {
            this.RollMany(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 1, 10 });
            Assert.AreEqual(143, game.GetScore());
        }

        [TestMethod]
        public void TestRandomGameWithThreeStrikesAtEnd()
        {
            this.RollMany(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 10, 10, 10 });
            Assert.AreEqual(163, game.GetScore());

        }

        private void RollMany(int times, int pins)
        {
            for (int i = 0; i < times; i++)
            {
                game.Roll(pins);
            }
        }

        private void RollMany(int[] pins)
        {
            for (int i = 0; i < pins.Length; i++)
            {
                game.Roll(pins[i]);
            }
        }

        private void RollSpare()
        {
            game.Roll(5);
            game.Roll(5);
        }

        private void RollStrike()
        {
            game.Roll(10);
        }
    }
}