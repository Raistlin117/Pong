using UnityEngine;

namespace Core.Gameplay
{
    public class Ball : MonoBehaviour, IBall
    {
        [SerializeField] private Rigidbody2D _rigidbody;

        public void SetVelocity(Vector2 forceDirection)
        {
            _rigidbody.velocity = forceDirection;
        }
    }
}