namespace miniScp049.Events
{
    using miniScp049.Components;
    using Exiled.Events.EventArgs;

    public class PlayerHandler
    {
        public void OnSetClass(ChangingRoleEventArgs ev)
        {
            if (ev.Player?.IsHost ?? true)
                return;

            if (ev.NewRole == RoleType.Scp049)
            {
                if (ev.Player.GameObject.TryGetComponent(out miniScp049Controller customScp049))
                    customScp049.Destroy();

                ev.Player.GameObject.AddComponent<miniScp049Controller>();
            }
        }
    }
}
