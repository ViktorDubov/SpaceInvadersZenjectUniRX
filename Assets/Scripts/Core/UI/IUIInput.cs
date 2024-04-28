using System;

namespace Core.UI
{
    public interface IUIInput
    {
        IObservable<float> MoveAction { get; }
        IObservable<bool> FireAction { get; }
    }
}

