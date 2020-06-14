using Terraria;
using Terraria.ID;

namespace SubnauticMod.Content.Items.Accessories {
	public class OxygenTank2 : OxygenTank {

		public OxygenTank2() {
			oxygenCapacityIncrease = 400;
			displayName = $"High Capacity {SubnauticMod.O2} Tank";
			toolTip = "Increases Oxygen significantly";
			value = 1000;
			rarity = ItemRarityID.Green;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.Subnautic().OxygenTank = true;
		}

	}
}
