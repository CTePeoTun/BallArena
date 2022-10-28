using System.Collections.Generic;

namespace BallArena
{
    public interface IKeepablePath : IKeepable
    {
        public List<PathData> Points { get; }
        public void SaveData();

    }
}