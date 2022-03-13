using UnityEngine;

namespace Movements.DeltaPositions.Decorators.Implementation.Constant
{
    public class ConstantApplyDeltaPosition : DeltaPositionDecorator
    {
        private readonly Vector3 _value;

        public ConstantApplyDeltaPosition(IDeltaPosition childDeltaPosition, Vector3 value) : base(childDeltaPosition)
        {
            _value = value;
        }

        public override Vector3 Evaluate()
        {
            var childDelta = ChildDeltaPosition.Evaluate();
            var delta = childDelta + _value;
            return delta;
        }
    }
}