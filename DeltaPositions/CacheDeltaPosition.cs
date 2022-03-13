using Movements.Common;
using Movements.DeltaPositions.Decorators;
using UnityEngine;
using Update;
using Values;

namespace Movements.DeltaPositions
{
    public class CacheDeltaPosition : DeltaPositionDecorator, IUpdate
    {
        private readonly IDeltaPosition _childDeltaPosition;
        private readonly IValue<float> _deltaTime;
        private readonly Timer _timer;
        
        private Vector3 _result;

        public CacheDeltaPosition(IDeltaPosition childDeltaPosition, IValue<float> deltaTime, Timer timer) : base(childDeltaPosition)
        {
            _childDeltaPosition = childDeltaPosition;
            _deltaTime = deltaTime;
            _timer = timer;
        }

        public override Vector3 Evaluate()
        {
            return _result;
        }

        public void Update()
        {
            var time = _deltaTime.Evaluate();
            _timer.Update(time);

            if (_timer.TimeIsUp())
            {
                UpdateResult();
                _timer.Reset();
            }
        }
        
        private void UpdateResult()
        {
            _result = _childDeltaPosition.Evaluate();
        }
    }
}