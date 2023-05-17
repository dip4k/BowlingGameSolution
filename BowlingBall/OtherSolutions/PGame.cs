using System.Collections.Generic;
using System.Linq;

namespace BowlingBall
{
    public class PGame : IGame
    {
        private readonly IList<int> pins = new List<int>();

        public void Roll(int n) => pins.Add(n);

        public int GetScore() => pins.Scores().Take(10).Sum();
    }


}
