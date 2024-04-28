using UnityEngine;
using Zenject;
using Core.DataManagement.Resolver;

namespace Core.Player
{
    public interface IPlayerPlacer
    {
        void PlacePlayer(Vector3 position);
        void DestroyPlayer();
    }
    public class PlayerPlacer : MonoBehaviour, IPlayerPlacer
    {
        [SerializeField]
        GameObject playerPrefab;
        [SerializeField]
        GameObject currentPlayer;

        IResolver resolver;
        [Inject]
        public void Construct(IResolver resolver)
        {
            this.resolver = resolver;
        }
        public void PlacePlayer(Vector3 position)
        {
            currentPlayer = GameObject.Instantiate(playerPrefab, this.transform);
            currentPlayer.transform.position = position;
            resolver.ResolveGameObject(gameObject);
        }
        public void DestroyPlayer()
        {
            Destroy(currentPlayer);
        }
    }
}

