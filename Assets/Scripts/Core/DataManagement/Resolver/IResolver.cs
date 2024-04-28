using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zenject;

namespace Core.DataManagement.Resolver
{
    public interface IResolver
    {
        DiContainer Container { get; set; }

        /// <summary>
        /// Add [Inject] property to function
        /// </summary>
        /// <param name="diContainer"></param>
        [Inject]
        void Construct(DiContainer diContainer);

        void ResolveGameObject(GameObject gameObject);
    }
}

