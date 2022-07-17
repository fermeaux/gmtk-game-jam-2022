using System.Collections;
using Board;
using Flow;
using Game;
using Stats;
using UnityEngine;

namespace Utility
{
    public static class InstanceHelper
    {
        public static IEnumerator WaitForInstances()
        {
            yield return new WaitUntil(() => GameManager.Instance != null &&
                                             BoardManager.Instance != null &&
                                             FlowManager.Instance != null &&
                                             StatManager.Instance != null);
        }
    }
}