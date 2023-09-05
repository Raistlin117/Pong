using Core.Configs;
using Core.GameInput;
using Core.Gameplay;
using Core.UI.Menu;
using Core.UI.StarterPopup;
using Core.UI.StarterPopup.Messages;
using MessagePipe;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core.Infrastructure
{
    public class GameLifetimeScope : LifetimeScope
    {
        [Header("Components")]
        [SerializeField] private UIMenuScreen _uiMenuScreen;
        [SerializeField] private StarterPopup _starterPopup;
        [SerializeField] private Ball _ballComponent;
        [SerializeField] private PlayerRocket _playerRocket;
        [SerializeField] private InputDirectionProvider _inputDirectionProvider;
        [SerializeField] private GameConfigs _gameConfigs;

        protected override void Configure(IContainerBuilder builder)
        {
            // Registering MessagePipe
            var options = builder.RegisterMessagePipe();
            builder.RegisterBuildCallback(c => GlobalMessagePipe.SetProvider(c.AsServiceProvider()));
            builder.RegisterMessageBroker<StartButtonClickedMsg>(options);
            
            // Project Registers
            builder.RegisterComponent(_ballComponent).As<IBall>();
            builder.RegisterComponent(_playerRocket).As<IPlayerRocket>();
            builder.RegisterComponent(_uiMenuScreen);
            builder.Register<GameConfigs>(Lifetime.Singleton);
            builder.Register<IBallHandler, BallHandler>(Lifetime.Singleton);
            builder.RegisterEntryPoint<UIMenuScreenHandler>();
            builder.RegisterComponent(_starterPopup).As<IStarterPopup>();
            builder.RegisterEntryPoint<StarterPopupHandler>();
            builder.RegisterEntryPoint<GameLoop>();
            builder.RegisterEntryPoint<PlayerRocketHandler>();
            builder.RegisterComponent(_inputDirectionProvider).As<IInputDirectionProvider>();
            builder.RegisterInstance(_gameConfigs.PlayerConfigs);
        }
    }
}