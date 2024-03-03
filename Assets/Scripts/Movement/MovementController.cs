using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TopDown2D_Demo.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private float _walkSpeed;

        private Rigidbody2D _rigidbody;
        private Vector2 _movementDirection;

        public Vector2 MovementDirection { get => _movementDirection; }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.gravityScale = 0f;
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = _movementDirection * _walkSpeed;
        }

        public void OnMove(InputValue value)
        {
            _movementDirection = value.Get<Vector2>();
        }
    }
}
