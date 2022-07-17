using System;
using System.Collections.Generic;
using System.Linq;
using Decks;
using Events;
using UnityEngine;
using UnityEngine.Serialization;

namespace Board
{
    public class BoardManager : MonoBehaviour
    {
        public static BoardManager Instance;
        [SerializeField] private Field player;
        [SerializeField] private Field shop;

        private Deck _playerDeck;
        private Deck _shopDeck;
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

        public void Initialize()
        {
            _playerDeck = new Deck(player.deckData);
            _shopDeck = new Deck(shop.deckData);

            InitializeShop();
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
            var drawDice = _shopDeck.Draw().First();
            if (drawDice == null) return;
            _shop.Insert(placement, drawDice);
            shop.onUpdate?.Raise();
        }
    }

    [Serializable]
    public class Field
    {
        public DeckData deckData;
        public GameEvent onUpdate;
    }
}