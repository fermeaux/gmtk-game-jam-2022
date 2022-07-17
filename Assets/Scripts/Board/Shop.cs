using System;
using System.Collections.Generic;
using UnityEngine;

namespace Board
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private ShopPlacements placements;
    }

    [Serializable]
    public class ShopPlacements
    {
        [SerializeField] private Transform drawPile;
        [SerializeField] private Transform discardPile;
        [SerializeField] private List<Transform> shop;
    }
}