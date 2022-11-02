using UnityEngine;

namespace BallArena
{
    public class ColorizationByDistanceOriginal : ColorizationByDistanceAbility
    {
        private IKeepableColor keepableColor;

        public override void Init(BaseUnit unit)
        {
            base.Init(unit);
            keepableColor = (IKeepableColor)unit;
        }

        private void SaveData(Color color)
        {
            keepableColor.Colors.Add(color); 
        }

        protected override Color? GetColor()
        {
            Color color = Random.ColorHSV();
            SaveData(color);
            return color;
        }
    }
}