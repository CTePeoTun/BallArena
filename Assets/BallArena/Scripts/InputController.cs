using System;
using UnityEngine;

namespace BallArena
{
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
}