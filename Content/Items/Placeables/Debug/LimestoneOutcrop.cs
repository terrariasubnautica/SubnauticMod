using Terraria.ID;
using Terraria.ModLoader;

namespace SubnauticMod.Content.Items.Materials {
	public class LimestoneOutcrop : ModItem {

		public override string Texture => "SubnauticMod/Content/Tiles/LimestoneOutcrop";
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("[c/FF0000:Debug Object]");
		}

		public override void SetDefaults() {
			item.width = 16;
			item.height = 16;
			item.maxStack = 999;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTime = 10;
			item.useAnimation = 10;
			item.autoReuse = true;
			item.rare = ItemRarityID.Blue;
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.LimestoneOutcrop>();
		}
	}
}
