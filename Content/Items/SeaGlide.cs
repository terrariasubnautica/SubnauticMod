using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SubnauticMod.Content.Items {
	public class SeaGlide : ModItem {
		//public override string Texture => "Terraria/Item_" + ItemID.Umbrella;

		public override void SetStaticDefaults() {
			//DisplayName.SetDefault("TutorialSword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Increases Speed In water");
			DisplayName.SetDefault("Sea Glide");
		}

		public override void SetDefaults() {
			item.channel = true;
			item.noMelee = true;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.width = 44;
			item.height = 26;
			item.value = 1000;
			item.rare = ItemRarityID.Green;
			item.holdStyle = ItemHoldStyleID.HarpHoldingOut;
			item.scale = 0.75f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 1);
			recipe.AddTile(ModContent.TileType<Tiles.Fabricator>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool CanUseItem(Player player) {
			return false;
		}

		public override Vector2? HoldoutOffset() {
			return Vector2.Zero;
		}

	}
}
