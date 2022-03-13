using UnityEngine;
using Values;

namespace Movements.DeltaPositions.ValueToDeltaPosition.Dimension3
{
    public class ToXyzDeltaPosition : IDeltaPosition
    {
        private readonly IValue<Vector3> _direction;

        public ToXyzDeltaPosition(IValue<Vector3> direction)
        {
            _direction = direction;
        }
        
        public Vector3 Evaluate()
        {
            var delta = _direction.Evaluate();
            return delta;
        }
    }
}