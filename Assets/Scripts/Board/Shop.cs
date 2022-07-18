using System;
using System.Collections.Generic;
using UnityEngine;

namespace Board
{
    public class Shop : MonoBehaviour
    {
        public ShopPlacements placements;
    }

    [Serializable]
    public class ShopPlacements
    {
        public Transform drawPile;
        public Transform discardPile;
        public List<Transform> shop;
    }
}