using Movements.DeltaPositions.Decorators;
using UnityEngine;

namespace Movements.DeltaPositions.Split.Dimension2
{
    public class XYSplit : DeltaPositionDecorator
    {
        public XYSplit(IDeltaPosition childDeltaPosition) : base(childDeltaPosition)
        {
        }

        public override Vector3 Evaluate()
        {
            var childDelta = ChildDeltaPosition.Evaluate();
            return new Vector3(childDelta.x, childDelta.y, 0);
        }
    }
}