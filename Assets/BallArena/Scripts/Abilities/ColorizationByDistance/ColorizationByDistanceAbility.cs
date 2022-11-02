using UnityEngine;

namespace BallArena
{
    public abstract class ColorizationByDistanceAbility : BaseAbility
    {
        private float distanceChangeColor = 3f;

        protected IColored colored;
        protected IMoveable moveable;
        private Vector3 lastPoint;

        public override bool IsCondiitonForUse => traveledDistance >= distanceChangeColor;

        protected abstract Color? GetColor();

        public override void Init(BaseUnit unit)
        {
            colored = (IColored)unit;
            moveable = (IMoveable)unit;
        }

        public override void Start()
        {
            base.Start();
            ClearTraveledDistance();
        }

        public override void Update()
        {
            UpdateTraveledDistance();
            if (IsCondiitonForUse)
            {
                Color? color = GetColor();
                if (color.HasValue)
                {
                    colored.SetColor(color.Value);
                }
                ClearTraveledDistance();
            }
        }

        private float traveledDistance;

        private void UpdateTraveledDistance()
        {
            traveledDistance += Vector3.Distance(lastPoint, moveable.Transform.localPosition);
            lastPoint = moveable.Transform.localPosition;
        }

        private void ClearTraveledDistance()
        {
            traveledDistance = 0f;
            lastPoint = moveable.Transform.localPosition;
        }

    }
}