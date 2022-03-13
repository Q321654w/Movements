using UnityEngine;

namespace Movements.DeltaPositions.Composites
{
    public abstract class DeltaPositionComposite : IDeltaPosition
    {
        protected readonly IDeltaPosition[] ChildDeltas;

        public DeltaPositionComposite(IDeltaPosition[] childDeltas)
        {
            ChildDeltas = childDeltas;
        }

        public abstract Vector3 Evaluate();
    }
}