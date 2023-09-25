using System;
using UnityEngine;

namespace Core.Gameplay
{
    public interface IPlayerRocket
    {
        event Action<Collision2D> CollisionEntered;
        Transform GetRocketTransform();
        void MakeRocketLonger(float deltaSize);
        void MakeRocketShorter(float deltaSize);
    }
}