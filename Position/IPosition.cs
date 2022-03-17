using Collections.Predicates.Common;
using UnityEngine;

namespace Movements.Position
{
    public interface IPosition : IEqualsWithParameter<IPosition>
    {
        Vector3 Coordinates();
    }
}