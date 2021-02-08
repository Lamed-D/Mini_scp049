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
            if (Mini_scp049.Instance.Config.ShowSpawnBroadcastMessage)
            {
                player.ClearBroadcasts();
                player.Broadcast(Mini_scp049.Instance.Config.SpawnBroadcastMessageDuration, string.Format(Mini_scp049.Instance.Config.SpawnBroadcastMessage));
            }

            Timing.CallDelayed(1.5f, () =>
            {
                player.Scale *= Mini_scp049.Instance.Config.Size;
            });

            Timing.CallDelayed(5f, () =>
            {
                player.MaxHealth = Mini_scp049.Instance.Config.SCP049Health;
            });

            Timing.CallDelayed(5.5f, () =>
            {
                player.Health = Mini_scp049.Instance.Config.SCP049Health;
            });
        }

        private void Update()
        {
            if (player.Role != RoleType.Scp049)
            {
                Destroy();
                return;
            }

            //if (!scp207.Enabled)
               // player.EnableEffect<Scp207>();
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
