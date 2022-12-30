using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerControls : MonoBehaviour
    {
        public float Horizontal { get => _joystick.Horizontal; }
        public float Vertical { get => _joystick.Vertical; }

        [SerializeField] private Joystick _joystick;
    }
}