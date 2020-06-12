using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;

namespace terrariasubnautica {
    public static class SubnauticHelper {
        public static terrariasubnauticaPlayer Subnautic(this Player player) {
            return player.GetModPlayer<terrariasubnauticaPlayer>();
        }
    }
}
