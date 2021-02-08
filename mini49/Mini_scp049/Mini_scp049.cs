namespace Mini_scp049
{
    using miniScp049.Components;
    using miniScp049.Events;
    using Exiled.API.Features;
    using System;
    using System.Collections.Generic;
    using Exiled.Events.EventArgs;
    using PlayerEvents = Exiled.Events.Handlers.Player;

    public class Mini_scp049 : Plugin<Config>
    {
        private static readonly Lazy<Mini_scp049> LazyInstance = new Lazy<Mini_scp049>(() => new Mini_scp049());

        internal PlayerHandler PlayerHandler { get; set; }

        public static Mini_scp049 Instance => LazyInstance.Value;

        private Mini_scp049()
        {
        }
        public override void OnEnabled()
        {
            RegisterEvents();
            if (!Config.IsEnabled)
            {
                Log.Info("Mini_scp049 is disabled via configs. It will not be loaded.");
                return;
            }
            Log.Info("Mini_scp049 is abled");

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
            foreach (var player in Player.Get(Team.SCP))
            {
                if (player.ReferenceHub.TryGetComponent<miniScp049Controller>(out var customScp049))
                    customScp049.Destroy();
            }

            base.OnDisabled();
        }
        internal void OnSetClass(ChangingRoleEventArgs ev)
        {
            if (ev.Player.GameObject == PlayerManager.localPlayer) return;

            if (!Config.IsEnabled || ev.NewRole == RoleType.Scp049)
            {
                if (ev.Player.Role == RoleType.Scp049)
                {

                }
            }
        }

        internal void RegisterEvents()
        {
            PlayerHandler = new PlayerHandler();

            PlayerEvents.ChangingRole += PlayerHandler.OnSetClass;
        }

        internal void UnregisterEvents()
        {
            PlayerEvents.ChangingRole -= PlayerHandler.OnSetClass;

            PlayerHandler = null;
        }
    }
}
