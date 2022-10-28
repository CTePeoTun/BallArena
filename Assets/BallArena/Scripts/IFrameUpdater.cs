using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFrameUpdater
{
    Action OnUpdate { get; set; }
}
