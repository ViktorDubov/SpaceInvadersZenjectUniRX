using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using System;

namespace Core.UI
{
    public class ButtonAction : MonoBehaviour
    {
        private IObservable<bool> isPressed;
        public IObservable<bool> IsPressed { get { if (isPressed == null) isPressed = GetPressed(); return isPressed; } }
        private IObservable<bool> GetPressed()
        {
            if (TryGetComponent<Button>(out Button button))
            {
                var createStream = Observable.Create<bool>(CreateMethod);
                IObservable<bool> isDown = button.OnPointerDownAsObservable()
                    .SelectMany(_ => button.FixedUpdateAsObservable())
                    .TakeUntil(button.OnPointerUpAsObservable())
                    .RepeatUntilDestroy(button)
                    .Select(_ => { return true; });
                IObservable<bool> isUp = button.OnPointerUpAsObservable().Select(_ => { return false; });
                return Observable.Merge(createStream, isDown, isUp);
            }
            else throw new ArgumentNullException($"There is no Button in gameobject {gameObject.name}");
        }
        IDisposable CreateMethod(IObserver<bool> observer)
        {
            observer.OnNext(false);
            observer.OnCompleted();
            return null;
        }
    }
}

