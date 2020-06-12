using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;

namespace SubnauticMod {
	public static class SubnauticHelper {
		public static SubnauticModPlayer Subnautic(this Player player) {
			return player.GetModPlayer<SubnauticModPlayer>();
		}
	}
}
