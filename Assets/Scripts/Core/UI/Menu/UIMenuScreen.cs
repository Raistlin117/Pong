using System;

namespace Core.UI.Menu
{
    public class UIMenuScreen : UIComponent
    {
        public event Action StartButtonClicked;
        
        public void OnStartButtonClicked() => StartButtonClicked?.Invoke();
    }
}