namespace miniScp049.Components
{
    using CustomPlayerEffects;
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;
    using MEC;
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using Mini_scp049;
    using PlayerEvents = Exiled.Events.Handlers.Player;

    public class miniScp049Controller : MonoBehaviour
    {
        private Player player;
        private Scp207 scp207;

        private void Awake()
        {

            player = Player.Get(gameObject);
            scp207 = player.ReferenceHub.playerEffectsController.GetEffect<Scp207>();

        }

        private void Start()
        {
            player.Scale *= Mini_scp049.Instance.Config.Size;

            if (Mini_scp049.Instance.Config.ShowSpawnBroadcastMessage)
            {
                player.ClearBroadcasts();
                player.Broadcast(Mini_scp049.Instance.Config.SpawnBroadcastMessageDuration, string.Format(Mini_scp049.Instance.Config.SpawnBroadcastMessage));
            }
        }

        private void Update()
        {
            if (player.Role != RoleType.Scp049)
            {
                Destroy();
                return;
            }

            if (!scp207.Enabled)
                player.EnableEffect<Scp207>();
        }

        private void OnDestroy() => PartiallyDestroy();

        public void PartiallyDestroy()
        {

            if (player == null)
                return;

            scp207.ServerDisable();

            player.Scale = new Vector3(1, 1, 1);
            player.AdrenalineHealth = 0;
        }

        public void Destroy()
        {
            try
            {
                Destroy(this);
            }
            catch (Exception exception)
            {
                Log.Error($"Error, cannot destroy: {exception}");
            }
        }
    }
}
