using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Win32;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SubnauticMod.Content.Tiles {
	public class FabricatorEntity : ModTileEntity {

		public bool open = false;

		public override void Update() {
			float dist = float.MaxValue;
			foreach (Player player in Main.player) {
				dist = Math.Min(dist, Position.TilePostoWorldPos(8f, 24f).ManhattanDistance(player.position));
			}
			open = dist <= 50f;

			Fabricator fabtile = (Fabricator) TileLoader.GetTile(ModContent.TileType<Fabricator>());
			if (fabtile.curFrame != 1)
				fabtile.open |= open;
		}

		public override bool ValidTile(int i, int j) {
			Tile tile = Main.tile[i, j];
			return tile.active() && tile.type == ModContent.TileType<Fabricator>();
		}

		public override int Hook_AfterPlacement(int i, int j, int type, int style, int direction) {
			// i - 1 and j - 2 come from the fact that the origin of the tile is "new Point16(1, 2);", so we need to pass the coordinates back to the top left tile. If using a vanilla TileObjectData.Style, make sure you know the origin value.
			if (Main.netMode == NetmodeID.MultiplayerClient) {
				NetMessage.SendTileSquare(Main.myPlayer, i - 1, j - 1, 3); // this is -1, -1, however, because -1, -1 places the 3 diameter square over all the tiles, which are sent to other clients as an update.
				NetMessage.SendData(MessageID.TileEntityPlacement, -1, -1, null, i - 1, j - 2, Type, 0f, 0, 0, 0);
				return -1;
			}
			return Place(i - 1, j - 2);
		}
	}
}
