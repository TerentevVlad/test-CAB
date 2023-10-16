using TMPro;
using UI.BaseLayout;
using UnityEngine;
using UnityEngine.UI;

namespace UI.EndGame
{
    public class EndGameWindow : Window
    {  
        [field: SerializeField] public Button ReloadButton { get; private set; }
        [field: SerializeField] public TextMeshProUGUI CurrentScoreText { get; private set; }
        [field: SerializeField] public TextMeshProUGUI RecordScoreText { get; private set; }


    }
}