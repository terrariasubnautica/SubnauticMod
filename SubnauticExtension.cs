using System;
using Microsoft.Xna.Framework;
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
	}
}
