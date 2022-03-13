using UnityEngine;
using Values;

namespace Movements.DeltaPositions.ValueToDeltaPosition.Dimension1
{
    public class ToZDeltaPosition : IDeltaPosition
    {
        private readonly IValue<float> _value;

        public ToZDeltaPosition(IValue<float> value)
        {
            _value = value;
        }

        public Vector3 Evaluate()
        {
            var value = _value.Evaluate();
            return new Vector3(0,0,value);
        }
    }
}