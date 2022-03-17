using UnityEngine;

namespace Movements.Position.Decorators
{
    public abstract class PositionDecorator : IPosition
    {
        protected readonly IPosition ChildPosition;

        public PositionDecorator(IPosition childPosition)
        {
            ChildPosition = childPosition;
        }

        public abstract Vector3 Coordinates();
        public abstract bool Equals(IPosition source);
    }
}