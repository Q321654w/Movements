using Collections;
using Collections.Predicates.Common;
using Movements.Position;
using UnityEngine;
using Values;

namespace Movements.DeltaPositions
{
    public class DeltaPositionBetweenPositions<T> : IDeltaPosition
        where T : IPosition, IEqualsWithParameter<T>
    {
        private readonly IValue<Result<T>> _collection;
        
        private T _previousObject;

        public DeltaPositionBetweenPositions(IValue<Result<T>> collection)
        {
            _collection = collection;
        }

        public Vector3 Evaluate()
        {
            var findResult = _collection.Evaluate();

            if (!findResult.Success)
                return Vector3.zero;

            var currentObject = findResult.Content;
            var value = UpdateValue(currentObject);

            _previousObject = currentObject;

            return value;
        }

        private Vector3 UpdateValue(T currentObject)
        {
            if (_previousObject.Equals(currentObject))
                return Vector3.zero;

            return CalculateDeltaBetweenLastAndCurrentObjects(currentObject);
        }

        private Vector3 CalculateDeltaBetweenLastAndCurrentObjects(T currentObject)
        {
            var currentPosition = currentObject.Coordinates();
            var delta = currentPosition - _previousObject.Coordinates();

            return delta;
        }
    }
}