using System;
using System.Collections.Generic;
using UnityEngine;

namespace Events
{
    public class UnityEventNotifier : MonoBehaviour
    {
        [SerializeField] private List<GameEvent> onEnableEvents;
        [SerializeField] private List<GameEvent> awakeEvents;
        [SerializeField] private List<GameEvent> startEvents;
        [SerializeField] private List<GameEvent> updateEvents;
        [SerializeField] private List<GameEvent> fixedUpdateEvents;
        [SerializeField] private List<GameEvent> onDisableEvents;
        [SerializeField] private List<GameEvent> onDestroyEvents;
        
        private void OnEnable() => onEnableEvents?.ForEach(action => action.Raise());
        
        private void Awake() => awakeEvents?.ForEach(action => action.Raise());

        private void Start() => startEvents?.ForEach(action => action.Raise());

        private void Update() => updateEvents?.ForEach(action => action.Raise());

        private void FixedUpdate() => fixedUpdateEvents?.ForEach(action => action.Raise());

        private void OnDisable() => onDisableEvents?.ForEach(action => action.Raise());

        private void OnDestroy() => onDestroyEvents?.ForEach(action => action.Raise());
    }
}