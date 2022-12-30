using System;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        [Inject] private Player _player;

        private void Update()
        {
            _animator.SetBool("isWalking", _player.Movement.IsMoving);
        }
    }
}
