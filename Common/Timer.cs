namespace Movements.Common
{
    public class Timer 
    {
        private readonly float _interval;

        private float _passedTime;
        private bool _isStopped;
        private bool _timeIsUp;

        public Timer(float interval) : this(interval, false, true)
        {
        }

        public Timer(float interval, bool isStopped) : this(interval, false, isStopped)
        {
        }
        
        public Timer(float interval, bool timeIsUp, bool isStopped)
        {
            _isStopped = isStopped;
            _interval = interval;
            _timeIsUp = timeIsUp;
        }

        public float PassedTime()
        {
            return _passedTime;
        }

        public bool IsStopped()
        {
            return _isStopped;
        }

        public void Resume()
        {
            _isStopped = false;
        }

        public void Stop()
        {
            _isStopped = true;
        }

        public void Update(float deltaTime)
        {
            if (_isStopped)
                return;

            _passedTime += deltaTime;

            if (_passedTime < _interval)
                return;

            _timeIsUp = true;
        }

        public void Reset()
        {
            _timeIsUp = false;
            _passedTime = 0;
        }

        public bool TimeIsUp()
        {
            return _timeIsUp;
        }
    }
}