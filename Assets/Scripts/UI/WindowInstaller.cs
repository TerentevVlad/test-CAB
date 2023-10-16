using System;
using System.Collections.Generic;
using DI;
using UI.BaseLayout;
using UI.EndGame;
using UI.Game;
using UnityEngine;

namespace UI
{
    public class WindowInstaller : Installer
    {
        [SerializeField] private StartWindow.StartWindow startWindow;
        [SerializeField] private GameWindow gameWindow;
        [SerializeField] private EndGameWindow _endGameWindow;
        
        Dictionary<Type, Window> _windows = new Dictionary<Type, Window>();
        public override void InstallBindings()
        {
            AppendWindow(startWindow);
            AppendWindow(gameWindow);
            AppendWindow(_endGameWindow);
            

            Container
                .Bind<WindowService>()
                .FromInstance(new WindowService(_windows));
            
        }

        private void AppendWindow(Window window)
        {
            _windows.Add(window.GetType(), window);
        } 
    }
}