namespace BowlingBall
{
    public class Frame
    {
        private FrameStatus frameStatus = FrameStatus.InProgress;
        private readonly int roll1;
        private int roll2 = 0;
        private int roll3 = 0;
        private bool isLastFrame = false;

        private Frame(int roll)
        {
            roll1 = roll;
        }

        public Frame(int roll, bool isLastFrame = false) : this(roll)
        {
            this.isLastFrame = isLastFrame;
        }
        public void Add2ndRoll(int roll)
        {
            this.roll2 = roll;
            frameStatus = FrameStatus.Complete;
        }

        public void AddLastRoll(int roll)
        {
            this.roll3 = roll;
            isLastFrame = true;
        }

        public int Roll1 { get => roll1; }

        public int Roll2 { get => roll2; }

        public int Roll3 { get => roll3; }

        public bool IsLastFrame() { return isLastFrame; }

        public void CloseFrame() => frameStatus = FrameStatus.Complete;

        public bool IsComplete() => frameStatus == FrameStatus.Complete;

        public bool IsStrike() => Roll1 == 10;

        public bool IsSpare() => Roll1 + Roll2 == 10;
    }
}
