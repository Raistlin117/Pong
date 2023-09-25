
using UnityEngine;

namespace Core.Gameplay
{
    public interface IBallHandler
    {
        void StartVelocity();
        void SetVelocity(Vector2 velocityDirection);
    }
}