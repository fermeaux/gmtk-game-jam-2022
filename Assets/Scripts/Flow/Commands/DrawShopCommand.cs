using System.Collections;
using Board;
using DG.Tweening;
using UnityEngine;

namespace Flow.Commands
{
    public class DrawShopCommand : IFlowCommand
    {
        private readonly int _placement;
        private const float Duration = 1f;
        
        public DrawShopCommand(int placement)
        {
            _placement = placement;
        }
        
        public IEnumerator Execute()
        {
            var dice = BoardManager.Instance.DrawShop(_placement);
            AnimateDice(dice);
            yield return new WaitForSeconds(Duration);
        }

        private void AnimateDice(Transform dice)
        {
            dice.transform.DOPath(GetPath(), Duration, PathType.CubicBezier);
            dice.transform.DORotate(new Vector3(0, 0, 0), Duration);
        }

        private Vector3[] GetPath()
        {
            var placements = BoardManager.Instance.shop.placements;
            var endPosition = placements.shop[_placement].position;
            var startPosition = placements.drawPile.position;
            var distance = (startPosition - endPosition).magnitude;
            return new Vector3[3] {endPosition, startPosition + Vector3.up * distance / 2, endPosition + Vector3.up * distance / 2};
        }
    }
}