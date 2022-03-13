using UnityEngine;
using Values;

namespace Movements.DeltaPositions.ValueToDeltaPosition.Dimension2
{
    public class ToXzDeltaPosition : IDeltaPosition
    {
        private readonly IValue<Vector2> _direction;

        public ToXzDeltaPosition(IValue<Vector2> direction)
        {
            _direction = direction;
        }

        public Vector3 Evaluate()
        {
            var direction = _direction.Evaluate();

            var delta = new Vector3(direction.x, 0, direction.y);
            return delta;
        }
    }
}