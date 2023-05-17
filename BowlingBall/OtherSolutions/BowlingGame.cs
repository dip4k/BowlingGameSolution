using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingBall
{
    public class BowlingGame : IGame
    {
        private readonly IList<IBGFrame> frames = new List<IBGFrame>();
        private const int FRAMES_IN_GAME = 10;
        public void Roll(int pins)
        {
            if (frames.Count >= FRAMES_IN_GAME && frames[FRAMES_IN_GAME - 1].Complete)
                throw new ArgumentException("Cannot add rolls to a complete game");
            // add roll to each incomplete frame
            foreach (var frame in IncompleteFrames())
            {
                frame.Add(pins);
            }
        }
        private IEnumerable<IBGFrame> IncompleteFrames()
        {
            var incompleteFrames = frames.Where(frame => !frame.Complete);
            // add new in-progress frame if needed
            if (!incompleteFrames.Any(frame => frame.InProgress))
                frames.Add(new global::BGFrame());
            return incompleteFrames;
        }
        public int GetScore()
        {
            var completeFrames = frames.Where(_ => _.Complete).Take(FRAMES_IN_GAME);
            if (completeFrames.Count() != FRAMES_IN_GAME)
                throw new ArgumentException("Game incomplete");
            return completeFrames.Sum(f => f.Score);
        }
    }
}