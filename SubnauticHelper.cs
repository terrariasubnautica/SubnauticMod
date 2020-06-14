using Terraria;

namespace SubnauticMod {
	public static class SubnauticHelper {
		public static SubnauticModPlayer Subnautic(this Player player) {
			return player.GetModPlayer<SubnauticModPlayer>();
		}
	}
}
