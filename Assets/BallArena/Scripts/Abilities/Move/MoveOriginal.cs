using System.Linq;
using UnityEngine;

namespace BallArena
{
    public class MoveOriginal : MoveAbility
    {
        private float minSpeed = 1f;
        private float maxSpeed = 5f;

        private IKeepablePath keepable;

        public override void Init(BaseUnit unit)
        {
            base.Init(unit);
            keepable = (IKeepablePath)unit;
        }

        protected float GetSpeed()
        {
            return Random.Range(minSpeed, maxSpeed);
        }

        protected Vector3 GetRandomDirection()
        {
            return new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
        }

        private void SaveData()
        {
            keepable.Points.Add(moveable.PathData);
        }

        private void ResaveLastData()
        {
            keepable.Points.Last().Point = moveable.Transform.localPosition;
        }

        public override void Stop()
        {
            ResaveLastData();
            base.Stop();
        }

        protected override PathData GetTargetPathData()
        {
            float speed = GetSpeed();
            Vector3 direction = GetRandomDirection();
            Vector3 targetPoint = moveable.Transform.localPosition + direction * speed * timeChangeDirection;
            return new PathData()
            {
                Speed = speed,
                Point = targetPoint
            };
        }

        protected override void GetNextTargetForMoving()
        {
            base.GetNextTargetForMoving();
            SaveData();
        }
    }
}