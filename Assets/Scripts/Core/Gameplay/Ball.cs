using System;
using UnityEngine;

namespace Core.Gameplay
{
    public class Ball : MonoBehaviour, IBall
    {
        [SerializeField] private Rigidbody2D _rigidbody;

        private void Start()
        {
            AddForce(Vector2.up * 300);
        }

        public void AddForce(Vector2 forceDirection)
        {
            Debug.Log(_rigidbody);
            _rigidbody.AddForce(forceDirection, ForceMode2D.Force);
        }
    }
}