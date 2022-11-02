using UnityEngine;

namespace BallArena
{
    public class ColorizationBySpeedAbility : BaseAbility
    {
        private float speedChangeColor = 3f;

        protected IColored colored;
        protected IMoveable moveable;
        private float speed;

        public override bool IsCondiitonForUse => SpeedIsChanged() && moveable.PathData.Speed > speedChangeColor;        

        public override void Init(BaseUnit unit)
        {
            colored = (IColored)unit;
            moveable = (IMoveable)unit;
        }

        public override void Update()
        {
            if (IsCondiitonForUse)
            {
                colored.SetColor(Color.green);
            }
        }

        private bool SpeedIsChanged()
        {
            if (moveable.PathData != null)
            {
                if (speed != moveable.PathData.Speed)
                {
                    speed = moveable.PathData.Speed;
                    return true;
                }
            }            
            return false;
        }
    }
}