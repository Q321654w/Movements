using Movements.DeltaPositions.Decorators;
using Predicate.WithOutParameters;
using UnityEngine;
using Update;

namespace Movements.DeltaPositions
{
    public class CacheDeltaPositionWhile : DeltaPositionDecorator, IUpdate
    {
        private readonly IDeltaPosition _childDeltaPosition;
        private readonly IPredicate _predicate;
        
        private Vector3 _result;

        public CacheDeltaPositionWhile(IDeltaPosition childDeltaPosition, IPredicate predicate) : base(childDeltaPosition)
        {
            _childDeltaPosition = childDeltaPosition;
            _predicate = predicate;
        }

        public override Vector3 Evaluate()
        {
            return _result;
        }

        public void Update()
        {
            if (_predicate.Evaluate())
                UpdateResult();
        }
        
        private void UpdateResult()
        {
            _result = _childDeltaPosition.Evaluate();
        }
    }
}