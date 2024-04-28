using UnityEngine;
using UniRx;
using System;

namespace Core.UI
{
    public class UIInput : MonoBehaviour, IUIInput
    {
        [SerializeField]
        ButtonAction left, right, fire;

        private IObservable<float> moveAction;
        public IObservable<float> MoveAction { get { if (moveAction == null) moveAction = GetMove(); return moveAction; } }

        private IObservable<bool> fireAction;
        public IObservable<bool> FireAction { get { if (fireAction == null) fireAction = GetFire(); return fireAction; } }

        private IObservable<float> GetMove()
        {
            if (left && right)
            {
                return Observable.CombineLatest(left.IsPressed, right.IsPressed)
                    .Select(x => { return (x[0] ? -1f : 0f) + (x[1] ? 1f : 0f); });
            }
            else throw new ArgumentNullException("There are no ButtonActions for move");
        }
        private IObservable<bool> GetFire()
        {
            if (fire) return fire.IsPressed;
            else throw new ArgumentNullException("There is no ButtonAction for fire");
        }
    }
}

