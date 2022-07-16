using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dice", menuName = "ScriptableObjects/Dice")]
public class DiceData : ScriptableObject
{
    [Range(0, 8)] public int price = 4;
    public DiceColor color;
    public DiceType type;
    public List<DiceFace> face;
}

public enum DiceColor
{
    None,
    Yellow,
    Red,
    Blue,
    Green
}

public enum DiceType
{
    Action,
    Hero,
    Object
}

[Serializable]
public class DiceFace
{
    public DiceEffects effectsByDefault;
    public DiceEffects effectsByColor;
    public DiceEffects effectsBySacrifice;
    [Header("Hero attributes")]
    [Range(0, 7)] public int health;
    public bool isGuard;
}

[Serializable]
public class DiceEffects
{
    public List<DiceEffect> effects;
    public DiceEffectCombination combination;
}

public enum DiceEffectCombination
{
    All,
    One,
    Two
}

[Serializable]
public class DiceEffect
{
    public DiceEffectType type;
    [Range(1, 8)] public int amount;
}

public enum DiceEffectType
{
    Damage,
    Gold,
    Heal,
    Draw,
    Reroll,
    AcquireTopDeck,
    AcquireHand,
    DrawAndDiscard,
    Sacrifice,
    HealByHero,
    DamageByHero,
    DamageByGuard,
    Mobilize,
    DamageByColor
}
