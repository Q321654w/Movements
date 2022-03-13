using UnityEngine;

namespace Movements.DeltaPositions.Composites
{
    public class ApplyPositionComposite : DeltaPositionComposite
    {
        public ApplyPositionComposite(IDeltaPosition[] childDeltas) : base(childDeltas)
        {
        }

        public override Vector3 Evaluate()
        {
            var result = new Vector3();
            
            for (int i = 0; i < ChildDeltas.Length; i++)
            {
                result += ChildDeltas[i].Evaluate();
            }

            return result;
        }
    }
}