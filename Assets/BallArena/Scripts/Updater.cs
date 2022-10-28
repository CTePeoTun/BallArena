using System;
using UnityEngine;

public class Updater : MonoBehaviour, IFrameUpdater
{
    private Action onUpdate;
    public Action OnUpdate { get => onUpdate; set => onUpdate = value; }

    private void Update()
    {
        onUpdate?.Invoke();
    }
}
