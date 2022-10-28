using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealUnit : Unit, IColored, IMoveable, IKeepablePath, IKeepableColor
{
    public override string Id => UnitIds.Real;

    private float distanceTraveled;
    private List<PathData> points = new List<PathData>();
    private List<ColorData> colors = new List<ColorData>();

    public float Speed { get; set; }
    public Vector3 Direction { get; set; }
    public float DistanceTraveled { get; set; }

    public List<PathData> Points => points;
    public List<ColorData> Colors => colors;

    public float TimeStart { get; set; }

    protected override void InitAbilities()
    {
        AddAbility(AbilityIds.Move);
        AddAbility(AbilityIds.ColorizationBySpeed);
        AddAbility(AbilityIds.ColorizationByDistance);
    }

    public override void Start()
    {
        base.Start();
        TimeStart = Time.time;
    }

    public void SaveData()
    {
        points.Add(new PathData()
        {
            Speed = this.Speed,
            Direction = this.Direction,
            TargetPoint = View.transform.localPosition
        });
    }

    public void SetColor(Color color)
    {
        colors.Add(new ColorData() { 
            Color = color,
            TimeFromStart = Time.time - TimeStart
        });
        View.SetColor(color);
    }

}
