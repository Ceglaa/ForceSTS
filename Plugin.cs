namespace ForceSTS
{
    using Exiled.API.Features;
    using ForceSTS.Events;
    using System;

    public class Plugin : Plugin<Config>
    {
        public static Plugin Singleton;
        private EventHandlers eventHandlers;
        public override string Name { get; } = "ForceSTS";
        public override string Author { get; } = "Jesus-QC, Cegla";
        public override string Prefix { get; } = "ForceSTS";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(3, 0, 0);

        public override void OnEnabled()
        {
            RegisterEvents();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
            base.OnDisabled();
        }
        private void RegisterEvents()
        {
            eventHandlers = new EventHandlers();
            Exiled.Events.Handlers.Server.RespawningTeam += eventHandlers.OnRespawningTeam;

        }
        private void UnregisterEvents()
        {
            Exiled.Events.Handlers.Server.RespawningTeam -= eventHandlers.OnRespawningTeam;
            eventHandlers = null;
        }
    }
}