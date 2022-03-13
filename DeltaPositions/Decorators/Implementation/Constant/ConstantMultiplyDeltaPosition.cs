using UnityEngine;

namespace Movements.DeltaPositions.Decorators.Implementation.Constant
{
    public class ConstantMultiplyDeltaPosition : DeltaPositionDecorator
    {
        private readonly float _factor;
       
        public ConstantMultiplyDeltaPosition(IDeltaPosition childDeltaPosition, float factor) : base(childDeltaPosition)
        {
            _factor = factor;
        }

        public override Vector3 Evaluate()
        {
            var childDelta = ChildDeltaPosition.Evaluate();
            var delta = childDelta * _factor;
            return delta;
        }
    }
}