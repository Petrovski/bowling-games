using BowlingGame;
using NUnit.Framework;

namespace BowlingGameTests
{
    public class BowlingGameTests
    {
        private Game game;

        [SetUp]
        public void Setup()
        {
            game = new Game();
        }

        [Test]
        public void TestGutterGame()
        {
            RollPins(20, 0);

            Assert.AreEqual(0, game.Score());
        }

        [Test]
        public void TestAllOnePinsHit()
        {
            RollPins(20, 1);

            Assert.AreEqual(20, game.Score());
        }
        
        [Test]
        public void TestOneSpare()
        {
            RollSpare();
            game.Roll(4);

            Assert.AreEqual(18, game.Score());
        }

        [Test]
        public void TestOneStrike()
        {
            RollStrike();
            game.Roll(5);
            game.Roll(4);

            RollPins(16, 0);

            Assert.AreEqual(28, game.Score());
        }

        [Test]
        public void TestPerfectGame()
        {
            RollPins(12, 10);

            Assert.AreEqual(300, game.Score());
        }

        private void RollSpare()
        {
            game.Roll(4);
            game.Roll(6);
        }

        private void RollStrike()
        {
            game.Roll(10);
        }

        private void RollPins(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                game.Roll(pins);
            }
        }
    }
}