internal interface IBGFrame
{
    bool Complete { get; }
    bool InProgress { get; }
    int Rolled { get; }
    int Score { get; }

    void Add(int pins);
}