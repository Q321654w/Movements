using Predicate.WithOutParameters;
using UnityEngine;

namespace Movements.DeltaPositions.Predicates
{
    public class ConstantPredicateDeltaPosition : IDeltaPosition
    {
        private readonly IPredicate _predicate;
        private readonly Vector3 _first;
        private readonly Vector3 _second;

        public ConstantPredicateDeltaPosition(IPredicate predicate, Vector3 first, Vector3 second)
        {
            _predicate = predicate;
            _first = first;
            _second = second;
        }

        public Vector3 Evaluate()
        {
            return _predicate.Evaluate() ? _first : _second;
        }
    }
}