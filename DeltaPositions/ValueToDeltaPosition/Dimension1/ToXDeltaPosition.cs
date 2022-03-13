using UnityEngine;
using Values;

namespace Movements.DeltaPositions.ValueToDeltaPosition.Dimension1
{
    public class ToXDeltaPosition : IDeltaPosition
    {
        private readonly IValue<float> _value;

        public ToXDeltaPosition(IValue<float> value)
        {
            _value = value;
        }

        public Vector3 Evaluate()
        {
            var value = _value.Evaluate();
            return new Vector3(value, 0, 0);
        }
    }
}