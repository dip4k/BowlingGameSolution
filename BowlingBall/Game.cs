using System.Collections.Generic;
using System.Linq;

namespace BowlingBall
{
    public class Game : IGame
    {
        private const int FRAME_COUNT = 10;
        private readonly IList<Frame> frames;

        public Game()
        {
            frames = new List<Frame>();
        }

        public void Roll(int pins)
        {
            this.AddToFrame(pins);
        }

        public int GetScore()
        {
            int score = 0;
            for (int frameIndex = 0; frameIndex < FRAME_COUNT; frameIndex++)
            {
                Frame currentFrame = frames[frameIndex];

                if (currentFrame.IsLastFrame())
                {
                    score += currentFrame.Roll1 + currentFrame.Roll2 + currentFrame.Roll3;
                    break;
                }

                Frame nextFrame = frames[frameIndex + 1];

                if (currentFrame.IsStrike())
                {
                    score += 10 + GetNextTwoRollBonus(frameIndex);
                }
                else if (currentFrame.IsSpare())
                {
                    score += 10 + nextFrame.Roll1;
                }
                else
                {
                    score += currentFrame.Roll1 + currentFrame.Roll2;
                }
            }
            return score;
        }

        #region Private methods
        private void AddToFrame(int roll)
        {
            // frames list is empty, start new frame
            if (frames.Count == 0)
            {
                this.CreateFrame(roll);
                return;
            }

            var runningFrame = frames.Last();

            // 10th frame special case, have 3rd roll
            if (runningFrame.IsLastFrame())
            {
                this.HandleLastFrame(roll, runningFrame);
                return;
            }

            if (runningFrame.IsStrike()) // for strike complete frame
            {
                runningFrame.CloseFrame();
            }

            // current frame is complete, add new frame
            if (runningFrame.IsComplete())
            {
                this.CreateFrame(roll);
                return;
            }

            // current frame is incomplete, add 2nd roll to frame
            runningFrame.Add2ndRoll(roll);
        }

        private void HandleLastFrame(int roll, Frame runningFrame)
        {
            if (runningFrame.IsComplete())
                runningFrame.AddLastRoll(roll);
            else
                runningFrame.Add2ndRoll(roll);
        }

        private void CreateFrame(int roll)
        {
            if (frames.Count == FRAME_COUNT - 1)
                frames.Add(new Frame(roll, true));
            else
                frames.Add(new Frame(roll));
        }

        private int GetNextTwoRollBonus(int currentFrameIndex)
        {
            Frame nextFrame = frames[currentFrameIndex + 1];
            if (nextFrame.IsStrike() && currentFrameIndex + 2 <= FRAME_COUNT - 1)
            {
                Frame nextNextFrame = frames[currentFrameIndex + 2];
                return 10 + nextNextFrame.Roll1;
            }
            else
            {
                return nextFrame.Roll1 + nextFrame.Roll2;
            }
        }
        #endregion
    }
}
