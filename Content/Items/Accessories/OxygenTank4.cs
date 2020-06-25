using Terraria.ID;
using Terraria.ModLoader;

namespace SubnauticMod.Content.Items.Accessories {

	[AutoloadEquip(EquipType.Back)]
	public class OxygenTank4 : OxygenTank {
		public override string Texture => "SubnauticMod/Content/Items/Accessories/OxygenTank";

		public OxygenTank4() {
			oxygenCapacityIncrease = 400;
			displayName = $"Lightweight High Capacity {SubnauticMod.O2} Tank";
			toolTip = "Increases Oxygen significantly while also not decreasing swim speed";
			value = 1000;
			rarity = ItemRarityID.Green;
		}

	}
}
