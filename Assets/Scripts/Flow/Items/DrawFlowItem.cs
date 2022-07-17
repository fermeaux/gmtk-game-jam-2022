using System.Collections;
using UnityEngine;

namespace Flow.Items
{
    public class DrawFlowItem : IFlowItem
    {
        private Transform _startPosition;
        private Transform _endPosition;
        private float _duration;
        
        public DrawFlowItem(Transform startPosition, Transform endPosition, float duration = 0.2f)
        {
            
        }
        
        public IEnumerator Execute()
        {
            yield return new WaitForSeconds(0.2f);
        }
    }
}