using System.Collections.Generic;

public interface IKeepablePath : IKeepable
{
    public List<PathData> Points { get; }
    public void SaveData();

}
