using System.Collections.Generic;
using UnityEngine;

namespace BallArena
{
    public interface IRepeatablePath
    {
        public Transform Transform { get; }
        public List<PathData> Points { get; set; }
    }
}