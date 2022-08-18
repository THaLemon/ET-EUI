﻿using System;

namespace ET
{
    [Timer(TimerType.PlayerOfflineOutTime)]
    public class PlayerOfflineOutTime: ATimer<PlayerOfflineOutTimeComponent>
    {
        public override void Run(PlayerOfflineOutTimeComponent self)
        {
            try
            {
                self.KickPlayer();
            }
            catch (Exception e)
            {
                Log.Error($"playeroffline timer error :{self.Id}\n{e}");
            }
        }
    }

    public class PlayerOfflineOutTimeComponentDestroySystem: DestroySystem<PlayerOfflineOutTimeComponent>
    {
        public override void Destroy(PlayerOfflineOutTimeComponent self)
        {
            TimerComponent.Instance.Remove(ref self.Timer);
        }
    }

    public class PlayerOfflineOutTimeComponentAwakeSystem: AwakeSystem<PlayerOfflineOutTimeComponent>
    {

        public override void Awake(PlayerOfflineOutTimeComponent self)
        {
            TimerComponent.Instance.Remove(ref self.Timer);
            self.Timer = TimerComponent.Instance.NewOnceTimer(TimeHelper.ServerNow() + 10000, TimerType.PlayerOfflineOutTime, self);
        }
    }

    public static class PlayerOfflineOutTimeComponentSystem
    {
        public static void KickPlayer(this PlayerOfflineOutTimeComponent self)
        {
            DisconnectHelper.Disconnect(self.GetParent<Session>()).Coroutine();
        }
    }
}