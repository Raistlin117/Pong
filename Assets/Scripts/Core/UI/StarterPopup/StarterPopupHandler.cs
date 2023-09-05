using Core.Gameplay;
using Core.UI.StarterPopup.Messages;
using MessagePipe;
using VContainer.Unity;

namespace Core.UI.StarterPopup
{
    public class StarterPopupHandler : IStartable
    {
        private readonly IStarterPopup _starterPopup;
        private readonly IPublisher<StartButtonClickedMsg> _publisher;

        public StarterPopupHandler(IStarterPopup starterPopup, IPublisher<StartButtonClickedMsg> publisher)
        {
            _starterPopup = starterPopup;
            _publisher = publisher;
        }
        
        public void Start()
        {
            _starterPopup.StartButtonClicked += OnStartButtonClicked;
        }

        private void OnStartButtonClicked()
        {
            _publisher.Publish(new StartButtonClickedMsg());
        }
    }
}