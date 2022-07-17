using System.Collections;
using System.Collections.Generic;
using Events;
using UnityEngine;

namespace Flow
{
    public class FlowManager : MonoBehaviour
    {
        public static FlowManager Instance;
        [SerializeField] private GameEvent onRunning;
        [SerializeField] private GameEvent onWaiting;
        private readonly Queue<IFlowItem> _flowItems = new Queue<IFlowItem>();

        private bool _isWaiting = true;
        private bool IsWaiting
        {
            get => _isWaiting;
            set
            {
                _isWaiting = value;
                if (_isWaiting) onWaiting?.Raise();
                else onRunning?.Raise();
            }
        }
        
        private void Awake()
        {
            if (Instance != null)
            {
                DestroyImmediate(this);
                return;
            }
            Instance = this;
            StartCoroutine(FlowLoop());
        }

        public void AddFlowItem(IFlowItem flowItem)
        {
            _flowItems.Enqueue(flowItem);
        }

        private IEnumerator FlowLoop()
        {
            while (true)
            {
                if (_flowItems.Count > 0)
                {
                    IsWaiting = false;
                    var flowItem = _flowItems.Dequeue();
                    yield return flowItem.Execute();
                    if (_flowItems.Count == 0) IsWaiting = true;
                }
                yield return null;
            }
        }
    }
}