using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public DeckData initialPlayerDeck;
    public DeckData initialShopDeck;

    private List<DiceData> _playerDeck;
    private List<DiceData> _playerDiscardPile = new List<DiceData>();
    private List<DiceData> _shopDeck;
    private List<DiceData> _shop;

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(this);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        _playerDeck = InitializeDeck(initialPlayerDeck);
        _playerDeck = ShuffleDeck(_playerDeck);
        
        _shopDeck = InitializeDeck(initialShopDeck);
        _shopDeck = ShuffleDeck(_shopDeck);

        InitializeShop();
    }

    private List<DiceData> InitializeDeck(DeckData deckData)
    {
        var deck = new List<DiceData>();
        deckData.dices.ForEach(exemplary =>
        {
            for (var i = 0; i < exemplary.count; i++)
            {
                deck.Add(exemplary.dice);
            }
        });
        return deck;
    }

    private List<DiceData> ShuffleDeck(List<DiceData> deck)
    {
        var newDeck = new List<DiceData>();
        while (deck.Count > 0)
        {
            var randomIndex = Random.Range(0, deck.Count);
            newDeck.Add(deck[randomIndex]);
            deck.RemoveAt(randomIndex);
        }
        return newDeck;
    }

    private void InitializeShop()
    {
        _shop = new List<DiceData>(5);
        for (int i = 0; i < 5; i++)
        {
            DrawShop(i);
        }
    }

    private void DrawShop(int placement)
    {
        if (_shopDeck.Count == 0) return;
        _shop.Insert(placement, _shopDeck[0]);
        _shopDeck.RemoveAt(0);
    }
}
