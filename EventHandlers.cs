﻿namespace ForceSTS.Events
{
    using Exiled.Events.EventArgs;
    using Exiled.API.Features;
    using UnityEngine;
    internal sealed class EventHandlers
    {

        public Vector3 spawnPos = new Vector3(150, 994, -46);
        public Vector3 spawnPos2 = new Vector3(151, 994, -48);

        public void OnRespawningTeam(RespawningTeamEventArgs ev)
        {
            if (ev.NextKnownTeam == Respawning.SpawnableTeamType.NineTailedFox)
            {
                int i = 0;
                int x = 0;
                foreach (Player ply in ev.Players)
                {
                    MEC.Timing.CallDelayed(0.5f, () =>
                    {
                        if (ply.Role == RoleType.NtfCaptain)
                        {
                            ply.Position = new Vector3(178, 994, -53);
                            ply.Rotation = new Vector3(0, 0, 0);
                        }
                        else if (i < 30)
                        {
                            ply.Position = spawnPos + new Vector3(i, 0); ply.Rotation = new Vector3(0, 90, 0);
                            i += 2;
                        }
                        else if (x < 27)
                        {
                            ply.Position = spawnPos2 + new Vector3(x, 0); ply.Rotation = new Vector3(0, 90, 0);
                            x += 2;
                        }
                    });
                }
            }
        }
    }
}