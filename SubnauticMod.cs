using Terraria.ModLoader;

namespace SubnauticMod {
	public class SubnauticMod : Mod {

		/// <summary>
		/// Short-hand string for O-subscript-2
		/// </summary>
		public static string O2 => "O\x2082";

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
			if (drp != null) {
				drp.Call("MainMenu", "Subnautica Mod", "In Main Menu", "mod_subnautic", "Subnautica Mod");
			}
		}
	}
}
