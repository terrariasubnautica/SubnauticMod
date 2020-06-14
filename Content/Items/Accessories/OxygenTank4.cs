using Terraria;
using Terraria.ID;

namespace SubnauticMod.Content.Items.Accessories {
	public class OxygenTank4 : OxygenTank {

		public OxygenTank4() {
			oxygenCapacityIncrease = 400;
			displayName = $"Lightweight High Capacity {SubnauticMod.O2} Tank";
			toolTip = "Increases Oxygen significantly while also not decreasing swim speed";
			value = 1000;
			rarity = ItemRarityID.Green;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.Subnautic().OxygenTank = true;
		}

	}
}
