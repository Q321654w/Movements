using Collections.Predicates.WithOutParameters;
using Values;

namespace Movements.Common
{
    public class TimerPredicate : IPredicate
    {
        private readonly Timer _timer;
        private readonly IValue<float> _deltaTime;

        public TimerPredicate(Timer timer, IValue<float> deltaTime)
        {
            _timer = timer;
            _deltaTime = deltaTime;
        }

        public bool Evaluate()
        {
            if (_timer.IsStopped())
                _timer.Resume();

            var elapsedTime = _deltaTime.Evaluate();
            _timer.Update(elapsedTime);

            var timeIsUp = _timer.TimeIsUp();

            if (timeIsUp)
                _timer.Stop();

            return timeIsUp;
        }
    }
}