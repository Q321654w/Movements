using Movements.DeltaPositions.Decorators;
using UnityEngine;

namespace Movements.DeltaPositions.Split.Dimension2
{
    public class YZSplit : DeltaPositionDecorator
    {
        public YZSplit(IDeltaPosition childDeltaPosition) : base(childDeltaPosition)
        {
        }

        public override Vector3 Evaluate()
        {
            var childDelta = ChildDeltaPosition.Evaluate();
            return new Vector3(0, childDelta.y, childDelta.z);
        }
    }
}