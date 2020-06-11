using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SubnauticMod.Content.Items {
	public class SeaGlide : ModItem {
		public override string Texture => "Terraria/Item_" + ItemID.Umbrella;

		public override void SetStaticDefaults() {
			//DisplayName.SetDefault("TutorialSword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Increases Speed In water");
			DisplayName.SetDefault("Sea Glide");
		}

		public override void SetDefaults() {
			item.channel = true;
			item.noMelee = true;
			item.width = 40;
			item.height = 40;
			item.value = 1000;
			item.rare = ItemRarityID.Green;
			item.holdStyle = ItemHoldStyleID.HoldingUp;
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
