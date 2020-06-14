using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SubnauticMod.Globals {
	public class SubnauticGlobalItem : GlobalItem {
		public override bool CanEquipAccessory(Item item, Player player, int slot) {
			if (item.type == ItemID.Flipper) {
				if (player.accFlipper || player.Subnautic().Fins) {
					return false;
				}
			}
			return true;
		}
	}
}
