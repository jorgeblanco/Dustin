using TMPro;
using UnityEngine;

namespace Dustin.Scripts
{
    public class DebugTextUpdater : MonoBehaviour
    {
        [SerializeField] private DebugText debugText;
        private TextMeshProUGUI _text;

        private void Start()
        {
            _text = GetComponentInChildren<TextMeshProUGUI>();
            debugText.onUpdated += OnUpdated;
        }

        private void OnUpdated(string text)
        {
            _text.text = text;
        }
    }
}
