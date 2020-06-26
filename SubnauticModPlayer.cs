using System;
using System.Collections.Generic;
using SubnauticMod.Content.Items;
using SubnauticMod.Content.Items.Accessories;
using Terraria;
using Terraria.ModLoader;

namespace SubnauticMod {
	public class SubnauticModPlayer : ModPlayer {
		public bool OxygenTank = false;
		public bool Fins = false;

		public override void SetupStartInventory(IList<Item> items, bool mediumcoreDeath) {
			Item StarterLootBag = new Item();
			StarterLootBag.SetDefaults(ModContent.ItemType<StarterBag>());
			StarterLootBag.stack = 1;
			items.Add(StarterLootBag);
		}

		public override void ResetEffects() {
			OxygenTank = false;
			Fins = false;
			player.breathMax = 200;
			player.breath = Math.Min(player.breath, player.breathMax);
		}

		public override void PostUpdate() {
			OxygenTank oxygenTank = player.GetOxygenTank().tank;
			if (oxygenTank != null) {
				oxygenTank.currentO2Hold = Math.Min(Math.Max(player.breath - 200, 0), oxygenTank.oxygenCapacityIncrease);
			}
		}

		public override void PostUpdateRunSpeeds() {
			if (player.HeldItem.type == ModContent.ItemType<SeaGlide>()) {
				if (player.wet) {
					player.runAcceleration *= 3;
					player.maxRunSpeed *= 3;
				}
			}
		}
	}
}
