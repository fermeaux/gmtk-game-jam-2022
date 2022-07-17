using System.Collections;
using Board;
using Flow;
using Stats;
using UnityEngine;
using Utility;

namespace Game
{
    [RequireComponent(typeof(BoardManager))]
    [RequireComponent(typeof(FlowManager))]
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        
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
            StartCoroutine(InitializeGame());
        }

        private IEnumerator InitializeGame()
        {
            yield return InstanceHelper.WaitForInstances();
            StatManager.Instance.Initialize();
            BoardManager.Instance.Initialize();
        }
    }
}
