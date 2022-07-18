using UnityEngine;

namespace Dices
{
    public class Dice : MonoBehaviour
    {
        private DiceData _data;

        public void Initialize(DiceData data)
        {
            _data = data;
        }
    }
}