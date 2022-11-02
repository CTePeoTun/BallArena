using System;
using UnityEngine;

namespace BallArena
{
    public abstract class MoveAbility : BaseAbility
    {
        protected float timeChangeDirection = 1f;
        protected IMoveable moveable;
        private Vector3 lastPoint;
        private float journeyLength;
        private Action onTimerAlaram;

        public override bool IsCondiitonForUse => moveable.PathData != null;
        protected abstract PathData GetTargetPathData();

        public override void Init(BaseUnit unit)
        {
            moveable = (IMoveable)unit;
        }

        public override void Start()
        {
            GetNextTargetForMoving();
            SubscribeToTimer();
        }

        private void SubscribeToTimer()
        {
            onTimerAlaram = GetNextTargetForMoving;
        }

        public override void Update()
        {
            UpdateWaitingTime();
            if (IsCondiitonForUse)
            {                
                Move();
            }
        }

        private float time;
        private void UpdateWaitingTime()
        {
            time += Time.deltaTime;
            if (time >= timeChangeDirection)
            {
                onTimerAlaram?.Invoke();
                time = 0;
            }
        }

        private void Move()
        {
            float distCovered = time * moveable.PathData.Speed;
            float fractionOfJourney = distCovered / journeyLength;
            moveable.Transform.localPosition = Vector3.Lerp(lastPoint, moveable.PathData.Point, fractionOfJourney);
        }

        protected virtual void GetNextTargetForMoving()
        {
            lastPoint = moveable.PathData != null ? moveable.PathData.Point : moveable.Transform.localPosition;
            moveable.PathData = GetTargetPathData();
            if (moveable.PathData != null)
            {
                journeyLength = Vector3.Distance(lastPoint, moveable.PathData.Point);
            }            
        }
    }
}