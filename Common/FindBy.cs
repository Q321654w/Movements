using Collections;
using Predicate;
using Predicate.WithParameters;
using UnityEngine;

namespace Movements.Common
{
    public class FindBy<T> where T : MonoBehaviour
    {
        private readonly IIterate<T> _content;
        private readonly IDefault<T> _default;

        public FindBy(IIterate<T> content, IDefault<T> defaultValue)
        {
            _content = content;
            _default = defaultValue;
        }

        public Result<T> Evaluate(IPredicateWithParameters<T, T> predicate)
        {
            var defaultValue = _default.Evaluate();
            var obj = defaultValue;
            var count = _content.Count().Evaluate();
            
            for (int i = 0; i < count; i++)
            {
                var currentObj = _content.Element(i);

                if (predicate.Evaluate(obj, currentObj))
                    continue;

                obj = currentObj;
            }

            return obj != defaultValue ? new Result<T>(true, obj) : new Result<T>(false, obj);
        }
    }
}