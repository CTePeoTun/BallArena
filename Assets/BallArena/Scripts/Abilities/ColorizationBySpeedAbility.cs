using UnityEngine;

namespace BallArena
{
    public class ColorizationBySpeedAbility : Ability
    {
        private float speedChangeColor = 3f;

        private IColored colored;
        private IMoveable moveable;
        private float speed;

        public override string Id => AbilityIds.ColorizationBySpeed;
        public override bool IsCondiitonForUse => SpeedIsChanged() && moveable.Speed > speedChangeColor;        

        public override void Init(Unit unit)
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
            if (speed != moveable.Speed)
            {
                speed = moveable.Speed;
                return true;
            }
            return false;
        }
    }
}