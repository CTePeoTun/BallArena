using System.Collections.Generic;
using UnityEngine;

namespace BallArena
{
    public class ShadowUnit : BaseUnit, IMoveable, IColored
    {
        public Transform Transform => view.transform;
        public PathData PathData { get; set; }

        public void InitAbilities(HistoryData data)
        {
            InitMoveAbility(data.Paths);
            InitColorByDistanceAbility(data.Colors);
            InitColorBySpeed();
        }

        private void InitMoveAbility(List<PathData> dataPaths)
        {
            if (dataPaths != null)
            {
                AddAbility<MoveShadow>().WithData(dataPaths);
            }
            else
            {
                AddAbility<MoveOriginal>();
            }
        }

        private void InitColorByDistanceAbility(List<Color> dataColors)
        {
            if (dataColors != null)
            {
                AddAbility<ColorizationByDistanceShadow>().WithData(dataColors);
            }
            else
            {
                AddAbility<ColorizationByDistanceOriginal>();
            }
        }

        private void InitColorBySpeed()
        {
            AddAbility<ColorizationBySpeedAbility>();
        }

        public void SetColor(Color color)
        {
            view.SetColor(color);
        }

    }
}