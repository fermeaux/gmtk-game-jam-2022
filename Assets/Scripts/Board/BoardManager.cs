using System;
using System.Collections.Generic;
using System.Linq;
using Decks;
using Dices;
using Events;
using Flow;
using Flow.Commands;
using UnityEngine;
using UnityEngine.Serialization;

namespace Board
{
    public class BoardManager : MonoBehaviour
    {
        public static BoardManager Instance;
        [Header("References")]
        public Shop shop;
        public Zone handZone;
        public Zone playedZone;
        public Zone heroZone;
        public Transform drawPile;
        public Transform discardPile;
        public GameObject dicePrefab;
        [Header("Initial values")]
        [SerializeField] private DeckData playerDeck;
        [SerializeField] private DeckData shopDeck;

        private Deck _playerDeck;
        private Deck _shopDeck;
        
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
            _playerDeck = new Deck(playerDeck);
            _shopDeck = new Deck(shopDeck);

            for (var i = 0; i < 5; i++)
            {
                var command = new DrawShopCommand(i);
                FlowManager.Instance.AddFlowCommand(command);
            }
        }
        
        public Transform Draw()
        {
            var diceData = _playerDeck.Draw().First();
            var dice = Instantiate(dicePrefab, drawPile.position, drawPile.rotation);
            dice.GetComponent<Dice>()?.Initialize(diceData);
            return dice.transform;
        }

        public Transform DrawShop(int placement)
        {
            var start = shop.placements.drawPile;
            var diceData = _shopDeck.Draw().First();
            var dice = Instantiate(dicePrefab, start.position, start.rotation);
            dice.GetComponent<Dice>()?.Initialize(diceData);
            return dice.transform;
        }
    }
}