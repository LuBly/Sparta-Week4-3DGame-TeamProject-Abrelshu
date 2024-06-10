public interface IReadyPatternEvent
{
    public void ReadyPattern();
    public void EndPattern();
}

public interface IReadyOnlyPatternEvent
{
    public void ReadyPattern();
}

public interface IStartPatternEvent
{
    public void StartPattern();
    public void EndPattern();
}