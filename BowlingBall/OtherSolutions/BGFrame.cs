using System;

class BGFrame : IBGFrame
{
    private int rollsAllowed = 2;
    private const int ALL_PINS = 10;
    public void Add(int pins)
    {
        if (Complete)
            throw new ArgumentException("Cannot add pins to a complete frame");
        if (pins < 0 || pins > ALL_PINS)
            throw new ArgumentException("Illegal number of pins");
        if (rollsAllowed == 2 && Score + pins > ALL_PINS)
            throw new ArgumentException($"Cannot hit more than {ALL_PINS} pins in a frame");
        Rolled++;
        Score += pins;
        // Add bonus roll(s) if we knock down all pins in 1 or 2 throws
        if (Rolled < 3 && Score == ALL_PINS)
            rollsAllowed = 3;
    }

    public bool InProgress => Rolled < 2 && Score < ALL_PINS;
    public bool Complete => Rolled >= rollsAllowed;
    public int Rolled { get; private set; } // count of rolls in frame
    public int Score { get; private set; }
}
