public interface ITask
{
    string Title { get; }
    string Detail { get; }

    void OnTaskStart();
    void OnTaskComplete();
    bool CheckTaskComplete();
}