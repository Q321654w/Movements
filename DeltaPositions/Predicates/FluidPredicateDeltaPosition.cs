using Collections.Predicates.WithOutParameters;
using UnityEngine;

namespace Movements.DeltaPositions.Predicates
{
    public class FluidPredicateDeltaPosition : IDeltaPosition
    {
        private readonly IPredicate _predicate;
        private readonly IDeltaPosition _first;
        private readonly IDeltaPosition _second;

        public FluidPredicateDeltaPosition(IPredicate predicate, IDeltaPosition first, IDeltaPosition second)
        {
            _predicate = predicate;
            _first = first;
            _second = second;
        }

        public Vector3 Evaluate()
        {
            return _predicate.Evaluate() ? _first.Evaluate() : _second.Evaluate();
        }
    }
}