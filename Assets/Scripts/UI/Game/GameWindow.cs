using TMPro;
using UI.BaseLayout;
using UnityEngine;

namespace UI.Game
{
    public class GameWindow : Window
    {
        [SerializeField] private TextMeshProUGUI _textScore;
        [SerializeField] private TextMeshProUGUI _healthScore;


        public void SetScore(float value)
        {
            _textScore.text = $"Score {value}";
        }

        public void SetHealth(float value)
        {
            _healthScore.text = $"Health {value}";
        }
        
        public void SetHealth(string value)
        {
            _healthScore.text = value;
        }
    }
}