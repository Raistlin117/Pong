using UnityEngine;

namespace Core.Gameplay
{
    public interface IPlayerRocket
    {
        Transform GetRocketTransform();
        void MakeRocketLonger(float deltaSize);
        void MakeRocketShorter(float deltaSize);
    }
}