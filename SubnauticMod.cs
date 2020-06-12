using Terraria.ModLoader;

namespace terrariasubnautica {
    public class terrariasubnautica : Mod {
        public terrariasubnautica() {
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true,
                AutoloadBackgrounds = true
            };
        }

        public override void PostSetupContent() {
            Mod drp = ModLoader.GetMod("DiscordRP");
            if (drp != null) {
                drp.Call("MainMenu", "Subnautica Mod", "In Main Menu", "mod_placeholder", "Subnautica Mod");
            }
        }
    }
}
