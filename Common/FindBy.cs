using Collections;
using Collections.Defaults;
using Collections.Predicates.Common;
using Collections.Predicates.WithParameters;

namespace Movements.Common
{
    public class FindBy<T> where T : IEqualsWithParameter<T>
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
            var count = _content.Count();

            for (int i = 0; i < count; i++)
            {
                var currentObj = _content.Element(i);

                if (predicate.Evaluate(obj, currentObj))
                    continue;

                obj = currentObj;
            }

            return obj.Equals(defaultValue) ? new Result<T>(false, obj) : new Result<T>(true, obj);
        }
    }
}