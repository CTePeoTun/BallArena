using System.Collections.Generic;

public interface IKeepableColor : IKeepable
{
    public List<ColorData> Colors { get; }
    public float TimeStart { get; set; }
}
