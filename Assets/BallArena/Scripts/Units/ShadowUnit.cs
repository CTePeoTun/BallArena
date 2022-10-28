using System.Collections.Generic;
using UnityEngine;

namespace BallArena
{
    public class ShadowUnit : Unit, IRepeatablePath, IColored, IRepeatableColor
    {
        public override string Id => UnitIds.Shadow;

        public List<PathData> Points { get; set; }

        public List<ColorData> Colors { get; set; }

        public Transform Transform => view.transform;

        public void SetColor(Color color)
        {
            view.SetColor(color);
        }

        protected override void InitAbilities()
        {
            AddAbility(AbilityIds.PathRepeat);
            AddAbility(AbilityIds.ColorRepeat);
        }
    }
}