using Predicate.WithParameters;
using UnityEngine;

namespace Movements.Common
{
    public class ZSmaller<T> : IPredicateWithParameters<T, T> where T : MonoBehaviour
    {
        public bool Evaluate(T content1, T content2)
        {
            return content1.transform.position.z < content2.transform.position.z;
        }
    }
}