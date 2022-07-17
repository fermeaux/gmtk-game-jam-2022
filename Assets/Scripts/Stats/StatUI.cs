using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Stats
{
    public class StatUI : MonoBehaviour
    {
        public StatData stat;
        private TextMeshProUGUI _text;
        private UnityAction _action;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
            _action += DisplayValue;
        }

        private void OnEnable() => stat?.onUpdated?.Register(_action);
        
        private void OnDisable() => stat?.onUpdated?.Unregister(_action);

        private void DisplayValue() => _text.text = $"{stat?.Value ?? 0}";
    }
}