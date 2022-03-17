using UnityEngine;

namespace Movements.Position.Composites
{
    public abstract class PositionComposite : IPosition
    {
        protected readonly IPosition[] Childs;

        public PositionComposite(IPosition[] childs)
        {
            Childs = childs;
        }

        public abstract Vector3 Coordinates();
        public abstract bool Equals(IPosition source);
    }
}