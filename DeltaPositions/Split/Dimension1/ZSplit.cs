using Movements.DeltaPositions.Decorators;
using UnityEngine;

namespace Movements.DeltaPositions.Split.Dimension1
{
    public class ZSplit : DeltaPositionDecorator
    {
        public ZSplit(IDeltaPosition childDeltaPosition) : base(childDeltaPosition)
        {
        }

        public override Vector3 Evaluate()
        {
            var childDelta = ChildDeltaPosition.Evaluate();
            return new Vector3(0, 0, childDelta.z);
        }
    }
}