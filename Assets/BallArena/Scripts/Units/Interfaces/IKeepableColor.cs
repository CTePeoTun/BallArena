using System.Collections.Generic;

namespace BallArena
{
    public interface IKeepableColor : IKeepable
    {
        public List<ColorData> Colors { get; }
        public float TimeStart { get; set; }
    }
}