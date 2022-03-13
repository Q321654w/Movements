using UnityEngine;

namespace Movements.DeltaPositions.Decorators
{
    public abstract class DeltaPositionDecorator : IDeltaPosition
    {
        protected readonly IDeltaPosition ChildDeltaPosition;

        protected DeltaPositionDecorator(IDeltaPosition childDeltaPosition)
        {
            ChildDeltaPosition = childDeltaPosition;
        }

        public abstract Vector3 Evaluate();
    }
}