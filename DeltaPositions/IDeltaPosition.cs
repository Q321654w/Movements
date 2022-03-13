using UnityEngine;
using Values;

namespace Movements.DeltaPositions
{
    public interface IDeltaPosition : IValue<Vector3>
    {
        new Vector3 Evaluate();
    }
}