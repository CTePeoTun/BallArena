using System;

namespace BallArena
{
    public interface IFrameUpdater
    {
        Action OnUpdate { get; set; }
    }
}