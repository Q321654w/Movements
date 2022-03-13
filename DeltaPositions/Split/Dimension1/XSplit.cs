using Movements.DeltaPositions.Decorators;
using UnityEngine;

namespace Movements.DeltaPositions.Split.Dimension1
{
    public class XSplit : DeltaPositionDecorator
    {
        public XSplit(IDeltaPosition childDeltaPosition) : base(childDeltaPosition)
        {
        }

        public override Vector3 Evaluate()
        {
            var childDelta = ChildDeltaPosition.Evaluate();
            return new Vector3(childDelta.x, 0, 0);
        }
    }
}