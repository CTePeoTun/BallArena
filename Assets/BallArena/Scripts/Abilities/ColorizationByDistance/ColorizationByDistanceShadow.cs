using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BallArena
{
    public class ColorizationByDistanceShadow : ColorizationByDistanceAbility, IRepeatebleFromData<Color>
    {
        private Queue<Color> data;
        public void WithData(List<Color> data)
        {
            this.data = new Queue<Color>(data);
        }

        protected override Color? GetColor()
        {
            if (data.Count > 0)
            {
                return data.Dequeue();
            }
            else
            {
                return null;
            }
        }
    }
}