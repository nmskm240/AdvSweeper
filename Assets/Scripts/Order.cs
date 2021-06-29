using UnityEngine;
using UnityEngine.Events;

public abstract class Order : ScriptableObject
{
    public UnityEvent OnOrderComplete { get; } = new UnityEvent();

    public virtual void Reset()
    {
        OnOrderComplete.RemoveAllListeners();
    }
}