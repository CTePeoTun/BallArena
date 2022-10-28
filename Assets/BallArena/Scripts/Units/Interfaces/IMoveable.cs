using UnityEngine;

namespace BallArena
{
    public interface IMoveable
    {
        public Transform Transform { get; }
        public float Speed { get; set; }
        public Vector3 Direction { get; set; }
        public float DistanceTraveled { get; set; }
        public void SaveData();
    }
}