using System.Collections.Generic;
using UnityEngine;

namespace BallArena
{
    public class RepeatPathAbility : Ability
    {
        private float timeChangeDirection = 1f;

        private IRepeatablePath repeatable;
        private Queue<PathData> path;
        private PathData target;
        private Vector3 lastPoint;
        private float journeyLength;

        public override bool IsCondiitonForUse => target != null;
        public override string Id => AbilityIds.PathRepeat;


        public override void Init(Unit unit)
        {
            repeatable = (IRepeatablePath)unit;
            path = new Queue<PathData>(repeatable.Points);
        }

        public override void Start()
        {
            base.Start();
            lastPoint = repeatable.Transform.localPosition;
            SelectTargetPoint();
        }

        private float time = 0;

        public override void Update()
        {
            if (IsCondiitonForUse)
            {
                time += Time.deltaTime;
                if (time >= timeChangeDirection)
                {
                    lastPoint = target.TargetPoint;
                    SelectTargetPoint();
                    time = 0;
                }
                if (IsCondiitonForUse)
                {
                    float distCovered = time * target.Speed;
                    float fractionOfJourney = distCovered / journeyLength;
                    repeatable.Transform.localPosition = Vector3.Lerp(lastPoint, target.TargetPoint, fractionOfJourney);
                }
            }
        }

        private void SelectTargetPoint()
        {
            if (path.Count > 0)
            {
                target = path.Dequeue();
                journeyLength = Vector3.Distance(lastPoint, target.TargetPoint);
            }
            else
            {
                target = null;
            }
        }
    }
}