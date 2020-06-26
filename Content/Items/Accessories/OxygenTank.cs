using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace SubnauticMod.Content.Items.Accessories {

	[AutoloadEquip(EquipType.Back)]
	public class OxygenTank : ModItem {

		public override bool CloneNewInstances => true;
		public int currentO2Hold = 0;
		public int oxygenCapacityIncrease = 200;

		protected int value = 1000;
		protected int rarity = ItemRarityID.Green;
		protected string toolTip = "Increases Oxygen";
		protected string displayName = $"Standard {SubnauticMod.O2} Tank";

		public override void SetStaticDefaults() {
			toolTip += $"\nCan hold {oxygenCapacityIncrease} {SubnauticMod.O2}";
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

		public override void ModifyTooltips(List<TooltipLine> tooltips) {
			TooltipLine holdTooltip = new TooltipLine(mod, "O2Stored", $"({currentO2Hold}/{oxygenCapacityIncrease}) {SubnauticMod.O2} Stored") {
				overrideColor = Color.Cyan
			};
			int equipIndex = tooltips.FindIndex(i => i.Name == "ItemName") + 1;
			tooltips.Insert(equipIndex, holdTooltip);
		}

		public override TagCompound Save() {
			return new TagCompound {
				[nameof(currentO2Hold)] = currentO2Hold,
			};
		}

		public override void Load(TagCompound tag) {
			currentO2Hold = tag.GetInt(nameof(currentO2Hold));
		}

		public override void NetSend(BinaryWriter writer) {
			writer.Write(currentO2Hold);
		}

		public override void NetRecieve(BinaryReader reader) {
			currentO2Hold = reader.ReadInt32();
		}

		public override void UpdateEquip(Player player) {
			player.Subnautic().OxygenTank = true;
			player.breath += currentO2Hold;
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
			int index = player.GetOxygenTank().index;
			if (index != -1) {
				return slot == index;
			}
			return base.CanEquipAccessory(player, slot);
		}

		public override bool CanRightClick() {
			if (Main.LocalPlayer.GetOxygenTank().tank != null) {
				return true;
			}
			return base.CanRightClick();
		}

		public override void RightClick(Player player) {
			var (index, accessory) = player.GetOxygenTank();
			if (accessory != null) {
				Main.LocalPlayer.QuickSpawnClonedItem(accessory.item);
				Main.LocalPlayer.armor[index] = item.Clone();
			}
		}
	}
}
