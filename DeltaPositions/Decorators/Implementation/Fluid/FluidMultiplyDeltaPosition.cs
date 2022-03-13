using UnityEngine;
using Values;

namespace Movements.DeltaPositions.Decorators.Implementation.Fluid
{
    public class FluidMultiplyDeltaPosition : DeltaPositionDecorator
    {
        private readonly IValue<float> _factor;

        public FluidMultiplyDeltaPosition(IDeltaPosition childDeltaPosition, IValue<float> factor) : base(childDeltaPosition)
        {
            _factor = factor;
        }

        public override Vector3 Evaluate()
        {
            var childDelta = ChildDeltaPosition.Evaluate();
            var delta = childDelta * _factor.Evaluate() ;
            return delta;
        }
    }
}