using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zenject;

namespace Core.DataManagement.Resolver
{
    public class ZenjectResolver : IResolver
    {
        DiContainer container;
        public DiContainer Container { get => container; set => container = value; }

        [Inject]
        public void Construct(DiContainer diContainer)
        {
            Container = diContainer;
        }

        public void ResolveGameObject(GameObject gameObject)
        {
            Container.InjectGameObject(gameObject);
        }
    }
}