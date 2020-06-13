using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SubnauticMod.Content.Items.Accessories {
	public class Fins : ModItem {
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Allows the player to move through water without being slowed down");
		}

		public override void SetDefaults() {
			item.accessory = true;
			item.width = 32;
			item.height = 32;
			item.value = 1000;
			item.rare = ItemRarityID.Green;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.Subnautic().Fins = true;
			player.accFlipper = true;
		}

		public override void UpdateEquip(Player player) {
			player.ignoreWater = true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 1);
			recipe.AddTile(ModContent.TileType<Tiles.Fabricator>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

	}
}
