using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Interfaces;
using System.ComponentModel;

namespace Mini_scp049 
{
    public sealed class Config : IConfig
    {
        [Description("Whether or not the plugin is enabled.")]
        public bool IsEnabled { get; set; } = true;

        [Description("The size multiplier for 49")]
        public float Size { get; private set; } = 0.5f;

        [Description("Whether or not to show a broadcast message to 049 when he spawns, explaining this plugin to them.")]
        public bool ShowSpawnBroadcastMessage { get; private set; } = true;

        [Description("The duration of the spawn broadcast.")]
        public ushort SpawnBroadcastMessageDuration { get; private set; } = 15;

        [Description("The message to broadcast to the 049.")]
        public string SpawnBroadcastMessage { get; private set; } =
            "<size=20><color=#00FFFF>당신은 미니<color=#FF0000>SCP-049입니다!</color>!";
    }

}
