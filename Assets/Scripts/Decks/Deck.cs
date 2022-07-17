using System;
using System.Collections.Generic;
using System.Linq;
using Flow;
using Random = UnityEngine.Random;

namespace Decks
{
    [Serializable]
    public class Deck
    {
        private readonly DeckData _ref;
        private List<DiceData> _drawPile;
        private List<DiceData> _discardPile;

        public Deck(DeckData deckData)
        {
            _ref = deckData;
            Initialize();
        }

        private void Initialize()
        {
            _discardPile = new List<DiceData>();
            _drawPile = new List<DiceData>();
            _ref.dices.ForEach(exemplary =>
            {
                for (var i = 0; i < exemplary.count; i++)
                {
                    _drawPile.Add(exemplary.dice);
                }
            });
            Shuffle();
        }

        public void Shuffle()
        {
            var newDrawPile = new List<DiceData>();
            while (_drawPile.Count > 0)
            {
                var randomIndex = Random.Range(0, _drawPile.Count);
                newDrawPile.Add(_drawPile[randomIndex]);
                _drawPile.RemoveAt(randomIndex);
            }
            _drawPile = newDrawPile;
            _ref.onShuffle?.Raise();
        }

        public List<DiceData> Draw(int x = 1)
        {
            var drawDices = new List<DiceData>();
            for (var i = 0; i < x; i++)
            {
                if (_drawPile.Count == 0) Shuffle();
                if (_drawPile.Count == 0) return drawDices;
                drawDices.Add(_drawPile.Last());
                _drawPile.RemoveAt(_drawPile.Count - 1);
                _ref.onDraw?.Raise();
            }
            return drawDices;
        }
    }
}