using UnityEngine;

namespace BallArena
{
    public class MoveAbility : Ability
    {
        private float minSpeed = 1f;
        private float maxSpeed = 5f;
        private float timeChangeDirection = 1f;

        private IMoveable moveable;
        private IKeepablePath keepablePath;

        public override string Id => AbilityIds.Move;
        public override bool IsCondiitonForUse => true;          

        public override void Init(Unit unit)
        {
            moveable = (IMoveable)unit;
            keepablePath = (IKeepablePath)unit;
        }

        private float time;
        public override void Update()
        {
            if (IsCondiitonForUse)
            {
                time += Time.deltaTime;
                if (time >= timeChangeDirection)
                {
                    keepablePath.SaveData();
                    GetSpeedAndDirection();
                    time = 0;
                }
                Vector3 directionMove = moveable.Direction * moveable.Speed * Time.deltaTime;
                moveable.DistanceTraveled += Vector3.Magnitude(directionMove);
                moveable.Transform.Translate(directionMove);
            }
        }

        private void GetSpeedAndDirection()
        {
            moveable.Speed = GetSpeed();
            moveable.Direction = GetDirection();
        }

        private float GetSpeed()
        {
            return Random.Range(minSpeed, maxSpeed);
        }

        private Vector3 GetDirection()
        {
            return new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
        }

        public override void Stop()
        {
            keepablePath.SaveData();
            base.Stop();
        }

        public override void Start()
        {
            GetSpeedAndDirection();
        }
    }
}