namespace CalorieTracker.Server.Common;

public class CommandResult<T>
{
    public T Result { get; set; }
    public List<string> Errors { get; set; }
    public bool IsSuccessful => Errors.Count == 0;
}