using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    [CreateAssetMenu(fileName = "GameEvent", menuName = "ScriptableObjects/Game Event")]
    public class GameEvent : ScriptableObject
    {
        [SerializeField] private UnityEvent reactors;
    
        public void Raise()
        {
#if UNITY_EDITOR
            Debug.Log($"Event raised : {name}");
#endif
            reactors?.Invoke();
        }

        public void Register(UnityAction action) => reactors.AddListener(action);

        public void Unregister(UnityAction action) => reactors.RemoveListener(action);
    }
}
