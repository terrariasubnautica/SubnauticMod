using System.Collections.Generic;
using SubnauticMod.UI;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace SubnauticMod {
	public class SubnauticMod : Mod {

		/// <summary>
		/// Short-hand string for O-subscript-2
		/// </summary>
		public static string O2 => "O\x2082";

		public UserInterface breathResources;
		public O2Level o2Level;
		public static SubnauticMod Instance = null;

		public SubnauticMod() {
			Properties = new ModProperties() {
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true,
				AutoloadBackgrounds = true
			};
			Instance = this;
		}

		public override void Load() {
			if (!Main.dedServ) {
				breathResources = new UserInterface();
				o2Level = new O2Level();
				breathResources.SetState(o2Level);
				SubnauticILEdits.Initialize();
			}
		}

		public override void Unload() {
			Instance = null;
			Terraria.DataStructures.TileEntity.Clear();
		}

		public override void PostSetupContent() {
			Mod drp = ModLoader.GetMod("DiscordRP");
			if (drp != null) {
				drp.Call("MainMenu", "Subnautica Mod", "In Main Menu", "mod_subnautic", "Subnautica Mod");
			}
		}

		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers) {
			int ResourceIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Resource Bars"));
			if (ResourceIndex != -1) {
				layers.Insert(ResourceIndex, new LegacyGameInterfaceLayer(
					"Honkai Impact 3: Laser Charge Level",
					delegate {
						if (o2Level.visible && !Main.LocalPlayer.dead) {
							breathResources.Update(Main._drawInterfaceGameTime);
							o2Level.Draw(Main.spriteBatch);
						}
						return true;
					},
					InterfaceScaleType.UI)
				);
			}
		}
	}
}
