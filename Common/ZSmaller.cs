using Collections.Predicates.WithParameters;
using Movements.Position;
using UnityEngine;

namespace Movements.Common
{
    public class ZSmaller<T> : IPredicateWithParameters<T, T> where T : IPosition
    {
        public bool Evaluate(T content1, T content2)
        {
            return content1.Coordinates().z < content2.Coordinates().z;
        }
    }
}