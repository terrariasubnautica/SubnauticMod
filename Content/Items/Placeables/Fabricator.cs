using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace terrariasubnautica.Content.Items.Placeables {
    public class Fabricator : ModItem {
        public override void SetStaticDefaults() {
            Tooltip.SetDefault("Basic survival fabricator. Atomically rearranges raw resources into useful objects.");
        }

        public override void SetDefaults() {
            item.width = 28;
            item.height = 34;
            item.maxStack = 1;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.rare = ItemRarityID.Orange;
            item.consumable = true;
            item.value = 0;
            item.createTile = ModContent.TileType<Tiles.Fabricator>();
        }

        public override void AddRecipes() {
            ModRecipe modRecipe = new ModRecipe(mod);
            modRecipe.SetResult(this, 1);
            modRecipe.AddIngredient(ItemID.DirtBlock);
            modRecipe.AddRecipe();
        }
    }
}
