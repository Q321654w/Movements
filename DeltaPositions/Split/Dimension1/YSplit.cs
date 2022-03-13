using Movements.DeltaPositions.Decorators;
using UnityEngine;

namespace Movements.DeltaPositions.Split.Dimension1
{
    public class YSplit : DeltaPositionDecorator
    {
        public YSplit(IDeltaPosition childDeltaPosition) : base(childDeltaPosition)
        {
        }

        public override Vector3 Evaluate()
        {
            var childDelta = ChildDeltaPosition.Evaluate();
            return new Vector3(0, childDelta.y, 0);
        }
    }
}