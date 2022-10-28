using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public Action OnRestart;

    [SerializeField] private KeyCode restartKey = KeyCode.R;

    private void Update()
    {
        if (Input.GetKeyDown(restartKey))
        {
            OnRestart?.Invoke();
        }
    }
}
