using System;
using UnityEngine;

namespace Player
{
    [Serializable]
    public class PlayerMovementSettings
    {
        public float Speed { get => _speed; }
        public AnimationCurve SpeedSensitivityCurve { get => _speedSensitivityCurve; }
        public float ModelRotationLerp { get => _modelRotationLerp; }

        [SerializeField] private float _speed = 5;
        [SerializeField] private float _modelRotationLerp = 0.1f;
        [SerializeField] private AnimationCurve _speedSensitivityCurve;
    }
}
