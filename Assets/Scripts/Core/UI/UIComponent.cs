using System;
using UnityEngine;

namespace Core.UI
{
    public class UIComponent : MonoBehaviour
    {
        public virtual void Hide(Action onHideComplete = null)
        {
            gameObject.SetActive(false);
            onHideComplete?.Invoke();
        }

        public virtual void Show(Action onShowComplete = null)
        {
            gameObject.SetActive(true);
            onShowComplete?.Invoke();
        }
    }
}