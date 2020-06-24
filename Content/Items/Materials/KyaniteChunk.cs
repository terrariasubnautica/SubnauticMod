using Terraria.ID;
using Terraria.ModLoader;

namespace SubnauticMod.Content.Items.Materials {
	public class KyaniteChunk : ModItem {

		public override string Texture => "SubnauticMod/Content/Items/Materials/Kyanite";
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
			item.rare = ItemRarityID.Cyan;
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.KyaniteChunk>();
		}
	}
}
