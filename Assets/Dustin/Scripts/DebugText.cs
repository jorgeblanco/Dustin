using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Dustin.Scripts
{
    [CreateAssetMenu(fileName = "DebugText", menuName = "ScriptableObjects/Debug Text")]
    public class DebugText : ScriptableObject
    {
        public delegate void OnUpdatedCallback(string text);
        public OnUpdatedCallback onUpdated = (text) => { };
        private string _text;

        public void SetText(string value)
        {
            _text = value;
            onUpdated(value);
        }

        public string GetText()
        {
            return _text;
        }
    }
}
