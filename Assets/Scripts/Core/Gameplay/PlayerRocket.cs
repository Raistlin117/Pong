using UnityEngine;

namespace Core.Gameplay
{
    public class PlayerRocket : MonoBehaviour, IPlayerRocket
    {
        public void MakeRocketLonger(float deltaSize)
        {
            transform.localScale += Vector3.right * deltaSize;
        }

        public void MakeRocketShorter(float deltaSize)
        {
            transform.localScale -= Vector3.right * deltaSize;
        }

        public Transform GetRocketTransform() => transform;
    }
}