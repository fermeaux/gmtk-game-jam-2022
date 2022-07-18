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
        private readonly Queue<IFlowCommand> _commands = new Queue<IFlowCommand>();

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

        public void AddFlowCommand(IFlowCommand command)
        {
            _commands.Enqueue(command);
        }

        private IEnumerator FlowLoop()
        {
            while (true)
            {
                if (_commands.Count > 0)
                {
                    if (IsWaiting) IsWaiting = false;
                    var command = _commands.Dequeue();
                    yield return command.Execute();
                    if (_commands.Count == 0) IsWaiting = true;
                }
                yield return null;
            }
        }
    }
}