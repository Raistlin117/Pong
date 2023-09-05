using UnityEngine;

namespace Core.Bot
{
    public class BotRocket : MonoBehaviour, IBotRocket
    {
        [SerializeField] private Transform _ballTransform;

        private void Update()
        {
            var transformPosition = transform.position;
            transformPosition.x = _ballTransform.position.x;
            transform.position = transformPosition;
        }
    }
}