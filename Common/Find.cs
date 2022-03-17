using Collections;
using Collections.Defaults;
using Collections.Predicates.Common;
using Collections.Predicates.WithParameters;
using UnityEngine;
using Values;

namespace Movements.Common
{
    public class Find<T> : IValue<Result<T>> where T : IEqualsWithParameter<T>
    {
        private readonly IIterate<T> _content;
        private readonly IPredicateWithParameters<T, T> _predicate;
        private readonly IDefault<T> _default;

        public Find(IIterate<T> content, IDefault<T> defaultValue, IPredicateWithParameters<T, T> predicate)
        {
            _content = content;
            _default = defaultValue;
            _predicate = predicate;
        }

        public Result<T> Evaluate()
        {
            var defaultValue = _default.Evaluate();
            var obj = defaultValue;
            var count = _content.Count();

            for (int i = 0; i < count; i++)
            {
                var currentObj = _content.Element(i);

                if (_predicate.Evaluate(obj, currentObj))
                    continue;

                obj = currentObj;
            }

            return obj.Equals(defaultValue) ? new Result<T>(false, obj) : new Result<T>(true, obj);
        }
    }
}