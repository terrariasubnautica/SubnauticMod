using System;
using Microsoft.Xna.Framework;
using SubnauticMod.Content.Items.Accessories;
using Terraria;
using Terraria.DataStructures;

namespace SubnauticMod {
	public static class SubnauticExtension {

		public static SubnauticModPlayer Subnautic(this Player player) {
			return player.GetModPlayer<SubnauticModPlayer>();
		}

		public static Vector2 TilePostoWorldPos(this Point16 point, float offsetX, float offsetY) {
			return new Vector2(point.X * 16f + offsetX, point.Y * 16f + offsetY);
		}

		public static float ManhattanDistance(this Vector2 a, Vector2 b) {
			return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
		}

		public static bool IsOxygenTank(this Item item) {
			if (item.modItem is OxygenTank) {
				return true;
			}
			return false;
		}

		public static (int index, OxygenTank tank) GetOxygenTank(this Player player) {
			int maxIdx = 5 + player.extraAccessorySlots;
			for (int i = 3; i < 3 + maxIdx; i++) {
				Item item = player.armor[i];
				if (!item.IsAir && item.modItem is OxygenTank oxygenTank) {
					return (i, oxygenTank);
				}
			}
			return (-1, null);
		}
	}
}
