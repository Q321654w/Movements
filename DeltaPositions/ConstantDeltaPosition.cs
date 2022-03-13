using UnityEngine;

namespace Movements.DeltaPositions
{
    public class ConstantDeltaPosition : IDeltaPosition
    {
        private readonly Vector3 _constant;

        public ConstantDeltaPosition(Vector3 constant)
        {
            _constant = constant;
        }

        public Vector3 Evaluate()
        {
            return _constant;
        }
    }
}