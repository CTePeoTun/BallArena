using System.Collections.Generic;
using UnityEngine;

namespace BallArena
{
    public interface IKeepableColor : IKeepable
    {
        public List<Color> Colors { get;}
    }
}