using System;
using UnityEngine;

public interface IMoveable
{
    public float Speed { get; set; }
    public Vector3 Direction { get; set; }
    public float DistanceTraveled { get; set; }
    public void SaveData();    
}
