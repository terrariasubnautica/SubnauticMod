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
			player.breath = Math.Min(player.breath, player.breathMax);
			OxygenTank = false;
			Fins = false;
		}

		public override void UpdateEquips(ref bool wallSpeedBuff, ref bool tileSpeedBuff, ref bool tileRangeBuff) {
			OxygenTank oxygenTank = player.GetOxygenTank().tank;
			if (oxygenTank != null) {
				if (player.breath == player.breathMax) {
					if (oxygenTank.currentO2Hold < oxygenTank.oxygenCapacityIncrease) {
						oxygenTank.currentO2Hold += 3;
						oxygenTank.currentO2Hold = Math.Min(oxygenTank.oxygenCapacityIncrease, oxygenTank.currentO2Hold);
						player.breath -= 3;
					}
				}
				else if (player.breath < player.breathMax - 3) {
					int oxygenNeed = player.breathMax - player.breath - 3;
					if (oxygenTank.currentO2Hold > 0) {
						int oxygenTankUsed = Math.Min(oxygenTank.currentO2Hold, oxygenNeed);
						oxygenTank.currentO2Hold -= oxygenTankUsed;
						player.breath += oxygenTankUsed;
					}
				}
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
