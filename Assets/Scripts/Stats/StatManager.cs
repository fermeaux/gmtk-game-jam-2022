using UnityEngine;

namespace Stats
{
    public class StatManager : MonoBehaviour
    {
        public static StatManager Instance;
        public StatData gold;
        public StatData damage;
        public StatData health;
        [SerializeField] private StatData healthBase;
        public StatData enemyHealth;
        [SerializeField] private StatData enemyHealthBase;
        
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
            ResetTurn();
            health.Value = healthBase.Value;
            enemyHealth.Value = enemyHealthBase.Value;
        }

        public void ResetTurn()
        {
            gold.Value = 0;
            damage.Value = 0;
        }
    }
}