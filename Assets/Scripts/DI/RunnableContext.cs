
using System;
using System.Collections.Generic;
using UnityEngine;

namespace DI
{
    public abstract class RunnableContext : MonoBehaviour
    {
        [SerializeField] private List<Installer> _installers;
        public DIContainer DiContainer { get; protected set; }

        protected void Run()
        {
            foreach (var installer in _installers)
            {
                installer.Inject(DiContainer);
            }
            
            foreach (var installer in _installers)
            {
                installer.InstallBindings();
            }
            
            DiContainer.RunInstall();
        }

        private void OnDestroy()
        {
            DiContainer.Dispose();
        }
    }
}