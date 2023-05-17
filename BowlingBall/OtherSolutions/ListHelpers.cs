using System.Collections.Generic;

namespace BowlingBall
{
    public static class ListHelpers
    {
        public static IEnumerable<int> Scores(this IList<int> pins)
        {
            int currentScore = 0;
            // Walk the list in steps of two rolls (= one frame)
            for (int i = 0; i + 1 < pins.Count; i += 2)
            {
                // Neither strike nor spare
                if (pins[i] + pins[i + 1] < 10)
                {
                    currentScore += pins[i] + pins[i + 1];
                    yield return pins[i] + pins[i + 1];
                    continue;
                }

                // Score can only be determined if third roll is available
                if (i + 2 >= pins.Count)
                    yield break;

                currentScore += pins[i] + pins[i + 1] + pins[i + 2];
                yield return pins[i] + pins[i + 1] + pins[i + 2];

                // In case of strike, advance only by one
                if (pins[i] == 10)
                    i--;
            }
        }
    }
}
