using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown2D_Demo.Animations
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class PlayerPartAnimation : MonoBehaviour
    {
        [System.Serializable]
        public enum PartType
        {
            Base, Head, Body, Legs, Tools, Hands
        }

        [SerializeField] private PartType _type;
        
        private Animator _animator;
        private SpriteRenderer _renderer;
        private Vector2 _movementDirection;
        private bool _isRunning;

        public PartType Type { get => _type; }
        public Vector2 MovementDirection { get => _movementDirection; set => _movementDirection = value; }

        private void Start()
        {
            _animator = GetComponent<Animator>();

            _renderer = GetComponent<SpriteRenderer>();
            _renderer.sortingOrder = (int)_type;
        }

        private void Update()
        {
            _isRunning = _movementDirection != Vector2.zero;

            Vector2 current = new Vector2(_animator.GetFloat("X"), _animator.GetFloat("Y"));
            Vector2 previous = new Vector2(_animator.GetFloat("PrevX"), _animator.GetFloat("PrevY"));

            _animator.SetFloat("PrevX", current.x != 0f ? current.x : previous.x);
            _animator.SetFloat("PrevY", current.y != 0f ? current.y : previous.y);

            _animator.SetFloat("X", _movementDirection.x);
            _animator.SetFloat("Y", _movementDirection.y);

            _animator.SetBool("IsRunning", _isRunning);
        }
    }
}
