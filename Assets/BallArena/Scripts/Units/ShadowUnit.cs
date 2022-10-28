using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowUnit : Unit, IRepeatablePath, IColored, IRepeatableColor
{
    public override string Id => UnitIds.Shadow;

    public List<PathData> Points { get; set; }

    public List<ColorData> Colors { get; set; }

    public void SetColor(Color color)
    {
        View.SetColor(color);
    }

    protected override void InitAbilities()
    {
        AddAbility(AbilityIds.PathRepeat);
        AddAbility(AbilityIds.ColorRepeat);
    }
}
