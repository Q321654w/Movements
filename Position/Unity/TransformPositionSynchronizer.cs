using Movements.Position.Decorators;
using UnityEngine;

namespace Movements.Position.Unity
{
    public class TransformPositionSynchronizer : PositionDecorator
    {
        private readonly Transform _transform;

        public TransformPositionSynchronizer(IPosition childPosition, Transform transform) : base(childPosition)
        {
            _transform = transform;
        }

        public override Vector3 Coordinates()
        {
            Synchronize();
            return ChildPosition.Coordinates();
        }

        private void Synchronize()
        {
            _transform.position = ChildPosition.Coordinates();
        }
    }
}