using System.Collections.Generic;
using UnityEngine;

namespace BallArena
{
    public class MoveShadow : MoveAbility, IRepeatebleFromData<PathData>
    {
        private Queue<PathData> data;
        public void WithData(List<PathData> data)
        {
            this.data = new Queue<PathData>(data);
        }

        protected override PathData GetTargetPathData()
        {
            if (data.Count > 0)
            {
                return data.Dequeue();
            } else
            {
                return null;
            }            
        }
    }
}