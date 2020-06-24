using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SubnauticMod.Content.Items.Accessories {

	[AutoloadEquip(EquipType.Back)]
	public class OxygenTank : ModItem {

		protected int oxygenCapacityIncrease = 133;
		protected int value = 1000;
		protected int rarity = ItemRarityID.Green;
		protected string toolTip = "Increases Oxygen";
		protected string displayName = $"Standard {SubnauticMod.O2} Tank";

		public override void SetStaticDefaults() {
			//DisplayName.SetDefault("TutorialSword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault(toolTip);
			DisplayName.SetDefault(displayName);
		}

		public override void SetDefaults() {
			item.accessory = true;
			item.width = 40;
			item.height = 40;
			item.value = value;
			item.rare = rarity;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.Subnautic().OxygenTank = true;
		}

		public override void UpdateEquip(Player player) {
			player.breathMax += oxygenCapacityIncrease;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 1);
			recipe.AddTile(ModContent.TileType<Tiles.Fabricator>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool CanEquipAccessory(Player player, int slot) {
			return !player.Subnautic().OxygenTank;
		}
	}
}
