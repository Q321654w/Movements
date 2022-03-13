using UnityEngine;
using Values;

namespace Movements.DeltaPositions.Decorators.Implementation
{
    public class SmoothInterpolateDeltaPosition : DeltaPositionDecorator
    {
        private readonly IValue<float> _deltaTime;
        private readonly float _translationTime;

        private Vector3 _partsSum;
        private Vector3 _targetDelta;
        private Vector3 _previousDelta;
        private float _progress;

        public SmoothInterpolateDeltaPosition(IDeltaPosition childDelta, IValue<float> deltaTime, 
            float translationTime) : base(childDelta)
        {
            _deltaTime = deltaTime;
            _translationTime = translationTime;
            
            _partsSum = Vector3.zero;
            _targetDelta = Vector3.zero;
            _previousDelta = Vector3.zero;
            _progress = 0;
        }

        public override Vector3 Evaluate()
        {
            var childDelta = ChildDeltaPosition.Evaluate();

            var isChildDeltaZero = childDelta == Vector3.zero;

            if (isChildDeltaZero && _targetDelta == Vector3.zero)
                return Vector3.zero;

            if (!isChildDeltaZero)
                CalculateNewTargetDelta(childDelta);

            _progress += _deltaTime.Evaluate();

            if (_progress < _translationTime)
                return CalculatePart();

            var correctedDelta = CorrectDelta();
            Reset();

            return correctedDelta;
        }

        private Vector3 CalculatePart()
        {
            var currentDelta = _targetDelta * _progress;
            var part = currentDelta - _previousDelta;
            _previousDelta = currentDelta;
            _partsSum += part;

            return part;
        }

        private void CalculateNewTargetDelta(Vector3 childDelta)
        {
            _progress = 0;

            _targetDelta = _targetDelta - _partsSum + childDelta;

            _previousDelta = Vector3.zero;
            _partsSum = Vector3.zero;
        }

        private Vector3 CorrectDelta()
        {
            return _targetDelta - _partsSum;
        }

        private void Reset()
        {
            _previousDelta = Vector3.zero;
            _targetDelta = Vector3.zero;
            _partsSum = Vector3.zero;
            _progress = 0;
        }
    }
}