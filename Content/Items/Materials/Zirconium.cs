using Terraria.ID;
using Terraria.ModLoader;

namespace SubnauticMod.Content.Items.Materials {
	public class Zirconium : ModItem {

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
			item.createTile = ModContent.TileType<Tiles.Zirconium>();
		}
	}
}
