namespace BowlingBall
{
    public class PlaneGame : IGame
    {
        // max 21 rolls possible for 10 frames, 9 frames with 2 rolls each and 10th frame with 3 rolls
        private readonly int[] Rolls = new int[21];
        private int CurrentRoll = 0;
        private const int FRAME_COUNT = 10;

        public void Roll(int pins)
        {
            Rolls[CurrentRoll++] = pins;
        }

        public int GetScore()
        {
            int score = 0;
            int frameIndex = 0;

            // for strike only one roll is used so go to next frame by incrementing roll by 1
            for (int frame = 0; frame < FRAME_COUNT; frame++)
            {
                if (IsStrike(frameIndex))
                {
                    score += 10 + StrikeBonus(frameIndex);
                    frameIndex++; // for strike there is no pins start new frame/round
                }
                else if (IsSpare(frameIndex))
                {
                    score += 10 + SpareBonus(frameIndex);
                    frameIndex += 2; // frameend
                }
                else
                {
                    score += SumOfPinsInFrame(frameIndex);
                    frameIndex += 2;
                }
            }
            return score;
        }

        #region Private methods
        private bool IsStrike(int frameIndex)
        {
            return Rolls[frameIndex] == 10;
        }

        private bool IsSpare(int frameIndex)
        {
            return Rolls[frameIndex] + Rolls[frameIndex + 1] == 10; // preemptive forward score calculation
        }

        private int SumOfPinsInFrame(int frameIndex)
        {
            return Rolls[frameIndex] + Rolls[frameIndex + 1];
        }

        private int SpareBonus(int frameIndex)
        {
            return Rolls[frameIndex + 2];
        }

        private int StrikeBonus(int frameIndex)
        {
            return Rolls[frameIndex + 1] + Rolls[frameIndex + 2];
        }
        #endregion

    }
}
