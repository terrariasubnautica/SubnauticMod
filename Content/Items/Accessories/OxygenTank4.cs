using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace terrariasubnautica.Content.Items.Accessories {
    public class OxygenTank4 : ModItem {
        public override void SetStaticDefaults() {
            //DisplayName.SetDefault("TutorialSword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Increases Oxygen Substantially while also not decreasing swim speed");
            DisplayName.SetDefault("LightWeight High Capacity 02 tank");
        }

        public override void SetDefaults() {
            item.accessory = true;
            item.width = 40;
            item.height = 40;
            item.value = 1000;
            item.rare = ItemRarityID.Green;
        }
        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.Subnautic().OxygenTank4 = true;

        }
        public override void UpdateEquip(Player player) {
            player.breath += 300;
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
