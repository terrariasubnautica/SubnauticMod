using Terraria.ModLoader;

namespace SubnauticMod {
	public class SubnauticMod : Mod {
		public SubnauticMod() {
			Properties = new ModProperties() {
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true,
				AutoloadBackgrounds = true
			};
		}

		public override void PostSetupContent() {
			Mod drp = ModLoader.GetMod("DiscordRP");
			if(drp != null) {
				drp.Call("MainMenu", "Subnautica Mod", "In Main Menu", "mod_placeholder", "Subnautica Mod");
			}
		}
	}
}
