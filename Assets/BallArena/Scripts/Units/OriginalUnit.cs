using System.Collections.Generic;
using UnityEngine;

namespace BallArena
{
    public class OriginalUnit : BaseUnit, IColored, IMoveable, IKeepablePath, IKeepableColor
    {
        private float distanceTraveled;
        private List<PathData> points = new List<PathData>();
        private List<Color> colors = new List<Color>();

        public List<PathData> Points => points;
        public Transform Transform => view.transform;
        public PathData PathData { get; set; }
        public List<Color> Colors => colors;

        public void InitAbilities()
        {
            AddAbility<MoveOriginal>();
            AddAbility<ColorizationBySpeedAbility>();
            AddAbility<ColorizationByDistanceOriginal>();
        }

        public void SetColor(Color color)
        {
            view.SetColor(color);
        }

    }
}