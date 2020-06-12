using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace terrariasubnautica.Content.Items.Weapons {
    public class PeeperYoyo : ModItem {
        public override void SetStaticDefaults() {
            Tooltip.SetDefault("Shoots out a peeper eye");

            // These are all related to gamepad controls and don't seem to affect anything else
            ItemID.Sets.Yoyo[item.type] = true;
            ItemID.Sets.GamepadExtraRange[item.type] = 15;
            ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
        }

        public override void SetDefaults() {
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.width = 32;
            item.height = 32;
            item.useAnimation = 25;
            item.useTime = 25;
            item.shootSpeed = 15f;
            item.knockBack = 2.5f;
            item.damage = 9;
            item.rare = ItemRarityID.White;
            item.crit = 8;

            item.melee = true;
            item.channel = true;
            item.noMelee = true;
            item.noUseGraphic = true;

            item.UseSound = SoundID.Item1;
            item.value = Item.sellPrice(silver: 1);
            item.shoot = ModContent.ProjectileType<Projectiles.PeeperYoyo>();
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock);
            recipe.AddTile(ModContent.TileType<Tiles.Fabricator>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
