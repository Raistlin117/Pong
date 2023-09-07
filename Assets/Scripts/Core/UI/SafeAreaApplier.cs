using UnityEngine;

namespace Core.UI
{
    [RequireComponent(typeof(RectTransform))]
    public class SafeAreaApplier : MonoBehaviour
    {
        [SerializeField] private RectTransform _safeAreaPanel;
        [SerializeField] bool _conformX = true;
        [SerializeField] bool _conformY = true;

        void Awake ()
        {
            ApplySafeArea();
        }

        void ApplySafeArea ()
        {
            Rect safeArea = Screen.safeArea;
        
            if (!_conformX)
            {
                safeArea.x = 0;
                safeArea.width = Screen.width;
            }

            if (!_conformY)
            {
                safeArea.y = 0;
                safeArea.height = Screen.height;
            }

            var anchorMin = safeArea.position;
            var anchorMax = safeArea.position + safeArea.size;
            
            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;

            _safeAreaPanel.anchorMin = anchorMin;
            _safeAreaPanel.anchorMax = anchorMax;
        }
    }
}