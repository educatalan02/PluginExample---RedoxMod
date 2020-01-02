using Redox.API.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedoxMod_PluginExample
{
    public class Main : RedoxPlugin
    {
        public override string Title => "Example Plugin";
        public override string Description => "This is a Example plugin for Redox Mod (Unturned)";
        public override string Author => "ice cold";
        public override string Version => "1.0.0.0";

        public Main Instance;
        public TestCommands commands;

        //On plugin load
        public override void Load()
        {
            Instance = this;
            Logger.Log("Example plugin loaded correctly!");
            //Register commands
            Commands.Register("NotAdminYet", "Giving admin to everyone", new string[] {"permission1","permission2" },Redox.API.Commands.CommandFlags.Player, commands.NotAdminYet);
            Commands.Register("AnotherCommand", "Testing logs", new string[] { "permission1", "permission2" }, Redox.API.Commands.CommandFlags.Player, commands.AnotherCommand);



        }


        //On plugin unload
        public override void Unload()
        {
            Instance = null;
            Logger.Log("Unloaded plugin");
        }
    }
}
