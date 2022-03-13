using Movements.DeltaPositions;
using UnityEngine;

namespace Movements.Position.Dimension3
{
    public class DefaultPosition : IPosition
    {
        private readonly IDeltaPosition _deltaPosition;
        private Vector3 _vector;

        public DefaultPosition(IDeltaPosition deltaPosition) : this(new Vector3(), deltaPosition)
        {
        }

        public DefaultPosition(Vector3 vector, IDeltaPosition deltaPosition)
        {
            _vector = vector;
            _deltaPosition = deltaPosition;
        }

        public Vector3 Coordinates()
        {
            var delta = _deltaPosition.Evaluate();
            _vector += delta;
            
            return _vector;
        }
    }
}