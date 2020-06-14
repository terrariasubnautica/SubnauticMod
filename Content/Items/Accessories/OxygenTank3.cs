using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SubnauticMod.Content.Items.Accessories {

	[AutoloadEquip(EquipType.Back)]
	public class OxygenTank3 : OxygenTank {

		public OxygenTank3() {
			oxygenCapacityIncrease = 800;
			displayName = $"Ultra High Capacity {SubnauticMod.O2} Tank";
			toolTip = "Increases Oxygen substantially";
			value = 1000;
			rarity = ItemRarityID.Green;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.Subnautic().OxygenTank = true;
		}

	}
}
