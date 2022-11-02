using UnityEngine;

namespace BallArena
{
    public interface IMoveable
    {
        public Transform Transform { get; }
        public PathData PathData { get; set; }
    }
}