using System;
using UnityEngine;

namespace Core.Gameplay
{
    public class PlayerRocket : MonoBehaviour, IPlayerRocket
    {
        public event Action<Collision2D> CollisionEntered;
        public void MakeRocketLonger(float deltaSize)
        {
            transform.localScale += Vector3.right * deltaSize;
        }

        public void MakeRocketShorter(float deltaSize)
        {
            transform.localScale -= Vector3.right * deltaSize;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            CollisionEntered?.Invoke(other);
        }

        public Transform GetRocketTransform() => transform;
    }
}