using Collections;
using Collections.Predicates.Common;
using Movements.DeltaPositions.Composites;
using UnityEngine;
using Values;

namespace Movements.DeltaPositions
{
    public class DeltaPositionBetweenGameObjects<T> : DeltaPositionComposite
        where T : IDeltaPosition, IEqualsWithParameter<T>
    {
        private readonly IValue<Result<T>> _collection;

        private Vector3 _lastPosition;
        private T _previousObject;

        public DeltaPositionBetweenGameObjects(IDeltaPosition[] childDeltas, IValue<Result<T>> collection) : base(childDeltas)
        {
            _collection = collection;
           
            _lastPosition = _previousObject.Evaluate();
        }

        public override Vector3 Evaluate()
        {
            var findResult = _collection.Evaluate();

            if (!findResult.Success)
                return Vector3.zero;

            var currentObject = findResult.Content;
            var value = UpdateValue(currentObject);

            _previousObject = currentObject;
            _lastPosition = _previousObject.Evaluate();

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
            var currentPosition = currentObject.Evaluate();
            var delta = currentPosition - _previousObject.Evaluate();

            return delta;
        }
    }
}