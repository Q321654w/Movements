using Movements.Common;
using Movements.DeltaPositions;
using Movements.Position;
using UnityEngine;

namespace Movements.WrongRealizations
{
    //Not working
    public class Vector3PhysicPosition : IPosition
    {
        private readonly CustomCollider _customCollider;
        private readonly IDeltaPosition _deltaPosition;
        
        private Vector3 _position;

        public Vector3PhysicPosition(CustomCollider customCollider, IDeltaPosition deltaPosition) : this(customCollider, deltaPosition,
            new Vector3())
        {
        }

        public Vector3PhysicPosition(CustomCollider customCollider, IDeltaPosition deltaPosition, Vector3 position)
        {
            _position = position;
            _customCollider = customCollider;
            _deltaPosition = deltaPosition;
        }

        public Vector3 Coordinates()
        {
            return _position;
        }

        public void Update()
        {
            var delta = _deltaPosition.Evaluate();

            _position += delta;
            _customCollider.transform.position = _position;
            
            if (_customCollider.HasCollisions())
                SynchronizePositionWith(_customCollider.transform);
        }

        private void SynchronizePositionWith(Transform transform)
        {
            _position = transform.position;
        }
    }
}