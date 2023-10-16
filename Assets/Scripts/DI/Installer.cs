using System;
using UnityEngine;

namespace DI
{
    public class Installer : MonoBehaviour
    {
        protected DIContainer Container { get; private set; }

        public void Inject(DIContainer diContainer)
        {
            Container = diContainer;
        }
        public virtual void InstallBindings()
        {
            throw new NotImplementedException();
        }

        protected virtual void OnDestroy()
        {
            
        }
    }
}