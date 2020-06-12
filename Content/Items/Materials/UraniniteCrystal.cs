using Terraria.ModLoader;
using Terraria.ID;

namespace terrariasubnautica.Content.Items.Materials {
    public class UraniniteCrystal : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Uraninte");
            Tooltip.SetDefault("Yes");
        }

        public override void SetDefaults() {
            item.width = 16;
            item.height = 16;
            item.maxStack = 999;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 10;
            item.useAnimation = 10;
            item.autoReuse = true;
        }
    }
}
