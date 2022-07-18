using System.Collections;
using System.Linq;
using Board;
using DG.Tweening;
using Dices;
using UnityEngine;

namespace Flow.Commands
{
    public class DrawFlowCommand : IFlowCommand
    {
        private readonly float _amount;
        private const float Duration = 1f;
        
        public DrawFlowCommand(float amount = 1)
        {
            _amount = amount;
        }
        
        public IEnumerator Execute()
        {
            for (var i = 0; i < _amount; i++)
            {
                var dice = BoardManager.Instance.Draw();
                AnimateDice(dice);
                yield return new WaitForSeconds(Duration);
            }
        }

        private void AnimateDice(Transform dice)
        {
            dice.transform.DOPath(GetPath(), Duration, PathType.CubicBezier);
            dice.transform.DORotate(new Vector3(0,0,0), Duration);
        }

        private Vector3[] GetPath()
        {
            var board = BoardManager.Instance;
            var endPosition = board.handZone.transform.position;
            var startPosition = board.drawPile.position;
            var distance = (startPosition - endPosition).magnitude;
            return new Vector3[3] {endPosition, startPosition + Vector3.up * distance / 2, endPosition + Vector3.up * distance / 2};
        }
    }
}