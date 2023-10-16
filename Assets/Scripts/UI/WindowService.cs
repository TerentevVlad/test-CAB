using System;
using System.Collections.Generic;
using UI.BaseLayout;

namespace UI
{
    public class WindowService 
    {
        private readonly Dictionary<Type, Window> _windows;

        private Window CurrentWindow { get; set; } = null;

        public WindowService(Dictionary<Type, Window> windows)
        {
            _windows = windows;
        }

        public void Open<T>() where T : Window
        {
            if (CurrentWindow != null)
            {
                CurrentWindow.Hide();   
            }
            CurrentWindow = _windows[typeof(T)];
            CurrentWindow.Show();
        }

        public void CloseAll()
        {
            foreach (var windowsValue in _windows.Values)
            {
                windowsValue.Hide();
            }
        }
        
    }
}