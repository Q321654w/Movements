using UnityEngine;
using Values;

namespace Movements.DeltaPositions.Decorators.Implementation.Fluid
{
    public class FluidApplyDeltaPosition : DeltaPositionDecorator
    {
        private readonly IValue<Vector3> _factor;
        
        public FluidApplyDeltaPosition(IDeltaPosition childDeltaPosition, IValue<Vector3> factor) : base(childDeltaPosition)
        {
            _factor = factor;
        }

        public override Vector3 Evaluate()
        {
            var childDelta = ChildDeltaPosition.Evaluate();
            var delta = childDelta + _factor.Evaluate();
            return delta;
        }
    }
}