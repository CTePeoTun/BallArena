using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatPathAbility : Ability
{
    private IRepeatablePath repeatable;
    private Queue<PathData> path;
    private PathData target;
    private Vector3 lastPoint;
    private float journeyLength;

    public override bool IsCondiitonForUse => target != null;
    public override string Id => AbilityIds.PathRepeat;
    

    public override void OnInit(Unit unit)
    {
        repeatable = (IRepeatablePath)unit;
        path = new Queue<PathData>(repeatable.Points);  
    }

    public override void Start()
    {
        base.Start();
        lastPoint = unit.View.transform.localPosition;
        SelectTargetPoint();
    }

    float time = 0;

    public override void Update()
    {
        if (IsCondiitonForUse)
        {
            time += Time.deltaTime;
            if (time >= 1f)
            {
                lastPoint = target.TargetPoint;
                SelectTargetPoint();
                time = 0;
            }
            if (IsCondiitonForUse)
            {
                float distCovered = time * target.Speed;
                float fractionOfJourney = distCovered / journeyLength;
                unit.View.transform.localPosition = Vector3.Lerp(lastPoint, target.TargetPoint, fractionOfJourney);
            }            
        }
    }

    private void SelectTargetPoint()
    {
        if(path.Count > 0)
        {
            target = path.Dequeue();
            journeyLength = Vector3.Distance(lastPoint, target.TargetPoint);
        }   else
        {
            target = null;
        }     
    }
}
