using System;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public abstract class LongPressMonoBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _waitTime = 1.5f;

    protected virtual void Start()
    {
        var eventTrigger = this.gameObject.AddComponent<ObservableEventTrigger>();
        eventTrigger.OnPointerDownAsObservable()
            .SelectMany(_ => Observable.Interval(TimeSpan.FromSeconds(_waitTime)))
            .TakeUntil(eventTrigger.OnPointerUpAsObservable())
            .RepeatUntilDestroy(this.gameObject)
            .Subscribe(x => 
            {
                OnLongPressed();
            });
    }

    protected abstract void OnLongPressed();
}