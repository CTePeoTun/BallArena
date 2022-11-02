using System.Collections.Generic;

namespace BallArena
{
    public interface IRepeatebleFromData<DataType>
    {
        public void WithData(List<DataType> data);
    }
}