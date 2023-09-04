using System;
using Core.UI.StarterPopup.Messages;
using MessagePipe;
using VContainer.Unity;

namespace Core.Gameplay
{
    public class GameLoop : IDisposable, IStartable
    {
        private readonly IBallHandler _ballHandler;
        private readonly ISubscriber<StartButtonClickedMsg> _subscriber;
        private IDisposable _disposable;

        public GameLoop(IBallHandler ballHandler, ISubscriber<StartButtonClickedMsg> subscriber)
        {
            _ballHandler = ballHandler;
            _subscriber = subscriber;
        }

        private void StartGame(StartButtonClickedMsg msg)
        {
            _ballHandler.StartImpulse();
        }

        public void FinishGame()
        {
            //если победа Победа, иначе Поражение
        }

        private void Subscribes()
        {
            var bag = DisposableBag.CreateBuilder();

            _subscriber.Subscribe(StartGame).AddTo(bag);

            _disposable = bag.Build();
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }

        public void Start()
        {
            Subscribes();
        }
    }
}