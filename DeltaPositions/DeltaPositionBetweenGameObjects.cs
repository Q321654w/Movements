using Collections;
using UnityEngine;
using Values;

namespace Movements.DeltaPositions
{
    public class DeltaPositionBetweenGameObjects<T> : IDeltaPosition where T : MonoBehaviour
    {
        private readonly IDeltaPosition _objectDelta;

        private readonly IValue<Result<T>> _value;

        private Vector3 _lastPosition;
        private T _previousObject;

        public DeltaPositionBetweenGameObjects(IDeltaPosition objectDelta, T previousObject, IValue<Result<T>> value)
        {
            _objectDelta = objectDelta;

            _previousObject = previousObject;
            _value = value;
            _lastPosition = _previousObject.transform.position;
        }

        public Vector3 Evaluate()
        {
            var result = _value.Evaluate();

            if (!result.Success)
                return Vector3.zero;

            var currentNearest = result.Content;

            if (_previousObject == null)
                return CalculateDeltaWithNewNearest(currentNearest);

            if (_previousObject != currentNearest)
                return CalculateDeltaBetweenLastAndCurrentObjects(currentNearest);

            _lastPosition = _previousObject.transform.position;
            return Vector3.zero;
        }

        private Vector3 CalculateDeltaWithNewNearest(T currentNearest)
        {
            _previousObject = currentNearest;

            var lastNearestCurrentPosition = _lastPosition + _objectDelta.Evaluate();
            var delta = currentNearest.transform.position - lastNearestCurrentPosition;
            _lastPosition = _previousObject.transform.position;

            return delta;
        }

        private Vector3 CalculateDeltaBetweenLastAndCurrentObjects(T nearestObject)
        {
            var currentPosition = nearestObject.transform.position;

            var delta = currentPosition - _previousObject.transform.position;
            _previousObject = nearestObject;

            return delta;
        }
    }
}