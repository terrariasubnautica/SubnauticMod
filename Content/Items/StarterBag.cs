using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SubnauticMod.Content.Items   //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
	public class StarterBag : ModItem {
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Basic Survival Kit");
			Tooltip.SetDefault("Right click to open");
		}
		public override void SetDefaults() {
			item.maxStack = 999;     //This defines the items max stack
			item.consumable = true;  //Tells the game that this should be used up once opened
			item.width = 34;  //The size in width of the sprite in pixels.
			item.height = 34;    //The size in height of the sprite in pixels.
			item.rare = ItemRarityID.Orange; //The color the title of your Weapon when hovering over it ingame
		}
		public override bool CanRightClick() //this make so you can right click this item
		{
			return true;
		}

		public override void RightClick(Player player)  //this make so when you right click this item, then one of these items will drop
		{
			player.QuickSpawnItem(ModContent.ItemType<Content.Items.Placeables.Fabricator>());
		}
	}
}


