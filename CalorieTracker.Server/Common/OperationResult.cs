namespace CalorieTracker.Server.Common;

public class OperationResult<T>
{
    public T Result { get; init; }
    public List<string> Errors { get; init; } = new List<string>();
    public bool IsSuccessful => Errors.Count == 0;
}