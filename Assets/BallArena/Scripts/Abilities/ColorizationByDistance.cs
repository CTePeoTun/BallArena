using UnityEngine;

namespace BallArena
{
    public class ColorizationByDistance : Ability
    {
        private float distanceChangeColor = 3f;

        private IColored colored;
        private IMoveable moveable;
        private float lastPoint;

        public override string Id => AbilityIds.ColorizationByDistance;
        public override bool IsCondiitonForUse => CheckThreeMetersBehind();

        public override void Init(Unit unit)
        {
            colored = (IColored)unit;
            moveable = (IMoveable)unit;
        }

        public override void Update()
        {
            if (IsCondiitonForUse)
            {
                colored.SetColor(Random.ColorHSV());
            }
        }

        private bool CheckThreeMetersBehind()
        {
            if (moveable.DistanceTraveled - lastPoint >= distanceChangeColor)
            {
                lastPoint = moveable.DistanceTraveled;
                return true;
            }
            return false;
        }
    }
}