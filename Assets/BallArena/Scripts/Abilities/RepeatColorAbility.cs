using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatColorAbility : Ability
{
    private IColored colored;
    private IRepeatableColor repeatable;
    private float timeStart;
    private Queue<ColorData> queueColor;
    private ColorData target;

    public override bool IsCondiitonForUse => target != null && (Time.time - timeStart) >= target.TimeFromStart;
    public override string Id => AbilityIds.ColorRepeat;

    public override void OnInit(Unit unit)
    {
        colored = (IColored)unit;
        repeatable = (IRepeatableColor)unit;
        queueColor = new Queue<ColorData>(repeatable.Colors);
    }

    public override void Start()
    {
        base.Start();
        timeStart = Time.time;
        GetNextTarget();
    }

    public override void Update()
    {
        if (IsCondiitonForUse)
        {
            colored.SetColor(target.Color);
            GetNextTarget();
        }
    }

    private void GetNextTarget()
    {
        if (queueColor.Count > 0)
        {
            target = queueColor.Dequeue();
        } else
        {
            target = null;
        }
    }

}
