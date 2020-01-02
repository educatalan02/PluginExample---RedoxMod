using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redox.API.Commands;
using Redox.API.Player;
using Redox.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using RedoxMod_PluginExample;
using UnityEngine;

using Redox.API.DependencyInjection;

namespace RedoxMod_PluginExample
{
    public class TestCommands
    {
        public ILogger Logger = DependencyContainer.Resolve<ILogger>();
        public void NotAdminYet(CommandExecutor executor, string[] args)
        {
            var player = ((IPlayer)executor.User).Object as UnturnedPlayer;

            if(!(player.IsAdmin))
            {
                player.Message("Due you're not admin, I gived you It");
                player.IsAdmin = true;
            }
            else
            {
                player.Message("You're already an admin.");
                return;
            }
        }


        public void AnotherCommand(CommandExecutor playerexecutor, string[] arguments)
        {
            foreach(SteamPlayer player in Provider.clients)
            {
                foreach(string text in arguments)
                {
                    //Testing logs
                    Logger.Log(text);
                    ChatManager.serverSendMessage(text, Color.white, null, player, EChatMode.SAY, null, true);
                }
            }
        }
    }
}
