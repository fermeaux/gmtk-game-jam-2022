using System;
using Events;
using UnityEngine;

namespace Stats
{
    [CreateAssetMenu(fileName = "Stat", menuName = "ScriptableObjects/Stat")]
    public class StatData : ScriptableObject
    {
        [SerializeField] private int stat;
        public int Value
        {
            get => stat;
            set
            {
                stat = value;
                onUpdated?.Raise();
            }
        }
        
        public GameEvent onUpdated;
    }
}