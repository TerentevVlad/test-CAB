using UI.BaseLayout;
using UnityEngine;
using UnityEngine.UI;

namespace UI.StartWindow
{
    public class StartWindow : Window
    {
        [field: SerializeField] public Button PlayButton { get; private set; }
    }
}