public abstract class BaseService
{
    public event EventHandler OnMethodPerformed;

    // Template method — final flow
    public void Execute()
    {
        PerformWork();
        OnWorkCompleted();
    }

    protected abstract void PerformWork();

    protected virtual void OnWorkCompleted()
    {
        OnMethodPerformed?.Invoke(this, EventArgs.Empty);
    }
}

public class MyService : BaseService
{
    protected override void PerformWork()
    {
        Console.WriteLine("Doing work...");
    }
}

public class MyEnhancedService : BaseService
{
    protected override void PerformWork()
    {
        Console.WriteLine("Enhanced work...");
    }

    protected override void OnWorkCompleted()
    {
        Console.WriteLine("Post-processing...");
        base.OnWorkCompleted();
    }
}

public interface IService
{
    void Execute();
}
