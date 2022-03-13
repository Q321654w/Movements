using UnityEngine;
using Values;

namespace Movements.DeltaPositions.ValueToDeltaPosition.Dimension2
{
    public class ToYzDeltaPosition : IDeltaPosition
    {
        private readonly IValue<Vector2> _direction;

        public ToYzDeltaPosition(IValue<Vector2> direction)
        {
            _direction = direction;
        }

        public Vector3 Evaluate()
        {
            var direction = _direction.Evaluate();
            var delta = new Vector3(0,direction.x, direction.y);
            return delta;
        }
    }
}