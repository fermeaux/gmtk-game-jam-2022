using System;
using System.Collections.Generic;
using Events;
using UnityEngine;

namespace Decks
{
    [CreateAssetMenu(fileName = "Deck", menuName = "ScriptableObjects/Deck")]
    public class DeckData : ScriptableObject
    {
        public List<DiceExemplary> dices;
        public GameEvent onShuffle;
        public GameEvent onDraw;
    }

    [Serializable]
    public class DiceExemplary
    {
        public DiceData dice;
        public int count;
    }
}