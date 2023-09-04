using System;

namespace Core.UI.StarterPopup
{
    public class StarterPopup : UIComponent
    {
        public event Action StartButtonClicked;

        public void OnStartButtonClicked() => StartButtonClicked?.Invoke();
    }
}