using UnityEngine;
using Zenject;
using UniRx;
using Core.UI;
using Core.DataManagement.Border;

namespace Core.Player
{
    public class PlayerMover : MonoBehaviour
    {
        CompositeDisposable disposables = new CompositeDisposable();
        [Inject]
        public void Construct(IUIInput input, BorderData borderData)
        {
            input.MoveAction
                .Where(x => x != 0)
                .Subscribe(x => 
                {
                    x *= 3;
                    if (transform.position.x > borderData.LeftBorder
                    && transform.position.x < borderData.RightBorder)
                    {
                        transform.Translate(x * Time.fixedDeltaTime * Vector3.right);
                        return;
                    }
                    if (transform.position.x < borderData.LeftBorder
                    && x > 0)
                    {
                        transform.Translate(x * Time.fixedDeltaTime * Vector3.right);
                        return;
                    }
                    if (transform.position.x > borderData.RightBorder
                    && x < 0)
                    {
                        transform.Translate(x * Time.fixedDeltaTime * Vector3.right);
                        return;
                    }
                })
                .AddTo(disposables);
        }
        private void OnDestroy()
        {
            disposables.Clear();
        }
    }
}