using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Deck", menuName = "ScriptableObjects/Deck")]
public class DeckData : ScriptableObject
{
    public List<DiceExemplary> dices;
}

[Serializable]
public class DiceExemplary
{
    public DiceData dice;
    public int count;
}
