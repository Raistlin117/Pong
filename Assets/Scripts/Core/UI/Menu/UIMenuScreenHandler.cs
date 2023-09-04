using VContainer.Unity;

namespace Core.UI.Menu
{
    public class UIMenuScreenHandler : IStartable
    {
        private readonly UIMenuScreen _uiMenuScreen;

        public UIMenuScreenHandler(UIMenuScreen uiMenuScreen)
        {
            _uiMenuScreen = uiMenuScreen;
        }
        
        void IStartable.Start()
        {
            _uiMenuScreen.StartButtonClicked += OnStartButtonClicked;
        }

        private void OnStartButtonClicked()
        {
            _uiMenuScreen.Hide();
        }
    }
}